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
	/// ReadOnly Child Object
	/// </summary>
	[Serializable()]
	public class CursoClienteInfo : ReadOnlyBaseEx<CursoClienteInfo>
	{
	
		#region Attributes & Properties 
		
		protected long _oid_curso;
		protected long _oid_cliente;
        protected long _oid_convocatoria;
        
        
        //Unlinked Properties    
        private string _curso;
        private string _cliente;
        private string _convocatoria;
        private int _n_alumnos;
	
		public long OidCurso { get { return _oid_curso; } /*set { _oid_curso = value; }*/ }
		public long OidCliente { get { return _oid_cliente; } /*set { _oid_cliente = value; }*/ }

        public string Curso { get { return _curso; } /*set { _oid_curso = value; }*/ }
        public string Cliente { get { return _cliente; } /*set { _oid_cliente = value; }*/ }        
        public string Convocatoria { get { return _convocatoria; } /*set { _oid_cliente = value; }*/ }    
        public int NAlumnos { get { return _n_alumnos; } /*set { _oid_cliente = value; }*/ }

		#endregion
		
		#region Business Methods
				
		/// <summary>
		/// Copia los atributos del objeto
		/// </summary>
		/// <param name="source">Objeto origen</param>
		protected override void CopyValues(IDataReader source)
		{
			if (source == null) return;
            _oid_cliente = Format.DataReader.GetInt64(source, "OID_CLIENTE");
            _oid_curso = Format.DataReader.GetInt64(source, "OID_CURSO");
            _oid_convocatoria = Format.DataReader.GetInt64(source, "OID_CONVOCATORIA");

            string oid = _oid_cliente.ToString(Resources.Defaults.DEFAULT_CODE_FORMAT)  + 
                         _oid_convocatoria.ToString();
            _oid = Convert.ToInt64(oid);

            _curso = Format.DataReader.GetString(source, "CURSO");
            _cliente = Format.DataReader.GetString(source, "CLIENTE");
            _convocatoria = Format.DataReader.GetString(source, "CONVOCATORIA");           
            _n_alumnos = Format.DataReader.GetInt32(source, "NALUMNOS");                         
		}
			
		#endregion		
		
		#region Common Factory Methods
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		protected CursoClienteInfo() { /* require use of factory methods */ }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> origen de los datos</param>
        /// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		private CursoClienteInfo(IDataReader reader, bool retrieve_childs)
		{
			Childs = retrieve_childs;
			Fetch(reader);
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
		public static CursoClienteInfo GetChild(IDataReader reader)
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
		public static CursoClienteInfo GetChild(IDataReader reader, bool retrieve_childs)
        {
			return new CursoClienteInfo(reader, retrieve_childs);
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

