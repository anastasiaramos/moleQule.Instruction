using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.Application;
using moleQule.Library.Instruction;
using moleQule.Library.Store;

using moleQule.Face.Common;

namespace moleQule.Face.Instruction
{
    public partial class InstructorForm : moleQule.Face.Skin01.ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 4; } }

        public SubmoduloList _submodulos;
        public ModuloList _modulos;
        public PromocionList _promociones;
        public InstructorList _instructores;
        public MunicipioList _municipios;

        protected Library.Instruction.HComboBoxSourceList _combo_modulos;

        protected List<ComboBoxSourceList> lista_sources = new List<ComboBoxSourceList>();
        protected List<ComboBoxSourceList> lista_sources_a = new List<ComboBoxSourceList>();

        public virtual Instructor Entity { get { return null; } set { } }
        public virtual InstructorInfo EntityInfo { get { return null; } }

        public virtual CursoFormacion CurrentCursoF
        {
            get
            {
                return Datos_CursosFormacion.Current != null ? (CursoFormacion)(Datos_CursosFormacion.Current) : null;
            }
        }

        protected bool _cerrado = true;

        #endregion

        #region Factory Methods

        public InstructorForm() : this(-1, true) { }

        public InstructorForm(bool isModal) : this(-1, isModal) { }

        public InstructorForm(long oid) : this(oid, true) { }

        public InstructorForm(long oid, bool ismodal)
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

            List<string> cursos_visibles = new List<string>();
            List<string> form_visibles = new List<string>();
            List<string> promociones_visibles = new List<string>();

            cursos_visibles.Add(Nombre.Name);
            cursos_visibles.Add(Fecha.Name);
            cursos_visibles.Add(NHoras.Name);
            cursos_visibles.Add(FechaRenovacion.Name);
            cursos_visibles.Add(Observaciones.Name);

            ControlTools.ShowDataGridColumns(CursosF_Grid, cursos_visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(CursosF_Grid.Width - vs.Width
                                                - CursosF_Grid.RowHeadersWidth
                                                - CursosF_Grid.Columns[Nombre.Name].Width
                                                - CursosF_Grid.Columns[Fecha.Name].Width
                                                - CursosF_Grid.Columns[NHoras.Name].Width
                                                - CursosF_Grid.Columns[FechaRenovacion.Name].Width);

            CursosF_Grid.Columns[Observaciones.Name].Width = (int)(rowWidth * 0.995);

            form_visibles.Add(Modulo_CBC.Name);
            form_visibles.Add(Submodulo_CBC.Name);
            form_visibles.Add(Prioridad.Name);

            ControlTools.ShowDataGridColumns(Submodulo_Instructor_Grid, form_visibles);

            rowWidth = (int)(Submodulo_Instructor_Grid.Width - vs.Width
                                                - Submodulo_Instructor_Grid.RowHeadersWidth
                                                - Submodulo_Instructor_Grid.Columns[Prioridad.Name].Width);

            Submodulo_Instructor_Grid.Columns[Modulo_CBC.Name].Width = (int)(rowWidth * 0.495);
            Submodulo_Instructor_Grid.Columns[Submodulo_CBC.Name].Width = (int)(rowWidth * 0.495);

            promociones_visibles.Add(Promocion_CBC.Name);

            ControlTools.ShowDataGridColumns(Promociones_Grid, promociones_visibles);

            rowWidth = (int)(Promociones_Grid.Width - vs.Width
                                                - Submodulo_Instructor_Grid.RowHeadersWidth);

            Promociones_Grid.Columns[Promocion_CBC.Name].Width = (int)(rowWidth * 0.995);

            if (Library.Instruction.ModulePrincipal.GetMostrarInstructoresAutorizadosSetting()
                && Ficha_TP.TabPages.Contains(Autorizados_TP))
            {
                Ficha_TP.TabPages.Remove(Autorizados_TP);
                MTOE_CB.Visible = false;
            }
        }

        public override void RefreshSecondaryData()
        {
            Datos_FormaPago.DataSource = Library.Common.EnumText<Library.Common.EFormaPago>.GetList();
            PgMng.Grow();

            Datos_MedioPago.DataSource = Library.Common.EnumText<Library.Common.EMedioPago>.GetList();
            PgMng.Grow();

            _municipios = MunicipioList.GetList(false);
            Library.Common.HComboBoxSourceList combo_municipios = 
                new Library.Common.HComboBoxSourceList(MunicipioList.GetList(false));
            //Datos_Municipios_F.DataSource = MunicipioList.SortList(municipios, "Valor", ListSortDirection.Ascending); ;
            Datos_Municipios_F.DataSource = combo_municipios;
            //MunicipioP_CB.Text = EntityInfo.Municipio;
            PgMng.Grow(string.Empty, "Municipios");
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Images.Show(EntityInfo.Foto, AppController.FOTOS_INSTRUCTORES_PATH, Logo_PictureBox);
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

        #endregion

        #region Actions

        protected virtual void LoadChildsAction(Type type) { }

        protected virtual void ChangeFicha() { }

        protected virtual void SetImpuestoAction() { }

        protected virtual void SetImpuestoDefectoAction() { }

        protected virtual void SetCuentaAsociadaAction() { }

        protected virtual void AddProductoAction() { }

        protected virtual void EditProductoAction() { }

        protected virtual void DeleteProductoAction() { }

        protected virtual void SetImpuestoProductoAction() { }

        #endregion

        #region Buttons

        private void Duplicar_BT_Click(object sender, EventArgs e)
        {
            DuplicarCapacidadActionForm form = new DuplicarCapacidadActionForm();
            form.SetSourceData(Entity);
            form.ShowDialog();

            RefreshSecondaryData();
        }

        private void Add_BT_Click(object sender, EventArgs e)
        {
            CapacidadActionForm form = new CapacidadActionForm();
            form.SetSourceData(Entity);
            form.ShowDialog();

            RefreshSecondaryData();
        }

        private void Impuesto_BT_Click(object sender, EventArgs e)
        {
            SetImpuestoAction();
        }

        private void Defecto_BT_Click(object sender, EventArgs e)
        {
            SetImpuestoDefectoAction();
        }

        private void CuentaAsociada_BT_Click(object sender, EventArgs e)
        {
            SetCuentaAsociadaAction();
        }

        #endregion

        #region Events

        private void Datos_DataSourceChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(ID_GB.Name);
            SetDependentControlSource(Perfil_GB.Name);
        }

        private void Ficha_TP_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFicha();
        }

        private void Submodulo_Instructor_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this is InstructorUIForm)
            {
                switch (Submodulo_Instructor_Grid.Columns[e.ColumnIndex].Name)
                {
                    case ("Modulo_CBC"):
                        {
                            if (Submodulo_Instructor_Grid["Modulo_CBC", e.RowIndex].Value != null)
                            {
                                if (Datos_Promociones.Current != null && ((Instructor_Promocion)Datos_Promociones.Current).OidPromocion > 0)
                                {
                                    //se está modificando una línea ya existente
                                    if (lista_sources.Count > e.RowIndex)
                                        lista_sources[e.RowIndex] = _combo_modulos.GetFilteredChilds((long)Submodulo_Instructor_Grid["Modulo_CBC", e.RowIndex].Value);
                                    else //hay que añadir un nuevo datasource a la lista
                                        lista_sources.Add(_combo_modulos.GetFilteredChilds((long)Submodulo_Instructor_Grid["Modulo_CBC", e.RowIndex].Value));
                                    ((DataGridViewComboBoxCell)(Submodulo_Instructor_Grid["Submodulo_CBC", e.RowIndex])).DataSource = lista_sources[e.RowIndex];
                                    ((Submodulo_Instructor_Promocion)Submodulo_Instructor_Grid.Rows[e.RowIndex].DataBoundItem).OidPromocion = ((Instructor_Promocion)Datos_Promociones.Current).OidPromocion;
                                }
                            }
                        }
                        break;
                    case ("Submodulo_CBC"):
                        {
                            if (Datos_Promociones.Current == null) return;

                            Instructor_Promocion selected = Entity.Promociones.GetItem(((Instructor_Promocion)Datos_Promociones.Current).Oid);

                            if (selected == null)
                            {
                                foreach (Instructor_Promocion item in Entity.Promociones)
                                {
                                    if (item.Oid == ((Instructor_Promocion)Datos_Promociones.Current).Oid)
                                    {
                                        selected = item;
                                        break;
                                    }
                                }
                            }

                            Submodulos_Instructores_Promociones lista = selected.Submodulos;


                            if (lista.Count <= e.RowIndex)
                                lista.Add((Submodulo_Instructor_Promocion)Submodulo_Instructor_Grid.Rows[e.RowIndex].DataBoundItem);

                            lista[e.RowIndex].OidInstructorPromocion = ((Instructor_Promocion)Datos_Promociones.Current).Oid;
                            lista[e.RowIndex].OidInstructor = Entity.Oid;
                        }
                        break;
                }
            }
        }

        protected void Submodulo_Instructor_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //No hace nada
        }
        
        private void Autorizados_Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this is InstructorUIForm)
            {
                switch (Autorizados_Grid.Columns[e.ColumnIndex].Name)
                {
                    case ("ModuloA_CBC"):
                        {
                            if (Autorizados_Grid["ModuloA_CBC", e.RowIndex].Value != null)
                            {
                                //se está modificando una línea ya existente
                                if (lista_sources_a.Count > e.RowIndex)
                                    lista_sources_a[e.RowIndex] = _combo_modulos.GetFilteredChilds((long)Autorizados_Grid["ModuloA_CBC", e.RowIndex].Value);
                                else //hay que añadir un nuevo datasource a la lista
                                    lista_sources_a.Add(_combo_modulos.GetFilteredChilds((long)Autorizados_Grid["ModuloA_CBC", e.RowIndex].Value));
                                ((DataGridViewComboBoxCell)(Autorizados_Grid["SubmoduloA_CBC", e.RowIndex])).DataSource = lista_sources_a[e.RowIndex];

                            }
                        }
                        break;
                    case ("SubmoduloA_CBC"):
                        {
                            Submodulos_Instructores lista = Entity.Submodulos;
                            if (lista.Count <= e.RowIndex)
                                lista.Add((Submodulo_Instructor)Autorizados_Grid.Rows[e.RowIndex].DataBoundItem);

                        }
                        break;
                }
            }
        }
        
        private void Autorizados_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this is InstructorViewForm) return;
            SetCellsDataSource(Autorizados_Grid.Name);
        }

        protected void Autorizados_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //No hace nada
        }
        
        private void Examinador_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (this is InstructorViewForm) return;
            if (Examinador_CB.Checked)
            {
                if (Entity.Perfil % 2 == 0)
                    Entity.Perfil += (long)moleQule.Library.Instruction.Perfil.Examinador;
            }
            else Entity.Perfil -= (long)moleQule.Library.Instruction.Perfil.Examinador;
        }

        private void Instructor_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (this is InstructorViewForm) return;
            if (Instructor_CB.Checked)
            {
                if ((Entity.Perfil >> 1) % 2 == 0)
                    Entity.Perfil += (long)moleQule.Library.Instruction.Perfil.Instructor;
            }
            else Entity.Perfil -= (long)moleQule.Library.Instruction.Perfil.Instructor;
        }

        private void RExamenes_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (this is InstructorViewForm) return;
            if (RExamenes_CB.Checked)
            {
                if ((Entity.Perfil >> 2) % 2 == 0)
                    Entity.Perfil += (long)moleQule.Library.Instruction.Perfil.RExamenes;
            }
            else Entity.Perfil -= (long)moleQule.Library.Instruction.Perfil.RExamenes;
        }

        private void Instructor_P_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (this is InstructorViewForm) return;
            if (Instructor_P_CB.Checked)
            {
                if ((Entity.Perfil >> 3) % 2 == 0)
                    Entity.Perfil += (long)moleQule.Library.Instruction.Perfil.InstPracticas;
            }
            else Entity.Perfil -= (long)moleQule.Library.Instruction.Perfil.InstPracticas;
        }

        private void Evaluador_P_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (this is InstructorViewForm) return;
            if (Evaluador_P_CB.Checked)
            {
                if ((Entity.Perfil >> 6) % 2 == 0)
                    Entity.Perfil += (long)moleQule.Library.Instruction.Perfil.EvalPracticas;
            }
            else Entity.Perfil -= (long)moleQule.Library.Instruction.Perfil.EvalPracticas;
        }

        private void Resp_Calidad_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (this is InstructorViewForm) return;
            if (Resp_Calidad_CB.Checked)
            {
                if ((Entity.Perfil >> 5) % 2 == 0)
                    Entity.Perfil += (long)moleQule.Library.Instruction.Perfil.RespCalidad;
            }
            else Entity.Perfil -= (long)moleQule.Library.Instruction.Perfil.RespCalidad;
        }

        private void RespInstruccion_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (this is InstructorViewForm) return;
            if (RespInstruccion_CB.Checked)
            {
                if (!Entity.HasProfile(moleQule.Library.Instruction.Perfil.RespInstruccion))
                    Entity.Perfil += (long)moleQule.Library.Instruction.Perfil.RespInstruccion;
            }
            else Entity.Perfil -= (long)moleQule.Library.Instruction.Perfil.RespInstruccion;
        }

        private void Gerente_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (this is InstructorViewForm) return;
            if (Gerente_CB.Checked)
            {
                if ((Entity.Perfil >> 8) % 2 == 0)
                    Entity.Perfil += (long)moleQule.Library.Instruction.Perfil.Gerente;
            }
            else Entity.Perfil -= (long)moleQule.Library.Instruction.Perfil.Gerente;
        }

        private void Administrador_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (this is InstructorViewForm) return;
            if (Administrador_CB.Checked)
            {
                if ((Entity.Perfil >> 9) % 2 == 0)
                    Entity.Perfil += (long)moleQule.Library.Instruction.Perfil.Administrador;
            }
            else Entity.Perfil -= (long)moleQule.Library.Instruction.Perfil.Administrador;
        }

        private void Auditor_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (this is InstructorViewForm) return;
            if (Auditor_CB.Checked)
            {
                if ((Entity.Perfil >> 7) % 2 == 0)
                    Entity.Perfil += (long)moleQule.Library.Instruction.Perfil.Auditor;
            }
            else Entity.Perfil -= (long)moleQule.Library.Instruction.Perfil.Auditor;
        }

        private void DNI_RB_CheckedChanged(object sender, EventArgs e)
        {
            ID_Label.Text = "12345678-X"; 
            if (this is InstructorViewForm) return;
            if (DNI_RB.Checked)
                Entity.TipoId = (long)TipoId.DNI;
            ValidateInput();
        }

        private void NIF_RB_CheckedChanged(object sender, EventArgs e)
        {
            ID_Label.Text = "12345678-X";
            if (this is InstructorViewForm) return;
            if (NIF_RB.Checked)
                Entity.TipoId = (long)TipoId.NIF;
            ValidateInput();
        }

        private void NIE_RB_CheckedChanged(object sender, EventArgs e)
        {
            ID_Label.Text = "X1234567Y";
            if (this is InstructorViewForm) return;
            if (NIE_RB.Checked)
                Entity.TipoId = (long)TipoId.NIE;
            ValidateInput();
        }

        private void Auto_RB_CheckedChanged(object sender, EventArgs e)
        {
            ID_Label.Text = "123456789";
            if (this is InstructorViewForm) return;
            if (Auto_RB.Checked)
                Entity.TipoId = (long)TipoId.OTROS;
            ValidateInput();
        }

        private void Promociones_Grid_CurrentCellChanged(object sender, EventArgs e)
        {
            lista_sources = new List<ComboBoxSourceList>();
            LoadChildsAction(typeof(Submodulo_Instructor_Promocion));
            RefreshSecondaryData();
        }

        private void CursosF_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void Promociones_Grid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void AddProducto_TI_Click(object sender, EventArgs e)
        {
            AddProductoAction();
        }

        private void EditProducto_TI_Click(object sender, EventArgs e)
        {
            EditProductoAction();
        }

        private void DeleteProducto_TI_Click(object sender, EventArgs e)
        {
            DeleteProductoAction();
        }

        private void Productos_DGW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Productos_DGW.CurrentRow == null) return;
            if (e.ColumnIndex == -1) return;

            if (Productos_DGW.Columns[e.ColumnIndex].Name == Impuesto.Name)
            {
                SetImpuestoProductoAction();
            }
        }

        private void Promociones_Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this is InstructorViewForm) return;
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex < 0) return;

            if (Promociones_Grid.Rows[e.RowIndex].IsNewRow) return;

            if (Promociones_Grid.Columns[e.ColumnIndex].Name == Promocion_CBC.Name)
            {
                if ((Promociones_Grid.Rows[e.RowIndex].DataBoundItem as Instructor_Promocion).Submodulos.Count > 0)
                    Promociones_Grid.Rows[e.RowIndex].ReadOnly = true;
                else
                    Promociones_Grid.Rows[e.ColumnIndex].ReadOnly = false;
            }
        }

        #endregion


    }
}


