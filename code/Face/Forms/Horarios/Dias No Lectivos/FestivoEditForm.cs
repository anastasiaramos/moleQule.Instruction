using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class FestivoEditForm : moleQule.Face.Instruction.FestivoUIForm
    {
        #region Factory Methods

        public FestivoEditForm(long oid, Form parent)
            : base(oid, parent)
		{
			InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFEdit;
        }

        public FestivoEditForm(Festivo item, Form parent)
            : base(item, parent)
        {
            InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFEdit;
        }

		public override void DisposeForm()
		{
			if (_entity != null && _entity.CloseSessions) _entity.CloseSession();

			base.DisposeForm();
		}

        protected override void GetFormSourceData(long oid, object[] parameters)
        {
            _entity = (Festivo)parameters[0];

            if (_entity == null)
            {
                _entity = Festivo.Get(oid, false);
                _entity.BeginEdit();
            }
        }

        #endregion

		#region Layout
        
		#endregion 

        #region Actions
        
        #endregion
    }
}
