using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class InstructorViewForm : InstructorForm
    {

        #region Business Methods

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private InstructorInfo _entity;

        public override InstructorInfo EntityInfo { get { return _entity; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private InstructorViewForm() : this(-1) { }

        public InstructorViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();

            SetFormData();

            this.Text = Resources.Labels.INSTRUCTOR_EDIT_TITLE + " " + EntityInfo.Apellidos.ToUpper() + ", " + EntityInfo.Nombre.ToUpper();
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = InstructorInfo.Get(oid, true);
            _mf_type = ManagerFormType.MFView;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            SetReadOnlyControls(this.Controls);
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;
            base.FormatControls();
            Disponibilidad_BT.Enabled = true;
        }

		public override void RefreshSecondaryData()
		{
			Datos_Promociones.DataSource = _entity.Promociones;
            PgMng.Grow();

            if (Datos_Promociones.Current != null && ((Instructor_PromocionInfo)Datos_Promociones.Current).OidPromocion > 0)
            {
                Submodulo_Instructor_PromocionList lista = _entity.Promociones.GetItem(((Instructor_PromocionInfo)Datos_Promociones.Current).Oid).Submodulos;
                Datos_Submodulo_Instructor_Promocion.DataSource = lista;
            }
            PgMng.Grow();

            Datos_Submodulo_Instructor.DataSource = _entity.Submodulos;
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
            Datos.DataSource = _entity;

            //Ini_Contrato_DTP.Value = _entity.InicioContrato;
            //Fin_Contrato_DTP.Value = _entity.FinContrato;
            //PgMng.Grow();
            Datos_ProductoProveedor.DataSource = _entity.Productos;

            Datos_CursosFormacion.DataSource = CursoFormacionList.SortList(_entity.CursosFormacion, "Fecha", ListSortDirection.Ascending);
            PgMng.Grow(string.Empty, "CursosFormacion");

            base.RefreshMainData();
            PgMng.FillUp();
        }

        /// <summary>
        /// Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        //protected override void SetUnlinkedGridValues(string gridName)
        //{
        //    switch (gridName)
        //    {
        //        case "Submodulo_Instructor_Grid":
        //            {
        //                foreach (DataGridViewRow row in Submodulo_Instructor_Grid.Rows)
        //                {
        //                    if (row.IsNewRow) continue;
        //                    if (_submodulos == null) _submodulos = SubmoduloList.GetList(false);
        //                    Submodulo_Instructor_PromocionInfo info = (Submodulo_Instructor_PromocionInfo)row.DataBoundItem;
        //                    if (info != null)
        //                    {
        //                        SubmoduloInfo submodulo = _submodulos.GetItem(info.OidSubmodulo);
        //                        if (submodulo != null)
        //                            row.Cells["Modulo_CBC"].Value = submodulo.OidModulo;
        //                    }
        //                }

        //            } break;
        //    }
        //}

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
                        Auto_RB.Checked = (EntityInfo.TipoId == (long)TipoId.OTROS || EntityInfo.TipoId == 0);
                    } break;
                case "Perfil_GB":
                    {
                        RExamenes_CB.Checked = (EntityInfo.Perfil >> 2) % 2 == 1; 
                        Instructor_CB.Checked = (EntityInfo.Perfil >> 1) % 2 == 1;
                        Examinador_CB.Checked = EntityInfo.Perfil % 2 == 1;
                        Instructor_P_CB.Checked = (EntityInfo.Perfil >> 3) % 2 == 1;
                        RespInstruccion_CB.Checked = (EntityInfo.Perfil >> 4) % 2 == 1;
                        Resp_Calidad_CB.Checked = (EntityInfo.Perfil >> 5) % 2 == 1;
                        Evaluador_P_CB.Checked = (EntityInfo.Perfil >> 6) % 2 == 1;
                        Gerente_CB.Checked = (EntityInfo.Perfil >> 8) % 2 == 1;
                        Administrador_CB.Checked = (EntityInfo.Perfil >> 9) % 2 == 1;
                        Auditor_CB.Checked = (EntityInfo.Perfil >> 7) % 2 == 1;
                    } break;  
            }
        }


        protected override void SetCellsDataSource(string gridName)
        {
            switch (gridName)
            {
                case "Submodulo_Instructor_Grid":
                    {
                        foreach (DataGridViewRow row in Submodulo_Instructor_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (lista_sources.Count >= row.Index + 1) continue;
                            Submodulo_Instructor_PromocionInfo info = (Submodulo_Instructor_PromocionInfo)row.DataBoundItem;
                            if ((info != null) && (_combo_modulos != null))
                            {
                                lista_sources.Add(_combo_modulos.GetFilteredChilds(info.OidModulo));
                                ((DataGridViewComboBoxCell)row.Cells["Submodulo_CBC"]).DataSource = lista_sources[row.Index];
                            }
                        }

                    } break;
                case "Autorizados_Grid":
                    {
                        foreach (DataGridViewRow row in Autorizados_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            if (lista_sources_a.Count >= row.Index + 1) continue;
                            Submodulo_InstructorInfo info = (Submodulo_InstructorInfo)row.DataBoundItem;
                            if ((info != null) && (_combo_modulos != null))
                            {
                                lista_sources_a.Add(_combo_modulos.GetFilteredChilds(info.OidModulo));
                                ((DataGridViewComboBoxCell)row.Cells["SubmoduloA_CBC"]).DataSource = lista_sources_a[row.Index];
                            }
                        }

                    } break;
            }
        }
		
        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        protected override void LoadChildsAction(Type type)
        {
            if (type == typeof(Submodulo_Instructor_Promocion))
            {
                Datos_Promociones.DataSource = _entity.Promociones;

                if (Datos_Promociones.Current != null && ((Instructor_PromocionInfo)Datos_Promociones.Current).OidPromocion > 0)
                {
                    Instructor_PromocionInfo promo = Datos_Promociones.Current as Instructor_PromocionInfo;
                    Datos_Submodulo_Instructor_Promocion.DataSource = promo.Submodulos;
                    SetCellsDataSource(Submodulo_Instructor_Grid.Name);
                }
            }
            if (type == typeof(Submodulo_Instructor))
            {
                Datos_Submodulo_Instructor.DataSource = _entity.Submodulos;
                PgMng.Grow(string.Empty, "Datos_Submodulo_Instructor");
            }
        }

        protected override void ChangeFicha()
        {
            if ((Ficha_TP.SelectedTab == Capacitacion_TP) ||
                (Ficha_TP.SelectedTab == Autorizados_TP))
            {
                if (_modulos == null)
                {
                    PgMng.Reset(4, 1, Resources.Messages.LOADING_DATA, this);

                    _modulos = ModuloList.GetList(false);
                    _combo_modulos = new Library.Instruction.HComboBoxSourceList(ModuloList.SortList(_modulos, "NumeroOrden", ListSortDirection.Ascending));
                    Datos_Modulos.DataSource = _combo_modulos;
                    PgMng.Grow(string.Empty, "Modulos");

                    _submodulos = SubmoduloList.GetList(false);
                    _combo_modulos.Childs = new Library.Instruction.HComboBoxSourceList(SubmoduloList.SortList(_submodulos, "CodigoOrden", ListSortDirection.Ascending));
                    Datos_Submodulos.DataSource = _combo_modulos.Childs;
                    PgMng.Grow(string.Empty, "Submodulos");

                    _promociones = PromocionList.GetList(false);
                    Library.Instruction.HComboBoxSourceList _combo_promociones = new Library.Instruction.HComboBoxSourceList(PromocionList.SortList(_promociones, "Nombre", ListSortDirection.Ascending));
                    Datos_Promociones_CB.DataSource = _combo_promociones;
                    PgMng.Grow(string.Empty, "Promociones");

                    _instructores = InstructorList.GetList(false);
                    Library.Instruction.HComboBoxSourceList _combo_instructores = new Library.Instruction.HComboBoxSourceList(InstructorList.SortList(_instructores, "Apellidos", ListSortDirection.Ascending));
                    Datos_Instructores.DataSource = _combo_instructores;
                    PgMng.FillUp(string.Empty, "Instructores");
                }

                if (Ficha_TP.SelectedTab == Capacitacion_TP) LoadChildsAction(typeof(Submodulo_Instructor_PromocionInfo));
                if (Ficha_TP.SelectedTab == Autorizados_TP) LoadChildsAction(typeof(Submodulo_InstructorInfo));
            }
        }

        #endregion

        #region Events

        private void Disponibilidad_BT_Click(object sender, EventArgs e)
        {
            DisponibilidadViewForm view_form = new DisponibilidadViewForm();
            view_form.SeleccionaInstructor(EntityInfo.Oid);
            EntityMngForm mng = new EntityMngForm();
            mng.AddForm(view_form);
        }

        #endregion
    
    }
}
