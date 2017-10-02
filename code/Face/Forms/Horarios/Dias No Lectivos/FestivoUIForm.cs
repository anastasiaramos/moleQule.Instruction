using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Face.Common;
using moleQule.Face.Hipatia;
using moleQule.Library;
using moleQule.Library.Common;
using moleQule.Library.CslaEx;
using moleQule.Library.Hipatia;
using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    public partial class FestivoUIForm : moleQule.Face.Instruction.FestivoForm
    {
        #region Attributes & Properties

        protected override int BarSteps { get { return base.BarSteps + 2; } }

        /// <summary>
        /// Se trata de la Cliente actual y que se va a editar.
        /// </summary>
        protected Festivo _entity;

        public override Festivo Entity { get { return _entity; } set { _entity = value; } }
        public override FestivoInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo() : null; } }

        #endregion

        #region Factory Methods

        public FestivoUIForm()
            : this(-1, null) {}

        public FestivoUIForm(long oid, Form parent)
            : base(oid, parent)
        {
            InitializeComponent();
        }

        public FestivoUIForm(Festivo item, Form parent)
            : base(item.Oid, item, parent)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            this.Datos.RaiseListChangedEvents = false;

            Festivo temp = _entity.Clone();
            temp.ApplyEdit();

            // do the save
            try
            {
                _entity = temp.Save();
                _entity.ApplyEdit();

                return true;
            }
            finally
            {
                this.Datos.RaiseListChangedEvents = true;
            }
        }

        #endregion

        #region Source

        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow();

            //SelectTipoAction();

            base.RefreshMainData();
        }

        #endregion

        #region Actions

        protected override void SaveAction()
        {
            if (!Intervalo_CB.Checked)
                _entity.FechaFin = _entity.FechaInicio;

            if (_entity.FechaFin.Date < _entity.FechaInicio.Date)
            {
                MessageBox.Show("La fecha final debe ser mayor o igual que la  fecha inicial");
                return;
            }

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

		protected override void SelectTipoAction()
		{
			SelectEnumInputForm form = new SelectEnumInputForm(true);

			form.SetDataSource(Library.Instruction.EnumText<ETipoDiaNoLectivo>.GetList(false, false, false));
			
			if (form.ShowDialog(this) == DialogResult.OK)
			{
				ComboBoxSource tipo = form.Selected as ComboBoxSource;
				_entity.ETipo = (ETipoDiaNoLectivo)tipo.Oid;
				Tipo_TB.Text = _entity.TipoLabel;
			}
		}

        #endregion

        #region Buttons

        #endregion

		#region Events

		#endregion
    }
}
