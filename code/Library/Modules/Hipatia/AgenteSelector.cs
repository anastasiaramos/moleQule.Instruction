using System;
using System.Collections.Generic;

using Csla;

using moleQule.Library;
using moleQule.Library.Hipatia;

namespace moleQule.Library.Instruction
{
    public partial class AgenteSelector : AgenteSelectorBase
    {
        #region Business Methods

        #endregion

        #region Style & Source
        
        public new static IAgenteHipatiaList GetAgentes(EntidadInfo entidad)
        {
            IAgenteHipatiaList lista = new IAgenteHipatiaList(new List<IAgenteHipatia>());

            if (entidad.Tipo == typeof(Alumno).Name)
            {
                AlumnoList alumnos = AlumnoList.GetList(false);

                foreach (AlumnoInfo obj in alumnos)
                {
                    if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                        lista.Add(obj);
                }
            }
            else if (entidad.Tipo == typeof(Instructor).Name)
            {
                InstructorList instructores = InstructorList.GetList(false);

                foreach (InstructorInfo obj in instructores)
                {
                    if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                        lista.Add(obj);
                }
            }
            else if (entidad.Tipo == typeof(Promocion).Name)
            {
                PromocionList promociones = PromocionList.GetList(false);

                foreach (PromocionInfo obj in promociones)
                {
                    if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                        lista.Add(obj);
                }
            }
            else if (entidad.Tipo == typeof(Curso).Name)
            {
                CursoList cursos = CursoList.GetList(false);

                foreach (CursoInfo obj in cursos)
                {
                    if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                        lista.Add(obj);
                }
            }
            else if (entidad.Tipo == typeof(Modulo).Name)
            {
                ModuloList modulos = ModuloList.GetList(false);

                foreach (ModuloInfo obj in modulos)
                {
                    if (entidad.Agentes.GetItemByProperty("Oid", obj.Oid) == null)
                        lista.Add(obj);
                }
            }
            else
                throw new iQException("No se ha encontrado el tipo de entidad " + entidad.Tipo);

            return lista;
        }

        #endregion
    }
}