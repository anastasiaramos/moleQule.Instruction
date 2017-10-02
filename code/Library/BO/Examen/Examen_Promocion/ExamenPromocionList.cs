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
	/// ReadOnly Business Object Child Collection
	/// </summary>
    [Serializable()]
	public class ExamenPromocionList : ReadOnlyListBaseEx<ExamenPromocionList, ExamenPromocionInfo>
	{	
		#region Business Methods
			
		#endregion
		 
		#region Common Factory Methods
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private ExamenPromocionList() {}
		private ExamenPromocionList(IList<ExamenPromocion> list, bool childs)
        {
			Childs = childs;
            Fetch(list);
        }
		private ExamenPromocionList(IList<ExamenPromocionInfo> list, bool childs)
        {
			Childs = childs;
            Fetch(list);
        }
		
		#endregion
		
		#region Child Factory Methods
						
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
		private ExamenPromocionList(int sessionCode, IDataReader reader, bool childs)
        {
			SessionCode = sessionCode;
			Childs = childs;
			SessionCode = sessionCode;
            Fetch(reader);
        }		
		/// <summary>
		/// Construye la lista
		/// </summary>
		/// <param name="list">IList origen</param>
        /// <returns>Lista de objetos de solo lectura</returns>
		/// <remarks>NO OBTIENE LOS HIJOS SI EL OBJETO NO LOS TIENE CARGADOS</remarks>
		public static ExamenPromocionList GetChildList(IList<ExamenPromocion> list) { return new ExamenPromocionList(list, false); }
		public static ExamenPromocionList GetChildList(IList<ExamenPromocion> list, bool childs) { return new ExamenPromocionList(list, childs); }

		/// <summary>
        /// Construye la lista
        /// </summary>
        /// <param name="reader">IDataReader</param>
        /// <returns>Lista de objetos de solo lectura</returns>
        /// <remarks>NO OBTIENE LOS HIJOS SI EL OBJETO NO LOS TIENE CARGADOS</remarks>
		public static ExamenPromocionList GetChildList(int sessionCode, IDataReader reader) { return new ExamenPromocionList(sessionCode, reader, false); } 
		public static ExamenPromocionList GetChildList(int sessionCode, IDataReader reader, bool childs) { return new ExamenPromocionList(sessionCode, reader, childs); }
		/// <summary>
		/// Construye la lista
		/// </summary>
		/// <param name="list">IList origen</param>
        /// <returns>Lista de objetos de solo lectura</returns>
		/// <remarks>NO OBTIENE LOS HIJOS SI EL OBJETO NO LOS TIENE CARGADOS</remarks>
        public static ExamenPromocionList GetChildList(IList<ExamenPromocionInfo> list) { return new ExamenPromocionList(list, false); }
		
		#endregion
		
		#region Common Data Access

		/// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="lista">IList origen</param>
		private void Fetch(IList<ExamenPromocion> lista)
		{
			this.RaiseListChangedEvents = false;

			IsReadOnly = false;
			
			foreach (ExamenPromocion item in lista)
				this.AddItem(item.GetInfo(Childs));

			IsReadOnly = true;

			this.RaiseListChangedEvents = true;
		}

        /// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="reader">IDataReader origen</param>
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
                this.AddItem(ExamenPromocionInfo.GetChild(SessionCode, reader, Childs));

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }
		
        #endregion
		
        #region SQL

        public static string SELECT() { return ExamenPromocionInfo.SELECT(new QueryConditions()); }
		public static string SELECT(QueryConditions conditions) { return ExamenPromocion.SELECT(conditions, false); }
		
		public static string SELECT(ExamenInfo parent) { return  ExamenPromocion.SELECT(new QueryConditions{ Examen = parent }, true); }
		
		#endregion		
	}
}
