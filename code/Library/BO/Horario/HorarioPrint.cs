using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class HorarioPrint : HorarioInfo
    {

        #region Business Methods

        private int _lunes; //dia del mes en lunes
        private int _martes;//dia del mes en martes
        private int _miercoles;//dia del mes en miercoles
        private int _jueves;//dia del mes en jueves
        private int _viernes;//dia del mes en viernes
        private int _sabado; 
        private long _n_alumnos; //numero de alumnos
        private string _fecha_titulo = string.Empty;

        //Horario primera promoción

        private string _modulo1_l1 = string.Empty;
        private string _modulo1_l2 = string.Empty;
        private string _modulo1_m1 = string.Empty;
        private string _modulo1_m2 = string.Empty;
        private string _modulo1_x1 = string.Empty;
        private string _modulo1_x2 = string.Empty;
        private string _modulo1_j1 = string.Empty;
        private string _modulo1_j2 = string.Empty;
        private string _modulo1_v1 = string.Empty;
        private string _modulo1_v2 = string.Empty;

        private string _clase1_l1 = string.Empty;
        private string _clase1_l2 = string.Empty;
        private string _clase1_m1 = string.Empty;
        private string _clase1_m2 = string.Empty;
        private string _clase1_x1 = string.Empty;
        private string _clase1_x2 = string.Empty;
        private string _clase1_j1 = string.Empty;
        private string _clase1_j2 = string.Empty;
        private string _clase1_v1 = string.Empty;
        private string _clase1_v2 = string.Empty;

        private string _instructor1_l1 = string.Empty;
        private string _instructor1_l2 = string.Empty;
        private string _instructor1_m1 = string.Empty;
        private string _instructor1_m2 = string.Empty;
        private string _instructor1_x1 = string.Empty;
        private string _instructor1_x2 = string.Empty;
        private string _instructor1_j1 = string.Empty;
        private string _instructor1_j2 = string.Empty;
        private string _instructor1_v1 = string.Empty;
        private string _instructor1_v2 = string.Empty;

        public int Lunes { get { return _lunes; } }
        public int Martes { get { return _martes; } }
        public int Miercoles { get { return _miercoles; } }
        public int Jueves { get { return _jueves; } }
        public int Viernes { get { return _viernes; } }
        public int Sabado { get { return _sabado; } }
        public long NAlumnos { get { return _n_alumnos; } }
        public string FechaTitulo { get { return _fecha_titulo; } }

        //Horario primera promocion

        public string Modulo1_L1 { get { return _modulo1_l1; } }
        public string Modulo1_L2 { get { return _modulo1_l2; } }
        public string Modulo1_M1 { get { return _modulo1_m1; } }
        public string Modulo1_M2 { get { return _modulo1_m2; } }
        public string Modulo1_X1 { get { return _modulo1_x1; } }
        public string Modulo1_X2 { get { return _modulo1_x2; } }
        public string Modulo1_J1 { get { return _modulo1_j1; } }
        public string Modulo1_J2 { get { return _modulo1_j2; } }
        public string Modulo1_V1 { get { return _modulo1_v1; } }
        public string Modulo1_V2 { get { return _modulo1_v2; } }

        public string Clase1_L1 { get { return _clase1_l1; } }
        public string Clase1_L2 { get { return _clase1_l2; } }
        public string Clase1_M1 { get { return _clase1_m1; } }
        public string Clase1_M2 { get { return _clase1_m2; } }
        public string Clase1_X1 { get { return _clase1_x1; } }
        public string Clase1_X2 { get { return _clase1_x2; } }
        public string Clase1_J1 { get { return _clase1_j1; } }
        public string Clase1_J2 { get { return _clase1_j2; } }
        public string Clase1_V1 { get { return _clase1_v1; } }
        public string Clase1_V2 { get { return _clase1_v2; } }

        public string Instructor1_L1 { get { return _instructor1_l1; } }
        public string Instructor1_L2 { get { return _instructor1_l2; } }
        public string Instructor1_M1 { get { return _instructor1_m1; } }
        public string Instructor1_M2 { get { return _instructor1_m2; } }
        public string Instructor1_X1 { get { return _instructor1_x1; } }
        public string Instructor1_X2 { get { return _instructor1_x2; } }
        public string Instructor1_J1 { get { return _instructor1_j1; } }
        public string Instructor1_J2 { get { return _instructor1_j2; } }
        public string Instructor1_V1 { get { return _instructor1_v1; } }
        public string Instructor1_V2 { get { return _instructor1_v2; } }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        protected void CopyValues(HorarioInfo source, InstructorList instructores, ModuloList modulos)
        {
            if (source == null) return;

            Oid = source.Oid;
            _base.Record.OidPlan = source.OidPlan;
            _base.Record.OidPromocion = source.OidPromocion;
            _base.Record.FechaInicial = source.FechaInicial;
            _base.Record.FechaFinal = source.FechaFinal;
            _base.Record.Observaciones = source.Observaciones;

            _lunes = _base.Record.FechaInicial.Day;
            _martes = _base.Record.FechaInicial.AddDays(1).Day;
            _miercoles = _base.Record.FechaInicial.AddDays(2).Day;
            _jueves = _base.Record.FechaInicial.AddDays(3).Day;
            _viernes = _base.Record.FechaInicial.AddDays(4).Day;
            _sabado = _base.Record.FechaFinal.Day;

            PromocionInfo promo = moleQule.Library.Instruction.PromocionInfo.Get(_base.Record.OidPromocion, true);
            _n_alumnos = promo.Alumnos.Count;
            _base.Promocion = promo.Nombre;

            CultureInfo cultura = new CultureInfo("es-ES");

            _fecha_titulo = cultura.TextInfo.ToTitleCase(cultura.DateTimeFormat.MonthNames[FechaInicial.Month - 1]) +
                            " de " + FechaInicial.Year.ToString();

        }

        #endregion

        #region Factory Methods

        private HorarioPrint() { /* require use of factory methods */ }

        // called to load data from source
        public static HorarioPrint New(HorarioInfo source, InstructorList instructores, ModuloList modulos)
        {
            HorarioPrint item = new HorarioPrint();
            item.CopyValues(source, instructores, modulos);

            return item;
        }

        #endregion

    }
}
