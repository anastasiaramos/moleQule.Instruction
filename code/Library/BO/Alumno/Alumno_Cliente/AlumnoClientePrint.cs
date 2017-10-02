using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Csla;

using moleQule.Library;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class AlumnoClientePrint : AlumnoClienteInfo
    {

        #region Attributes & Properties
			
		#endregion
		
		#region Business Methods

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(AlumnoClienteInfo source)
        {
            if (source == null) return;
        }

        #endregion

        #region Factory Methods

        private AlumnoClientePrint() { /* require use of factory methods */ }

        // called to load data from source
        public static AlumnoClientePrint New(AlumnoClienteInfo source)
        {
            AlumnoClientePrint item = new AlumnoClientePrint();
            item.CopyValues(source);

            return item;
        }

        #endregion

    }
}
