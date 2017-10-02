using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Face;
using moleQule.Face.Skin01;

using molApp.Library;
using molApp.Library.Application;

namespace molApp.Face.Application
{
    public partial class MunicipioUIForm : ItemMngSkinForm
    {

        #region Business Methods

        public const string ID = "MunicipioUIForm";
        public static Type Type { get { return typeof(MunicipioUIForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private Municipios _municipios;

        public Municipios Municipios
        {
            get { return _municipios; }
            set { _municipios = value; }
        }

        #endregion

        #region Factory Methods

        public MunicipioUIForm()
            : this(true)
        {
        }

        public MunicipioUIForm(bool IsModal)
            : base(IsModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Modules.Instruction.Resources.Labels.MUNICIPIO_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _municipios = Municipios.GetList();
        }

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
                _municipios.Save();
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
        public override void FormatControls()
        {
            base.FormatControls();

            List<string> visibles = new List<string>();

            visibles.Add(CodPostal.Name);
            visibles.Add(Valor.Name);
            visibles.Add(Provincia.Name);

            ControlTools.ShowDataGridColumns(Datos_Grid, visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Datos_Grid.Width - vs.Width
                                                - Datos_Grid.RowHeadersWidth
                                                - Datos_Grid.Columns[CodPostal.Name].Width);

            Datos_Grid.Columns[Valor.Name].Width = (int)(rowWidth * 0.595);
            Datos_Grid.Columns[Provincia.Name].Width = (int)(rowWidth * 0.395);
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = Municipios.SortList(_municipios, "Valor", ListSortDirection.Ascending);
            Bar.FillUp();
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
                if (!IsModal) _municipios.CloseSession();
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
                _municipios.CancelEdit();
                _municipios.CloseSession();
            }
            Cerrar();
        }

        #endregion

        #region Events

        private void MunicipioUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _municipios.CancelEdit();
            _municipios.CloseSession();
        }

        #endregion

    }
}