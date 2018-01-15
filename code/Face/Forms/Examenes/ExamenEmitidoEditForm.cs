using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Face;
using moleQule.Library.Application;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class ExamenEmitidoEditForm : ExamenEmitidoForm
    {
        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 7; } }

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Examen _entity;

        public override Examen Entity { get { return _entity; } set { _entity = value; } }
        public override ExamenInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(true) : null; } }

        #endregion

        #region Factory Methods

        public ExamenEmitidoEditForm() : this(-1, true) { }

        public ExamenEmitidoEditForm(long oid)
            : this(oid, true) { }

        public ExamenEmitidoEditForm(long oid, bool ismodal)
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
            _entity = Examen.Get(oid,true);
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

                Examen temp = _entity.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    _entity = temp.Save();
                    _entity.ApplyEdit();
                    
                    //Decomentar si se va a mantener en memoria
                    //_entity.BeginEdit();
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
                    return false;
                }
                finally
                {
                    this.Datos.RaiseListChangedEvents = true;
                }
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
            int validas = 0;

            foreach (PreguntaExamen item in _entity.PreguntaExamens)
            {
                if (!item.Anulada)
                    validas++;
            }

            Preguntas_TB.Text = validas.ToString();
            PgMng.Grow(string.Empty, "Preguntas_TB");

            Desarrollo_CB.Checked = _entity.Desarrollo;
            PgMng.Grow(string.Empty, "Desarrollo_CB");

            if (Entity != null && Entity.OidModulo != 0)
            {
                _modulo = ModuloInfo.Get(Entity.OidModulo, false);
                PgMng.Grow(string.Empty, "_modulo");
                _preguntas = _entity.PreguntaExamens;
                Datos_Preguntas.DataSource = PreguntaExamens.SortList(_entity.PreguntaExamens, "Orden", ListSortDirection.Ascending);
                PgMng.Grow(string.Empty, "_preguntas");
                _submodulos = SubmoduloList.GetModuloList(_modulo.Oid, false);
                PgMng.Grow(string.Empty, "_submodulos");
                _temas = TemaList.GetModuloList(_modulo.Oid, false);
                PgMng.Grow(string.Empty, "_temas");
            }
            PgMng.Grow();

            base.RefreshSecondaryData();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            Duracion_MTB.Text = _entity.Duracion.TimeOfDay.ToString();

            promociones = PromocionList.GetList(false);
            foreach (PromocionInfo info in promociones)
                _promociones_todas.Add(info.Numero + " - " + info.Nombre, info);

            RellenaPromociones();

            TimeSpan duracion = TimeSpan.Zero;
            TimeSpan tiempo_pregunta;

            if (_entity.Desarrollo)
                tiempo_pregunta = moleQule.Library.Instruction.ModulePrincipal.GetTiempoPreguntasTipoDesarrolloSetting().TimeOfDay;
            else
                tiempo_pregunta = moleQule.Library.Instruction.ModulePrincipal.GetTiempoPreguntasTipoTestSetting().TimeOfDay;

            duracion = TimeSpan.FromSeconds(tiempo_pregunta.TotalSeconds * Datos_Preguntas.Count);
            _entity.Duracion = Convert.ToDateTime(duracion.ToString());
            Duracion_MTB.Text = _entity.Duracion.Hour.ToString("00") + ":" + _entity.Duracion.Minute.ToString("00");

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
                throw new iQValidationException(Duracion_LB.Text, string.Empty);
            }
        }

        #endregion

        #region Actions

        protected override void AlumnosButton()
        {
            AlumnosSelectForm form = new AlumnosSelectForm(true);
            form.SetSourceData(Entity);
            form.ShowDialog();
        }

        protected override void ResumenPreguntasButton()
        {
            ExamenReportMng reportMng = new ExamenReportMng(AppContext.ActiveSchema);

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
                                                    PreguntaList.GetListaExamen(_entity.Oid), 
                                                    null, 
                                                    empresa));
            ReportViewer.ShowDialog();
        }

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

        protected override void LiberarAction()
        {
            if (!AppContext.User.IsAdmin /*|| !(AppContext.User.Name == "Admin")*/)
            {
                MessageBox.Show("Esta acción solo está permitida al administrador del sistema");
                return;
            }

            _liberar = true;

            if (Entity.FechaExamen.Date > DateTime.Today.Date)
            {
                if (Entity.Alumnos != null && Entity.Alumnos.Count > 0)
                    MessageBox.Show("No se puede liberar un examen que tiene alumnos asociados.");
                else
                {
                    PgMng.Reset(Entity.PreguntaExamens.Count * 2 + 2, 1, "Eliminando copias de preguntas y respuestas...", this);

                    PreguntaExamens preguntas = Entity.PreguntaExamens.Clone();
                    Entity.MemoPreguntas = string.Empty;
                    foreach (PreguntaExamen p in preguntas)
                    {
                        Entity.PreguntaExamens.Remove(p.Oid);
                        Entity.MemoPreguntas += p.OidPregunta.ToString() + ";";

                        PgMng.Grow();
                    }

                    string directorio = Library.Application.AppController.FOTOS_PREGUNTAS_EXAMEN_PATH + Entity.Oid.ToString("00000");

                    if (Directory.Exists(directorio))
                        Directory.Delete(directorio, true);

                    PgMng.Grow("Liberando preguntas...");

                    if (Entity.MemoPreguntas != string.Empty)
                    {
                        PgMng.Grow("Liberando preguntas...");

                        string lista_preguntas = Entity.MemoPreguntas.Replace(';', ',').Substring(0, Entity.MemoPreguntas.Length - 1);

                        _preguntas_examen = Preguntas.GetPreguntasByList(lista_preguntas, _entity.SessionCode);
                        foreach (Pregunta item in _preguntas_examen)
                        {
                            DateTime fecha = ExamenInfo.GetUltimoByPreguntaIncluida(item.Oid, Entity.FechaExamen);
                            if (fecha != DateTime.MinValue)
                            {
                                item.FechaDisponibilidad = fecha.AddMonths(6);
                                item.FechaUltimoExamen = fecha;
                            }
                            else
                            {
                                item.FechaDisponibilidad = item.FechaAlta;
                                item.FechaUltimoExamen = item.FechaAlta.AddMonths(-6);
                            }
                            item.Bloqueada = false;
                            item.Reservada = true;

                            PgMng.Grow();
                        }
                        _preguntas_examen.Save();
                    }

                    Entity.FechaEmision = DateTime.MaxValue;
                    FExamen_DTP.Enabled = true;
                    Desarrollo_CB.Enabled = true;
                    Instructor_CB.Enabled = true;
                    Promocion_CB.Enabled = true;
                    Tipo_TB.Enabled = true;

                    PgMng.FillUp();
                    MessageBox.Show("El examen ha sido liberado correctamente.");

                    SaveAction();
                    //Scripts.FormatFechaDisponibilidad();
                }
            }
            else
                MessageBox.Show("No se puede liberar un examen que ya se ha celebrado.");

            _liberar = false;
        }

        protected override void Resumen_Button()
        {
            ResumenEmitidoActionForm form = new ResumenEmitidoActionForm();
            form.SetSourceData(Entity.MemoPreguntas, _modulo, Entity);
            form.ShowDialog();
        }

        protected override void RellenaPromociones()
        {
            if (_entity.Promociones == null) return;
            try
            {
                _promociones_select = new Dictionary<string, PromocionInfo>();

                if (_entity.Promociones.Count > 0)
                {
                    foreach (ExamenPromocion item in _entity.Promociones)
                    {
                        PromocionInfo info = promociones.GetItem(item.OidPromocion);
                        if (info != null)
                            _promociones_select.Add(info.Numero + " - " + info.Nombre, info);
                    }
                }
                else
                {
                    foreach (PromocionInfo info in promociones)
                    {
                        if (info != null)
                            _promociones_select.Add(info.Numero + " - " + info.Nombre, info);
                    }
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

        private void ExamenEmitidoEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_entity != null && !_entity.SharedTransaction)
            {
                if (_entity.CloseSessions) Entity.CloseSession();
                //_entity = null;
            }
        }

        protected override void CellContentClick(int column, int row)
        {
            switch (Preguntas_Grid.Columns[column].Name)
            {
                case "Ver_BT":
                    {
                        long oid = ((PreguntaExamen)Preguntas_Grid.Rows[row].DataBoundItem).Oid;
                        PreguntasEmitidasViewForm form = new PreguntasEmitidasViewForm(oid, Entity.PreguntaExamens, _lista_preguntas, true);
                        form.ShowDialog();
                    }
                    break;
            }
        }

        protected override void CellEndEdit(int column, int row)
        {
            switch (Preguntas_Grid.Columns[column].Name)
            {
                case "Anulada":
                    {
                        int validas = 0;

                        foreach (PreguntaExamen item in _entity.PreguntaExamens)
                        {
                            if (!item.Anulada)
                                validas++;
                        }

                        Preguntas_TB.Text = validas.ToString();
                    }
                    break;
            }
        }

        #endregion
    }
}

