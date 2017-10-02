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
	public class Pregunta_ExamenInfo : ReadOnlyBaseEx<Pregunta_ExamenInfo>
    {
        #region Attributes

        protected Pregunta_ExamenBase _base = new Pregunta_ExamenBase();


        #endregion

        #region Properties

        public Pregunta_ExamenBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPregunta { get { return _base.Record.OidPregunta; } }
        public long OidExamen { get { return _base.Record.OidExamen; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Pregunta_Examen source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected Pregunta_ExamenInfo() { /* require use of factory methods */ }

        private Pregunta_ExamenInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal Pregunta_ExamenInfo(Pregunta_Examen item)
        {
            _base.CopyValues(item);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Pregunta_ExamenInfo Get(IDataReader reader, bool childs)
        {
            return new Pregunta_ExamenInfo(reader, childs);
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

