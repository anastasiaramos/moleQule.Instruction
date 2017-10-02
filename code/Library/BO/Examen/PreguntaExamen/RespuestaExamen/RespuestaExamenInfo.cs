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
    public class RespuestaExamenInfo : ReadOnlyBaseEx<RespuestaExamenInfo>
    {
        #region Attributes

        protected RespuestaExamenBase _base = new RespuestaExamenBase();


        #endregion

        #region Properties

        public RespuestaExamenBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPregunta { get { return _base.Record.OidPregunta; } }
        public string Texto { get { return _base.Record.Texto; } }
        public string Opcion { get { return _base.Record.Opcion; } }
        public bool Correcta { get { return _base.Record.Correcta; } }
        public long OidPreguntaOld { get { return _base.Record.OidPreguntaOld; } }
        public long OidRespuestaOld { get { return _base.Record.OidRespuestaOld; } }
        public long OidExamen { get { return _base.Record.OidExamen; } }
        public long OidRespuesta { get { return _base.Record.OidRespuesta; } }



        #endregion

        #region Business Methods

        public void CopyFrom(RespuestaExamen source) { _base.CopyValues(source); }
        
        public RespuestaExamenPrint GetPrintObject(PreguntaExamenInfo pregunta, Preguntas preguntas, ExamenInfo examen, bool imagen)
        {
            return RespuestaExamenPrint.New(this, pregunta, preguntas, examen, imagen);
        }


        #endregion

        #region Factory Methods

        protected RespuestaExamenInfo() { /* require use of factory methods */ }

        private RespuestaExamenInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }
        internal RespuestaExamenInfo(RespuestaExamen source)
        {
            _base.CopyValues(source);
        }
        

        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static RespuestaExamenInfo Get(IDataReader reader, bool childs)
        {
            return new RespuestaExamenInfo(reader, childs);
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

