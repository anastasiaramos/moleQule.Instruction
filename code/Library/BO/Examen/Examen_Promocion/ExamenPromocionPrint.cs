using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class ExamenPromocionPrint : ExamenPromocionInfo
    {

        #region Attributes & Properties
			
		#endregion
		
		#region Business Methods

        protected void CopyValues(ExamenPromocionInfo source)
        {
            if (source == null) return;

			Oid = source.Oid;
			_base.CopyValues(source);
			
			
        }

        #endregion

        #region Factory Methods

        private ExamenPromocionPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static ExamenPromocionPrint New(ExamenPromocionInfo source)
        {
            ExamenPromocionPrint item = new ExamenPromocionPrint();
            item.CopyValues(source);

            return item;
        }

        #endregion

    }
}
