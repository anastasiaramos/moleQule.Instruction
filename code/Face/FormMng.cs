using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using moleQule.Library;
using moleQule.Face;

using moleQule.Library.Instruction;

namespace moleQule.Face.Instruction
{
    /// <summary>
    /// Clase base para manejo (apertura y cierre) de formularios
    /// Es único en el sistema (singleton)
    /// </summary>
    /// <remarks>
    /// Para utilizar el FormMng es necesario indicar cual será el MainForm padre de los formularios
    /// Este MainForm deberá ser un formulario heredado de MainFormBase
    /// </remarks>
    public class FormMng : IFormMng
    {

        #region Factory Methods

        /// <summary>
        /// Única instancia de la clase (Singleton)
        /// </summary>
        protected static FormMng _main;

        /// <summary>
        /// Unique FormMng Class Instance
        /// </summary>
        /// <remarks>
        /// Para utilizar el FormMng es necesario inicializar
        /// </remarks>
        public static FormMng Instance { get { return (_main != null) ? _main : new FormMng(); } }

        /// <summary>
        /// Constructor
        /// </summary>
        public FormMng()
		{
			// Singleton
			_main = this;
		}

        #endregion

        #region Business Methods

        /// <summary>
        /// Abre un nuevo manager para la entidad. Si no está abierto, lo crea, y si 
        /// lo está, lo muestra 
        /// </summary>
        /// <param name="formID">Identificador del formulario que queremos abrir</param>
        public void OpenForm(string formID) { OpenForm(formID, null, null); }
        public void OpenForm(string formID, object param) { OpenForm(formID, new object[1] { param }); }
        public void OpenForm(string formID, object[] param) { OpenForm(formID, param, null); }

        /// <summary>
        /// Abre un nuevo manager para la entidad. Si no está abierto, lo crea, y si 
        /// lo está, lo muestra 
        /// </summary>
        /// <param name="formID">Identificador del formulario que queremos abrir</param>
        /// <param name="param">Parámetro para el formulario</param>
        public void OpenForm(string formID, object[] parameters, Form parent)
        {
            try
            {
                switch (formID)
                {
                    // FORMULARIOS GENERALES

                    case AlumnoMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(AlumnoMngForm.Type))
                            {
                                AlumnoMngForm em = new AlumnoMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case AlumnosAdmitidosExamenActionForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(AlumnosAdmitidosExamenActionForm.Type))
                            {
                                AlumnosAdmitidosExamenActionForm em = new AlumnosAdmitidosExamenActionForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case CronogramaMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(CronogramaMngForm.Type))
                            {
                                CronogramaMngForm em = new CronogramaMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case CursoMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(CursoMngForm.Type))
                            {
                                CursoMngForm em = new CursoMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case DiasNoLectivosForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(DiasNoLectivosForm.Type))
                            {
                                DiasNoLectivosForm em = new DiasNoLectivosForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        }
                        break;

                    case DisponibilidadAddForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(DisponibilidadAddForm.Type))
                            {
                                EntityMngForm mng = new EntityMngForm();
                                mng.AddForm(new DisponibilidadAddForm());
                            }
                        } break;

                    case ExamenMngForm.ID:
                        {
                            if (FormMngBase.Instance.BuscarFormulario(PreguntaMngForm.Type))
                            {
                                foreach (Form form in MainBaseForm.Instance.MdiChildren)
                                {
                                    if (form is PreguntaMngForm)
                                        form.Close();
                                }
                            }

                            if (!FormMngBase.Instance.BuscarFormulario(ExamenMngForm.Type))
                            {
                                ExamenMngForm em = new ExamenMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        }
                        break;

                    case FaltasAlumnosMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(FaltasAlumnosMngForm.Type))
                            {
                                FaltasAlumnosMngForm em = new FaltasAlumnosMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case RegistroFaltasAlumnosMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(RegistroFaltasAlumnosMngForm.Type))
                            {
                                RegistroFaltasAlumnosMngForm em = new RegistroFaltasAlumnosMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case NotasPracticasMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(NotasPracticasMngForm.Type))
                            {
                                long oid_promocion = 0;
                                PromocionSelectForm form = new PromocionSelectForm();
                                form.ShowDialog();
                                oid_promocion = (form.Selected as PromocionInfo).Oid;
                                if (oid_promocion > 0)
                                {
                                    NotasPracticasMngForm em = new NotasPracticasMngForm(oid_promocion, parent);
                                    FormMngBase.Instance.ShowFormulario(em);
                                }
                            }
                        } break;

                    case HorarioMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(HorarioMngForm.Type))
                            {
                                HorarioMngForm em = new HorarioMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case InstructorMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(InstructorMngForm.Type))
                            {
                                InstructorMngForm em = new InstructorMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case InstructoresPromocionViewForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(InstructoresPromocionViewForm.Type))
                            {
                                InstructoresPromocionViewForm em = new InstructoresPromocionViewForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case MaterialMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(MaterialMngForm.Type))
                            {
                                MaterialMngForm em = new MaterialMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case ModuloMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(ModuloMngForm.Type))
                            {
                                ModuloMngForm em = new ModuloMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case ParteAsistenciaMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(ParteAsistenciaMngForm.Type))
                            {
                                ParteAsistenciaMngForm em = new ParteAsistenciaMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case PlanEstudiosMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(PlanEstudiosMngForm.Type))
                            {
                                PlanEstudiosMngForm em = new PlanEstudiosMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case PlanExtraMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(PlanExtraMngForm.Type))
                            {
                                PlanExtraMngForm em = new PlanExtraMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case PreguntaMngForm.ID:
                        {
                            if (FormMngBase.Instance.BuscarFormulario(ExamenMngForm.Type))
                            {
                                foreach (Form form in MainBaseForm.Instance.MdiChildren)
                                {
                                    if (form is ExamenMngForm)
                                        form.Close();
                                }
                            }

                            if (!FormMngBase.Instance.BuscarFormulario(PreguntaMngForm.Type))
                            {
                                PreguntaMngForm em = new PreguntaMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case PromocionMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(PromocionMngForm.Type))
                            {
                                PromocionMngForm em = new PromocionMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                    case PlantillaMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(PlantillaMngForm.Type))
                            {
                                PlantillaMngForm em = new PlantillaMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;
                    case DuplicarPreguntasTemaActionForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(DuplicarPreguntasTemaActionForm.Type))
                            {
                                DuplicarPreguntasTemaActionForm em = new DuplicarPreguntasTemaActionForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;
                    case FormularioNotasPracticasMngForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(FormularioNotasPracticasMngForm.Type))
                            {
                                FormularioNotasPracticasMngForm em = new FormularioNotasPracticasMngForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;
                    case DisponibilidadSemanalForm.ID:
                        { 
                            if (!FormMngBase.Instance.BuscarFormulario(DisponibilidadSemanalForm.Type))
                            {
                                DisponibilidadSemanalForm em = new DisponibilidadSemanalForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }}break;

                   // FORMULARIOS DE INFORMES

                    case MatriculasActionForm.ID:
                        {
                            if (!FormMngBase.Instance.BuscarFormulario(MatriculasActionForm.Type))
                            {
                                MatriculasActionForm em = new MatriculasActionForm(parent);
                                FormMngBase.Instance.ShowFormulario(em);
                            }
                        } break;

                   default:
                        {
                            throw new iQImplementationException(string.Format(moleQule.Face.Resources.Messages.FORM_NOT_FOUND, formID), string.Empty);
                        } 
                }
            }
            catch (iQImplementationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(iQExceptionHandler.GetAllMessages(ex), Application.ProductName);
            }
        }

        /// <summary>
        /// Devuelve un formulario hijo del tipo pasado como parámetro
        /// </summary>
        /// <param name="childType">Tipo de formulario</param>
        public object GetFormulario(Type childType) { return FormMngBase.Instance.GetFormulario(childType); }

        #endregion

    }
}
