using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using moleQule.Library;
using moleQule.Library.Common;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class ExamenPrint : ExamenInfo
    {

        #region Business Methods

        private long _n_preguntas;
        private System.Byte[] _logo_emp;
        private string _tiempo = string.Empty;
        private string _dia = string.Empty;
        private string _mes = string.Empty;
        private string _año = string.Empty;
        private string _observaciones = string.Empty;
        private long _oid_promocion_alumno;
        private string _n_modulo = string.Empty;
        
        public string Profesor { get { return _base.Instructor; } }
        public long NPreguntas { get { return _n_preguntas; } }
        public System.Byte[] LogoEmp { get { return _logo_emp; } }
        public string Tiempo { get { return _tiempo; } }
        public string Dia { get { return _dia; } }
        public string Mes { get { return _mes; } }
        public string Año { get { return _año; } }
        public string Observaciones{get{return _observaciones;}}
        public long OidPromocionAlumno { get { return _oid_promocion_alumno; } }
        public string NModulo { get { return _n_modulo; } }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(ExamenInfo source, CompanyInfo empresa, string promocion, string observaciones)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidPromocion = source.OidPromocion;
            _base.Record.OidProfesor = source.OidProfesor;
            _base.Record.OidModulo = source.OidModulo;
            _base.Record.FechaExamen = source.FechaExamen;
            _base.Record.FechaCreacion = source.FechaCreacion;
            _base.Record.FechaEmision = source.FechaEmision;
            _base.Record.Tipo = source.Tipo;
            _base.Record.Desarrollo = source.Desarrollo;
            _base.Record.Titulo = source.Titulo;
            _base.Record.Duracion = source.Duracion;
            _tiempo = Duracion.ToShortTimeString();
            _base.Record.MemoPreguntas = source.MemoPreguntas;
            _base.Record.Numero = source.Numero;
            _dia = _base.Record.FechaExamen.Day.ToString("00");
            _mes = _base.Record.FechaExamen.Month.ToString("00");
            _año = _base.Record.FechaExamen.Year.ToString();
            _observaciones = observaciones;
            
            _base.Promocion = source.Promocion;
            _base.Modulo = source.Modulo;
            _n_modulo = ModuloInfo.Get(source.OidModulo, false).NumeroModulo;
            _base.Instructor = source.Instructor;

            _n_preguntas = source.PreguntaExamenes != null ? source.PreguntaExamenes.Count : 0;

            if (promocion != null)
            {
                //_oid_promocion_alumno = promocion.Oid;
                _base.Promocion = promocion;
            }
            else
            {
                if (source.Promociones != null && source.Promociones.Count > 0)
                {
                    _base.Promocion = string.Empty;

                    foreach (ExamenPromocionInfo ep in source.Promociones)
                    {
                        PromocionInfo pinfo = PromocionInfo.Get(ep.OidPromocion, false);
                        _base.Promocion += pinfo.Nombre + " ";
                    }
                }
            }
            
            if (empresa == null) return;

            string path = CompanyInfo.GetLogoPath(empresa.Oid);
            //Z:\.\Recursos\Logos\Empresas\0002.jpg

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

        private ExamenPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static ExamenPrint New(ExamenInfo source, CompanyInfo empresa, string promocion, string observaciones)
        {
            ExamenPrint item = new ExamenPrint();
            item.CopyValues(source, empresa, promocion, observaciones);

            return item;
        }

        #endregion

    }
}
