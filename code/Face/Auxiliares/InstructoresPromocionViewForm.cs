using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class InstructoresPromocionViewForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return 14; } }

        public const string ID = "InstructoresPromocionViewForm";
        public static Type Type { get { return typeof(InstructoresPromocionViewForm); } }

        protected InstructorList _instructores = null;
        protected SortedBindingList<ModuloInfo> _modulos = null;
        protected SortedBindingList<SubmoduloInfo> _submodulos = null;
        protected SortedBindingList<PromocionInfo> _promociones = null;

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected Submodulo_Instructor_PromocionList _entity;

        public Submodulo_Instructor_PromocionList Entity { get { return _entity; } }

        /// <summary>
        /// Función recursiva que va creando el árbol de preguntas por submódulo
        /// </summary>
        /// <param name="padre"></param>
        /// <param name="apartado"></param>
        private void SetSubmodulosValues(TreeNode padre, SortedBindingList<ModuloInfo> modulos,
                                                SortedBindingList<SubmoduloInfo> submodulos, 
                                                InstructorList instructores,
                                                SortedBindingList<PromocionInfo> promociones)
        {
            SortedBindingList<Submodulo_Instructor_PromocionInfo> lista = Submodulo_Instructor_PromocionList.GetSortedList(_entity,
                                                                            "Prioridad", ListSortDirection.Ascending);
            if (padre == null)
            {
                while (Arbol_TV.Nodes.Count != 0)
                {
                    foreach (TreeNode t in Arbol_TV.Nodes)
                        Arbol_TV.Nodes.Remove(t);
                }
            }

            foreach (PromocionInfo item in _promociones)
            {
                TreeNode nodo = new TreeNode(item.Nombre);
                nodo.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
                nodo.ForeColor = System.Drawing.Color.Black;
                nodo.Tag = item;
                nodo.SelectedImageKey = "promocion";

                Arbol_TV.Nodes.Add(nodo);

                foreach (ModuloInfo mod in _modulos)
                {
                    TreeNode nodo_m = new TreeNode(mod.Codigo + " " + mod.Texto);
                    nodo_m.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
                    nodo_m.ForeColor = System.Drawing.Color.Black;
                    nodo_m.Tag = mod;
                    nodo_m.SelectedImageKey = "modulo";

                    nodo.Nodes.Add(nodo_m);

                    foreach (SubmoduloInfo sub in _submodulos)
                    {
                        if (sub.OidModulo == mod.Oid)
                        {
                            TreeNode nodo_s = new TreeNode(sub.Codigo + " " + sub.Texto);
                            nodo_s.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
                            nodo_s.ForeColor = System.Drawing.Color.Black;
                            nodo_s.Tag = sub;
                            nodo_s.SelectedImageKey = "submodulo";

                            nodo_m.Nodes.Add(nodo_s);

                            foreach(Submodulo_Instructor_PromocionInfo obj in lista)
                            {
                                if (obj.OidSubmodulo == sub.Oid && obj.OidPromocion == item.Oid)
                                {
                                    InstructorInfo instructor = _instructores.GetItem(obj.OidInstructor);

                                    if (instructor != null)
                                    {
                                        TreeNode nodo_i = new TreeNode(instructor.Apellidos + ", " + instructor.NombrePropio + " - " + obj.Prioridad.ToString());
                                        nodo_i.NodeFont = new Font("Tahoma", (float)8.25, FontStyle.Regular);
                                        nodo_i.ForeColor = System.Drawing.Color.Black;
                                        nodo_i.Tag = instructor;
                                        nodo_i.SelectedImageKey = "submodulo";

                                        nodo_s.Nodes.Add(nodo_i);
                                    }
                                }
                            }
                        } 
                    }
                    
                }
            }
        }

        #endregion

        #region Factory Methods

        public InstructoresPromocionViewForm() : this(-1, true, null) { }

        public InstructoresPromocionViewForm(bool isModal) : this(-1, isModal, null) { }

        public InstructoresPromocionViewForm(Form parent) : this(-1, true, parent) { }
        
        public InstructoresPromocionViewForm(long oid) : this(oid, true, null) { }

        public InstructoresPromocionViewForm(long oid, bool ismodal, Form parent)
            : base(oid, ismodal, parent)
        {
            InitializeComponent();

            _entity = Submodulo_Instructor_PromocionList.GetList();
            _mf_type = ManagerFormType.MFView;

            if (Entity != null)
            {
                SetFormData();
                this.Text = Resources.Labels.SUBMODULO_INSTRUCTOR_PROMOCION_VIEW_TITLE;
            }

            _mf_type = ManagerFormType.MFView;

            FormatControls();
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            Height = Parent.ClientRectangle.Height - Paneles2.Panel1.Height;
            Cancel_BT.Visible = false;
            Cancel_BT.Enabled = false;
        }


        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow();

            SetSubmodulosValues(null, _modulos, _submodulos, _instructores, _promociones);
            PgMng.FillUp("RefreshMain de InstructoresPromocionViewForm");
            //PgMng.ShowCronos();
        }


        public override void RefreshSecondaryData()
        {
            _instructores = InstructorList.GetList(false);
            PgMng.Grow();

            _modulos = ModuloList.GetSortedList("Codigo",ListSortDirection.Ascending);
            PgMng.Grow();

            _submodulos = SubmoduloList.GetSortedList("CodigoOrden", ListSortDirection.Ascending);
            PgMng.Grow();

            _promociones = PromocionList.GetSortedList("Numero", ListSortDirection.Ascending);
            PgMng.Grow();

        }

        #endregion

        #region Validation & Format

        #endregion


        #region Buttons

        private void Cerrar_BT_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        private void Aceptar_BT_Click(object sender, EventArgs e)
        {
            Cerrar();
        }

        protected override void SaveAction()
        {
            _action_result = DialogResult.Cancel;
            Cerrar();
        }

        #endregion

        #region Events

        private void PlantillaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        #endregion

    }
}


