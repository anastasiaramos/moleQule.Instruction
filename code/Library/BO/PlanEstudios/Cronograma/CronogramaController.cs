using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    /// <summary>
    /// Editable Root Business Object With Editable Child Collection
    /// Editable Child Business Object With Editable Child Collection
    /// </summary>
    [Serializable()]
    public class CronogramaController
    {

        #region Attributes

        ClaseTeoricaList _teoricas;
        List<ClasePracticaList> _practicas;
        List<List<long>> _duracion_sesiones;
        Cronograma _cronograma;
        List<long> _practicas_programadas_grupo = new List<long>();
        ClaseTeoricaList _teoricas_plan;
        List<bool> _activas_dia;
        List<bool> _activas_sabado;
        DateTime _inicio_cronograma;
        DateTime _fin_cronograma;

        decimal _n_practicas = 0;
        decimal _practicas_semana = 0;
        int _comienzo_practicas = 0;

        #endregion

        #region Properties

        #endregion

        #region Factory Methods

        public CronogramaController(Cronograma cronograma,
                                    DateTime fecha_inicio,
                                    DateTime fecha_fin,
                                    ClaseTeoricaList teoricas,
                                    List<ClasePracticaList> practicas,
                                    List<bool> activas_dia, List<bool> activas_sabado,
                                    long practicas_semana = 0,
                                    int comienzo_practicas = 0)
        {
            _cronograma = cronograma;
            _teoricas = teoricas;
            _practicas = practicas;
            _activas_dia = activas_dia;
            _activas_sabado = activas_sabado;
            _comienzo_practicas = comienzo_practicas;
            _inicio_cronograma = fecha_inicio;
            _fin_cronograma = fecha_fin;

            _n_practicas = practicas_semana;
            _practicas_semana = practicas_semana;

            _duracion_sesiones = cronograma.RellenaHorasSemana(activas_dia, activas_sabado);

            for (int i = 0; i < _practicas.Count; i++)
            {
                _practicas_programadas_grupo.Add(0);
            }

            _teoricas_plan = ClaseTeoricaList.GetClasesPlanList(_cronograma.OidPlan);
        }

        #endregion

        #region Rules

        public bool PracticasTotalesAsignadas() { return _practicas_semana == 0; }

        /// <summary>
        /// Comprueba que sea posible asignar una clase práctica en función de las prioridades
        /// establecidas en el plan de estudios y en función de las clases teóricas impartidas 
        /// hasta el momento
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public bool PosibleAsignarModulo(ClasePracticaInfo cl)
        {
            //hay que comprobar que no haya clases prioritarias sin colocar
            //si existen módulos con mayor prioridad sin programar
            if (cl.OrdenPrimario != 1)
            {
                foreach (ClaseTeoricaInfo aux in _teoricas)
                {
                    if (aux.OrdenPrimario <= cl.OrdenPrimario &&
                        aux.OidModulo == cl.OidModulo &&
                        aux.EEstadoClase == EEstadoClase.NoProgramada)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Comprueba que sea posible asignar una clase práctica en función de las prioridades
        /// establecidas en el plan de estudios y en función de las clases teóricas impartidas 
        /// hasta el momento
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public bool PosibleAsignarSubmodulo(ClasePracticaInfo cl)
        {
            //hay que comprobar que no haya clases prioritarias sin colocar
            //si existen submódulos previos del mismo módulo sin programar
            if (cl.OrdenSecundario != 1)
            {
                foreach (ClaseTeoricaInfo aux in _teoricas)
                {
                    if (aux.OrdenSecundario <= cl.OrdenSecundario &&
                        aux.OidModulo == cl.OidModulo &&
                        aux.EEstadoClase == EEstadoClase.NoProgramada)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Comprueba que sea posible asignar una clase práctica en función de las clases
        /// teóricas programadas hasta el momento en el horario actual
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public bool PosibleAsignarPractica(ClasePracticaInfo cl, ListaSesiones lista_sesiones)
        {
            bool no_programadas = false;

            foreach (ClaseTeoricaInfo clase in _teoricas)
            {
                if (clase.EEstadoClase == EEstadoClase.Programada)
                {
                    if (clase.OidModulo != cl.OidModulo &&
                        (clase.OrdenPrimario >= cl.OrdenPrimario
                        || (clase.OrdenPrimario == cl.OrdenPrimario
                        && clase.OrdenSecundario >= cl.OrdenSecundario)
                        || (clase.OrdenPrimario == cl.OrdenPrimario
                        && clase.OrdenSecundario == cl.OrdenSecundario
                        && clase.OrdenTerciario >= cl.OrdenTerciario)))
                        return true;
                }
                else
                    no_programadas = true;
            }

            //si ya no quedan clases teóricas por programar se puede incluir la práctica
            return no_programadas ? false : true;
        }

        /// <summary>
        /// Comprueba que sea posible asignar una clase práctica en función de las prioridades
        /// establecidas en el plan de estudios y en función de las clases teóricas impartidas 
        /// hasta el momento
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public bool PosibleAsignarClase(ClasePracticaInfo cl)
        {
            //hay que comprobar que no haya clases prioritarias sin colocar
            //si existen apartados de un submódulo previos sin programar
            if (cl.OrdenTerciario != 1)
            {
                foreach (ClaseTeoricaInfo aux in _teoricas)
                {
                    if (aux.OrdenTerciario <= cl.OrdenTerciario &&
                        aux.OidSubmodulo == cl.OidSubmodulo &&
                        aux.EEstadoClase == EEstadoClase.NoProgramada)
                        return false;
                }
            }

            return true;
        }

        public bool QuedanSesiones(long sesiones_asignadas, ListaSesiones lista_sesiones) { return sesiones_asignadas < lista_sesiones.Count; }

        /// <summary>
        /// Comprueba que queden clases del mismo submódulo por impartir para rellenar el hueco con el 
        /// número de horas de la sesión
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="n_horas"></param>
        /// <returns></returns>
        public bool QuedanClasesSubmodulo(ClaseTeoricaInfo clase,
                                            int n_horas,
                                            out int horas_restantes)
        {
            horas_restantes = (int)(clase.TotalClases - clase.OrdenTerciario + 1);
            return (horas_restantes >= n_horas);
        }

        public bool SesionDisponible(int hora_inicial, int n_horas, ListaSesiones lista_sesiones)
        {
            for (int hora = hora_inicial; hora < hora_inicial + n_horas; hora++)
            {
                if (lista_sesiones[hora].EEstadoClase != EEstadoClase.NoProgramada)
                    return false;
            }
            return true;
        }


        /// <summary>
        /// Función que comprueba que se pueda realizar una práctica en una sesión determinada 
        /// en función del campo Incompatible de la clase práctica
        /// </summary>
        /// <param name="lista_sesiones">sesiones del horario actual</param>
        /// <param name="_instructores_asignados">lista de horarios de la misma semana para otras promociones</param>
        /// <param name="index">índice de la sesión en la que se va a insertar la clase práctica</param>
        /// <param name="incompatible">campo Incompatible de la práctica</param>
        /// <returns></returns>
        public bool LaboratorioLibre(int index, long laboratorio, ListaSesiones lista_sesiones)
        {
            //se comprueba el horario actual, por si el otro grupo tuviera una práctica
            //con el mismo valor de campo Incompatible
            for (int i = index; i < index + 5; i++)
            {
                if (lista_sesiones[i].Laboratorio == laboratorio)
                    return false;
            }
            return true;
        }

        #endregion

        #region Business Methods

        /// <summary>
        /// Función que devuelve el nombre del módulo a la que pertenece una clase a partir del
        /// Oid y el tipo de la misma
        /// </summary>
        /// <param name="oid"></param>
        /// <param name="tipo"></param>
        /// <param name="teoricas"></param>
        /// <param name="practicas"></param>
        /// <param name="extras"></param>
        /// <param name="modulos"></param>
        /// <returns></returns>
        public string ObtieneNombreModulo(long oid, long tipo, ModuloList modulos)
        {
            long oid_clase = oid;
            long oid_modulo = 0;

            if (oid_clase < 0) return string.Empty;

            if (tipo.Equals(0))
            {
                ClaseTeoricaInfo clase = _teoricas.GetItem(oid_clase);
                oid_modulo = clase.OidModulo;
            }
            else
            {
                if (tipo.Equals(1))
                {
                    ClasePracticaInfo clase = null;
                    foreach (ClasePracticaList lista in _practicas)
                    {
                        clase = lista.GetItem(oid_clase);
                        if (clase != null)
                            break;
                    }
                    oid_modulo = clase.OidModulo;

                }
            }
            ModuloInfo modulo = modulos.GetItem(oid_modulo);
            return modulo.Texto;
        }


        public bool AsignaInstructorPractica(ClasePracticaInfo clase,
                                            int hora_inicial,
                                            int n_horas,
                                            ListaSesiones lista_sesiones, long sesiones_asignadas)
        {
            AsignaSesion(clase, hora_inicial, n_horas, lista_sesiones, sesiones_asignadas);
            return true;
        }


        public bool AsignaInstructorTeorica(ClaseTeoricaInfo clase,
                                            int hora_inicial,
                                            int n_horas,
                                            ListaSesiones lista_sesiones, long sesiones_asignadas)
        {
            if (AsignaInstructorTeorica2(hora_inicial, n_horas, clase, lista_sesiones, sesiones_asignadas))
                return true;

            return false;
        }

        public bool AsignaInstructorTeorica2(int hora_inicial, int n_horas,
                                            ClaseTeoricaInfo clase, ListaSesiones lista_sesiones, long sesiones_asignadas)
        {

            int horas_restantes = 0;

            if (QuedanClasesSubmodulo(clase, n_horas, out horas_restantes))
            {
                AsignaSesion(clase, hora_inicial, n_horas, lista_sesiones, sesiones_asignadas);
            }
            else
            {
                AsignaSesion(clase, hora_inicial, horas_restantes, lista_sesiones, sesiones_asignadas);
                AsignaSesionesOtrosSubmodulos(hora_inicial, n_horas, horas_restantes, clase, lista_sesiones, sesiones_asignadas);
            }

            return true;
        }

        public void AsignaSesion(ClasePracticaInfo clase,
                                int hora_inicial,
                                int n_horas,
                                ListaSesiones lista_sesiones,
                                long sesiones_asignadas)
        {
            clase.EEstadoClase = EEstadoClase.Programada;

            if (lista_sesiones[hora_inicial].EEstadoClase == EEstadoClase.NoProgramada)
                _practicas_semana--;

            if (lista_sesiones[hora_inicial].EEstadoClase == EEstadoClase.NoProgramada)
                lista_sesiones[hora_inicial].AsignaClaseASesion(clase);
            else
                lista_sesiones[hora_inicial + 1].AsignaClaseASesion(clase);

            for (int indice = hora_inicial; indice < hora_inicial + n_horas; indice++)
            {
                if (lista_sesiones[indice].EEstadoClase == EEstadoClase.NoProgramada)
                {
                    sesiones_asignadas++;
                    lista_sesiones[indice].EEstadoClase = EEstadoClase.Programada;
                    //lista_sesiones[indice].AsignaClaseASesion(clase);
                }
                /*else
                {
                    if (indice % 2 == 0)
                    {
                        lista_sesiones[indice].AsignaClaseASesion(clase);
                    }
                }*/
            }

        }

        public void AsignaSesion(ClaseTeoricaInfo clase,
                                int hora_inicial,
                                int n_horas,
                                ListaSesiones lista_sesiones, long sesiones_asignadas)
        {
            clase.EEstadoClase = EEstadoClase.Programada;
            sesiones_asignadas++;
            lista_sesiones[hora_inicial].AsignaClaseASesion(clase);
            int indice_clase = _teoricas.IndexOf(clase) + 1;

            int asignadas = 1;

            while (indice_clase < _teoricas.Count && asignadas < n_horas)
            {
                if (_teoricas[indice_clase].OidSubmodulo == clase.OidSubmodulo && _teoricas[indice_clase].EEstadoClase == EEstadoClase.NoProgramada)
                {
                    _teoricas[indice_clase].EEstadoClase = EEstadoClase.Programada;
                    sesiones_asignadas++;
                    lista_sesiones[hora_inicial + asignadas].AsignaClaseASesion(_teoricas[indice_clase]);
                    asignadas++;
                }
                indice_clase++;
            }
        }

        public void AsignaSesionesOtrosSubmodulos(int hora_inicial, int n_horas, int horas_asignadas,
                                                ClaseTeoricaInfo clase,
                                                ListaSesiones lista_sesiones, long sesiones_asignadas)
        {
            for (int i = horas_asignadas; i < n_horas; i++)
            {

                //intentar buscar un submodulo del mismo modulo que la clase asignada
                //con un orden secundario superior, que el instructor sea el mismo e
                //intentar asignarla al hueco
                ClaseTeoricaInfo cl_aux = null;
                foreach (ClaseTeoricaInfo clase_aux in _teoricas)
                {
                    if (clase_aux.OidModulo == clase.OidModulo
                        && clase_aux.OidSubmodulo != clase.OidSubmodulo
                        //&& clase_aux.OrdenSecundario >= clase.OrdenSecundario
                        && clase_aux.EEstadoClase == EEstadoClase.NoProgramada)
                    {
                        cl_aux = clase_aux;
                        break;
                    }
                }

                if (cl_aux != null)
                    AsignaSesion(cl_aux, hora_inicial + i, 1, lista_sesiones, sesiones_asignadas);
            }
        }

        public bool AsignaSesionPractica(int hora_inicial,
                                        int n_horas, ListaSesiones lista_sesiones, long sesiones_asignadas)
        {
            int n_grupo = GetGrupoConMenosPracticas();

            for (int i = 1; i < _practicas.Count; i++)
            {
                int indice_practica = 0;

                //Bucle para buscar una clase que pueda ir la sesión
                while (indice_practica < _practicas[n_grupo].Count)
                {
                    ClasePracticaInfo clase = _practicas[n_grupo][indice_practica];
                    clase.Grupo = n_grupo;

                    if (clase.EEstadoClase == EEstadoClase.NoProgramada) // aún no está programada
                    {
                        /*if (!PosibleAsignarPracticaHorario(clase)) break;
                        if (!PosibleAsignarModulo(clase)) break;
                        if (!PosibleAsignarSubmodulo(clase)) break;*/

                        if ((lista_sesiones[hora_inicial].OidClasePractica == clase.Oid
                            && lista_sesiones[hora_inicial].Grupo != n_grupo) ||
                            !PosibleAsignarPractica(clase, lista_sesiones) || !PosibleAsignarModulo(clase) ||
                            !PosibleAsignarSubmodulo(clase) || !PosibleAsignarClase(clase) ||
                            (clase.Laboratorio > 0 &&
                            !LaboratorioLibre(hora_inicial, clase.Laboratorio, lista_sesiones)))
                        {
                            indice_practica++;
                            continue;
                        }

                        if (AsignaInstructorPractica(clase, hora_inicial, n_horas, lista_sesiones, sesiones_asignadas))
                        {
                            _practicas_programadas_grupo[n_grupo]++;
                            break;
                        }
                    }
                    indice_practica++;
                }

                //Calcula el número del siguiente grupo al que asignarle una clase
                n_grupo = (n_grupo % (_practicas.Count - 1)) + 1;

            }
            return lista_sesiones[hora_inicial].EEstadoClase == EEstadoClase.Programada;
        }


        public bool AsignaSesionTeorica(int hora_inicial,
                                        int n_horas,
                                        ListaSesiones lista_sesiones, long sesiones_asignadas,
                                        bool mismo_modulo)
        {
            int indice_teorica = 0;

            //Bucle para buscar una clase que pueda ir la sesión
            while (indice_teorica < _teoricas.Count)
            {
                ClaseTeoricaInfo clase = _teoricas[indice_teorica];
                if (clase.EEstadoClase == EEstadoClase.NoProgramada
                    && (!mismo_modulo || (mismo_modulo && !MismoModuloMismoDia(hora_inicial, clase, lista_sesiones)))) // aún no está programada
                {
                    if (AsignaInstructorTeorica(clase, hora_inicial, n_horas, lista_sesiones, sesiones_asignadas))
                        return true;
                }
                indice_teorica++;
            }

            return false;
        }
        
        public int BuscaSesionLibre(int n_horas, ListaSesiones lista_sesiones)
        {
            for (int i = 0; i + n_horas - 1 < 75; i++)
            {
                if (SesionDisponible(i, n_horas, lista_sesiones))
                    return i;
            }

            return -1;
        }

        public int BuscaSesionPracticaLibre(int n_horas, ListaSesiones lista_sesiones)
        {
            for (int i = 0; i + n_horas - 1 < 75; i++)
            {
                if (SesionDisponible(i, n_horas, lista_sesiones))
                {
                    while (i + n_horas < 75 && SesionDisponible(i + 1, n_horas, lista_sesiones))
                        i++;
                    return i;
                }
            }

            return -1;
        }

        public int GetGrupoConMenosPracticas()
        {
            int menos_practicas = 1;

            for (int i = 1; i < _practicas.Count; i++)
            {
                if (_practicas[i].Count - _practicas_programadas_grupo[i] >
                    _practicas[menos_practicas].Count - _practicas_programadas_grupo[menos_practicas])
                    menos_practicas = i;
            }
            return menos_practicas;
        }

        public int GetSiguienteSesionLibre(out int n_horas, int hora_inicial, ListaSesiones lista_sesiones)
        {
            n_horas = 0;

            for (int i = hora_inicial; i < lista_sesiones.Count; i++)
            {
                if (lista_sesiones[i].EEstadoClase == EEstadoClase.NoProgramada && lista_sesiones[i].Activa)
                {
                    int indice_hora = i % 14;
                    for (int j = 0; j < _duracion_sesiones.Count; j++)
                    {
                        if (_duracion_sesiones[j].Contains(indice_hora))
                        {
                            n_horas = 0;
                            for (int k = 0; k <= j; k++)
                            {
                                if (lista_sesiones[i + j].EEstadoClase != EEstadoClase.NoProgramada
                                    || !lista_sesiones[i + j].Activa)
                                {
                                    n_horas++;
                                    return i;
                                }
                                n_horas++;
                            }
                            return i;
                        }
                    }
                }
            }
            return -1;
        }

        public void GeneraCronograma()
        {
            int semana = 1;
            int sesiones = -1;
            DateTime inicio_semana = _inicio_cronograma;

            while (_cronograma.Sesiones.Count > sesiones)
            {
                sesiones = _cronograma.Sesiones.Count;
                ListaSesiones lista = GeneraHorario(semana, inicio_semana);

                for (int i = 0; i < lista.Count; i++)
                {
                    if (lista[i].OidClaseTeorica > 0 || lista[i].OidClasePractica > 0)
                    {
                        SesionCronograma sesion = SesionCronograma.NewChild(_cronograma);
                        sesion.MarkItemChild();
                        _cronograma.Sesiones.Add(sesion);

                        sesion.OidClaseTeorica = lista[i].OidClaseTeorica;
                        sesion.OidClasePractica = lista[i].OidClasePractica;
                        sesion.Semana = semana;
                        sesion.Dia = (int)i / 14 + 1;
                        sesion.Turno = i % 14 + 1;
                        sesion.Numero = 0;
                        sesion.Duracion = string.Empty;
                        sesion.Texto = string.Empty;
                        sesion.Clase = string.Empty;
                        sesion.Modulo = string.Empty;
                        sesion.Fecha = lista[i].Fecha;
                        sesion.Hora = lista[i].Hora;

                        if (sesion.OidClaseTeorica > 0)
                        {
                            ClaseTeoricaInfo teorica = _teoricas.GetItem(sesion.OidClaseTeorica);
                            sesion.Duracion = "1:00";
                            sesion.Texto = teorica.Alias;
                            sesion.Clase = teorica.Alias;
                            sesion.Modulo = teorica.Modulo;
                            sesion.Submodulo = teorica.Submodulo;
                            sesion.Alias = teorica.Alias;
                            sesion.ETipoClase = ETipoClase.Teorica;
                            sesion.OrdenPrimario = teorica.OrdenPrimario;
                            sesion.OrdenSecundario = teorica.OrdenSecundario;
                            sesion.OrdenTerciario = teorica.OrdenTerciario;
                        }
                        if (sesion.OidClasePractica > 0)
                        {
                            ClasePracticaInfo practica = _practicas[(int)lista[i].Grupo].GetItem(sesion.OidClasePractica);
                            sesion.Duracion = "5:00";
                            sesion.Texto = practica.Alias + "G" + lista[i].Grupo.ToString();
                            sesion.Clase = practica.Alias + "G" + lista[i].Grupo.ToString();
                            sesion.Modulo = practica.Modulo;
                            sesion.Submodulo = practica.Submodulo;
                            sesion.Alias = practica.Alias;
                            sesion.ETipoClase = ETipoClase.Practica;
                            sesion.OrdenPrimario = practica.OrdenPrimario;
                            sesion.OrdenSecundario = practica.OrdenSecundario;
                            sesion.OrdenTerciario = practica.OrdenTerciario;
                            sesion.Grupo = lista[i].Grupo;
                            sesion.Incompatible = practica.Incompatible;

                        }
                    }

                }
                semana++;
                inicio_semana = inicio_semana.AddDays(7);
                if (inicio_semana > _fin_cronograma) break;
            }
        }

        public ListaSesiones GeneraHorario(int semana, DateTime inicio_promocion)
        {
            long sesiones_asignadas = 0;
            DateTime inicio_semana = inicio_promocion;

            while (inicio_semana.DayOfWeek != DayOfWeek.Monday)
                inicio_semana = inicio_semana.AddDays(-1);

            ListaSesiones lista_sesiones = new ListaSesiones(inicio_semana);
            SetSesionesActivas(lista_sesiones, inicio_promocion, inicio_semana);

            int n_grupos_activos = 0;

            for (int i = 1; i < _practicas.Count; i++)
                n_grupos_activos += _practicas[i].Count > _practicas_programadas_grupo[i] ? 1 : 0;

            _practicas_semana = _n_practicas == 0 ? 6 * n_grupos_activos : _n_practicas * n_grupos_activos;

            int index_practica = 0;

            //Se calcula el número de clases ya asignadas poniendo como asignadas las horas que no se van a programar
            //según las horas seleccionadas
            foreach (SesionAuxiliar obj in lista_sesiones)
            {
                if (obj.Estado > 1)
                {
                    sesiones_asignadas++;
                }
                if ((obj.OidClasePractica != 0 && index_practica == 0) ||
                    index_practica > 0 && index_practica < 5)
                {
                    if (obj.Estado != 3)
                        obj.Estado = 2;
                    index_practica++;
                    sesiones_asignadas++;
                }
                if (index_practica == 5) index_practica = 0;
            }

            long num_sesiones_asignadas = 0;
            long total_asignadas = 0;

            bool practica_asignada = true;
            bool teorica_asignada = false;

            /*do
            {
                total_asignadas = num_sesiones_asignadas;

                if (semana >= _comienzo_practicas)
                {
                    //CLASES PRACTICAS
                    practica_asignada = true;

                    while (!PracticasTotalesAsignadas() && practica_asignada)
                    {
                        //Sesión del sábado
                        if (SesionDisponible(70, 5, lista_sesiones))
                        {
                            practica_asignada = AsignaSesionPractica(70, 5, lista_sesiones, sesiones_asignadas);
                        }

                        //Resto de sesiones
                        int hora_incial = BuscaSesionLibre(5, lista_sesiones);
                        if (hora_incial != -1)
                        {
                            practica_asignada = AsignaSesionPractica(hora_incial, 5, lista_sesiones, sesiones_asignadas);
                        }
                        else
                            practica_asignada = false;

                        if (practica_asignada)
                            num_sesiones_asignadas += 5;
                    }
                }

                //TEORICAS

                for (int hora_inicial = 0; hora_inicial < lista_sesiones.Count; hora_inicial++)
                {
                    int n_horas = 0;
                    hora_inicial = GetSiguienteSesionLibre(out n_horas, hora_inicial, lista_sesiones);

                    if (hora_inicial == -1) break;
                    teorica_asignada = AsignaSesionTeorica(hora_inicial, n_horas, lista_sesiones, sesiones_asignadas, true);

                    if (teorica_asignada)
                    {
                        num_sesiones_asignadas += n_horas;
                        break;
                    }
                }
                if (!teorica_asignada)
                {
                    for (int hora_inicial = 0; hora_inicial < lista_sesiones.Count; hora_inicial++)
                    {
                        int n_horas = 0;
                        hora_inicial = GetSiguienteSesionLibre(out n_horas, hora_inicial, lista_sesiones);

                        if (hora_inicial == -1) break;
                        teorica_asignada = AsignaSesionTeorica(hora_inicial, n_horas, lista_sesiones, sesiones_asignadas, false);

                        if (teorica_asignada)
                        {
                            num_sesiones_asignadas += n_horas;
                            break;
                        }
                    }
                }

            } while (num_sesiones_asignadas < lista_sesiones.Count - sesiones_asignadas
                && total_asignadas != num_sesiones_asignadas);*/


            do
            {
                total_asignadas = num_sesiones_asignadas;

                //CLASES PRACTICAS
                practica_asignada = true;

                while (!PracticasTotalesAsignadas() && practica_asignada)
                {
                    //Sesión del sábado
                    if (SesionDisponible(70, 5, lista_sesiones))
                    {
                        practica_asignada = AsignaSesionPractica(70, 5, lista_sesiones, sesiones_asignadas);
                    }

                    //Resto de sesiones
                    int hora_incial = BuscaSesionPracticaLibre(5, lista_sesiones);
                    if (hora_incial != -1)
                    {
                        practica_asignada = AsignaSesionPractica(hora_incial, 5, lista_sesiones, sesiones_asignadas);
                    }
                    else
                        practica_asignada = false;

                    if (practica_asignada)
                        num_sesiones_asignadas += 5;
                }

                //TEORICAS

                for (int hora_inicial = 0; hora_inicial < lista_sesiones.Count; hora_inicial++)
                {
                    int n_horas = 0;
                    hora_inicial = GetSiguienteSesionLibre(out n_horas, hora_inicial, lista_sesiones);

                    if (n_horas == 1 && (hora_inicial+1) < lista_sesiones.Count && lista_sesiones[hora_inicial +1].OidClasePractica != 0) continue;

                    if (hora_inicial == -1) break;
                    teorica_asignada = AsignaSesionTeorica(hora_inicial, n_horas, lista_sesiones, sesiones_asignadas, true);

                    if (teorica_asignada)
                    {
                        num_sesiones_asignadas += n_horas;
                        break;
                    }
                }
                if (!teorica_asignada)
                {
                    for (int hora_inicial = 0; hora_inicial < lista_sesiones.Count; hora_inicial++)
                    {
                        int n_horas = 0;
                        hora_inicial = GetSiguienteSesionLibre(out n_horas, hora_inicial, lista_sesiones);

                        if (hora_inicial == -1) break;
                        teorica_asignada = AsignaSesionTeorica(hora_inicial, n_horas, lista_sesiones, sesiones_asignadas, false);

                        if (teorica_asignada)
                        {
                            num_sesiones_asignadas += n_horas;
                            break;
                        }
                    }
                }
                
            } while (num_sesiones_asignadas < lista_sesiones.Count - sesiones_asignadas
                && total_asignadas != num_sesiones_asignadas);

            return lista_sesiones;
        }


        /// <summary>
        /// Comprueba que no se impartan varias sesiones del mismo módulo el mismo día
        /// </summary>
        /// <returns></returns>
        public bool MismoModuloMismoDia(int indice_horario,
                                        ClaseTeoricaInfo clase, ListaSesiones lista_sesiones)
        {
            int indice_dia = indice_horario - (indice_horario % 14);
            int contador = 0;

            while (contador < 14 && contador + indice_dia < 75)
            {
                if (clase.OidModulo == lista_sesiones[indice_dia + contador].OidModulo
                    && indice_dia + contador != indice_horario)
                    return true;
                contador++;
            }
            return false;
        }


        public virtual ListaSesiones SetSesionesActivas(ListaSesiones lista_sesiones, DateTime inicio_promocion, DateTime inicio_semana)
        {
            if (lista_sesiones != null)
            {
                //de lunes a viernes a 1ª hora
                lista_sesiones[0].Activa = _activas_dia[0];
                lista_sesiones[14].Activa = _activas_dia[0];
                lista_sesiones[28].Activa = _activas_dia[0];
                lista_sesiones[42].Activa = _activas_dia[0];
                lista_sesiones[56].Activa = _activas_dia[0];


                //de lunes a viernes a 2ª hora
                lista_sesiones[1].Activa = _activas_dia[1];
                lista_sesiones[15].Activa = _activas_dia[1];
                lista_sesiones[29].Activa = _activas_dia[1];
                lista_sesiones[43].Activa = _activas_dia[1];
                lista_sesiones[57].Activa = _activas_dia[1];

                //de lunes a viernes a 3ª hora
                lista_sesiones[2].Activa = _activas_dia[2];
                lista_sesiones[16].Activa = _activas_dia[2];
                lista_sesiones[30].Activa = _activas_dia[2];
                lista_sesiones[44].Activa = _activas_dia[2];
                lista_sesiones[58].Activa = _activas_dia[2];


                //de lunes a viernes a 4ª hora
                lista_sesiones[3].Activa = _activas_dia[3];
                lista_sesiones[17].Activa = _activas_dia[3];
                lista_sesiones[31].Activa = _activas_dia[3];
                lista_sesiones[45].Activa = _activas_dia[3];
                lista_sesiones[59].Activa = _activas_dia[3];

                //de lunes a viernes a 5ª hora
                lista_sesiones[4].Activa = _activas_dia[4];
                lista_sesiones[18].Activa = _activas_dia[4];
                lista_sesiones[32].Activa = _activas_dia[4];
                lista_sesiones[46].Activa = _activas_dia[4];
                lista_sesiones[60].Activa = _activas_dia[4];


                //de lunes a viernes a 6ª hora
                lista_sesiones[5].Activa = _activas_dia[5];
                lista_sesiones[19].Activa = _activas_dia[5];
                lista_sesiones[33].Activa = _activas_dia[5];
                lista_sesiones[47].Activa = _activas_dia[5];
                lista_sesiones[61].Activa = _activas_dia[5];

                //de lunes a viernes a 7ª hora
                lista_sesiones[6].Activa = _activas_dia[6];
                lista_sesiones[20].Activa = _activas_dia[6];
                lista_sesiones[34].Activa = _activas_dia[6];
                lista_sesiones[48].Activa = _activas_dia[6];
                lista_sesiones[62].Activa = _activas_dia[6];


                //de lunes a viernes a 8ª hora
                lista_sesiones[7].Activa = _activas_dia[7];
                lista_sesiones[21].Activa = _activas_dia[7];
                lista_sesiones[35].Activa = _activas_dia[7];
                lista_sesiones[49].Activa = _activas_dia[7];
                lista_sesiones[63].Activa = _activas_dia[7];

                //de lunes a viernes a 9ª hora
                lista_sesiones[8].Activa = _activas_dia[8];
                lista_sesiones[22].Activa = _activas_dia[8];
                lista_sesiones[36].Activa = _activas_dia[8];
                lista_sesiones[50].Activa = _activas_dia[8];
                lista_sesiones[64].Activa = _activas_dia[8];


                //de lunes a viernes a 10ª hora
                lista_sesiones[9].Activa = _activas_dia[9];
                lista_sesiones[23].Activa = _activas_dia[9];
                lista_sesiones[37].Activa = _activas_dia[9];
                lista_sesiones[51].Activa = _activas_dia[9];
                lista_sesiones[65].Activa = _activas_dia[9];

                //de lunes a viernes a 11ª hora
                lista_sesiones[10].Activa = _activas_dia[10];
                lista_sesiones[24].Activa = _activas_dia[10];
                lista_sesiones[38].Activa = _activas_dia[10];
                lista_sesiones[52].Activa = _activas_dia[10];
                lista_sesiones[64].Activa = _activas_dia[10];

                //de lunes a viernes a 12ª hora
                lista_sesiones[11].Activa = _activas_dia[11];
                lista_sesiones[25].Activa = _activas_dia[11];
                lista_sesiones[39].Activa = _activas_dia[11];
                lista_sesiones[53].Activa = _activas_dia[11];
                lista_sesiones[67].Activa = _activas_dia[11];

                //de lunes a viernes a 13ª hora
                lista_sesiones[12].Activa = _activas_dia[12];
                lista_sesiones[26].Activa = _activas_dia[12];
                lista_sesiones[40].Activa = _activas_dia[12];
                lista_sesiones[54].Activa = _activas_dia[12];
                lista_sesiones[68].Activa = _activas_dia[12];

                //de lunes a viernes a 14ª hora
                lista_sesiones[13].Activa = _activas_dia[13];
                lista_sesiones[27].Activa = _activas_dia[13];
                lista_sesiones[41].Activa = _activas_dia[13];
                lista_sesiones[55].Activa = _activas_dia[13];
                lista_sesiones[69].Activa = _activas_dia[13];

                //SÁBADO
                lista_sesiones[70].Activa = _activas_sabado[0];
                lista_sesiones[71].Activa = _activas_sabado[1];
                lista_sesiones[72].Activa = _activas_sabado[2];
                lista_sesiones[73].Activa = _activas_sabado[3];
                lista_sesiones[74].Activa = _activas_sabado[4];

                SortedBindingList<FestivoInfo> festivos = FestivoList.GetList(inicio_semana, inicio_semana.AddDays(5));
                //Se marcar como libres los días establecidos como no lectivos
                if (festivos != null && festivos.Count > 0)
                {
                    foreach (SesionAuxiliar aux in lista_sesiones)
                    {
                        if (aux.Activa)
                        {
                            foreach (FestivoInfo festivo in festivos)
                            {
                                if (aux.Fecha.Date >= festivo.FechaInicio.Date
                                    && aux.Fecha.Date <= festivo.FechaFin.Date)
                                {
                                    aux.Activa = false;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (inicio_semana < inicio_promocion)
                {
                    foreach (SesionAuxiliar aux in lista_sesiones)
                    {
                        if (aux.Activa && aux.Fecha.Date < inicio_promocion.Date)
                            aux.Activa = false;
                    }
                }
            }

            for (int i = 0; i < 75; i++)
            {
                if (!lista_sesiones[i].Activa && lista_sesiones[i].Estado == 1)
                {
                    lista_sesiones[i].Titulo = "LIBRE";
                    lista_sesiones[i].Estado = 2;
                    lista_sesiones[i].OidClaseTeorica = -1;
                }
            }

            return lista_sesiones;
        }

        #endregion

    }
}

