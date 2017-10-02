using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;

using Csla;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Invoice;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// ReadOnly Child Object
	/// </summary>
	[Serializable()]
	public class AlumnoClienteInfo : ReadOnlyBaseEx<AlumnoClienteInfo>
    {
        #region Attributes

        protected AlumnoClienteBase _base = new AlumnoClienteBase();


        #endregion

        #region Properties

        public AlumnoClienteBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidAlumno { get { return _base.Record.OidAlumno; } }
        public long OidCliente { get { return _base.Record.OidCliente; } }

        public string NAlumno { get { return _base.NAlumno; } }
        public string Alumno { get { return _base.Alumno; } }
        public string Cliente { get { return _base.Cliente; } }



        #endregion
		
		#region Business Methods
							
		#endregion		
		
		#region Common Factory Methods
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		protected AlumnoClienteInfo() { /* require use of factory methods */ }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> origen de los datos</param>
        /// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		private AlumnoClienteInfo(IDataReader reader, bool retrieve_childs)
		{
			Childs = retrieve_childs;
			Fetch(reader);
		}
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader"><see cref="BusinessBaseEx"/> origen</param>
        /// <param name="copy_childs">Flag para copiar los hijos</param>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		internal AlumnoClienteInfo(AlumnoCliente item, bool copy_childs)
		{
            _base.CopyValues(item);
			
			if (copy_childs)
			{
				
			}
		}
	
		/// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> a partir de un <see cref="IDataReader"/>
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> con los datos del objeto</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
        /// <remarks>
		/// NO OBTIENE los datos de los hijos. Para ello utiliza GetChild(IDataReader reader, bool retrieve_childs)
		/// La utiliza la ReadOnlyListBaseEx correspondiente para montar la lista
		/// <remarks/>
		public static AlumnoClienteInfo GetChild(IDataReader reader)
        {
			return GetChild(reader, false);
		}
		
		/// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> a partir de un <see cref="IDataReader"/>
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> con los datos del objeto</param>
		/// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
		/// <remarks>La utiliza la ReadOnlyListBaseEx correspondiente para montar la lista<remarks/>
		public static AlumnoClienteInfo GetChild(IDataReader reader, bool retrieve_childs)
        {
			return new AlumnoClienteInfo(reader, retrieve_childs);
		}
		
 		#endregion

		#region Child Data Access
		
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
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}
		
		#endregion

        #region SQL

        public static string SELECT(long oid)
        {
            string ac = nHManager.Instance.GetSQLTable(typeof(AlumnoClienteRecord));
            string a = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string c = nHManager.Instance.GetSQLTable(typeof(ClientRecord));
            string query;

            query = "SELECT AC.*," +
                    "       (A.\"NOMBRE\" || ' ' || A.\"APELLIDOS\") AS \"ALUMNO\"," +
                    "       C.\"NOMBRE\" AS \"CLIENTE\"" +
                    " FROM " + ac + " AS AC" +
                    " INNER JOIN " + a + " AS A ON AC.\"OID_ALUMNO\" = A.\"OID\"" +
                    " INNER JOIN " + c + " AS C ON AC.\"OID_CLIENTE\" = C.\"OID\"";

            if (oid > 0) query += " WHERE P.\"OID\" = " + oid.ToString();

            return query;
        }

        #endregion
	}
}

