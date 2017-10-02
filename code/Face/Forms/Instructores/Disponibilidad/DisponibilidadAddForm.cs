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
    public partial class DisponibilidadAddForm : DisponibilidadUIForm
    {

        #region Business Methods

        public const string ID = "DisponibilidadAddForm";
        public static Type Type { get { return typeof(DisponibilidadAddForm); } }

        #endregion

        #region Factory Methods

        public DisponibilidadAddForm() : this(true) {}

        public DisponibilidadAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.DISPONIBILIDAD_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            //_lista = Instructores.GetList();
        }

        #endregion

        #region Style & Source

        #endregion

        #region Validation & Format

        #endregion

        #region Buttons
       
        #endregion

        #region Events

        private void DisponibilidadAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        #endregion

    }
}

