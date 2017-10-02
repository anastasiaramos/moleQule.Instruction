using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;
using moleQule.Face.Skin01;

using moleQule.Library.Common;
using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PlantillaAddForm : ItemMngSkinForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 3; } }

        public ModuloList _modulos;

        protected PlantillaExamen _entity;
        private long _propuesto = 0;

        public PlantillaExamen Entity { get { return _entity; } set { _entity = value; } }
        public PlantillaExamenInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        #endregion

        #region Factory Methods

        public PlantillaAddForm() : this(true) {}

        public PlantillaAddForm(bool isModal)
            : base(isModal)
        {
            InitializeComponent();

            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.PLANTILLA_EXAMEN_ADD_TITLE;
        }

        public PlantillaAddForm(long oid_modulo, bool isModal)
            : base(isModal)
        {
            InitializeComponent();
            _propuesto = oid_modulo;

            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.PLANTILLA_EXAMEN_ADD_TITLE;
        }

        public PlantillaAddForm(PlantillaExamen source)
            : base()
        {
            InitializeComponent();

            _entity = source.Clone();
            _entity.BeginEdit();
            SetFormData();
            _mf_type = ManagerFormType.MFAdd;
            this.Text = Resources.Labels.PLANTILLA_EXAMEN_ADD_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _entity = PlantillaExamen.New();
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

                PlantillaExamen temp = _entity.Clone();
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
            
        }

        public override void RefreshSecondaryData()
        {
            if (_propuesto == 0)
            {
                _modulos = ModuloList.GetList(false);
                Library.Instruction.HComboBoxSourceList _combo_modulos = new Library.Instruction.HComboBoxSourceList(_modulos);
                Datos_Modulos.DataSource = _combo_modulos;
            }
            else
            {
                Library.Instruction.HComboBoxSourceList _combo_modulos = new Library.Instruction.HComboBoxSourceList();
                _combo_modulos.Add(new ComboBoxSource(_propuesto, ModuloInfo.Get(_propuesto, false).Texto));
                Datos_Modulos.DataSource = _combo_modulos;
                ((ComboBoxSource)Modulo_CB.SelectedItem).Oid = _propuesto;
                _entity.OidModulo = _propuesto;
                Modulo_CB.Enabled = false;
            }
            PgMng.Grow(string.Empty, "Modulos");

            //Library.Instruction.HComboBoxSourceList _combo_idiomas = new Library.Instruction.HComboBoxSourceList();
            //_combo_idiomas.Add(new ComboBoxSource(0, ""));
            //_combo_idiomas.Add(new ComboBoxSource(1, "Español"));
            //_combo_idiomas.Add(new ComboBoxSource(2, "Inglés"));
            Datos_Idiomas.DataSource = Library.Common.EnumText<EIdioma>.GetList(false);
            PgMng.Grow(string.Empty, "Idiomas");
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            _entity.Idioma = Library.Common.EnumText<EIdioma>.GetLabel(EIdioma.Todos);
            Datos.DataSource = _entity;
            PgMng.Grow();
        }


        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            //Antes de guardar se crean todos los registros de Pregunta_Plantilla necesarios para cada submódulo
            //del módulo asociado a la plantilla que se está creando, y se inicializan todos los números de 
            //preguntas a cero.
            ModuloInfo modulo = ModuloInfo.Get(Entity.OidModulo, false);
            _entity.Modulo = modulo.Texto;
            _entity.Preguntas = Preguntas_Plantillas.NewChildList();
            SubmoduloList submodulos = SubmoduloList.GetModuloList(Entity.OidModulo, false);
            TemaList temas = TemaList.GetModuloList(Entity.OidModulo, false);
            foreach (SubmoduloInfo submodulo in submodulos)
            {
                foreach (TemaInfo tema in temas)
                {
                    if (submodulo.Oid == tema.OidSubmodulo)
                    {
                        Preguntas_Plantilla preguntas = Preguntas_Plantilla.NewChild(Entity);
                        preguntas.OidSubmodulo = submodulo.Oid;
                        preguntas.OidTema = tema.Oid;
                        preguntas.NPreguntas = 0;
                        Entity.Preguntas.AddItem(preguntas);
                    }
                }
            }

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        #endregion

        #region Events
        
        private void Modulo_CB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Modulo_CB.SelectedItem != null)
                _entity.OidModulo = ((ComboBoxSource)Modulo_CB.SelectedItem).Oid;
        }
        
        #endregion

    }
}


