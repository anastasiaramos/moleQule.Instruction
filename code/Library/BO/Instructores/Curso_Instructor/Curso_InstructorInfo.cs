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
	public class Curso_InstructorInfo : ReadOnlyBaseEx<Curso_InstructorInfo>
    {
        #region Attributes

        protected Curso_InstructorBase _base = new Curso_InstructorBase();


        #endregion

        #region Properties

        public Curso_InstructorBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidCurso { get { return _base.Record.OidCurso; } }
        public long OidProfesor { get { return _base.Record.OidProfesor; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Curso_Instructor source) { _base.CopyValues(source); }

        #endregion		
		 
		 #region Factory Methods
		 
			protected Curso_InstructorInfo() { /* require use of factory methods */ }

			private Curso_InstructorInfo(IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(reader);
			}
			
			internal Curso_InstructorInfo(Curso_Instructor item)
			{
                _base.CopyValues(item);
			}
	

			/// <summary>
			/// Copia los datos al objeto desde un IDataReader 
			/// </summary>
			/// <param name="reader"></param>
			/// <returns></returns>
			public static Curso_InstructorInfo Get(IDataReader reader, bool childs)
			{
				return new Curso_InstructorInfo(reader, childs);
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

