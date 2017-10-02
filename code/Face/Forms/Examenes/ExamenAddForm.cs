using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;
using moleQule.Face;

namespace moleQule.Face.Instruction
{
    public partial class ExamenAddForm : Skin01.ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 2; } }

        public PromocionList _promociones;
        protected bool _editable = true;

        protected Examen _entity;
        Dictionary<string, PromocionInfo> _promociones_select = new Dictionary<string, PromocionInfo>();
        Dictionary<string, PromocionInfo> _promociones_todas = new Dictionary<string, PromocionInfo>();
        Library.Instruction.HComboBoxSourceList _combo_tipo = null;

        public Examen Entity { get { return _entity; } set { _entity = value; } }
        public ExamenInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        #endregion

        #region Factory Methods

        public ExamenAddForm() : this(true) {}

        public ExamenAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();

            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.EXAMEN_ADD_TITLE;
        }

        public ExamenAddForm(Examen source)
            : base()
        {
            InitializeComponent();

			_entity = source.Clone();
            _entity.BeginEdit();
            _editable = false;
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.EXAMEN_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = Examen.New();
            _entity.BeginEdit();
        }

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            {

                this.Datos.RaiseListChangedEvents = false;

                Examen temp = _entity.Clone();
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

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            Modulo_BT.Enabled = _editable;    
        }

        public override void RefreshSecondaryData()
        {
            _promociones = PromocionList.GetList(false);
            Library.Instruction.HComboBoxSourceList _combo_promociones = new Library.Instruction.HComboBoxSourceList(_promociones);
            ComboBoxSource combo = new ComboBoxSource(-1, "ATCs");
            _combo_promociones.Add(combo);
            Datos_Promociones.DataSource = _combo_promociones;
            //PgMng.Grow(string.Empty, "Promociones");

            _combo_tipo = new Library.Instruction.HComboBoxSourceList();
            _combo_tipo.Add(new ComboBoxSource(0, ""));
            _combo_tipo.Add(new ComboBoxSource(1, "Finales"));
            _combo_tipo.Add(new ComboBoxSource(2, "Parciales"));
            Datos_Tipos.DataSource = _combo_tipo;
            //PgMng.Grow(string.Empty, "Tipos");
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            if (!_editable)
            {
                Promocion_CB.SelectedValue = _entity.OidPromocion;
                Tipo_CB.SelectedItem = _combo_tipo.Buscar(_entity.Tipo);

                foreach (ExamenPromocion item in _entity.Promociones)
                {
                    PromocionInfo info = _promociones.GetItem(item.OidPromocion);
                    _promociones_select.Add(info.Numero + " - " + info.Nombre, info);
                    Promociones_CLB.Items.Add(info.Numero + " - " + info.Nombre, true);
                }

            }
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            _entity.FechaCreacion = DateTime.Now;
            _entity.FechaEmision = DateTime.MaxValue;
            
            if (!FExamen_DTP.Checked) _entity.FechaExamen = DateTime.MaxValue;

            foreach (KeyValuePair<string, PromocionInfo> info in _promociones_select)
            {
                bool esta = false;
                foreach (ExamenPromocion expr in _entity.Promociones)
                {
                    if (expr.OidPromocion == info.Value.Oid)
                    { 
                        esta = true;
                        break;
                    }
                }
                if (!esta)
                {
                    ExamenPromocion item = _entity.Promociones.NewItem(_entity);
                    item.OidPromocion = info.Value.Oid;
                }
            }

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        private void Promocion_BT_Click(object sender, EventArgs e)
        {
            PromocionList lista_promociones = PromocionList.GetList(false);
            if (_promociones_todas.Count == 0)
            {
                foreach (PromocionInfo info in lista_promociones)
                    _promociones_todas.Add(info.Numero + " - " + info.Nombre, info);
            }
            PromocionSelectForm form = new PromocionSelectForm(this, lista_promociones);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                if (form.Selected is PromocionInfo)
                {
                    PromocionInfo info = form.Selected as PromocionInfo;

                    if (!_promociones_select.ContainsKey(info.Numero + " - " + info.Nombre))
                        _promociones_select.Add(info.Numero + " - " + info.Nombre, info);
                }
                else if (form.Selected is SortedBindingList<PromocionInfo>)
                {
                    SortedBindingList<PromocionInfo> promociones = form.Selected as SortedBindingList<PromocionInfo>;

                    foreach (PromocionInfo info in promociones)
                    {
                        if (!_promociones_select.ContainsKey(info.Numero + " - " + info.Nombre))
                            _promociones_select.Add(info.Numero + " - " + info.Nombre, info);
                    }
                }

                Promociones_CLB.Items.Clear();

                foreach (KeyValuePair<string, PromocionInfo> item in _promociones_select)
                    Promociones_CLB.Items.Add(item.Key, true);
            }
        }

        private void ClearPromociones_BT_Click(object sender, EventArgs e)
        {
            _promociones_select.Clear();
            Promociones_CLB.Items.Clear();
        }

        private void Promociones_CLB_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //PgMng.Reset(2, 1, Resources.Messages.LOADING_DATA);

            try
            {
                if (e.NewValue == CheckState.Unchecked)
                {
                    if (_promociones_select.ContainsKey(Promociones_CLB.Items[e.Index].ToString()))
                        _promociones_select.Remove(Promociones_CLB.Items[e.Index].ToString());
                    //PgMng.Grow();
                }
                else if (e.NewValue == CheckState.Checked)
                {
                    if (!_promociones_select.ContainsKey(Promociones_CLB.Items[e.Index].ToString()))
                        _promociones_select.Add(Promociones_CLB.Items[e.Index].ToString(), _promociones_todas[Promociones_CLB.Items[e.Index].ToString()]);
                    //PgMng.Grow();
                }
            }
            catch { }
            finally { //PgMng.FillUp(); 
            }

        }

        private void Modulo_BT_Click(object sender, EventArgs e)
        {
            ModuloList modulos = ModuloList.GetList(false);
            ModuloSelectForm form = new ModuloSelectForm(this, modulos);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                ModuloInfo modulo = form.Selected as ModuloInfo;
                _entity.OidModulo = modulo.Oid;
                _entity.Modulo = modulo.Texto;
                Modulo_TB.Text = modulo.Texto;
            }
        }

        private void Instructor_BT_Click(object sender, EventArgs e)
        {
            InstructorList instructores = InstructorList.GetList(false);
            InstructorSelectForm form = new InstructorSelectForm(this, instructores);

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                InstructorInfo instructor = form.Selected as InstructorInfo;
                _entity.OidProfesor = instructor.Oid;
                _entity.Instructor = instructor.Alias;
                Instructor_TB.Text = instructor.Alias;
            }
        }

        #endregion

        #region Events

        private void ExamenAddForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_entity != null && !_entity.SharedTransaction)
            {
                if (_entity.CloseSessions) Entity.CloseSession();
                //_entity = null;
            }
        }
        
        private void Promocion_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Promocion_CB.SelectedItem != null)
            {
                _entity.OidPromocion = ((ComboBoxSource)Promocion_CB.SelectedItem).Oid;
                _entity.Promocion = ((ComboBoxSource)Promocion_CB.SelectedItem).Texto;
            }
        }

        private void Tipo_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tipo_CB.SelectedItem != null)
                _entity.Tipo = ((ComboBoxSource)Tipo_CB.SelectedItem).Texto;
        }

        #endregion
        
    }
}


