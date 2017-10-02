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
using moleQule.Library.Store;

using moleQule.Face.Store; 

namespace moleQule.Face.Instruction
{
    public partial class PlanExtraForm : ItemMngSkinForm
    {
        #region Business Methods

        protected override int BarSteps { get { return 15; } }

		protected ModuloList _modulos;
        protected SubmoduloList _submodulos;
        protected ProductList _productos;
        protected SerieList _series;

		protected DataSourceList _source_list;

        public virtual PlanExtra Entity { get { return null; } set { } }
        public virtual PlanExtraInfo EntityInfo { get { return null; } }

		/// <summary>
		/// Devuelve el objeto activo de la tabla
		/// </summary>
		/// <returns></returns>
		public ClaseExtra CurrentClaseExtra { get { return Clases_Grid.CurrentRow != null ? ((ClaseExtra)Clases_Grid.CurrentRow.DataBoundItem) : null; } }

        /// <summary>
		/// Devuelve el OID del módulo activo seleccionado en la fila actual
		/// </summary>
		/// <returns></returns>
        public long ActiveComboModulo
        {
            get
            {
                return Clases_Grid.CurrentRow != null ? ((ComboBoxSource)Datos_Modulos.Current).Oid : -1;
            }
        }

		/// <summary>
		/// Devuelve el OID del submódulo activo seleccionado en la fila actual
		/// </summary>
		/// <returns></returns>
		public long ActiveComboSubmodulo 
		{ 
            get
            {
			    return Clases_Grid.CurrentRow != null ? _source_list.GetCurrentChild(Clases_Grid.CurrentRow.Index).Oid : -1;
		    }
        }

		/// <summary>
		/// Añade una lista de valores de combobox a la lista de combos
		/// </summary>
		protected virtual void AddComboList() { throw new iQImplementationException("No se ha definido AddComboList"); }

        #endregion

        #region Factory Methods

        public PlanExtraForm() : this(-1, true) { }

        public PlanExtraForm(bool isModal) : this(-1, isModal) { }

		public PlanExtraForm(long oid) : this(oid, true) { }

        public PlanExtraForm(long oid, bool ismodal)
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

            List<string> t_visibles = new List<string>();

            t_visibles.Add(Modulo_CBC.Name);
            t_visibles.Add(Submodulo_CBC.Name);
            t_visibles.Add(Titulo.Name);
            t_visibles.Add(Alias.Name);
            t_visibles.Add(Observaciones.Name);


            ControlTools.ShowDataGridColumns(Clases_Grid, t_visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Clases_Grid.Width - vs.Width
                                                - Clases_Grid.RowHeadersWidth
                                                - Clases_Grid.Columns[Modulo_CBC.Name].Width
                                                - Clases_Grid.Columns[Submodulo_CBC.Name].Width
                                                - Clases_Grid.Columns[Alias.Name].Width);

            Clases_Grid.Columns[Titulo.Name].Width = (int)(rowWidth * 0.495);
            Clases_Grid.Columns[Observaciones.Name].Width = (int)(rowWidth * 0.495);

        }

        public override void RefreshSecondaryData()
        {
            _productos = ProductList.GetList(false);
            _series = SerieList.GetList(false, ETipoSerie.Compra);
            _modulos = ModuloList.GetList(false);
            Library.Instruction.HComboBoxSourceList comboModulosT = new Library.Instruction.HComboBoxSourceList(_modulos);
            Library.Instruction.HComboBoxSourceList comboModulosP = new Library.Instruction.HComboBoxSourceList(_modulos);
            PgMng.Grow();

            _submodulos = SubmoduloList.GetList(false);
            comboModulosT.Childs = new Library.Instruction.HComboBoxSourceList(_submodulos);
            comboModulosP.Childs = new Library.Instruction.HComboBoxSourceList(_submodulos);
            PgMng.Grow();

            _source_list = new DataSourceList(comboModulosT);
            Datos_Modulos.DataSource = _source_list.CBList;
            PgMng.Grow();

        }

        protected virtual void ResumenAction() { }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Buttons

        private void Add_Clases_BT_Click(object sender, EventArgs e)
        {
            ExtrasActionForm form = new ExtrasActionForm();
            form.SetSourceData(Entity);
            form.ShowDialog();
        }

        private void Resumen_BT_Click(object sender, EventArgs e)
        {
            ResumenAction();
        }

        private void SerieInstruccion_BT_Click(object sender, EventArgs e)
        {
            SerieSelectForm form = new SerieSelectForm(this, _series);

            if (form.ShowDialog() == DialogResult.OK)
            {
                SerieInfo serie = form.Selected as SerieInfo;
                Entity.OidSerie = serie.Oid;
                SerieInstruccion_TB.Text = serie.Nombre;
            }

        }

        private void ProductoInstruccion_BT_Click(object sender, EventArgs e)
        {
            ProductSelectForm form = new ProductSelectForm(this, _productos);

            if (form.ShowDialog() == DialogResult.OK)
            {
                ProductInfo producto = form.Selected as ProductInfo;
                Entity.OidProducto = producto.Oid;
                ProductoInstruccion_TB.Text = producto.Nombre;
            }

        }

        #endregion

        #region Events

		private void PlanExtraForm_Shown(object sender, EventArgs e)
		{
            SetUnlinkedGridValues(Clases_Grid.Name);
		}

		private void Clases_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{ 
            //Clases_Grid.Columns[e.ColumnIndex].Name
			switch (e.ColumnIndex)
			{
				case 0://"Modulo_CBC":
					{
						if (ActiveComboModulo > 0 && Clases_Grid["Modulo_CBC", e.RowIndex].Value != null)
						{
							//se está modificando una línea ya existente
							if (_source_list.CombosListCount > e.RowIndex)
								_source_list.UpdateCombosList(e.RowIndex, ActiveComboModulo);
							else //hay que añadir un nuevo datasource a la lista
								_source_list.AddCombosList(ActiveComboModulo);

							CurrentClaseExtra.OidModulo = ActiveComboModulo;

							((DataGridViewComboBoxCell)(Clases_Grid["Submodulo_CBC", e.RowIndex])).DataSource = _source_list.GetCombosList(e.RowIndex);
						}
					} break;

				case 1://"Submodulo_CBC":
					{
                        if (ActiveComboSubmodulo > 0 && Clases_Grid["Submodulo_CBC", e.RowIndex].Value != null)
                        {
                            SubmoduloInfo submodulo = _submodulos.GetItem(ActiveComboSubmodulo);
                            ModuloInfo modulo = _modulos.GetItem(submodulo.OidModulo);
                            Clases_Grid["Titulo", e.RowIndex].Value = modulo.Texto + " " + submodulo.Codigo;
                            string alias;
                            if (submodulo.Codigo.Length > 5)
                                alias = submodulo.Codigo.Substring(0, 5);
                            else
                                alias = submodulo.Codigo;

                            CurrentClaseExtra.OidSubmodulo = ActiveComboSubmodulo;
                            Clases_Grid["Alias", e.RowIndex].Value = alias + " (1/1)";
                        }

					} break;
			}

		}

		private void Clases_Grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			if (_source_list == null) return;
			AddComboList();
		}

		private void Clases_Grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (this is PlanExtraViewForm) return;

            long oid_clase = ((ClaseExtra)e.Row.DataBoundItem).Oid;

            //comprueba que no haya ningún horario que incluya esta clase
            if (oid_clase == -1 || ClaseExtra.SesionExists(oid_clase))
            {
                MessageBox.Show(Resources.Messages.CLASE_ASIGNADA);
                e.Cancel = true;
            }
            else
            {
                //Eliminamos el datasource asociado
                if (_source_list.CombosListCount > e.Row.Index)
                    _source_list.DeleteCombosList(e.Row.Index);
            }
		}

		private void Clases_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}

        #endregion

    }
}


