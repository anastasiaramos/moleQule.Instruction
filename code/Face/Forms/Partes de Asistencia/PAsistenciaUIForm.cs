using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Face;

using moleQule.Library.Instruction;
using moleQule.Library.Store;

namespace moleQule.Face.Instruction
{
    public partial class PAsistenciaUIForm : PAsistenciaForm
    {

        #region Business Methods

        protected override int BarSteps { get { return base.BarSteps + 4; } }

        /// <summary>
        /// Se trata del objeto actual y que se va a editar.
        /// </summary>
        protected ParteAsistencia _entity;

        public override ParteAsistencia Entity { get { return _entity; } set { _entity = value; } }
        public override ParteAsistenciaInfo EntityInfo { get { return (_entity != null) ? _entity.GetInfo(false) : null; } }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Declarado por exigencia del entorno. No Utilizar.
        /// </summary>
        protected PAsistenciaUIForm() : this(-1, true) { }

        public PAsistenciaUIForm(bool isModal) : this(-1, isModal) { }

        public PAsistenciaUIForm(long oid) : this(oid, true) { }

        public PAsistenciaUIForm(long oid, bool ismodal)
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

                ParteAsistencia temp = _entity.Clone();

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

            Hora_TB.Text = _entity.HoraInicio;
            Fecha_TB.Text = _entity.Fecha.ToShortDateString();
            Clase_TB.Text = _entity.Texto;

            base.RefreshMainData();
        }

        public override void RefreshSecondaryData()
        {
            HorarioList horarios = HorarioList.GetList(false);
            HorarioInfo horario = horarios.GetItem(_entity.OidHorario);

            Horario_TB.Text = "Desde " + horario.FechaInicial.ToShortDateString() 
                + " hasta " + horario.FechaFinal.ToShortDateString();
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
                            Alumno_Parte info = (Alumno_Parte)row.DataBoundItem;
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

        #endregion

        #region Validation & Format

      
        #endregion

        #region Actions

        protected override void SetInstructorEfectivo()
        {
            InstructorSelectForm form = new InstructorSelectForm(this);

            if (form.ShowDialog() == DialogResult.OK)
            {
                InstructorInfo instructor = form.Selected as InstructorInfo;
                _entity.OidInstructorEfectivo = instructor.Oid;
                ProfesorEfectivo_TB.Text = instructor.Nombre;
            }

            RefreshSources();

        }

        /// <summary>
        /// Implementa Save_button_Click
        /// </summary>
        protected override void SaveAction()
        {
            if (_entity.OidInstructorEfectivo == 0)
                _entity.OidInstructorEfectivo = _entity.OidInstructor;

            if (_entity.Confirmada)
            {
                if (!_entity.GeneraAlbaran())
                {
                    MessageBox.Show(Resources.Messages.ERROR_GENERACION_ALBARAN_INSTRUCTOR);
                    _action_result = DialogResult.Ignore;
                    return;
                }

            }

            _entity.UpdateAlumnosPracticas();

            _action_result = SaveObject() ? DialogResult.OK : DialogResult.Ignore;
        }

        #endregion

    }
}
