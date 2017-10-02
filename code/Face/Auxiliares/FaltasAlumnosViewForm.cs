using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Face.Skin01;
using moleQule.Face;

using molApp.Library.Modules.Instruction;

namespace molApp.Face.Modules.Instruction
{
    public partial class FaltasAlumnosViewForm : ItemMngSkinForm
    {

        #region Business Methods

        public const string ID = "FaltasAlumnosViewForm";
        public static Type Type { get { return typeof(FaltasAlumnosViewForm); } }

        /// <summary>
        /// Se trata de la empresa actual y que se va a editar.
        /// </summary>
        private List<FaltaAlumnoInfo> _alumnos;

        public List<FaltaAlumnoInfo> Alumnos
        {
            get { return _alumnos; }
            set { _alumnos = value; }
        }

        #endregion

        #region Factory Methods

        public FaltasAlumnosViewForm()
            : this(true)
        {
        }

        public FaltasAlumnosViewForm(bool IsModal)
            : base(IsModal)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.FALTAS_ALUMNOS_VIEW_TITLE;
        }

        protected override void GetFormSourceData()
        {
            _alumnos = FaltaAlumnoInfo.GetEstadisticasFaltasAlumnos();
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            Cancelar_Button.Enabled = false;
            Cancelar_Button.Visible = false;
            Imprimir_Button.Enabled = false;
            Imprimir_Button.Visible = false;
            base.FormatControls();

            List<string> visibles = new List<string>();

            visibles.Add(Promocion.Name);
            visibles.Add(NExpediente.Name);
            visibles.Add(Codigo.Name);
            visibles.Add(Nombre.Name);
            visibles.Add(Apellidos.Name);
            visibles.Add(Duracion.Name);
            visibles.Add(Modulo.Name);
            visibles.Add(TotalClases.Name);
            visibles.Add(Porcentaje.Name);

            ControlTools.ShowDataGridColumns(Alumnos_Grid, visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Alumnos_Grid.Width - vs.Width
                                                - Alumnos_Grid.RowHeadersWidth
                                                - Alumnos_Grid.Columns[Promocion.Name].Width
                                                - Alumnos_Grid.Columns[NExpediente.Name].Width
                                                - Alumnos_Grid.Columns[Codigo.Name].Width
                                                - Alumnos_Grid.Columns[Duracion.Name].Width
                                                - Alumnos_Grid.Columns[TotalClases.Name].Width
                                                - Alumnos_Grid.Columns[Porcentaje.Name].Width);

            Alumnos_Grid.Columns[Modulo.Name].Width = (int)(rowWidth * 0.495);
            Alumnos_Grid.Columns[Nombre.Name].Width = (int)(rowWidth * 0.195);
            Alumnos_Grid.Columns[Apellidos.Name].Width = (int)(rowWidth * 0.295);
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            if (_alumnos.Count > 0)
                Datos.DataSource = _alumnos;
            Bar.FillUp();
        }

        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Alumnos_Grid":
                    {
                        foreach (DataGridViewRow row in Alumnos_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            FaltaAlumnoInfo info = (FaltaAlumnoInfo)row.DataBoundItem;
                            if (info != null)
                            {
                                if (info.Porcentaje >= 15)
                                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                                else
                                {
                                    if (info.Porcentaje >= 10)
                                        row.DefaultCellStyle.BackColor = Color.LightSalmon;
                                    else
                                    {
                                        if (info.Porcentaje >= 5)
                                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                                    }
                                }
                            }
                        }
                    } break;
            }
        }

        #endregion

        #region Buttons

        protected override void SaveAction()
        {
            Close();
        }

        #endregion
        
        #region Events

        private void FaltasAlumnosViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cerrar();
        }

        private void Alumnos_Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SetUnlinkedGridValues(Alumnos_Grid.Name);
        }

        #endregion


    }
}