using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;

using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class CronogramaPrint : CronogramaInfo
    {

        #region Business Methods

        private string _plan = string.Empty;
        private new string _promocion = string.Empty;
        private System.Byte[] _logo_emp;

        public string Plan { get { return _plan; } }
        public new string Promocion { get { return _promocion; } }
        public System.Byte[] LogoEmp { get { return _logo_emp; } }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(CronogramaInfo source, CompanyInfo empresa, PlanEstudiosInfo plan, PromocionInfo promocion)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidPlan = source.OidPlan;
            _base.Record.OidPromocion = source.OidPromocion;
            _base.Record.FechaCreacion = source.FechaCreacion;
            _base.Record.Observaciones = source.Observaciones;

            if (plan != null)
                _plan = plan.Nombre;
            if (promocion != null)
                _promocion = promocion.Nombre;

            if (empresa == null) return;

            string path = CompanyInfo.GetLogoPath(AppContext.ActiveSchema.Oid);

            // Cargamos la imagen en el buffer
            if (File.Exists(path))
            {
                //Declaramos fs para poder abrir la imagen.
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                // Declaramos un lector binario para pasar la imagen a bytes
                BinaryReader br = new BinaryReader(fs);
                _logo_emp = new byte[(int)fs.Length];
                br.Read(LogoEmp, 0, (int)fs.Length);
                br.Close();
                fs.Close();
            }
        }

        #endregion

        #region Factory Methods

        private CronogramaPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static CronogramaPrint New(CronogramaInfo source, CompanyInfo empresa, PlanEstudiosInfo plan, PromocionInfo promocion)
        {
            CronogramaPrint item = new CronogramaPrint();
            item.CopyValues(source, empresa, plan, promocion);

            return item;
        }

        #endregion

    }
}
