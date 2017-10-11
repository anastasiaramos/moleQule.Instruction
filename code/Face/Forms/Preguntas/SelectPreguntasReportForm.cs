using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library;

namespace moleQule.Face.Instruction
{
    public partial class SelectPreguntasReportForm : moleQule.Face.Skin02.PrintSelectSkinForm
    {
        public SelectPreguntasReportForm()
        {
            InitializeComponent();
        }

        #region Actions

        protected override void SubmitAction()
        {
            _source = Seleccion_RB.Checked ? PrintSource.Selection : PrintSource.All;
            this.Close();
            DialogResult = DialogResult.OK;
        }

        #endregion
    }
}
