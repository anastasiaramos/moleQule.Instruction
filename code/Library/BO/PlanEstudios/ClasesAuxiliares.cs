using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Collections;

using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
    public class Clase
    {
        private string _titulo = string.Empty;
        private long _oid = 0;
        private long _oid_submodulo = 0;
        private long _oid_modulo = 0;
        private object _tipo = 0;
        private long _orden_primario = 0;
        private long _orden_secundario = 0;
        private long _orden_terciario = 0;
        private long _estado = 1;
        private long _incompatible;
        private long _grupo = 3;
        private string _modulo = string.Empty;
        private string _submodulo = string.Empty;
        private string _alias = string.Empty;
        private string _tipo_clase = string.Empty;

        public string Titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                if (!_titulo.Equals(value))
                {
                    _titulo = value;
                }
            }
        }
        public virtual long Oid
        {
            get
            {
                return _oid;
            }
            set
            {
                if (!_oid.Equals(value))
                {
                    _oid = value;
                }
            }
        }
        public virtual long OidSubmodulo
        {
            get
            {
                return _oid_submodulo;
            }
            set
            {
                if (!_oid_submodulo.Equals(value))
                {
                    _oid_submodulo = value;
                }
            }
        }
        public virtual long OidModulo
        {
            get
            {
                return _oid_modulo;
            }
            set
            {
                if (!_oid_modulo.Equals(value))
                {
                    _oid_modulo = value;
                }
            }
        }
        public virtual object Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                if (!_tipo.Equals(value))
                {
                    _tipo = value;
                }
            }
        }
        public virtual long OrdenPrimario
        {
            get
            {
                return _orden_primario;
            }
            set
            {
                if (!_orden_primario.Equals(value))
                {
                    _orden_primario = value;
                }
            }
        }
        public virtual long OrdenSecundario
        {
            get
            {
                return _orden_secundario;
            }
            set
            {
                if (!_orden_secundario.Equals(value))
                {
                    _orden_secundario = value;
                }
            }
        }
        public virtual long OrdenTerciario
        {
            get
            {
                return _orden_terciario;
            }
            set
            {
                if (!_orden_terciario.Equals(value))
                {
                    _orden_terciario = value;
                }
            }
        }
        public virtual long Estado
        {
            get
            {
                return _estado;
            }
            set
            {
                if (!_estado.Equals(value))
                {
                    _estado = value;
                }
            }
        }
        public virtual long Incompatible
        {
            get
            {
                return _incompatible;
            }
            set
            {
                if (!_incompatible.Equals(value))
                {
                    _incompatible = value;
                }
            }
        }
        public virtual long Grupo
        {
            get
            {
                return _grupo;
            }
            set
            {
                if (!_grupo.Equals(value))
                {
                    _grupo = value;
                }
            }
        }
        public string Modulo
        {
            get
            {
                return _modulo;
            }
            set
            {
                if (!_modulo.Equals(value))
                {
                    _modulo = value;
                }
            }
        }
        public string Submodulo
        {
            get
            {
                return _submodulo;
            }
            set
            {
                if (!_submodulo.Equals(value))
                {
                    _submodulo = value;
                }
            }
        }
        public string Alias
        {
            get
            {
                return _alias;
            }
            set
            {
                if (!_alias.Equals(value))
                {
                    _alias = value;
                }
            }
        }
        public string TipoClase
        {
            get
            {
                return _tipo_clase;
            }
            set
            {
                if (!_tipo_clase.Equals(value))
                {
                    _tipo_clase = value;
                }
            }
        }

        public Clase(long oid, string titulo, long oid_submodulo, object tipo)
        {
            this.Oid = oid;
            this.Titulo = titulo;
            this.OidSubmodulo = oid_submodulo;
            this.Tipo = tipo;
        }

        public Clase()
        {

        }

        public Clase(ClaseTeoricaInfo clase)
        {
            this.Titulo = clase.Titulo;
            this.Oid = clase.Oid;
            this.OidSubmodulo = clase.OidSubmodulo;
            this.OidModulo = clase.OidModulo;
            this.Tipo = 0;
            this.OrdenPrimario = clase.OrdenPrimario;
            this.OrdenSecundario = clase.OrdenSecundario;
            this.OrdenTerciario = clase.OrdenTerciario;
            this.Estado = 1;
            this.Incompatible = 0;
            this.Modulo = clase.Modulo;
            this.Submodulo = clase.Submodulo;
            this.Alias = clase.Alias;
            this.TipoClase = "Teórica";
        }

        public Clase(ClasePracticaInfo clase)
        {
            this.Titulo = clase.Titulo;
            this.Oid = clase.Oid;
            this.OidSubmodulo = clase.OidSubmodulo;
            this.OidModulo = clase.OidModulo;
            this.Tipo = 1;
            this.OrdenPrimario = clase.OrdenPrimario;
            this.OrdenSecundario = clase.OrdenSecundario;
            this.OrdenTerciario = clase.OrdenTerciario;
            this.Estado = 1;
            this.Incompatible = clase.Incompatible;
            this.Modulo = clase.Modulo;
            this.Submodulo = clase.Submodulo;
            this.Alias = clase.Alias;
            this.TipoClase = "Práctica";
            this.Grupo = clase.Grupo;
        }

        public Clase(ClaseExtraInfo clase)
        {
            if (clase == null) return;
            this.Titulo = clase.Titulo;
            this.Oid = clase.Oid;
            this.OidSubmodulo = clase.OidSubmodulo;
            this.OidModulo = clase.OidModulo;
            this.Tipo = 2;
            this.Estado = 1;
            this.Incompatible = 0;
            this.Modulo = clase.Modulo;
            this.Submodulo = clase.Submodulo;
            this.Alias = clase.Alias;
            this.TipoClase = "Extra";
        }
    }

    public class ListaClases : List<Clase>
    {
        public ListaClases()
        {
        }

        private static int CompareClasesbyOrder(Clase x, Clase y)
        {
            if (x.OrdenPrimario == y.OrdenPrimario)
            {
                if (x.OrdenSecundario == y.OrdenSecundario)
                {
                    if (x.OrdenTerciario == y.OrdenTerciario)
                    {
                        if (x.Submodulo == y.Submodulo)
                        {
                            if (x.Grupo == y.Grupo)
                                return 0;
                            else
                            {
                                if (x.Grupo < y.Grupo)
                                    return -1;
                                else
                                    return 1;
                            }
                        }
                        else
                            return x.Submodulo.CompareTo(y.Submodulo);
                    }
                    else
                    {
                        if (x.OrdenTerciario < y.OrdenTerciario)
                            return -1;
                        else
                            return 1;
                    }
                }
                else
                {
                    if (x.OrdenSecundario < y.OrdenSecundario)
                        return -1;
                    else
                        return 1;
                }
            }
            else
            {
                if (x.OrdenPrimario < y.OrdenPrimario)
                    return -1;
                else
                    return 1;
            }
        }

        public static BindingList<Clase> GetList(ClaseTeoricaList teoricas, ClasePracticaList practicas, ClaseExtraList extras)
        {
            BindingList<Clase> list = new BindingList<Clase>();

            if (teoricas != null)
                foreach (ClaseTeoricaInfo item in teoricas)
                    list.Add(new Clase(item));
            if (practicas != null)
                foreach (ClasePracticaInfo item in practicas)
                    list.Add(new Clase(item));
            if (extras != null)
                foreach (ClaseExtraInfo item in extras)
                    list.Add(new Clase(item));

            return list;

        }

        public ListaClases OrdenaLista()
        {
            this.Sort(CompareClasesbyOrder);
            return this;
        }

    }

    public class Profesor
    {
        private long _oid = 0;
        private long _prioridad = 0;
        private long _oid_submodulo = 0;
        private List<bool> _semana = new List<bool>();
        private long _clases_semanales = 0;

        public virtual long Oid
        {
            get
            {
                return _oid;
            }
            set
            {
                if (!_oid.Equals(value))
                {
                    _oid = value;
                }
            }
        }
        public virtual long Prioridad
        {
            get
            {
                return _prioridad;
            }
            set
            {
                if (!_prioridad.Equals(value))
                {
                    _prioridad = value;
                }
            }
        }
        public virtual long OidSubmodulo
        {
            get
            {
                return _oid_submodulo;
            }
            set
            {
                if (!_oid_submodulo.Equals(value))
                {
                    _oid_submodulo = value;
                }
            }
        }
        public virtual List<bool> Semana
        {
            get
            {
                return _semana;
            }
            set
            {
                _semana = value;
            }
        }
        public virtual long ClasesSemanales
        {
            get
            {
                return _clases_semanales;
            }
            set
            {
                if (!_clases_semanales.Equals(value))
                {
                    _clases_semanales = value;
                }
            }
        }

        public Profesor()
        {
            for (int i = 0; i < 10; i++)
                _semana.Add(false);
        }
    }

    public class ListaProfesores : List<Profesor>
    {
        public ListaProfesores()
        {
        }

        public ListaProfesores GetListaCapacitados(long oid_submodulo)
        {
            ListaProfesores lista = new ListaProfesores();
            foreach (Profesor profesor in this)
            {
                if (profesor.OidSubmodulo == oid_submodulo)
                    lista.Add(profesor);
            }

            return lista;
        }
    }

    public class SesionAuxiliar
    {
        private long _oid_clase_teorica = 0;
        private long _oid_clase_practica = 0;
        private long _oid_clase_extra = 0;
        private long _oid_profesor = 0;
        private long _orden_primario = 0;
        private long _orden_secundario = 0;
        private long _orden_terciario = 0;
        private long _oid_modulo = 0;
        private long _oid_submodulo = 0;
        private DateTime _fecha;
        private DateTime _hora;
        private long _estado = 1;
        private bool _forzada = false;
        private bool _seleccionada = false;
        private string _titulo = string.Empty;
        private bool _desordenada = false;
        private long _grupo = 3;
        private bool _activa = true;
        private long _incompatible = 0;

        public virtual long OidClaseTeorica
        {
            get
            {
                return _oid_clase_teorica;
            }
            set
            {
                if (!_oid_clase_teorica.Equals(value))
                {
                    _oid_clase_teorica = value;
                }
            }
        }
        public virtual long OidClasePractica
        {
            get
            {
                return _oid_clase_practica;
            }
            set
            {
                if (!_oid_clase_practica.Equals(value))
                {
                    _oid_clase_practica = value;
                }
            }
        }
        public virtual long OidClaseExtra
        {
            get
            {
                return _oid_clase_extra;
            }
            set
            {
                if (!_oid_clase_extra.Equals(value))
                {
                    _oid_clase_extra = value;
                }
            }
        }
        public virtual long OidProfesor
        {
            get
            {
                return _oid_profesor;
            }
            set
            {
                if (!_oid_profesor.Equals(value))
                {
                    _oid_profesor = value;
                }
            }
        }
        public virtual long OrdenPrimario
        {
            get
            {
                return _orden_primario;
            }
            set
            {
                if (!_orden_primario.Equals(value))
                {
                    _orden_primario = value;
                }
            }
        }
        public virtual long OrdenSecundario
        {
            get
            {
                return _orden_secundario;
            }
            set
            {
                if (!_orden_secundario.Equals(value))
                {
                    _orden_secundario = value;
                }
            }
        }
        public virtual long OrdenTerciario
        {
            get
            {
                return _orden_terciario;
            }
            set
            {
                if (!_orden_terciario.Equals(value))
                {
                    _orden_terciario = value;
                }
            }
        }
        public virtual DateTime Fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                if (!_fecha.Equals(value))
                {
                    _fecha = value;
                }
            }
        }
        public virtual DateTime Hora
        {
            get
            {
                return _hora;
            }
            set
            {
                if (!_hora.Equals(value))
                {
                    _hora = value;
                }
            }
        }
        public virtual long Estado
        {
            get
            {
                return _estado;
            }
            set
            {
                if (!_estado.Equals(value))
                {
                    _estado = value;
                }
            }
        }
        public virtual bool Forzada
        {
            get
            {
                return _forzada;
            }
            set
            {
                if (!_forzada.Equals(value))
                {
                    _forzada = value;
                }
            }
        }
        public virtual bool Seleccionada
        {
            get
            {
                return _seleccionada;
            }
            set
            {
                if (!_seleccionada.Equals(value))
                {
                    _seleccionada = value;
                }
            }
        }
        public virtual long OidModulo
        {
            get
            {
                return _oid_modulo;
            }
            set
            {
                if (!_oid_modulo.Equals(value))
                {
                    _oid_modulo = value;
                }
            }
        }
        public virtual long OidSubmodulo
        {
            get
            {
                return _oid_submodulo;
            }
            set
            {
                if (!_oid_submodulo.Equals(value))
                {
                    _oid_submodulo = value;
                }
            }
        }
        public virtual string Titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                if (!_titulo.Equals(value))
                {
                    _titulo = value;
                }
            }
        }
        public virtual bool Desordenada
        {
            get
            {
                return _desordenada;
            }
            set
            {
                if (!_desordenada.Equals(value))
                {
                    _desordenada = value;
                }
            }
        }
        public virtual long Grupo
        {
            get
            {
                return _grupo;
            }
            set
            {
                if (!_grupo.Equals(value))
                {
                    _grupo = value;
                }
            }
        }
        public virtual bool Activa
        {
            get
            {
                return _activa;
            }
            set
            {
                if (!_activa.Equals(value))
                {
                    _activa = value;
                }
            }
        }
        public virtual long Incompatible
        {
            get
            {
                return _incompatible;
            }
            set
            {
                if (!_incompatible.Equals(value))
                {
                    _incompatible = value;
                }
            }
        }

        public virtual long Laboratorio { get { return _incompatible; } }
        public virtual EEstadoClase EEstadoClase { get { return (EEstadoClase)_estado; } set { _estado = (long)value; } }

        public SesionAuxiliar(string hora)
        {
            this.Hora = DateTime.Parse(hora);
            this.Fecha = DateTime.Parse(hora);
        }

        public SesionAuxiliar()
        { }

        public void AsignaClaseASesion(ClaseExtraInfo clase)
        {
            if (clase != null)
            {
                this.OidClaseExtra = clase.Oid;
                this.OidClasePractica = 0;
                this.OidClaseTeorica = 0;
                this.Incompatible = 0;

                this.OrdenPrimario = 0;
                this.OrdenSecundario = 0;
                this.OrdenTerciario = 0;
                this.Estado = 2;
                this.OidModulo = clase.OidModulo;
                this.Titulo = clase.Titulo;
                this.OidSubmodulo = clase.OidSubmodulo;
                this.Forzada = false;
                this.Seleccionada = false;
                this.Desordenada = false;
                this.OidProfesor = 0;
            }
            else
            {

                this.OidClaseExtra = 0;
                this.OidClasePractica = 0;
                this.OidClaseTeorica = 0;
                this.Incompatible = 0;
                this.OrdenPrimario = 0;
                this.OrdenSecundario = 0;
                this.OrdenTerciario = 0;
                this.Estado = 1;
                this.Grupo = 3;
                this.OidModulo = 0;
                this.OidSubmodulo = 0;
                this.OidProfesor = 0;
                this.Titulo = string.Empty;
                this.Seleccionada = false;
                this.Forzada = false;
                this.Desordenada = false;
            }
        }

        public void AsignaClaseASesion(ClaseTeoricaInfo clase)
        {
            if (clase != null)
            {
                this.OidClaseTeorica = clase.Oid;
                this.OidClaseExtra = 0;
                this.OidClasePractica = 0;
                this.Incompatible = 0;

                this.OrdenPrimario = clase.OrdenPrimario;
                this.OrdenSecundario = clase.OrdenSecundario;
                this.OrdenTerciario = clase.OrdenTerciario;
                this.Estado = 2;
                this.OidModulo = clase.OidModulo;
                this.Titulo = clase.Alias;
                this.OidSubmodulo = clase.OidSubmodulo;
                this.Forzada = false;
                this.Seleccionada = false;
                this.Desordenada = false;
                this.OidProfesor = 0;
                this.Grupo = 3;
            }
            else
            {

                this.OidClaseExtra = 0;
                this.OidClasePractica = 0;
                this.OidClaseTeorica = 0;
                this.Incompatible = 0;

                this.OrdenPrimario = 0;
                this.OrdenSecundario = 0;
                this.OrdenTerciario = 0;
                this.Estado = 1;
                this.Grupo = 3;
                this.OidModulo = 0;
                this.OidSubmodulo = 0;
                this.OidProfesor = 0;
                this.Titulo = string.Empty;
                this.Seleccionada = false;
                this.Forzada = false;
                this.Desordenada = false;
            }
        }

        public void AsignaClaseASesion(ClasePracticaInfo clase)
        {
            if (clase != null)
            {
                this.OidClasePractica = clase.Oid;
                this.OidClaseExtra = 0;
                this.OidClaseTeorica = 0;
                this.Incompatible = clase.Incompatible;

                this.OrdenPrimario = clase.OrdenPrimario;
                this.OrdenSecundario = clase.OrdenSecundario;
                this.OrdenTerciario = clase.OrdenTerciario;
                this.Estado = 2;
                this.OidModulo = clase.OidModulo;
                this.Titulo = clase.Alias;
                this.OidSubmodulo = clase.OidSubmodulo;
                this.Grupo = clase.Grupo;
                this.Forzada = false;
                this.Seleccionada = false;
                this.Desordenada = false;
                this.OidProfesor = 0;
            }
            else
            {

                this.OidClaseExtra = 0;
                this.OidClasePractica = 0;
                this.OidClaseTeorica = 0;
                this.Incompatible = 0;

                this.OrdenPrimario = 0;
                this.OrdenSecundario = 0;
                this.OrdenTerciario = 0;
                this.Estado = 1;
                this.OidModulo = 0;
                this.OidSubmodulo = 0;
                this.OidProfesor = 0;
                this.Grupo = 3;
                this.Titulo = string.Empty;
                this.Seleccionada = false;
                this.Forzada = false;
                this.Desordenada = false;
            }
        }

        public void IntercambiaSesion(SesionAuxiliar sesion, bool profesor)
        {
            SesionAuxiliar aux = new SesionAuxiliar();

            aux.Copia(this, true);
            this.Copia(sesion, profesor);
            sesion.Copia(aux, profesor);
        }

        public void Copia(SesionAuxiliar sesion, bool profesor)
        {
            this.OidClaseTeorica = sesion.OidClaseTeorica;
            this.OidClasePractica = sesion.OidClasePractica;
            this.OidClaseExtra = sesion.OidClaseExtra;
            this.Incompatible = sesion.Incompatible;
            this.OrdenPrimario = sesion.OrdenPrimario;
            this.OrdenSecundario = sesion.OrdenSecundario;
            this.OrdenTerciario = sesion.OrdenTerciario;
            this.Titulo = sesion.Titulo;
            this.OidModulo = sesion.OidModulo;
            this.OidSubmodulo = sesion.OidSubmodulo;
            this.Grupo = sesion.Grupo;
            this.Estado = sesion.Estado;
            if (profesor)
                this.OidProfesor = sesion.OidProfesor;
        }

        public void AsignaSesion(Sesion sesion, ClaseTeoricaList teoricas, ClasePracticaList practicas,
            ClaseExtraList extras)
        {
            this.OidClaseTeorica = sesion.OidClaseTeorica;
            this.OidClasePractica = sesion.OidClasePractica;
            this.OidClaseExtra = sesion.OidClaseExtra;
            this.OidProfesor = sesion.OidProfesor;
            this.Forzada = sesion.Forzada;
            this.Estado = sesion.Estado;
            this.Grupo = sesion.Grupo;

            if (sesion.OidClaseTeorica != 0)
            {
                if (sesion.OidClaseTeorica < 0)
                {
                    this.OrdenPrimario = 0;
                    this.OrdenSecundario = 0;
                    this.OrdenTerciario = 0;
                    this.OidModulo = 0;
                    this.OidSubmodulo = 0;
                    if (sesion.OidClaseTeorica == -1)
                        this.Titulo = "LIBRE";
                    else
                        this.Titulo = "NO ASIGNADA";
                }
                else
                {
                    ClaseTeoricaInfo clase = teoricas.GetItem(sesion.OidClaseTeorica);
                    if (clase != null)
                    {
                        this.OrdenPrimario = clase.OrdenPrimario;
                        this.OrdenSecundario = clase.OrdenSecundario;
                        this.OrdenTerciario = clase.OrdenTerciario;
                        this.OidModulo = clase.OidModulo;
                        this.OidSubmodulo = clase.OidSubmodulo;
                        this.Titulo = clase.Alias;
                    }
                    else
                    {
                        this.OidClaseTeorica = 0;
                        this.OrdenPrimario = 0;
                        this.OrdenSecundario = 0;
                        this.OrdenTerciario = 0;
                        this.OidModulo = 0;
                        this.OidSubmodulo = 0;
                        this.Titulo = string.Empty;
                    }
                }
            }
            else
            {
                if (sesion.OidClasePractica != 0)
                {
                    while (this.OrdenPrimario == 0 || this.OrdenSecundario == 0 || this.OrdenTerciario == 0 ||
                    this.OidModulo == 0 || this.OidSubmodulo == 0)
                    {
                        ClasePracticaInfo clase = null;

                        foreach (ClasePracticaInfo item in practicas)
                        {
                            if (item.Oid == sesion.OidClasePractica
                                && item.Grupo == sesion.Grupo)
                            {
                                clase = item;
                                break;
                            }
                        }

                        if (clase != null)
                        {
                            this.Incompatible = clase.Incompatible;
                            this.OrdenPrimario = clase.OrdenPrimario;
                            this.OrdenSecundario = clase.OrdenSecundario;
                            this.OrdenTerciario = clase.OrdenTerciario;
                            this.OidModulo = clase.OidModulo;
                            this.OidSubmodulo = clase.OidSubmodulo;
                            this.Titulo = clase.Alias;
                        }
                        else
                        {
                            this.OidClasePractica = 0;
                            this.Incompatible = 0;
                            this.OrdenPrimario = 0;
                            this.OrdenSecundario = 0;
                            this.OrdenTerciario = 0;
                            this.OidModulo = 0;
                            this.OidSubmodulo = 0;
                            this.Titulo = string.Empty;
                        }
                    }
                }
                else
                {
                    if (sesion.OidClaseExtra != 0)
                    {
                        ClaseExtraInfo clase = extras.GetItem(sesion.OidClaseExtra);
                        if (clase != null)
                        {
                            this.OidModulo = clase.OidModulo;
                            this.OidSubmodulo = clase.OidSubmodulo;
                            this.Titulo = clase.Alias;
                        }
                        else
                        {
                            this.OidClaseExtra = 0;
                            this.OidModulo = 0;
                            this.OidSubmodulo = 0;
                            this.Titulo = string.Empty;
                        }
                    }
                }
            }
        }

        public void AsignaSesion(SesionInfo sesion, ClaseTeoricaList teoricas, ClasePracticaList practicas,
            ClaseExtraList extras)
        {
            this.OidClaseTeorica = sesion.OidClaseTeorica;
            this.OidClasePractica = sesion.OidClasePractica;
            this.OidClaseExtra = sesion.OidClaseExtra;
            this.OidProfesor = sesion.OidProfesor;
            this.Forzada = sesion.Forzada;
            this.Estado = sesion.Estado;
            this.Grupo = sesion.Grupo;

            if (sesion.OidClaseTeorica != 0)
            {
                if (sesion.OidClaseTeorica < 0)
                {
                    this.OrdenPrimario = 0;
                    this.OrdenSecundario = 0;
                    this.OrdenTerciario = 0;
                    this.OidModulo = 0;
                    this.OidSubmodulo = 0;
                    if (sesion.OidClaseTeorica == -1)
                        this.Titulo = "LIBRE";
                    else
                        this.Titulo = "NO ASIGNADA";
                }
                else
                {
                    ClaseTeoricaInfo clase = teoricas.GetItem(sesion.OidClaseTeorica);
                    if (clase != null)
                    {
                        this.OrdenPrimario = clase.OrdenPrimario;
                        this.OrdenSecundario = clase.OrdenSecundario;
                        this.OrdenTerciario = clase.OrdenTerciario;
                        this.OidModulo = clase.OidModulo;
                        this.OidSubmodulo = clase.OidSubmodulo;
                        this.Titulo = clase.Alias;
                    }
                    else
                    {
                        this.OidClaseTeorica = 0;
                        this.OrdenPrimario = 0;
                        this.OrdenSecundario = 0;
                        this.OrdenTerciario = 0;
                        this.OidModulo = 0;
                        this.OidSubmodulo = 0;
                        this.Titulo = string.Empty;
                    }
                }
            }
            else
            {
                if (sesion.OidClasePractica != 0)
                {
                    while (this.OrdenPrimario == 0 || this.OrdenSecundario == 0 || this.OrdenTerciario == 0 ||
                    this.OidModulo == 0 || this.OidSubmodulo == 0)
                    {
                        ClasePracticaInfo clase = null;

                        foreach (ClasePracticaInfo item in practicas)
                        {
                            if (item.Oid == sesion.OidClasePractica
                                && item.Grupo == sesion.Grupo)
                            {
                                clase = item;
                                break;
                            }
                        }

                        if (clase != null)
                        {
                            this.Incompatible = clase.Incompatible;
                            this.OrdenPrimario = clase.OrdenPrimario;
                            this.OrdenSecundario = clase.OrdenSecundario;
                            this.OrdenTerciario = clase.OrdenTerciario;
                            this.OidModulo = clase.OidModulo;
                            this.OidSubmodulo = clase.OidSubmodulo;
                            this.Titulo = clase.Alias;
                        }
                        else
                        {
                            this.OidClasePractica = 0;
                            this.Incompatible = 0;
                            this.OrdenPrimario = 0;
                            this.OrdenSecundario = 0;
                            this.OrdenTerciario = 0;
                            this.OidModulo = 0;
                            this.OidSubmodulo = 0;
                            this.Titulo = string.Empty;
                        }
                    }
                }
                else
                {
                    if (sesion.OidClaseExtra != 0)
                    {
                        ClaseExtraInfo clase = extras.GetItem(sesion.OidClaseExtra);
                        if (clase != null)
                        {
                            this.OidModulo = clase.OidModulo;
                            this.OidSubmodulo = clase.OidSubmodulo;
                            this.Titulo = clase.Alias;
                        }
                        else
                        {
                            this.OidClaseExtra = 0;
                            this.OidModulo = 0;
                            this.OidSubmodulo = 0;
                            this.Titulo = string.Empty;
                        }
                    }
                }
            }
        }


    }

    public class SesionNoAsignable
    {
        private int _index = 0;
        private long _oid_modulo = 0;
        private long _oid_instructor = 0;

        public virtual int Index
        {
            get
            {
                return _index;
            }
            set
            {
                if (!_index.Equals(value))
                {
                    _index = value;
                }
            }
        }
        public virtual long OidModulo
        {
            get
            {
                return _oid_modulo;
            }
            set
            {
                if (!_oid_modulo.Equals(value))
                {
                    _oid_modulo = value;
                }
            }
        }
        public virtual long OidInstructor
        {
            get
            {
                return _oid_instructor;
            }
            set
            {
                if (!_oid_instructor.Equals(value))
                {
                    _oid_instructor = value;
                }
            }
        }

        public SesionNoAsignable(int index, long oid_modulo, long oid_instructor)
        {
            _index = index;
            _oid_modulo = oid_modulo;
            _oid_instructor = oid_instructor;
        }
    }

    public class ListaSesiones : List<SesionAuxiliar>
    {
        public ListaSesiones(DateTime fecha)
        {
            string hora;
            for (int i = 0; i < 6; i++)
            {
                if (i != 5)
                {
                    hora = fecha.ToShortDateString() + " 8:00";
                    this.Add(new SesionAuxiliar(hora));
                }

                hora = fecha.ToShortDateString() + " 9:00";
                this.Add(new SesionAuxiliar(hora));

                hora = fecha.ToShortDateString() + " 10:00";
                this.Add(new SesionAuxiliar(hora));

                hora = fecha.ToShortDateString() + " 11:00";
                this.Add(new SesionAuxiliar(hora));

                hora = fecha.ToShortDateString() + " 12:00";
                this.Add(new SesionAuxiliar(hora));

                hora = fecha.ToShortDateString() + " 13:00";
                this.Add(new SesionAuxiliar(hora));

                if (i != 5)
                {
                    hora = fecha.ToShortDateString() + " 14:00";
                    this.Add(new SesionAuxiliar(hora));

                    hora = fecha.ToShortDateString() + " 15:00";
                    this.Add(new SesionAuxiliar(hora));

                    hora = fecha.ToShortDateString() + " 16:00";
                    this.Add(new SesionAuxiliar(hora));

                    hora = fecha.ToShortDateString() + " 17:00";
                    this.Add(new SesionAuxiliar(hora));

                    hora = fecha.ToShortDateString() + " 18:00";
                    this.Add(new SesionAuxiliar(hora));

                    hora = fecha.ToShortDateString() + " 19:00";
                    this.Add(new SesionAuxiliar(hora));

                    hora = fecha.ToShortDateString() + " 20:00";
                    this.Add(new SesionAuxiliar(hora));

                    hora = fecha.ToShortDateString() + " 21:00";
                    this.Add(new SesionAuxiliar(hora));
                }

                fecha = fecha.AddDays(1);

            }
        }


        public ListaSesiones()
        {
        }


        public void CambiaClase(int index, long oid_clase, long tipo, long grupo, List<int> lista)
        {
            if (this[index].OidClaseTeorica > 0)
                tipo = 0;
            else
            {
                if (this[index].OidClasePractica > 0)
                    tipo = 1;
                else
                {
                    if (this[index].OidClaseExtra > 0)
                        tipo = 2;
                }
            }

            foreach (SesionAuxiliar aux in this)
            {
                if (tipo == 0)
                {
                    int indice = this.IndexOf(aux);
                    if (aux.OidClaseTeorica == oid_clase && index != indice)
                    {
                        aux.AsignaClaseASesion((ClaseTeoricaInfo)null);
                        lista.Add(indice);
                    }
                }
                else
                {
                    if (tipo == 1)
                    {
                        int indice = this.IndexOf(aux);
                        if (aux.OidClasePractica == oid_clase && aux.Grupo == grupo && index != indice)
                        {
                            aux.AsignaClaseASesion((ClaseTeoricaInfo)null);
                            lista.Add(indice);
                        }
                    }
                    else
                    {
                        int indice = this.IndexOf(aux);
                        if (aux.OidClaseExtra == oid_clase && indice != index)
                        {
                            aux.AsignaClaseASesion((ClaseTeoricaInfo)null);
                            lista.Add(indice);
                        }
                    }
                }
            }
        }
    }

    public class SCronogramaAuxiliar
    {
        private long _oid_clase_teorica;
        private long _oid_clase_practica;
        private long _estado = 1;
        private long _oid_submodulo;
        private long _oid_modulo;
        private long _tipo;
        private string _titulo = string.Empty;
        private string _modulo = string.Empty;

        public long OidClaseTeorica
        {
            get
            {
                return _oid_clase_teorica;
            }
            set
            {
                if (!_oid_clase_teorica.Equals(value))
                {
                    _oid_clase_teorica = value;
                }
            }
        }
        public long OidClasePractica
        {
            get
            {
                return _oid_clase_practica;
            }
            set
            {
                if (!_oid_clase_practica.Equals(value))
                {
                    _oid_clase_practica = value;
                }
            }
        }
        public long Estado
        {
            get
            {
                return _estado;
            }
            set
            {
                if (!_estado.Equals(value))
                {
                    _estado = value;
                }
            }
        }
        public long OidSubmodulo
        {
            get
            {
                return _oid_submodulo;
            }
            set
            {
                if (!_oid_submodulo.Equals(value))
                {
                    _oid_submodulo = value;
                }
            }
        }
        public long OidModulo
        {
            get
            {
                return _oid_modulo;
            }
            set
            {
                if (!_oid_modulo.Equals(value))
                {
                    _oid_modulo = value;
                }
            }
        }
        public long Tipo
        {
            get
            {
                return _tipo;
            }
            set
            {
                if (!_tipo.Equals(value))
                {
                    _tipo = value;
                }
            }
        }
        public string Titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                if (!_titulo.Equals(value))
                {
                    _titulo = value;
                }
            }
        }
        public string Modulo
        {
            get
            {
                return _modulo;
            }
            set
            {
                if (!_modulo.Equals(value))
                {
                    _modulo = value;
                }
            }
        }

        public SCronogramaAuxiliar()
        {
        }

        public static List<SCronogramaAuxiliar> GetListaClases(IDataReader reader, ClaseTeoricaList teoricas,
                                                                ClasePracticaList practicas)
        {
            List<SCronogramaAuxiliar> lista = new List<SCronogramaAuxiliar>();

            while (reader.Read())
            {
                SCronogramaAuxiliar sesion = new SCronogramaAuxiliar();

                sesion.OidSubmodulo = (long)reader["OID_SUBMODULO"];
                sesion.OidModulo = (long)reader["OID_MODULO"];
                sesion.Titulo = reader["TITULO"].ToString();

                if (reader["TIPO"].Equals(0))
                {
                    sesion.Tipo = 1;
                    sesion.OidClasePractica = 0;
                    sesion.OidClaseTeorica = (long)reader["OID"];
                    ClaseTeoricaInfo teorica = teoricas.GetItem(sesion.OidClaseTeorica);
                    sesion.Modulo = teorica.Modulo;
                    sesion.Titulo += " (" + teorica.OrdenTerciario.ToString() + "/" + teorica.TotalClases.ToString() + ")";
                }
                else
                {
                    sesion.Tipo = 2;
                    sesion.OidClasePractica = (long)reader["OID"];
                    sesion.OidClaseTeorica = 0;
                    sesion.Modulo = practicas.GetItem(sesion.OidClasePractica).Modulo;
                    sesion.Titulo += " G" + reader["GRUPO"].ToString();
                }

                lista.Add(sesion);
            }

            return lista;
        }
    }

    public class Contador
    {
        private long _oid;
        private long _counter;

        public long Oid
        {
            get
            {
                return _oid;
            }
            set
            {
                if (!_oid.Equals(value))
                {
                    _oid = value;
                }
            }
        }
        public long Counter
        {
            get
            {
                return _counter;
            }
            set
            {
                if (!_counter.Equals(value))
                {
                    _counter = value;
                }
            }
        }

        public Contador(long oid)
        {
            this.Oid = oid;
            this.Counter = 1;
        }
    }

    public class ListaContadores : List<Contador>
    {
        public ListaContadores() { }

        public long NuevoContador(long oid)
        {
            foreach (Contador count in this)
            {
                if (count.Oid == oid)
                {
                    count.Counter++;
                    return count.Counter;
                }
            }

            Contador c = new Contador(oid);
            this.Add(c);
            return 1;

        }

    }

    public class RegistroResumen
    {
        private string _titulo = string.Empty;
        private string _nivel = string.Empty;
        private long _n_preguntas = 0;
        private long _oid_submodulo;

        public string Titulo
        {
            get
            {
                return _titulo;
            }
            set
            {
                if (!_titulo.Equals(value))
                {
                    _titulo = value;
                }
            }
        }
        public virtual string Nivel
        {
            get
            {
                return _nivel;
            }
            set
            {
                if (!_nivel.Equals(value))
                {
                    _nivel = value;
                }
            }
        }
        public virtual long NPreguntas
        {
            get
            {
                return _n_preguntas;
            }
            set
            {
                if (!_n_preguntas.Equals(value))
                {
                    _n_preguntas = value;
                }
            }
        }
        public virtual long OidSubmodulo
        {
            get
            {
                return _oid_submodulo;
            }
            set
            {
                if (!_oid_submodulo.Equals(value))
                {
                    _oid_submodulo = value;
                }
            }
        }

        private RegistroResumen(long oid_submodulo, string titulo, string nivel)
        {
            this.OidSubmodulo = oid_submodulo;
            this.Titulo = titulo;
            this.Nivel = nivel;
            this.NPreguntas = 1;
        }

        public RegistroResumen(string titulo, string nivel, long n_preguntas)
        {
            this.OidSubmodulo = 0;
            this.Titulo = titulo;
            this.Nivel = nivel;
            this.NPreguntas = n_preguntas;
        }

        public static List<RegistroResumen> ContabilizaPregunta(List<RegistroResumen> lista,
                                    long oid_submodulo, string titulo, string nivel)
        {
            if (lista != null)
            {
                bool esta = false;
                foreach (RegistroResumen reg in lista)
                {
                    if (reg.OidSubmodulo == oid_submodulo)
                    {
                        if (reg.Nivel == nivel)
                        {
                            esta = true;
                            reg.NPreguntas++;
                            break;
                        }
                    }
                }
                if (!esta)
                {
                    RegistroResumen registro = new RegistroResumen(oid_submodulo, titulo, nivel);
                    lista.Add(registro);
                }

            }
            return lista;
        }

    }

    public class RegistroResumenPlanDocente
    {
        private string _modulo = string.Empty;
        private string _submodulo = string.Empty;
        private long _n_clases_modulo = 0;
        private long _n_clases_submodulo = 0;
        private long _oid_modulo = 0;
        private long _oid_submodulo = 0;

        public string Modulo
        {
            get
            {
                return _modulo;
            }
            set
            {
                if (!_modulo.Equals(value))
                {
                    _modulo = value;
                }
            }
        }
        public virtual string Submodulo
        {
            get
            {
                return _submodulo;
            }
            set
            {
                if (!_submodulo.Equals(value))
                {
                    _submodulo = value;
                }
            }
        }
        public virtual long NClasesModulo
        {
            get
            {
                return _n_clases_modulo;
            }
            set
            {
                if (!_n_clases_modulo.Equals(value))
                {
                    _n_clases_modulo = value;
                }
            }
        }
        public virtual long NClasesSubmodulo
        {
            get
            {
                return _n_clases_submodulo;
            }
            set
            {
                if (!_n_clases_submodulo.Equals(value))
                {
                    _n_clases_submodulo = value;
                }
            }
        }
        public virtual long OidModulo
        {
            get
            {
                return _oid_modulo;
            }
            set
            {
                if (!_oid_modulo.Equals(value))
                {
                    _oid_modulo = value;
                }
            }
        }
        public virtual long OidSubmodulo
        {
            get
            {
                return _oid_submodulo;
            }
            set
            {
                if (!_oid_submodulo.Equals(value))
                {
                    _oid_submodulo = value;
                }
            }
        }

        private RegistroResumenPlanDocente(long oid_modulo, long oid_submodulo, string modulo, string submodulo,
            long n_clases_modulo, long n_clases_submodulo)
        {
            this.OidModulo = oid_modulo;
            this.OidSubmodulo = oid_submodulo;
            this.Modulo = modulo;
            this.Submodulo = submodulo;
            this.NClasesModulo = n_clases_modulo;
            this.NClasesSubmodulo = n_clases_submodulo;
        }

        private RegistroResumenPlanDocente(IDataReader reader)
        {
            this.OidModulo = Format.DataReader.GetInt64(reader, "OID_MODULO");
            this.OidSubmodulo = Format.DataReader.GetInt64(reader, "OID_SUBMODULO");
            this.Modulo = Format.DataReader.GetString(reader, "NUMERO_MODULO") + " " + Format.DataReader.GetString(reader, "MODULO");
            this.Submodulo = Format.DataReader.GetString(reader, "CODIGO_SUBMODULO") + " " + Format.DataReader.GetString(reader, "SUBMODULO");
            this.NClasesModulo = Format.DataReader.GetInt64(reader, "TOTAL_MODULO");
            this.NClasesSubmodulo = Format.DataReader.GetInt64(reader, "TOTAL_SUBMODULO");
        }

        public static List<RegistroResumenPlanDocente> GetComparativaPracticasCronogramaHorarios(CronogramaInfo cronograma, DateTime fecha, long grupo)
        {
            List<RegistroResumenPlanDocente> lista = new List<RegistroResumenPlanDocente>();

            Hashtable lista_submodulos = new Hashtable();

            ClasePracticaList lista_practicas = ClasePracticaList.GetList();

            ClasePracticaList practicas = ClasePracticaList.GetImpartidasList(cronograma.OidPromocion, fecha, grupo);

            foreach (SesionCronogramaInfo info in cronograma.Sesiones)
            {
                if (info.OidClasePractica > 0)
                {
                    ClasePracticaInfo clase = lista_practicas.GetItem(info.OidClasePractica);
                    
                    if (clase != null)
                    {
                        if (!lista_submodulos.ContainsKey(clase.OidSubmodulo))
                            lista_submodulos.Add(clase.OidSubmodulo, 0);
                    }
                }
            }

            SubmoduloList submodulos = SubmoduloList.GetList(false);
            ModuloList modulos = ModuloList.GetList(false);

            foreach (SubmoduloInfo item in submodulos)
            {
                long programadas = 0;
                long impartidas = 0;

                if (lista_submodulos.ContainsKey(item.Oid))
                {
                    foreach (ClasePracticaInfo info in practicas)
                    {
                        if (info.OidSubmodulo == item.Oid)
                            impartidas++;
                    }

                    foreach (SesionCronogramaInfo info in cronograma.Sesiones)
                    {
                        if (info.OidClasePractica > 0 && info.Grupo == grupo)
                        {
                            ClasePracticaInfo clase = lista_practicas.GetItem(info.OidClasePractica);
                            if (info.Fecha.Date <= fecha.Date && clase.OidSubmodulo == item.Oid)
                                programadas++;
                        }
                    }

                    if (programadas > 0 || impartidas > 0)
                    {
                        ModuloInfo modulo = modulos.GetItem(item.OidModulo);

                        RegistroResumenPlanDocente registro = new RegistroResumenPlanDocente(item.OidModulo, item.Oid,
                             modulo.NumeroModulo + " " + modulo.Texto, item.Codigo + " " + item.Texto,
                            programadas, impartidas);
                        lista.Add(registro);
                    }
                }
            }

            return lista;
        }


        public static List<RegistroResumenPlanDocente> GetComparativaTeoricasCronogramaHorarios(CronogramaInfo cronograma, DateTime fecha)
        {
            List<RegistroResumenPlanDocente> lista = new List<RegistroResumenPlanDocente>();

            Hashtable lista_submodulos = new Hashtable();

            ClaseTeoricaList lista_teoricas = ClaseTeoricaList.GetList();

            ClaseTeoricaList teoricas = ClaseTeoricaList.GetImpartidasList(cronograma.OidPromocion, fecha);

            foreach (SesionCronogramaInfo info in cronograma.Sesiones)
            {
                if (info.OidClaseTeorica > 0)
                {
                    ClaseTeoricaInfo clase = lista_teoricas.GetItem(info.OidClaseTeorica);

                    if (clase != null)
                    {
                        if (!lista_submodulos.ContainsKey(clase.OidSubmodulo))
                            lista_submodulos.Add(clase.OidSubmodulo, 0);
                    }
                }
            }

            SubmoduloList submodulos = SubmoduloList.GetList(false);
            ModuloList modulos = ModuloList.GetList(false);

            foreach (SubmoduloInfo item in submodulos)
            {
                long programadas = 0;
                long impartidas = 0;

                if (lista_submodulos.ContainsKey(item.Oid))
                {
                    foreach (ClaseTeoricaInfo info in teoricas)
                    {
                        if (info.OidSubmodulo == item.Oid)
                            impartidas++;
                    }

                    foreach (SesionCronogramaInfo info in cronograma.Sesiones)
                    {
                        if (info.OidClaseTeorica > 0)
                        {
                            ClaseTeoricaInfo clase = lista_teoricas.GetItem(info.OidClaseTeorica);
                            if (info.Fecha.Date <= fecha.Date && clase.OidSubmodulo == item.Oid)
                                programadas++;
                        }
                    }

                    if (programadas > 0 || impartidas > 0)
                    {
                        ModuloInfo modulo = modulos.GetItem(item.OidModulo);

                        RegistroResumenPlanDocente registro = new RegistroResumenPlanDocente(item.OidModulo, item.Oid,
                             modulo.NumeroModulo + " " + modulo.Texto, item.Codigo + " " + item.Texto,
                            programadas, impartidas);
                        lista.Add(registro);
                    }
                }
            }

            return lista;
        }

        public static List<RegistroResumenPlanDocente> ContabilizaClasesTeoricas(long oid_plan)
        {
            List<RegistroResumenPlanDocente> lista = new List<RegistroResumenPlanDocente>();

            string query = SELECT_CLASES_TEORICAS(oid_plan);
            IDataReader reader = nHManager.Instance.SQLNativeSelect(query);

            while (reader.Read())
            {
                RegistroResumenPlanDocente item = new RegistroResumenPlanDocente(reader);
                lista.Add(item);
            }

            return lista;
        }

        public static List<RegistroResumenPlanDocente> ContabilizaClases(ClaseTeoricaList lista_teoricas)
        {
            Hashtable lista_modulos = new Hashtable();
            Hashtable lista_submodulos = new Hashtable();

            foreach (ClaseTeoricaInfo item in lista_teoricas)
            {
                if (lista_modulos.ContainsKey(item.OidModulo))
                {
                    lista_modulos[item.OidModulo] = Convert.ToInt64(lista_modulos[item.OidModulo]) + 1;

                    if (lista_submodulos.ContainsKey(item.OidSubmodulo))
                        lista_submodulos[item.OidSubmodulo] = Convert.ToInt64(lista_submodulos[item.OidSubmodulo]) + 1;
                    else
                        lista_submodulos.Add(item.OidSubmodulo, 1);
                }
                else
                {
                    lista_modulos.Add(item.OidModulo, 1);
                    lista_submodulos.Add(item.OidSubmodulo, 1);
                }
            }

            List<RegistroResumenPlanDocente> lista = new List<RegistroResumenPlanDocente>();
            SubmoduloList submodulos = SubmoduloList.GetList(false);
            ModuloList modulos = ModuloList.GetList(false);
            long oid_modulo = 0;
            ModuloInfo modulo = null;
            long n_clases_modulo = 0;

            foreach (SubmoduloInfo item in submodulos)
            {
                if (lista_submodulos.ContainsKey(item.Oid))
                {
                    if (item.OidModulo != oid_modulo)
                    {
                        oid_modulo = item.OidModulo;
                        modulo = modulos.GetItem(oid_modulo);
                        n_clases_modulo = Convert.ToInt64(lista_modulos[item.OidModulo]);
                    }

                    RegistroResumenPlanDocente registro = new RegistroResumenPlanDocente(modulo.Oid, item.Oid,
                        modulo.NumeroModulo + " " + modulo.Texto, item.Codigo + " " + item.Texto,
                        n_clases_modulo, Convert.ToInt64(lista_submodulos[item.Oid]));
                    lista.Add(registro);
                }
            }

            return lista;
        }

        public static List<RegistroResumenPlanDocente> ContabilizaClasesPracticas(long oid_plan)
        {
            List<RegistroResumenPlanDocente> lista = new List<RegistroResumenPlanDocente>();

            string query = SELECT_CLASES_PRACTICAS(oid_plan);
            IDataReader reader = nHManager.Instance.SQLNativeSelect(query);

            while (reader.Read())
            {
                RegistroResumenPlanDocente item = new RegistroResumenPlanDocente(reader);
                lista.Add(item);
            }

            return lista;
        }

        public static List<RegistroResumenPlanDocente> ContabilizaClases(ClasePracticaList lista_practicas)
        {
            Hashtable lista_modulos = new Hashtable();
            Hashtable lista_submodulos = new Hashtable();

            foreach (ClasePracticaInfo item in lista_practicas)
            {
                if (lista_modulos.ContainsKey(item.OidModulo))
                {
                    lista_modulos[item.OidModulo] = Convert.ToInt64(lista_modulos[item.OidModulo]) + 1;

                    if (lista_submodulos.ContainsKey(item.OidSubmodulo))
                        lista_submodulos[item.OidSubmodulo] = Convert.ToInt64(lista_submodulos[item.OidSubmodulo]) + 1;
                    else
                        lista_submodulos.Add(item.OidSubmodulo, 1);

                }
                else
                {
                    lista_modulos.Add(item.OidModulo, 1);
                    lista_submodulos.Add(item.OidSubmodulo, 1);
                }
            }

            List<RegistroResumenPlanDocente> lista = new List<RegistroResumenPlanDocente>();
            SubmoduloList submodulos = SubmoduloList.GetList(false);
            ModuloList modulos = ModuloList.GetList(false);
            long oid_modulo = 0;
            ModuloInfo modulo = null;
            long n_clases_modulo = 0;

            foreach (SubmoduloInfo item in submodulos)
            {
                if (lista_submodulos.ContainsKey(item.Oid))
                {
                    if (item.OidModulo != oid_modulo)
                    {
                        oid_modulo = item.OidModulo;
                        modulo = modulos.GetItem(oid_modulo);
                        n_clases_modulo = Convert.ToInt64(lista_modulos[item.OidModulo]);
                    }

                    RegistroResumenPlanDocente registro = new RegistroResumenPlanDocente(modulo.Oid, item.Oid,
                        modulo.NumeroModulo + " " + modulo.Texto, item.Codigo + " " + item.Texto,
                        n_clases_modulo, Convert.ToInt64(lista_submodulos[item.Oid]));
                    lista.Add(registro);
                }
            }

            return lista;
        }

        public static List<RegistroResumenPlanDocente> ContabilizaClasesExtra(long oid_plan)
        {
            List<RegistroResumenPlanDocente> lista = new List<RegistroResumenPlanDocente>();

            string query = SELECT_CLASES_EXTRA(oid_plan);
            IDataReader reader = nHManager.Instance.SQLNativeSelect(query);

            while (reader.Read())
            {
                RegistroResumenPlanDocente item = new RegistroResumenPlanDocente(reader);
                lista.Add(item);
            }

            return lista;
        }

        public static List<RegistroResumenPlanDocente> ContabilizaClases(ClaseExtraList lista_extras)
        {
            Hashtable lista_modulos = new Hashtable();
            Hashtable lista_submodulos = new Hashtable();

            foreach (ClaseExtraInfo item in lista_extras)
            {
                if (lista_modulos.ContainsKey(item.OidModulo))
                {
                    lista_modulos[item.OidModulo] = Convert.ToInt64(lista_modulos[item.OidModulo]) + 1;

                    if (lista_submodulos.ContainsKey(item.OidSubmodulo))
                        lista_submodulos[item.OidSubmodulo] = Convert.ToInt64(lista_submodulos[item.OidSubmodulo]) + 1;
                    else
                        lista_submodulos.Add(item.OidSubmodulo, 1);

                }
                else
                {
                    lista_modulos.Add(item.OidModulo, 1);
                    lista_submodulos.Add(item.OidSubmodulo, 1);
                }
            }

            List<RegistroResumenPlanDocente> lista = new List<RegistroResumenPlanDocente>();
            SubmoduloList submodulos = SubmoduloList.GetList(false);
            ModuloList modulos = ModuloList.GetList(false);
            long oid_modulo = 0;
            ModuloInfo modulo = null;
            long n_clases_modulo = 0;

            foreach (SubmoduloInfo item in submodulos)
            {
                if (lista_submodulos.ContainsKey(item.Oid))
                {
                    if (item.OidModulo != oid_modulo)
                    {
                        oid_modulo = item.OidModulo;
                        modulo = modulos.GetItem(oid_modulo);
                        n_clases_modulo = Convert.ToInt64(lista_modulos[item.OidModulo]);
                    }

                    RegistroResumenPlanDocente registro = new RegistroResumenPlanDocente(modulo.Oid, item.Oid,
                        modulo.NumeroModulo + " " + modulo.Texto, item.Codigo + " " + item.Texto,
                        n_clases_modulo, Convert.ToInt64(lista_submodulos[item.Oid]));
                    lista.Add(registro);
                }
            }

            return lista;
        }

        #region SQL

        private static string SELECT_CLASES_TEORICAS(long oid_plan)
        {
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string clase = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string plan = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));

            string query = string.Empty;

            query = "SELECT \"OID_MODULO\", \"OID_SUBMODULO\", \"ORDEN_MODULO\", \"ORDEN_SUBMODULO\", " +
                    "   \"NUMERO_MODULO\", \"MODULO\", \"CODIGO_SUBMODULO\",  \"SUBMODULO\", " +
                    "   QUERY1.\"TOTAL_MODULO\" AS \"TOTAL_MODULO\", QUERY1.\"TOTAL_SUBMODULO\" AS \"TOTAL_SUBMODULO\" " +
                    "FROM( " +
                    "   SELECT m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", " +
                    "       m.\"TEXTO\" AS \"MODULO\", m.\"OID\" AS \"OID_MODULO\", QUERY2.\"TOTAL\" AS \"TOTAL_MODULO\" , " +
                    "       QUERY3.\"TOTAL\" AS \"TOTAL_SUBMODULO\", sm.\"CODIGO\" AS \"CODIGO_SUBMODULO\", " +
                    "       sm.\"TEXTO\" AS \"SUBMODULO\", sm.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", sm.\"OID\" AS \"OID_SUBMODULO\" " +
                    "   FROM ( " +
                    "           SELECT MOD.\"OID\" AS \"OID_MOD2\",MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                    "           FROM " + plan + " AS PE " +
                    "           INNER JOIN " + clase + " AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                    "           INNER JOIN " + modulo + " AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                    "           WHERE PE.\"OID\" = " + oid_plan.ToString() + " " +
                    "           GROUP BY \"OID_MOD2\", \"MODULO2\" " +
                    "           ) AS QUERY2 , " +
                    "       ( " +
                    "           SELECT SUBMOD.\"OID\" AS \"OID_SUB2\", SUBMOD.\"TEXTO\" AS \"SUBMODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                    "           FROM " + plan + " AS PE " +
                    "           INNER JOIN " + clase + " AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                    "           INNER JOIN " + submodulo + " AS SUBMOD ON ( C.\"OID_SUBMODULO\" = SUBMOD.\"OID\") " +
                    "           WHERE PE.\"OID\" = " + oid_plan.ToString() + " " +
                    "           GROUP BY \"OID_SUB2\", \"SUBMODULO2\" " +
                    "       ) AS QUERY3 , " + plan + " as pl " +
                    "   INNER JOIN " + clase + " as ct ON (ct.\"OID_PLAN\" = pl.\"OID\") " +
                    "   INNER JOIN " + modulo + " as m ON (m.\"OID\" = ct.\"OID_MODULO\") " +
                    "   INNER JOIN " + submodulo + " as sm ON (sm.\"OID\" = ct.\"OID_SUBMODULO\") " +
                    "   WHERE \"OID_MOD2\" = m.\"OID\" AND \"OID_SUB2\" = sm.\"OID\") AS QUERY1 " +
                    "GROUP BY \"ORDEN_MODULO\", \"NUMERO_MODULO\", \"MODULO\", \"TOTAL_MODULO\", \"TOTAL_SUBMODULO\", \"OID_MODULO\", \"OID_SUBMODULO\", " +
                    "\"CODIGO_SUBMODULO\", \"SUBMODULO\", \"ORDEN_SUBMODULO\" " +
                    "ORDER BY \"ORDEN_MODULO\", \"ORDEN_SUBMODULO\";";

            return query;
        }

        private static string SELECT_CLASES_PRACTICAS(long oid_plan)
        {
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string clase = nHManager.Instance.GetSQLTable(typeof(ClasePracticaRecord));
            string plan = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));


            string query = string.Empty;

            query = "SELECT \"OID_MODULO\", \"OID_SUBMODULO\", \"ORDEN_MODULO\", \"ORDEN_SUBMODULO\", " +
                    "   \"NUMERO_MODULO\", \"MODULO\", \"CODIGO_SUBMODULO\",  \"SUBMODULO\", " +
                    "   QUERY1.\"TOTAL_MODULO\" AS \"TOTAL_MODULO\", QUERY1.\"TOTAL_SUBMODULO\" AS \"TOTAL_SUBMODULO\" " +
                    "FROM( " +
                    "   SELECT m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", " +
                    "       m.\"TEXTO\" AS \"MODULO\", m.\"OID\" AS \"OID_MODULO\", QUERY2.\"TOTAL\" AS \"TOTAL_MODULO\" , " +
                    "       QUERY3.\"TOTAL\" AS \"TOTAL_SUBMODULO\", sm.\"CODIGO\" AS \"CODIGO_SUBMODULO\", " +
                    "       sm.\"TEXTO\" AS \"SUBMODULO\", sm.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", sm.\"OID\" AS \"OID_SUBMODULO\" " +
                    "   FROM ( " +
                    "           SELECT MOD.\"OID\" AS \"OID_MOD2\",MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                    "           FROM " + plan + " AS PE " +
                    "           INNER JOIN " + clase + " AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                    "           INNER JOIN " + modulo + " AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                    "           WHERE PE.\"OID\" = " + oid_plan.ToString() + " " +
                    "           GROUP BY \"OID_MOD2\", \"MODULO2\" " +
                    "           ) AS QUERY2 , " +
                    "       ( " +
                    "           SELECT SUBMOD.\"OID\" AS \"OID_SUB2\", SUBMOD.\"TEXTO\" AS \"SUBMODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                    "           FROM " + plan + " AS PE " +
                    "           INNER JOIN " + clase + " AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                    "           INNER JOIN " + submodulo + " AS SUBMOD ON ( C.\"OID_SUBMODULO\" = SUBMOD.\"OID\") " +
                    "           WHERE PE.\"OID\" = " + oid_plan.ToString() + " " +
                    "           GROUP BY \"OID_SUB2\", \"SUBMODULO2\" " +
                    "       ) AS QUERY3 , " + plan + " as pl " +
                    "   INNER JOIN " + clase + " as ct ON (ct.\"OID_PLAN\" = pl.\"OID\") " +
                    "   INNER JOIN " + modulo + " as m ON (m.\"OID\" = ct.\"OID_MODULO\") " +
                    "   INNER JOIN " + submodulo + " as sm ON (sm.\"OID\" = ct.\"OID_SUBMODULO\") " +
                    "   WHERE \"OID_MOD2\" = m.\"OID\" AND \"OID_SUB2\" = sm.\"OID\") AS QUERY1 " +
                    "GROUP BY \"ORDEN_MODULO\", \"NUMERO_MODULO\", \"MODULO\", \"TOTAL_MODULO\", \"TOTAL_SUBMODULO\", \"OID_MODULO\", \"OID_SUBMODULO\", " +
                    "\"CODIGO_SUBMODULO\", \"SUBMODULO\", \"ORDEN_SUBMODULO\" " +
                    "ORDER BY \"ORDEN_MODULO\", \"ORDEN_SUBMODULO\";";

            return query;
        }

        private static string SELECT_CLASES_EXTRA(long oid_plan)
        {
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string submodulo = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));
            string clase = nHManager.Instance.GetSQLTable(typeof(ClaseExtraRecord));
            string plan = nHManager.Instance.GetSQLTable(typeof(PlanExtraRecord));

            string query = string.Empty;

            query = "SELECT \"OID_MODULO\", \"OID_SUBMODULO\", \"ORDEN_MODULO\", \"ORDEN_SUBMODULO\", " +
                    "   \"NUMERO_MODULO\", \"MODULO\", \"CODIGO_SUBMODULO\",  \"SUBMODULO\", " +
                    "   QUERY1.\"TOTAL_MODULO\" AS \"TOTAL_MODULO\", QUERY1.\"TOTAL_SUBMODULO\" AS \"TOTAL_SUBMODULO\" " +
                    "FROM( " +
                    "   SELECT m.\"NUMERO_MODULO\" AS \"NUMERO_MODULO\", m.\"NUMERO_ORDEN\" AS \"ORDEN_MODULO\", " +
                    "       m.\"TEXTO\" AS \"MODULO\", m.\"OID\" AS \"OID_MODULO\", QUERY2.\"TOTAL\" AS \"TOTAL_MODULO\" , " +
                    "       QUERY3.\"TOTAL\" AS \"TOTAL_SUBMODULO\", sm.\"CODIGO\" AS \"CODIGO_SUBMODULO\", " +
                    "       sm.\"TEXTO\" AS \"SUBMODULO\", sm.\"CODIGO_ORDEN\" AS \"ORDEN_SUBMODULO\", sm.\"OID\" AS \"OID_SUBMODULO\" " +
                    "   FROM ( " +
                    "           SELECT MOD.\"OID\" AS \"OID_MOD2\",MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                    "           FROM " + plan + " AS PE " +
                    "           INNER JOIN " + clase + " AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                    "           INNER JOIN " + modulo + " AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\") " +
                    "           WHERE PE.\"OID\" = " + oid_plan.ToString() + " " +
                    "           GROUP BY \"OID_MOD2\", \"MODULO2\" " +
                    "           ) AS QUERY2 , " +
                    "       ( " +
                    "           SELECT SUBMOD.\"OID\" AS \"OID_SUB2\", SUBMOD.\"TEXTO\" AS \"SUBMODULO2\", COUNT(C.\"OID\") AS \"TOTAL\" " +
                    "           FROM " + plan + " AS PE " +
                    "           INNER JOIN " + clase + " AS C ON ( C.\"OID_PLAN\" = PE.\"OID\") " +
                    "           INNER JOIN " + submodulo + " AS SUBMOD ON ( C.\"OID_SUBMODULO\" = SUBMOD.\"OID\") " +
                    "           WHERE PE.\"OID\" = " + oid_plan.ToString() + " " +
                    "           GROUP BY \"OID_SUB2\", \"SUBMODULO2\" " +
                    "       ) AS QUERY3 , " + plan + " as pl " +
                    "   INNER JOIN " + clase + " as ct ON (ct.\"OID_PLAN\" = pl.\"OID\") " +
                    "   INNER JOIN " + modulo + " as m ON (m.\"OID\" = ct.\"OID_MODULO\") " +
                    "   INNER JOIN " + submodulo + " as sm ON (sm.\"OID\" = ct.\"OID_SUBMODULO\") " +
                    "   WHERE \"OID_MOD2\" = m.\"OID\" AND \"OID_SUB2\" = sm.\"OID\") AS QUERY1 " +
                    "GROUP BY \"ORDEN_MODULO\", \"NUMERO_MODULO\", \"MODULO\", \"TOTAL_MODULO\", \"TOTAL_SUBMODULO\", \"OID_MODULO\", \"OID_SUBMODULO\", " +
                    "\"CODIGO_SUBMODULO\", \"SUBMODULO\", \"ORDEN_SUBMODULO\" " +
                    "ORDER BY \"ORDEN_MODULO\", \"ORDEN_SUBMODULO\";";

            return query;
        }

        #endregion

    }

    public class ProfesorModulo
    {
        private long _oid_modulo = 0;
        private long _oid_instructor = 0;
        private bool _practica = false;

        public long OidModulo
        {
            get
            {
                return _oid_modulo;
            }
            set
            {
                if (!_oid_modulo.Equals(value))
                {
                    _oid_modulo = value;
                }
            }
        }

        public long OidInstructor
        {
            get
            {
                return _oid_instructor;
            }
            set
            {
                if (!_oid_instructor.Equals(value))
                {
                    _oid_instructor = value;
                }
            }
        }

        public bool EsPractica
        { get { return _practica; } set { _practica = value; } }

        public ProfesorModulo(long oid_modulo, long oid_instructor, bool practica)
        {
            this.OidModulo = oid_modulo;
            this.OidInstructor = oid_instructor;
            this.EsPractica = practica;
        }

        public ProfesorModulo()
        {

        }
    }

    public class ProfesoresModulos : List<ProfesorModulo>
    {
        public ProfesoresModulos() { }

        public bool Esta(long oid_modulo, bool practica)
        {
            foreach (ProfesorModulo item in this)
            {
                if (item.OidModulo == oid_modulo
                    && item.EsPractica == practica)
                    return true;
            }
            return false;

        }

        public bool ProfesorEncargado(long oid_modulo, long oid_instructor, bool practica)
        {
            foreach (ProfesorModulo item in this)
            {
                if (item.OidModulo == oid_modulo && item.EsPractica == practica)
                {
                    if (item.OidInstructor == oid_instructor)
                        return true;
                    else
                        return false;
                }
            }

            //si aún no ha salido, es que el módulo no había empezado a darse
            //con lo cual, podemos meterlo en la lista
            //this.Add(new ProfesorModulo(oid_modulo, oid_instructor));
            return true;
        }

        public void SetProfesorEncargado(long oid_modulo, long oid_instructor, bool practica)
        {
            foreach (ProfesorModulo item in this)
            {
                if (item.OidModulo == oid_modulo && item.EsPractica == practica)
                    return;
            }

            this.Add(new ProfesorModulo(oid_modulo, oid_instructor, practica));
        }

        public bool ExisteProfesorEncargado(long oid_modulo, long oid_instructor, bool practica)
        {
            foreach (ProfesorModulo item in this)
            {
                if (item.OidModulo == oid_modulo && item.EsPractica == practica)
                    return true;
            }

            return false;
        }

        public void GetEncargados(long oid_plan, long oid_promocion)
        {
            string query = Sesions.SELECT_SESIONES(oid_plan, oid_promocion);
            int sesion = Sesion.OpenSession();

            IDataReader reader = nHManager.Instance.SQLNativeSelect(query);

            while (reader.Read())
            {
                long oid_modulo = Convert.ToInt32(reader["OID_MODULO"]);
                long oid_instructor = Convert.ToInt32(reader["OID_INSTRUCTOR"]);
                bool practica = Format.DataReader.GetBool(reader, "PRACTICA");

                if (!Esta(oid_modulo, practica))
                    this.Add(new ProfesorModulo(oid_modulo, oid_instructor, practica));
            }

            Sesion.CloseSession(sesion);
        }

    }
}
