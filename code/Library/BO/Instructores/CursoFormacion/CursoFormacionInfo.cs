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
	public class CursoFormacionInfo : ReadOnlyBaseEx<CursoFormacionInfo>
    {
        #region Attributes

        protected CursoFormacionBase _base = new CursoFormacionBase();


        #endregion

        #region Properties

        public CursoFormacionBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidProfesor { get { return _base.Record.OidProfesor; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public DateTime FechaRenovacion { get { return _base.Record.FechaRenovacion; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public long NHoras { get { return _base.Record.NHoras; } }



        #endregion

        #region Business Methods

        public void CopyFrom(CursoFormacion source) { _base.CopyValues(source); }

        #endregion		

		 #region Factory Methods
		 
			protected CursoFormacionInfo() { /* require use of factory methods */ }

			private CursoFormacionInfo(IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(reader);
			}
			
			internal CursoFormacionInfo(CursoFormacion item)
			{
                _base.CopyValues(item);
			}
	
			/// <summary>
			/// Copia los datos al objeto desde un IDataReader 
			/// </summary>
			/// <param name="reader"></param>
			/// <returns></returns>
			public static CursoFormacionInfo Get(IDataReader reader, bool childs)
			{
				return new CursoFormacionInfo(reader, childs);
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

