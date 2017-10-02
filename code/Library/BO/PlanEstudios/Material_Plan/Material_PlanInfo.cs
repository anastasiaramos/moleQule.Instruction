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
	public class Material_PlanInfo : ReadOnlyBaseEx<Material_PlanInfo>
	{
        #region Attributes

        protected Material_PlanBase _base = new Material_PlanBase();

		#endregion

        #region Properties

        public Material_PlanBase Base { get { return _base; } }

        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
		public long OidModulo { get { return _base.Record.OidModulo; } /*set { _oid_plan = value; }*/ }
		public long OidMaterial { get { return _base.Record.OidMaterial; } /*set { _oid_material = value; }*/ }
		public long OidRevision { get { return _base.Record.OidRevision; } /*set { _oid_revision = value; }*/ }

        //NO ENLAZADAS
        public string Modulo { get { return _base.Modulo; } /*set { _oid_plan = value; }*/ }
        public string Material { get { return _base.Material; } /*set { _oid_material = value; }*/ }
        public string Revision { get { return _base.Revision; } /*set { _oid_revision = value; }*/ }

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
		protected Material_PlanInfo() { /* require use of factory methods */ }
		
		/// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> origen de los datos</param>
        /// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		private Material_PlanInfo(IDataReader reader, bool retrieve_childs)
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
		internal Material_PlanInfo(Material_Plan item, bool copy_childs)
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
		public static Material_PlanInfo GetChild(IDataReader reader)
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
		public static Material_PlanInfo GetChild(IDataReader reader, bool retrieve_childs)
        {
			return new Material_PlanInfo(reader, retrieve_childs);
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

    }
}
