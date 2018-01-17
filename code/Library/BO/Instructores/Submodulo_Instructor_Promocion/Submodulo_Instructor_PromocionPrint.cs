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
    public class Submodulo_Instructor_PromocionPrint : Submodulo_Instructor_PromocionInfo
    {

        #region Business Methods

        string _modulo = string.Empty;
        string _submodulo = string.Empty;
        string _promocion = string.Empty;

        public string Modulo { get { return _modulo; } }
        public string Submodulo { get { return _submodulo; } }
        public string Promocion { get { return _promocion; } }


        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(Submodulo_Instructor_PromocionInfo source)
        {
            if (source == null) return;
            
            Oid = source.Oid;
            _base.Record.OidSubmodulo = source.OidSubmodulo;
            _base.OidModulo = source.OidModulo;
            _base.Record.Prioridad = source.Prioridad;
            _base.Record.OidPromocion = source.OidPromocion;
            _base.Modulo = source.Modulo;
            _base.Submodulo = source.Submodulo;
            _base.Promocion = source.Promocion;
        }

        #endregion

        #region Factory Methods

        private Submodulo_Instructor_PromocionPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static Submodulo_Instructor_PromocionPrint New(Submodulo_Instructor_PromocionInfo source)
        {
            Submodulo_Instructor_PromocionPrint item = new Submodulo_Instructor_PromocionPrint();
            item.CopyValues(source);

            return item;
        }

        #endregion

    }
}
