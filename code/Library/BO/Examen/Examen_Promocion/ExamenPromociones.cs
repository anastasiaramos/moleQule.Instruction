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
	/// Editable Business Object Child Collection
	/// </summary>
    [Serializable()]
    public class ExamenPromociones : BusinessListBaseEx<ExamenPromociones, ExamenPromocion>
    {
		#region Business Methods
        		
		/// <summary>
		/// Crea un nuevo elemento y lo añade a la lista
		/// </summary>
		/// <returns>Nuevo item</returns>
		public ExamenPromocion NewItem(Examen parent)
		{
			this.NewItem(ExamenPromocion.NewChild(parent));
			ExamenPromocion item = this[Count - 1];
			return item;
		}
		
		
		#endregion
		
		#region Common Factory Methods

		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
        private ExamenPromociones() { }

		#endregion		
		
		#region Child Factory Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lista">IList de objetos</param>
        /// <remarks>NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods</remarks>
        private ExamenPromociones(IList<ExamenPromocion> lista)
		{
			MarkAsChild();
			Fetch(lista);
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lista">IList de objetos</param>
        /// <param name="retrieve_childs">Flag para indicar si quiere obtener los hijos</param>
		
        private ExamenPromociones(int sessionCode, IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
			SessionCode = sessionCode;
            Fetch(reader);
        }
		
		
		/// <summary>
        /// Construye una nueva lista vacía
        /// </summary>
        /// <returns>Lista vacía</returns>
        public static ExamenPromociones NewChildList() 
        { 
            ExamenPromociones list = new ExamenPromociones(); 
            list.MarkAsChild(); 
            return list; 
        }
		
		/// <summary>
        /// Construye una nueva lista
        /// </summary>
        /// <param name="lista">IList origen</param>
        /// <returns>Lista creada</returns>
		public static ExamenPromociones GetChildList(IList<ExamenPromocion> lista) { return new ExamenPromociones(lista); }

        /// <summary>
        /// Construye una nueva lista
        /// </summary>
        /// <param name="reader">IDataReader origen</param>
        /// <returns>Lista creada</returns>
        /// <remarks>Obtiene los hijos</remarks>
		
        public static ExamenPromociones GetChildList(int sessionCode,IDataReader reader) { return GetChildList(sessionCode, reader, true); }
        public static ExamenPromociones GetChildList(int sessionCode,IDataReader reader, bool childs) { return new ExamenPromociones(sessionCode, reader, childs); }
		
		#endregion
		
		#region Child Data Access

		/// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="lista">IList origen</param>
        private void Fetch(IList<ExamenPromocion> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (ExamenPromocion item in lista)
				this.AddItem(ExamenPromocion.GetChild(item, Childs));

			this.RaiseListChangedEvents = true;
		}
		
        /// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="reader">IDataReader origen con los elementos a insertar</param>
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(ExamenPromocion.GetChild(SessionCode, reader, Childs));

            this.RaiseListChangedEvents = true;
        }

		
        /// <summary>
        /// Realiza el Save de los objetos de la lista. Inserta, Actualiza o Borra en función
		/// de los flags de cada objeto de la lista
		/// </summary>
		/// <param name="parent">BusinessBaseEx padre de la lista</param>
		internal void Update(Examen parent)
		{
			try
			{
				this.RaiseListChangedEvents = false;

				SessionCode = parent.SessionCode;
				
				// update (thus deleting) any deleted child objects
				foreach (ExamenPromocion obj in DeletedList)
					obj.DeleteSelf(parent);

				// now that they are deleted, remove them from memory too
				DeletedList.Clear();

				// add/update any current child objects
				foreach (ExamenPromocion obj in this)
				{	
					if (!this.Contains(obj))
					{
						if (obj.IsNew)
							obj.Insert(parent);
						else
							obj.Update(parent);
					}
				}
			}
			finally
			{
				this.RaiseListChangedEvents = true;
			}
		}
		
		#endregion
			
        #region SQL

        public new static string SELECT() { return ExamenPromocion.SELECT(new QueryConditions()); }
		public static string SELECT(QueryConditions conditions) { return ExamenPromocion.SELECT(conditions, true); }
		
		public static string SELECT(Examen parent) { return ExamenPromocion.SELECT(new QueryConditions{ Examen = parent.GetInfo(false) }, true); }
			
		#endregion
    }
}

