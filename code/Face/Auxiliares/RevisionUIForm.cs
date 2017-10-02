using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Face.Skin01;

using molApp.Library;
using molApp.Library.Modules.Instruction;

namespace molApp.Face.Modules.Instruction
{
    public partial class RevisionUIForm : ItemMngSkinForm
    {

        #region Business Methods

        public const string ID = "RevisionUIForm";
        public static Type Type { get { return typeof(RevisionUIForm); } }

        /// <summary>
        /// Se trata del material actual y que se va a editar.
        /// </summary>
        private RevisionMaterials _revisiones;

        public RevisionMaterials Revisiones
        {
            get { return _revisiones; }
            set { _revisiones = value; }
        }

        #endregion

        #region Factory Methods

        public RevisionUIForm()
            : this(true)
        {
        }

        public RevisionUIForm(bool IsModal)
            : base(IsModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.REVISION_TITLE;
        }

        /*protected override void GetFormEntity()
        {
            _revisiones = RevisionMaterials.GetList();
        }*/

        /// <summary>
        /// Guarda en la bd el objeto actual
        /// </summary>
        protected override bool SaveObject()
        {
            //using (StatusBusy busy = new StatusBusy(moleQule.Face.Resources.Messages.SAVING))
            //{
            this.Datos.RaiseListChangedEvents = false; ;

            // do the save
            try
            {
                _revisiones.Save();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(moleQule.Face.Resources.Messages.OPERATION_ERROR + Environment.NewLine +
                                ex.Message,
                                Controler.APP_TITLE,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                return false;
            }
            finally
            {
                RefreshMainData();
                this.Datos.RaiseListChangedEvents = true;
            }
            //}
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        //public override void FormatControls()
        //{
        //    base.FormatControls();

        //    VScrollBar vs = new VScrollBar();

        //    int rowWidth = (int)(Datos_Grid.Width - vs.Width
        //                                            - Datos_Grid.RowHeadersWidth
        //                                            - Datos_Grid.Columns["CodPostal"].Width);

        //    Datos_Grid.Columns["Valor"].Width = (int)(rowWidth * 0.595);
        //    Datos_Grid.Columns["Provincia"].Width = (int)(rowWidth * 0.395);
        //}

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = RevisionMaterials.SortList(_municipios, "Valor", ListSortDirection.Ascending);
        }

        #endregion

        #region Buttons

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            if (SaveObject())
            {
                if (!IsModal) _revisiones.CloseSession();
                Cerrar();
            }
        }

        /// <summary>
        /// Implementa Undo_button_Click
        /// </summary>
        protected override void CancelAction()
        {
            if (!IsModal)
            {
                _revisiones.CancelEdit();
                _revisiones.CloseSession();
            }
            Cerrar();
        }

        #endregion

        #region Events

        private void RevisionUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _revisiones.CancelEdit();
            _revisiones.CloseSession();
        }

        #endregion

    }
}