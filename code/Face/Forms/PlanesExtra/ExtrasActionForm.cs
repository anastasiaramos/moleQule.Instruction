using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class ExtrasActionForm : ActionSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 2; } }

        public const string ID = "ExtrasActionForm";
        public static Type Type { get { return typeof(ExtrasActionForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private PlanExtra _entity;

        public PlanExtra Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }
        
        protected Library.Instruction.HComboBoxSourceList _combo_modulos;
        protected Library.Instruction.HComboBoxSourceList _combo_submodulos;

        #endregion

        #region Factory Methods

        public ExtrasActionForm()
            : this(true) { }

        public ExtrasActionForm(bool IsModal)
            : base(IsModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.EXTRAS_TITLE;
        }

        public void SetSourceData(PlanExtra item)
        {
            _entity = item;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
        }

        public override void RefreshSecondaryData()
        {
            ModuloList modulos = ModuloList.GetList(false);
            _combo_modulos = new Library.Instruction.HComboBoxSourceList(modulos);

            Datos_Modulos.DataSource = _combo_modulos;
            PgMng.Grow();

            SubmoduloList submodulos = SubmoduloList.GetList(false);
            _combo_submodulos = new Library.Instruction.HComboBoxSourceList(submodulos);
            _combo_modulos.Childs = _combo_submodulos;
            PgMng.Grow();

            Datos_Submodulos.DataSource = _combo_submodulos;
        }

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected void SetDependentControlSource(string controlName)
        {
            switch (controlName)
            {
                case "Modulo_CB":
                    {
                        if (Datos_Modulos.Current != null)
                            Datos_Submodulos.DataSource = _combo_modulos.GetFilteredChilds(((ComboBoxSource)Modulo_CB.SelectedItem).Oid);

                    } break;
            }
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SubmitAction()
        {
            if (((ComboBoxSource)Modulo_CB.SelectedItem).Oid == 0
                || ((ComboBoxSource)Submodulo_CB.SelectedItem).Oid == 0)
            {
                MessageBox.Show("Debe seleccionar un módulo y submódulo válidos");
                return;
            }

            ModuloInfo modulo = ModuloInfo.Get(((ComboBoxSource)Modulo_CB.SelectedItem).Oid);
            SubmoduloInfo submodulo = SubmoduloInfo.Get(((ComboBoxSource)Submodulo_CB.SelectedItem).Oid);

            ClaseExtra.OpenSession();

            for (int i = 1; i <= (int)Clases_NUD.Value; i++)
            {
                ClaseExtra clase = ClaseExtra.NewChild(_entity);
                clase.MarkItemNew();

                clase.OidModulo = modulo.Oid;
                clase.Modulo = modulo.Texto;
                clase.OidSubmodulo = submodulo.Oid;
                clase.Submodulo = submodulo.Codigo;
                clase.Orden = (long)i;
                int index = submodulo.Codigo.IndexOf(".");
                if (submodulo.Codigo.Length > 5)
                    clase.Alias = submodulo.Codigo.Substring(0, 5);
                else
                    clase.Alias = submodulo.Codigo;
                clase.Alias += "(" + i.ToString() + "/" + Clases_NUD.Value.ToString() + ")";
                clase.Titulo = modulo.Texto + " " + submodulo.Codigo;
                clase.TotalClases = (long)Clases_NUD.Value;

                _entity.CExtras.AddItem(clase);
            }

            _action_result = DialogResult.OK;
            Close();

        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            if (!IsModal)
                _entity.CancelEdit();
            _action_result = DialogResult.Cancel;

            Cerrar();
        }

        #endregion

        #region Events

        private void ExtrasActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Esta función solo se llama si se le da a la X o
            // se el formulario es modal
            if (!this.IsModal)
            {
                e.Cancel = true;
                Entity.CancelEdit();
            }

            Cerrar();

        }


        private void Modulo_CB_SelectedValueChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Modulo_CB.Name);
        }

        #endregion


    }
}

