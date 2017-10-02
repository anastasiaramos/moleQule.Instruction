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
    public partial class MaterialForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        public AlumnoList _alumnos;

        protected List<ComboBoxSourceList> lista_sources = new List<ComboBoxSourceList>();

        protected Library.Instruction.HComboBoxSourceList _combo_alumnos;
        protected Library.Instruction.HComboBoxSourceList _combo_tipo;
        protected Library.Instruction.HComboBoxSourceList _combo_promociones;

        private MaterialDocenteInfo _entity;

        public virtual MaterialDocente Entity { get { return null; } set { } }
        public virtual MaterialDocenteInfo EntityInfo { get { return _entity; } set { _entity = value; } }

        #endregion

        #region Factory Methods

        public MaterialForm() : this(-1, true) { }

        public MaterialForm(bool isModal) : this(-1, isModal) { }

        public MaterialForm(long oid) : this(oid, true) { }

        public MaterialForm(long oid, bool ismodal)
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

            visibles.Add(Entregado.Name);
            visibles.Add(Alumno_CBC.Name);

            ControlTools.ShowDataGridColumns(Alumnos_Grid, visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Alumnos_Grid.Width - vs.Width
                                                - Alumnos_Grid.RowHeadersWidth
                                                - Alumnos_Grid.Columns[Entregado.Name].Width);

            Alumnos_Grid.Columns[Alumno_CBC.Name].Width = (int)(rowWidth * 0.995);

            List<string> revisiones = new List<string>();

            revisiones.Add(Autor.Name);
            revisiones.Add(Fecha.Name);
            revisiones.Add(Version.Name);
            revisiones.Add(Observaciones.Name);

            ControlTools.ShowDataGridColumns(Revisiones_Grid, revisiones);

            rowWidth = (int)(Revisiones_Grid.Width - vs.Width
                                                - Revisiones_Grid.RowHeadersWidth
                                                - Revisiones_Grid.Columns[Autor.Name].Width
                                                - Revisiones_Grid.Columns[Version.Name].Width
                                                - Revisiones_Grid.Columns[Fecha.Name].Width);

            Revisiones_Grid.Columns[Observaciones.Name].Width = (int)(rowWidth * 0.995);
        }

        public override void RefreshSecondaryData()
        {
            PromocionList promociones = PromocionList.GetList(false);
            _combo_promociones = new Library.Instruction.HComboBoxSourceList(promociones);

            Datos_Promociones.DataSource = _combo_promociones;
            PgMng.Grow();

            _alumnos = AlumnoList.GetList(false);
            _combo_promociones.Childs = new Library.Instruction.HComboBoxSourceList(_alumnos);

            Datos_ComboAlumnos.DataSource = _combo_promociones.Childs;
            PgMng.Grow();

            _combo_tipo = new Library.Instruction.HComboBoxSourceList();
            _combo_tipo.Add(new ComboBoxSource());
            _combo_tipo.Add(new ComboBoxSource(1, "Curso"));
            _combo_tipo.Add(new ComboBoxSource(2, "Módulo"));

            Datos_Tipo.DataSource = _combo_tipo;
            PgMng.Grow();

        }

        protected override void SetCellsDataSource(string gridName)
        {
            //switch (gridName)
            //{
            //    case "Alumnos_Grid":
            //        {
            //            foreach (DataGridViewRow row in Alumnos_Grid.Rows)
            //            {
            //                if (row.IsNewRow) continue;
            //                if (lista_sources.Count >= row.Index + 1) continue;
            //                Material_Alumno info = (Material_Alumno)row.DataBoundItem;
            //                if (info != null)
            //                {
            //                    AlumnoInfo alumno = _alumnos.GetItem(info.OidAlumno);
            //                    if (alumno != null)
            //                    {
            //                        lista_sources.Add(_combo_promociones.GetFilteredChilds(alumno.OidPromocion));
            //                        ((DataGridViewComboBoxCell)row.Cells["Alumno_CBC"]).DataSource = lista_sources[row.Index];
            //                    }
            //                }
            //            }

            //        } break;
            //}
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected virtual void NuevaRevision() {}
        protected virtual void EditarRevision() { }

        #endregion

        #region Buttons

        private void Add_Button_Click(object sender, EventArgs e)
        {
            NuevaRevision();
        }

        private void Edit_Button_Click(object sender, EventArgs e)
        {
            if (Datos_Revisiones.Current == null) return;
            EditarRevision();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            if (this is MaterialViewForm) return;
            if (Datos_Revisiones.Current == null) return;

            //if (MessageBox.Show(moleQule.Face.Resources.Messages.DELETE_CONFIRM,
            //                        moleQule.Face.Resources.Labels.ADVISE_TITLE,
            //                        MessageBoxButtons.YesNoCancel,
            //                        MessageBoxIcon.Question) == DialogResult.Yes)
            //{
                //RevisionMaterial.Delete(((RevisionMaterial)Datos_Revisiones.Current).Oid);
                Entity.Revisiones.Remove(((RevisionMaterial)Datos_Revisiones.Current).Oid);
                Datos_Revisiones.ResetBindings(false);
            //}
        }

        #endregion

        #region Events

        private void Tipo_CB_SelectedValueChanged(object sender, EventArgs e)
        {
            SetDependentControlSource("Tipo_CB");
        }

        private void Nombre_CB_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Datos_Curso.Current != null)
                SetDependentControlSource("Nombre_CB");
        }

        private void Alumnos_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (Alumnos_Grid.Columns[e.ColumnIndex].Name == "Promocion_CBC")
            {
                if (Alumnos_Grid["Promocion_CBC", e.RowIndex].Value != null)
                {
                    //se está modificando una línea ya existente
                    if (lista_sources.Count > e.RowIndex)
                        lista_sources[e.RowIndex] = _combo_promociones.GetFilteredChilds((long)Alumnos_Grid["Promocion_CBC", e.RowIndex].Value);
                    else //hay que añadir un nuevo datasource a la lista
                        lista_sources.Add(_combo_promociones.GetFilteredChilds((long)Alumnos_Grid["Promocion_CBC", e.RowIndex].Value));
                    ((DataGridViewComboBoxCell)(Alumnos_Grid["Alumno_CBC", e.RowIndex])).DataSource = lista_sources[e.RowIndex];
                }
            }
        }

        private void Alumnos_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Alumnos_Grid.Name);
        }

        private void Alumnos_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void Revisiones_Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditarRevision();
        }
        
        #endregion

    }
}


