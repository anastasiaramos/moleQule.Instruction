using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;

using Csla;
using Csla.Validation;  
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class DisponibilidadRecord : RecordBase
	{
		#region Attributes

		private long _oid_instructor;
		private DateTime _fecha_inicio;
		private DateTime _fecha_fin;
		private bool _l1 = false;
		private bool _l2 = false;
		private bool _m1 = false;
		private bool _m2 = false;
		private bool _x1 = false;
		private bool _x2 = false;
		private bool _j1 = false;
		private bool _j2 = false;
		private bool _v1 = false;
		private bool _v2 = false;
		private string _observaciones = string.Empty;
		private long _clases_semanales;
		private bool _l3 = false;
		private bool _l4 = false;
		private bool _l5 = false;
		private bool _l6 = false;
		private bool _l7 = false;
		private bool _l8 = false;
		private bool _l9 = false;
		private bool _l10 = false;
		private bool _m3 = false;
		private bool _m4 = false;
		private bool _m5 = false;
		private bool _m6 = false;
		private bool _m7 = false;
		private bool _m8 = false;
		private bool _m9 = false;
		private bool _m10 = false;
		private bool _x3 = false;
		private bool _x4 = false;
		private bool _x5 = false;
		private bool _x6 = false;
		private bool _x7 = false;
		private bool _x8 = false;
		private bool _x9 = false;
		private bool _x10 = false;
		private bool _j3 = false;
		private bool _j4 = false;
		private bool _j5 = false;
		private bool _j6 = false;
		private bool _j7 = false;
		private bool _j8 = false;
		private bool _j9 = false;
		private bool _j10 = false;
		private bool _v3 = false;
		private bool _v4 = false;
		private bool _v5 = false;
		private bool _v6 = false;
		private bool _v7 = false;
		private bool _v8 = false;
		private bool _v9 = false;
		private bool _v10 = false;
		private bool _s1 = false;
		private bool _s2 = false;
		private bool _s3 = false;
		private bool _s4 = false;
		private bool _l0 = false;
		private bool _m0 = false;
		private bool _x0 = false;
		private bool _j0 = false;
		private bool _v0 = false;
		private bool _s0 = false;
		private bool _l11 = false;
		private bool _l12 = false;
		private bool _m11 = false;
		private bool _m12 = false;
		private bool _x11 = false;
		private bool _x12 = false;
		private bool _j11 = false;
		private bool _j12 = false;
		private bool _v11 = false;
		private bool _v12 = false;
		private bool _nd_l = false;
		private bool _nd_m = false;
		private bool _nd_x = false;
		private bool _nd_j = false;
		private bool _nd_v = false;
		private bool _nd_s = false;
        private bool _l8am = false;
        private bool _m8am = false;
        private bool _x8am = false;
        private bool _j8am = false;
        private bool _v8am = false;
        private bool _predeterminado = false;
  
		#endregion
		
		#region Properties
		
				public virtual long OidInstructor { get { return _oid_instructor; } set { _oid_instructor = value; } }
		public virtual DateTime FechaInicio { get { return _fecha_inicio; } set { _fecha_inicio = value; } }
		public virtual DateTime FechaFin { get { return _fecha_fin; } set { _fecha_fin = value; } }
		public virtual bool L1 { get { return _nd_l ? false : _l1; } set { _l1 = value; } }
        public virtual bool L2 { get { return _nd_l ? false : _l2; } set { _l2 = value; } }
        public virtual bool M1 { get { return _nd_m ? false : _m1; } set { _m1 = value; } }
        public virtual bool M2 { get { return _nd_m ? false : _m2; } set { _m2 = value; } }
        public virtual bool X1 { get { return _nd_x ? false : _x1; } set { _x1 = value; } }
        public virtual bool X2 { get { return _nd_x ? false : _x2; } set { _x2 = value; } }
        public virtual bool J1 { get { return _nd_j ? false : _j1; } set { _j1 = value; } }
        public virtual bool J2 { get { return _nd_j ? false : _j2; } set { _j2 = value; } }
        public virtual bool V1 { get { return _nd_v ? false : _v1; } set { _v1 = value; } }
        public virtual bool V2 { get { return _nd_v ? false : _v2; } set { _v2 = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual long ClasesSemanales { get { return _clases_semanales; } set { _clases_semanales = value; } }
        public virtual bool L3 { get { return _nd_l ? false : _l3; } set { _l3 = value; } }
        public virtual bool L4 { get { return _nd_l ? false : _l4; } set { _l4 = value; } }
        public virtual bool L5 { get { return _nd_l ? false : _l5; } set { _l5 = value; } }
        public virtual bool L6 { get { return _nd_l ? false : _l6; } set { _l6 = value; } }
        public virtual bool L7 { get { return _nd_l ? false : _l7; } set { _l7 = value; } }
        public virtual bool L8 { get { return _nd_l ? false : _l8; } set { _l8 = value; } }
        public virtual bool L9 { get { return _nd_l ? false : _l9; } set { _l9 = value; } }
        public virtual bool L10 { get { return _nd_l ? false : _l10; } set { _l10 = value; } }
        public virtual bool M3 { get { return _nd_m ? false : _m3; } set { _m3 = value; } }
        public virtual bool M4 { get { return _nd_m ? false : _m4; } set { _m4 = value; } }
        public virtual bool M5 { get { return _nd_m ? false : _m5; } set { _m5 = value; } }
        public virtual bool M6 { get { return _nd_m ? false : _m6; } set { _m6 = value; } }
        public virtual bool M7 { get { return _nd_m ? false : _m7; } set { _m7 = value; } }
        public virtual bool M8 { get { return _nd_m ? false : _m8; } set { _m8 = value; } }
        public virtual bool M9 { get { return _nd_m ? false : _m9; } set { _m9 = value; } }
        public virtual bool M10 { get { return _nd_m ? false : _m10; } set { _m10 = value; } }
        public virtual bool X3 { get { return _nd_x ? false : _x3; } set { _x3 = value; } }
        public virtual bool X4 { get { return _nd_x ? false : _x4; } set { _x4 = value; } }
        public virtual bool X5 { get { return _nd_x ? false : _x5; } set { _x5 = value; } }
        public virtual bool X6 { get { return _nd_x ? false : _x6; } set { _x6 = value; } }
        public virtual bool X7 { get { return _nd_x ? false : _x7; } set { _x7 = value; } }
        public virtual bool X8 { get { return _nd_x ? false : _x8; } set { _x8 = value; } }
        public virtual bool X9 { get { return _nd_x ? false : _x9; } set { _x9 = value; } }
        public virtual bool X10 { get { return _nd_x ? false : _x10; } set { _x10 = value; } }
        public virtual bool J3 { get { return _nd_j ? false : _j3; } set { _j3 = value; } }
        public virtual bool J4 { get { return _nd_j ? false : _j4; } set { _j4 = value; } }
        public virtual bool J5 { get { return _nd_j ? false : _j5; } set { _j5 = value; } }
        public virtual bool J6 { get { return _nd_j ? false : _j6; } set { _j6 = value; } }
        public virtual bool J7 { get { return _nd_j ? false : _j7; } set { _j7 = value; } }
        public virtual bool J8 { get { return _nd_j ? false : _j8; } set { _j8 = value; } }
        public virtual bool J9 { get { return _nd_j ? false : _j9; } set { _j9 = value; } }
        public virtual bool J10 { get { return _nd_j ? false : _j10; } set { _j10 = value; } }
        public virtual bool V3 { get { return _nd_v ? false : _v3; } set { _v3 = value; } }
        public virtual bool V4 { get { return _nd_v ? false : _v4; } set { _v4 = value; } }
        public virtual bool V5 { get { return _nd_v ? false : _v5; } set { _v5 = value; } }
        public virtual bool V6 { get { return _nd_v ? false : _v6; } set { _v6 = value; } }
        public virtual bool V7 { get { return _nd_v ? false : _v7; } set { _v7 = value; } }
        public virtual bool V8 { get { return _nd_v ? false : _v8; } set { _v8 = value; } }
        public virtual bool V9 { get { return _nd_v ? false : _v9; } set { _v9 = value; } }
        public virtual bool V10 { get { return _nd_v ? false : _v10; } set { _v10 = value; } }
        public virtual bool S1 { get { return _nd_s ? false : _s1; } set { _s1 = value; } }
        public virtual bool S2 { get { return _nd_s ? false : _s2; } set { _s2 = value; } }
        public virtual bool S3 { get { return _nd_s ? false : _s3; } set { _s3 = value; } }
        public virtual bool S4 { get { return _nd_s ? false : _s4; } set { _s4 = value; } }
        public virtual bool L0 { get { return _nd_l ? false : _l0; } set { _l0 = value; } }
        public virtual bool M0 { get { return _nd_m ? false : _m0; } set { _m0 = value; } }
        public virtual bool X0 { get { return _nd_x ? false : _x0; } set { _x0 = value; } }
        public virtual bool J0 { get { return _nd_j ? false : _j0; } set { _j0 = value; } }
        public virtual bool V0 { get { return _nd_v ? false : _v0; } set { _v0 = value; } }
        public virtual bool S0 { get { return _nd_s ? false : _s0; } set { _s0 = value; } }
        public virtual bool L11 { get { return _nd_l ? false : _l11; } set { _l11 = value; } }
        public virtual bool L12 { get { return _nd_l ? false : _l12; } set { _l12 = value; } }
        public virtual bool M11 { get { return _nd_m ? false : _m11; } set { _m11 = value; } }
        public virtual bool M12 { get { return _nd_m ? false : _m12; } set { _m12 = value; } }
        public virtual bool X11 { get { return _nd_x ? false : _x11; } set { _x11 = value; } }
        public virtual bool X12 { get { return _nd_x ? false : _x12; } set { _x12 = value; } }
        public virtual bool J11 { get { return _nd_j ? false : _j11; } set { _j11 = value; } }
        public virtual bool J12 { get { return _nd_j ? false : _j12; } set { _j12 = value; } }
        public virtual bool V11 { get { return _nd_v ? false : _v11; } set { _v11 = value; } }
        public virtual bool V12 { get { return _nd_v ? false : _v12; } set { _v12 = value; } }
		public virtual bool NdL { get { return _nd_l; } set { _nd_l = value; } }
        public virtual bool NdM { get { return _nd_m ? false : _nd_m; } set { _nd_m = value; } }
		public virtual bool NdX { get { return _nd_x; } set { _nd_x = value; } }
		public virtual bool NdJ { get { return _nd_j; } set { _nd_j = value; } }
		public virtual bool NdV { get { return _nd_v; } set { _nd_v = value; } }
		public virtual bool NdS { get { return _nd_s; } set { _nd_s = value; } }
        public virtual bool L8AM { get { return _nd_l ? false : _l8am; } set { _l8am = value; } }
        public virtual bool M8AM { get { return _nd_m ? false : _m8am; } set { _m8am = value; } }
        public virtual bool X8AM { get { return _nd_x ? false : _x8am; } set { _x8am = value; } }
        public virtual bool J8AM { get { return _nd_j ? false : _j8am; } set { _j8am = value; } }
        public virtual bool V8AM { get { return _nd_v ? false : _v8am; } set { _v8am = value; } }
        public virtual bool Predeterminado { get { return _predeterminado; } set { _predeterminado = value; } }

		#endregion
		
		#region Business Methods
		
		public DisponibilidadRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_instructor = Format.DataReader.GetInt64(source, "OID_INSTRUCTOR");
			_fecha_inicio = Format.DataReader.GetDateTime(source, "FECHA_INICIO");
			_fecha_fin = Format.DataReader.GetDateTime(source, "FECHA_FIN");
			_l1 = Format.DataReader.GetBool(source, "L1");
			_l2 = Format.DataReader.GetBool(source, "L2");
			_m1 = Format.DataReader.GetBool(source, "M1");
			_m2 = Format.DataReader.GetBool(source, "M2");
			_x1 = Format.DataReader.GetBool(source, "X1");
			_x2 = Format.DataReader.GetBool(source, "X2");
			_j1 = Format.DataReader.GetBool(source, "J1");
			_j2 = Format.DataReader.GetBool(source, "J2");
			_v1 = Format.DataReader.GetBool(source, "V1");
			_v2 = Format.DataReader.GetBool(source, "V2");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_clases_semanales = Format.DataReader.GetInt64(source, "CLASES_SEMANALES");
			_l3 = Format.DataReader.GetBool(source, "L3");
			_l4 = Format.DataReader.GetBool(source, "L4");
			_l5 = Format.DataReader.GetBool(source, "L5");
			_l6 = Format.DataReader.GetBool(source, "L6");
			_l7 = Format.DataReader.GetBool(source, "L7");
			_l8 = Format.DataReader.GetBool(source, "L8");
			_l9 = Format.DataReader.GetBool(source, "L9");
			_l10 = Format.DataReader.GetBool(source, "L10");
			_m3 = Format.DataReader.GetBool(source, "M3");
			_m4 = Format.DataReader.GetBool(source, "M4");
			_m5 = Format.DataReader.GetBool(source, "M5");
			_m6 = Format.DataReader.GetBool(source, "M6");
			_m7 = Format.DataReader.GetBool(source, "M7");
			_m8 = Format.DataReader.GetBool(source, "M8");
			_m9 = Format.DataReader.GetBool(source, "M9");
			_m10 = Format.DataReader.GetBool(source, "M10");
			_x3 = Format.DataReader.GetBool(source, "X3");
			_x4 = Format.DataReader.GetBool(source, "X4");
			_x5 = Format.DataReader.GetBool(source, "X5");
			_x6 = Format.DataReader.GetBool(source, "X6");
			_x7 = Format.DataReader.GetBool(source, "X7");
			_x8 = Format.DataReader.GetBool(source, "X8");
			_x9 = Format.DataReader.GetBool(source, "X9");
			_x10 = Format.DataReader.GetBool(source, "X10");
			_j3 = Format.DataReader.GetBool(source, "J3");
			_j4 = Format.DataReader.GetBool(source, "J4");
			_j5 = Format.DataReader.GetBool(source, "J5");
			_j6 = Format.DataReader.GetBool(source, "J6");
			_j7 = Format.DataReader.GetBool(source, "J7");
			_j8 = Format.DataReader.GetBool(source, "J8");
			_j9 = Format.DataReader.GetBool(source, "J9");
			_j10 = Format.DataReader.GetBool(source, "J10");
			_v3 = Format.DataReader.GetBool(source, "V3");
			_v4 = Format.DataReader.GetBool(source, "V4");
			_v5 = Format.DataReader.GetBool(source, "V5");
			_v6 = Format.DataReader.GetBool(source, "V6");
			_v7 = Format.DataReader.GetBool(source, "V7");
			_v8 = Format.DataReader.GetBool(source, "V8");
			_v9 = Format.DataReader.GetBool(source, "V9");
			_v10 = Format.DataReader.GetBool(source, "V10");
			_s1 = Format.DataReader.GetBool(source, "S1");
			_s2 = Format.DataReader.GetBool(source, "S2");
			_s3 = Format.DataReader.GetBool(source, "S3");
			_s4 = Format.DataReader.GetBool(source, "S4");
			_l0 = Format.DataReader.GetBool(source, "L0");
			_m0 = Format.DataReader.GetBool(source, "M0");
			_x0 = Format.DataReader.GetBool(source, "X0");
			_j0 = Format.DataReader.GetBool(source, "J0");
			_v0 = Format.DataReader.GetBool(source, "V0");
			_s0 = Format.DataReader.GetBool(source, "S0");
			_l11 = Format.DataReader.GetBool(source, "L11");
			_l12 = Format.DataReader.GetBool(source, "L12");
			_m11 = Format.DataReader.GetBool(source, "M11");
			_m12 = Format.DataReader.GetBool(source, "M12");
			_x11 = Format.DataReader.GetBool(source, "X11");
			_x12 = Format.DataReader.GetBool(source, "X12");
			_j11 = Format.DataReader.GetBool(source, "J11");
			_j12 = Format.DataReader.GetBool(source, "J12");
			_v11 = Format.DataReader.GetBool(source, "V11");
			_v12 = Format.DataReader.GetBool(source, "V12");
			_nd_l = Format.DataReader.GetBool(source, "ND_L");
			_nd_m = Format.DataReader.GetBool(source, "ND_M");
			_nd_x = Format.DataReader.GetBool(source, "ND_X");
			_nd_j = Format.DataReader.GetBool(source, "ND_J");
			_nd_v = Format.DataReader.GetBool(source, "ND_V");
			_nd_s = Format.DataReader.GetBool(source, "ND_S");
            _l8am = Format.DataReader.GetBool(source, "L8AM");
            _m8am = Format.DataReader.GetBool(source, "M8AM");
            _x8am = Format.DataReader.GetBool(source, "X8AM");
            _j8am = Format.DataReader.GetBool(source, "J8AM");
            _v8am = Format.DataReader.GetBool(source, "V8AM");
            _predeterminado = Format.DataReader.GetBool(source, "PREDETERMINADO");

		}		
		public virtual void CopyValues(DisponibilidadRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_instructor = source.OidInstructor;
			_fecha_inicio = source.FechaInicio;
			_fecha_fin = source.FechaFin;
			_l1 = source.L1;
			_l2 = source.L2;
			_m1 = source.M1;
			_m2 = source.M2;
			_x1 = source.X1;
			_x2 = source.X2;
			_j1 = source.J1;
			_j2 = source.J2;
			_v1 = source.V1;
			_v2 = source.V2;
			_observaciones = source.Observaciones;
			_clases_semanales = source.ClasesSemanales;
			_l3 = source.L3;
			_l4 = source.L4;
			_l5 = source.L5;
			_l6 = source.L6;
			_l7 = source.L7;
			_l8 = source.L8;
			_l9 = source.L9;
			_l10 = source.L10;
			_m3 = source.M3;
			_m4 = source.M4;
			_m5 = source.M5;
			_m6 = source.M6;
			_m7 = source.M7;
			_m8 = source.M8;
			_m9 = source.M9;
			_m10 = source.M10;
			_x3 = source.X3;
			_x4 = source.X4;
			_x5 = source.X5;
			_x6 = source.X6;
			_x7 = source.X7;
			_x8 = source.X8;
			_x9 = source.X9;
			_x10 = source.X10;
			_j3 = source.J3;
			_j4 = source.J4;
			_j5 = source.J5;
			_j6 = source.J6;
			_j7 = source.J7;
			_j8 = source.J8;
			_j9 = source.J9;
			_j10 = source.J10;
			_v3 = source.V3;
			_v4 = source.V4;
			_v5 = source.V5;
			_v6 = source.V6;
			_v7 = source.V7;
			_v8 = source.V8;
			_v9 = source.V9;
			_v10 = source.V10;
			_s1 = source.S1;
			_s2 = source.S2;
			_s3 = source.S3;
			_s4 = source.S4;
			_l0 = source.L0;
			_m0 = source.M0;
			_x0 = source.X0;
			_j0 = source.J0;
			_v0 = source.V0;
			_s0 = source.S0;
			_l11 = source.L11;
			_l12 = source.L12;
			_m11 = source.M11;
			_m12 = source.M12;
			_x11 = source.X11;
			_x12 = source.X12;
			_j11 = source.J11;
			_j12 = source.J12;
			_v11 = source.V11;
			_v12 = source.V12;
			_nd_l = source.NdL;
			_nd_m = source.NdM;
			_nd_x = source.NdX;
			_nd_j = source.NdJ;
			_nd_v = source.NdV;
			_nd_s = source.NdS;
            _l8am = source.L8AM;
            _m8am = source.M8AM;
            _x8am = source.X8AM;
            _j8am = source.J8AM;
            _v8am = source.V8AM;
            _predeterminado = source.Predeterminado;
		}
		
		#endregion	
	}

    [Serializable()]
	public class DisponibilidadBase 
	{	 
		#region Attributes
		
		private DisponibilidadRecord _record = new DisponibilidadRecord();

        private List<bool> _semana = new List<bool>();
		
		#endregion
		
		#region Properties
		
		public DisponibilidadRecord Record { get { return _record; } }

        public virtual List<bool> Semana
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                return _semana;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_semana.Equals(value))
                {
                    _semana = value;
                }
            }
        }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
                _semana = new List<bool>();

                _semana.Add(Record.L8AM);
                _semana.Add(Record.L0);
                _semana.Add(Record.L1);
                _semana.Add(Record.L2);
                _semana.Add(Record.L2);
                _semana.Add(Record.L2);
                _semana.Add(Record.L5);
                _semana.Add(Record.L6);
                _semana.Add(Record.L7);
                _semana.Add(Record.L8);
                _semana.Add(Record.L9);
                _semana.Add(Record.L10);
                _semana.Add(Record.L11);
                _semana.Add(Record.L12);
                _semana.Add(Record.M8AM);
                _semana.Add(Record.M0);
                _semana.Add(Record.M1);
                _semana.Add(Record.M2);
                _semana.Add(Record.M3);
                _semana.Add(Record.M4);
                _semana.Add(Record.M5);
                _semana.Add(Record.M6);
                _semana.Add(Record.M7);
                _semana.Add(Record.M8);
                _semana.Add(Record.M9);
                _semana.Add(Record.M10);
                _semana.Add(Record.M11);
                _semana.Add(Record.M12);
                _semana.Add(Record.X8AM);
                _semana.Add(Record.X0);
                _semana.Add(Record.X1);
                _semana.Add(Record.X2);
                _semana.Add(Record.X3);
                _semana.Add(Record.X4);
                _semana.Add(Record.X5);
                _semana.Add(Record.X6);
                _semana.Add(Record.X7);
                _semana.Add(Record.X8);
                _semana.Add(Record.X9);
                _semana.Add(Record.X10);
                _semana.Add(Record.X11);
                _semana.Add(Record.X12);
                _semana.Add(Record.J8AM);
                _semana.Add(Record.J0);
                _semana.Add(Record.J1);
                _semana.Add(Record.J2);
                _semana.Add(Record.J3);
                _semana.Add(Record.J4);
                _semana.Add(Record.J5);
                _semana.Add(Record.J6);
                _semana.Add(Record.J7);
                _semana.Add(Record.J8);
                _semana.Add(Record.J9);
                _semana.Add(Record.J10);
                _semana.Add(Record.J11);
                _semana.Add(Record.J12);
                _semana.Add(Record.V8AM);
                _semana.Add(Record.V0);
                _semana.Add(Record.V1);
                _semana.Add(Record.V2);
                _semana.Add(Record.V3);
                _semana.Add(Record.V4);
                _semana.Add(Record.V5);
                _semana.Add(Record.V6);
                _semana.Add(Record.V7);
                _semana.Add(Record.V8);
                _semana.Add(Record.V9);
                _semana.Add(Record.V10);
                _semana.Add(Record.V11);
                _semana.Add(Record.V12);
                _semana.Add(Record.S0);
                _semana.Add(Record.S1);
                _semana.Add(Record.S2);
                _semana.Add(Record.S3);
                _semana.Add(Record.S4);
		}		
		public void CopyValues(Disponibilidad source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

                if (_semana.Count == 0)
                {
                    for (int i = 0; i < 75; i++)
                        _semana.Add(new bool());
                }
                _semana[0] = source.L8AM;
                _semana[1] = source.L0;
                _semana[2] = source.L1;
                _semana[3] = source.L2;
                _semana[4] = source.L3;
                _semana[5] = source.L4;
                _semana[6] = source.L5;
                _semana[7] = source.L6;
                _semana[8] = source.L7;
                _semana[9] = source.L8;
                _semana[10] = source.L9;
                _semana[11] = source.L10;
                _semana[12] = source.L11;
                _semana[13] = source.L12;
                _semana[14] = source.M8AM;
                _semana[15] = source.M0;
                _semana[16] = source.M1;
                _semana[17] = source.M2;
                _semana[18] = source.M3;
                _semana[19] = source.M4;
                _semana[20] = source.M5;
                _semana[21] = source.M6;
                _semana[22] = source.M7;
                _semana[23] = source.M8;
                _semana[24] = source.M9;
                _semana[25] = source.M10;
                _semana[26] = source.M11;
                _semana[27] = source.M12;
                _semana[28] = source.X8AM;
                _semana[29] = source.X0;
                _semana[30] = source.X1;
                _semana[31] = source.X2;
                _semana[32] = source.X3;
                _semana[33] = source.X4;
                _semana[34] = source.X5;
                _semana[35] = source.X6;
                _semana[36] = source.X7;
                _semana[37] = source.X8;
                _semana[38] = source.X9;
                _semana[39] = source.X10;
                _semana[40] = source.X11;
                _semana[41] = source.X12;
                _semana[42] = source.J8AM;
                _semana[43] = source.J0;
                _semana[44] = source.J1;
                _semana[45] = source.J2;
                _semana[46] = source.J3;
                _semana[47] = source.J4;
                _semana[48] = source.J5;
                _semana[49] = source.J6;
                _semana[50] = source.J7;
                _semana[51] = source.J8;
                _semana[52] = source.J9;
                _semana[53] = source.J10;
                _semana[54] = source.J11;
                _semana[55] = source.J12;
                _semana[56] = source.V8AM;
                _semana[57] = source.V0;
                _semana[58] = source.V1;
                _semana[59] = source.V2;
                _semana[60] = source.V3;
                _semana[61] = source.V4;
                _semana[62] = source.V5;
                _semana[63] = source.V6;
                _semana[64] = source.V7;
                _semana[65] = source.V8;
                _semana[66] = source.V9;
                _semana[67] = source.V10;
                _semana[68] = source.V11;
                _semana[69] = source.V12;
                _semana[70] = source.S0;
                _semana[71] = source.S1;
                _semana[72] = source.S2;
                _semana[73] = source.S3;
                _semana[74] = source.S4;
		}
		public void CopyValues(DisponibilidadInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

                if (_semana.Count == 0)
                {
                    for (int i = 0; i < 75; i++)
                        _semana.Add(new bool());
                }
                _semana[0] = source.L8AM;
                _semana[1] = source.L0;
                _semana[2] = source.L1;
                _semana[3] = source.L2;
                _semana[4] = source.L3;
                _semana[5] = source.L4;
                _semana[6] = source.L5;
                _semana[7] = source.L6;
                _semana[8] = source.L7;
                _semana[9] = source.L8;
                _semana[10] = source.L9;
                _semana[11] = source.L10;
                _semana[12] = source.L11;
                _semana[13] = source.L12;
                _semana[14] = source.M8AM;
                _semana[15] = source.M0;
                _semana[16] = source.M1;
                _semana[17] = source.M2;
                _semana[18] = source.M3;
                _semana[19] = source.M4;
                _semana[20] = source.M5;
                _semana[21] = source.M6;
                _semana[22] = source.M7;
                _semana[23] = source.M8;
                _semana[24] = source.M9;
                _semana[25] = source.M10;
                _semana[26] = source.M11;
                _semana[27] = source.M12;
                _semana[28] = source.X8AM;
                _semana[29] = source.X0;
                _semana[30] = source.X1;
                _semana[31] = source.X2;
                _semana[32] = source.X3;
                _semana[33] = source.X4;
                _semana[34] = source.X5;
                _semana[35] = source.X6;
                _semana[36] = source.X7;
                _semana[37] = source.X8;
                _semana[38] = source.X9;
                _semana[39] = source.X10;
                _semana[40] = source.X11;
                _semana[41] = source.X12;
                _semana[42] = source.J8AM;
                _semana[43] = source.J0;
                _semana[44] = source.J1;
                _semana[45] = source.J2;
                _semana[46] = source.J3;
                _semana[47] = source.J4;
                _semana[48] = source.J5;
                _semana[49] = source.J6;
                _semana[50] = source.J7;
                _semana[51] = source.J8;
                _semana[52] = source.J9;
                _semana[53] = source.J10;
                _semana[54] = source.J11;
                _semana[55] = source.J12;
                _semana[56] = source.V8AM;
                _semana[57] = source.V0;
                _semana[58] = source.V1;
                _semana[59] = source.V2;
                _semana[60] = source.V3;
                _semana[61] = source.V4;
                _semana[62] = source.V5;
                _semana[63] = source.V6;
                _semana[64] = source.V7;
                _semana[65] = source.V8;
                _semana[66] = source.V9;
                _semana[67] = source.V10;
                _semana[68] = source.V11;
                _semana[69] = source.V12;
                _semana[70] = source.S0;
                _semana[71] = source.S1;
                _semana[72] = source.S2;
                _semana[73] = source.S3;
                _semana[74] = source.S4;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Disponibilidad : BusinessBaseEx<Disponibilidad>
	{	 
		#region Attributes
		
		protected DisponibilidadBase _base = new DisponibilidadBase();
		

		#endregion
		
		#region Properties
		
		public DisponibilidadBase Base { get { return _base; } }
		
		public override long Oid
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Oid;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				if (!_base.Record.Oid.Equals(value))
				{
					_base.Record.Oid = value;
					//PropertyHasChanged();
				}
			}
		}
		public virtual long OidInstructor
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidInstructor;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidInstructor.Equals(value))
				{
					_base.Record.OidInstructor = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaInicio
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaInicio;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.FechaInicio.Equals(value))
				{
					_base.Record.FechaInicio = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaFin
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaFin;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.FechaFin.Equals(value))
				{
					_base.Record.FechaFin = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L1
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L1;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L1.Equals(value))
				{
					_base.Record.L1 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L2
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L2;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L2.Equals(value))
				{
					_base.Record.L2 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M1
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M1;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M1.Equals(value))
				{
					_base.Record.M1 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M2
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M2;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M2.Equals(value))
				{
					_base.Record.M2 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X1
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X1;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X1.Equals(value))
				{
					_base.Record.X1 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X2
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X2;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X2.Equals(value))
				{
					_base.Record.X2 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J1
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J1;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J1.Equals(value))
				{
					_base.Record.J1 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J2
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J2;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J2.Equals(value))
				{
					_base.Record.J2 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V1
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V1;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V1.Equals(value))
				{
					_base.Record.V1 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V2
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V2;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V2.Equals(value))
				{
					_base.Record.V2 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Observaciones
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Observaciones;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Observaciones.Equals(value))
				{
					_base.Record.Observaciones = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long ClasesSemanales
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.ClasesSemanales;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.ClasesSemanales.Equals(value))
				{
					_base.Record.ClasesSemanales = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L3
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L3;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L3.Equals(value))
				{
					_base.Record.L3 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L4
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L4;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L4.Equals(value))
				{
					_base.Record.L4 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L5
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L5;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L5.Equals(value))
				{
					_base.Record.L5 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L6
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L6;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L6.Equals(value))
				{
					_base.Record.L6 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L7
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L7;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L7.Equals(value))
				{
					_base.Record.L7 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L8
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L8;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L8.Equals(value))
				{
					_base.Record.L8 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L9
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L9;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L9.Equals(value))
				{
					_base.Record.L9 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L10
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L10;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L10.Equals(value))
				{
					_base.Record.L10 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M3
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M3;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M3.Equals(value))
				{
					_base.Record.M3 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M4
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M4;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M4.Equals(value))
				{
					_base.Record.M4 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M5
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M5;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M5.Equals(value))
				{
					_base.Record.M5 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M6
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M6;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M6.Equals(value))
				{
					_base.Record.M6 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M7
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M7;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M7.Equals(value))
				{
					_base.Record.M7 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M8
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M8;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M8.Equals(value))
				{
					_base.Record.M8 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M9
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M9;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M9.Equals(value))
				{
					_base.Record.M9 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M10
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M10;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M10.Equals(value))
				{
					_base.Record.M10 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X3
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X3;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X3.Equals(value))
				{
					_base.Record.X3 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X4
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X4;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X4.Equals(value))
				{
					_base.Record.X4 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X5
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X5;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X5.Equals(value))
				{
					_base.Record.X5 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X6
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X6;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X6.Equals(value))
				{
					_base.Record.X6 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X7
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X7;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X7.Equals(value))
				{
					_base.Record.X7 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X8
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X8;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X8.Equals(value))
				{
					_base.Record.X8 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X9
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X9;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X9.Equals(value))
				{
					_base.Record.X9 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X10
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X10;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X10.Equals(value))
				{
					_base.Record.X10 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J3
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J3;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J3.Equals(value))
				{
					_base.Record.J3 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J4
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J4;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J4.Equals(value))
				{
					_base.Record.J4 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J5
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J5;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J5.Equals(value))
				{
					_base.Record.J5 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J6
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J6;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J6.Equals(value))
				{
					_base.Record.J6 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J7
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J7;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J7.Equals(value))
				{
					_base.Record.J7 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J8
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J8;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J8.Equals(value))
				{
					_base.Record.J8 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J9
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J9;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J9.Equals(value))
				{
					_base.Record.J9 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J10
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J10;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J10.Equals(value))
				{
					_base.Record.J10 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V3
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V3;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V3.Equals(value))
				{
					_base.Record.V3 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V4
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V4;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V4.Equals(value))
				{
					_base.Record.V4 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V5
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V5;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V5.Equals(value))
				{
					_base.Record.V5 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V6
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V6;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V6.Equals(value))
				{
					_base.Record.V6 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V7
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V7;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V7.Equals(value))
				{
					_base.Record.V7 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V8
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V8;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V8.Equals(value))
				{
					_base.Record.V8 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V9
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V9;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V9.Equals(value))
				{
					_base.Record.V9 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V10
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V10;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V10.Equals(value))
				{
					_base.Record.V10 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool S1
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.S1;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.S1.Equals(value))
				{
					_base.Record.S1 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool S2
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.S2;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.S2.Equals(value))
				{
					_base.Record.S2 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool S3
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.S3;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.S3.Equals(value))
				{
					_base.Record.S3 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool S4
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.S4;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.S4.Equals(value))
				{
					_base.Record.S4 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L0
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L0;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L0.Equals(value))
				{
					_base.Record.L0 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M0
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M0;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M0.Equals(value))
				{
					_base.Record.M0 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X0
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X0;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X0.Equals(value))
				{
					_base.Record.X0 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J0
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J0;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J0.Equals(value))
				{
					_base.Record.J0 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V0
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V0;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V0.Equals(value))
				{
					_base.Record.V0 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool S0
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.S0;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.S0.Equals(value))
				{
					_base.Record.S0 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L11
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L11;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L11.Equals(value))
				{
					_base.Record.L11 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool L12
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.L12;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.L12.Equals(value))
				{
					_base.Record.L12 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M11
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M11;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M11.Equals(value))
				{
					_base.Record.M11 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool M12
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.M12;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.M12.Equals(value))
				{
					_base.Record.M12 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X11
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X11;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X11.Equals(value))
				{
					_base.Record.X11 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool X12
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.X12;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.X12.Equals(value))
				{
					_base.Record.X12 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J11
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J11;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J11.Equals(value))
				{
					_base.Record.J11 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool J12
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.J12;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.J12.Equals(value))
				{
					_base.Record.J12 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V11
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V11;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V11.Equals(value))
				{
					_base.Record.V11 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool V12
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.V12;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.V12.Equals(value))
				{
					_base.Record.V12 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool NdL
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NdL;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.NdL.Equals(value))
				{
					_base.Record.NdL = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool NdM
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NdM;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.NdM.Equals(value))
				{
					_base.Record.NdM = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool NdX
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NdX;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.NdX.Equals(value))
				{
					_base.Record.NdX = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool NdJ
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NdJ;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.NdJ.Equals(value))
				{
					_base.Record.NdJ = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool NdV
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NdV;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.NdV.Equals(value))
				{
					_base.Record.NdV = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool NdS
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NdS;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.NdS.Equals(value))
				{
					_base.Record.NdS = value;
					PropertyHasChanged();
				}
			}
		}
        public virtual bool L8AM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.L8AM;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.L8AM.Equals(value))
                {
                    _base.Record.L8AM = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool M8AM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.M8AM;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.M8AM.Equals(value))
                {
                    _base.Record.M8AM = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool X8AM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.X8AM;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.X8AM.Equals(value))
                {
                    _base.Record.X8AM = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool J8AM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.J8AM;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.J8AM.Equals(value))
                {
                    _base.Record.J8AM = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool V8AM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.V8AM;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.V8AM.Equals(value))
                {
                    _base.Record.V8AM = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual bool Predeterminado
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Predeterminado;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.Predeterminado.Equals(value))
                {
                    _base.Record.Predeterminado = value;
                    PropertyHasChanged();
                }
            }
        }

        public virtual List<bool> Semana
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                return _base.Semana;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (!_base.Semana.Equals(value))
                {
                    _base.Semana = value;
                }
            }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Disponibilidad CloneAsNew()
		{
			Disponibilidad clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Disponibilidad.OpenSession();
			Disponibilidad.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		public virtual void CopyFrom(DisponibilidadInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidInstructor = source.OidInstructor;
			FechaInicio = source.FechaInicio;
			FechaFin = source.FechaFin;
            L8AM = source.L8AM;
            M8AM = source.M8AM;
            X8AM = source.X8AM;
            J8AM = source.J8AM;
            V8AM = source.V8AM;
			L1 = source.L1;
			L2 = source.L2;
			M1 = source.M1;
			M2 = source.M2;
			X1 = source.X1;
			X2 = source.X2;
			J1 = source.J1;
			J2 = source.J2;
			V1 = source.V1;
			V2 = source.V2;
			Observaciones = source.Observaciones;
			ClasesSemanales = source.ClasesSemanales;
			L3 = source.L3;
			L4 = source.L4;
			L5 = source.L5;
			L6 = source.L6;
			L7 = source.L7;
			L8 = source.L8;
			L9 = source.L9;
			L10 = source.L10;
			M3 = source.M3;
			M4 = source.M4;
			M5 = source.M5;
			M6 = source.M6;
			M7 = source.M7;
			M8 = source.M8;
			M9 = source.M9;
			M10 = source.M10;
			X3 = source.X3;
			X4 = source.X4;
			X5 = source.X5;
			X6 = source.X6;
			X7 = source.X7;
			X8 = source.X8;
			X9 = source.X9;
			X10 = source.X10;
			J3 = source.J3;
			J4 = source.J4;
			J5 = source.J5;
			J6 = source.J6;
			J7 = source.J7;
			J8 = source.J8;
			J9 = source.J9;
			J10 = source.J10;
			V3 = source.V3;
			V4 = source.V4;
			V5 = source.V5;
			V6 = source.V6;
			V7 = source.V7;
			V8 = source.V8;
			V9 = source.V9;
			V10 = source.V10;
			S1 = source.S1;
			S2 = source.S2;
			S3 = source.S3;
			S4 = source.S4;
			L0 = source.L0;
			M0 = source.M0;
			X0 = source.X0;
			J0 = source.J0;
			V0 = source.V0;
			S0 = source.S0;
			L11 = source.L11;
			L12 = source.L12;
			M11 = source.M11;
			M12 = source.M12;
			X11 = source.X11;
			X12 = source.X12;
			J11 = source.J11;
			J12 = source.J12;
			V11 = source.V11;
			V12 = source.V12;
			NdL = source.NdL;
			NdM = source.NdM;
			NdX = source.NdX;
			NdJ = source.NdJ;
			NdV = source.NdV;
			NdS = source.NdS;
            Predeterminado = source.Predeterminado;
		}
		
			
		#endregion
		 
	     #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidInstructor", 1));

             ValidationRules.AddRule(CommonRules.MaxValue<long>,
                                    new CommonRules.MaxValueRuleArgs<long>("ClasesSemanales", 60));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("ClasesSemanales", 0));
        }
		 
		 #endregion
		 
		 #region Autorization Rules
		 
			public static bool CanAddObject()
			{
                return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.INSTRUCTOR);

			}

			public static bool CanGetObject()
			{
                return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.INSTRUCTOR);

			}

			public static bool CanDeleteObject()
			{
                return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.INSTRUCTOR);

			}
			public static bool CanEditObject()
			{
                return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.INSTRUCTOR);

			}
		 
		 #endregion
		 
		 #region Factory Methods
		 
		 	/// <summary>
			/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
			/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
			/// pero debe ser protected por exigencia de NHibernate
			/// y public para que funcionen los DataGridView
			/// </summary>
			public Disponibilidad() 
			{ 
				MarkAsChild();
				Random r = new Random();
                Oid = (long)r.Next();
                ClasesSemanales = 15;
			}	

			private Disponibilidad(Disponibilidad source)
			{
				MarkAsChild();
				Fetch(source);
			}

			private Disponibilidad(IDataReader reader)
			{
				MarkAsChild();
				Fetch(reader);
			}

			public static Disponibilidad NewChild(Instructor parent)
			{
				if (!CanAddObject())
					throw new System.Security.SecurityException(
						moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

				Disponibilidad obj = new Disponibilidad();
				obj.OidInstructor = parent.Oid;
				return obj;
			}

			internal static Disponibilidad GetChild(Disponibilidad source)
			{
				return new Disponibilidad(source);
			}

			internal static Disponibilidad GetChild(IDataReader reader)
			{
				return new Disponibilidad(reader);
			}

			public virtual DisponibilidadInfo GetInfo()
			{
				if (!CanGetObject())
					throw new System.Security.SecurityException(
					  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

				return new DisponibilidadInfo(this);
			}
			
			/// <summary>
			/// Borrado aplazado, es posible el undo 
			/// (La función debe ser "no estática")
			/// </summary>
			public override void Delete()
			{
				if (!CanDeleteObject())
					throw new System.Security.SecurityException(
						moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);			
				
				MarkDeleted();
			}

			/// <summary>
			/// No se debe utilizar esta función para guardar. Hace falta el padre.
			/// Utilizar Insert o Update en sustitución de Save.
			/// </summary>
			/// <returns></returns>
			public override Disponibilidad Save()
			{
				throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
			}

			
		 #endregion
		 
		 #region Child Data Access
		 
		 	private void Fetch(Disponibilidad source)
			{
				_base.CopyValues(source);
				MarkOld();
			}

			private void Fetch(IDataReader reader)
			{
				_base.CopyValues(reader);
				MarkOld();
			}

			internal void Insert(Instructor parent)
			{
				// if we're not dirty then don't update the database
				if (!this.IsDirty) return;

                SessionCode = parent.SessionCode;

				OidInstructor = parent.Oid;

				try
				{
					ValidationRules.CheckRules();

					if (!IsValid)
						throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

					parent.Session().Save(this.Base.Record);
				}
				catch (Exception ex)
				{
					iQExceptionHandler.TreatException(ex);
				}

				MarkOld();
			}

			internal void Update(Instructor parent)
			{
				// if we're not dirty then don't update the database
				if (!this.IsDirty) return;

				OidInstructor = parent.Oid;

				try
				{
					ValidationRules.CheckRules();

					if (!IsValid)
						throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

					DisponibilidadRecord obj = parent.Session().Get<DisponibilidadRecord>(Oid);
					obj.CopyValues(this.Base.Record);
					parent.Session().Update(obj);
				}
				catch (Exception ex)
				{
					iQExceptionHandler.TreatException(ex);
				}

				MarkOld();
			}

			internal void DeleteSelf(Instructor parent)
			{
				// if we're not dirty then don't update the database
				if (!this.IsDirty) return;

				// if we're new then don't update the database
				if (this.IsNew) return;

				try
				{
					parent.Session().Delete(parent.Session().Get<DisponibilidadRecord>(Oid));
				}
				catch (Exception ex)
				{
					iQExceptionHandler.TreatException(ex);
				}
		
				MarkNew(); 
			}

		 
		 #endregion
	
	}
}

