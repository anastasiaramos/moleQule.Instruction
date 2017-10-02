using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using moleQule.Library;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class HistoriaPrint : HistoriaInfo
    {

        #region Attributes & Properties
		
		protected string _pregunta = string.Empty;
			
		#endregion
		
		#region Business Methods

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(HistoriaInfo source)
        {
            if (source == null) return;
			
			PreguntaInfo pregunta = PreguntaInfo.Get(OidPregunta, false);
            if (pregunta != null)
                _pregunta = pregunta.Texto;			
			
        }

        #endregion

        #region Factory Methods

        private HistoriaPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static HistoriaPrint New(HistoriaInfo source)
        {
            HistoriaPrint item = new HistoriaPrint();
            item.CopyValues(source);

            return item;
        }

        #endregion

    }
}
