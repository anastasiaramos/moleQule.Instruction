using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// ReadOnly Root Object
	/// ReadOnly Child Object
	/// </summary>
	[Serializable()]
	public class FestivoInfo : ReadOnlyBaseEx<FestivoInfo>
    {

        #region Attributes

        protected FestivoBase _base = new FestivoBase();

        #endregion

        #region Properties

        public FestivoBase Base { get { return _base; } }

        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public DateTime FechaInicio { get { return _base.Record.FechaInicio; } set { _base.Record.FechaInicio = value; } }
        public DateTime FechaFin { get { return _base.Record.FechaFin; } set { _base.Record.FechaFin = value; } }
		public bool Anual { get { return _base.Record.Anual; } }
		public long Tipo { get { return _base.Record.Tipo; } }
        public string Titulo { get { return _base.Record.Titulo; } }
        public string Descripcion { get { return _base.Record.Descripcion; } }

        public virtual ETipoDiaNoLectivo ETipo { get { return _base.ETipo; } set { _base.Record.Tipo = (long)value; } }
        public virtual string TipoLabel { get { return Library.Instruction.EnumText<ETipoDiaNoLectivo>.GetLabel(ETipo); } }		
		
		#endregion
		
		#region Business Methods

        public void CopyFrom(Festivo source) { _base.CopyValues(source); }
        public void CopyFrom(FestivoInfo source) { _base.CopyValues(source); }
			
		#endregion		
		
		#region Common Factory Methods
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		protected FestivoInfo() { /* require use of factory methods */ }
		private FestivoInfo(int sessionCode, IDataReader reader, bool childs)
		{
			Childs = childs;
			SessionCode = sessionCode;
			Fetch(reader);
		}
		internal FestivoInfo(Festivo item, bool copy_childs)
		{
			_base.CopyValues(item);
			
			if (copy_childs)
			{
				
			}
		}
		
		public static FestivoInfo GetChild(int sessionCode, IDataReader reader) { return GetChild(sessionCode, reader, false); }
		public static FestivoInfo GetChild(int sessionCode, IDataReader reader, bool childs)
        {
			return new FestivoInfo(sessionCode, reader, childs);
		}
		
 		#endregion
		
		#region Root Factory Methods
		
		/// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> de la base de datos
        /// </summary>
        /// <param name="oid">Oid del objeto</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
        public static FestivoInfo Get(long oid) { return Get(oid, false); }
		public static FestivoInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = Festivo.GetCriteria(Festivo.OpenSession());
			criteria.Childs = childs;

			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = FestivoInfo.SELECT(oid);
	
			FestivoInfo obj = DataPortal.Fetch<FestivoInfo>(criteria);
			Festivo.CloseSession(criteria.SessionCode);
			return obj;
		}

        public static FestivoInfo New(long oid = 0) { return new FestivoInfo() { Oid = oid }; }
		
		#endregion
					
		#region Common Data Access
								
        /// <summary>
        /// Obtiene un objeto a partir de un <see cref="IDataReader"/>.
        /// Obtiene los hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria"><see cref="IDataReader"/> con los datos</param>
        /// <remarks>
        /// La utiliza el <see cref="ReadOnlyListBaseEx"/> correspondiente para construir los objetos de la lista
        /// </remarks>
		private void Fetch(IDataReader source)
		{
			try
			{
				_base.CopyValues(source);
				
			}
            catch (Exception ex) { throw ex; }
		}
		
		#endregion
		
		#region Root Data Access
		 
        /// <summary>
        /// Obtiene un registro de la base de datos
        /// </summary>
        /// <param name="criteria"><see cref="CriteriaEx"/> con los criterios</param>
        /// <remarks>
        /// La llama el DataPortal
        /// </remarks>
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
						_base.CopyValues(reader);
					
				}
			}
            catch (Exception ex) { iQExceptionHandler.TreatException(ex); }
		}
		
		#endregion
					
        #region SQL

        public static string SELECT(long oid) { return Festivo.SELECT(oid, false); }
		public static string SELECT(QueryConditions conditions) { return Festivo.SELECT(conditions, false); }
		
        #endregion		
	}
}
