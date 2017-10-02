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
    public class Respuesta_Alumno_ExamenInfo : ReadOnlyBaseEx<Respuesta_Alumno_ExamenInfo>
    {

        #region Business Methods

        protected Respuesta_Alumno_ExamenBase _base = new Respuesta_Alumno_ExamenBase();

        #endregion

        #region Properties

        public Respuesta_Alumno_ExamenBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidAlumnoExamen { get { return _base.Record.OidAlumnoExamen; } }
        public long OidPreguntaExamen { get { return _base.Record.OidPreguntaExamen; } }
        public string Opcion { get { return _base.Record.Opcion; } }
        public long Orden { get { return _base.Record.Orden; } }
        public bool Correcta { get { return _base.Record.Correcta; } }
        public Decimal Calificacion { get { return _base.Record.Calificacion; } }

        #endregion

        #region Business Methods

        public void CopyFrom(Respuesta_Alumno_Examen source) { _base.CopyValues(source); }

        #endregion	

        #region Factory Methods

        protected Respuesta_Alumno_ExamenInfo() { /* require use of factory methods */ }

        private Respuesta_Alumno_ExamenInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal Respuesta_Alumno_ExamenInfo(Respuesta_Alumno_Examen source)
        {
            _base.CopyValues(source);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Respuesta_Alumno_ExamenInfo Get(IDataReader reader, bool childs)
        {
            return new Respuesta_Alumno_ExamenInfo(reader, childs);
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

