using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;

using moleQule.Library.CslaEx;
using moleQule.Library;
using moleQule.Library.Instruction.Properties;
using moleQule.Library.Instruction.Resources;

namespace moleQule.Library.Instruction
{

	[Serializable()]
	public class ModuleController
	{
		#region Attributes & Properties

		#endregion

		#region Factory Methods

		/// <summary>
		/// Única instancia de la clase ControlerBase (Singleton)
		/// </summary>
		protected static ModuleController _main;

		/// <summary>
		/// Unique Controler Class Instance
		/// </summary>
		public static ModuleController Instance { get { return (_main != null) ? _main : new ModuleController(); } }

		/// <summary>
		/// Contructor 
		/// </summary>
		protected ModuleController()
		{
			// Singleton
			_main = this;

			Init();
		}

		private void Init()
		{
		}

        public static void CheckDBVersion()
        {
            ApplicationSettingInfo dbVersion = ApplicationSettingInfo.Get(Settings.Default.DB_VERSION_VARIABLE);

            //Version de base de datos equivalente o no existe la variable
            if ((dbVersion.Value == string.Empty) ||
                (String.CompareOrdinal(dbVersion.Value, ModulePrincipal.GetDBVersion()) == 0))
            {
                return;
            }
            //Version de base de datos superior
            else if (String.CompareOrdinal(dbVersion.Value, ModulePrincipal.GetDBVersion()) > 0)
            {
                throw new iQException(String.Format(Library.Resources.Messages.DB_VERSION_HIGHER,
                                                    dbVersion.Value,
                                                    ModulePrincipal.GetDBVersion(),
                                                    Settings.Default.NAME),
                                                    iQExceptionCode.DB_VERSION_MISSMATCH);
            }
            //Version de base de datos inferior
            else if (String.CompareOrdinal(dbVersion.Value, ModulePrincipal.GetDBVersion()) < 0)
            {
                throw new iQException(String.Format(Library.Resources.Messages.DB_VERSION_LOWER,
                                                    dbVersion.Value,
                                                    ModulePrincipal.GetDBVersion(),
                                                    Settings.Default.NAME),
                                                    iQExceptionCode.DB_VERSION_MISSMATCH);
            }
        }
        
        public static void UpgradeSettings() { ModulePrincipal.UpgradeSettings(); }

        #endregion

        #region Paths
        
        //INSTRUCTION
        public static string FOTOS_INSTRUCTORES_PATH { get { return AppControllerBase.Reg32GetServerPath() + Paths.RESOURCES_ROOT + Paths.FOTO_INSTRUCTORES; } }
        public static string FOTOS_ALUMNOS_PATH { get { return AppControllerBase.Reg32GetServerPath() + Paths.RESOURCES_ROOT + Paths.FOTO_ALUMNOS; } }
        public static string FOTOS_PREGUNTAS_PATH { get { return AppControllerBase.Reg32GetServerPath() + Paths.RESOURCES_ROOT + Paths.FOTO_PREGUNTAS; } }
        public static string FOTOS_PREGUNTAS_EXAMEN_PATH { get { return AppControllerBase.Reg32GetServerPath() + Paths.RESOURCES_ROOT + Paths.FOTO_PREGUNTAS_EXAMENES; } }
        public static string MODELO_PREGUNTAS_PATH { get { return AppControllerBase.Reg32GetServerPath() + Paths.RESOURCES_ROOT + Paths.MODELO_PREGUNTAS; } }
        public static string MODELO_PREGUNTAS_EXAMEN_PATH { get { return AppControllerBase.Reg32GetServerPath() + Paths.RESOURCES_ROOT + Paths.MODELO_PREGUNTAS_EXAMENES; } }
       
        #endregion

		#region Variables

        #endregion

        #region Business Methods

        public void AutoPilot()
        {
            //ShowApuntesPendientes();
        }

        #endregion

		#region Variables

		#endregion
	}

    public class ModuleDef : IModuleDef
    {
        public string Name { get { return "Instruction"; } }
        public Type Type { get { return typeof(Library.Instruction.ModuleController); } }
        public Type[] Mappings
        {
            get
            {
                return new Type[] 
                {   
					typeof(AlumnoMap),
					typeof(AlumnoClienteMap),
					typeof(AlumnoConvocatoriaMap),
					typeof(AlumnoCursoMap),
					typeof(AlumnoExamenMap),
					typeof(AlumnoParteMap),
					typeof(AlumnoPracticaMap),
					typeof(AlumnoPromocionMap),
					typeof(Clase_ParteMap),
					typeof(ClaseExtraMap),
					typeof(ClasePracticaMap),
					typeof(ClaseTeoricaMap),
                    typeof(Concepto_ParteMap),
					typeof(Convocatoria_CursoMap),
					typeof(CronogramaMap),
					typeof(CursoMap),
					typeof(Curso_InstructorMap),
                    typeof(CursoFormacionMap),
					typeof(DisponibilidadMap),
					typeof(ExamenMap),
                    typeof(ExamenPromocionMap),
                    typeof(FestivoMap),
					typeof(HistoriaMap),
					typeof(HorarioMap),
                    typeof(IncidenciaCronogramaMap),
                    typeof(IncidenciaSesionCronogramaMap),
					typeof(InstructorMap),
					typeof(Instructor_PromocionMap),
					typeof(Material_AlumnoMap),
					typeof(Material_PlanMap),
                    typeof(MaterialDocenteMap),
                    typeof(ModuloMap),
					typeof(ParteAsistenciaMap),
					typeof(PlanEstudiosMap),
                    typeof(PlanExtraMap),
					typeof(PlantillaExamenMap),
					typeof(PreguntaMap),
					typeof(Pregunta_ExamenMap),
					typeof(PreguntaExamenMap),
					typeof(Preguntas_PlantillaMap),
					typeof(PromocionMap),
					typeof(RespuestaMap),
					typeof(Respuesta_Alumno_ExamenMap),
					typeof(RespuestaExamenMap),
					typeof(RevisionMaterialMap),
					typeof(SesionMap),
					typeof(Sesion_PromocionMap),
                    typeof(SesionCronogramaMap),
                    typeof(SubmoduloMap),
                    typeof(Submodulo_InstructorMap),
                    typeof(Submodulo_Instructor_PromocionMap),
                    typeof(TemaMap)
                };
            }
        }

        public void GetEntities(Dictionary<Type, Type> recordEntities)
        {
            if (recordEntities.ContainsKey(typeof(Alumno))) return;

            recordEntities.Add(typeof(Alumno), typeof(AlumnoRecord));
            recordEntities.Add(typeof(AlumnoCliente), typeof(AlumnoClienteRecord));
            recordEntities.Add(typeof(Alumno_Convocatoria), typeof(AlumnoConvocatoriaRecord));
            recordEntities.Add(typeof(AlumnoCurso), typeof(AlumnoCursoRecord));
            recordEntities.Add(typeof(Alumno_Examen), typeof(AlumnoExamenRecord));
            recordEntities.Add(typeof(Alumno_Parte), typeof(AlumnoParteRecord));
            recordEntities.Add(typeof(Alumno_Practica), typeof(AlumnoPracticaRecord));
            recordEntities.Add(typeof(Alumno_Promocion), typeof(AlumnoPromocionRecord));
            recordEntities.Add(typeof(Clase_Parte), typeof(Clase_ParteRecord));
            recordEntities.Add(typeof(ClaseExtra), typeof(ClaseExtraRecord));
            recordEntities.Add(typeof(ClasePractica), typeof(ClasePracticaRecord));
            recordEntities.Add(typeof(ClaseTeorica), typeof(ClaseTeoricaRecord));
            recordEntities.Add(typeof(Concepto_Parte), typeof(Concepto_ParteRecord));
            recordEntities.Add(typeof(Convocatoria_Curso), typeof(Convocatoria_CursoRecord));
            recordEntities.Add(typeof(Cronograma), typeof(CronogramaRecord));
            recordEntities.Add(typeof(Curso), typeof(CursoRecord));
            recordEntities.Add(typeof(Curso_Instructor), typeof(Curso_InstructorRecord));
            recordEntities.Add(typeof(CursoFormacion), typeof(CursoFormacionRecord));
            recordEntities.Add(typeof(Disponibilidad), typeof(DisponibilidadRecord));
            recordEntities.Add(typeof(Examen), typeof(ExamenRecord));
            recordEntities.Add(typeof(ExamenPromocion), typeof(ExamenPromocionRecord));
            recordEntities.Add(typeof(Festivo), typeof(FestivoRecord));
            recordEntities.Add(typeof(Historia), typeof(HistoriaRecord));
            recordEntities.Add(typeof(Horario), typeof(HorarioRecord));
            recordEntities.Add(typeof(IncidenciaCronograma), typeof(IncidenciaCronogramaRecord));
            recordEntities.Add(typeof(IncidenciaSesionCronograma), typeof(IncidenciaSesionCronogramaRecord));
            recordEntities.Add(typeof(Instructor), typeof(InstructorRecord));
            recordEntities.Add(typeof(Instructor_Promocion), typeof(Instructor_PromocionRecord));
            recordEntities.Add(typeof(Material_Alumno), typeof(Material_AlumnoRecord));
            recordEntities.Add(typeof(Material_Plan), typeof(Material_PlanRecord));
            recordEntities.Add(typeof(MaterialDocente), typeof(MaterialDocenteRecord));
            recordEntities.Add(typeof(Modulo), typeof(ModuloRecord));
            recordEntities.Add(typeof(ParteAsistencia), typeof(ParteAsistenciaRecord));
            recordEntities.Add(typeof(PlanEstudios), typeof(PlanEstudiosRecord));
            recordEntities.Add(typeof(PlanExtra), typeof(PlanExtraRecord));
            recordEntities.Add(typeof(PlantillaExamen), typeof(PlantillaExamenRecord));
            recordEntities.Add(typeof(Pregunta), typeof(PreguntaRecord));
            recordEntities.Add(typeof(Pregunta_Examen), typeof(Pregunta_ExamenRecord));
            recordEntities.Add(typeof(PreguntaExamen), typeof(PreguntaExamenRecord));
            recordEntities.Add(typeof(Preguntas_Plantilla), typeof(Preguntas_PlantillaRecord));
            recordEntities.Add(typeof(Promocion), typeof(PromocionRecord));
            recordEntities.Add(typeof(Respuesta), typeof(RespuestaRecord));
            recordEntities.Add(typeof(Respuesta_Alumno_Examen), typeof(Respuesta_Alumno_ExamenRecord));
            recordEntities.Add(typeof(RespuestaExamen), typeof(RespuestaExamenRecord));
            recordEntities.Add(typeof(RevisionMaterial), typeof(RevisionMaterialRecord));
            recordEntities.Add(typeof(Sesion), typeof(SesionRecord));
            recordEntities.Add(typeof(Sesion_Promocion), typeof(Sesion_PromocionRecord));
            recordEntities.Add(typeof(SesionCronograma), typeof(SesionCronogramaRecord));
            recordEntities.Add(typeof(Submodulo), typeof(SubmoduloRecord));
            recordEntities.Add(typeof(Submodulo_Instructor), typeof(Submodulo_InstructorRecord));
            recordEntities.Add(typeof(Submodulo_Instructor_Promocion), typeof(Submodulo_Instructor_PromocionRecord));
            recordEntities.Add(typeof(Tema), typeof(TemaRecord));
        }
    }
}
