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
    public partial class RevisionForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 1; } }

        protected MaterialDocente _material = null;
        protected RevisionMaterial _entity;

        public RevisionMaterial Entity { get { return _entity; } set { _entity = value; } }
        public RevisionMaterialInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }


        #endregion

        #region Factory Methods

        public RevisionForm() : this(-1, true) { }

        public RevisionForm(bool isModal) : this(-1, isModal) { }

        public RevisionForm(long oid) : this(oid, true) { }

        public RevisionForm(long oid, bool ismodal)
            : base(oid, ismodal)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {

                this.Datos.RaiseListChangedEvents = false;

                RevisionMaterial temp = _entity.Clone();
                temp.ApplyEdit();

                // do the save
                try
                {
                    _entity = temp.Save();
                    _entity.ApplyEdit();

                    //Decomentar si se va a mantener en memoria
                    //_entity.BeginEdit();
                    return true;
                }
                catch (iQValidationException ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex) +
                                    Environment.NewLine + ex.SysMessage,
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(iQExceptionHandler.GetAllMessages(ex),
                                    moleQule.Library.Application.AppController.APP_TITLE,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                    return false;
                }
                finally
                {
                    this.Datos.RaiseListChangedEvents = true;
                }
            }
        }
        
        #endregion

        #region Style & Source

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow();

            base.RefreshMainData();
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected override void SaveAction()
        {
            if (_entity.Fecha.Date.Equals(DateTime.MinValue))
                _entity.Fecha = fechaDateTimePicker.Value;

            if (_material == null)
            {
                if (SaveObject())
                {
                    _action_result = DialogResult.OK;
                    Close();
                }
                else
                    _action_result = DialogResult.Ignore;
            }
            else
            {
                _action_result = DialogResult.OK;
                Close();
            }
        }

        protected override void CancelAction()
        {
            if (_material != null)
                _material.Revisiones.Remove(_entity);
            _action_result = DialogResult.Cancel;
            Close();
        }

        #endregion

        #region Events

        private void RevisionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_material == null) Entity.CloseSession();
            Cerrar();
        }

        #endregion

    }
}


