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
    public class HistoriaInfo : ReadOnlyBaseEx<HistoriaInfo>
    {
        #region Attributes

        protected HistoriaBase _base = new HistoriaBase();


        #endregion

        #region Properties

        public HistoriaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPregunta { get { return _base.Record.OidPregunta; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public string Texto { get { return _base.Record.Texto; } }
        public DateTime Hora { get { return _base.Record.Hora; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Historia source) { _base.CopyValues(source); }

        #endregion		

        #region Common Factory Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
        protected HistoriaInfo() { /* require use of factory methods */ }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> origen de los datos</param>
        /// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
        private HistoriaInfo(IDataReader reader, bool retrieve_childs)
        {
            Childs = retrieve_childs;
            Fetch(reader);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader"><see cref="BusinessBaseEx"/> origen</param>
        /// <param name="copy_childs">Flag para copiar los hijos</param>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
        internal HistoriaInfo(Historia item, bool copy_childs)
        {
            _base.CopyValues(item);

            if (copy_childs) {}
        }

        /// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> a partir de un <see cref="IDataReader"/>
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> con los datos del objeto</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
        /// <remarks>
        /// NO OBTIENE los datos de los hijos. Para ello utiliza GetChild(IDataReader reader, bool retrieve_childs)
        /// La utiliza la ReadOnlyListBaseEx correspondiente para montar la lista
        /// <remarks/>
        public static HistoriaInfo GetChild(IDataReader reader)
        {
            return GetChild(reader, false);
        }

        /// <summary>
        /// Obtiene un <see cref="ReadOnlyBaseEx"/> a partir de un <see cref="IDataReader"/>
        /// </summary>
        /// <param name="reader"><see cref="IDataReader"/> con los datos del objeto</param>
        /// <param name="get_childs">Flag para obtener los hijos de la bd</param>
        /// <returns>Objeto <see cref="ReadOnlyBaseEx"/> construido a partir del registro</returns>
        /// <remarks>La utiliza la ReadOnlyListBaseEx correspondiente para montar la lista<remarks/>
        public static HistoriaInfo GetChild(IDataReader reader, bool retrieve_childs)
        {
            return new HistoriaInfo(reader, retrieve_childs);
        }

        #endregion

        #region Child Data Access

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

