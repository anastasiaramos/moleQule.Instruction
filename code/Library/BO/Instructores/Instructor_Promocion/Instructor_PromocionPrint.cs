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
    public class Instructor_PromocionPrint : Instructor_PromocionInfo
    {

        #region Business Methods

        string _instructor = string.Empty;
        string _curso = string.Empty;

        public string Instructor { get { return _instructor; } }
        public string Curso { get  { return _curso; } }


        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(Instructor_PromocionInfo source)
        {
            if (source == null) return;
            
            Oid = source.Oid;
            _base.Record.OidInstructor = source.OidInstructor;
            _base.Record.OidPromocion = source.OidPromocion;

            InstructorInfo instructor = InstructorInfo.Get(OidInstructor,false);

            if (instructor != null && instructor.Oid > 0)
                _instructor = instructor.Nombre;

            PromocionInfo promocion = PromocionInfo.Get(OidPromocion, false);

            if (promocion != null && promocion.Oid > 0)
                _curso = promocion.Nombre;
        }

        #endregion

        #region Factory Methods

        private Instructor_PromocionPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static Instructor_PromocionPrint New(Instructor_PromocionInfo source)
        {
            Instructor_PromocionPrint item = new Instructor_PromocionPrint();
            item.CopyValues(source);

            return item;
        }

        #endregion

    }
}
