using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// ReadOnly Root Business Object with ReadOnly Childs
    /// </summary>
	[Serializable()]
	public class RegistroDisponibilidadInfo : ReadOnlyBaseEx<RegistroDisponibilidadInfo>
	{
	
		#region Business Methods
		
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

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellidos { get { return _apellidos; } set { _apellidos = value; } }
        public bool LunesM { get { return _lunes_m; } set { _lunes_m = value; } }
        public bool MartesM { get { return _martes_m; } set { _martes_m = value; } }
        public bool MiercolesM { get { return _miercoles_m; } set { _miercoles_m = value; } }
        public bool JuevesM { get { return _jueves_m; } set { _jueves_m = value; } }
        public bool ViernesM { get { return _viernes_m; } set { _viernes_m = value; } }
        public bool SabadoM { get { return _sabado_m; } set { _sabado_m = value; } }
        public bool LunesT1 { get { return _lunes_t1; } set { _lunes_t1 = value; } }
        public bool MartesT1 { get { return _martes_t1; } set { _martes_t1 = value; } }
        public bool MiercolesT1 { get { return _miercoles_t1; } set { _miercoles_t1 = value; } }
        public bool JuevesT1 { get { return _jueves_t1; } set { _jueves_t1 = value; } }
        public bool ViernesT1 { get { return _viernes_t1; } set { _viernes_t1 = value; } }
        public bool SabadoT1 { get { return _sabado_t1; } set { _sabado_t1 = value; } }
        public bool LunesT2 { get { return _lunes_t2; } set { _lunes_t2 = value; } }
        public bool MartesT2 { get { return _martes_t2; } set { _martes_t2 = value; } }
        public bool MiercolesT2 { get { return _miercoles_t2; } set { _miercoles_t2 = value; } }
        public bool JuevesT2 { get { return _jueves_t2; } set { _jueves_t2 = value; } }
        public bool ViernesT2 { get { return _viernes_t2; } set { _viernes_t2 = value; } }
        public bool SabadoT2 { get { return _sabado_t2; } set { _sabado_t2 = value; } }
        public bool LunesND { get { return _lunes_nd; } set { _lunes_nd = value; } }
        public bool MartesND { get { return _martes_nd; } set { _martes_nd = value; } }
        public bool MiercolesND { get { return _miercoles_nd; } set { _miercoles_nd = value; } }
        public bool JuevesND { get { return _jueves_nd; } set { _jueves_nd = value; } }
        public bool ViernesND { get { return _viernes_nd; } set { _viernes_nd = value; } }
        public bool SabadoND { get { return _sabado_nd; } set { _sabado_nd = value; } }


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
	
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues (RegistroDisponibilidad source)
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

        public void CopyFrom(RegistroDisponibilidad source)
        {
            CopyValues(source);
        }
			
		#endregion		
		
		#region Factory Methods
		
		private RegistroDisponibilidadInfo() { /* require use of factory methods */ }
		
		private RegistroDisponibilidadInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		/// <summary>
		/// Contructor de AreaInfo a partir de un Area
		/// No copia los hijos
		/// </summary>
		/// <param name="item"></param>
		internal RegistroDisponibilidadInfo(RegistroDisponibilidad item)
			: this(item, false)
		{
		}

        internal RegistroDisponibilidadInfo(RegistroDisponibilidad item, bool childs)
		{
            Oid = item.Oid;
            _nombre = item.Nombre;
            _apellidos = item.Apellidos;
            _lunes_m = item.LunesM;
            _martes_m = item.MartesM;
            _miercoles_m = item.MiercolesM;
            _jueves_m = item.JuevesM;
            _viernes_m = item.ViernesM;
            _sabado_m = item.SabadoM;
            _lunes_t1 = item.LunesT1;
            _martes_t1 = item.MartesT1;
            _miercoles_t1 = item.MiercolesT1;
            _jueves_t1 = item.JuevesT1;
            _viernes_t1 = item.ViernesT1;
            _sabado_t1 = item.SabadoT1;
            _lunes_t2 = item.LunesT2;
            _martes_t2 = item.MartesT2;
            _miercoles_t2 = item.MiercolesT2;
            _jueves_t2 = item.JuevesT2;
            _viernes_t2 = item.ViernesT2;
            _sabado_t2 = item.SabadoT2;
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>

        public static RegistroDisponibilidadInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
        public static RegistroDisponibilidadInfo Get(long oid, bool childs)
		{
            CriteriaEx criteria = RegistroDisponibilidad.GetCriteria(RegistroDisponibilidad.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
                criteria.Query = RegistroDisponibilidad.SELECT(oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
            RegistroDisponibilidadInfo obj = DataPortal.Fetch<RegistroDisponibilidadInfo>(criteria);
            RegistroDisponibilidad.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
        public static RegistroDisponibilidadInfo Get(IDataReader reader, bool childs)
        {
            return new RegistroDisponibilidadInfo(reader, childs);
		}
		
 		#endregion
		 
		#region Data Access
		 
		// called to retrieve data from db
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			SessionCode = criteria.SessionCode;
			Childs = criteria.Childs;
			try
			{
				if (nHMng.UseDirectSQL)
				{
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());
					if (reader.Read())
						CopyValues(reader);
					
                    if (Childs)
					{
						string query = string.Empty;
						
                        
                    }
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		//called to copy data from IDataReader
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
		}
		
		#endregion
	}
}



