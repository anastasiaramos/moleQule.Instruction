using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class Alumno_ExamenPrint : Alumno_ExamenInfo
    {

        #region Business Methods

        private string _nombre = string.Empty;
        private string _dni = string.Empty;
        private string _nota_test = string.Empty;
        private string _nota_desarrollo = string.Empty;
        private string _numero = string.Empty;

        public string Nombre { get { return _nombre; } }
        public string DNI { get { return _dni; } }
        public string NotaTest { get { return _nota_test; } set { _nota_test = value; } }
        public string NotaDesarrollo { get { return _nota_desarrollo; } }
        public string Numero { get { return _numero; } }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(Alumno_ExamenInfo source, AlumnoInfo alumno, int numero, bool nota)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidAlumno = source.OidAlumno;
            _base.Record.OidExamen = source.OidExamen;
            _base.Record.Observaciones = source.Observaciones;
            _numero = numero.ToString();
            _base.Record.Calificacion = source.Calificacion;
            _base.Record.Presentado = source.Presentado;

            _base.OidPromocion = source.OidPromocion;
            if (!_base.Record.Presentado)
                _nota_test = "NP";
            else
                _nota_test = source.Calificacion.ToString() + "%";

            //AlumnoInfo alumno = AlumnoInfo.Get(_oid_alumno, true);
            if (alumno != null)
            {
                _nombre = alumno.Apellidos + ", " + alumno.Nombre;
                _dni = alumno.Id;

                if (nota)
                {
                    //ExamenList examenes = ExamenList.GetList(false);
                    //ExamenInfo examen = examenes.GetItem(_oid_examen);
                    //if (examen.Desarrollo)
                    //{
                    //    _nota_desarrollo = _calificacion.ToString();
                    //    foreach (ExamenInfo info in examenes)
                    //    {
                    //        if (!info.Desarrollo
                    //            && info.OidModulo == examen.OidModulo
                    //            && info.FechaExamen.ToShortDateString().Equals(examen.FechaExamen.ToShortDateString())
                    //            && info.OidPromocion == examen.OidPromocion)
                    //        {
                    //            Alumno_ExamenList notas = alumno.AlumnoExamens;

                    //            foreach (Alumno_ExamenInfo exam in notas)
                    //            {
                    //                if (exam.OidExamen == info.Oid)
                    //                    _nota_test = exam.Calificacion.ToString();
                    //            }
                    //            break;
                    //        }
                    //    }
                    //}
                    //else
                    //{
                    //    _nota_test = _calificacion.ToString();
                    //    foreach (ExamenInfo info in examenes)
                    //    {
                    //        if (info.Desarrollo
                    //            && info.OidModulo == examen.OidModulo
                    //            && info.FechaExamen.ToShortDateString().Equals(examen.FechaExamen.ToShortDateString())
                    //            && info.OidPromocion == examen.OidPromocion)
                    //        {
                    //            Alumno_ExamenList notas = alumno.AlumnoExamens;

                    //            foreach (Alumno_ExamenInfo exam in notas)
                    //            {
                    //                if (exam.OidExamen == info.Oid)
                    //                    _nota_desarrollo = exam.Calificacion.ToString();
                    //            }

                    //            break;
                    //        }
                    //    }
                    //}
                }
            }

        }

        #endregion

        #region Factory Methods

        private Alumno_ExamenPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static Alumno_ExamenPrint New(Alumno_ExamenInfo source, AlumnoInfo alumno, int numero, bool notas)
        {
            Alumno_ExamenPrint item = new Alumno_ExamenPrint();
            item.CopyValues(source, alumno, numero, notas);

            return item;
        }

        #endregion

    }
}
