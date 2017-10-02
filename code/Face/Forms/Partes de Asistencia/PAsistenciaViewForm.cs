using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;

using moleQule.Library.Instruction; 

namespace moleQule.Face.Instruction
{
    public partial class PAsistenciaViewForm : PAsistenciaForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 4; } }

        /// <summary>
        /// Se trata del objeto actual.
        /// </summary>
        private ParteAsistenciaInfo _entity;

        public override ParteAsistenciaInfo EntityInfo { get { return _entity; } }


        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar
        /// </summary>
        private PAsistenciaViewForm() : this(-1) { }

        public PAsistenciaViewForm(long oid)
            : base(oid)
        {
            InitializeComponent();
            SetFormData();
            this.Text = Resources.Labels.P_ASISTENCIA_EDIT_TITLE ;
            _mf_type = ManagerFormType.MFView;
        }

        protected override void GetFormSourceData(long oid)
        {
            _entity = ParteAsistenciaInfo.Get(oid, true);
            _mf_type = ManagerFormType.MFView;
        }

        #endregion

        #region Style & Source

        /// <summary>Formatea los Controles del formulario
        /// <returns>void</returns>
        /// </summary>
        public override void FormatControls()
        {
            SetReadOnlyControls(this.Controls);
            Cancel_BT.Enabled = false;
            Cancel_BT.Visible = false;
            base.FormatControls();
        }

        /// <summary>
        /// Asigna el objeto principal al origen de datos 
        /// <returns>void</returns>
        /// </summary>
        protected override void RefreshMainData()
        {
            Datos.DataSource = _entity;
            PgMng.Grow();

            Datos_Alumnos.DataSource = _entity.Alumno_Partes;
            PgMng.Grow();

            Clase_TB.Text = _entity.Texto;
            Hora_TB.Text = _entity.HoraInicio;
            Fecha_TB.Text = _entity.Fecha.ToShortDateString();

            base.RefreshMainData();
        }

        public override void RefreshSecondaryData()
        {
            HorarioList horarios = HorarioList.GetList(false);
            HorarioInfo horario = horarios.GetItem(_entity.OidHorario);

            Horario_TB.Text = "Desde " + horario.FechaInicial.ToShortDateString() + " hasta " + horario.FechaFinal.ToShortDateString();
            PgMng.Grow();

            base.RefreshSecondaryData();
        }

        /// <summary>
        /// Asigna los valores del grid que no están asociados a propiedades
        /// </summary>
        protected override void SetUnlinkedGridValues(string gridName)
        {
            switch (gridName)
            {
                case "Alumnos_Grid":
                    {
                        foreach (DataGridViewRow row in Alumnos_Grid.Rows)
                        {
                            if (row.IsNewRow) continue;
                            Alumno_ParteInfo info = (Alumno_ParteInfo)row.DataBoundItem;
                            if (info != null)
                            {
                                AlumnoInfo alumno = _alumnos.GetItem(info.OidAlumno);
                                if (alumno != null)
                                {
                                    row.Cells["Alumno"].Value = alumno.Apellidos + ", " + alumno.Nombre;
                                    row.Cells["Numero"].Value = alumno.NExpediente.ToString();
                                }
                            }
                        }

                    } break;
            }
        }

        /// <summary>
        #endregion

        #region Validation & Format

        #endregion

        #region Print

        #endregion

        #region Actions

        protected override void SaveAction() { _action_result = DialogResult.Cancel; }

        #endregion

        #region Events

        #endregion
    }

}
