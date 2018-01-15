using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class PreguntaPrint : PreguntaInfo
    {
        #region Properties

        private int _orden;
        
        public int Orden {get{return _orden;} }
        public string Tema { get { return _tema; } }
        public string Submodulo { get { return _submodulo; } }
        public string Modulo { get { return _modulo; } }

        #endregion

        #region Business Methods

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(PreguntaInfo source, int orden)
        {
            Oid = source.Oid;
			_base.Record.OidModulo = source.OidModulo;
            _base.Record.OidSubmodulo = source.OidSubmodulo;
			_base.Record.OidTema = source.OidTema;
			_base.Record.Nivel = source.Nivel;
			_base.Record.FechaAlta = source.FechaAlta;
			_base.Record.FechaPublicacion = source.FechaPublicacion;
			_base.Record.Texto = source.Texto;
			_base.Record.Tipo = source.Tipo;
            _base.Record.Imagen = source.Imagen;
            _base.Record.ModeloRespuesta = source.ModeloRespuesta;
			_base.Record.Observaciones = source.Observaciones;
			_base.Record.FechaDisponibilidad = source.FechaDisponibilidad;
			_base.Record.Idioma = source.Idioma;
			_base.Record.Activa = source.Activa;
			_base.Record.Revisada = source.Revisada;
			_base.Record.Bloqueada = source.Bloqueada;
            _base.Record.OidOld = source.OidOld;
            _base.Record.Reservada = source.Reservada;
            _base.Record.Codigo = source.Codigo;
            _base.Record.Serial = source.Serial;

            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _tema = source.Tema;

            _orden = orden;
        }

        #endregion

        #region Factory Methods

        private PreguntaPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static PreguntaPrint New(PreguntaInfo source, int orden)
        {
            PreguntaPrint item = new PreguntaPrint();
            item.CopyValues(source, orden);

            return item;
        }

        #endregion
    }
}
