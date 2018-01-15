using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace moleQule.Face.Instruction
{
    public partial class SelectFechaDisponibilidadForm : moleQule.Face.Skin08.ActionSkinForm
    {
        public SelectFechaDisponibilidadForm()
        {
            InitializeComponent();
        }

        protected override void SubmitAction()
        {
            if (FechaDisponibilidad_DTP.Value.Date < DateTime.Today.AddYears(-5).Date
                || FechaDisponibilidad_DTP.Value.Date > DateTime.Today.AddYears(5).Date)
                FechaDisponibilidad_DTP.Value = DateTime.Today;
            this.DialogResult = DialogResult.OK;
            Close();
        }

        protected override void CancelAction()
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
