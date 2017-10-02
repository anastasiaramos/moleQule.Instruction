using System;
using System.Collections.Generic;
using System.Data;

using moleQule.Library;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// ReadOnly Child Business Object
    /// </summary>
	[Serializable()]
	public class Alumno_ConvocatoriaInfo : ReadOnlyBaseEx<Alumno_ConvocatoriaInfo>
    {
        #region Attributes

        protected AlumnoConvocatoriaBase _base = new AlumnoConvocatoriaBase();


        #endregion

        #region Properties

        public AlumnoConvocatoriaBase Base { get { return _base; } }

        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidConvocatoria { get { return _base.Record.OidConvocatoria; } }
        public long OidAlumno { get { return _base.Record.OidAlumno; } }
        public long OidCliente { get { return _base.Record.OidCliente; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }

        //unlinked
        public string Nombre { get { return _base.Nombre; } }
        public string Cliente { get { return _base.Cliente; } }

        #endregion

        #region Business Methods

        public void CopyFrom(Alumno_Convocatoria source) { _base.CopyValues(source); }

        #endregion		

        #region Business Methods
        
        #endregion

        #region Factory Methods

        protected Alumno_ConvocatoriaInfo() { /* require use of factory methods */ }

        private Alumno_ConvocatoriaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal Alumno_ConvocatoriaInfo(Alumno_Convocatoria source)
        {
            _base.CopyValues(source);
        }

        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Alumno_ConvocatoriaInfo Get(IDataReader reader, bool childs)
        {
            return new Alumno_ConvocatoriaInfo(reader, childs);
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

