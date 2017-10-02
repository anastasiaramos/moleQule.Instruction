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
    public partial class CursoForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps; } }

        protected Library.Instruction.HComboBoxSourceList _combo_promociones;

        public AlumnoList _alumnos;
        protected AlumnoCursoList _cursos = null;

        protected List<ComboBoxSourceList> lista_sources = new List<ComboBoxSourceList>();

        public virtual Curso Entity { get { return null; } set { } }
        public virtual CursoInfo EntityInfo { get { return null; } }

        #endregion

        #region Factory Methods

        public CursoForm() : this(-1, true) { }

        public CursoForm(bool isModal) : this(-1, isModal) { }

        public CursoForm(long oid) : this(oid, true) { }

        public CursoForm(long oid, bool ismodal)
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

            Codigo_TB.Font = new Font("Tahoma", (float)8.25, FontStyle.Bold);

            List<string> visibles = new List<string>();

            visibles.Add(Codigo.Name);
            visibles.Add(Nombre.Name);
            visibles.Add(FechaInicio.Name);
            visibles.Add(FechaCaducidad.Name);

            ControlTools.ShowDataGridColumns(Convocatorias_Grid, visibles);

            List<DataGridViewColumn> cols = new List<DataGridViewColumn>();

            Nombre.Tag = 1;
            cols.Add(Nombre);

            ControlsMng.MaximizeColumns(Convocatorias_Grid, cols);
            ControlsMng.MarkGridColumn(Convocatorias_Grid, ControlsMng.GetCurrentColumn(Convocatorias_Grid));
        }

        #endregion

        #region Validation & Format

        /// <summary>
        /// Asigna formato deseado a los controles del objeto cuando éste es modificado
        /// </summary>
        protected override void FormatData()
        {
            if (Datos.Current != null)
            {
                Codigo_TB.Text = Convert.ToInt64(((Curso)Datos.Current).Codigo).ToString("00000000");
            }
        }

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

        #region Actions

        protected virtual void SelectAlumnos() { }

        #endregion

        #region Events

        private void Datos_Convocatorias_CurrentChanged(object sender, EventArgs e)
        {
            SelectAlumnos();
        }

        #endregion

    }
}

