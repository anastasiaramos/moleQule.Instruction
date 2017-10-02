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
    public partial class ClasesPromocionSelectForm : ClasesPromocionMngForm
    {
        #region Factory Methods

        public ClasesPromocionSelectForm()
            : this(false, null) {}

        public ClasesPromocionSelectForm(Form parent)
            : this(false, parent) {}

        public ClasesPromocionSelectForm(bool isModal, Form parent)
             : this(isModal, parent, null, null, null) { }

        public ClasesPromocionSelectForm(bool isModal, Form parent, ClaseTeoricaList teoricas, ClasePracticaList practicas, ClaseExtraList extras)
            : base(isModal, parent, teoricas, practicas, extras)
        {
            InitializeComponent();
			_view_mode = molView.Select;

			_action_result = DialogResult.Cancel;
        }

        #endregion

        #region Actions

        protected override void DefaultAction() 
        {
			SelectAction();
        }

        public override void SelectAll()
        {
            Datos.MoveFirst();
            Datos.MoveLast();

            List<ClaseGenericaInfo> list = new List<ClaseGenericaInfo>();

            foreach (DataGridViewRow row in Tabla.Rows)
                list.Add(row.DataBoundItem as ClaseGenericaInfo);

            _selected = list;
            _action_result = list.Count > 0 ? DialogResult.OK : DialogResult.Cancel;
        }

        #endregion
    }
}
