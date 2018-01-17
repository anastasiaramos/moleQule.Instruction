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
	public class Submodulo_Instructor_PromocionInfo : ReadOnlyBaseEx<Submodulo_Instructor_PromocionInfo>
	{

        #region Attributes

        protected Submodulo_Instructor_PromocionBase _base = new Submodulo_Instructor_PromocionBase();

        #endregion

        #region Properties

        public Submodulo_Instructor_PromocionBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidSubmodulo { get { return _base.Record.OidSubmodulo; } }
        public long OidInstructor { get { return _base.Record.OidInstructor; } }
        public long Prioridad { get { return _base.Record.Prioridad; } }
        public long OidPromocion { get { return _base.Record.OidPromocion; } }
        public long OidInstructorPromocion { get { return _base.Record.OidInstructorPromocion; } }

        public long OidModulo { get { return _base.OidModulo; } }
        public string Modulo { get { return _base.Modulo; } }
        public string Submodulo { get { return _base.Submodulo; } }
        public string Promocion { get { return _base.Promocion; } }
		
		
		#endregion
		
		#region Business Methods

        public void CopyFrom(Submodulo_Instructor_Promocion source) { _base.CopyValues(source); }

        public Submodulo_Instructor_PromocionPrint GetPrintObject()
        {
            return Submodulo_Instructor_PromocionPrint.New(this);
        }
			
		#endregion		
					 
		#region Factory Methods
		 
		protected Submodulo_Instructor_PromocionInfo() { /* require use of factory methods */ }

		private Submodulo_Instructor_PromocionInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
		
		internal Submodulo_Instructor_PromocionInfo(Submodulo_Instructor_Promocion item)
		{
            _base.CopyValues(item);
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static Submodulo_Instructor_PromocionInfo Get(IDataReader reader, bool childs)
		{
			return new Submodulo_Instructor_PromocionInfo(reader, childs);
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

