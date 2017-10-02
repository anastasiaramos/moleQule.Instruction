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
    public class RespuestaInfo : ReadOnlyBaseEx<RespuestaInfo>
    {
        #region Attributes

        protected RespuestaBase _base = new RespuestaBase();


        #endregion

        #region Properties

        public RespuestaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPregunta { get { return _base.Record.OidPregunta; } }
        public string Texto { get { return _base.Record.Texto; } }
        public string Opcion { get { return _base.Record.Opcion; } }
        public bool Correcta { get { return _base.Record.Correcta; } }
        public long OidOld { get { return _base.Record.OidOld; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long OidPreguntaOld { get { return _base.Record.OidPreguntaOld; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Respuesta source) { _base.CopyValues(source); }

        public void CopyFrom(RespuestaExamenInfo source)
        {
            if (source == null) return;

            Oid = source.OidRespuesta;
            _base.Record.OidPregunta = source.OidPregunta;
            _base.Record.Texto = source.Texto;
            _base.Record.Opcion = source.Opcion;
            _base.Record.Correcta = source.Correcta;
            _base.Record.OidPreguntaOld = source.OidPreguntaOld;
        }

        #endregion		

        #region Factory Methods

        protected RespuestaInfo() { /* require use of factory methods */ }

        private RespuestaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal RespuestaInfo(Respuesta item)
        {
            _base.CopyValues(item);
        }

        internal RespuestaInfo(RespuestaExamenInfo item)
        {
            CopyFrom(item);
        }

        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static RespuestaInfo Get(IDataReader reader, bool childs)
        {
            return new RespuestaInfo(reader, childs);
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

