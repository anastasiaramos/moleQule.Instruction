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
    public partial class PAsistenciaForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 1; } }

        public AlumnoList _alumnos;

        public virtual ParteAsistencia Entity { get { return null; } set { } }
        public virtual ParteAsistenciaInfo EntityInfo { get { return null; } }

        #endregion

        #region Factory Methods

        public PAsistenciaForm() : this(-1, true) { }

        public PAsistenciaForm(bool isModal) : this(-1, isModal) { }

        public PAsistenciaForm(long oid) : this(oid, true) { }

        public PAsistenciaForm(long oid, bool ismodal)
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

            List<string> visibles = new List<string>();

            visibles.Add(Alumno.Name);
            visibles.Add(Falta.Name);
            visibles.Add(Retraso.Name);
            visibles.Add(Observaciones.Name);
            visibles.Add(Numero.Name);

            ControlTools.ShowDataGridColumns(Alumnos_Grid, visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Alumnos_Grid.Width - vs.Width
                                                - Alumnos_Grid.RowHeadersWidth
                                                - Alumnos_Grid.Columns[Alumno.Name].Width
                                                - Alumnos_Grid.Columns[Falta.Name].Width
                                                - Alumnos_Grid.Columns[Retraso.Name].Width
                                                - Alumnos_Grid.Columns[Numero.Name].Width);

            Alumnos_Grid.Columns[Observaciones.Name].Width = (int)(rowWidth * 0.995);

            if (ModulePrincipal.GetMostrarInstructoresAutorizadosSetting())
            {
                Efectivo_Label.Visible = false;
                ProfesorEfectivo_BT.Visible = false;
                ProfesorEfectivo_TB.Visible = false;
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

        #region Events

        private void Alumnos_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Alumnos_Grid.Name);
        }

        #endregion


    }
}

