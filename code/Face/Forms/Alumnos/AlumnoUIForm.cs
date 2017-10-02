using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;

using moleQule.Library.Common;
using moleQule.Face.Common;

using moleQule.Library.Application;
using moleQule.Library.Instruction;
using moleQule.Library.Instruction.Reports.Alumno;

namespace moleQule.Face.Instruction
{
    public partial class AlumnoUIForm : AlumnoForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Alumno _entity;

        public override Alumno Entity { get { return _entity; } set { _entity = value; } }
        public override AlumnoInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }


        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected AlumnoUIForm() : this(-1, true) { }

        public AlumnoUIForm(bool isModal) : this(-1, isModal) { }

        public AlumnoUIForm(long oid) : this(oid, true) { }

        public AlumnoUIForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        public AlumnoUIForm(Alumno item, bool ismodal, Form parent)
            : base(item, ismodal, parent)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {
                this.Datos.RaiseListChangedEvents = false;

                if (PracticaRepetida())
                    return false;

                Alumno temp = _entity.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    _entity = temp.Save();
                    _entity.ApplyEdit();

                    // Se modifica el nombre de la foto
                    if (_entity.Foto != string.Empty)
                    {
                        if (File.Exists(AppController.FOTOS_ALUMNOS_PATH + _entity.Foto))
                        {
                            Bitmap imagen = new Bitmap(AppController.FOTOS_ALUMNOS_PATH + _entity.Foto);

                            string ext = string.Empty;

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

                            imagen.Dispose();

                            if (_entity.Foto != _entity.Oid.ToString("000") + ext)
                            {
                                File.Copy(AppController.FOTOS_ALUMNOS_PATH + _entity.Foto,
                                            AppController.FOTOS_ALUMNOS_PATH + _entity.Oid.ToString("000") + ext,
                                    true);
                                File.Delete(AppController.FOTOS_ALUMNOS_PATH + _entity.Foto);

                                _entity.Foto = _entity.Oid.ToString("000") + ext;
                                _entity.Save();
                            }
                        }
                    }

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
           
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow();

            Datos_Alumnos_Promociones.DataSource = _entity.Promociones;
            PgMng.Grow();

            Datos_Alumno_Examen.DataSource = _entity.AlumnoExamens;
            PgMng.Grow();

            Datos_Alumno_Practica.DataSource = _entity.AlumnosPracticas;
            PgMng.Grow();

            FCriteria<bool> criteria = new FCriteria<bool>("Falta", true);
            Datos_Alumno_Parte.DataSource = _entity.AlumnoPartes.GetSubList(criteria);
            PgMng.Grow();


            base.RefreshMainData();
            PgMng.FillUp();
        }

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            switch (controlName)
            {
                case "ID_GB":
                    {
                        NIF_RB.Checked = (EntityInfo.TipoId == (long)TipoId.NIF);
                        NIE_RB.Checked = (EntityInfo.TipoId == (long)TipoId.NIE);
                        DNI_RB.Checked = (EntityInfo.TipoId == (long)TipoId.DNI);

                    } break;
                case "Grupo_GB":
                    {
                        G0_RB.Checked = (EntityInfo.Grupo == (long)moleQule.Library.Instruction.Grupo.SinGrupo);
                        GA_RB.Checked = (EntityInfo.Grupo == (long)moleQule.Library.Instruction.Grupo.A);
                        GB_RB.Checked = (EntityInfo.Grupo == (long)moleQule.Library.Instruction.Grupo.B);

                    } break;
            }
        }

        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Examenes_Grid":
                    {
                        ExamenList examenes = ExamenList.GetList(false);
                        foreach (DataGridViewRow row in Examenes_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            Alumno_Examen info = (Alumno_Examen)row.DataBoundItem;
                            if (info != null)
                            {
                                ExamenInfo examen = examenes.GetItem(info.OidExamen);
                                if (examen != null)
                                {
                                    row.Cells["Examen"].Value = examen.Titulo;
                                    if (info.Presentado)
                                    {
                                        if (examen.Desarrollo)
                                        {
                                            string calif = string.Empty;
                                            foreach (Respuesta_Alumno_Examen item in info.Respuestas)
                                            {
                                                if (calif != string.Empty)
                                                    calif += " - ";
                                                calif += item.Calificacion.ToString() + "%";
                                            }
                                            row.Cells["Calificacion"].Value = calif;
                                        }
                                        else
                                            row.Cells["Calificacion"].Value = info.Calificacion.ToString();
                                    }
                                    else
                                        row.Cells["Calificacion"].Value = "NP";
                                }
                            }
                        }

                    } break;
                case "Practicas_Grid":
                    {
                        //ClasePracticaList practicas = ClasePracticaList.GetList();
                        foreach (DataGridViewRow row in Practicas_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            Alumno_Practica info = (Alumno_Practica)row.DataBoundItem;
                            if (info != null)
                            {
                                if (info.Calificacion == Resources.Labels.NO_APTO_LABEL)
                                {
                                    if (info.Falta)
                                    {
                                        info.Calificacion = Resources.Labels.FALTA_ASISTENCIA_LABEL;
                                        row.DefaultCellStyle = FaltaStyle;
                                    }
                                    else
                                        row.DefaultCellStyle = NoAptaStyle;
                                }
                                else
                                {
                                    if (info.Calificacion == Resources.Labels.FALTA_ASISTENCIA_LABEL)
                                        row.DefaultCellStyle = FaltaStyle;
                                    else
                                    {
                                        if (info.Calificacion == Resources.Labels.APTO_LABEL)
                                            row.DefaultCellStyle = AptaStyle;
                                    }
                                }
                            }
                            if (info.Recuperada)
                                row.DefaultCellStyle = AptaStyle;
                        }

                    } break;
                case "Faltas_Grid":
                    {
                        ParteAsistenciaList partes = ParteAsistenciaList.GetList(false);
                        foreach (DataGridViewRow row in Faltas_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            Alumno_Parte info = (Alumno_Parte)row.DataBoundItem;
                            if (info != null)
                            {
                                ParteAsistenciaInfo item = partes.GetItem(info.OidParte);
                                if (item != null)
                                {
                                    row.Cells["Clase"].Value = item.Texto;
                                    row.Cells["Fecha"].Value = item.Fecha;
                                    row.Cells["Hora"].Value = item.HoraInicio;
                                }
                                
                            }
                        }
                    }
                    break;
            }
        }

        private bool ExamenRepetido()
        {
            for (int i = 0; i < Entity.AlumnoExamens.Count-1; i++)
            {
                for (int j = i + 1; j < Entity.AlumnoExamens.Count; j++)
                {
                    if (Entity.AlumnoExamens[i].OidExamen == Entity.AlumnoExamens[j].OidExamen)
                    {
                        MessageBox.Show("No se puede incluir dos veces un mismo examen");
                        return true;
                    }
                }
            }

            return false;
        }

        private bool PracticaRepetida()
        {
            for (int i = 0; i < Entity.AlumnosPracticas.Count - 1; i++)
            {
                for (int j = i + 1; j < Entity.AlumnosPracticas.Count; j++)
                {
                    if (Entity.AlumnosPracticas[i].OidClasePractica == Entity.AlumnosPracticas[j].OidClasePractica)
                    {
                        MessageBox.Show("No se puede incluir dos veces una misma práctica");
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            /*if (_entity.Promocion == string.Empty)
            {
                PromocionInfo promocion = PromocionInfo.Get(_entity.OidPromocion, false);
                if (promocion != null)
                    _entity.Promocion = promocion.Nombre;
            }
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
            }*/

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        protected override void AddExamenAction()
        {
            Alumno_ExamenAddForm form = new Alumno_ExamenAddForm();
            form.SetSourceData(Entity);
            form.ShowDialog();
            Datos_Alumno_Examen.ResetBindings(false);
        }

        protected override void EditExamenAction()
        {
            try
            {
                Alumno_Examen current = (Alumno_Examen)Examenes_Grid.CurrentRow.DataBoundItem;
                if (current != null)
                {
                    ExamenInfo examen = ExamenInfo.Get(current.OidExamen, false);
                    if (examen != null && !examen.Desarrollo)
                    {
                        Alumno_ExamenEditForm form = new Alumno_ExamenEditForm();
                        form.SetSourceData(Entity, current);
                        form.ShowDialog();
                        Datos_Alumno_Examen.ResetBindings(false);
                    }
                }
            }
            catch { }
        }

        protected override void ModificaNotaPracticasAction(Alumno_Practica item)
        {
            if (Datos.Current != null)
            {
                if (item.Calificacion != Resources.Labels.FALTA_ASISTENCIA_LABEL)
                {
                    if (item.Calificacion == Resources.Labels.APTO_LABEL)
                        item.Calificacion = Resources.Labels.NO_APTO_LABEL;
                    else
                    {
                        if (item.Calificacion == Resources.Labels.NO_APTO_LABEL 
                            || item.Calificacion == Resources.Labels.SIN_CALIFICAR_LABEL)
                            item.Calificacion = Resources.Labels.APTO_LABEL;
                    }
                }

                if (item.Recuperada)
                    item.Recuperada = false;
                //Alumno_Parte parte = _entity.AlumnoPartes.GetItem(new FCriteria<long>("OidParte", item.OidParte));
                //if (parte != null && !parte.Falta)
                //    item.Calificacion = Resources.Labels.APTO_LABEL;
            }
        }

        protected override void PrintCertificadoNotasAction()
        {
            RegistroNotasAlumnoForm form = new RegistroNotasAlumnoForm(true, this, _entity.Oid);
            form.ShowDialog();
        }

        protected override void PrintNotasPracticas()
        {
            InformesReportMng reportMng = new InformesReportMng(AppContext.ActiveSchema);

            NotaPracticasAlumnoRpt report = null;

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

            string promos = string.Empty;

            foreach(Alumno_Promocion ap in _entity.Promociones)
                promos += ap.Promocion + "; ";

            NotaPracticasList list = NotaPracticasList.GetListByAlumno(false, _entity.Oid);

            report = reportMng.GetDetailReport(empresa, EntityInfo.GetPrintObject(), promos, list);

            if (report != null)
            {
                report.SetParameterValue("Empresa", empresa.Name);
                report.SetParameterValue("Alumno", _entity.Nombre + "  " + _entity.Apellidos);
                report.SetParameterValue("Promoción", promos);
                if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(report.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                ReportViewer.SetReport(report);
                ReportViewer.ShowDialog();
            }
            else
            {
                MessageBox.Show(Resources.Messages.NO_DATA_REPORTS,
                                moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        protected override void PrintFaltasAsistencia()
        {
            InformesReportMng reportMng = new InformesReportMng(AppContext.ActiveSchema);

            FaltasByAlumnoRpt report = null;

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

            string promos = string.Empty;

            foreach (Alumno_Promocion ap in _entity.Promociones)
                promos += ap.Promocion + "; ";

            FaltaAlumnoList list = FaltaAlumnoList.GetListByAlumno(false, _entity.Oid);

            report = reportMng.GetDetailReport(empresa, EntityInfo.GetPrintObject(), promos, list);

            if (report != null)
            {
                report.SetParameterValue("Empresa", empresa.Name);
                report.SetParameterValue("Alumno", _entity.Nombre + "  " + _entity.Apellidos);
                report.SetParameterValue("Promocion", promos);
                if (empresa.Oid == 2) ((CrystalDecisions.CrystalReports.Engine.TextObject)(report.Section5.ReportObjects["Text1"])).Color = System.Drawing.Color.FromArgb(13, 176, 46);
                ReportViewer.SetReport(report);
                ReportViewer.ShowDialog();
            }
            else
            {
                MessageBox.Show(Resources.Messages.NO_DATA_REPORTS,
                                moleQule.Face.Resources.Labels.ADVISE_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
        }

        protected override void SetCurrentTabDataSources()
        {
            switch(Pestanas_TC.SelectedTab.Name)
            {                
                case "Formacion_TP":
                    { 
                        _entity.LoadChilds(typeof(Alumno_Promocion), true, false);
                        Datos_Alumnos_Promociones.DataSource = _entity.Promociones;
                    } break;
                case "NotasExamenes_TP": 
                    {
                        _entity.LoadChilds(typeof(Alumno_Examen), true, false);
                        Datos_Alumno_Examen.DataSource = _entity.AlumnoExamens; 
                    } break;
                case "NotasPracticas_TP": 
                    { 
                        _entity.LoadChilds(typeof(Alumno_Practica), true, false);
                        Datos_Alumno_Practica.DataSource = _entity.AlumnosPracticas;
                    } break;
                case "FaltasAsistencia_TP": 
                    { 
                        _entity.LoadChilds(typeof(Alumno_Parte), true, false);
                        FCriteria<bool> criteria = new FCriteria<bool>("Falta", true);
                        Datos_Alumno_Parte.DataSource = _entity.AlumnoPartes.GetSubList(criteria);
                    } break;
            }
        }

        #endregion

        #region Buttons

        private void MunicipioP_Button_Click(object sender, EventArgs e)
        {
            MunicipioSelectForm form = new MunicipioSelectForm(this);
            form.ShowDialog();
        }

        private void MunicipioF_Button_Click(object sender, EventArgs e)
        {
            MunicipioSelectForm form = new MunicipioSelectForm(this);
            form.ShowDialog();
        }

        private void DNI_RB_CheckedChanged(object sender, EventArgs e)
        {
            ID_Label.Text = "12345678-X";
            if (DNI_RB.Checked)
                Entity.TipoId = (long)TipoId.DNI;
            ValidateInput();
        }

        private void Auto_RB_CheckedChanged(object sender, EventArgs e)
        {
            ID_Label.Text = string.Empty;
            if (Auto_RB.Checked)
                Entity.TipoId = (long)TipoId.OTROS;
        }

        private void NIE_RB_CheckedChanged(object sender, EventArgs e)
        {
            ID_Label.Text = "X1234567Y";
            if (NIE_RB.Checked)
                Entity.TipoId = (long)TipoId.NIE;
            ValidateInput();
        }

        private void NIF_RB_CheckedChanged(object sender, EventArgs e)
        {
            ID_Label.Text = "12345678-X";
            if (NIF_RB.Checked)
                Entity.TipoId = (long)TipoId.NIF;
            ValidateInput();

        }

        private void GA_RB_Click(object sender, EventArgs e)
        {
            Entity.Grupo = (long)moleQule.Library.Instruction.Grupo.A;
            ValidateInput();
        }

        private void GB_RB_Click(object sender, EventArgs e)
        {
            Entity.Grupo = (long)moleQule.Library.Instruction.Grupo.B;
            ValidateInput();
        }

        private void G0_RB_Click(object sender, EventArgs e)
        {
            Entity.Grupo = (long)moleQule.Library.Instruction.Grupo.SinGrupo;
            ValidateInput();
        }

        private void Examinar_Button_Click(object sender, EventArgs e)
        {
            if (this is AlumnoEditForm)
            {
                try
                {
                    if (Browser.ShowDialog() == DialogResult.OK)
                    {
                        Bitmap imagen = new Bitmap(Browser.FileName);

                        string ext = string.Empty;

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

                        imagen.Dispose();

                        _entity.Foto = _entity.Oid.ToString("000") + ext;
                        File.Copy(Browser.FileName, AppController.FOTOS_ALUMNOS_PATH + _entity.Foto, true);
                    }

                    Images.Show(Entity.Foto, AppController.FOTOS_ALUMNOS_PATH, Logo_PictureBox);
                }
               catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Debe guardar la ficha del alumno actual antes de poder insertar una imagen");
        }

        private void Ninguno_Button_Click(object sender, EventArgs e)
        {
            Images.Delete(Entity.Foto, AppController.FOTOS_ALUMNOS_PATH);
            Entity.Foto = string.Empty;
            Images.Show(Entity.Foto, AppController.FOTOS_ALUMNOS_PATH, Logo_PictureBox);
        }

        #endregion

        #region Events
        
        private void MunicipioP_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MunicipioP_CB.SelectedItem != null)
            {
                MunicipioInfo municipio = _municipios.GetItem(((ComboBoxSource)MunicipioP_CB.SelectedItem).Oid);
                if (municipio != null)
                {
                    _entity.Municipio = municipio.Nombre;
                    _entity.Provincia = municipio.Provincia;
                    _entity.CodPostal = municipio.CodPostal;
                    Provincia_TextBox.Text = _entity.Provincia;
                    CodPostal_TextBox.Text = _entity.CodPostal;
                }
            }
        }

        private void MunicipioP_CB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Add) || e.KeyCode.Equals(Keys.Oemplus))
            {
                MunicipioSelectForm form = new MunicipioSelectForm(this);
                form.ShowDialog();
                MunicipioP_CB.ResetText();
            }
        }

        #endregion

    }
}