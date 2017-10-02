using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction; 


namespace moleQule.Face.Instruction
{
    public partial class FormularioNotasPracticasForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 1; } }

        public AlumnoList _alumnos;

        public virtual ParteAsistencia Entity { get { return null; } set { } }
        public virtual ParteAsistenciaInfo EntityInfo { get { return null; } }

        public DataGridViewCellStyle AptaStyle = new DataGridViewCellStyle();
        public DataGridViewCellStyle NoAptaStyle = new DataGridViewCellStyle();
        public DataGridViewCellStyle FaltaStyle = new DataGridViewCellStyle();

        #endregion

        #region Factory Methods

        public FormularioNotasPracticasForm() : this(-1, true) { }

        public FormularioNotasPracticasForm(bool isModal) : this(-1, isModal) { }

        public FormularioNotasPracticasForm(long oid) : this(oid, true) { }

        public FormularioNotasPracticasForm(long oid, bool ismodal)
            : base(oid, ismodal)
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

            List<string> visibles = new List<string>();

            visibles.Add(Alumno.Name);
            visibles.Add(Numero.Name);
            visibles.Add(Calificacion.Name);
            visibles.Add(Observaciones.Name);
            visibles.Add(Recuparada.Name);
            visibles.Add(FechaRecuperacion.Name);

            ControlTools.ShowDataGridColumns(Alumnos_Grid, visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Alumnos_Grid.Width - vs.Width
                                                - Alumnos_Grid.RowHeadersWidth
                                                - Alumnos_Grid.Columns[Alumno.Name].Width
                                                - Alumnos_Grid.Columns[Calificacion.Name].Width
                                                - Alumnos_Grid.Columns[Numero.Name].Width
                                                - Alumnos_Grid.Columns[Recuparada.Name].Width
                                                - Alumnos_Grid.Columns[FechaRecuperacion.Name].Width);

            Alumnos_Grid.Columns[Observaciones.Name].Width = (int)(rowWidth * 0.95);

            if (ModulePrincipal.GetMostrarInstructoresAutorizadosSetting())
            {
                ProfesorEfectivo_TB.Visible = false;
                Efectivo_Label.Visible = false;
            }
        }

        public override void RefreshSecondaryData()
        {
            _alumnos = AlumnoList.GetList(false);
            PgMng.Grow();
        }

        protected virtual void SetInstructorEfectivo() { }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        //public override void PrintObject()
        //{
        //}

        //#endregion

        //#region Buttons

        //protected override void PrintAction()
        //{
        //    switch (TabControl.SelectedTab.Name)
        //    {
        //        case "General_TP":
        //            {
        //                PrintObject();
        //            } break;

        //        default:
        //            {
        //                PrintSelectSkinForm psform = new PrintSelectSkinForm(true);
        //                psform.EnableDetail(false);
        //                psform.ShowDialog();
        //                if (psform.DialogResult == DialogResult.Cancel) return;

        //                switch (TabControl.SelectedTab.Name)
        //                {
        //                    case "Redes_TP":
        //                        {
        //                            PrintData(Entidad.Red, psform.Source, psform.Type);
        //                        } break;

        //                }
        //            } break;
        //    }
        //}

        #endregion

        #region Buttons 
        
        private void ProfesorEfectivo_BT_Click(object sender, EventArgs e)
        {
            SetInstructorEfectivo();
        }

        #endregion

        #region Actions

        protected virtual void ModificaNotaPracticasAction(Alumno_Practica item) { }

        #endregion

        #region Events

        private void Alumnos_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Alumnos_Grid.Name);
        }

        private void Alumnos_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this is FormularioNotasPracticasViewForm) return;

            if (Alumnos_Grid.CurrentRow == null) return;
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;

            if (Alumnos_Grid.Columns[e.ColumnIndex].Name == Calificacion.Name)
            {
                DataGridViewRow row = Alumnos_Grid.CurrentRow;
                Alumno_Practica item = row.DataBoundItem as Alumno_Practica;
                ModificaNotaPracticasAction(item);
                Alumnos_Grid.Refresh();
            }
        }

        private void Alumnos_Grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (this is FormularioNotasPracticasViewForm) return;

            if (Alumnos_Grid.Columns[e.ColumnIndex].Name == Recuparada.Name)
            {
                DataGridViewRow row = Alumnos_Grid.CurrentRow;
                Alumno_Practica item = row.DataBoundItem as Alumno_Practica;
                if (item.Calificacion == Resources.Labels.APTO_LABEL
                    || item.Calificacion == Resources.Labels.SIN_CALIFICAR_LABEL)
                {
                    e.Cancel = true;
                }
                Alumnos_Grid.Refresh();
            }
            if (Alumnos_Grid.Columns[e.ColumnIndex].Name == FechaRecuperacion.Name)
            {
                DataGridViewRow row = Alumnos_Grid.CurrentRow;
                Alumno_Practica item = row.DataBoundItem as Alumno_Practica;
                if (!item.Recuperada)
                {
                    e.Cancel = true;
                }
                Alumnos_Grid.Refresh();
            }
        }

        #endregion
        
        
    }
}

