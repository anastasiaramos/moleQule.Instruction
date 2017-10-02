using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class DateSelectForm : moleQule.Face.Skin08.ActionSkinForm
    {
        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 1; } }

        public const string ID = "DateSelectForm";
        public static Type Type { get { return typeof(DateSelectForm); } }

        protected PromocionInfo _promocion = null;
        protected DateTime _fecha = DateTime.Today;

        public DateTime Fecha { get { return _fecha; } set { _fecha = value; } }

        #endregion

        #region Factory Methods

        public DateSelectForm()
            : this(null, true, null) { }

        public DateSelectForm(PromocionInfo promo, bool IsModal, Form parent)
            : base(IsModal, parent)
        {
            _promocion = promo;
            InitializeComponent();
            SetFormData();
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();
            Fecha_DTP.MinDate = _promocion.FechaInicio;
            Fecha_DTP.MaxDate = DateTime.Today;
            Fecha_DTP.Visible = true;
            Fecha_DTP.BringToFront();
        }

        #endregion

        #region Buttons
        
        protected override void SubmitAction()
        {
            _action_result = DialogResult.OK;
        }

        #endregion

        #region Events

        private void Fecha_DTP_ValueChanged(object sender, EventArgs e)
        {
            _fecha = Fecha_DTP.Value;
        }

        #endregion
    }
}
