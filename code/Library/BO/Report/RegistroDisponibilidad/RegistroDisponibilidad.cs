using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// Editable Root Business Object With Editable Child Collection
    /// </summary>
    [Serializable()]
    public class RegistroDisponibilidad : BusinessBaseEx<RegistroDisponibilidad>
    {

        #region Attributes

        private string _nombre = string.Empty;
        private string _apellidos = string.Empty;
        private bool _lunes_m = false;
        private bool _martes_m = false;
        private bool _miercoles_m = false;
        private bool _jueves_m = false;
        private bool _viernes_m = false;
        private bool _sabado_m = false;
        private bool _lunes_t1 = false;
        private bool _martes_t1 = false;
        private bool _miercoles_t1 = false;
        private bool _jueves_t1 = false;
        private bool _viernes_t1 = false;
        private bool _sabado_t1 = false;
        private bool _lunes_t2 = false;
        private bool _martes_t2 = false;
        private bool _miercoles_t2 = false;
        private bool _jueves_t2 = false;
        private bool _viernes_t2 = false;
        private bool _sabado_t2 = false;
        private bool _lunes_nd = false;
        private bool _martes_nd = false;
        private bool _miercoles_nd = false;
        private bool _jueves_nd = false;
        private bool _viernes_nd = false;
        private bool _sabado_nd = false;

        #endregion

        #region Properties

        public virtual string Nombre
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _nombre;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_nombre.Equals(value))
                {
                    _nombre = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Apellidos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _apellidos;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_apellidos.Equals(value))
                {
                    _apellidos = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool LunesM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _lunes_m;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_lunes_m.Equals(value))
                {
                    _lunes_m = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool MartesM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _martes_m;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_martes_m.Equals(value))
                {
                    _martes_m = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool MiercolesM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _miercoles_m;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_miercoles_m.Equals(value))
                {
                    _miercoles_m = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool JuevesM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _jueves_m;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_jueves_m.Equals(value))
                {
                    _jueves_m = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool ViernesM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _viernes_m;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_viernes_m.Equals(value))
                {
                    _viernes_m = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool SabadoM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _sabado_m;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_sabado_m.Equals(value))
                {
                    _sabado_m = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool LunesT1
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _lunes_t1;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_lunes_t1.Equals(value))
                {
                    _lunes_t1 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool MartesT1
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _martes_t1;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_martes_t1.Equals(value))
                {
                    _martes_t1 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool MiercolesT1
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _miercoles_t1;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_miercoles_t1.Equals(value))
                {
                    _miercoles_t1 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool JuevesT1
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _jueves_t1;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_jueves_t1.Equals(value))
                {
                    _jueves_t1 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool ViernesT1
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _viernes_t1;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_viernes_t1.Equals(value))
                {
                    _viernes_t1 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool SabadoT1
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _sabado_t1;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_sabado_t1.Equals(value))
                {
                    _sabado_t1 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool LunesT2
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _lunes_t2;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_lunes_t2.Equals(value))
                {
                    _lunes_t2 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool MartesT2
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _martes_t2;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_martes_t2.Equals(value))
                {
                    _martes_t2 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool MiercolesT2
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _miercoles_t2;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_miercoles_t2.Equals(value))
                {
                    _miercoles_t2 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool JuevesT2
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _jueves_t2;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_jueves_t2.Equals(value))
                {
                    _jueves_t2 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool ViernesT2
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _viernes_t2;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_viernes_t2.Equals(value))
                {
                    _viernes_t2 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool SabadoT2
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _sabado_t2;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_sabado_t2.Equals(value))
                {
                    _sabado_t2 = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool LunesND
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _lunes_nd;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_lunes_nd.Equals(value))
                {
                    _lunes_nd = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool MartesND
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _martes_nd;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_martes_nd.Equals(value))
                {
                    _martes_nd = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool MiercolesND
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _miercoles_nd;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_miercoles_nd.Equals(value))
                {
                    _miercoles_nd = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool JuevesND
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _jueves_nd;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_jueves_nd.Equals(value))
                {
                    _jueves_nd = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool ViernesND
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _viernes_nd;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_viernes_nd.Equals(value))
                {
                    _viernes_nd = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool SabadoND
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _sabado_nd;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);

                if (!_sabado_nd.Equals(value))
                {
                    _sabado_nd = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Lunes
        {
            get
            {
                if (_lunes_nd) return Resources.Defaults.NO_DISPONIBILIDAD_VALUE;
                if (_lunes_m && (_lunes_t1 || _lunes_t2)) return Resources.Defaults.DISPONIBILIDAD_DIA_VALUE;
                if (_lunes_t1 && _lunes_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE_VALUE;
                if (_lunes_m) return Resources.Defaults.DISPONIBILIDAD_MANANA_VALUE;
                if (_lunes_t1) return Resources.Defaults.DISPONIBILIDAD_TARDE1_VALUE;
                if (_lunes_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE2_VALUE;
                return Resources.Defaults.DISPONIBILIDAD_NO_DISPONIBLE_VALUE;
            }
        }
        public virtual string Martes
        {
            get
            {
                if (_martes_nd) return Resources.Defaults.NO_DISPONIBILIDAD_VALUE;
                if (_martes_m && (_martes_t1 || _martes_t2)) return Resources.Defaults.DISPONIBILIDAD_DIA_VALUE;
                if (_martes_t1 && _martes_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE_VALUE;
                if (_martes_m) return Resources.Defaults.DISPONIBILIDAD_MANANA_VALUE;
                if (_martes_t1) return Resources.Defaults.DISPONIBILIDAD_TARDE1_VALUE;
                if (_martes_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE2_VALUE;
                return Resources.Defaults.DISPONIBILIDAD_NO_DISPONIBLE_VALUE;
            }
        }
        public virtual string Miercoles
        {
            get
            {
                if (_miercoles_nd) return Resources.Defaults.NO_DISPONIBILIDAD_VALUE;
                if (_miercoles_m && (_miercoles_t1 || _miercoles_t2)) return Resources.Defaults.DISPONIBILIDAD_DIA_VALUE;
                if (_miercoles_t1 && _miercoles_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE_VALUE;
                if (_miercoles_m) return Resources.Defaults.DISPONIBILIDAD_MANANA_VALUE;
                if (_miercoles_t1) return Resources.Defaults.DISPONIBILIDAD_TARDE1_VALUE;
                if (_miercoles_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE2_VALUE;
                return Resources.Defaults.DISPONIBILIDAD_NO_DISPONIBLE_VALUE;
            }
        }
        public virtual string Jueves
        {
            get
            {
                if (_jueves_nd) return Resources.Defaults.NO_DISPONIBILIDAD_VALUE;
                if (_jueves_m && (_jueves_t1 || _jueves_t2)) return Resources.Defaults.DISPONIBILIDAD_DIA_VALUE;
                if (_jueves_t1 && _jueves_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE_VALUE;
                if (_jueves_m) return Resources.Defaults.DISPONIBILIDAD_MANANA_VALUE;
                if (_jueves_t1) return Resources.Defaults.DISPONIBILIDAD_TARDE1_VALUE;
                if (_jueves_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE2_VALUE;
                return Resources.Defaults.DISPONIBILIDAD_NO_DISPONIBLE_VALUE;
            }
        }
        public virtual string Viernes
        {
            get
            {
                if (_viernes_nd) return Resources.Defaults.NO_DISPONIBILIDAD_VALUE;
                if (_viernes_m && (_viernes_t1 || _viernes_t2)) return Resources.Defaults.DISPONIBILIDAD_DIA_VALUE;
                if (_viernes_t1 && _viernes_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE_VALUE;
                if (_viernes_m) return Resources.Defaults.DISPONIBILIDAD_MANANA_VALUE;
                if (_viernes_t1) return Resources.Defaults.DISPONIBILIDAD_TARDE1_VALUE;
                if (_viernes_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE2_VALUE;
                return Resources.Defaults.DISPONIBILIDAD_NO_DISPONIBLE_VALUE;
            }
        }
        public virtual string Sabado
        {
            get
            {
                if (_sabado_nd) return Resources.Defaults.NO_DISPONIBILIDAD_VALUE;
                if (_sabado_m && (_sabado_t1 || _sabado_t2)) return Resources.Defaults.DISPONIBILIDAD_DIA_VALUE;
                if (_sabado_t1 && _sabado_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE_VALUE;
                if (_sabado_m) return Resources.Defaults.DISPONIBILIDAD_MANANA_VALUE;
                if (_sabado_t1) return Resources.Defaults.DISPONIBILIDAD_TARDE1_VALUE;
                if (_sabado_t2) return Resources.Defaults.DISPONIBILIDAD_TARDE2_VALUE;
                return Resources.Defaults.DISPONIBILIDAD_NO_DISPONIBLE_VALUE;
            }
        }


        #endregion

        #region Business Methods

        /// <summary>
        /// Clona la entidad y sus subentidades y las marca como nuevas
        /// </summary>
        /// <returns>Una entidad clon</returns>

        public virtual RegistroDisponibilidad CloneAsNew()
        {
            RegistroDisponibilidad clon = base.Clone();

            //Se definen el Oid y el Coidgo como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();
            clon.SessionCode = RegistroDisponibilidad.OpenSession();
            RegistroDisponibilidad.BeginTransaction(clon.SessionCode);

            clon.MarkNew();

            return clon;
        }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(RegistroDisponibilidad source)
        {
            if (source == null) return;

            Oid = source.Oid;
            _nombre = source.Nombre;
            _apellidos = source.Apellidos;
            _lunes_m = source.LunesM;
            _martes_m = source.MartesM;
            _miercoles_m = source.MiercolesM;
            _jueves_m = source.JuevesM;
            _viernes_m = source.ViernesM;
            _sabado_m = source.SabadoM;
            _lunes_t1 = source.LunesT1;
            _martes_t1 = source.MartesT1;
            _miercoles_t1 = source.MiercolesT1;
            _jueves_t1 = source.JuevesT1;
            _viernes_t1 = source.ViernesT1;
            _sabado_t1 = source.SabadoT1;
            _lunes_t2 = source.LunesT2;
            _martes_t2 = source.MartesT2;
            _miercoles_t2 = source.MiercolesT2;
            _jueves_t2 = source.JuevesT2;
            _viernes_t2 = source.ViernesT2;
            _sabado_t2 = source.SabadoT2;
            _lunes_nd = source.LunesND;
            _martes_nd = source.MartesND;
            _miercoles_nd = source.MiercolesND;
            _jueves_nd = source.JuevesND;
            _viernes_nd = source.ViernesND;
            _sabado_nd = source.SabadoND;
        }


        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(IDataReader source)
        {
            if (source == null) return;

            Oid = Format.DataReader.GetInt64(source, "OID");
            _nombre = DBNull.Value.Equals(source["NOMBRE_PROPIO"]) ? string.Empty : source["NOMBRE_PROPIO"].ToString();
            _apellidos = DBNull.Value.Equals(source["APELLIDOS"]) ? string.Empty : source["APELLIDOS"].ToString();
            _lunes_m = Format.DataReader.GetBool(source, "LUNES_M");
            _martes_m = Format.DataReader.GetBool(source, "MARTES_M");
            _miercoles_m = Format.DataReader.GetBool(source, "MIERCOLES_M");
            _jueves_m = Format.DataReader.GetBool(source, "JUEVES_M");
            _viernes_m = Format.DataReader.GetBool(source, "VIERNES_M");
            _sabado_m = Format.DataReader.GetBool(source, "SABADO_M");
            _lunes_t1 = Format.DataReader.GetBool(source, "LUNES_T1");
            _martes_t1 = Format.DataReader.GetBool(source, "MARTES_T1");
            _miercoles_t1 = Format.DataReader.GetBool(source, "MIERCOLES_T1");
            _jueves_t1 = Format.DataReader.GetBool(source, "JUEVES_T1");
            _viernes_t1 = Format.DataReader.GetBool(source, "VIERNES_T1");
            _sabado_t1 = Format.DataReader.GetBool(source, "SABADO_T1");
            _lunes_t2 = Format.DataReader.GetBool(source, "LUNES_T2");
            _martes_t2 = Format.DataReader.GetBool(source, "MARTES_T2");
            _miercoles_t2 = Format.DataReader.GetBool(source, "MIERCOLES_T2");
            _jueves_t2 = Format.DataReader.GetBool(source, "JUEVES_T2");
            _viernes_t2 = Format.DataReader.GetBool(source, "VIERNES_T2");
            _sabado_t2 = Format.DataReader.GetBool(source, "SABADO_T2");
            _lunes_nd = Format.DataReader.GetBool(source, "LUNES_ND");
            _martes_nd = Format.DataReader.GetBool(source, "MARTES_ND");
            _miercoles_nd = Format.DataReader.GetBool(source, "MIERCOLES_ND");
            _jueves_nd = Format.DataReader.GetBool(source, "JUEVES_ND");
            _viernes_nd = Format.DataReader.GetBool(source, "VIERNES_ND");
            _sabado_nd = Format.DataReader.GetBool(source, "SABADO_ND");
        }

        #endregion

        #region Validation Rules


        protected override void AddBusinessRules()
        {
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.INSTRUCTOR);
        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.INSTRUCTOR);
        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.INSTRUCTOR);
        }

        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.INSTRUCTOR);
        }

        #endregion

        #region Root Factory Methods

        public static RegistroDisponibilidad New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<RegistroDisponibilidad>(new CriteriaCs(-1));
        }

        public static RegistroDisponibilidad Get(long oid)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = RegistroDisponibilidad.GetCriteria(RegistroDisponibilidad.OpenSession());

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = RegistroDisponibilidad.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

            RegistroDisponibilidad.BeginTransaction(criteria.Session);

            return DataPortal.Fetch<RegistroDisponibilidad>(criteria);
        }

        internal static RegistroDisponibilidad Get(IDataReader reader)
        {
            return new RegistroDisponibilidad(reader, true);
        }

        /// <summary>
        /// Borrado inmediato, no cabe "undo"
        /// (La función debe ser "estática")
        /// </summary>
        /// <param name="oid"></param>
        public static void Delete(long oid)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            DataPortal.Delete(new CriteriaCs(oid));
        }

        /// <summary>
        /// Elimina todos los Area. 
        /// Si no existe integridad referencial, hay que eliminar las listas hijo en esta función.
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = RegistroDisponibilidad.OpenSession();
            ISession sess = RegistroDisponibilidad.Session(sessCode);
            ITransaction trans = RegistroDisponibilidad.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from RegistroDisponibilidad");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                RegistroDisponibilidad.CloseSession(sessCode);
            }
        }

        public override RegistroDisponibilidad Save()
        {
            // Por la posible doble interfaz Root/Child
            if (IsChild) throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);

            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            else if (!CanEditObject())
            {
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            }
            try
            {
                ValidationRules.CheckRules();

                base.Save();

                if (!SharedTransaction) Transaction().Commit();
                return this;
            }
            catch (Exception ex)
            {
                if (!SharedTransaction) if (!SharedTransaction && Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
                return this;
            }
            finally
            {
                if (!SharedTransaction)
                {
                    if (CloseSessions && (this.IsNew || Transaction().WasCommitted)) CloseSession();
                    else BeginTransaction();
                }
            }
        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New o NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate.
        /// </summary>
        protected RegistroDisponibilidad()
        {
        }

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
        /// </summary>
        private RegistroDisponibilidad(RegistroDisponibilidad source, bool retrieve_childs)
        {
            MarkAsChild();
            Childs = retrieve_childs;
            Fetch(source);
        }

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
        /// </summary>
        private RegistroDisponibilidad(IDataReader source, bool retrieve_childs)
        {
            MarkAsChild();
            Childs = retrieve_childs;
            Fetch(source);
        }

        /// <summary>
        /// Crea un nuevo objeto
        /// </summary>
        /// <returns>Nuevo objeto creado</returns>
        /// La utiliza la BusinessListBaseEx correspondiente para crear nuevos elementos
        public static RegistroDisponibilidad NewChild()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<RegistroDisponibilidad>(new CriteriaCs(-1));
        }

        /// <summary>
        /// Crea un objeto
        /// </summary>
        /// <param name="source">Area con los datos para el objeto</param>
        /// <returns>Objeto creado</returns>
        /// <remarks>
        /// La utiliza la BusinessListBaseEx correspondiente para montar la lista
        /// NO OBTIENE los hijos. Para ello utilice GetChild(Area source, bool retrieve_childs)
        /// <remarks/>
        internal static RegistroDisponibilidad GetChild(RegistroDisponibilidad source)
        {
            return new RegistroDisponibilidad(source, false);
        }

        /// <summary>
        /// Crea un objeto
        /// </summary>
        /// <param name="source">Area con los datos para el objeto</param>
        /// <param name="retrieve_childs">Flag para obtener también los hijos</param>
        /// <returns>Objeto creado</returns>
        /// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static RegistroDisponibilidad GetChild(RegistroDisponibilidad source, bool retrieve_childs)
        {
            return new RegistroDisponibilidad(source, retrieve_childs);
        }

        /// <summary>
        /// Crea un objeto
        /// </summary>
        /// <param name="reader">DataReader con los datos para el objeto</param>
        /// <returns>Objeto creado</returns>
        /// <remarks>
        /// La utiliza la BusinessListBaseEx correspondiente para montar la lista
        /// NO OBTIENE los hijos. Para ello utilice GetChild(IDataReader source, bool retrieve_childs)
        /// <remarks/>
        internal static RegistroDisponibilidad GetChild(IDataReader source)
        {
            return new RegistroDisponibilidad(source, false);
        }

        /// <summary>
        /// Crea un objeto
        /// </summary>
        /// <param name="source">IDataReader con los datos para el objeto</param>
        /// <param name="retrieve_childs">Flag para obtener también los hijos</param>
        /// <returns>Objeto creado</returns>
        /// <remarks>La utiliza la BusinessListBaseEx correspondiente para montar la lista<remarks/>
        internal static RegistroDisponibilidad GetChild(IDataReader source, bool retrieve_childs)
        {
            return new RegistroDisponibilidad(source, retrieve_childs);
        }

        /// <summary>
        /// Construye y devuelve un objeto de solo lectura copia de si mismo.
        /// También copia los datos de los hijos del objeto.
        /// </summary>
        /// <returns>Réplica de solo lectura del objeto</returns>
        public virtual RegistroDisponibilidadInfo GetInfo()
        {
            return GetInfo(true);
        }

        /// <summary>
        /// Construye y devuelve un objeto de solo lectura copia de si mismo.
        /// </summary>
        /// <param name="get_childs">Flag para solicitar que se copien los hijos</param>
        /// <returns>Réplica de solo lectura del objeto</returns>
        public virtual RegistroDisponibilidadInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new RegistroDisponibilidadInfo(this, get_childs);
        }

        #endregion

        #region Common Data Access

        [RunLocal()]
        private void DataPortal_Create(CriteriaCs criteria)
        {
            Random r = new Random();
            Oid = (long)r.Next();
        }

        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="source">Objeto fuente</param>
        private void Fetch(RegistroDisponibilidad source)
        {
            try
            {
                SessionCode = source.SessionCode;
                CopyValues(source);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="source">DataReader fuente</param>
        private void Fetch(IDataReader source)
        {
            try
            {
                CopyValues(source);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        #endregion

        #region Root Data Access

        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            try
            {
                SessionCode = criteria.SessionCode;
                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {
                    RegistroDisponibilidad.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        CopyValues(reader);
                }
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Insert()
        {
            try
            {
                SessionCode = OpenSession();
                BeginTransaction();
                Session().Save(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Update()
        {
            if (IsDirty)
            {
                try
                {
                    RegistroDisponibilidad obj = Session().Get<RegistroDisponibilidad>(Oid);
                    obj.CopyValues(this);
                    Session().Update(obj);
                }
                catch (Exception ex)
                {
                    iQExceptionHandler.TreatException(ex);
                }
            }
        }

        //Deferred deletion
        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new CriteriaCs(Oid));
        }

        [Transactional(TransactionalTypes.Manual)]
        private void DataPortal_Delete(CriteriaCs criteria)
        {
            try
            {
                // Iniciamos la conexion y la transaccion
                SessionCode = OpenSession();
                BeginTransaction();

                //Si no hay integridad referencial, aquí se deben borrar las listas hijo
                CriteriaEx criterio = GetCriteria();
                criterio.AddOidSearch(criteria.Oid);
                Session().Delete((DisponibilidadRecord)(criterio.UniqueResult()));
                Transaction().Commit();
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                CloseSession();
            }
        }

        #endregion

        #region Commands

        #endregion

    }
}

