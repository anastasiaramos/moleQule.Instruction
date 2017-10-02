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
	public class AlumnoCursoInfo : ReadOnlyBaseEx<AlumnoCursoInfo>
    {
        #region Attributes

        protected AlumnoCursoBase _base = new AlumnoCursoBase();


        #endregion

        #region Properties

        public AlumnoCursoBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string Empresa { get { return _base.Record.Empresa; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public long OidConvocatoria { get { return _base.Record.OidConvocatoria; } }
        public string Apellidos { get { return _base.Record.Apellidos; } }
        public string Ident { get { return _base.Record.Ident; } }



        #endregion

        #region Business Methods

        public void CopyFrom(AlumnoCurso source) { _base.CopyValues(source); }

        #endregion		
		 
		 #region Factory Methods
		 
			protected AlumnoCursoInfo() { /* require use of factory methods */ }

			private AlumnoCursoInfo(IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(reader);
			}
            internal AlumnoCursoInfo(AlumnoCurso item)
            {
                _base.CopyValues(item);
            }
	

			/// <summary>
			/// Copia los datos al objeto desde un IDataReader 
			/// </summary>
			/// <param name="reader"></param>
			/// <returns></returns>
			public static AlumnoCursoInfo Get(IDataReader reader, bool childs)
			{
				return new AlumnoCursoInfo(reader, childs);
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

