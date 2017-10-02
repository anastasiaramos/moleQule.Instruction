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
	/// ReadOnly Child Object
	/// </summary>
	[Serializable()]
	public class ExamenPromocionInfo : ReadOnlyBaseEx<ExamenPromocionInfo>
	{	
		#region Attributes

		protected ExamenPromocionBase _base = new ExamenPromocionBase();

		
		#endregion
		
		#region Properties

        public ExamenPromocionBase Base { get { return _base; } }

        public override long Oid { get { return _base._record.Oid; } set { _base._record.Oid = value; } }
		public long OidExamen { get { return _base._record.OidExamen; } }
		public long OidPromocion { get { return _base._record.OidPromocion; } }
		
		
		#endregion
		
		#region Business Methods
						
		public void CopyFrom(ExamenPromocion source) { _base.CopyValues(source); }
			
		#endregion		
		
		#region Common Factory Methods
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		protected ExamenPromocionInfo() { /* require use of factory methods */ }
		private ExamenPromocionInfo(int sessionCode, IDataReader reader, bool childs)
		{
			Childs = childs;
			SessionCode = sessionCode;
			Fetch(reader);
		}
		internal ExamenPromocionInfo(ExamenPromocion item, bool copy_childs)
		{
			_base.CopyValues(item);
			
			if (copy_childs)
			{
				
			}
		}
		
		public static ExamenPromocionInfo GetChild(int sessionCode, IDataReader reader) { return GetChild(sessionCode, reader, false); }
		public static ExamenPromocionInfo GetChild(int sessionCode, IDataReader reader, bool childs)
        {
			return new ExamenPromocionInfo(sessionCode, reader, childs);
		}
		
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
					
        #region SQL

        public static string SELECT(long oid) { return ExamenPromocion.SELECT(oid, false); }
		public static string SELECT(QueryConditions conditions) { return ExamenPromocion.SELECT(conditions, false); }
		
		public static string SELECT(ExamenInfo item) { return SELECT(new Library.Instruction.QueryConditions { Examen = item }); }
			
		
        #endregion		
	}
}
