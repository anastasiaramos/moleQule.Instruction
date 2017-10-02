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
	public class Alumno_ParteInfo : ReadOnlyBaseEx<Alumno_ParteInfo>
    {
        #region Attributes

        protected AlumnoParteBase _base = new AlumnoParteBase();


        #endregion

        #region Properties

        public AlumnoParteBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidAlumno { get { return _base.Record.OidAlumno; } }
        public long OidParte { get { return _base.Record.OidParte; } }
        public bool Falta { get { return _base.Record.Falta; } }
        public bool Retraso { get { return _base.Record.Retraso; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public bool Recuperada { get { return _base.Record.Recuperada; } }
        public DateTime FechaRecuperacion { get { return _base.Record.FechaRecuperacion; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Alumno_Parte source) { _base.CopyValues(source); }

        #endregion		

		 #region Factory Methods
		 
			protected Alumno_ParteInfo() { /* require use of factory methods */ }

			private Alumno_ParteInfo(IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(reader);
			}
			
			internal Alumno_ParteInfo( Alumno_Parte item)
			{
                _base.CopyValues(item);
			}
	

			/// <summary>
			/// Copia los datos al objeto desde un IDataReader 
			/// </summary>
			/// <param name="reader"></param>
			/// <returns></returns>
			public static Alumno_ParteInfo Get(IDataReader reader, bool childs)
			{
				return new Alumno_ParteInfo(reader, childs);
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

