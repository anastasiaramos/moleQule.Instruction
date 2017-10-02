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
	public class Alumno_PromocionInfo : ReadOnlyBaseEx<Alumno_PromocionInfo>
    {
        #region Attributes

        protected Alumno_PromocionBase _base = new Alumno_PromocionBase();


        #endregion

        #region Properties

        public Alumno_PromocionBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPromocion { get { return _base.Record.OidPromocion; } }
        public long OidAlumno { get { return _base.Record.OidAlumno; } }

        public string Apellidos { get { return _base.Apellidos; } }
        public string Nombre { get { return _base.Nombre; } }
        public string Promocion { get { return _base.Promocion; } }
        public string Dni { get { return _base.Dni; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Alumno_Promocion source) { _base.CopyValues(source); }

        #endregion		

		 #region Factory Methods
		 
			protected Alumno_PromocionInfo() { /* require use of factory methods */ }

			private Alumno_PromocionInfo(IDataReader reader, bool childs)
			{
				Childs = childs;
				Fetch(reader);
			}
			
			internal Alumno_PromocionInfo(Alumno_Promocion item)
			{
                _base.CopyValues(item);
			}
	

			/// <summary>
			/// Copia los datos al objeto desde un IDataReader 
			/// </summary>
			/// <param name="reader"></param>
			/// <returns></returns>
			public static Alumno_PromocionInfo Get(IDataReader reader, bool childs)
			{
				return new Alumno_PromocionInfo(reader, childs);
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

