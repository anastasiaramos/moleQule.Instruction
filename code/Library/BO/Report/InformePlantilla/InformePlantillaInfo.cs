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
	public class InformePlantillaInfo : ReadOnlyBaseEx<InformePlantillaInfo>
	{
	
		#region Business Methods

        private string _submodulo = string.Empty;
        private string _tema = string.Empty;
        private int _nivel;
        private int _n_preguntas;
        private int _disponibles;

        public string Submodulo { get { return _submodulo; } set { _submodulo = value; } }
        public string Tema { get { return _tema; } set { _tema = value; } }
        public int Nivel { get { return _nivel; } set { _nivel = value; } }
        public int NPreguntas { get { return _n_preguntas; } set { _n_preguntas = value; } }
        public int Disponibles { get { return _disponibles; } set { _disponibles = value; } }
	
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues (InformePlantilla source)
		{
			if (source == null) return;
			
			Oid = source.Oid;
            _submodulo = source.Submodulo;
            _tema = source.Tema;
            _nivel = source.Nivel;
            _n_preguntas = source.NPreguntas;
            _disponibles = source.Disponibles;
		}
			
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues(IDataReader reader)
		{
            if (reader == null) return;

            _submodulo = DBNull.Value.Equals(reader["SUBMODULO"]) ? string.Empty : reader["SUBMODULO"].ToString();
            _tema = DBNull.Value.Equals(reader["TEMA"]) ? string.Empty : reader["TEMA"].ToString();
            _nivel = Format.DataReader.GetInt32(reader, "NIVEL");
            _n_preguntas = Format.DataReader.GetInt32(reader, "N_PREGUNTAS");
            _disponibles = Format.DataReader.GetInt32(reader, "DISPONIBLES");

            Oid = Convert.ToInt64(Format.DataReader.GetString(reader, "OID") + Format.DataReader.GetString(reader, "OID_TEMA"));
        }

        public void CopyFrom(InformePlantilla source)
        {
            CopyValues(source);
        }
			
		#endregion		
		
		#region Factory Methods
		
		private InformePlantillaInfo() { /* require use of factory methods */ }
		
		private InformePlantillaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		/// <summary>
		/// Contructor de AreaInfo a partir de un Area
		/// No copia los hijos
		/// </summary>
		/// <param name="item"></param>
		internal InformePlantillaInfo(InformePlantilla item)
			: this(item, false)
		{
		}

        internal InformePlantillaInfo(InformePlantilla item, bool childs)
		{
            Oid = item.Oid;
            _submodulo = item.Submodulo;
            _nivel = item.Nivel;
            _n_preguntas = item.NPreguntas;
            _disponibles = item.Disponibles;
            _tema = item.Tema;
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>

        public static InformePlantillaInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
        public static InformePlantillaInfo Get(long oid, bool childs)
		{
            CriteriaEx criteria = InformePlantilla.GetCriteria(InformePlantilla.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
                criteria.Query = InformePlantilla.SELECT(oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
            InformePlantillaInfo obj = DataPortal.Fetch<InformePlantillaInfo>(criteria);
            InformePlantilla.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
        public static InformePlantillaInfo Get(IDataReader reader, bool childs)
        {
            return new InformePlantillaInfo(reader, childs);
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



