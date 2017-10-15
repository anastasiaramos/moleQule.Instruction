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
	public class InformePreguntasInfo : ReadOnlyBaseEx<InformePreguntasInfo>
	{

        #region Business Methods

        private long _oid_modulo;
        private string _modulo = string.Empty;
        private int _preguntas_modulo;
        private long _oid_submodulo;
        private string _submodulo = string.Empty;
        private int _preguntas_submodulo;
        private int _nivel;
        private int _n_preguntas;
        private bool _desarrollo;

        public long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
        public string Modulo { get { return _modulo; } set { _modulo = value; } }
        public int PreguntasModulo { get { return _preguntas_modulo; } set { _preguntas_modulo = value; } }
        public long OidSubmodulo { get { return _oid_submodulo; } set { _oid_submodulo = value; } }
        public string Submodulo { get { return _submodulo; } set { _submodulo = value; } }
        public int PreguntasSubmodulo { get { return _preguntas_submodulo; } set { _preguntas_submodulo = value; } }
        public int Nivel { get { return _nivel; } set { _nivel = value; } }
        public int NPreguntas { get { return _n_preguntas; } set { _n_preguntas = value; } }
        public bool Desarrollo { get { return _desarrollo; } set { _desarrollo = value; } }
	
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues (InformePreguntas source)
		{
			if (source == null) return;
			
			Oid = source.Oid;

            _oid_modulo = source.OidModulo;
            _modulo = source.Modulo;
            _preguntas_modulo = source.PreguntasModulo;
            _oid_submodulo = source.OidSubmodulo;
            _submodulo = source.Submodulo;
            _preguntas_submodulo = source.PreguntasSubmodulo;
            _nivel = source.Nivel;
            _n_preguntas = source.NPreguntas;
            _desarrollo = source.Desarrollo;
		}
			
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues(IDataReader reader)
		{
            if (reader == null) return;

            Oid = Convert.ToInt64(Format.DataReader.GetString(reader, "OID_MODULO") + Format.DataReader.GetString(reader, "OID_SUBMODULO") + Format.DataReader.GetString(reader, "NIVEL") + (Format.DataReader.GetBool(reader, "DESARROLLO") ? "0" : "1"));
            _oid_modulo = Format.DataReader.GetInt64(reader, "OID_MODULO");
            _modulo = DBNull.Value.Equals(reader["MODULO"]) ? string.Empty : reader["MODULO"].ToString();
            _preguntas_modulo = Format.DataReader.GetInt32(reader, "PREGUNTAS_MODULO");
            _oid_submodulo = Format.DataReader.GetInt64(reader, "OID_SUBMODULO");
            _submodulo = DBNull.Value.Equals(reader["SUBMODULO"]) ? string.Empty : reader["SUBMODULO"].ToString();
            _preguntas_submodulo = Format.DataReader.GetInt32(reader, "PREGUNTAS_SUBMODULO");
            _nivel = Format.DataReader.GetInt32(reader, "NIVEL");
            _n_preguntas = Format.DataReader.GetInt32(reader, "N_PREGUNTAS");
            _desarrollo = Format.DataReader.GetBool(reader, "DESARROLLO");
        }

        public void CopyFrom(InformePreguntas source)
        {
            CopyValues(source);
        }
			
		#endregion		
		
		#region Factory Methods
		
		private InformePreguntasInfo() { /* require use of factory methods */ }
		
		private InformePreguntasInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		/// <summary>
		/// Contructor de AreaInfo a partir de un Area
		/// No copia los hijos
		/// </summary>
		/// <param name="item"></param>
		internal InformePreguntasInfo(InformePreguntas item)
			: this(item, false)
		{
		}

        internal InformePreguntasInfo(InformePreguntas item, bool childs)
		{
            Oid = item.Oid;

            _oid_modulo = item.OidModulo;
            _modulo = item.Modulo;
            _preguntas_modulo = item.PreguntasModulo;
            _oid_submodulo = item.OidSubmodulo;
            _submodulo = item.Submodulo;
            _preguntas_submodulo = item.PreguntasSubmodulo;
            _nivel = item.Nivel;
            _n_preguntas = item.NPreguntas;
            _desarrollo = item.Desarrollo;
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>

        public static InformePreguntasInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
        public static InformePreguntasInfo Get(long oid, bool childs)
		{
            CriteriaEx criteria = InformePreguntas.GetCriteria(InformePreguntas.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
                criteria.Query = InformePreguntas.SELECT(oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
            InformePreguntasInfo obj = DataPortal.Fetch<InformePreguntasInfo>(criteria);
            InformePreguntas.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
        public static InformePreguntasInfo Get(IDataReader reader, bool childs)
        {
            return new InformePreguntasInfo(reader, childs);
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



