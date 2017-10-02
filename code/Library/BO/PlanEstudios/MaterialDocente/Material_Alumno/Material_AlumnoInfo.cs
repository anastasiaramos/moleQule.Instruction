using System;
using System.Collections.Generic;
using System.Data;

using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// ReadOnly Child Business Object
    /// </summary>
	[Serializable()]
	public class Material_AlumnoInfo : ReadOnlyBaseEx<Material_AlumnoInfo>
    {
        #region Attributes

        protected Material_AlumnoBase _base = new Material_AlumnoBase();


        #endregion

        #region Properties

        public Material_AlumnoBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidMaterial { get { return _base.Record.OidMaterial; } }
        public long OidAlumno { get { return _base.Record.OidAlumno; } }
        public bool Entregado { get { return _base.Record.Entregado; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Material_Alumno source) { _base.CopyValues(source); }

        #endregion		
		 
		 #region Factory Methods
		 
			protected Material_AlumnoInfo() { /* require use of factory methods */ }

			private Material_AlumnoInfo(IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(reader);
			}
			
			internal Material_AlumnoInfo(Material_Alumno item)
			{
                _base.CopyValues(item);

			}
	

			/// <summary>
			/// Copia los datos al objeto desde un IDataReader 
			/// </summary>
			/// <param name="reader"></param>
			/// <returns></returns>
			public static Material_AlumnoInfo Get(IDataReader reader, bool childs)
			{
				return new Material_AlumnoInfo(reader, childs);
			}
		
		 #endregion
		 		 
		 #region Data Access
		 
		 	//called to copy data from IDataReader
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

