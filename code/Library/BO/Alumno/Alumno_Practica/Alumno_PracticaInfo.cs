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
    public class Alumno_PracticaInfo : ReadOnlyBaseEx<Alumno_PracticaInfo>
    {
		#region Attributes

		protected Alumno_PracticaBase _base = new Alumno_PracticaBase();

		
		#endregion
		
		#region Properties
		
		public  Alumno_PracticaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
		public long OidAlumno { get { return _base.Record.OidAlumno; } }
		public long OidClasePractica { get { return _base.Record.OidClasePractica; } }
		public string Calificacion { get { return _base.Record.Calificacion; } }
		public string Observaciones { get { return _base.Record.Observaciones; } }
		public long OidParte { get { return _base.Record.OidParte; } }
		public bool Recuperada { get { return _base.Record.Recuperada; } }
		public DateTime FechaRecuperacion { get { return _base.Record.FechaRecuperacion; } }
                
        public virtual bool Falta { get { return _base.Falta; } }
        public virtual string Alias { get { return _base.Alias; } }
		
		#endregion
		
		#region Business Methods
						
		public void CopyFrom(Alumno_Practica source) { _base.CopyValues(source); }
			
		#endregion		

        #region Factory Methods

        protected Alumno_PracticaInfo() { /* require use of factory methods */ }

        private Alumno_PracticaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal Alumno_PracticaInfo(Alumno_Practica item)
        {
            _base.CopyValues(item);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Alumno_PracticaInfo Get(IDataReader reader, bool childs)
        {
            return new Alumno_PracticaInfo(reader, childs);
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

