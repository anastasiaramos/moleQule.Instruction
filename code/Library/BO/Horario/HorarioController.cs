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

    public enum TRule { MismoInstructorMismaSesion = 0, MismoInstructorMismoDia = 1 }

    /// <summary>
    /// Editable Root Business Object With Editable Child Collection
    /// Editable Child Business Object With Editable Child Collection
    /// </summary>
    [Serializable()]
    public class HorarioController
    {

        #region Attributes

        List<ListaSesiones> _instructores_asignados;
        ClaseTeoricaList _teoricas;
        List<ClasePracticaList> _practicas;
        ClaseExtraList _extras;
        ListaSesiones _lista_sesiones;
        InstructorList _profesores;
        ProfesoresModulos _profesores_encargados;
        SortedDictionary<long, DisponibilidadInfo> _disponibilidades;
        List<List<long>> _duracion_sesiones;
        Horario _horario;
        decimal _dias_suplente;
        List<long> _practicas_programadas_grupo = new List<long>();
        HorarioList _horarios_promocion;
        ClaseTeoricaList _teoricas_plan;

        decimal _practicas_restantes = 0;
        long _sesiones_asignadas = 0;
        bool[] _rules = new bool[2];

        #endregion

        #region Properties

        public bool[] Rules { get { return _rules; } set { _rules = value; } }

        #endregion

        #region Factory Methods

        public HorarioController(Horario horario,
                                    ListaSesiones lista_sesiones,
                                    ClaseTeoricaList teoricas,
                                    List<ClasePracticaList> practicas,
                                    ClaseExtraList extras,
                                    InstructorList profesores,
                                    ProfesoresModulos profesores_encargados,
                                    List<ListaSesiones> instructores_asignados,
                                    SortedDictionary<long, DisponibilidadInfo> disponibilidades,
                                    decimal n_practicas,
                                    decimal dias_suplente)
        {
            _horario = horario;
            _lista_sesiones = lista_sesiones;
            _teoricas = teoricas;
            _practicas = practicas;
            _extras = extras;
            _profesores = profesores;
            _profesores_encargados = profesores_encargados;
            _instructores_asignados = instructores_asignados;
            _disponibilidades = disponibilidades;

            _practicas_restantes = n_practicas;
            _sesiones_asignadas = 0;
            _dias_suplente = dias_suplente;

            _duracion_sesiones = horario.RellenaHorasSemana();

            for (int i = 0; i < _practicas.Count; i++)
            {
                _practicas_programadas_grupo.Add(0);
            }

            DateTime fecha_horario = horario.FechaInicial.AddDays(-Convert.ToDouble(_dias_suplente));
            _horarios_promocion = HorarioList.GetHorariosPromocionList(_horario.OidPromocion, 
                _horario.OidPlan, fecha_horario, false);
            _horarios_promocion.LoadChilds(typeof(Sesion), false);
            _teoricas_plan = ClaseTeoricaList.GetClasesPlanList(_horario.OidPlan);
        }

        #endregion

        #region Rules

        public bool InstructorLibre(int index, long oid_profesor, int act_index)
        {
            if (_lista_sesiones[index].OidProfesor == oid_profesor)
                return true;

            long contador = 0;
            long clases_semanales = 0;

            InstructorInfo p = _profesores.GetItem(oid_profesor);

            if (p != null)
            {
                DisponibilidadInfo disp = null;
                if (_disponibilidades.TryGetValue(p.Oid, out disp))
                    //foreach (DisponibilidadInfo disp in p.Disponibilidades)
                    //{
                    //    if (disp.FechaInicio.Date.Equals(fecha.Date))
                    //    {
                    clases_semanales = disp.ClasesSemanales;
                //        break;
                //    }
                //}
            }

            //foreach (InstructorInfo p in profesores)
            //{
            //    if (p.Oid == oid_profesor)
            //    {
            //        bool salir = false;
            //        foreach (DisponibilidadInfo disp in p.Disponibilidades)
            //        {
            //            if (disp.FechaInicio.Date.Equals(fecha.Date))
            //            {
            //                clases_semanales = disp.ClasesSemanales;
            //                salir = true;
            //                break;
            //            }
            //        }
            //        if (salir) break;
            //    }
            //}

            foreach (ListaSesiones list in _instructores_asignados)
            {
                if (list[index].OidProfesor == oid_profesor)
                    return false;
                else
                {
                    //puede ser que el profesor no esté asignado directamente porque se trata de una clase práctica 
                    //pero también tenga esas horas ocupadas
                    if (list[index].OidClasePractica != 0)
                    {
                        int index_aux = 0;
                        while (index_aux + index < 75 && list[index_aux + index].OidClasePractica != 0)
                            index_aux++;
                        while (index_aux > 5)
                            index_aux -= 5;
                        int limite_inferior = index + index_aux - 5;
                        for (int i = 0; i < 5; i++)
                        {
                            if (list[limite_inferior + i].OidProfesor == oid_profesor)
                                return false;
                        }

                    }
                }

                int cont_index;

                if (index % 2 == 0)
                    cont_index = index + 1;
                else
                    cont_index = index - 1;

                if (list[index].OidClasePractica != 0 && list[cont_index].OidProfesor == oid_profesor)
                    return false;

                foreach (SesionAuxiliar aux in list)
                {
                    if (aux.OidProfesor == oid_profesor)
                        contador++;
                }
            }

            foreach (SesionAuxiliar ses in _lista_sesiones)
            {
                if (ses.OidProfesor == oid_profesor &&
                    (ses.OidClaseTeorica > 0
                    || ses.OidClasePractica > 0
                    || ses.OidClaseExtra > 0))
                    contador++;
            }

            if (contador >= clases_semanales && act_index == -1)
                return false;
            else return true;
        }

        public bool InstructorDisponible(InstructorInfo instructor,
                                         int hora_inicial,
                                         int n_horas,
                                         out int horas_disponibles)
        {
            horas_disponibles = 0;

            DisponibilidadInfo disponibilidad = null;
            if (!_disponibilidades.TryGetValue(instructor.Oid, out disponibilidad)) return false;
            
            for (int hora = hora_inicial; hora < hora_inicial + n_horas; hora++)
            {
                if (!disponibilidad.Semana[hora] ||
                    !InstructorLibre(hora, instructor.Oid, -1))
                {
                    if (horas_disponibles == 0)
                        return false;
                    else
                    {
                        n_horas = horas_disponibles;
                        return true;
                    }
                }
                else
                    horas_disponibles++;
            }
            return true;
        }

        /// <summary>
        /// Función que comprueba que el instructor que ha comenzado a impartir un módulo sea
        /// quien lo continúa impartiendo
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="prioridad"></param>
        /// <param name="oid_instructor"></param>
        /// <returns></returns>
        public bool InstructorInicialModulo(ClaseTeoricaInfo clase,
                                            long prioridad,
                                            long oid_instructor)
        {
            return (prioridad == 1 && _profesores_encargados.ProfesorEncargado(clase.OidSubmodulo, oid_instructor, false));
        }

        public bool InstructorSuperaDiasSuplencia(int hora_inicial, 
                                                InstructorInfo instructor)
        {
            //comprobar la disponibilidad
            int dias_comprobados = 0, semana = 0;
            int indice;
            DisponibilidadInfo disponibilidad = null;
            bool disponible = false, primero = true;

            if (instructor != null)
            {
                if (instructor.Disponibilidades == null
                    || instructor.Disponibilidades.Count == 0)
                    instructor.LoadChilds(typeof(Disponibilidad), false);

                indice = hora_inicial;// _lista_sesiones.Count - 1; ;
                while (!disponible && dias_comprobados < _dias_suplente)
                {
                    if (indice == _lista_sesiones.Count - 1 || primero)
                    {
                        primero = false;
                        disponibilidad = null;
                        foreach (DisponibilidadInfo d in instructor.Disponibilidades)
                        {
                            if (d.FechaInicio.Date.Equals(_horario.FechaInicial.Date/*.AddDays(semana * (-7))*/))
                            {
                                disponibilidad = d;
                                break;
                            }
                        }
                    }

                    if (disponibilidad == null)
                    {
                        dias_comprobados += (indice % 14) + 1;// 6;
                        semana++;
                    }
                    else
                    {
                        if (disponibilidad.Semana[indice])
                            disponible = true;
                        else
                        {
                            if (indice % 14 == 0)
                                dias_comprobados++;

                            if (indice == 0)
                            {
                                indice = _lista_sesiones.Count - 1;
                                semana++;
                            }
                            else
                                indice--;
                        }
                    }
                }
            }

            return !disponible;
        }

        public bool HayInstructoresDisponibles(int hora_inicial)
        {
            DisponibilidadInfo disp = null;
            for (int i = 0; i < _profesores.Count; i++)
            {
                if (_disponibilidades.TryGetValue(_profesores[i].Oid, out disp) && disp.Semana[hora_inicial]) 
                    return true;
            }
                
            return false;
        }

        public List<long> GetInstructoresDisponibles(int hora_inicial, int n_horas)
        {
            DisponibilidadInfo disp = null;
            List<long> disponibles = new List<long>();

            for (int i = 0; i < _profesores.Count; i++)
            {
                if (_disponibilidades.TryGetValue(_profesores[i].Oid, out disp))
                {
                    bool disponible = true;

                    for (int j = 0; j < n_horas; j++)
                    {
                        if (!(hora_inicial + j < disp.Semana.Count
                            && disp.Semana[hora_inicial + j]))
                        {
                            disponible = false;
                            break;
                        }
                    }

                    if (disponible)
                        disponibles.Add(_profesores[i].Oid);
                }
            }

            return disponibles;
        }

        public bool HayInstructoresSuplentes(out Submodulo_Instructor_PromocionList lista_suplentes)
        {
            lista_suplentes = Submodulo_Instructor_PromocionList.GetPromocionList(_horario.OidPromocion);

            return (lista_suplentes.Count != 0);
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
        public bool LaboratorioLibre(int index, long laboratorio, int n_horas)
        {
            //se comprueban los horarios generados para otras promociones
            foreach (ListaSesiones lista in _instructores_asignados)
            {
                for (int i = index; i < index + n_horas; i++)
                {
                    if (lista[i].Laboratorio == laboratorio)
                        return false;
                }
            }

            //también se comprueba el horario actual, por si el otro grupo tuviera una práctica
            //con el mismo valor de campo Incompatible
            for (int i = index; i < index + n_horas; i++)
            {
                if (_lista_sesiones[i].Laboratorio == laboratorio)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Comprueba que un mismo instructor no tenga clase en la misma sesión dos días seguidos
        /// </summary>
        /// <returns></returns>
        public bool MismaInstructorMismaSesion(int indice_horario,
                                                long oid_instructor)
        {
            int indice_dia = indice_horario % 14;
            if (indice_horario > 14 && indice_dia > 9)
            {
                if (oid_instructor == _lista_sesiones[indice_horario - 14].OidProfesor)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Comprueba que no se impartan varias sesiones del mismo módulo el mismo día
        /// </summary>
        /// <returns></returns>
        public bool MismoInstructorMismoDia(int indice_horario,
                                        long oid_instructor)
        {
            int indice_dia = indice_horario - (indice_horario % 14);
            int contador = 0;

            while (contador < 14 && indice_dia + contador < 75)
            {
                if (oid_instructor == _lista_sesiones[indice_dia + contador].OidProfesor
                    && indice_dia + contador != indice_horario
                    && _lista_sesiones[indice_dia + contador].OidClaseTeorica > 0)
                    return true;
                contador++;
            }
            return false;
        }

        /// <summary>
        /// Comprueba que no se impartan varias sesiones del mismo módulo el mismo día
        /// </summary>
        /// <returns></returns>
        public bool MismoModuloMismoDia(int indice_horario,
                                        ClaseTeoricaInfo clase)
        {
            int indice_dia = indice_horario - (indice_horario % 14);
            int contador = 0;

            while (contador < 14 && indice_dia + contador < 75)
            {
                if (clase.OidModulo == _lista_sesiones[indice_dia + contador].OidModulo
                    && indice_dia + contador != indice_horario
                    && _lista_sesiones[indice_dia+contador].OidClaseTeorica > 0)
                    return true;
                contador++;
            }
            return false;
        }

        public bool PracticasTotalesAsignadas() { return _practicas_restantes <= 0; }

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
                    if (aux.OrdenPrimario < cl.OrdenPrimario &&
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
                    if (aux.OrdenSecundario < cl.OrdenSecundario &&
                        aux.OidSubmodulo == cl.OidSubmodulo &&
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
        public bool PosibleAsignarPracticaHorario(ClasePracticaInfo cl)
        {
            //Si dentro del mismo horario ya hay programadas clases teóricas con prioridad menor
            //que no pertenezcan al mismo módulo
            foreach (SesionAuxiliar item in _lista_sesiones)
            {
                if (item.OidClaseTeorica > 0)
                {
                    ClaseTeoricaInfo clase = _teoricas.GetItem(item.OidClaseTeorica);

                    if ((clase != null &&
                        clase.OidModulo != cl.OidModulo &&
                        (clase.OrdenPrimario > cl.OrdenPrimario
                        || (clase.OrdenPrimario == cl.OrdenPrimario
                        && clase.OrdenSecundario > cl.OrdenSecundario)
                        || (clase.OrdenPrimario == cl.OrdenPrimario
                        && clase.OrdenSecundario == cl.OrdenSecundario
                        && clase.OrdenTerciario >= cl.OrdenTerciario)))
                        || (clase.OidModulo == cl.OidModulo 
                            && clase.OrdenPrimario == cl.OrdenPrimario))
                        return true;
                        
                }
            }

            return PosibleAsignarPracticaHorariosAnteriores(cl);
        }

        /// <summary>
        /// Comprueba que sea posible asignar una clase práctica en función de las clases
        /// teóricas programadas hasta el momento en el horario actual
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public bool PosibleAsignarPracticaHorariosAnteriores(ClasePracticaInfo cl)
        {
            bool hay_teoricas = false;
            //Si dentro del mismo horario ya hay programadas clases teóricas con prioridad menor
            //que no pertenezcan al mismo módulo
            for(int i = _horarios_promocion.Count - 1; i >= 0; i--)
            {
                if (_horarios_promocion[i].FechaInicial >= _horario.FechaInicial)
                    continue;
                foreach (SesionInfo item in _horarios_promocion[i].Sesions)
                {
                    if (item.OidClaseTeorica > 0)
                    {
                        hay_teoricas = true;
                        ClaseTeoricaInfo clase = _teoricas_plan.GetItem(item.OidClaseTeorica);

                        if (clase != null &&
                            //clase.OidModulo != cl.OidModulo &&
                            (clase.OrdenPrimario > cl.OrdenPrimario
                            || (clase.OrdenPrimario == cl.OrdenPrimario
                            && clase.OrdenSecundario > cl.OrdenSecundario)
                            || (clase.OrdenPrimario == cl.OrdenPrimario
                            && clase.OrdenSecundario == cl.OrdenSecundario
                            && clase.OrdenTerciario >= cl.OrdenTerciario)))
                            return true;
                    }
                }
            }

            return !hay_teoricas;
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
                    if (aux.OrdenTerciario < cl.OrdenTerciario &&
                        aux.OidSubmodulo == cl.OidSubmodulo &&
                        aux.EEstadoClase == EEstadoClase.NoProgramada)
                        return false;
                }
            }

            return true;
        }

        public bool QuedanSesiones() { return _sesiones_asignadas < _lista_sesiones.Count; }
        
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

        public bool SesionDisponible(int hora_inicial, int n_horas)
        {
            for (int hora = hora_inicial; hora < hora_inicial + n_horas; hora++)
            {
                if (!_lista_sesiones[hora_inicial].Fecha.ToShortDateString().Equals(_lista_sesiones[hora].Fecha.ToShortDateString()))
                    return false;
                if (_lista_sesiones[hora].EEstadoClase != EEstadoClase.NoProgramada)
                    return false;
            }
            return true;
        }

        #endregion

        #region Business Methods

        /// <summary>
        /// Función que comprueba si es posible realizar un intercambio de una sesión que contiene una
        /// clase teórica ya asignada
        /// </summary>
        public bool PosibleIntercambiar(ClaseTeoricaInfo candidata,
                                        SesionAuxiliar asignada,
                                        InstructorInfo prof,
                                        DateTime fecha)
        {
            if (asignada.Forzada) return false;
            //hay que comprobar que no haya clases prioritarias sin colocar
            //si existen apartados de un submódulo previos sin programar
            if (asignada.OidClasePractica == 0)
            {
                if (candidata.OrdenPrimario > asignada.OrdenPrimario)
                    return false;
                else
                {
                    if (candidata.OidModulo == asignada.OidModulo
                        && candidata.OrdenSecundario > asignada.OrdenSecundario)
                        return false;
                    else
                    {
                        if (candidata.OidSubmodulo == asignada.OidSubmodulo
                            && candidata.OrdenTerciario > asignada.OrdenTerciario)
                            return false;
                        else
                        {
                            bool colocada = false;
                            int i = 0;
                            while (i < 10 && !colocada)
                            {
                                if (_lista_sesiones[i].Estado == 1)
                                {
                                    InstructorInfo profesor = _profesores.GetItem(asignada.OidProfesor);
                                    //foreach (InstructorInfo p in profesores)
                                    //{
                                    //    if (p.Oid == asignada.OidProfesor)
                                    //    {
                                    //        profesor = p;
                                    //        break;
                                    //    }
                                    //}
                                    if (profesor != null && InstructorLibre(i, profesor.Oid, -1))
                                    {
                                        //foreach (DisponibilidadInfo disp in profesor.Disponibilidades)
                                        //{
                                        //    if (disp.FechaInicio.Date.Equals(fecha.Date) && disp.Semana[i])
                                        DisponibilidadInfo disp = null;
                                        if (_disponibilidades.TryGetValue(profesor.Oid, out disp) && disp.Semana[i])
                                            //{
                                            colocada = true;
                                        //break;
                                        //}
                                        //}
                                        if (colocada) break;
                                    }
                                }
                                i++;
                            }
                            if (colocada)
                            {
                                //antes de hacer el cambio hay que comprobar las prioridades
                                int j = _lista_sesiones.IndexOf(asignada);
                                _lista_sesiones[i].Copia(_lista_sesiones[j], true);
                                _lista_sesiones[i].OidProfesor = _lista_sesiones[j].OidProfesor;
                                _lista_sesiones[i].Estado = 2;
                                _lista_sesiones[j].AsignaClaseASesion(candidata);
                                _lista_sesiones[j].OidProfesor = prof.Oid;
                                _lista_sesiones[j].Estado = 2;
                                candidata.Estado = 2;
                                return true;
                            }
                        }
                    }
                }
            }
            else
            {
                int i = 0;
                bool colocada = false;
                bool segunda = false;
                //si se trata de la segunda hora del día
                if (_lista_sesiones.IndexOf(asignada) % 2 != 0)
                {
                    asignada = _lista_sesiones[_lista_sesiones.IndexOf(asignada) - 1];
                    segunda = true;
                }
                //hay que buscar hueco para las practicas
                while (i < 10 && !colocada)
                {
                    if (_lista_sesiones[i].Estado == 1 && _lista_sesiones[i + 1].Estado == 1)
                    {
                        InstructorInfo profesor = _profesores.GetItem(asignada.OidProfesor);
                        //foreach (InstructorInfo p in profesores)
                        //{
                        //    if (p.Oid == asignada.OidProfesor)
                        //    {
                        //        profesor = p;
                        //        break;
                        //    }
                        //}
                        if (profesor != null)
                        {
                            //foreach (DisponibilidadInfo disp in profesor.Disponibilidades)
                            //{
                            //    if (disp.FechaInicio.Date.Equals(fecha.Date))
                            DisponibilidadInfo disp = null;
                            if (_disponibilidades.TryGetValue(profesor.Oid, out disp))
                            {
                                if (disp.Semana[i] && disp.Semana[i + 1])
                                    //{
                                    colocada = true;
                                //break;
                                //}
                            }
                            //}
                            if (colocada) break;
                        }
                    }
                    i += 2;
                }
                if (colocada)
                {
                    //movemos las prácticas desde donde estaban al hueco libre
                    int j = _lista_sesiones.IndexOf(asignada);
                    _lista_sesiones[i].Copia(_lista_sesiones[j], true);
                    _lista_sesiones[i + 1].Copia(_lista_sesiones[j + 1], true);
                    if (segunda)
                    {
                        _lista_sesiones[j].AsignaClaseASesion((ClaseTeoricaInfo)null);
                        _lista_sesiones[j + 1].OidProfesor = prof.Oid;
                        _lista_sesiones[j + 1].AsignaClaseASesion(candidata);
                        _lista_sesiones[j + 1].Estado = 2;
                    }
                    else
                    {
                        _lista_sesiones[j + 1].AsignaClaseASesion((ClaseTeoricaInfo)null);
                        _lista_sesiones[j].OidProfesor = prof.Oid;
                        _lista_sesiones[j].AsignaClaseASesion(candidata);
                    }
                    candidata.Estado = 2;
                    return true;
                }
            }
            return false;

        }

        /// <summary>
        /// Función que comprueba que se pueden intercambiar dos clases de un horario
        /// </summary>
        /// <param name="index1">índice de una de las clases que se pretende cambiar en la lista anterior</param>
        /// <param name="index2">índice de una de las clases que se pretende cambiar en la lista anterior</param>
        /// <param name="fecha">fecha del horario actual</param>
        /// <returns></returns>
        public bool IntentaIntercambio(int index1, int index2, DateTime fecha)
        {
            //se comprueba que los profesores puedan hacer el cambio, ya sea por disponibilidad o porque tengan
            //ya alguna clase asignada en otro horario de la misma semana a la misma hora
            if (_profesores.EstaDisponible(_lista_sesiones[index1].OidProfesor, index2, fecha)
                && _profesores.EstaDisponible(_lista_sesiones[index2].OidProfesor, index1, fecha)
                && Horario.ProfesorLibre(_instructores_asignados, index2, _lista_sesiones[index1].OidProfesor, _lista_sesiones, _profesores, index1, fecha, _disponibilidades)
                && Horario.ProfesorLibre(_instructores_asignados, index1, _lista_sesiones[index2].OidProfesor, _lista_sesiones, _profesores, index2, fecha, _disponibilidades))
            {
                int index_dia1 = index1; //índice de index1 en las clases de su mismo día
                while (index_dia1 > 13)
                    index_dia1 -= 14;
                int index_semana1 = index1; //día de la semana de index1
                while (index_semana1 % 14 != 0)
                    index_semana1--;
                int index_dia2 = index2;//índice de index2 en las clases de su mismo día
                while (index_dia2 > 13)
                    index_dia2 -= 14;
                int index_semana2 = index2;//día de la semana de index2
                while (index_semana2 % 14 != 0)
                    index_semana2--;

                bool no_repetido = true; //indica si ya hay clases del mismo módulo en el día
                int contador = 0;

                //bucle que comprueba que no se repitan clases del mismo módulo el mismo día
                while (contador < 14 && no_repetido && index_semana1 + contador < 75)
                {
                    /*if (contador + index_semana1 != index1
                        && lista_sesiones[contador + index_semana1].OidModulo != lista_sesiones[index2].OidModulo)
                        no_repetido = false;*/
                    contador++;
                }
                contador = 0;
                while (contador < 14 && no_repetido && index_semana2 + contador < 75)
                {
                    /*if (contador + index_semana2 != index2
                        && lista_sesiones[contador + index_semana2].OidModulo != lista_sesiones[index1].OidModulo)
                        no_repetido = false;*/
                    contador++;
                }

                //si no se repiten clases del mismo módulo se realiza el intercambio
                if (no_repetido)
                {
                    _lista_sesiones[index1].IntercambiaSesion(_lista_sesiones[index2], true);
                    return true;
                }
                else
                    return false;
            }
            else return false;
        }

        /// <summary>
        /// Función que organiza las clases asignadas a sesiones de un horario intentando que se cumplan
        /// las prioridades establecidas en el plan de estudios.
        /// No siempre será posible por la disponibilidad de los instructores.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="lista_sesiones"></param>
        /// <param name="profesores"></param>
        /// <param name="_instructores_asignados"></param>
        /// <param name="fecha"></param>
        /// <param name="oid_promocion"></param>
        public void OrdenaHorario(int index)
        {
            int i = 1;
            while (i < index)
            {
                if (_lista_sesiones[i].Estado == 2
                    && _lista_sesiones[i].OidClaseTeorica > 0
                    && !_lista_sesiones[i].Forzada)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (_lista_sesiones[j].OidClaseTeorica > 0
                            &&_lista_sesiones[i].OidProfesor == _lista_sesiones[j].OidProfesor
                            && _lista_sesiones[i].OidModulo == _lista_sesiones[j].OidModulo
                            /*&& (_lista_sesiones[i].OrdenSecundario < _lista_sesiones[j].OrdenSecundario
                            || (_lista_sesiones[i].OrdenSecundario == _lista_sesiones[j].OrdenSecundario
                            && _lista_sesiones[i].OrdenTerciario < _lista_sesiones[j].OrdenTerciario))*/
                            && _teoricas.IndexOf(_teoricas.GetItem(_lista_sesiones[i].OidClaseTeorica)) 
                            < _teoricas.IndexOf(_teoricas.GetItem(_lista_sesiones[j].OidClaseTeorica))
                            && !_lista_sesiones[j].Forzada && _lista_sesiones[j].Estado == 2)
                        { 
                            _lista_sesiones[i].IntercambiaSesion(_lista_sesiones[j], true);
                            OrdenaHorario(i);
                        }
                    }
                }
                i++;
            }
            /*while (i < index)
            {
                if (_lista_sesiones[i].Estado == 2
                    && _lista_sesiones[i].OidClaseTeorica > 0)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (((_lista_sesiones[i].OidModulo == _lista_sesiones[j].OidModulo
                            && (_lista_sesiones[i].OrdenPrimario < _lista_sesiones[j].OrdenPrimario
                            || (_lista_sesiones[i].OrdenPrimario == _lista_sesiones[j].OrdenPrimario
                            && _lista_sesiones[i].OrdenSecundario < _lista_sesiones[j].OrdenSecundario)))
                            || (_lista_sesiones[i].OidSubmodulo == _lista_sesiones[j].OidSubmodulo
                            && _lista_sesiones[i].OrdenTerciario < _lista_sesiones[j].OrdenTerciario))
                            && !_lista_sesiones[j].Forzada
                            && !_lista_sesiones[i].Forzada
                            && _lista_sesiones[j].Estado == 2 && _lista_sesiones[i].Estado == 2
                            && _lista_sesiones[i].OidClasePractica == 0 && _lista_sesiones[j].OidClasePractica == 0)
                        {
                            //si hay dos clases que están desordenadas, comprueba que se pueda realizar el intercambio
                            //de las mismas, si es posible lo realiza y luego reordena nuevamente la primera parte
                            //por si se trastocó

                            if (_lista_sesiones[i].OidProfesor == _lista_sesiones[j].OidProfesor)
                                _lista_sesiones[i].IntercambiaSesion(_lista_sesiones[j], true);
                            else
                            {
                                if (_lista_sesiones[i].OidSubmodulo == _lista_sesiones[j].OidSubmodulo)
                                    _lista_sesiones[i].IntercambiaSesion(_lista_sesiones[j], false);
                                else
                                {
                                    if (!IntentaIntercambio(i, j, _horario.FechaInicial))
                                    {
                                        InstructorInfo instructor_i = _profesores.GetItem(_lista_sesiones[i].OidProfesor);
                                        InstructorInfo instructor_j = _profesores.GetItem(_lista_sesiones[j].OidProfesor);
                                        bool capacitado = false;

                                        foreach (Instructor_PromocionInfo info in instructor_i.Promociones)
                                        {
                                            foreach (Submodulo_Instructor_PromocionInfo item in info.Submodulos)
                                            {
                                                if (item.OidPromocion == _horario.OidPromocion
                                                    && item.OidSubmodulo == _lista_sesiones[j].OidSubmodulo)
                                                {
                                                    capacitado = true;
                                                    break;
                                                }
                                            }
                                            if (capacitado) break;
                                        }
                                        if (capacitado)
                                        {
                                            capacitado = false;

                                            foreach (Instructor_PromocionInfo info in instructor_j.Promociones)
                                            {
                                                foreach (Submodulo_Instructor_PromocionInfo item in info.Submodulos)
                                                {
                                                    if (item.OidPromocion == _horario.OidPromocion
                                                        && item.OidSubmodulo == _lista_sesiones[i].OidSubmodulo)
                                                    {
                                                        capacitado = true;
                                                        break;
                                                    }
                                                }
                                                if (capacitado) break;
                                            }
                                        }
                                        if (capacitado)
                                            _lista_sesiones[i].IntercambiaSesion(_lista_sesiones[j], false);
                                    }
                                }
                            }
                            OrdenaHorario(i);
                        }
                    }
                }
                i++;
            }*/
        }


        /// <summary>
        /// Función que rellena los huecos que quedan aún sin asignar en el horario, intentando forzar clases
        /// y profesores suplentes
        /// </summary>
        /// <param name="_teoria"></param>
        /// <param name="profesores"></param>
        /// <param name="lista_sesiones"></param>
        /// <param name="_instructores_asignados"></param>
        /// <param name="fecha"></param>
        /// <param name="no_asignables"></param>
        /// <param name="oid_promocion"></param>
        /// <param name="lista_3"></param>
        /// <param name="lista_2"></param>
        /// <param name="dias_suplente"></param>
        /// <param name="profesores_encargados"></param>
        public void RellenaLibres(List<SesionNoAsignable> no_asignables)
        {
            Submodulo_Instructor_PromocionList lista_suplentes = Submodulo_Instructor_PromocionList.GetPromocionList(_horario.OidPromocion);
            foreach (SesionAuxiliar obj in _lista_sesiones)
            {
                if (obj.Estado == 1)
                {
                    foreach (ClaseTeoricaInfo clase in _teoricas)
                    {
                        bool asignable = true;
                        if (clase.Estado == 1) // aún no está programada
                        {
                            foreach (InstructorInfo item in _profesores)
                            {
                                foreach (Instructor_PromocionInfo promo in item.Promociones)
                                {
                                    foreach (Submodulo_Instructor_PromocionInfo sub in promo.Submodulos)
                                    {
                                        if (sub.OidSubmodulo == clase.OidSubmodulo
                                           && sub.OidPromocion == _horario.OidPromocion)
                                        {
                                            if (!asignable) break;
                                            bool salir = false;
                                            DisponibilidadInfo disp = null;
                                            if (_disponibilidades.TryGetValue(item.Oid, out disp))
                                            //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                            //{
                                            //    if (disp.FechaInicio.Date.Equals(fecha.Date))
                                            {
                                                if (disp.Semana[_lista_sesiones.IndexOf(obj)] == true
                                                && InstructorLibre(_lista_sesiones.IndexOf(obj), item.Oid, -1))
                                                {
                                                    if (sub.Prioridad != 1 || !_profesores_encargados.ProfesorEncargado(clase.OidSubmodulo, item.Oid, false))
                                                    {
                                                        Submodulo_Instructor_PromocionList subs = lista_suplentes.GetTitulares(sub.OidSubmodulo);
                                                        if (subs != null)
                                                        {
                                                            foreach (Submodulo_Instructor_PromocionInfo elem in subs)
                                                            {
                                                                //comprobar la disponibilidad
                                                                int dias_comprobados = 0, semana = 0;
                                                                int indice = _lista_sesiones.IndexOf(obj);
                                                                InstructorInfo instructor = _profesores.GetItem(elem.OidInstructor);
                                                                DisponibilidadInfo disponibilidad = null;
                                                                bool disponible = false, primero = true;

                                                                if (instructor.Disponibilidades == null
                                                                    || instructor.Disponibilidades.Count == 0)
                                                                    instructor.LoadChilds(typeof(Disponibilidad), false);

                                                                if (instructor != null)
                                                                {
                                                                    //if (indice > 74)
                                                                    indice = 74;
                                                                    //else
                                                                    //{
                                                                    //while (indice % 14 != 13)
                                                                    //indice++;
                                                                    //}
                                                                    while (!disponible && dias_comprobados < _dias_suplente)
                                                                    {
                                                                        if (indice == 74 || primero)
                                                                        {
                                                                            primero = false;
                                                                            disponibilidad = null;
                                                                            foreach (DisponibilidadInfo d in instructor.Disponibilidades)
                                                                            {
                                                                                if (d.FechaInicio.Date.Equals(_horario.FechaInicial.Date.AddDays(semana * (-7))))
                                                                                {
                                                                                    disponibilidad = d;
                                                                                    break;
                                                                                }
                                                                            }
                                                                        }

                                                                        if (disponibilidad == null)
                                                                        {
                                                                            dias_comprobados += 6;
                                                                            semana++;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (disponibilidad.Semana[indice])
                                                                                disponible = true;
                                                                            else
                                                                            {
                                                                                if (indice % 14 == 0)
                                                                                    dias_comprobados++;

                                                                                if (indice == 0)
                                                                                {
                                                                                    indice = 74;
                                                                                    semana++;
                                                                                }
                                                                                else
                                                                                    indice--;
                                                                            }
                                                                        }
                                                                    }
                                                                    if (disponible)
                                                                    {
                                                                        asignable = false;
                                                                        break;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    int index = _lista_sesiones.IndexOf(obj);
                                                    int index_dia = index;
                                                    while (index_dia > 13)
                                                        index_dia -= 14;
                                                    int index_semana = index;
                                                    while (index_semana % 14 != 0)
                                                        index_semana--;
                                                    //int contador = 0;
                                                    foreach (SesionNoAsignable ses in no_asignables)
                                                    {
                                                        if ((item.Oid == ses.OidInstructor
                                                            || clase.OidModulo == ses.OidModulo)
                                                            && index == ses.Index)
                                                        {
                                                            asignable = false;
                                                            break;
                                                        }
                                                    }
                                                    //bucle que controlaba que un mismo profesor no diera una misma asignatura dos veces en un mismo dia
                                                    //while (asignable && contador < 14 && contador + index_semana < 75)
                                                    //{
                                                    //    if (clase.OidModulo == lista_sesiones[index_semana + contador].OidModulo
                                                    //        && index != index_semana + contador)
                                                    //        asignable = false;
                                                    //    contador++;
                                                    //}
                                                    //if (!asignable) break;
                                                    if (asignable)
                                                    {
                                                        clase.Estado = 2;
                                                        obj.AsignaClaseASesion(clase);
                                                        obj.OidProfesor = item.Oid;
                                                        obj.Desordenada = true;
                                                        salir = true;
                                                        if ((_duracion_sesiones[1].Contains(index_dia) && index < 70) || _duracion_sesiones[1].Contains(index)
                                                            || _duracion_sesiones[1].Contains(index - 1) || (_duracion_sesiones[1].Contains(index_dia - 1) && index - 1 < 70))
                                                        {
                                                            if (((_duracion_sesiones[1].Contains(index_dia) && index < 70) || _duracion_sesiones[1].Contains(index)) && _lista_sesiones[index + 1].Estado == 1)
                                                            {
                                                                if (clase.OrdenTerciario < clase.TotalClases)
                                                                {
                                                                    ClaseTeoricaInfo clase_aux = null;
                                                                    foreach (ClaseTeoricaInfo aux in _teoricas)
                                                                    {
                                                                        if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                            && clase.OrdenTerciario == aux.OrdenTerciario - 1
                                                                            && aux.Estado == 1)
                                                                        {
                                                                            clase_aux = aux;
                                                                            break;
                                                                        }
                                                                    }
                                                                    if (clase_aux != null)
                                                                    {
                                                                        if (disp.Semana[index + 1]
                                                                            && InstructorLibre(index + 1, item.Oid, -1))
                                                                        {
                                                                            clase_aux.Estado = 2;
                                                                            _lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                            _lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                            _lista_sesiones[index + 1].Desordenada = true;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    ClaseTeoricaInfo clase_aux = null;
                                                                    foreach (ClaseTeoricaInfo aux in _teoricas)
                                                                    {
                                                                        if (clase.OidModulo == aux.OidModulo
                                                                            && clase.OidSubmodulo != aux.OidSubmodulo
                                                                            && clase.OrdenSecundario < aux.OrdenSecundario
                                                                            && aux.Estado == 1)
                                                                        {
                                                                            clase_aux = aux;
                                                                            break;
                                                                        }
                                                                    }
                                                                    if (clase_aux != null)
                                                                    {
                                                                        bool capacitado = false;
                                                                        foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                                        {
                                                                            if (promocion.OidPromocion == _horario.OidPromocion)
                                                                            {
                                                                                foreach (Submodulo_Instructor_PromocionInfo info in promocion.Submodulos)
                                                                                {
                                                                                    if (info.OidSubmodulo == clase_aux.OidSubmodulo)
                                                                                    {
                                                                                        capacitado = true;
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        if (disp.Semana[index + 1] && capacitado
                                                                            && InstructorLibre(index + 1, item.Oid, -1))
                                                                        {
                                                                            clase_aux.Estado = 2;
                                                                            _lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                            _lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                            _lista_sesiones[index + 1].Desordenada = true;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (((_duracion_sesiones[2].Contains(index_dia - 1) && index - 1 < 70) || _duracion_sesiones[2].Contains(index - 1)
                                                                || (_duracion_sesiones[2].Contains(index_dia) && index < 70) || _duracion_sesiones[2].Contains(index)) && _lista_sesiones[index + 1].Estado == 1)
                                                            {
                                                                if (clase.OrdenTerciario < clase.TotalClases)
                                                                {
                                                                    ClaseTeoricaInfo clase_aux = null;
                                                                    foreach (ClaseTeoricaInfo aux in _teoricas)
                                                                    {
                                                                        if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                            && clase.OrdenTerciario == aux.OrdenTerciario - 1
                                                                            && aux.Estado == 1)
                                                                        {
                                                                            clase_aux = aux;
                                                                            break;
                                                                        }
                                                                    }
                                                                    if (clase_aux != null)
                                                                    {
                                                                        if (disp.Semana[index + 1]
                                                                            && InstructorLibre(index + 1, item.Oid, -1))
                                                                        {
                                                                            clase_aux.Estado = 2;
                                                                            _lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                            _lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                            _lista_sesiones[index + 1].Desordenada = true;
                                                                        }
                                                                    }
                                                                    if (((_duracion_sesiones[2].Contains(index_dia) && index < 70) || _duracion_sesiones[2].Contains(index)) && _lista_sesiones[index + 2].Estado == 1)
                                                                    {
                                                                        if (clase.OrdenTerciario < clase.TotalClases - 1)
                                                                        {
                                                                            ClaseTeoricaInfo clase_aux2 = null;
                                                                            foreach (ClaseTeoricaInfo aux in _teoricas)
                                                                            {
                                                                                if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                                    && clase.OrdenTerciario == aux.OrdenTerciario - 2
                                                                                    && aux.Estado == 1)
                                                                                {
                                                                                    clase_aux2 = aux;
                                                                                    break;
                                                                                }
                                                                            }
                                                                            if (clase_aux2 != null)
                                                                            {
                                                                                if (disp.Semana[index + 2]
                                                                                    && InstructorLibre(index + 2, item.Oid, -1))
                                                                                {
                                                                                    clase_aux2.Estado = 2;
                                                                                    _lista_sesiones[index + 2].AsignaClaseASesion(clase_aux2);
                                                                                    _lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                    _lista_sesiones[index + 2].Desordenada = true;
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            ClaseTeoricaInfo clase_aux2 = null;
                                                                            foreach (ClaseTeoricaInfo aux in _teoricas)
                                                                            {
                                                                                if (clase.OidModulo == aux.OidModulo
                                                                                    && clase.OidSubmodulo != aux.OidSubmodulo
                                                                                    && clase.OrdenSecundario < aux.OrdenSecundario
                                                                                    && aux.Estado == 1)
                                                                                {
                                                                                    clase_aux2 = aux;
                                                                                    break;
                                                                                }
                                                                            }
                                                                            if (clase_aux2 != null)
                                                                            {
                                                                                bool capacitado = false;
                                                                                foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                                                {
                                                                                    if (promocion.OidPromocion == _horario.OidPromocion)
                                                                                    {
                                                                                        foreach (Submodulo_Instructor_PromocionInfo info in promocion.Submodulos)
                                                                                        {
                                                                                            if (info.OidSubmodulo == clase_aux2.OidSubmodulo)
                                                                                            {
                                                                                                capacitado = true;
                                                                                                break;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                if (disp.Semana[index + 2] && capacitado
                                                                                    && InstructorLibre(index + 2, item.Oid, -2))
                                                                                {
                                                                                    clase_aux2.Estado = 2;
                                                                                    _lista_sesiones[index + 2].AsignaClaseASesion(clase_aux2);
                                                                                    _lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                    _lista_sesiones[index + 2].Desordenada = true;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    ClaseTeoricaInfo clase_aux = null;
                                                                    foreach (ClaseTeoricaInfo aux in _teoricas)
                                                                    {
                                                                        if (clase.OidModulo == aux.OidModulo
                                                                            && clase.OidSubmodulo != aux.OidSubmodulo
                                                                            && clase.OrdenSecundario < aux.OrdenSecundario
                                                                            && aux.Estado == 1)
                                                                        {
                                                                            clase_aux = aux;
                                                                            break;
                                                                        }
                                                                    }
                                                                    if (clase_aux != null)
                                                                    {
                                                                        bool capacitado = false;
                                                                        foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                                        {
                                                                            if (promocion.OidPromocion == _horario.OidPromocion)
                                                                            {
                                                                                foreach (Submodulo_Instructor_PromocionInfo info in promocion.Submodulos)
                                                                                {
                                                                                    if (info.OidSubmodulo == clase_aux.OidSubmodulo)
                                                                                    {
                                                                                        capacitado = true;
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        if (disp.Semana[index + 1] && capacitado
                                                                            && InstructorLibre(index + 1, item.Oid, -1))
                                                                        {
                                                                            clase_aux.Estado = 2;
                                                                            _lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                            _lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                            _lista_sesiones[index + 1].Desordenada = true;
                                                                        }
                                                                        if (((_duracion_sesiones[2].Contains(index_dia) && index < 70) || _duracion_sesiones[2].Contains(index)) && _lista_sesiones[index + 2].Estado == 1)
                                                                        {
                                                                            if (clase_aux.OrdenTerciario < clase_aux.TotalClases - 1)
                                                                            {
                                                                                ClaseTeoricaInfo clase_aux2 = null;
                                                                                foreach (ClaseTeoricaInfo aux in _teoricas)
                                                                                {
                                                                                    if (clase_aux.OidSubmodulo == aux.OidSubmodulo
                                                                                        && clase_aux.OrdenTerciario == aux.OrdenTerciario - 1
                                                                                        && aux.Estado == 1)
                                                                                    {
                                                                                        clase_aux2 = aux;
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                if (clase_aux2 != null)
                                                                                {
                                                                                    if (disp.Semana[index + 2]
                                                                                        && InstructorLibre(index + 2, item.Oid, -1))
                                                                                    {
                                                                                        clase_aux2.Estado = 2;
                                                                                        _lista_sesiones[index + 2].AsignaClaseASesion(clase_aux2);
                                                                                        _lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                        _lista_sesiones[index + 2].Desordenada = true;
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                ClaseTeoricaInfo clase_aux2 = null;
                                                                                foreach (ClaseTeoricaInfo aux in _teoricas)
                                                                                {
                                                                                    if (clase_aux.OidModulo == aux.OidModulo
                                                                                        && clase_aux.OidSubmodulo != aux.OidSubmodulo
                                                                                        && clase_aux.OrdenSecundario < aux.OrdenSecundario
                                                                                        && aux.Estado == 1)
                                                                                    {
                                                                                        clase_aux2 = aux;
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                if (clase_aux2 != null)
                                                                                {
                                                                                    capacitado = false;
                                                                                    foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                                                    {
                                                                                        if (promocion.OidPromocion == _horario.OidPromocion)
                                                                                        {
                                                                                            foreach (Submodulo_Instructor_PromocionInfo info in promocion.Submodulos)
                                                                                            {
                                                                                                if (info.OidSubmodulo == clase_aux2.OidSubmodulo)
                                                                                                {
                                                                                                    capacitado = true;
                                                                                                    break;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    if (disp.Semana[index + 2] && capacitado
                                                                                        && InstructorLibre(index + 2, item.Oid, -1))
                                                                                    {
                                                                                        clase_aux2.Estado = 2;
                                                                                        _lista_sesiones[index + 2].AsignaClaseASesion(clase_aux2);
                                                                                        _lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                        _lista_sesiones[index + 2].Desordenada = true;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    //break;
                                                }
                                            }
                                            //}
                                            if (salir || !asignable) break;
                                        }
                                        if (!asignable || clase.Estado == 2) break;
                                    }
                                }
                                if (clase.Estado == 2 || !asignable) break;
                            }
                            if (clase.Estado == 2)
                            {
                                int index = _lista_sesiones.IndexOf(obj);

                                for (int k = index + 1; k < 75; k++)
                                {
                                    if (_lista_sesiones[k].OidModulo == _lista_sesiones[index].OidModulo)
                                    {
                                        if ((_lista_sesiones[k].OrdenPrimario < _lista_sesiones[index].OrdenPrimario
                                            || (_lista_sesiones[k].OrdenPrimario == _lista_sesiones[index].OrdenPrimario
                                            && _lista_sesiones[k].OrdenSecundario < _lista_sesiones[index].OrdenSecundario)
                                            || (_lista_sesiones[k].OrdenPrimario == _lista_sesiones[index].OrdenPrimario
                                            && _lista_sesiones[k].OrdenSecundario == _lista_sesiones[index].OrdenSecundario
                                            && _lista_sesiones[k].OrdenTerciario < _lista_sesiones[index].OrdenTerciario))
                                            && _lista_sesiones[k].OidClaseTeorica != 0
                                            && _lista_sesiones[k].OidProfesor == _lista_sesiones[index].OidProfesor)
                                            _lista_sesiones[k].IntercambiaSesion(_lista_sesiones[index], true);
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void SetInstructor(long oid, string instructor, int index)
        {
            if (_lista_sesiones[index].Seleccionada)
            {
                _lista_sesiones[index].OidProfesor = oid;
                _lista_sesiones[index].Seleccionada = false;
            }
        }


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
            long oid_modulo;

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
                else
                {
                    ClaseExtraInfo clase = _extras.GetItem(oid_clase);
                    oid_modulo = clase.OidModulo;
                }
            }
            ModuloInfo modulo = modulos.GetItem(oid_modulo);
            return modulo.Texto;
        }

        public bool AsignaInstructorPractica(ClasePracticaInfo clase,
                                            List<SesionNoAsignable> no_asignables,
                                            int hora_inicial,
                                            int n_horas)
        {
            foreach (InstructorInfo item in _profesores)
            {
                //Compruebo que el instructor pertenece a esta promocion
                Instructor_PromocionInfo promocion = item.Promociones.GetItemByPromocion(_horario.OidPromocion);

                if (promocion != null)
                {
                    //Compruebo que el instructor puede dar este submodulo
                    Submodulo_Instructor_PromocionInfo sub = promocion.Submodulos.GetItemBySubmoduloPromocion(clase.OidSubmodulo, _horario.OidPromocion);

                    if (sub != null)
                    {
                        if (sub.Prioridad == 1 && _profesores_encargados.ProfesorEncargado(clase.OidSubmodulo, item.Oid, true))
                        {
                            if (MismoInstructorMismoDia(hora_inicial, item.Oid)) break;
                            //se comprueba que el profesor tenga las 5 horas libres
                            int horas_disponibles = 0;
                            if (InstructorDisponible(item, hora_inicial, n_horas, out horas_disponibles)
                               && n_horas == horas_disponibles)
                            {
                                if (!PosibleAsignarClase(clase)) break;

                                AsignaSesion(clase, item.Oid, hora_inicial, n_horas);
                                _profesores_encargados.SetProfesorEncargado(clase.OidSubmodulo, item.Oid, true);
                                return true;
                            }
                            else
                            {
                                if (InstructorSuperaDiasSuplencia(hora_inicial, item))
                                {
                                    Submodulo_Instructor_PromocionList lista_suplentes;

                                    if (!HayInstructoresSuplentes(out lista_suplentes)) break;

                                    int posicion_inicial = 0;

                                    InstructorInfo instructor = GetProfesorSuplente(clase.OidSubmodulo, ref posicion_inicial, lista_suplentes);
                                    while (instructor != null)
                                    {
                                        if (!InstructorDisponible(instructor, hora_inicial, n_horas, out horas_disponibles)
                                            || horas_disponibles != n_horas)
                                        {
                                            posicion_inicial++;
                                            instructor = GetProfesorSuplente(clase.OidSubmodulo, ref posicion_inicial, lista_suplentes);
                                            continue;
                                        }

                                        if (!PosibleAsignarClase(clase))
                                        {
                                            posicion_inicial++;
                                            instructor = GetProfesorSuplente(clase.OidSubmodulo, ref posicion_inicial, lista_suplentes);
                                            break;
                                        }

                                        AsignaSesion(clase, item.Oid, hora_inicial, n_horas);
                                        return true;
                                    }
                                }
                                else break;
                            }
                        }
                    }
                }
            }

            return false;
        }
        
        public bool AsignaInstructorTeorica(ClaseTeoricaInfo clase,
                                            List<SesionNoAsignable> no_asignables,
                                            int hora_inicial,
                                            int n_horas,
                                            long oid_profesor)
        {
            foreach (InstructorInfo item in _profesores)
            {
                if (oid_profesor != 0 && oid_profesor != item.Oid)
                    continue;
                //Compruebo que el instructor pertenece a esta promocion
                Instructor_PromocionInfo promocion = item.Promociones.GetItemByPromocion(_horario.OidPromocion);

                if (promocion != null)
                {
                    //Compruebo que el instructor puede dar este submodulo
                    Submodulo_Instructor_PromocionInfo sub = promocion.Submodulos.GetItemBySubmoduloPromocion(clase.OidSubmodulo, _horario.OidPromocion);

                    if (sub != null)
                    {
                        if (InstructorInicialModulo(clase, sub.Prioridad, item.Oid))
                        {
                            int horas_disponibles = 0;
                            if (InstructorDisponible(item, hora_inicial, n_horas, out horas_disponibles))
                            {
                                n_horas = horas_disponibles;
                                if (AsignaInstructorTeorica2(item, hora_inicial, n_horas, clase))
                                {
                                    _profesores_encargados.SetProfesorEncargado(clase.OidSubmodulo, item.Oid, false);
                                    return true;
                                }
                            }
                            else
                            {
                                if (InstructorSuperaDiasSuplencia(hora_inicial, item))
                                {
                                    Submodulo_Instructor_PromocionList lista_suplentes;

                                    if (!HayInstructoresSuplentes(out lista_suplentes)) break;

                                    int posicion_inicial = 0;

                                    InstructorInfo instructor = GetProfesorSuplente(clase.OidSubmodulo, ref posicion_inicial, lista_suplentes);
                                    while (instructor != null)
                                    {
                                        if (!InstructorDisponible(instructor, hora_inicial, n_horas, out horas_disponibles))
                                        {
                                            posicion_inicial++;
                                            instructor = GetProfesorSuplente(clase.OidSubmodulo, ref posicion_inicial, lista_suplentes);
                                            continue;
                                        }

                                        n_horas = horas_disponibles;

                                        if (AsignaInstructorTeorica2(instructor, hora_inicial, n_horas, clase))
                                            return true;

                                        posicion_inicial++;
                                        instructor = GetProfesorSuplente(clase.OidSubmodulo, ref posicion_inicial, lista_suplentes);
                                    }
                                }
                                else
                                {
                                    if (_profesores_encargados.ExisteProfesorEncargado(clase.OidSubmodulo, item.Oid, false))
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool AsignaInstructorTeorica2(InstructorInfo instructor, int hora_inicial, int n_horas,
                                            ClaseTeoricaInfo clase)
        {
            
            int horas_restantes = 0;

            if (_rules[(int)TRule.MismoInstructorMismoDia] && (MismoInstructorMismoDia(hora_inicial, instructor.Oid))) return false;
            if (_rules[(int)TRule.MismoInstructorMismaSesion] && (MismaInstructorMismaSesion(hora_inicial, instructor.Oid)))
            {
                int inicio_dia = hora_inicial;
                int fin_dia = hora_inicial;

                while (inicio_dia > 0 && _lista_sesiones[inicio_dia - 1].Fecha.Day == _lista_sesiones[hora_inicial].Fecha.Day)
                    inicio_dia--;
                while (fin_dia + n_horas - 1 < _lista_sesiones.Count - 1 && _lista_sesiones[fin_dia + n_horas].Fecha.Day == _lista_sesiones[hora_inicial].Fecha.Day)
                    fin_dia++;

                DateTime fecha_inicio = _lista_sesiones[hora_inicial].Fecha;
                while (fecha_inicio.DayOfWeek != DayOfWeek.Monday)
                    fecha_inicio = fecha_inicio.AddDays(-1);

                for (int i = inicio_dia; i <= fin_dia - n_horas + 1; i++)
                {
                    if (i != hora_inicial && _lista_sesiones[i].EEstadoClase == EEstadoClase.Programada 
                        && (_lista_sesiones[i].OidClaseTeorica > 0 
                        || _lista_sesiones[i].OidClaseExtra > 0)
                        && (_profesores.EstaDisponible(_lista_sesiones[i].OidProfesor, hora_inicial, fecha_inicio)
                        && _profesores.EstaDisponible(instructor.Oid, i, fecha_inicio)
                        && Horario.ProfesorLibre(_instructores_asignados, hora_inicial, _lista_sesiones[i].OidProfesor, _lista_sesiones, _profesores, hora_inicial, fecha_inicio, _disponibilidades)
                        && Horario.ProfesorLibre(_instructores_asignados, i, instructor.Oid, _lista_sesiones, _profesores, i, fecha_inicio, _disponibilidades)))
                    {
                        for (int ind = 0; ind < n_horas; ind++)
                        {
                            if (i + ind == _lista_sesiones.Count
                                || hora_inicial + ind == _lista_sesiones.Count
                                || _lista_sesiones[i].OidModulo != _lista_sesiones[hora_inicial+ind].OidModulo)
                                break;
                            _lista_sesiones[i+ind].IntercambiaSesion(_lista_sesiones[hora_inicial+ind], true);
                        }
                        if (QuedanClasesSubmodulo(clase, n_horas, out horas_restantes))
                        {
                            AsignaSesion(clase, instructor.Oid, i, n_horas);
                        }
                        else
                        {
                            AsignaSesion(clase, instructor.Oid, i, horas_restantes);
                            AsignaSesionesOtrosSubmodulos(i, n_horas, horas_restantes, clase, instructor);
                        }
                        return true;
                    }
                }

                return false;
            }
            if (QuedanClasesSubmodulo(clase, n_horas, out horas_restantes))
            {
                AsignaSesion(clase, instructor.Oid, hora_inicial, n_horas);
            }
            else
            {
                AsignaSesion(clase, instructor.Oid, hora_inicial, horas_restantes);
                AsignaSesionesOtrosSubmodulos(hora_inicial, n_horas, horas_restantes, clase, instructor);
            }
            
            return true;            
        }

        public void AsignaSesionLibre(int hora_inicial,
                                int n_horas)
        {
            _sesiones_asignadas++;
            if (_lista_sesiones[hora_inicial].EEstadoClase == EEstadoClase.Programada)
                LiberarClase(hora_inicial);
            _lista_sesiones[hora_inicial].AsignaClaseASesion((ClaseTeoricaInfo)null);
            _lista_sesiones[hora_inicial].EEstadoClase = EEstadoClase.Programada;
            _lista_sesiones[hora_inicial].OidClaseTeorica = -1;

            int asignadas = 1;

            while (asignadas < n_horas)
            {
                _sesiones_asignadas++;
                if (_lista_sesiones[hora_inicial + asignadas].EEstadoClase == EEstadoClase.Programada)
                    LiberarClase(hora_inicial + asignadas);
                _lista_sesiones[hora_inicial + asignadas].AsignaClaseASesion((ClaseTeoricaInfo)null);
                _lista_sesiones[hora_inicial + asignadas].EEstadoClase = EEstadoClase.Programada;
                _lista_sesiones[hora_inicial + asignadas].OidClaseTeorica = -1;
                asignadas++;
            }
        }

        public void AsignaSesion(ClasePracticaInfo clase,
                                long oid_instructor, 
                                int hora_inicial, 
                                int n_horas)
        {
            clase.EEstadoClase = EEstadoClase.Programada;

            if (_lista_sesiones[hora_inicial].EEstadoClase == EEstadoClase.NoProgramada)
                _practicas_restantes--;

            for (int indice = hora_inicial; indice < hora_inicial + n_horas; indice++)
            {
                if (_lista_sesiones[indice].EEstadoClase == EEstadoClase.NoProgramada)
                {
                    _sesiones_asignadas++;
                    _lista_sesiones[indice].AsignaClaseASesion(clase);
                    _lista_sesiones[indice].OidProfesor = oid_instructor;
                }
                else
                {
                    if (indice % 2 == 0)
                    {
                        _lista_sesiones[indice].AsignaClaseASesion(clase);
                        _lista_sesiones[indice].OidProfesor = oid_instructor;
                    }
                }
            }
        }

        public void  AsignaSesion(ClaseTeoricaInfo clase,
                                long oid_instructor,
                                int hora_inicial,
                                int n_horas)
        {
            clase.EEstadoClase = EEstadoClase.Programada;
            _sesiones_asignadas++;
            if (_lista_sesiones[hora_inicial].EEstadoClase == EEstadoClase.Programada)
                LiberarClase(hora_inicial);
            _lista_sesiones[hora_inicial].AsignaClaseASesion(clase);
            _lista_sesiones[hora_inicial].OidProfesor = oid_instructor;
            int indice_clase = _teoricas.IndexOf(clase) + 1;

            int asignadas = 1;

            while (indice_clase < _teoricas.Count && asignadas < n_horas)
            {
                if (_teoricas[indice_clase].OidSubmodulo == clase.OidSubmodulo && _teoricas[indice_clase].EEstadoClase == EEstadoClase.NoProgramada)
                {
                    _teoricas[indice_clase].EEstadoClase = EEstadoClase.Programada;
                    _sesiones_asignadas++;
                    if (_lista_sesiones[hora_inicial + asignadas].EEstadoClase == EEstadoClase.Programada)
                        LiberarClase(hora_inicial + asignadas);
                    _lista_sesiones[hora_inicial + asignadas].AsignaClaseASesion(_teoricas[indice_clase]);
                    _lista_sesiones[hora_inicial + asignadas].OidProfesor = oid_instructor;
                    asignadas++;
                }
                indice_clase++;
            }
        }

        public void AsignaSesionesOtrosSubmodulos(int hora_inicial, int n_horas, int horas_asignadas,
                                                ClaseTeoricaInfo clase, InstructorInfo instructor)
        {
            for (int i = horas_asignadas; i < n_horas; i++)
            {

                //intentar buscar un submodulo del mismo modulo que la clase asignada
                //con un orden secundario superior, que el instructor sea el mismo e
                //intentar asignarla al hueco
                //ClaseTeoricaInfo cl_aux = null;
                foreach (ClaseTeoricaInfo clase_aux in _teoricas)
                {
                    bool asignada = false;
                    if (clase_aux.OidModulo == clase.OidModulo
                        && clase_aux.OidSubmodulo != clase.OidSubmodulo
                        && clase_aux.OrdenSecundario >= clase.OrdenSecundario
                        && clase_aux.EEstadoClase == EEstadoClase.NoProgramada)
                    {
                        //cl_aux = clase_aux;
                        foreach (Instructor_PromocionInfo pr in instructor.Promociones)
                        {
                            if (pr.OidPromocion == _horario.OidPromocion)
                            {
                                foreach (Submodulo_Instructor_PromocionInfo info in pr.Submodulos)
                                {
                                    if (info.OidSubmodulo == clase_aux.OidSubmodulo)
                                    {
                                        AsignaSesion(clase_aux, instructor.Oid, hora_inicial + i, 1);
                                        asignada = true;
                                        break;
                                    }
                                }
                            }
                            if (asignada)
                                break;
                        }
                        //break;
                    }
                    if (asignada)
                        break;
                }
                /*if (cl_aux != null)
                {
                    foreach (Instructor_PromocionInfo pr in instructor.Promociones)
                    {
                        if (pr.OidPromocion == _horario.OidPromocion)
                        {
                            foreach (Submodulo_Instructor_PromocionInfo info in pr.Submodulos)
                            {
                                if (info.OidSubmodulo == cl_aux.OidSubmodulo)
                                {
                                    AsignaSesion(cl_aux, instructor.Oid, hora_inicial + i, 1);
                                    break;
                                }
                            }
                        }
                    }
                }*/
            }
        }

        public bool AsignaSesionPractica(List<SesionNoAsignable> no_asignables,
                                        int hora_inicial, 
                                        out int n_horas)
        {
            n_horas = 5;
            if (!HayInstructoresDisponibles(hora_inicial)) return false;

            int n_grupo = GetGrupoConMenosPracticas();

            for (int i = 1; i < _practicas.Count; i++)
            {
                int indice_practica = 0;

                //Bucle para buscar una clase que pueda ir la sesión
                while (indice_practica < _practicas[n_grupo].Count)
                {
                    ClasePracticaInfo clase = _practicas[n_grupo][indice_practica];

                    if (clase.EEstadoClase == EEstadoClase.NoProgramada) // aún no está programada
                    {
                        /*if (!PosibleAsignarPracticaHorario(clase)) break;
                        if (!PosibleAsignarModulo(clase)) break;
                        if (!PosibleAsignarSubmodulo(clase)) break;*/

                        if ((_lista_sesiones[hora_inicial].OidClasePractica == clase.Oid
                            && _lista_sesiones[hora_inicial].Grupo != n_grupo) || 
                            !PosibleAsignarPracticaHorario(clase) || !PosibleAsignarModulo(clase) ||
                            !PosibleAsignarSubmodulo(clase) || (clase.Laboratorio > 0 && 
                            !LaboratorioLibre(hora_inicial, clase.Laboratorio, (int)clase.Duracion)))
                        {
                            indice_practica++;
                            continue;
                        }

                        if (AsignaInstructorPractica(clase, no_asignables, hora_inicial + (5 - (int)clase.Duracion), (int)clase.Duracion))
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
            return _lista_sesiones[hora_inicial + (5 - n_horas)].EEstadoClase == EEstadoClase.Programada;
        }

        public int GetHorasSesion(int indice)
        {
            int indice_hora = indice % 14;
            for (int j = 0; j < _duracion_sesiones.Count; j++)
            {
                if (_duracion_sesiones[j].Contains(indice_hora))
                {
                    return j + 1;
                }
            }

            return 0;
        }

        public bool ReasignaSesionTeorica(List<SesionNoAsignable> no_asignables,
                                        int hora_inicial,
                                        int n_horas,
                                        out int total_horas)
        {
            total_horas = 0;

            if (HayInstructoresDisponibles(hora_inicial))
            {
                //aquí se intentaría incluir alguna clase de alguno de los instructores disponibles
                List<long> disponibles = GetInstructoresDisponibles(hora_inicial, n_horas);

                //Para cada instructor disponible en la hora que se está intentando asignar
                foreach (long oid in disponibles)
                {
                    //se mira si tiene clases asignadas en otros huecos del horario para intentar moverlas
                    //y reasignar los huecos que quedarían libres
                    for (int i = 0; i < _lista_sesiones.Count; i++)
                    {
                        SesionAuxiliar item = _lista_sesiones[i];

                        if (item.OidClaseTeorica > 0 && item.OidProfesor == oid)
                        {
                            //se ha encontrado una clase con el profesor actual
                            int n_horas_sesion = GetHorasSesion(i);

                            //se buscan instructores disponibles para el hueco que va a quedar libre
                            List<long> disponibles_cambio = GetInstructoresDisponibles(i, n_horas_sesion);

                            if (disponibles_cambio.Count > 0)
                            {
                                long oid_modulo = _lista_sesiones[i].OidModulo;

                                foreach (long oid_disponible in disponibles_cambio)
                                {
                                    if (oid_disponible == oid)
                                        continue;

                                    bool teorica_asignada = false;

                                    teorica_asignada = AsignaSesionTeorica(no_asignables, i, n_horas_sesion, oid_disponible);

                                    if (teorica_asignada)
                                    {
                                        //total_horas = n_horas_sesion;

                                        //for (int k = 0; k < n_horas; k++)
                                            //LiberarClase(hora_inicial + k);

                                        //total_horas -= n_horas;

                                        if (AsignaSesionTeorica(no_asignables, hora_inicial, n_horas, oid))
                                            total_horas += n_horas;

                                        if (n_horas > n_horas_sesion)
                                        {
                                            for (int k = i + n_horas_sesion; k < _lista_sesiones.Count; k++)
                                            {
                                                if (_lista_sesiones[k].OidProfesor == oid
                                                && _lista_sesiones[k].OidClaseTeorica > 0
                                                && _lista_sesiones[k].OidModulo == oid_modulo)
                                                {
                                                    int duracion = GetHorasSesion(k);

                                                    for (int l = 0; l < duracion; l++)
                                                        LiberarClase(k + l);

                                                    total_horas -= duracion;

                                                    if (AsignaSesionTeorica(no_asignables, k, duracion, oid))
                                                        total_horas += duracion;
                                                }
                                                
                                            }
                                        }
                                        return true;
                                    }
                                }
                            }

                            i += n_horas_sesion - 1;
                        }
                    }
                }
            }

            return false;
        }

        public bool AsignaSesionTeorica(List<SesionNoAsignable> no_asignables,
                                        int hora_inicial,
                                        int n_horas)
        {
            return AsignaSesionTeorica(no_asignables, hora_inicial, n_horas, 0);
        }

        public bool AsignaSesionTeorica(List<SesionNoAsignable> no_asignables,
                                        int hora_inicial,
                                        int n_horas,
                                        long oid_profesor)
        {
            int indice_teorica = 0;

            if (!HayInstructoresDisponibles(hora_inicial)) 
            {
                AsignaSesionLibre(hora_inicial, n_horas);
                return true;
            }

            
            //Bucle para buscar una clase que pueda ir la sesión
            while (indice_teorica < _teoricas.Count)
            {
                ClaseTeoricaInfo clase = _teoricas[indice_teorica];
                if (clase.EEstadoClase == EEstadoClase.NoProgramada) // aún no está programada
                {
                    if (!MismoModuloMismoDia(hora_inicial ,clase) 
                        && AsignaInstructorTeorica(clase, no_asignables, hora_inicial, n_horas, oid_profesor))
                        return true;
                }
                indice_teorica++;
            }

            return false;
        }

        public int BuscaSesionLibre(int n_horas)
        {
            for (int i = 0; i + n_horas - 1 < 75; i++)
            {
                if (SesionDisponible(i, n_horas))
                    return i;
            }

            return -1;
        }

        public int BuscaSesionPracticaLibre(int n_horas)
        {
            for (int i = 0; i + n_horas - 1 < 75; i++)
            {
                if (SesionDisponible(i, n_horas))
                {
                    while (i + n_horas < 75 && SesionDisponible(i + 1, n_horas))
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

        public InstructorInfo GetProfesorSuplente(long oid_submodulo, ref int posicion_inicial, 
                                                Submodulo_Instructor_PromocionList lista)
        {
            for (int i = posicion_inicial; i < lista.Count; i++)
            {
                if (lista[i].OidSubmodulo == oid_submodulo && lista[i].Prioridad > 1)
                {
                    posicion_inicial = i;
                     return _profesores.GetItem(lista[i].OidInstructor);
                }
            }
            return null;
        }

        public int GetSiguienteSesionLibre(out int n_horas, int hora_inicial)
        {
            n_horas = 0;

            for (int i = hora_inicial; i < _lista_sesiones.Count; i++)
            {
                if (_lista_sesiones[i].EEstadoClase == EEstadoClase.NoProgramada && _lista_sesiones[i].Activa)
                {
                    int indice_hora = i % 14;
                    for (int j = 0; j < _duracion_sesiones.Count; j++)
                    {
                        if (_duracion_sesiones[j].Contains(indice_hora))
                        {
                            n_horas = 0;
                            for (int k = 0; k <= j; k++)
                            {
                                if (_lista_sesiones[i + j].EEstadoClase != EEstadoClase.NoProgramada
                                    || !_lista_sesiones[i + j].Activa)
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

        /// <summary>
        /// Marca como libre en la lista de clases, la clase que estaba asignada en la sesión que está en el índice index
        /// </summary>
        /// <param name="index">índice de la sesión actual</param>
        /// <param name="lista_sesiones">lista de sesiones del horario actual</param>
        /// <param name="_practicas">lista de clases prácticas que aún no se han asignado a la promoción actual</param>
        /// <param name="_teoria">lista de clases teóricas que aún no se han asignado a la promoción actual</param>
        /// <param name="_extra">lista de clases extra que aún no se han asignado a la promoción actual</param>
        public void LiberarClase(int index)
        {
            if (_lista_sesiones[index].Estado != 1)
            {
                if (_lista_sesiones[index].OidClasePractica != 0)
                {
                    //foreach (ClasePracticaList lista in _practicas)
                    //{
                    //    foreach (ClasePracticaInfo clase in lista)
                    //    {
                    //        if (clase.Oid == lista_sesiones[index].OidClasePractica
                    //            && clase.Grupo == lista_sesiones[index].Grupo)
                    //        {
                    //            clase.Estado = 1;
                    //            break;
                    //        }
                    //    }
                    //}
                    ClasePracticaInfo clase = _practicas[(int)(_lista_sesiones[index].Grupo)].GetItem(_lista_sesiones[index].OidClasePractica);
                    clase.Estado = 1;
                }
                else
                {
                    if (_lista_sesiones[index].OidClaseTeorica != 0)
                    {
                        //foreach (ClaseTeoricaInfo clase in _teoria)
                        //{
                        //    if (clase.Oid == lista_sesiones[index].OidClaseTeorica)
                        //    {
                        //        clase.Estado = 1;
                        //        break;
                        //    }
                        //}

                        ClaseTeoricaInfo clase = _teoricas.GetItem(_lista_sesiones[index].OidClaseTeorica);
                        clase.Estado = 1;
                    }
                    else
                    {
                        //foreach (ClaseExtraInfo clase in _extra)
                        //{
                        //    if (clase.Oid == lista_sesiones[index].OidClaseExtra)
                        //    {
                        //        clase.Estado = 1;
                        //        break;
                        //    }
                        //}
                        ClaseExtraInfo clase = _extras.GetItem(_lista_sesiones[index].OidClaseExtra);
                        clase.Estado = 1;
                    }
                }
            }
        }

        public void GeneraHorario(List<SesionNoAsignable> no_asignables)
        {
            _sesiones_asignadas = 0;

            if (_profesores == null) _profesores = InstructorList.GetInstructoresHorariosList(_horario.OidPromocion, _horario.FechaInicial, _horario.FechaFinal);
            int index_practica = 0;

            ListaSesiones auxiliar = new ListaSesiones(_horario.FechaInicial);

            List<bool> activas = new List<bool>();

            for (int i = 0; i < 14; i++)
                activas.Add(false);

            foreach (List<long> duraciones in _duracion_sesiones)
            {
                foreach (long inicio_sesion in duraciones)
                {
                    for(int i = 0; i <= _duracion_sesiones.IndexOf(duraciones); i++)
                        activas[(int)inicio_sesion + i] = true;
                }
            }

            //Se calcula el número de clases ya asignadas poniendo como asignadas las horas que no se van a programar
            //según las horas seleccionadas
            foreach (SesionAuxiliar obj in _lista_sesiones)
            {
                if (obj.Estado > 1)
                {
                    _sesiones_asignadas++;
                }
                else
                {
                    int indice = _lista_sesiones.IndexOf(obj);
                    if (indice < 70)
                    {
                        int indice_dia = indice % 14;
                        if (!activas[indice_dia])
                        {
                            obj.Estado = 2;
                            _sesiones_asignadas++;
                        }
                    }
                }
                if ((obj.OidClasePractica != 0 && index_practica == 0) ||
                    index_practica > 0 && index_practica < 5)
                {
                    if (obj.Estado != 3)
                        obj.Estado = 2;
                    if (index_practica == 0
                        && obj.Estado == 3)
                        _practicas_restantes--;
                    index_practica++;
                    _sesiones_asignadas++;
                }
                if (index_practica == 5) index_practica = 0;
            }

            List<List<long>> incompatibles = new List<List<long>>();

            for (int i = 0; i < 5; i++)
                incompatibles.Add(new List<long>());

            long num_sesiones_asignadas = 0;
            long total_asignadas = 0;

            bool practica_asignada = true;
            bool teorica_asignada = false;

            do
            {
                total_asignadas = num_sesiones_asignadas;

                //CLASES PRACTICAS
                practica_asignada = true;

                while (!PracticasTotalesAsignadas() && practica_asignada)
                {
                    int n_horas = 0;

                    //Sesión del sábado
                    if (SesionDisponible(70, 5))
                    {
                        practica_asignada = AsignaSesionPractica(no_asignables, 70, out n_horas);
                    }

                    //Resto de sesiones
                    int hora_incial = BuscaSesionPracticaLibre(5);
                    if (hora_incial != -1)
                    {
                        practica_asignada = AsignaSesionPractica(no_asignables, hora_incial, out n_horas);
                    }
                    else
                        practica_asignada = false;

                    if (practica_asignada)
                        num_sesiones_asignadas += n_horas;
                }

                //TEORICAS

                for (int hora_inicial = 0; hora_inicial < _lista_sesiones.Count; hora_inicial++)
                {
                    int n_horas = 0;
                    hora_inicial = GetSiguienteSesionLibre(out n_horas, hora_inicial);

                    if (hora_inicial == -1) break;
                    teorica_asignada = AsignaSesionTeorica(no_asignables, hora_inicial, n_horas);

                    if (teorica_asignada)
                    {
                        num_sesiones_asignadas += n_horas;
                        break;
                    }
                    else
                    {
                        int total_horas = 0;
                        teorica_asignada = ReasignaSesionTeorica(no_asignables, hora_inicial, n_horas, out total_horas);

                        if (teorica_asignada)
                        {                            
                            num_sesiones_asignadas += total_horas;
                            break;
                        }
                    }
                }

            } while (num_sesiones_asignadas < _sesiones_asignadas
                && total_asignadas != num_sesiones_asignadas);

            //RellenaLibres(no_asignables);
            //MarcaDesordenadas();
            OrdenaHorario(_lista_sesiones.Count);
        }

        private void MarcaDesordenadas()
        {
            foreach (SesionAuxiliar item in _lista_sesiones)
            {
                int index = _lista_sesiones.IndexOf(item);

                if (item.OidClaseTeorica > 0)
                { 
                    int i = 0;
                    ClaseTeoricaInfo teorica = _teoricas.GetItem(item.OidClaseTeorica);

                    for (int j = index + 1; j < _lista_sesiones.Count; j++)
                    {
                        if (_lista_sesiones[j].OidClaseTeorica > 0)
                        {
                            ClaseTeoricaInfo aux = _teoricas.GetItem(_lista_sesiones[j].OidClaseTeorica);

                            if (aux.OrdenPrimario < teorica.OrdenPrimario ||
                            (aux.OrdenPrimario == teorica.OrdenPrimario
                            && aux.OrdenSecundario < teorica.OrdenSecundario) ||
                            (aux.OrdenPrimario == teorica.OrdenPrimario
                            && aux.OrdenSecundario == teorica.OrdenSecundario
                            && aux.OrdenTerciario < teorica.OrdenTerciario))
                            {
                                item.Desordenada = true;
                                break;
                            }
                        }
                    }

                    while (item.OidClaseTeorica != _teoricas[i].Oid
                        && !item.Desordenada)
                    {
                        if (_teoricas[i].EEstadoClase == EEstadoClase.Programada)
                        {
                            i++;
                            continue;
                        }

                        if (_teoricas[i].OrdenPrimario < teorica.OrdenPrimario ||
                            (_teoricas[i].OrdenPrimario == teorica.OrdenPrimario
                            && _teoricas[i].OrdenSecundario < teorica.OrdenSecundario) ||
                            (_teoricas[i].OrdenPrimario == teorica.OrdenPrimario
                            && _teoricas[i].OrdenSecundario == teorica.OrdenSecundario
                            && _teoricas[i].OrdenTerciario < teorica.OrdenTerciario))
                            item.Desordenada = true;
                        i++;
                    }
                }

                if (item.OidClasePractica > 0)
                {
                    int i = 0;
                    ClasePracticaInfo practica = _practicas[(int)item.Grupo].GetItem(item.OidClasePractica);

                    for (int j = index + 1; j < _lista_sesiones.Count ; j++)
                    {
                        if (_lista_sesiones[j].OidClasePractica > 0
                            && _lista_sesiones[j].Grupo == item.Grupo
                            && _lista_sesiones[j].OidClasePractica != item.OidClasePractica)
                        {
                            ClasePracticaInfo aux = _practicas[(int)_lista_sesiones[j].Grupo].GetItem(_lista_sesiones[j].OidClasePractica);

                            if (aux.OrdenPrimario < practica.OrdenPrimario ||
                            (aux.OrdenPrimario == practica.OrdenPrimario
                            && aux.OrdenSecundario < practica.OrdenSecundario) ||
                            (aux.OrdenPrimario == practica.OrdenPrimario
                            && aux.OrdenSecundario == practica.OrdenSecundario
                            && aux.OrdenTerciario < practica.OrdenTerciario))
                            {
                                item.Desordenada = true;
                                break;
                            }
                        }
                    } 
                    
                    for (int j = index - 1; j >= 0; j--)
                    {
                        if (_lista_sesiones[j].OidClasePractica == 0)
                            break;

                        if (_lista_sesiones[j].OidClasePractica > 0
                            && _lista_sesiones[j].Grupo == item.Grupo
                            && _lista_sesiones[j].OidClasePractica == item.OidClasePractica)
                        {
                            item.Desordenada = _lista_sesiones[j].Desordenada;
                            break;
                        }
                    }

                    while (item.OidClasePractica != _practicas[(int)item.Grupo][i].Oid
                        && !item.Desordenada)
                    {
                        if (_practicas[(int)item.Grupo][i].EEstadoClase == EEstadoClase.Programada)
                        {
                            i++;
                            continue;
                        }

                        if (_practicas[(int)item.Grupo][i].OrdenPrimario < practica.OrdenPrimario ||
                            (_practicas[(int)item.Grupo][i].OrdenPrimario == practica.OrdenPrimario
                            && _practicas[(int)item.Grupo][i].OrdenSecundario < practica.OrdenSecundario) ||
                            (_practicas[(int)item.Grupo][i].OrdenPrimario == practica.OrdenPrimario
                            && _practicas[(int)item.Grupo][i].OrdenSecundario == practica.OrdenSecundario
                            && _practicas[(int)item.Grupo][i].OrdenTerciario < practica.OrdenTerciario))
                            item.Desordenada = true;

                        i++;
                    }
                }
            }
        }

        #endregion

    }
}

