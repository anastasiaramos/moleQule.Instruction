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
    public class FestivoPrint : FestivoInfo
    {

        #region Attributes & Properties
			
		#endregion
		
		#region Business Methods

        protected void CopyValues(FestivoInfo source)
        {
            if (source == null) return;

            Oid = source.Oid;
			_base.CopyValues(source);
			
			
        }

        #endregion

        #region Factory Methods

        private FestivoPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static FestivoPrint New(FestivoInfo source)
        {
            FestivoPrint item = new FestivoPrint();
            item.CopyValues(source);

            return item;
        }

        #endregion

    }
}
