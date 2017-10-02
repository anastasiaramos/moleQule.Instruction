using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using NHibernate;

using moleQule.Library;
using moleQule.Library.CslaEx;
using moleQule.Library.Invoice;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// Editable Business Object Child Collection
	/// </summary>
    [Serializable()]
    public class AlumnoClientes : BusinessListBaseEx<AlumnoClientes, AlumnoCliente>
    {
		
		#region Child Business Methods
		
		/// <summary>
		/// Crea un nuevo elemento y lo añade a la lista
		/// </summary>
		/// <returns>Nuevo item</returns>
		public AlumnoCliente NewItem(Cliente parent)
		{
			this.NewItem(AlumnoCliente.NewChild(parent));
			return this[Count - 1];
		}

        public AlumnoCliente GetItemByAlumno(long oid_alumno)
        {
            foreach (AlumnoCliente item in this)
                if (item.OidAlumno == oid_alumno)
                    return item;

            return null;
        }
		
		#endregion
		
		#region Common Factory Methods

		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods
        /// </remarks>
        private AlumnoClientes() { }

		#endregion		
		
		#region Child Factory Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lista">IList de objetos</param>
        /// <remarks>NO UTILIZAR DIRECTAMENTE. Objet creation require use of factory methods</remarks>
        private AlumnoClientes(IList<AlumnoCliente> lista)
		{
			MarkAsChild();
			Fetch(lista);
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lista">IList de objetos</param>
        /// <param name="retrieve_childs">Flag para indicar si quiere obtener los hijos</param>
        private AlumnoClientes(IDataReader reader, bool retrieve_childs)
        {
            MarkAsChild();
            Childs = retrieve_childs;
            Fetch(reader);
        }
		
		/// <summary>
        /// Construye una nueva lista vacía
        /// </summary>
        /// <returns>Lista vacía</returns>
        public static AlumnoClientes NewChildList() 
        { 
            AlumnoClientes list = new AlumnoClientes(); 
            list.MarkAsChild(); 
            return list; 
        }
		
		/// <summary>
        /// Construye una nueva lista
        /// </summary>
        /// <param name="lista">IList origen</param>
        /// <returns>Lista creada</returns>
		public static AlumnoClientes GetChildList(IList<AlumnoCliente> lista) { return new AlumnoClientes(lista); }

        /// <summary>
        /// Construye una nueva lista
        /// </summary>
        /// <param name="reader">IDataReader origen</param>
        /// <returns>Lista creada</returns>
        /// <remarks>Obtiene los hijos</remarks>
        public static AlumnoClientes  GetChildList(IDataReader reader) { return GetChildList(reader, true); }

        /// <summary>
        /// Construye una nueva lista
        /// </summary>
        /// <param name="reader">IDataReader origen</param>
        /// <param name="retrieve_childs">Flag para indicar si quiere obtener los hijos</param>
        /// <returns>Lista creada</returns>
        /// <remarks>Obtiene los hijos</remarks>
        public static AlumnoClientes GetChildList(IDataReader reader, bool retrieve_childs) { return new AlumnoClientes(reader, retrieve_childs); }

		#endregion
		
		#region Child Data Access

		/// <summary>
        /// Construye la lista y obtiene los datos de los hijos de la bd
		/// </summary>
		/// <param name="lista">IList origen</param>
        private void Fetch(IList<AlumnoCliente> lista)
		{
			this.RaiseListChangedEvents = false;

			foreach (AlumnoCliente item in lista)
				this.AddItem(AlumnoCliente.GetChild(item, Childs));

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
                this.AddItem(AlumnoCliente.GetChild(reader, Childs));

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
			foreach (AlumnoCliente obj in DeletedList)
				obj.DeleteSelf(parent);

			// now that they are deleted, remove them from memory too
			DeletedList.Clear();

			// add/update any current child objects
			foreach (AlumnoCliente obj in this)
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
        public static string SELECT(string filter_field, object field_value)
        {
            string tabla = nHManager.Instance.GetSQLTable(typeof(AlumnoClienteRecord));
            string alumnos = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string clientes = nHManager.Instance.GetSQLTable(typeof(ClientRecord));

            string query = "SELECT  AC.*," +
                            "       A.\"CODIGO\" AS \"N_ALUMNO\"," + 
                            "       (A.\"APELLIDOS\" || ', ' || A.\"NOMBRE\") AS \"ALUMNO\"," + 
                            "       C.\"NOMBRE\" AS \"CLIENTE\"" +
                            " FROM " + tabla + " AS AC" +
                            " INNER JOIN " + alumnos + " AS A ON (A.\"OID\" = AC.\"OID_ALUMNO\")" +
                            " INNER JOIN " + clientes + " AS C ON (C.\"OID\" = AC.\"OID_CLIENTE\")";

            if (filter_field != null)
            {
                string columna = (filter_field == "Oid") ? "OID" : nHManager.Instance.GetTableField(typeof(AlumnoClienteRecord), filter_field);
                query += " WHERE AC.\"" + columna + "\" = " + field_value.ToString();
            }

            query += " ORDER BY A.\"APELLIDOS\", A.\"NOMBRE\"";

            //query += " FOR UPDATE NOWAIT;";
            
            return query;
        }

        #endregion
    }
}

