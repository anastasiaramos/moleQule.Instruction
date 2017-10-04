using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Face;
using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class ExamenEditForm : ExamenForm
    {
        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Examen _entity;

        protected Preguntas _preguntas_examen = null;

        public override Examen Entity { get { return _entity; } set { _entity = value; } }
        public override ExamenInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(true) : null; } }

        #endregion

        #region Factory Methods

        public ExamenEditForm() : this(-1, true) { }

        public ExamenEditForm(long oid)
            : this(oid, true) { }

        public ExamenEditForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();

            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.EXAMEN_EDIT_TITLE + " " + Entity.Titulo.ToUpper();
            }

            _mf_type = ManagerFormType.MFEdit;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = Examen.Get(oid);

            string[] preguntas = _entity.MemoPreguntas.Split(';');

            //se genera la lista de preguntas del examen con la que se va a trabajar
            foreach (string item in preguntas)
            {
                try
                {
                    if (item != string.Empty)
                    {
                        long oid_pregunta = Convert.ToInt32(item);
                        Pregunta_Examen p_examen = Pregunta_Examen.NewChild(_entity);
                        p_examen.OidPregunta = oid_pregunta;
                        _entity.Pregunta_Examens.AddItem(p_examen);
                    }
                }
                catch
                {
                    continue;
                }
            }

            _entity.BeginEdit();
            _mf_type = ManagerFormType.MFEdit;
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {

                this.Datos.RaiseListChangedEvents = false;

                // do the save
                try
                {
                    string memo = Entity.MemoPreguntas;

                    foreach (Pregunta_Examen item in Entity.Pregunta_Examens)
                    {
                        //si se han añadido preguntas al examen, se añaden al memo
                        if (memo.IndexOf(";" + item.OidPregunta.ToString() + ";") == -1
                            || memo.IndexOf(item.OidPregunta.ToString() + ";") != 0)
                            memo += item.OidPregunta.ToString() + ";";
                    }

                    if (memo != string.Empty)
                    {
                        //se cambian los ; por coma porque los estamos guardando en la base de datos
                        //separandolos con ; y el SQL necesita que se separen con ,
                        memo = memo.Substring(0, memo.Length - 1);
                        memo = memo.Replace(';', ',');
                    }

                    _preguntas_examen = Preguntas.GetPreguntasByList(memo, _entity.SessionCode);

                    List<long> incluidas = new List<long>();

                    //hay que reconstruir el memo_preguntas
                    string memo_viejo = _entity.MemoPreguntas;
                    _entity.MemoPreguntas = string.Empty;

                    foreach (Pregunta_Examen item in Entity.Pregunta_Examens)
                    {
                        if (_preguntas_examen.GetItem(item.OidPregunta).Activa)
                        {
                            incluidas.Add(item.OidPregunta);
                            _entity.MemoPreguntas += item.OidPregunta.ToString() + ";";
                        }
                    }

                    GetPreguntasReservadas();

                    foreach (Pregunta item in _preguntas_examen)
                    {
                        if (item.Reservada && !preguntas_mismo_dia.Contains(item.Oid))
                        {
                            //hay que comprobar que estaba en el memopreguntas
                            //si no estaba, es que alguien la ha reservado  y no se puede incluir en el examen
                            if (memo_viejo.IndexOf(";" + item.Oid.ToString() + ";") == -1
                                && memo_viejo.IndexOf(item.Oid.ToString() + ";") != 0)
                            {

                                MessageBox.Show(string.Format(Resources.Messages.PREGUNTA_INCLUIDA, item.Codigo),
                                                moleQule.Library.Application.AppController.APP_TITLE,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation);
                                //_preguntas_examen.CloseSession();
                                return false;
                            }
                        }

                        //si están en el examen
                        if (incluidas.Contains(item.Oid))
                        {
                            //y el examen ha sido emitido, se bloquean
                            if (_entity.FechaEmision.Date.Equals(DateTime.Today.Date))
                            {
                                item.Reservada = false;
                                item.Bloqueada = true;
                                item.FechaDisponibilidad = _entity.FechaExamen.AddMonths(6);
                            }
                            else //si no, se reservan
                                item.Reservada = true;
                        }
                        else //si se han quitado del examen, deja de estar reservada
                        {
                            if (!preguntas_mismo_dia.Contains(item.Oid))
                                item.Reservada = false;
                        }
                    }
                    _entity.Pregunta_Examens = Pregunta_Examens.NewChildList();

                    Examen temp = _entity.Clone();
                    temp.ApplyEdit();

                    _entity = temp.Save();
                    _entity.ApplyEdit();

                    //rutina para copiar las imágenes de las preguntas en la carpeta de fotos
                    //de preguntas de examen
                    if (_entity.FechaEmision.Date.Equals(DateTime.Today.Date))
                    {
                        PgMng.Grow("Guardando imágenes...");

                        _entity.MemoPreguntas = string.Empty;
                        int orden = 1;
                        foreach (Pregunta origen in _preguntas_examen)
                        {
                            if (origen.Bloqueada == false) continue;

                            foreach (PreguntaExamen destino in _entity.PreguntaExamens)
                            {
                                if (destino.OidPregunta == origen.Oid)
                                {
                                    if (origen.Imagen != string.Empty && File.Exists(origen.ImagenWithPath))
                                    {
                                        string ext = string.Empty;

                                        Bitmap imagen = new Bitmap(Library.Application.AppController.FOTOS_PREGUNTAS_PATH + origen.Imagen);

                                        if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Jpeg.Guid))
                                            ext = ".jpg";
                                        else
                                        {
                                            if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Bmp.Guid))
                                                ext = ".bmp";
                                            else
                                            {
                                                if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Png.Guid))
                                                    ext = ".png";
                                            }
                                        }

                                        destino.Imagen = destino.Oid.ToString("000000") + ext;

                                        int maxHeight = imagen.Height > imagen.Width ? imagen.Height : imagen.Width;

                                        Images.Save(origen.ImagenWithPath, destino.ImagenWithPath, maxHeight);

                                        imagen.Dispose();
                                    }
                                    else destino.Imagen = string.Empty;
                                    if (origen.ModeloRespuesta != string.Empty && File.Exists(origen.ModeloRespuestaPath))
                                    {
                                        string ext = origen.ModeloRespuesta.Substring(origen.ModeloRespuesta.LastIndexOf('.'));
                                        destino.ModeloRespuesta = destino.Oid.ToString("000000") + ext;

                                        string directorio = destino.ModeloRespuestaPath.Substring(0, destino.ModeloRespuestaPath.Length - destino.ModeloRespuesta.Length);
                                        if (!Directory.Exists(directorio))
                                            Directory.CreateDirectory(directorio);
                                        File.Copy(origen.ModeloRespuestaPath, destino.ModeloRespuestaPath);
                                    }
                                    else destino.Imagen = string.Empty;
                                    orden++;
                                    break;
                                }
                            }

                            PgMng.Grow();
                        }
                        temp = _entity.Clone();
                        _preguntas_examen.Save();
                        _entity = temp.Save();
                    }

                    PgMng.Grow("Guardando examen...");

                    //_preguntas_examen.Save();
                    //_preguntas_examen.CloseSession();

                    PgMng.FillUp();

                    return true;
                }
                catch (iQValidationException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex) +
                                    Environment.NewLine + ex.SysMessage,
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex),
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return true;
                }
                finally
                {
                    this.Datos.RaiseListChangedEvents = true;
                }
            }
        }


        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Preguntas_Grid":
                    {
                        if (_entity == null) return;
                        long orden = 1;

                        foreach (DataGridViewRow row in Preguntas_Grid.Rows)
                        {
                            row.Cells[N_Orden.Name].Value = orden.ToString();
                            orden++;

                            Datos.MoveNext();
                        }

                    } break;
            }
        }

        #endregion

        #region Style & Source


        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();            

            if (!Entity.FechaEmision.Date.Equals(DateTime.MaxValue.Date)
                   && !Entity.FechaEmision.Date.Equals(DateTime.MinValue.Date))
            {
                Desarrollo_CB.Enabled = false;
                FExamen_DTP.Enabled = false;
                Instructor_CB.Enabled = false;
                Promocion_CB.Enabled = false;
                Tipo_TB.Enabled = false;
            }
        }

        public override void RefreshSecondaryData()
        {
            Preguntas_TB.Text = _entity.PreguntaExamens.Count.ToString();
            PgMng.Grow(string.Empty, "Preguntas_TB");

            Desarrollo_CB.Checked = _entity.Desarrollo;
            PgMng.Grow(string.Empty, "Desarrollo_CB");

            if (Entity != null && Entity.OidModulo != 0)
            {
                _modulo = ModuloInfo.Get(Entity.OidModulo, false);
                PgMng.Grow(string.Empty, "_modulo");
                _submodulos = SubmoduloList.GetModuloList(_modulo.Oid, false);
                PgMng.Grow(string.Empty, "_submodulos");
                _temas = TemaList.GetModuloList(_modulo.Oid, false);
                PgMng.Grow(string.Empty, "_temas");
            }
            PgMng.Grow();

            base.RefreshSecondaryData();
            PgMng.Grow();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            _preguntas_modulo = PreguntaList.GetPreguntasModulo(_modulo.Oid, _entity.MemoPreguntas);
            //_modulo.Preguntas = _preguntas_modulo;
            PgMng.Grow(string.Empty, "_preguntas");

            _respuestas_modulo = RespuestaList.GetModuloList(_modulo.Oid);
            PgMng.Grow(string.Empty, "_respuestas");

            RellenaPreguntas(); 
            
            promociones = PromocionList.GetList(false);
            foreach (PromocionInfo info in promociones)
                _promociones_todas.Add(info.Numero + " - " + info.Nombre, info);

            RellenaPromociones();
            PgMng.Grow(string.Empty, "RellenaPreguntas");

            Datos.DataSource = _entity;
            Duracion_MTB.Text = _entity.Duracion.TimeOfDay.ToString();
            PgMng.FillUp(string.Empty, "RefreshMain de ExamenEditForm");
            //PgMng.ShowCronos();
        }

        protected override void RellenaPreguntas()
        {
            //Preguntas lista_aux = Preguntas.NewList();
            PreguntaList _preguntas_examen = null;

            //if (EntityInfo.MemoPreguntas.Length > 0)
            //{
            //    string lista = EntityInfo.MemoPreguntas.Replace(';', ',').Substring(0, EntityInfo.MemoPreguntas.Length - 1);
            //    lista_aux = Preguntas.GetPreguntasByList(lista);
            //}

            //string[] oid_preguntas = EntityInfo.MemoPreguntas.Split(';');

            //foreach (string item in oid_preguntas)
            //{
            //    try
            //    {
            //        long oid = Convert.ToInt32(item);
            //        //en _preguntas_examen se guardan las preguntas ordenadas según el campo MemoPreguntas
            //        _preguntas_examen.AddItem(lista_aux.GetItem(oid));
            //    }
            //    catch 
            //    {
            //        continue;
            //    }
            //}

            string memo = string.Empty;

            foreach (Pregunta_Examen item in _entity.Pregunta_Examens)
            {
                if (memo != string.Empty) memo += ",";
                memo += item.OidPregunta.ToString();
            }

            if (memo != string.Empty)
            {
                _preguntas_examen = PreguntaList.GetPreguntasByList(memo);

                string inactivas = string.Empty;

                foreach (PreguntaInfo item in _preguntas_examen)
                {
                    if (!item.Activa)
                        inactivas += item.Serial.ToString() + ", ";
                }

                if (inactivas != string.Empty)
                {
                    inactivas = inactivas.Substring(0, inactivas.Length - 2);
                    MessageBox.Show(string.Format(Resources.Messages.PREGUNTAS_INACTIVAS, inactivas),
                                                moleQule.Library.Application.AppController.APP_TITLE,
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Exclamation);
                }
            }

            Datos_Preguntas.DataSource = _preguntas_examen;

            Preguntas_TB.Text = Datos_Preguntas.Count.ToString();
        }

        #endregion

        #region Validation & Format

        /// <summary>
        /// Valida datos de entrada
        /// </summary>
        protected override void ValidateInput()
        {
            try
            {
                _entity.Duracion = DateTime.Parse(Duracion_MTB.Text);
            }
            catch
            {
                throw new iQValidationException("Duración", string.Empty);
            }
        }

        #endregion

        #region Actions

        protected override void SaveAction()
        {
            try
            {
                ValidateInput();
            }
            catch (iQValidationException ex)
            {
                MessageBox.Show(ex.Message,
                                moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                _action_result = DialogResult.Ignore;
                return;
            }

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        protected override void QuitarAction()
        {
            if (!Entity.FechaEmision.Date.Equals(DateTime.MaxValue.Date)
                && !Entity.FechaEmision.Date.Equals(DateTime.MinValue.Date))
            {
                MessageBox.Show("No se puede modificar un examen que ha sido emitido");
                return;
            }

            //string[] lista = Entity.MemoPreguntas.Split(';');

            //foreach (string oid in lista)
            //{
            //    try 
            //    {
            //        long oid_pregunta = Convert.ToInt32(oid);
            //        Pregunta item = _preguntas.GetItem(oid_pregunta);
            //        item.Reservada = false;
            //    }
            //    catch 
            //    {
            //        continue;
            //    }
            //}

            //Entity.MemoPreguntas = string.Empty;

            Entity.Pregunta_Examens = Pregunta_Examens.NewChildList();

            //while (Entity.MemoPreguntas != string.Empty)
            //{
            //    long pregunta;
            //    int index = Entity.MemoPreguntas.IndexOf(";");
            //    pregunta = Convert.ToInt64(Entity.MemoPreguntas.Substring(0, index));
            //    Entity.MemoPreguntas = Entity.MemoPreguntas.Substring(index + 1);
            //    Pregunta p = _modulo.Preguntas.GetItem(pregunta);
            //    p.Reservada = false;
            //}

            RellenaPreguntas();
        }

        protected override void SetPreguntasAction()
        {
            if (!Entity.FechaEmision.Date.Equals(DateTime.MaxValue.Date)
                && !Entity.FechaEmision.Date.Equals(DateTime.MinValue.Date))
            {
                MessageBox.Show("No se puede modificar un examen que ha sido emitido");
                return;
            }

            if (Entity.FechaExamen.Date.Equals(DateTime.MaxValue.Date))
            {
                MessageBox.Show("Debe especificar una fecha para el examen antes de añadir preguntas");
                return;
            }

            if (Entity != null && Entity.OidModulo != 0)
            {
                if (_modulo == null) _modulo = ModuloInfo.Get(Entity.OidModulo);
                if (_submodulos == null) _submodulos = SubmoduloList.GetModuloList(Entity.OidModulo, false);
                if (_temas == null) _temas = TemaList.GetModuloList(_modulo.Oid, false);
                if (preguntas_mismo_dia == null) GetPreguntasReservadas();

                PreguntasSelectForm form = new PreguntasSelectForm(true);
                form.SetSourceData(Entity, _modulo, _submodulos, _temas, _preguntas_modulo, preguntas_mismo_dia, false);
                form.ShowDialog();

                RellenaPreguntas();
            }

        }

        protected override void AlumnosAction()
        {
            AlumnosSelectForm form = new AlumnosSelectForm(true);
            form.SetSourceData(_entity);
            form.ShowDialog();
        }

        protected override void ResumenPreguntasAction()
        {
            if (_entity.MemoPreguntas == string.Empty) return;

            ExamenReportMng reportMng = new ExamenReportMng(AppContext.ActiveSchema);

            string lista = _entity.MemoPreguntas.Replace(';', ',');
            lista = lista.Substring(0, lista.Length - 1);
            bool defecto = moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultBoolSetting();
            CompanyInfo empresa = null;

            if (defecto)
                empresa = CompanyInfo.Get(moleQule.Library.Instruction.ModulePrincipal.GetImpresionEmpresaDefaultOidSetting(), false);
            while (empresa == null)
            {
                moleQule.Face.Common.CompanySelectForm form = new Common.CompanySelectForm(this);
                DialogResult result = form.ShowDialog();

                try
                {
                    if (result == DialogResult.OK)
                        empresa = form.Selected as CompanyInfo;
                }
                catch
                { empresa = null; }
            }

            ISchemaInfo schema = AppContext.ActiveSchema;
            try
            {
                schema = empresa as ISchemaInfo;
                if (schema == null) schema = AppContext.ActiveSchema;
            }
            catch
            {
            }

            ReportViewer.SetReport(reportMng.GetDetailResumenExamenReport(EntityInfo, 
                PreguntaList.GetListaExamen(lista), null, empresa));
            ReportViewer.ShowDialog();
        }

        protected override void EmitirAction()
        {
            _entity.PreguntaExamens = PreguntaExamens.NewChildList();

            if (Entity.FechaExamen.Date.Equals(DateTime.MaxValue.Date))
            {
                MessageBox.Show("No se puede emitir un examen que no tiene fecha de examen.");
                return;
            }

            if (Entity.Pregunta_Examens.Count == 0)
            {
                MessageBox.Show("No se puede emitir un examen que no tiene preguntas.");
                return;
            }

            PgMng.Reset((Preguntas_Grid.Rows.Count * 2) + 2, 1, "Guardando estado actual de las preguntas...", this);

            foreach (DataGridViewRow row in Preguntas_Grid.Rows)
            {
                PreguntaInfo p = _preguntas_modulo.GetItem(((PreguntaInfo)row.DataBoundItem).Oid);
                if (!p.Activa) continue;

                //se añade la nueva PreguntaExamen al examen a partir de la Pregunta
                PreguntaExamen pexamen = _entity.PreguntaExamens.NewItem(_entity);
                FCriteria<long> criteria = new FCriteria<long>("OidPregunta", p.Oid);
                pexamen.CopyValues(p);
                pexamen.FechaPublicacion = _entity.FechaExamen;
                pexamen.Orden = Convert.ToInt64(row.Cells[N_Orden.Name].Value);

                List<RespuestaInfo> respuestas = _respuestas_modulo.GetSubList(criteria);
                foreach (RespuestaInfo item in respuestas)
                {
                    if (item.OidPregunta == p.Oid)
                    {
                        RespuestaExamen rexamen = RespuestaExamen.NewChild(pexamen);
                        rexamen.CopyValues(item);
                        rexamen.OidExamen = _entity.Oid;
                        rexamen.MarkItemChild();
                        pexamen.RespuestaExamens.AddItem(rexamen);
                    }
                }
                PgMng.Grow();
            }

            Entity.FechaEmision = DateTime.Now;

            SaveAction();
        }

        protected override void ResumenAction()
        {
            ResumenActionForm form = new ResumenActionForm();
            form.SetSourceData(Entity, _modulo, _preguntas_modulo);
            form.ShowDialog();
        }

        protected override void ProponerAction()
        {
            if (_entity.Pregunta_Examens.Count != 0)
            {
                MessageBox.Show("El examen que desea proponer contiene preguntas, bórrelas antes de continuar",
                                        "Aviso");
            }
            else
            {
                PlantillaSelectForm form = new PlantillaSelectForm(true);
                form.SetSourceData(_entity, _modulo, _preguntas_modulo);
                form.ShowDialog(this);

                if (Entity != null && Entity.OidModulo != 0 && form.Guardado)
                {
                    if (_modulo == null) _modulo = ModuloInfo.Get(Entity.OidModulo);
                    if (_submodulos == null) _submodulos = SubmoduloList.GetModuloList(_modulo.Oid, false);
                    if (_temas == null) _temas = TemaList.GetModuloList(_modulo.Oid, false);
                    if (preguntas_mismo_dia == null) GetPreguntasReservadas();

                    PreguntasSelectForm select = new PreguntasSelectForm(true);
                    select.SetSourceData(Entity, _modulo, _submodulos, _temas, _preguntas_modulo, preguntas_mismo_dia, true);
                    select.ShowDialog(this);

                    RellenaPreguntas();
                }
            }
        }

        protected override void PrintAction()
        {
            if (Entity.Pregunta_Examens.Count == 0) return;

            moleQule.Library.Timer t = new moleQule.Library.Timer();
            t.Start();

            //se obliga a guardar el examen antes de imprimir por si durante la impresión hubiera algún problema
            //quedan guardadas las modificaciones que pudieran no haberse guardado
            if (Entity.IsDirty)
            {
                DialogResult result = MessageBox.Show(Resources.Messages.GUARDADO_EXAMEN,
                    moleQule.Face.Resources.Labels.ADVISE_TITLE, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    try
                    {
                        ValidateInput();
                    }
                    catch (iQValidationException ex)
                    {
                        MessageBox.Show(ex.Message,
                                        moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                    return;
            }

            Entity.PreguntaExamens = PreguntaExamens.NewChildList();

            string memo = string.Empty;

            foreach (Pregunta_Examen item in Entity.Pregunta_Examens)
                memo += item.OidPregunta.ToString() + ",";

            if (memo != string.Empty) memo = memo.Substring(0, memo.Length - 1);
            RespuestaList respuestas = RespuestaList.GetRespuestasExamenList(memo);

            foreach (DataGridViewRow row in Preguntas_Grid.Rows)
            {
                PreguntaInfo p = _preguntas_modulo.GetItem(((PreguntaInfo)row.DataBoundItem).Oid);
                t.Record("Obtener pregunta de la lista de preguntas del examen");

                PreguntaExamen pexamen = PreguntaExamen.NewChild(_entity);
                pexamen.CopyValues(p);
                pexamen.Orden = Convert.ToInt64(row.Cells[N_Orden.Name].Value);
                pexamen.MarkItemChild();
                t.Record("Crear PreguntaExamen");

                Entity.PreguntaExamens.AddItem(pexamen);
                FCriteria<long> criteria = new FCriteria<long>("OidPregunta", p.Oid);

                foreach (RespuestaInfo item in respuestas)
                {
                    if (p.Oid == item.OidPregunta)
                    {
                        RespuestaExamen rexamen = RespuestaExamen.NewChild(pexamen);
                        rexamen.CopyValues(item);
                        rexamen.MarkItemChild();
                        pexamen.RespuestaExamens.AddItem(rexamen);
                    }
                }
            }

            //Preguntas preguntas_examen = null;/* Pregunta.GetPreguntasByList(memo);*/
            PreguntaList preguntas_examen_list = PreguntaList.GetPreguntasByList(memo);

            if (EntityInfo.Desarrollo)
            {
                //tiene que llamar a ExamenDesarrolloReportForm
                ExamenDesarrolloReportForm form = new ExamenDesarrolloReportForm(true, EntityInfo, preguntas_examen_list, _entity.Pregunta_Examens);
                form.ShowDialog();
            }
            else
            {
                //tiene que llamar a ExamenTestReportForm
                ExamenTestReportForm form = new ExamenTestReportForm(true, EntityInfo, preguntas_examen_list, _entity.Pregunta_Examens);
                form.ShowDialog();
            }

            Entity.PreguntaExamens = PreguntaExamens.NewChildList();
        }

        protected override void RellenaPromociones()
        {
            if (_entity.Promociones == null) return;
            try
            {
                _promociones_select = new Dictionary<string, PromocionInfo>();

                foreach (ExamenPromocion item in _entity.Promociones)
                {
                    PromocionInfo info = promociones.GetItem(item.OidPromocion);
                    if (info != null)
                        _promociones_select.Add(info.Numero + " - " + info.Nombre, info);
                } 
            
                //Promociones_CLB.Items.Clear();

                foreach (KeyValuePair<string, PromocionInfo> item in _promociones_todas)
                {
                    if (_promociones_select.ContainsKey(item.Key))
                    {
                        int index = Promociones_CLB.Items.IndexOf(item.Key);

                        if (index >= 0)
                        {
                            if (Promociones_CLB.GetItemCheckState(index) == CheckState.Unchecked)
                                Promociones_CLB.SetItemChecked(index, true);
                        }
                        else
                            Promociones_CLB.Items.Add(item.Key, true);
                    }
                    else
                    {
                        int index = Promociones_CLB.Items.IndexOf(item.Key);

                        if (index >= 0)
                        {
                            if (Promociones_CLB.GetItemCheckState(index) == CheckState.Checked)
                                Promociones_CLB.SetItemChecked(index, false);
                        }
                    }
                }
            }
            catch { throw new iQException("RellenaPromociones"); }
        }
        
        #endregion

        #region Events

        private void ExamenEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_entity != null && !_entity.SharedTransaction)
            {
                if (_entity.CloseSessions) Entity.CloseSession();
                //_entity = null;
            }
            Cerrar();
        }

        protected override void CellContentClick(int column, int row)
        {
            switch (Preguntas_Grid.Columns[column].Name)
            {
                case "Ordenar_BT":
                    {

                        OrdenarPreguntasInputForm form = new OrdenarPreguntasInputForm(true, row + 1);
                        form.SetSourceData(Entity, Preguntas_Grid.Rows.Count);
                        form.ShowDialog();

                        RellenaPreguntas();
                    }
                    break;
                case "Ver_BT":
                    {
                        //Pregunta.OpenSession();
                        string memo = string.Empty;

                        foreach (Pregunta_Examen item in Entity.Pregunta_Examens)
                            memo += item.OidPregunta.ToString() + ",";

                        if (memo != string.Empty) memo = memo.Substring(0, memo.Length - 1);

                        PreguntaList preguntas = PreguntaList.GetPreguntasByList(memo);

                        PreguntaInfo info = (PreguntaInfo)Preguntas_Grid.Rows[row].DataBoundItem;
                        PreguntasViewForm form = new PreguntasViewForm(info.Oid, preguntas, true);
                        form.ShowDialog();
                    }
                    break;
                case "Editar_BT":
                    {
                        string memo = string.Empty;

                        foreach (Pregunta_Examen item in Entity.Pregunta_Examens)
                            memo += item.OidPregunta.ToString() + ",";

                        if (memo != string.Empty) memo = memo.Substring(0, memo.Length - 1);

                        Preguntas preguntas = Preguntas.GetPreguntasByList(memo, _entity.SessionCode);
                        Preguntas ordenadas = Preguntas.NewList();
                        PreguntaInfo info = (PreguntaInfo)Preguntas_Grid.Rows[row].DataBoundItem;

                        //se ordenan las preguntas para que se vayan mostrando en el mismo orden que en el examen
                        foreach (Pregunta_Examen item in _entity.Pregunta_Examens)
                            ordenadas.AddItem(preguntas.GetItem(item.OidPregunta));

                        Pregunta activa = ordenadas.GetItem(info.Oid);
                        SortedBindingList<Pregunta> sorted = Preguntas.SortList(ordenadas, "Codigo", ListSortDirection.Ascending);

                        PreguntasEditForm form = new PreguntasEditForm(activa, sorted, true);
                        form.ShowDialog();

                        //se recarga la lista de preguntas a seleccionar para que estén actualizadas
                        PreguntasModulo = PreguntaList.GetPreguntasModulo(_entity.OidModulo, _entity.MemoPreguntas);

                        RellenaPreguntas();
                        preguntas.CloseSession();
                        ordenadas.CloseSession();
                    }
                    break;
                case "Eliminar_BT":
                    {
                        DialogResult result;

                        result = MessageBox.Show("¿Está seguro que desea eliminar la pregunta seleccionada?", "Aviso", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            //string memo_preguntas = Entity.MemoPreguntas;
                            //int pos = 0;

                            //long oid_eliminada = ((PreguntaInfo)Preguntas_Grid.Rows[row].DataBoundItem).Oid;

                            //string[] lista = Entity.MemoPreguntas.Split(';');
                            //Entity.MemoPreguntas = string.Empty;

                            //foreach (string oid in lista)
                            //{
                            //    try
                            //    {
                            //        long oid_pregunta = Convert.ToInt32(oid);
                            //        if (oid_pregunta != oid_eliminada)
                            //            Entity.MemoPreguntas += oid_pregunta + ";";
                            //        else
                            //        {
                            //            Pregunta item = _preguntas.GetItem(oid_pregunta);
                            //            item.Reservada = false;
                            //        }
                            //    }
                            //    catch
                            //    {
                            //        continue;
                            //    }
                            //}

                            foreach (Pregunta_Examen item in Entity.Pregunta_Examens)
                            {
                                if (item.OidPregunta == ((PreguntaInfo)Preguntas_Grid.Rows[row].DataBoundItem).Oid)
                                {
                                    Entity.Pregunta_Examens.Remove(item);
                                    break;
                                }
                            }

                            //while (memo_preguntas != string.Empty)
                            //{
                            //    string pregunta;
                            //    int index = memo_preguntas.IndexOf(";");
                            //    pregunta = memo_preguntas.Substring(0, index + 1);
                            //    memo_preguntas = memo_preguntas.Substring(index + 1);
                            //    if (pos != row)
                            //        Entity.MemoPreguntas += pregunta;
                            //    else
                            //    {
                            //        int l = pregunta.Length;
                            //        Pregunta p = _modulo.Preguntas.GetItem(Convert.ToInt64(pregunta.Substring(0, l - 1)));
                            //        p.Reservada = false;

                            //    }
                            //    pos++;
                            //}

                            RellenaPreguntas();
                        }

                    }
                    break;
            }
        }

        protected override void Desarrollo_Check()
        {
            if (_modulo == null) return;

            //string memo_preguntas = string.Empty;
            string tipo = string.Empty;

            if (Desarrollo_CB.Checked)
                tipo = "Desarrollo";
            else
                tipo = "Test";

            //string[] lista = Entity.MemoPreguntas.Split(';');

            //foreach (string oid in lista)
            //{
            //    try
            //    {
            //        long oid_pregunta = Convert.ToInt32(oid);
            //        Pregunta item = _preguntas.GetItem(oid_pregunta);
            //        item.Reservada = false;
            //    }
            //    catch
            //    {
            //        continue;
            //    }
            //}

            //Entity.MemoPreguntas = string.Empty;

            Entity.Pregunta_Examens = Pregunta_Examens.NewChildList();

            //while (Entity.MemoPreguntas != string.Empty)
            //{
            //    long pregunta;
            //    int index = Entity.MemoPreguntas.IndexOf(";");
            //    pregunta = Convert.ToInt64(Entity.MemoPreguntas.Substring(0, index));
            //    Entity.MemoPreguntas = Entity.MemoPreguntas.Substring(index + 1);
            //    _modulo.Preguntas.GetItem(pregunta).Reservada = false;
            //}

            Entity.Desarrollo = Desarrollo_CB.Checked;
            RellenaPreguntas();
        }

        #endregion

    }
}

