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
    public class Material_PlanPrint : Material_PlanInfo
    {

        #region Attributes & Properties		
		
		#endregion
		
		#region Business Methods

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(Material_PlanInfo source)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidModulo = source.OidModulo;
            _base.Record.OidMaterial = source.OidMaterial;
            _base.Record.OidRevision = source.OidRevision;

            _base.Modulo = source.Modulo;
            _base.Material = source.Material;
            _base.Revision = source.Revision;
        }

        #endregion

        #region Factory Methods

        private Material_PlanPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static Material_PlanPrint New(Material_PlanInfo source)
        {
            Material_PlanPrint item = new Material_PlanPrint();
            item.CopyValues(source);

            return item;
        }

        #endregion

    }
}
