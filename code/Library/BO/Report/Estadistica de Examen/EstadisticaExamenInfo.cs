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
	public class EstadisticaExamenInfo : ReadOnlyBaseEx<EstadisticaExamenInfo>
	{
	
		#region Business Methods

        private long _numero_pregunta;
        private long _total_fallos = 0;
        private decimal _porcentaje_fallos = 0;
        private bool _anulada = false;
        private string _numero_pregunta_banco = string.Empty;
        private long _nivel;
        private string _tema = string.Empty;

        public long NumeroPregunta { get { return _numero_pregunta; } }
        public long TotalFallos { get { return _total_fallos; } }
        public decimal PorcentajeFallos { get { return _porcentaje_fallos; } }
        public bool Anulada { get { return _anulada; } }
        public string NumeroPreguntaBanco { get { return _numero_pregunta_banco; } }
        public long Nivel { get { return _nivel; } }
        public string Tema { get { return _tema; } }
	
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues (EstadisticaExamen source)
		{
            if (source == null) return;

            Oid = source.Oid;
            _numero_pregunta = source.NumeroPregunta;
            _total_fallos = source.TotalFallos;
            _porcentaje_fallos = source.PorcentajeFallos;
            _anulada = source.Anulada;
            _numero_pregunta_banco = source.NumeroPreguntaBanco;
            _nivel = source.Nivel;
            _tema = source.Tema;
			
		}
			
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected void CopyValues(IDataReader source)
		{
            if (source == null) return;

            Oid = Format.DataReader.GetInt64(source, "OID");
            _numero_pregunta = Format.DataReader.GetInt64(source, "NUMERO_PREGUNTA");
            _total_fallos = Format.DataReader.GetInt64(source, "TOTAL_FALLOS");
            _porcentaje_fallos = Format.DataReader.GetDecimal(source, "PORCENTAJE_FALLOS");
            _anulada = Format.DataReader.GetBool(source, "ANULADA");
            _numero_pregunta_banco = Format.DataReader.GetString(source, "NUMERO_PREGUNTA_BANCO");
            _nivel = Format.DataReader.GetInt64(source, "NIVEL");
            _tema = Format.DataReader.GetString(source, "TEMA");
		}

        public void CopyFrom(EstadisticaExamen source)
        {
            CopyValues(source);
        }
			
		#endregion		
		
		#region Factory Methods
		
		public EstadisticaExamenInfo() { /* require use of factory methods */ }
		
		private EstadisticaExamenInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
			
		/// <summary>
		/// Contructor de AreaInfo a partir de un Area
		/// No copia los hijos
		/// </summary>
		/// <param name="item"></param>
		internal EstadisticaExamenInfo(EstadisticaExamen item)
			: this(item, false)
		{
		}

        internal EstadisticaExamenInfo(EstadisticaExamen item, bool childs)
        {
            Oid = item.Oid;
            _numero_pregunta = item.NumeroPregunta;
            _total_fallos = item.TotalFallos;
            _porcentaje_fallos = item.PorcentajeFallos;
            _anulada = item.Anulada;
            _numero_pregunta_banco = item.NumeroPreguntaBanco;
            _nivel = item.Nivel;
            _tema = item.Tema;
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>

        public static EstadisticaExamenInfo Get(long oid)
		{
			return Get(oid, false);
		}
		
		/// <summary>
		/// Devuelve un AreaInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
        public static EstadisticaExamenInfo Get(long oid, bool childs)
		{
            CriteriaEx criteria = EstadisticaExamen.GetCriteria(EstadisticaExamen.OpenSession());
			
			if (nHManager.Instance.UseDirectSQL)
                criteria.Query = EstadisticaExamen.SELECT(oid);
			else
				criteria.AddOidSearch(oid);
				
			criteria.Childs = childs;
            EstadisticaExamenInfo obj = DataPortal.Fetch<EstadisticaExamenInfo>(criteria);
            EstadisticaExamen.CloseSession(criteria.SessionCode);
			return obj;
		}
		
		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
        public static EstadisticaExamenInfo Get(IDataReader reader, bool childs)
        {
            return new EstadisticaExamenInfo(reader, childs);
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



