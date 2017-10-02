using System;
using System.Collections.Generic;
using System.Resources;

using moleQule.Library;
using moleQule.Library.Common;

namespace moleQule.Library.Instruction
{
    #region Querys

    public class QueryConditions : moleQule.Library.QueryConditions
    {
        public long Oid = 0;
        public ETipoEntidad EntityType = ETipoEntidad.Todos;
        public EEstado[] Status = null;
        
        public BankAccountInfo CuentaBancaria = null;
        public Modelo Modelo = null;
        public CreditCardInfo TarjetaCredito = null;
        public UserInfo Usuario = null;

        public EEstado Estado = EEstado.Todos;
        public Common.EMedioPago MedioPago = Common.EMedioPago.Todos;
        public EModelo EModelo = EModelo.Modelo111;

        public List<EMedioPago> MedioPagoList = null;

        public ESesionPromocion ESesionPromocion = ESesionPromocion.Todos;

        public AlumnoInfo Alumno = null;
        public Alumno_ExamenInfo Alumno_Examen = null;
        public ClaseExtraInfo ClaseExtra = null;
        public ClasePracticaInfo ClasePractica = null;
        public ClaseTeoricaInfo ClaseTeorica = null;
        public Convocatoria_CursoInfo Convocatoria_Curso = null;
        public CronogramaInfo Cronograma = null;
        public CursoInfo Curso = null;
        public ExamenInfo Examen = null;
        public ExamenPromocionInfo ExamenPromocion = null;
        public FestivoInfo Festivo = null;
        public InstructorInfo Instructor = null;
        public MaterialDocenteInfo MaterialDocente = null;
        public ModuloInfo Modulo = null;
        public ParteAsistenciaInfo ParteAsistencia = null;
        public PlanEstudiosInfo PlanEstudios = null;
        public PlantillaExamenInfo PlantillaExamen = null;
        public PromocionInfo Promocion = null;
        public RevisionMaterialInfo RevisionMaterial = null;
        public SubmoduloInfo Submodulo = null;

        public static Common.QueryConditions ConvertToCommonQuery(Store.QueryConditions conditions)
        {
            Common.QueryConditions conds = new Common.QueryConditions
            {
                Oid = conditions.Oid,
                EntityType = conditions.EntityType,
                Status = conditions.Status,

                FechaIni = conditions.FechaIni,
                FechaFin = conditions.FechaFin,
                FechaAuxIni = conditions.FechaAuxIni,
                FechaAuxFin = conditions.FechaAuxFin,
                Estado = conditions.Estado
            };

            return conds;
        }
    }

    public delegate string SelectCaller(QueryConditions conditions);

    #endregion

    #region Enums

    public enum Grupo { SinGrupo = 0, A = 1, B = 2 }

    public enum EDocumentoAlumno { Matricula = 1, Material = 2, Documentacion = 3 }    

    public enum ETipoPregunta { Test = 1 , Desarrollo = 2 }

    public enum ETipoExamen { Final = 1, Parcial = 2 }

    public enum ETipoImpresionCronograma { Lista = 1, Horario = 2 }

    public enum ETipoPagina { Portada, Preguntas, Respuestas, PlantillaCorrectora }

    public enum EEstadoClase { NoProgramada = 1, Programada = 2, Impartida = 3 }

    public enum ETipoClase { Teorica = 1, Practica = 2, Extra = 3 }

    public enum ETipoListadoClases { Todas = 0, Restantes = 1, TeoricasImpartidas = 2, TeoricasNoImpartidas = 3, PracticasImpartidas = 4, PracticasNoImpartidas = 5,
                                    TodasCronograma = 6, RestantesCronograma = 7, ComparativaCronograma = 8}

    public enum ETipoDiaNoLectivo { Todos = 0, FestivoNacional = 1, FestivoLocal = 2, Vacaciones = 3, Examenes = 4, Otros = 5 }

    public enum Perfil
    {
        Examinador = 1,			// 0000000000000001
        Instructor = 2,			// 0000000000000010
        RExamenes = 4,			// 0000000000000100
        InstPracticas = 8,		// 0000000000001000
        RespInstruccion = 16,   // 0000000000010000
        RespCalidad = 32,		// 0000000000100000
        EvalPracticas = 64,		// 0000000001000000
        Auditor = 128,          // 0000000100000000
        Gerente = 256,          // 0000001000000000
        Administrador = 512,    // 0000010000000000
    }

    public enum ENotaPractica { Apto = 1, NoApto = 2, NoCalificado = 3, FaltaAsistencia = 4 }

    public enum ESesionPromocion { Todos = 0, Promocion = 1, Cronograma = 2 }
    
    public class EnumText<T> : EnumTextBase<T>
    {
        public static ComboBoxList<T> GetList()
        {
            return GetList(Resources.Enums.ResourceManager);
        }

        public static ComboBoxList<T> GetList(bool empty_value, bool special_values, bool all_value)
        {
            return GetList(Resources.Enums.ResourceManager, empty_value, special_values, all_value);
        }

        public static string GetLabel(object value)
        {
            return GetLabel(Resources.Enums.ResourceManager, value);
        }
    }

    #endregion
}
