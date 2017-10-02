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
	public class RegistroFaltasInfo : ReadOnlyBaseEx<RegistroFaltasInfo>
	{
	
		#region Business Methods
		
        private string _nombre = string.Empty;
        private string _apellidos = string.Empty;
        private string _n_expediente = string.Empty;
        private string _promocion = string.Empty;
        private string _modulo = string.Empty;
	    private string _submodulo = string.Empty;
        private string _clase = string.Empty;
        private DateTime _fecha;
        private DateTime _hora;
        private string _profesor = string.Empty;
        private long _total_modulo;
        private long _total_submodulo;
        private bool _recuperada = false;
        private DateTime _fecha_recuperacion;

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellidos { get { return _apellidos; } set { _apellidos = value; } }
        public string NExpediente { get { return _n_expediente; } set { _n_expediente = value; } }
        public string Promocion { get { return _promocion; } set { _promocion = value; } }
        public string Modulo { get { return _modulo; } set { _modulo = value; } }
        public string Submodulo{get{return _submodulo;}set{_submodulo=value;}}
        public string Clase {get{return _clase;}set{_clase=value;}}
        public DateTime Fecha {get{return _fecha;}set{_fecha = value;}}
        public DateTime Hora{get{return _hora;}set{_hora = value;}}
        public string Profesor{get{return _profesor;}set{_profesor=value;}}
        public long TotalModulo { get { return _total_modulo; } set { _total_modulo = value; } }
        public long TotalSubmodulo { get { return _total_submodulo; } set { _total_submodulo = value; } }
        public bool Recuperada { get { return _recuperada; } set { _recuperada = value; } }
        public DateTime FechaRecuperacion { get { return _fecha_recuperacion; } set { _fecha_recuperacion = value; } }
	
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues (RegistroFaltas source)
		{
			if (source == null) return;
			
			Oid = source.Oid;
			_nombre = source.Nombre;
            _apellidos = source.Apellidos;
            _n_expediente = source.NExpediente;
            _promocion = source.Promocion;
            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _clase = source.Clase;
            _fecha = source.Fecha;
            _hora = source.Hora;
            _profesor = source.Profesor;
            _total_modulo = source.TotalModulo;
            _total_submodulo = source.TotalSubmodulo;
            _recuperada = source.Recuperada;
            _fecha_recuperacion = source.FechaRecuperacion;
		}
			
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues(IDataReader reader)
		{
			if (reader == null) return;

            _nombre = DBNull.Value.Equals(reader["NOMBRE"]) ? string.Empty : reader["NOMBRE"].ToString();
            _apellidos = DBNull.Value.Equals(reader["APELLIDOS"]) ? string.Empty : reader["APELLIDOS"].ToString();
            _n_expediente = DBNull.Value.Equals(reader["N_EXPEDIENTE"]) ? string.Empty : reader["N_EXPEDIENTE"].ToString();
            _promocion = DBNull.Value.Equals(reader["PROMOCION"]) ? string.Empty : reader["PROMOCION"].ToString();
            _modulo = Format.DataReader.GetString(reader, "NUMERO_MODULO") + " " + Format.DataReader.GetString(reader, "MODULO");
            _submodulo = Format.DataReader.GetString(reader, "SUBMODULO");
            _clase = Format.DataReader.GetString(reader, "CLASE");
            _fecha = Format.DataReader.GetDateTime(reader, "FECHA");
            _hora = Format.DataReader.GetDateTime(reader, "HORA");
            _profesor = Format.DataReader.GetString(reader, "PROFESOR");
            _total_modulo = Format.DataReader.GetInt64(reader, "COUNT_MODULO");
            _total_submodulo = Format.DataReader.GetInt64(reader, "COUNT_SUBMODULO");
            _recuperada = Format.DataReader.GetBool(reader, "RECUPERADA");
            _fecha_recuperacion = Format.DataReader.GetDateTime(reader, "FECHA_RECUPERACION");

            Oid = Convert.ToInt64(Format.DataReader.GetInt64(reader, "OID_PROMOCION") + Format.DataReader.GetString(reader, "OID_ALUMNO") + Format.DataReader.GetString(reader, "OID_CLASE") + Format.DataReader.GetString(reader, "TIPO"));
		}

        public void CopyFrom(RegistroFaltas source)
        {
            CopyValues(source);
        }
			
		#endregion		
		
		#region Factory Methods
		
		private RegistroFaltasInfo() { /* require use of factory methods */ }
		
		private RegistroFaltasInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		/// <summary>
		/// Contructor de AreaInfo a partir de un Area
		/// No copia los hijos
		/// </summary>
		/// <param name="item"></param>
		internal RegistroFaltasInfo(RegistroFaltas item)
			: this(item, false)
		{
		}

        internal RegistroFaltasInfo(RegistroFaltas item, bool childs)
		{
            Oid = item.Oid;
            _nombre = item.Nombre;
            _apellidos = item.Apellidos;
            _n_expediente = item.NExpediente;
            _promocion = item.Promocion;
            _modulo = item.Modulo;
            _submodulo = item.Submodulo;
            _clase = item.Clase;
            _fecha = item.Fecha;
            _hora = item.Hora;
            _profesor = item.Profesor;
            _total_modulo = item.TotalModulo;
            _total_submodulo = item.TotalSubmodulo;
            _recuperada = item.Recuperada;
            _fecha_recuperacion = item.FechaRecuperacion;
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>

        public static RegistroFaltasInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
        public static RegistroFaltasInfo Get(long oid, bool childs)
		{
            CriteriaEx criteria = RegistroFaltas.GetCriteria(RegistroFaltas.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
                criteria.Query = RegistroFaltas.SELECT(oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
            RegistroFaltasInfo obj = DataPortal.Fetch<RegistroFaltasInfo>(criteria);
            RegistroFaltas.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
        public static RegistroFaltasInfo Get(IDataReader reader, bool childs)
        {
            return new RegistroFaltasInfo(reader, childs);
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



