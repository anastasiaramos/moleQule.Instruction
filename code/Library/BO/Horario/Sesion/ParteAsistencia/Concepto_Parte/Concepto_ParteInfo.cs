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
	public class Concepto_ParteInfo : ReadOnlyBaseEx<Concepto_ParteInfo>
    {
        #region Attributes

        protected Concepto_ParteBase _base = new Concepto_ParteBase();


        #endregion

        #region Properties

        public Concepto_ParteBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidConcepto { get { return _base.Record.OidConcepto; } }
        public long OidParte { get { return _base.Record.OidParte; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Concepto_Parte source) { _base.CopyValues(source); }

        #endregion		

		 #region Factory Methods
		 
			protected Concepto_ParteInfo() { /* require use of factory methods */ }

			private Concepto_ParteInfo(IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(reader);
			}

            internal Concepto_ParteInfo(Concepto_Parte item)
            {
                _base.CopyValues(item);
            }
	

			/// <summary>
			/// Copia los datos al objeto desde un IDataReader 
			/// </summary>
			/// <param name="reader"></param>
			/// <returns></returns>
			public static Concepto_ParteInfo Get(IDataReader reader, bool childs)
			{
				return new Concepto_ParteInfo(reader, childs);
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

