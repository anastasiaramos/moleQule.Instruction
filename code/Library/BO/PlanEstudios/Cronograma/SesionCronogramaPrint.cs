using System;
using System.Collections;
using System.Collections.Generic;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class SesionCronogramaPrint : SesionCronogramaInfo
    {
        #region Properties

        public virtual string FechaLabel { get { return _base.Record.Fecha.ToString("dd/MM/yyyy"); } }
        public virtual string HoraLabel { get { return _base.Record.Hora.ToString("HH:mm"); } }

        #endregion

        #region Business Methods

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(SesionCronogramaInfo source, ModuloList modulos, ClaseTeoricaList teoricas, ClasePracticaList practicas)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidCronograma = source.OidCronograma;
            _base.Record.OidClaseTeorica = source.OidClaseTeorica;
            _base.Record.OidClasePractica = source.OidClasePractica;
            _base.Record.Semana = source.Semana;
            _base.Record.Dia = source.Dia;
            _base.Record.Turno = source.Turno;
            _base.Record.Numero = source.Numero;
            _base.Record.Texto = source.Texto;
            _base.Clase = source.Clase;
            _base.Modulo = source.Modulo;
            _base.Record.Fecha = source.Fecha;
            _base.Record.Hora = source.Hora;
            _base.Duracion = source.Duracion;

            long oid_modulo = 0;
            if (source.OidClaseTeorica > 0)
            {
                ClaseTeoricaInfo teorica = teoricas.GetItem(source.OidClaseTeorica);
                if (teorica != null)
                    oid_modulo = teorica.OidModulo;
            }

            if (source.OidClasePractica > 0)
            {
                ClasePracticaInfo practica = practicas.GetItem(source.OidClasePractica);
                if (practica != null)
                    oid_modulo = practica.OidModulo;
            }

            if (oid_modulo > 0)
            {
                ModuloInfo modulo = modulos.GetItem(oid_modulo);
                if (modulo != null)
                    _base.Modulo = modulo.NumeroModulo + " " + modulo.Texto;
            }

            //if (_base.Record.OidClaseTeorica != 0)
            //    _base.Duracion = "1";
            //else
            //    _base.Duracion = "5";

        }


        #endregion

        #region Factory Methods

        private SesionCronogramaPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static SesionCronogramaPrint New(SesionCronogramaInfo source, 
            ModuloList modulos, ClaseTeoricaList teoricas, ClasePracticaList practicas)
        {
            SesionCronogramaPrint item = new SesionCronogramaPrint();
            item.CopyValues(source, modulos, teoricas, practicas);

            return item;
        }

        #endregion

    }
}
