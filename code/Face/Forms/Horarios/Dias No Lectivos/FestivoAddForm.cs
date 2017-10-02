using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class FestivoAddForm : moleQule.Face.Instruction.FestivoUIForm
    {
        #region Factory Methods

        public FestivoAddForm(Form parent) 
			: base(-1, parent)
        {
            InitializeComponent();
			SetFormData();
            _mf_type = ManagerFormType.MFAdd;
		}

		protected override void GetFormSourceData(object[] parameters)
		{
			_entity = Festivo.New();
			_entity.BeginEdit();
		}

		#endregion
    }
}
