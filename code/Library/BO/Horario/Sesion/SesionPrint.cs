using System;
using System.Collections;
using System.Collections.Generic;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class SesionPrint : SesionInfo
    {

        #region Business Methods

        private string _instructor = string.Empty;
        private string _modulo = string.Empty;
        private string _submodulo = string.Empty;
        private string _titulo = string.Empty;
        private long _numero = 0;

        public string Instructor {get { return _instructor; } }
        public string Modulo { get { return _modulo; } }
        public string Submodulo { get { return _submodulo; } }
        public string Titulo { get { return _titulo; } }
        public long Numero { get { return _numero; } }

        /// <summary>
			/// Copia los atributos del objeto
			/// </summary>
			/// <param name="source">Objeto origen</param>
			protected void CopyValues (SesionInfo source, InstructorInfo instructor, ClaseTeoricaList teoricas,
                ClasePracticaList practicas, ClaseExtraList extras, string clases, long grupo, bool print_alumno)
			{
				if (source == null) return;

				Oid = source.Oid;
				_base.Record.OidHorario = source.OidHorario;
				_base.Record.OidClaseTeorica = source.OidClaseTeorica;
				_base.Record.OidClasePractica = source.OidClasePractica;
				_base.Record.OidClaseExtra = source.OidClaseExtra;
				_base.Record.OidProfesor = source.OidProfesor;
				_base.Record.Fecha = source.Fecha;
				_base.Record.Hora = source.Hora;
				_base.Record.Estado = source.Estado;
				_base.Record.Observaciones = source.Observaciones;
                _base.Record.Grupo = grupo;
                _base.Record.Forzada = source.Forzada;

                if (OidClaseTeorica != 0)
                {
                    ClaseTeoricaInfo clase = teoricas.GetItem(OidClaseTeorica);
                    if (clase != null)
                    {
                        _modulo = ModuloInfo.Get(clase.OidModulo, false).Alias;
                        _submodulo = SubmoduloInfo.Get(clase.OidSubmodulo, false).Codigo;// clases;

                        if (instructor != null)
                        {
                            foreach (Submodulo_InstructorInfo item in instructor.Submodulos)
                            {
                                if (item.OidSubmodulo == clase.OidSubmodulo 
                                    && item.FechaInicio.Date <= source.Fecha.Date
                                    && item.FechaFin >= source.Fecha.Date
                                    )
                                {
                                    instructor = InstructorInfo.Get(item.OidInstructorSuplente);
                                    break;
                                }
                            }
                            if (instructor != null)
                                _instructor = instructor.Apellidos + ", " + instructor.NombrePropio;
                        }
                    }
                }
                else
                {
                    if (OidClasePractica != 0)
                    {
                        ClasePracticaInfo clase = practicas.GetItem(OidClasePractica);
                        if (clase != null)
                        {
                            _modulo = ModuloInfo.Get(clase.OidModulo, false).Alias;
                            _submodulo = clases;
                            _titulo = clase.Alias;

                            if (instructor != null)
                            {
                                foreach (Submodulo_InstructorInfo item in instructor.Submodulos)
                                {
                                    if (item.OidSubmodulo == clase.OidSubmodulo
                                        && item.FechaInicio.Date <= source.Fecha.Date
                                        && item.FechaFin >= source.Fecha.Date
                                        )
                                    {
                                        instructor = InstructorInfo.Get(item.OidInstructorSuplente);
                                        break;
                                    }
                                }
                                if (instructor != null)
                                    _instructor = instructor.Apellidos + ", " + instructor.NombrePropio;
                            }
                        }
                    }
                    else
                    {
                        if (OidClaseExtra != 0)
                        {
                            ClaseExtraInfo clase = extras.GetItem(OidClaseExtra);
                            if (clase != null)
                            {
                                _modulo = ModuloInfo.Get(clase.OidModulo, false).Alias;
                                _submodulo = SubmoduloInfo.Get(clase.OidSubmodulo, false).Codigo;//clases;

                                if (instructor != null)
                                {
                                    foreach (Submodulo_InstructorInfo item in instructor.Submodulos)
                                    {
                                        if (item.OidSubmodulo == clase.OidSubmodulo
                                            && item.FechaInicio.Date <= source.Fecha.Date
                                            && item.FechaFin >= source.Fecha.Date
                                            )
                                        {
                                            instructor = InstructorInfo.Get(item.OidInstructorSuplente);
                                            break;
                                        }
                                    }
                                    if (instructor != null)
                                        _instructor = instructor.Apellidos + ", " + instructor.NombrePropio;
                                }
                            }
                        }
                    }
                }

                if (print_alumno)
                    _instructor = string.Empty;
			}

        #endregion

        #region Factory Methods

        private SesionPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static SesionPrint New(SesionInfo source, InstructorInfo instructor, ClaseTeoricaList teoricas,
            ClasePracticaList practicas, ClaseExtraList extras, string clases, long grupo, bool print_alumno)
        {
            SesionPrint item = new SesionPrint();
            item.CopyValues(source, instructor, teoricas, practicas, extras, clases, grupo, print_alumno);

            return item;
        }

        #endregion

    }
}
