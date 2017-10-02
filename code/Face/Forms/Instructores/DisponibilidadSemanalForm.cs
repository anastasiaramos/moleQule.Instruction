using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class DisponibilidadSemanalForm : moleQule.Face.Skin01.ItemMngSkinForm
    {
        #region Business Methods

        public const string ID = "DisponibilidadSemanalForm";
        public static Type Type { get { return typeof(DisponibilidadSemanalForm); } }

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private RegistroDisponibilidadList _entity;

        public RegistroDisponibilidadList EntityInfo { get { return _entity; } }
        
        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        public DisponibilidadSemanalForm() : this(true, null) { }

        public DisponibilidadSemanalForm(Form parent) : this(true, parent) { }

        public DisponibilidadSemanalForm(bool ismodal, Form parent)
            : base(-1, ismodal, parent)
        {
            InitializeComponent();
            SetFormData();
            _mf_type = ManagerFormType.MFEditList;
        }

        protected override void GetFormSourceData()
        {
            _mf_type = ManagerFormType.MFEditList;
            //DateTime fecha = DateTime.MaxValue;
            //while (fecha.DayOfWeek != DayOfWeek.Monday)
            //    fecha = fecha.AddDays(-1);
            //_entity = RegistroDisponibilidadList.GetList(fecha);
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            base.FormatControls();

            Siguiente_BT.Enabled = true;
            Anterior_BT.Enabled = true;
            Fecha_DTP.Enabled = true;

            List<string> visibles = new List<string>();

            visibles.Add(Nombre.Name);
            visibles.Add(Apellidos.Name);
            visibles.Add(Lunes.Name);
            visibles.Add(Martes.Name);
            visibles.Add(Miercoles.Name);
            visibles.Add(Jueves.Name);
            visibles.Add(Viernes.Name);
            visibles.Add(Sabado.Name);

            ControlTools.ShowDataGridColumns(Disponibilidades_Grid, visibles);

            VScrollBar vs = new VScrollBar();

            int rowWidth = (int)(Disponibilidades_Grid.Width - vs.Width
                                                - Disponibilidades_Grid.RowHeadersWidth
                                                - Disponibilidades_Grid.Columns[Nombre.Name].Width
                                                - Disponibilidades_Grid.Columns[Lunes.Name].Width
                                                - Disponibilidades_Grid.Columns[Martes.Name].Width
                                                - Disponibilidades_Grid.Columns[Miercoles.Name].Width
                                                - Disponibilidades_Grid.Columns[Jueves.Name].Width
                                                - Disponibilidades_Grid.Columns[Viernes.Name].Width
                                                - Disponibilidades_Grid.Columns[Sabado.Name].Width);

            Disponibilidades_Grid.Columns[Apellidos.Name].Width = (int)(rowWidth * 0.995);

            SetUnlinkedGridValues(Disponibilidades_Grid.Name);
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Fecha_DTP.Value = DateTime.Today;
            FechaFin_DTP.Value = Fecha_DTP.Value.AddDays(5);
            if (_entity != null) Datos.DataSource = _entity;
            
            PgMng.FillUp();
        }

        /// <summary>
        /// Asigna los datos de origen para controles que dependen de otros
        /// </summary>
        /// <param name="controlName"></param>
        protected override void SetDependentControlSource(string controlName)
        {
            try
            {
                switch (controlName)
                {
                    case "Fecha_DTP":
                        {
                            if (Fecha_DTP.Value.DayOfWeek != DayOfWeek.Monday)
                            {
                                DateTime fecha = Fecha_DTP.Value;
                                while (fecha.DayOfWeek != DayOfWeek.Monday)
                                    fecha = fecha.AddDays(-1);
                                Fecha_DTP.Value = fecha;
                                FechaFin_DTP.Value = Fecha_DTP.Value.AddDays(5);
                            }
                            else
                            {
                                _entity = RegistroDisponibilidadList.GetList(Fecha_DTP.Value, MostrarTodos_CB.Checked);
                                Datos.DataSource = _entity;
                            }

                        } break;
                }
            }
            finally
            {
                PgMng.FillUp();
            }
        }

        protected override void SetUnlinkedGridValues(string gridName)
        {
            try 
            {
                switch (gridName)
                {
                    case "Disponibilidades_Grid":
                        {
                            foreach (DataGridViewRow row in Disponibilidades_Grid.Rows)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.ColumnIndex == Disponibilidades_Grid.Columns["Lunes"].Index
                                        || cell.ColumnIndex == Disponibilidades_Grid.Columns["Martes"].Index
                                        || cell.ColumnIndex == Disponibilidades_Grid.Columns["Miercoles"].Index
                                        || cell.ColumnIndex == Disponibilidades_Grid.Columns["Jueves"].Index
                                        || cell.ColumnIndex == Disponibilidades_Grid.Columns["Viernes"].Index
                                        || cell.ColumnIndex == Disponibilidades_Grid.Columns["Sabado"].Index)
                                    {
                                        if (cell.Value.ToString() == moleQule.Library.Instruction.Resources.Defaults.DISPONIBILIDAD_DIA_VALUE)
                                            cell.Style.BackColor = Color.LightYellow;
                                        if (cell.Value.ToString() == moleQule.Library.Instruction.Resources.Defaults.DISPONIBILIDAD_TARDE_VALUE)
                                            cell.Style.BackColor = Color.LightGreen;
                                        if (cell.Value.ToString() == moleQule.Library.Instruction.Resources.Defaults.DISPONIBILIDAD_MANANA_VALUE)
                                            cell.Style.BackColor = Color.LightPink;
                                        if (cell.Value.ToString() == moleQule.Library.Instruction.Resources.Defaults.DISPONIBILIDAD_TARDE1_VALUE)
                                            cell.Style.BackColor = Color.LightBlue;
                                        if (cell.Value.ToString() == moleQule.Library.Instruction.Resources.Defaults.DISPONIBILIDAD_TARDE2_VALUE)
                                            cell.Style.BackColor = Color.LightSalmon;
                                        if (cell.Value.ToString() == moleQule.Library.Instruction.Resources.Defaults.NO_DISPONIBILIDAD_VALUE)
                                            cell.Style.BackColor = Color.Red;
                                    }
                                }
                            }
                            
                        }break;
                }
            }
            catch { }
        }

        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected override void SaveAction() { Close(); }

        #endregion

        #region Events
        
        private void Disponibilidades_Grid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                RegistroDisponibilidadInfo info = (RegistroDisponibilidadInfo)Disponibilidades_Grid.Rows[e.RowIndex].DataBoundItem;
                if (info != null)
                {
                    //int sessCode = Disponibilidad.OpenSession();
                    DisponibilidadEditForm edit_form = new DisponibilidadEditForm();
                    edit_form.SeleccionaInstructor(info.Oid, Fecha_DTP.Value);
                    edit_form.ShowDialog();
                    //nHManager.Instance.CloseSession(sessCode);

                    DateTime fecha = Fecha_DTP.Value;
                    while (fecha.DayOfWeek != DayOfWeek.Monday)
                        fecha = fecha.AddDays(-1);
                    _entity = RegistroDisponibilidadList.GetList(fecha, MostrarTodos_CB.Checked);
                    Datos.DataSource = _entity;
                }
            }
        }

        private void Fecha_DTP_ValueChanged(object sender, EventArgs e)
        {
            SetDependentControlSource(Fecha_DTP.Name);
        }

        private void Anterior_BT_Click(object sender, EventArgs e)
        {
            Fecha_DTP.Value = Fecha_DTP.Value.AddDays(-7);
            FechaFin_DTP.Value = Fecha_DTP.Value.AddDays(5);
        }

        private void Siguiente_BT_Click(object sender, EventArgs e)
        {
            Fecha_DTP.Value = Fecha_DTP.Value.AddDays(7);
            FechaFin_DTP.Value = Fecha_DTP.Value.AddDays(5);
        }

        private void Datos_DataSourceChanged(object sender, EventArgs e)
        {
            SetUnlinkedGridValues(Disponibilidades_Grid.Name);
        }

        private void MostrarTodos_CB_CheckedChanged(object sender, EventArgs e)
        {
            _entity = RegistroDisponibilidadList.GetList(Fecha_DTP.Value, MostrarTodos_CB.Checked);
            Datos.DataSource = _entity;
        }
        
        #endregion


    }
}
