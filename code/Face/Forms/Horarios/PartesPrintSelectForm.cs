using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PartesPrintSelectForm : moleQule.Face.Skin02.PrintSelectSkinForm
    {
        
		#region Business Methods

        private bool _print_timestamp = false;
        private DateTime _timestamp = DateTime.Now;

        public bool PrintTimestamp { get { return _print_timestamp; } set { _print_timestamp = value; } }
        public DateTime Timestamp { get { return _timestamp; } set { _timestamp = value; } }
        
		#endregion

		#region Factory Methods

		public PartesPrintSelectForm(PrintSource seleccion) : this(true, seleccion) {}

        public PartesPrintSelectForm(bool isModal, PrintSource seleccion)
			: base(isModal)
		{
			InitializeComponent();
            _source = seleccion;
		}

		#endregion

		#region Buttons

		#endregion

        #region Actions

        protected override void SubmitAction() 
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        #endregion

        #region Events

        private void Source_GB_Validated(object sender, EventArgs e)
		{
			_source = Seleccion_RB.Checked ? PrintSource.Selection : PrintSource.All;
		}

		#endregion
    }
}

