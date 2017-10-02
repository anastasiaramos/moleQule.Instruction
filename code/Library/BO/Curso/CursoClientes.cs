using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Invoice;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// Editable Business Object Child Collection
	/// </summary>
    [Serializable()]
    public class CursoClientes : BusinessListBaseEx<CursoClientes, CursoCliente>
    {
		
		#region Child Business Methods
		
		/// <summary>
		/// Crea un nuevo elemento y lo añade a la lista
		/// </summary>
		/// <returns>Nuevo item</returns>
		public CursoCliente NewItem(Cliente parent)
		{
			this.NewItem(CursoCliente.NewChild(parent));
			return this[Count - 1];
		}
		
		/// <summary>
		/// Crea un nuevo elemento y lo añade a la lista
		/// </summary>
		/// <returns>Nuevo item</returns>
		public CursoCliente NewItem(Curso parent)
		{
			this.NewItem(CursoCliente.NewChild(parent));
			return this[Count - 1];
		}
		
		#endregion
		
		#region Common Factory Methods

		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
        private CursoClientes() { }

		#endregion		
		
		#region Child Factory Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lista">IList de objetos</param>
        /// <remarks>NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods</remarks>
        private CursoClientes(IList<CursoCliente> lista)
		{
			MarkAsChild();
			Fetch(lista);
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lista">IList de objetos</param>
        /// <param name="retrieve_childs">Flag para indicar si quiere obtener los hijos</param>
        private CursoClientes(IDataReader reader, bool retrieve_childs)
        {
            MarkAsChild();
            Childs = retrieve_childs;
            Fetch(reader);
        }
		
		/// <summary>
        /// Construye una nueva lista vacía
        /// </summary>
        /// <returns>Lista vacía</returns>
        public static CursoClientes NewChildList() 
        { 
            CursoClientes list = new CursoClientes(); 
            list.MarkAsChild(); 
            return list; 
        }
		
		/// <summary>
        /// Construye una nueva lista
        /// </summary>
        /// <param name="lista">IList origen</param>
        /// <returns>Lista creada</returns>
		public static CursoClientes GetChildList(IList<CursoCliente> lista) { return new CursoClientes(lista); }

        /// <summary>
        /// Construye una nueva lista
        /// </summary>
        /// <param name="reader">IDataReader origen</param>
        /// <returns>Lista creada</returns>
        /// <remarks>Obtiene los hijos</remarks>
        public static CursoClientes  GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        /// <summary>
        /// Construye una nueva lista
        /// </summary>
        /// <param name="reader">IDataReader origen</param>
        /// <param name="retrieve_childs">Flag para indicar si quiere obtener los hijos</param>
        /// <returns>Lista creada</returns>
        /// <remarks>Obtiene los hijos</remarks>
        public static CursoClientes GetChildList(IDataReader reader, bool retrieve_childs) { return new CursoClientes(reader, retrieve_childs); }

		#endregion
		
		#region Child Data Access

		/// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="lista">IList origen</param>
        private void Fetch(IList<CursoCliente> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (CursoCliente item in lista)
				this.AddItem(CursoCliente.GetChild(item, Childs));

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
                this.AddItem(CursoCliente.GetChild(reader, Childs));

            this.RaiseListChangedEvents = true;
        }

		
        /// <summary>
        /// Realiza el Save de los objetos de la lista. Inserta, Actualiza o Borra en función
		/// de los flags de cada objeto de la lista
		/// </summary>
		/// <param name="parent">BusinessBaseEx padre de la lista</param>
		internal void Update(Cliente parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (CursoCliente obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// add/update any current child objects
			foreach (CursoCliente obj in this)
			{	
				if (!this.Contains(obj))
				{
					if (obj.IsNew)
						obj.Insert(parent);
					else
						obj.Update(parent);
				}
			}

			this.RaiseListChangedEvents = true;
		}
		
        /// <summary>
        /// Realiza el Save de los objetos de la lista. Inserta, Actualiza o Borra en función
		/// de los flags de cada objeto de la lista
		/// </summary>
		/// <param name="parent">BusinessBaseEx padre de la lista</param>
		internal void Update(Curso parent)
		{
			this.RaiseListChangedEvents = false;

			// update (thus deleting) any deleted child objects
			foreach (CursoCliente obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// add/update any current child objects
			foreach (CursoCliente obj in this)
			{	
				if (!this.Contains(obj))
				{
					if (obj.IsNew)
						obj.Insert(parent);
					else
						obj.Update(parent);
				}
			}

			this.RaiseListChangedEvents = true;
		}
		
		#endregion

        #region SQL

        /// <summary>
        /// Construye el SELECT de la lista
        /// </summary>
        /// <param name="parent_field"></param>
        /// <param name="field_value"></param>
        /// <param name="order_field"></param>
        /// <returns></returns>
        public new static string SELECT(string filter_field, object field_value, string order_field)
        {
            string tabla = string.Empty;
            string cursos = string.Empty;
            string clientes = string.Empty;
            string columna = string.Empty;
            Type type = typeof(CursoCliente);

            tabla = nHManager.Instance.GetSQLTable(type);
            cursos = nHManager.Instance.GetSQLTable(typeof(Curso));
            clientes = nHManager.Instance.GetSQLTable(typeof(Cliente));

            string query = "SELECT " + tabla + ".*, " + cursos + ".\"NOMBRE\" AS \"CURSO\", " + clientes + ".\"NOMBRE\" AS CLIENTE " +
                            " FROM " + tabla +
                            " INNER JOIN " + cursos + " ON (" + cursos + ".\"OID\" = " + tabla + ".\"OID_CURSO\") " +
                            " INNER JOIN " + clientes + " ON (" + clientes + ".\"OID\" = " + tabla + ".\"OID_CURSO\") ";

            if (filter_field != null)
            {
                columna = filter_field == "Oid" ? "OID" : nHManager.Instance.GetTableField(type, filter_field);
                query += " WHERE \"" + columna + "\" = " + field_value.ToString();
            }

            if (order_field != null)
            {
                columna = order_field == "Oid" ? "OID" : nHManager.Instance.GetTableField(type, order_field);
                query += " ORDER BY \"" + columna + "\"";
            }

            //query += " FOR UPDATE NOWAIT;";
            query += ";";

            return query;
        }

        #endregion
    }
}

