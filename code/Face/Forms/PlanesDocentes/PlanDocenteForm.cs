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
    public partial class PlanDocenteForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 15; } }

		protected ModuloList _modulos;
		protected SubmoduloList _submodulos;
        protected ProductList _productos;
        protected SerieList _series;

		protected DataSourceList _source_list_t;
		protected DataSourceList _source_list_p;

        public virtual PlanEstudios Entity { get { return null; } set { } }
        public virtual PlanEstudiosInfo EntityInfo { get { return null; } }

		/// <summary>
		/// Devuelve el objeto activo de la tabla
		/// </summary>
		/// <returns></returns>
		public ClaseTeorica CurrentClaseTeorica { get { return Teoricas_Grid.CurrentRow != null ? ((ClaseTeorica)Teoricas_Grid.CurrentRow.DataBoundItem) : null; } }

		/// <summary>
		/// Devuelve el objeto activo de la tabla
		/// </summary>
		/// <returns></returns>
		public ClasePractica CurrentClasePractica { get { return Practicas_Grid.CurrentRow != null ? ((ClasePractica)Practicas_Grid.CurrentRow.DataBoundItem) : null; } }

		/// <summary>
		/// Devuelve el OID del módulo activo seleccionado en la fila actual
		/// </summary>
		/// <returns></returns>
		public long ActiveComboModulo
		{
			get
			{
				switch (Clases_TC.SelectedTab.Name)
				{
					case "Teoricas_TP":
						{
							return Teoricas_Grid.CurrentRow != null ? ((ComboBoxSource)Datos_Modulos.Current).Oid : -1;
						} 

					case "Practicas_TP":
						{
							return Practicas_Grid.CurrentRow != null ? ((ComboBoxSource)Datos_Modulos.Current).Oid : -1;
						} 

				}

				return -1;
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
				switch (Clases_TC.SelectedTab.Name)
				{ 
					case "Teoricas_TP":
					{
						return Teoricas_Grid.CurrentRow != null ? _source_list_t.GetCurrentChild(Teoricas_Grid.CurrentRow.Index).Oid : -1;
					} 

					case "Practicas_TP":
					{
						return Practicas_Grid.CurrentRow != null ? _source_list_p.GetCurrentChild(Practicas_Grid.CurrentRow.Index).Oid : -1;
					} 
				}

				return -1;
				
			} 
		}

		/// <summary>
		/// Añade una lista de valores de combobox a la lista de combos
		/// </summary>
		protected virtual void AddComboList(Type tipo) { throw new iQImplementationException("No se ha definido AddComboList"); }

        #endregion

        #region Factory Methods

        public PlanDocenteForm() : this(-1, true) { }

        public PlanDocenteForm(bool isModal) : this(-1, isModal) { }

		public PlanDocenteForm(long oid) : this(oid, true) { }

        public PlanDocenteForm(long oid, bool ismodal)
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
            t_visibles.Add(OrdenPrimario.Name);
            t_visibles.Add(OrdenSecundario.Name);
            t_visibles.Add(OrdenTerciario.Name);
            t_visibles.Add(Alias.Name);
            t_visibles.Add(TotalClases.Name);
            t_visibles.Add(Observaciones.Name);


            ControlTools.ShowDataGridColumns(Teoricas_Grid, t_visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Teoricas_Grid.Width - vs.Width
                                                - Teoricas_Grid.RowHeadersWidth
                                                - Teoricas_Grid.Columns[Modulo_CBC.Name].Width
                                                - Teoricas_Grid.Columns[Submodulo_CBC.Name].Width
                                                - Teoricas_Grid.Columns[OrdenPrimario.Name].Width
                                                - Teoricas_Grid.Columns[OrdenSecundario.Name].Width
                                                - Teoricas_Grid.Columns[OrdenTerciario.Name].Width
                                                - Teoricas_Grid.Columns[TotalClases.Name].Width
                                                - Teoricas_Grid.Columns[Alias.Name].Width);

            Teoricas_Grid.Columns[Titulo.Name].Width = (int)(rowWidth * 0.495);
            Teoricas_Grid.Columns[Observaciones.Name].Width = (int)(rowWidth * 0.495);

            List<string> p_visibles = new List<string>();

            p_visibles.Add(Modulo_CBC_P.Name);
            p_visibles.Add(Submodulo_CBC_P.Name);
            p_visibles.Add(Titulo_P.Name);
            p_visibles.Add(OrdenPrimario_P.Name);
            p_visibles.Add(OrdenSecundario_P.Name);
            p_visibles.Add(OrdenTerciario_P.Name);
            p_visibles.Add(Alias_P.Name);
            p_visibles.Add(Incompatible.Name);
            p_visibles.Add(Duracion.Name);
            p_visibles.Add(Observaciones_P.Name);
            
            ControlTools.ShowDataGridColumns(Practicas_Grid, p_visibles);

            rowWidth = (int)(Practicas_Grid.Width - vs.Width
                                                - Practicas_Grid.RowHeadersWidth
                                                - Practicas_Grid.Columns[Modulo_CBC_P.Name].Width
                                                - Practicas_Grid.Columns[Submodulo_CBC_P.Name].Width
                                                - Practicas_Grid.Columns[OrdenPrimario_P.Name].Width
                                                - Practicas_Grid.Columns[OrdenSecundario_P.Name].Width
                                                - Practicas_Grid.Columns[OrdenTerciario_P.Name].Width
                                                - Practicas_Grid.Columns[Incompatible.Name].Width
                                                - Practicas_Grid.Columns[Duracion.Name].Width
                                                - Practicas_Grid.Columns[Alias_P.Name].Width);

            Practicas_Grid.Columns[Titulo_P.Name].Width = (int)(rowWidth * 0.495);
            Practicas_Grid.Columns[Observaciones_P.Name].Width = (int)(rowWidth * 0.495);

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

            _source_list_t = new DataSourceList(comboModulosT);
            _source_list_p = new DataSourceList(comboModulosP);
            Datos_Modulos.DataSource = _source_list_t.CBList;
            PgMng.Grow();

            Library.Instruction.HComboBoxSourceList _incompatibles = new Library.Instruction.HComboBoxSourceList();
            ComboBoxSource _compatible = new ComboBoxSource(0, "");
            ComboBoxSource _inc_1 = new ComboBoxSource(1, "1");
            ComboBoxSource _inc_2 = new ComboBoxSource(2, "2");
            ComboBoxSource _inc_3 = new ComboBoxSource(3, "3");
            ComboBoxSource _inc_4 = new ComboBoxSource(4, "4");
            ComboBoxSource _inc_5 = new ComboBoxSource(5, "5");
            _incompatibles.Add(_compatible);
            _incompatibles.Add(_inc_1);
            _incompatibles.Add(_inc_2);
            _incompatibles.Add(_inc_3);
            _incompatibles.Add(_inc_4);
            _incompatibles.Add(_inc_5);
            Datos_Incompatible.DataSource = _incompatibles;
            PgMng.Grow();

        }

        protected virtual void ResumenAction() { }

        protected virtual void MergePlanesAction() { }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Buttons
		
		private void CTeoricas_Button_Click(object sender, EventArgs e)
		{
			TeoricasActionForm form = new TeoricasActionForm();
            form.SetSourceData(Entity);
            form.ShowDialog();
		}

		private void CPracticas_Button_Click(object sender, EventArgs e)
		{
            PracticasActionForm form = new PracticasActionForm();
            form.SetSourceData(Entity);
            form.ShowDialog();
		}

        private void Resumen_BT_Click(object sender, EventArgs e)
        {
            ResumenAction();
        }

        private void Merge_BT_Click(object sender, EventArgs e)
        {
            MergePlanesAction();
        }

        //private void SerieInstruccion_BT_Click(object sender, EventArgs e)
        //{
        //    SerieSelectForm form = new SerieSelectForm(this, _series);

        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        SerieInfo serie = form.Selected as SerieInfo;
        //        Entity.OidSerie = serie.Oid;
        //        SerieInstruccion_TB.Text = serie.Nombre;
        //    }

        //}

        //private void ProductoInstruccion_BT_Click(object sender, EventArgs e)
        //{
        //    ProductSelectForm form = new ProductSelectForm(this, _productos);

        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        ProductInfo producto = form.Selected as ProductInfo;
        //        Entity.OidProducto = producto.Oid;
        //        ProductoInstruccion_TB.Text = producto.Nombre;
        //    }

        //}

        #endregion

        #region Events

		private void PlanDocenteForm_Shown(object sender, EventArgs e)
		{
            if (Clases_TC.SelectedTab.Name == "Teoricas_TP")
			    SetUnlinkedGridValues(Teoricas_Grid.Name);
            else
			    SetUnlinkedGridValues(Practicas_Grid.Name);
		}

		private void Teoricas_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
            switch (Teoricas_Grid.Columns[e.ColumnIndex].Name)
            {
                case "Modulo_CBC":
                    {
                        if (ActiveComboModulo > 0 && Teoricas_Grid["Modulo_CBC", e.RowIndex].Value != null)
                        {
                            //se está modificando una línea ya existente
                            if (_source_list_t.CombosListCount > e.RowIndex)
                                _source_list_t.UpdateCombosList(e.RowIndex, ActiveComboModulo);
                            else //hay que añadir un nuevo datasource a la lista
                                _source_list_t.AddCombosList(ActiveComboModulo);

                            CurrentClaseTeorica.OidModulo = ActiveComboModulo;

                            ((DataGridViewComboBoxCell)(Teoricas_Grid["Submodulo_CBC", e.RowIndex])).DataSource = _source_list_t.GetCombosList(e.RowIndex);
                        }
                    } break;

                case "Submodulo_CBC":
                    {
                        if (ActiveComboSubmodulo > 0 && Teoricas_Grid["Submodulo_CBC", e.RowIndex].Value != null)
                        {
                            SubmoduloInfo submodulo = _submodulos.GetItem(ActiveComboSubmodulo);
                            ModuloInfo modulo = _modulos.GetItem(submodulo.OidModulo);
                            Teoricas_Grid["Titulo", e.RowIndex].Value = modulo.Texto + " " + submodulo.Codigo;
                            string alias;
                            /*if (submodulo.Codigo.Length > 5)
                                alias = submodulo.Codigo.Substring(0, 5);
                            else*/
                                alias = submodulo.Codigo;

                            CurrentClaseTeorica.OidSubmodulo = ActiveComboSubmodulo;
                            Teoricas_Grid["Alias", e.RowIndex].Value = alias + " (1/1)";
                        }

                    } break;
            }

		}

		private void Teoricas_Grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			if (_source_list_t == null) return;
			AddComboList(typeof(ClaseTeorica));
		}

		private void Teoricas_Grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
            if (this is PlanDocenteViewForm) return;

            long oid_clase = ((ClaseTeorica)e.Row.DataBoundItem).Oid;

            //comprueba que no haya ningún horario que incluya esta clase
            if (oid_clase == -1 || ClaseTeorica.SesionExists(oid_clase))
            {
                MessageBox.Show(Resources.Messages.CLASE_ASIGNADA);
                e.Cancel = true;
            }
            else
            {
                //Eliminamos el datasource asociado
                if (_source_list_t.CombosListCount > e.Row.Index)
                    _source_list_t.DeleteCombosList(e.Row.Index);
            }
		}

		private void Teoricas_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}

		private void Practicas_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			switch (Practicas_Grid.Columns[e.ColumnIndex].Name)
			{
				case "Modulo_CBC_P":
					{
						if (ActiveComboModulo > 0 && Practicas_Grid["Modulo_CBC_P", e.RowIndex].Value != null)
						{
							//se está modificando una línea ya existente
							if (_source_list_p.CombosListCount > e.RowIndex)
								_source_list_p.UpdateCombosList(e.RowIndex, ActiveComboModulo);
							else //hay que añadir un nuevo datasource a la lista
								_source_list_p.AddCombosList(ActiveComboModulo);

							CurrentClasePractica.OidModulo = ActiveComboModulo;

							((DataGridViewComboBoxCell)(Practicas_Grid["Submodulo_CBC_P", e.RowIndex])).DataSource = _source_list_p.GetCombosList(e.RowIndex);
						}
					} break;

				case "Submodulo_CBC_P":
					{
                        if (ActiveComboSubmodulo > 0 && Practicas_Grid["Submodulo_CBC_P", e.RowIndex].Value != null)
                        {
                            SubmoduloInfo submodulo = _submodulos.GetItem(ActiveComboSubmodulo);
                            ModuloInfo modulo = _modulos.GetItem(submodulo.OidModulo);
                            Practicas_Grid["Titulo_P", e.RowIndex].Value = modulo.Texto + " " + submodulo.Codigo;
                            string alias;
                            /*if (submodulo.Codigo.Length > 5)
                                alias = submodulo.Codigo.Substring(0, 5);
                            else*/
                                alias = submodulo.Codigo;

                            CurrentClasePractica.OidSubmodulo = ActiveComboSubmodulo;
                            Practicas_Grid["Alias_P", e.RowIndex].Value = alias + " (1/1)";
                        }

					} break;
			}
		}

		private void Practicas_Grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			if (_source_list_p == null) return;
			AddComboList(typeof(ClasePractica));
		}

        private void Practicas_Grid_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (this is PlanDocenteViewForm) return;

            long oid_clase = ((ClasePractica)e.Row.DataBoundItem).Oid;

            //comprueba que no haya ningún horario que incluya esta clase
            if (oid_clase == -1 || ClasePractica.SesionExists(oid_clase))
            {
                MessageBox.Show(Resources.Messages.CLASE_ASIGNADA);
                e.Cancel = true;
            }
            else
            {
                //Eliminamos el datasource asociado
                if (_source_list_p.CombosListCount > e.Row.Index)
                    _source_list_p.DeleteCombosList(e.Row.Index);
            }
        }

		private void Practicas_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{

		}

        private void Clases_TC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Clases_TC.SelectedTab.Name == "Teoricas_TP")
                SetUnlinkedGridValues(Teoricas_Grid.Name);
            else
                SetUnlinkedGridValues(Practicas_Grid.Name);
        }

        #endregion
        
    }
}


