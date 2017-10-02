using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Common;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class AlumnoForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 14; } }

        private PromocionList _promociones = null;
        //protected ClasePracticaList _practicas = null;
        protected MunicipioList _municipios = null;

        /// <summary>
        /// Lista de alumnos de la entidad
        /// </summary>
        protected CursoList _cursos;

        public virtual Alumno Entity { get { return null; } set { } }
        public virtual AlumnoInfo EntityInfo { get { return null; } }

        public DataGridViewCellStyle AptaStyle = new DataGridViewCellStyle();
        public DataGridViewCellStyle NoAptaStyle = new DataGridViewCellStyle();
        public DataGridViewCellStyle FaltaStyle = new DataGridViewCellStyle();

        #endregion

        #region Factory Methods

        public AlumnoForm() : this(-1, true) { }

        public AlumnoForm(bool isModal) : this(-1, isModal) { }

        public AlumnoForm(long oid) : this(oid, true) { }

        public AlumnoForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        public AlumnoForm(Alumno item, bool ismodal, Form parent)
            : base(item.Oid, new object[1]{item}, ismodal, parent)
        {
            InitializeComponent();
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            ControlTools.Instance.CopyBasicStyle(AptaStyle);
            AptaStyle.BackColor = Color.LightGreen;

            ControlTools.Instance.CopyBasicStyle(NoAptaStyle);
            NoAptaStyle.BackColor = Color.Red;

            ControlTools.Instance.CopyBasicStyle(FaltaStyle);
            FaltaStyle.BackColor = Color.Orange;
        }

        public override void RefreshSecondaryData()
        {
            _municipios = MunicipioList.GetList(false);
            Library.Common.HComboBoxSourceList combo_municipios = new Library.Common.HComboBoxSourceList(_municipios);
            Datos_Municipios.DataSource = combo_municipios;
            //MunicipioP_CB.Text = EntityInfo.Municipio;
            PgMng.Grow();

            _promociones = PromocionList.GetList(false);
            PgMng.Grow();
            moleQule.Library.Instruction.HComboBoxSourceList combo_promociones = new moleQule.Library.Instruction.HComboBoxSourceList(_promociones);
            //_promociones.AddEmptyItem();
            Datos_Promociones.DataSource = combo_promociones;
            PgMng.Grow();

            //moleQule.Library.Instruction.HComboBoxSourceList _combo_practicas = new moleQule.Library.Instruction.HComboBoxSourceList();

            //if (EntityInfo.OidPromocion != 0)
            //{
                //_practicas = ClasePracticaList.GetList();
                //_combo_practicas = new moleQule.Library.Instruction.HComboBoxSourceList(_practicas);
            //}
            PgMng.Grow();

            //Datos_Practicas.DataSource = _combo_practicas;
            PgMng.Grow();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Images.Show(EntityInfo.Foto, moleQule.Library.Application.AppController.FOTOS_ALUMNOS_PATH, Logo_PictureBox);
            PgMng.Grow();
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
                switch (EntityInfo.TipoId)
                {
                    case (long)ETipoID.CIF:
                        Validator.ValidateCIF(ID_LB.Text, ID_TB.Text);
                        break;

                    case (long)ETipoID.NIF:
                    case (long)ETipoID.DNI:
                        Validator.ValidateNIF(ID_LB.Text, ID_TB.Text);
                        break;

                    case (long)ETipoID.NIE:
                        Validator.ValidateNIE(ID_LB.Text, ID_TB.Text);
                        break;
                }
            }
            catch (iQValidationException ex)
            {
                MessageBox.Show(ex.Message);
                ID_TB.Text = string.Empty;
            }
        }

        #endregion

        #region Print

        //public override void PrintObject()
        //{
        //    ClienteReportMng reportMng = new ClienteReportMng(AppContext.ActiveSchema);
        //    ReportViewer.SetReport(reportMng.GetAlumnoReport(EntityInfo, _proveedores.GetItem(EntityInfo.ProveedorN)));
        //    ReportViewer.ShowDialog();
        //}

        #endregion

        #region Actions

        protected virtual void AddExamenAction() {}
        protected virtual void EditExamenAction() {}
        protected virtual void ModificaNotaPracticasAction(Alumno_Practica item) { }
        protected virtual void PrintCertificadoNotasAction() { }
        protected virtual void SetCurrentTabDataSources() { }
        protected virtual void PrintNotasPracticas() { }
        protected virtual void PrintFaltasAsistencia() { }

        #endregion
        
        #region Buttons

        protected override void PrintAction()
        {
            switch (Pestanas_TC.SelectedTab.Name)
            {
                case "General_TP":
                    {
                        PrintObject();
                    } break;
                case "FaltasAsistencia_TP":
                    {
                        PrintFaltasAsistencia();
                    }
                    break;
                case "NotasPracticas_TP":
                    {
                        PrintNotasPracticas();
                    }
                    break;
                default:
                    {
                        //PrintSelectSkinForm psform = new PrintSelectSkinForm(true);
                        //psform.EnableDetail(false);
                        //psform.ShowDialog();
                        //if (psform.DialogResult == DialogResult.Cancel) return;

                        //switch (TabControl.SelectedTab.Name)
                        //{
                        //    case "Alumnos_TP":
                        //        {
                        //            PrintData(Entidad.Historia, psform.Source, psform.Type);
                        //        } break;

                        //}
                    } break;
            }
        }
       
        private void NuevoExamen_BT_Click(object sender, EventArgs e)
        {
            AddExamenAction();
        }

        private void EditarExamen_BT_Click(object sender, EventArgs e)
        {
            EditExamenAction();
        }

        private void PrintCertificado_BT_Click(object sender, EventArgs e)
        {
            PrintCertificadoNotasAction();
        }
        
        #endregion

        #region Events

        private void Datos_DataSourceChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(ID_GB.Name);
            SetDependentControlSource(Grupo_GB.Name);
        }

        private void Examenes_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void Examenes_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Examenes_Grid.Name);
        }

        private void Practicas_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this is AlumnoViewForm) return;

            if (Practicas_Grid.CurrentRow == null) return;
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            if (Practicas_Grid.Columns[e.ColumnIndex].Name == Calificacion_BT.Name)
            {
                DataGridViewRow row = Practicas_Grid.CurrentRow;
                Alumno_Practica item = row.DataBoundItem as Alumno_Practica;
                ModificaNotaPracticasAction(item);
                Practicas_Grid.Refresh();
            }
        }

        private void Practicas_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Practicas_Grid.Name);
        }

        private void Faltas_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Faltas_Grid.Name);
        }

        private void Practicas_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void Promociones_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void Faltas_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void Practicas_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (this is AlumnoViewForm) return;
            if (Practicas_Grid.Columns[e.ColumnIndex].Name == Recuperada.Name)
            {
                DataGridViewRow row = Practicas_Grid.CurrentRow;
                Alumno_Practica item = row.DataBoundItem as Alumno_Practica;
                if (item.Calificacion == Resources.Labels.APTO_LABEL
                    || item.Calificacion == Resources.Labels.SIN_CALIFICAR_LABEL)
                {
                    e.Cancel = true;
                }
                Practicas_Grid.Refresh();
            }
            if (Practicas_Grid.Columns[e.ColumnIndex].Name == FechaRecuperacion.Name)
            {
                DataGridViewRow row = Practicas_Grid.CurrentRow;
                Alumno_Practica item = row.DataBoundItem as Alumno_Practica;
                if (!item.Recuperada)
                {
                    e.Cancel = true;
                }
                Practicas_Grid.Refresh();
            }
        }

        private void Pestanas_TC_TabIndexChanged(object sender, EventArgs e)
        {
            //SetCurrentTabDataSources();
        }
        
        #endregion
        
    }
}
