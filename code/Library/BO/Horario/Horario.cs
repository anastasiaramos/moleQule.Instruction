using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Store;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class HorarioRecord : RecordBase
	{
		#region Attributes

		private long _oid_plan;
		private long _oid_promocion;
		private DateTime _fecha_inicial;
		private DateTime _fecha_final;
		private string _observaciones = string.Empty;
        private bool _h8am = false;
		private bool _h1 = false;
		private bool _h2 = false;
		private bool _h3 = false;
		private bool _h4 = false;
		private bool _h5 = false;
		private bool _h6 = false;
		private bool _h7 = false;
		private bool _h8 = false;
		private bool _h9 = false;
		private bool _h10 = false;
		private bool _hs1 = false;
		private bool _hs2 = false;
		private bool _hs3 = false;
		private bool _hs4 = false;
		private bool _h0 = false;
		private bool _hs0 = false;
		private bool _h11 = false;
		private bool _h12 = false;
  
		#endregion
		
		#region Properties
		
				public virtual long OidPlan { get { return _oid_plan; } set { _oid_plan = value; } }
		public virtual long OidPromocion { get { return _oid_promocion; } set { _oid_promocion = value; } }
		public virtual DateTime FechaInicial { get { return _fecha_inicial; } set { _fecha_inicial = value; } }
		public virtual DateTime FechaFinal { get { return _fecha_final; } set { _fecha_final = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
        public virtual bool H8AM { get { return _h8am; } set { _h8am = value; } }
		public virtual bool H1 { get { return _h1; } set { _h1 = value; } }
		public virtual bool H2 { get { return _h2; } set { _h2 = value; } }
		public virtual bool H3 { get { return _h3; } set { _h3 = value; } }
		public virtual bool H4 { get { return _h4; } set { _h4 = value; } }
		public virtual bool H5 { get { return _h5; } set { _h5 = value; } }
		public virtual bool H6 { get { return _h6; } set { _h6 = value; } }
		public virtual bool H7 { get { return _h7; } set { _h7 = value; } }
		public virtual bool H8 { get { return _h8; } set { _h8 = value; } }
		public virtual bool H9 { get { return _h9; } set { _h9 = value; } }
		public virtual bool H10 { get { return _h10; } set { _h10 = value; } }
		public virtual bool Hs1 { get { return _hs1; } set { _hs1 = value; } }
		public virtual bool Hs2 { get { return _hs2; } set { _hs2 = value; } }
		public virtual bool Hs3 { get { return _hs3; } set { _hs3 = value; } }
		public virtual bool Hs4 { get { return _hs4; } set { _hs4 = value; } }
		public virtual bool H0 { get { return _h0; } set { _h0 = value; } }
		public virtual bool Hs0 { get { return _hs0; } set { _hs0 = value; } }
		public virtual bool H11 { get { return _h11; } set { _h11 = value; } }
		public virtual bool H12 { get { return _h12; } set { _h12 = value; } }

		#endregion
		
		#region Business Methods
		
		public HorarioRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_plan = Format.DataReader.GetInt64(source, "OID_PLAN");
			_oid_promocion = Format.DataReader.GetInt64(source, "OID_PROMOCION");
			_fecha_inicial = Format.DataReader.GetDateTime(source, "FECHA_INICIAL");
			_fecha_final = Format.DataReader.GetDateTime(source, "FECHA_FINAL");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
            _h8am = Format.DataReader.GetBool(source, "H8AM");
			_h1 = Format.DataReader.GetBool(source, "H1");
			_h2 = Format.DataReader.GetBool(source, "H2");
			_h3 = Format.DataReader.GetBool(source, "H3");
			_h4 = Format.DataReader.GetBool(source, "H4");
			_h5 = Format.DataReader.GetBool(source, "H5");
			_h6 = Format.DataReader.GetBool(source, "H6");
			_h7 = Format.DataReader.GetBool(source, "H7");
			_h8 = Format.DataReader.GetBool(source, "H8");
			_h9 = Format.DataReader.GetBool(source, "H9");
			_h10 = Format.DataReader.GetBool(source, "H10");
			_hs1 = Format.DataReader.GetBool(source, "HS1");
			_hs2 = Format.DataReader.GetBool(source, "HS2");
			_hs3 = Format.DataReader.GetBool(source, "HS3");
			_hs4 = Format.DataReader.GetBool(source, "HS4");
			_h0 = Format.DataReader.GetBool(source, "H0");
			_hs0 = Format.DataReader.GetBool(source, "HS0");
			_h11 = Format.DataReader.GetBool(source, "H11");
			_h12 = Format.DataReader.GetBool(source, "H12");

		}		
		public virtual void CopyValues(HorarioRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_plan = source.OidPlan;
			_oid_promocion = source.OidPromocion;
			_fecha_inicial = source.FechaInicial;
			_fecha_final = source.FechaFinal;
			_observaciones = source.Observaciones;
            _h8am = source.H8AM;
			_h1 = source.H1;
			_h2 = source.H2;
			_h3 = source.H3;
			_h4 = source.H4;
			_h5 = source.H5;
			_h6 = source.H6;
			_h7 = source.H7;
			_h8 = source.H8;
			_h9 = source.H9;
			_h10 = source.H10;
			_hs1 = source.Hs1;
			_hs2 = source.Hs2;
			_hs3 = source.Hs3;
			_hs4 = source.Hs4;
			_h0 = source.H0;
			_hs0 = source.Hs0;
			_h11 = source.H11;
			_h12 = source.H12;
		}
		
		#endregion	
	}

    [Serializable()]
	public class HorarioBase 
	{	 
		#region Attributes
		
		private HorarioRecord _record = new HorarioRecord();

        //Campos adicionales
        protected string _plan;
        protected string _promocion;
		
		#endregion
		
		#region Properties
		
		public HorarioRecord Record { get { return _record; } }

        //Propiedades adicionales
        public virtual string Plan { get { return _plan; } set { _plan = value; } }
        public virtual string Promocion { get { return _promocion; } set { _promocion = value; }  }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _plan = Format.DataReader.GetString(source, "PLAN");
            _promocion = Format.DataReader.GetString(source, "PROMOCION");
		}		
		public void CopyValues(Horario source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _plan = source.Plan;
            _promocion = source.Promocion;
		}
		public void CopyValues(HorarioInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _plan = source.Plan;
            _promocion = source.Promocion;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Horario : BusinessBaseEx<Horario>
	{	 
		#region Attributes
		
		protected HorarioBase _base = new HorarioBase();

        private Sesions _sesiones = Sesions.NewChildList();
        private ParteAsistencias _asistencias = ParteAsistencias.NewChildList();
		

		#endregion
		
		#region Properties
		
		public HorarioBase Base { get { return _base; } }
		
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
				//CanWriteProperty(true);
				if (!_base.Record.Oid.Equals(value))
				{
					_base.Record.Oid = value;
					//PropertyHasChanged();
				}
			}
		}
		public virtual long OidPlan
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPlan;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPlan.Equals(value))
				{
					_base.Record.OidPlan = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidPromocion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPromocion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPromocion.Equals(value))
				{
					_base.Record.OidPromocion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaInicial
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaInicial;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaInicial.Equals(value))
				{
					_base.Record.FechaInicial = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaFinal
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaFinal;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaFinal.Equals(value))
				{
					_base.Record.FechaFinal = value;
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
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Observaciones.Equals(value))
				{
					_base.Record.Observaciones = value;
					PropertyHasChanged();
				}
			}
		}
        public virtual bool H8AM
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.H8AM;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //CanWriteProperty(true);

                if (!_base.Record.H8AM.Equals(value))
                {
                    _base.Record.H8AM = value;
                    PropertyHasChanged();
                }
            }
        }
		public virtual bool H1
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H1;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H1.Equals(value))
				{
					_base.Record.H1 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H2
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H2;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H2.Equals(value))
				{
					_base.Record.H2 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H3
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H3;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H3.Equals(value))
				{
					_base.Record.H3 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H4
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H4;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H4.Equals(value))
				{
					_base.Record.H4 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H5
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H5;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H5.Equals(value))
				{
					_base.Record.H5 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H6
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H6;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H6.Equals(value))
				{
					_base.Record.H6 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H7
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H7;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H7.Equals(value))
				{
					_base.Record.H7 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H8
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H8;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H8.Equals(value))
				{
					_base.Record.H8 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H9
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H9;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H9.Equals(value))
				{
					_base.Record.H9 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H10
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H10;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H10.Equals(value))
				{
					_base.Record.H10 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool HS1
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Hs1;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Hs1.Equals(value))
				{
					_base.Record.Hs1 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool HS2
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Hs2;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Hs2.Equals(value))
				{
					_base.Record.Hs2 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool HS3
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Hs3;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Hs3.Equals(value))
				{
					_base.Record.Hs3 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool HS4
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Hs4;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Hs4.Equals(value))
				{
					_base.Record.Hs4 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H0
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H0;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H0.Equals(value))
				{
					_base.Record.H0 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool HS0
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Hs0;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Hs0.Equals(value))
				{
					_base.Record.Hs0 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H11
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H11;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H11.Equals(value))
				{
					_base.Record.H11 = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool H12
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.H12;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.H12.Equals(value))
				{
					_base.Record.H12 = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual Sesions Sesions
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _sesiones;
            }

            set
            {
                _sesiones = value;
            }
        }
        public virtual ParteAsistencias Asistencias
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _asistencias;
            }

            set
            {
                _asistencias = value;
            }
        }

        //Propiedades adicionales
        public virtual string Plan { get { return _base.Plan; } set { _base.Plan = value; } }
        public virtual string Promocion { get { return _base.Promocion; } set { _base.Promocion = value; }  }

        public override bool IsValid
        {
            get { return base.IsValid && _sesiones.IsValid && _asistencias.IsValid; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _sesiones.IsDirty || _asistencias.IsDirty; }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Horario CloneAsNew()
		{
			Horario clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Horario.OpenSession();
			Horario.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(HorarioInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidPlan = source.OidPlan;
			OidPromocion = source.OidPromocion;
			FechaInicial = source.FechaInicial;
			FechaFinal = source.FechaFinal;
			Observaciones = source.Observaciones;
            H8AM = source.H8AM;
			H1 = source.H1;
			H2 = source.H2;
			H3 = source.H3;
			H4 = source.H4;
			H5 = source.H5;
			H6 = source.H6;
			H7 = source.H7;
			H8 = source.H8;
			H9 = source.H9;
			H10 = source.H10;
			HS1 = source.Hs1;
			HS2 = source.Hs2;
			HS3 = source.Hs3;
			HS4 = source.Hs4;
			H0 = source.H0;
			HS0 = source.Hs0;
			H11 = source.H11;
			H12 = source.H12;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPlan", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPromocion", 1));
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.HORARIO);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.HORARIO);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.HORARIO);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.HORARIO);

        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        protected Horario() { }

        public virtual HorarioInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new HorarioInfo(this, get_childs);
        }

        public virtual HorarioInfo GetInfo() { return GetInfo(true); }

        #endregion

        #region Root Factory Methods

        public static Horario New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Horario>(new CriteriaCs(-1));
        }

        public static Horario Get(long oid, bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Horario.GetCriteria(Horario.OpenSession());
            
            criteria.Childs = get_childs;
            if (nHManager.Instance.UseDirectSQL) 
                criteria.Query = Horario.SELECT(oid);
            else 
                criteria.AddOidSearch(oid);

            Horario.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Horario>(criteria);
        }

        public static Horario Get(long oid) {return Get(oid, true); }

        /// <summary>
        /// Devuelve un horario con las sesiones ordenadas 
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        //public static Horario GetSesionesOrdenadas(long oid)
        //{
        //    Horario item = Get(oid);

        //    DateTime dia = item.FechaInicial;
        //    DateTime hora = DateTime.Parse("15:45");
        //    Sesions sesiones = Sesions.NewChildList();

        //    for (int i = 0; i < 10; i++)
        //    {
        //        foreach (Sesion info in item.Sesions)
        //        {
        //            if (dia.Date.Equals(info.Fecha.Date) && hora.TimeOfDay.Equals(info.Hora.TimeOfDay))
        //                sesiones.Add(info);
        //        }

        //        if (i % 2 == 1)
        //        {
        //            dia = dia.AddDays(1);
        //            hora = DateTime.Parse("15:45");
        //        }
        //        else hora = DateTime.Parse("18:45");
        //    }

        //    item.Sesions = sesiones;
        //    return item;
        //}

        public static Horario Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Horario.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Horario>(criteria);
        }

        /// <summary>
        /// Borrado inmediato, no cabe "undo"
        /// (La función debe ser "estática")
        /// </summary>
        /// <param name="oid"></param>
        public static void Delete(long oid)
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            DataPortal.Delete(new CriteriaCs(oid));
        }

        /// <summary>
        /// Elimina todas los Horarios
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Horario.OpenSession();
            ISession sess = Horario.Session(sessCode);
            ITransaction trans = Horario.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Horario");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Horario.CloseSession(sessCode);
            }
        }

        public override Horario Save()
        {
            // Por interfaz Root/Child
            if (IsChild) throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);

            if (IsDeleted && !CanDeleteObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            else if (IsNew && !CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            else if (!CanEditObject())
            {
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            }

            try
            {
                ValidationRules.CheckRules();

                base.Save();

                _sesiones.Update(this);
                _asistencias.Update(this);

                if (!SharedTransaction) Transaction().Commit();
                return this;
            }
            catch (Exception ex)
            {
                if (!SharedTransaction) if (!SharedTransaction && Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
                return this;
            }
            finally
            {
                if (!SharedTransaction)
                {
                    if (CloseSessions && (this.IsNew || Transaction().WasCommitted)) CloseSession();
                    else BeginTransaction();
                }
            }
        }

        #endregion

        #region Child Factory Methods

        private Horario(Horario source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Horario(IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(reader);
        }

        public static Horario NewChild(PlanEstudios parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Horario obj = new Horario();
            obj.OidPlan = parent.Oid;
            return obj;
        }

        //public static Horario NewChild(Promocion parent)
        //{
        //    if (!CanAddObject())
        //        throw new System.Security.SecurityException(
        //            moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

        //    Horario obj = new Horario();
        //    obj.OidPromocion = parent.Oid;
        //    return obj;
        //}

        internal static Horario GetChild(Horario source)
        {
            return new Horario(source);
        }

        internal static Horario GetChild(IDataReader reader, bool childs)
        {
            return new Horario(reader, childs);
        }


        internal static Horario GetChild(IDataReader reader)
        {
            return GetChild(reader, true);
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


        #endregion

        #region Common Data Access

        [RunLocal()]
        private void DataPortal_Create(CriteriaCs criteria)
        {
            Random r = new Random();
            Oid = (long)r.Next();
        }

        #endregion

        #region Child Data Access

        private void Fetch(Horario source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                CriteriaEx criteria = Sesion.GetCriteria(Session());
                criteria.AddEq("OidHorario", this.Oid);
                _sesiones = Sesions.GetChildList(criteria.List<Sesion>());

                criteria = ParteAsistencia.GetCriteria(Session());
                criteria.AddEq("OidHorario", this.Oid);
                _asistencias = ParteAsistencias.GetChildList(criteria.List<ParteAsistencia>());

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        private void Fetch(IDataReader source)
        {
            try
            {
                _base.CopyValues(source);

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Insert(PlanEstudios parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidPlan = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);

                _sesiones.Update(this);
                _asistencias.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(PlanEstudios parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            //Debe obtener la sesion del padre pq el objeto es padre a su vez
            SessionCode = parent.SessionCode;

            OidPlan = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                HorarioRecord obj = parent.Session().Get<HorarioRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                _sesiones.Update(this);
                _asistencias.Update(this);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }


        internal void DeleteSelf(PlanEstudios parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                SessionCode = parent.SessionCode;
                Session().Delete(Session().Get<HorarioRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        //internal void Insert(Promocion parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    //Debe obtener la sesion del padre pq el objeto es padre a su vez
        //    SessionCode = parent.SessionCode;

        //    _oid_promocion = parent.Oid;

        //    try
        //    {
        //        ValidationRules.CheckRules();

        //        if (!IsValid)
        //            throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

        //        parent.Session().Save(this);

        //        _sesiones.Update(this);
        //        _asistencias.Update(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkOld();
        //}

        //internal void Update(Promocion parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    //Debe obtener la sesion del padre pq el objeto es padre a su vez
        //    SessionCode = parent.SessionCode;

        //    _oid_promocion = parent.Oid;

        //    try
        //    {
        //        ValidationRules.CheckRules();

        //        if (!IsValid)
        //            throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

        //        Horario obj = parent.Session().Get<Horario>(Oid);
        //        obj.CopyValues(this);
        //        parent.Session().Update(obj);

        //        _sesiones.Update(this);
        //        _asistencias.Update(this);
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkOld();
        //}


        //internal void DeleteSelf(Promocion parent)
        //{
        //    // if we're not dirty then don't update the database
        //    if (!this.IsDirty) return;

        //    // if we're new then don't update the database
        //    if (this.IsNew) return;

        //    try
        //    {
        //        SessionCode = parent.SessionCode;
        //        Session().Delete(Session().Get<Horario>(Oid));
        //    }
        //    catch (Exception ex)
        //    {
        //        iQExceptionHandler.TreatException(ex);
        //    }

        //    MarkNew();
        //}

        #endregion

        #region Root Data Access

        // called to retrieve data from the database
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            try
            {
                SessionCode = criteria.SessionCode;

                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {
                    Horario.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        Sesion.DoLOCK(Session());
                        string query = Sesions.SELECT_BY_HORARIO(Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _sesiones = Sesions.GetChildList(reader);

                        ParteAsistencia.DoLOCK(Session());
                        query = ParteAsistencias.SELECT_BY_HORARIO(Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _asistencias = ParteAsistencias.GetChildList(criteria.SessionCode, reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((HorarioRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<HorarioRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        criteria = Sesion.GetCriteria(Session());
                        criteria.AddEq("OidHorario", this.Oid);
                        _sesiones = Sesions.GetChildList(criteria.List<Sesion>());

                        criteria = ParteAsistencia.GetCriteria(Session());
                        criteria.AddEq("OidHorario", this.Oid);
                        _asistencias = ParteAsistencias.GetChildList(criteria.List<ParteAsistencia>());
                    }
                }
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Insert()
        {
            try
            {
                SessionCode = OpenSession();
                BeginTransaction();
                Session().Save(this.Base.Record);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Update()
        {
            if (IsDirty)
            {
                try
                {
                    HorarioRecord obj = Session().Get<HorarioRecord>(Oid);
                    obj.CopyValues(this.Base.Record);
                    Session().Update(obj);
                }
                catch (Exception ex)
                {
                    iQExceptionHandler.TreatException(ex);
                }
            }
        }

        // deferred deletion
        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new CriteriaCs(Oid));
        }

        // inmediate deletion
        [Transactional(TransactionalTypes.Manual)]
        private void DataPortal_Delete(CriteriaCs criterio)
        {
            try
            {
                //Iniciamos la conexion y la transaccion
                SessionCode = OpenSession();
                BeginTransaction();

                CriteriaEx criteria = GetCriteria();
                criteria.AddOidSearch(criterio.Oid);

                // Obtenemos el objeto
                HorarioRecord obj = (HorarioRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<HorarioRecord>(obj.Oid));

                Transaction().Commit();
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                CloseSession();
            }
        }

        #endregion

        #region Commands

        //public virtual bool GeneraAlbaranes(ClaseTeoricaList teoricas,
        //                            List<ClasePracticaList> practicas,
        //                            ClaseExtraList extras)
        //{
        //    VariableList lista = VariableList.GetList();
        
        //    VariableInfo serie = lista.GetItem(ModuleControler.GetInstruccionSerieVariableName());

        //    VariableInfo v_producto = lista.GetItem(ModuleControler.GetInstruccionProductoVariableName());
        //    ProductoInfo producto = ProductoInfo.Get(Convert.ToInt64(v_producto.Value), false);

        //    AlbaranProveedorList albaranes = AlbaranProveedorList.GetListByProducto(true, Convert.ToInt64(v_producto.Value));

        //    List<string> practicas_generadas = new List<string>();
        //    List<AlbaranProveedor> lista_save = new List<AlbaranProveedor>();

        //    foreach (Sesion sesion in Sesions)
        //    {
        //        if (sesion.Estado == 3) //sesión confirmada
        //        {
        //            string concepto_factura = string.Empty;

        //            concepto_factura = "CLASE: ";

        //            if (sesion.OidClaseTeorica != 0)
        //                concepto_factura += teoricas.GetItem(sesion.OidClaseTeorica).Alias;
        //            if (sesion.OidClasePractica != 0)
        //            {
        //                string alias_practica = practicas[(int)sesion.Grupo].GetItem(sesion.OidClasePractica).Alias + " G" + sesion.Grupo.ToString();
        //                if (!practicas_generadas.Contains(alias_practica))
        //                {
        //                    concepto_factura += alias_practica;
        //                    practicas_generadas.Add(alias_practica);
        //                }
        //                else
        //                    continue;
        //            }
        //            if (sesion.OidClaseExtra != 0)
        //                concepto_factura += extras.GetItem(sesion.OidClaseExtra).Alias;

        //            concepto_factura += " DÍA: " + sesion.Fecha.ToShortDateString() + " HORA: " + sesion.Hora.ToShortTimeString();
                    
        //            Concepto_Parte Concepto_Parte = null;

        //            if (sesion.Conceptos != null && sesion.Conceptos.Count > 0)
        //            {
        //                if (sesion.Conceptos.Count > 1)
        //                    return false;

        //                Concepto_Parte = sesion.Conceptos[0];
        //                foreach (AlbaranProveedorInfo albaran in albaranes)
        //                {
        //                    foreach (ConceptoAlbaranProveedorInfo concepto in albaran.ConceptoAlbaranes)
        //                    {
        //                        if (concepto.Oid == Concepto_Parte.OidConcepto)
        //                        {
        //                            if (albaran.Facturado)
        //                                return false;
        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //            else
        //                Concepto_Parte = sesion.Conceptos.AddNew();

        //            AlbaranProveedor nuevo_albaran = null;
        //            int index = 0;
        //            foreach (AlbaranProveedorInfo albaran in albaranes)
        //            {
        //                if (albaran.OidAcreedor == sesion.OidProfesor
        //                    && albaran.TipoAcreedor == (long)ETipoAcreedor.Instructor
        //                    && albaran.Fecha.Month == sesion.Fecha.Month
        //                    && !albaran.Facturado)
        //                {
        //                    foreach (AlbaranProveedor item in lista_save)
        //                    {
        //                        if (item.OidAcreedor == sesion.OidProfesor
        //                            && item.Fecha.Month == sesion.Fecha.Month)
        //                        {
        //                            nuevo_albaran = item;
        //                            break;
        //                        }
        //                    }
        //                    if (nuevo_albaran == null)
        //                        nuevo_albaran = AlbaranProveedor.Get(albaran.Oid, ETipoAcreedor.Instructor);

        //                    break;
        //                }
        //                index++;
        //            }

        //            if (nuevo_albaran == null)
        //            {
        //                nuevo_albaran = AlbaranProveedor.New();
        //                nuevo_albaran.ETipoAcreedor = ETipoAcreedor.Instructor;
        //                nuevo_albaran.OidAcreedor = sesion.OidProfesor;
        //                nuevo_albaran.OidSerie = Convert.ToInt64(serie.Value);
        //                nuevo_albaran.Fecha = sesion.Fecha;
        //                while (nuevo_albaran.Fecha.Day != DateTime.DaysInMonth(nuevo_albaran.Fecha.Year, nuevo_albaran.Fecha.Month))
        //                    nuevo_albaran.Fecha = nuevo_albaran.Fecha.AddDays(1);
        //            }

        //            ConceptoAlbaranProveedor nuevo_concepto = nuevo_albaran.ConceptoAlbaranes.GetItem(Concepto_Parte.OidConcepto);
        //            if (nuevo_concepto == null)
        //                nuevo_concepto = nuevo_albaran.ConceptoAlbaranes.AddNew();

        //            if (sesion.OidClasePractica != 0)
        //                nuevo_concepto.Cantidad = 5;
        //            else
        //                nuevo_concepto.Cantidad = 1;
        //            nuevo_concepto.CopyFrom(producto);
        //            nuevo_concepto.Concepto += " " + concepto_factura;
        //            nuevo_concepto.Precio = nuevo_concepto.Gastos;
        //            nuevo_concepto.CalculaTotal();
        //            nuevo_albaran.CalculaTotal();

        //            if (!lista_save.Contains(nuevo_albaran))
        //                lista_save.Add(nuevo_albaran);

        //            AlbaranProveedorInfo nuevo_info = nuevo_albaran.GetInfo(true);

        //            if (albaranes.GetItem(nuevo_albaran.Oid) != null)
        //                albaranes.RemoveItem(nuevo_info.Oid);
        //            albaranes.AddItem(nuevo_info);
        //            //}
        //        }
        //        else
        //        {
        //            //la sesión ya no está confirmada pero tiene conceptos asociados que habrá
        //            //que eliminar
        //            if (sesion.Conceptos != null && sesion.Conceptos.Count > 0)
        //            {
        //                if (sesion.Conceptos.Count > 1)
        //                    return false;

        //                AlbaranProveedor nuevo_albaran = null;
        //                foreach (AlbaranProveedor albaran in lista_save)
        //                {
        //                    foreach (ConceptoAlbaranProveedor concepto in albaran.ConceptoAlbaranes)
        //                    {
        //                        if (concepto.Oid == sesion.Conceptos[0].OidConcepto)
        //                        {
        //                            albaran.ConceptoAlbaranes.Remove(concepto);
        //                            nuevo_albaran = albaran;
        //                            nuevo_albaran.CalculaTotal();
        //                            break;
        //                        }
        //                    }
        //                }
        //                if (nuevo_albaran == null)
        //                {
        //                    foreach (AlbaranProveedorInfo albaran in albaranes)
        //                    {
        //                        foreach (ConceptoAlbaranProveedorInfo info in albaran.ConceptoAlbaranes)
        //                        {
        //                            if (info.Oid == sesion.Conceptos[0].OidConcepto)
        //                            {
        //                                if (albaran.Facturado)
        //                                    return false;
        //                                else
        //                                {
        //                                    nuevo_albaran = AlbaranProveedor.Get(albaran.Oid, ETipoAcreedor.Instructor, true);
        //                                    ConceptoAlbaranProveedor concepto = nuevo_albaran.ConceptoAlbaranes.GetItem(info.Oid);
                    
        //                                    nuevo_albaran.ConceptoAlbaranes.Remove(concepto);
        //                                    nuevo_albaran.CalculaTotal();
        //                                }
        //                                break;
        //                            }
        //                        }
        //                    }
        //                }

        //                if (!lista_save.Contains(nuevo_albaran))
        //                    lista_save.Add(nuevo_albaran);

        //                sesion.Conceptos[0].Delete();

        //                AlbaranProveedorInfo nuevo_info = nuevo_albaran.GetInfo(true);

        //                if (albaranes.GetItem(nuevo_albaran.Oid) != null)
        //                    albaranes.RemoveItem(nuevo_info.Oid);
        //                albaranes.AddItem(nuevo_info);
        //            }
        //        }
        //    }

        //    for (int i = 0; i < lista_save.Count; i++)
        //    {
        //        lista_save[i] = lista_save[i].Save();
        //        lista_save[i].CloseSession();
        //    }

        //    //al hacer el save se abre una sesion que no encuentro otra forma de cerrar :S
        //    if (nHManager.Instance.Sessions[nHManager.Instance.Sessions.Count-1] != null
        //        && nHManager.Instance.Sessions.Count > 1)
        //        nHManager.Instance.CloseSession(nHManager.Instance.Sessions.Count - 1);

        //    practicas_generadas = new List<string>();

        //    foreach (Sesion sesion in this.Sesions)
        //    {
        //        if (sesion.Estado != 3)
        //            continue;

        //        string concepto_factura = string.Empty;

        //        concepto_factura = "CLASE: ";

        //        if (sesion.OidClaseTeorica != 0)
        //            concepto_factura += teoricas.GetItem(sesion.OidClaseTeorica).Alias;
        //        if (sesion.OidClasePractica != 0)
        //        {
        //            string alias_practica = practicas[(int)sesion.Grupo].GetItem(sesion.OidClasePractica).Alias + " G" + sesion.Grupo.ToString();
        //            if (!practicas_generadas.Contains(alias_practica))
        //            {
        //                concepto_factura += alias_practica;
        //                practicas_generadas.Add(alias_practica);
        //            }
        //            else
        //                continue;
        //        }
        //        if (sesion.OidClaseExtra != 0)
        //            concepto_factura += extras.GetItem(sesion.OidClaseExtra).Alias;

        //        concepto_factura += " DÍA: " + sesion.Fecha.ToShortDateString() + " HORA: " + sesion.Hora.ToShortTimeString();

        //        foreach (AlbaranProveedor albaran in lista_save)
        //        {
        //            foreach (ConceptoAlbaranProveedor concepto in albaran.ConceptoAlbaranes)
        //            {
        //                if (concepto.Concepto.Contains(concepto_factura))
        //                {
        //                    if (sesion.Conceptos[0].OidConcepto != concepto.Oid)
        //                        sesion.Conceptos[0].OidConcepto = concepto.Oid;                        
        //                }
        //            }
        //        }
        //    }

        //    return true;
        //}

        public virtual void CopiaConfiguracion(PromocionInfo promocion)
        {
            H8AM = promocion.H8AM;
            H0 = promocion.H0;
            H1 = promocion.H1;
            H2 = promocion.H2;
            H3 = promocion.H3;
            H4 = promocion.H4;
            H5 = promocion.H5;
            H6 = promocion.H6;
            H7 = promocion.H7;
            H8 = promocion.H8;
            H9 = promocion.H9;
            H10 = promocion.H10;
            H11 = promocion.H11;
            H12 = promocion.H12;
            HS0 = promocion.HS0;
            HS1 = promocion.HS1;
            HS2 = promocion.HS2;
            HS3 = promocion.HS3;
            HS4 = promocion.HS4;
        }

        public static long GetHorario(long oid_plan, long oid_promocion)
        {
            return GetHorario(oid_plan, oid_promocion, DateTime.MinValue);
        }

        public static long GetHorario(long oid_plan, long oid_promocion, DateTime fecha_inicial)
        {
            string query = SELECT_BY_PLAN_BY_PROMOCION(oid_plan, oid_promocion, fecha_inicial);
            int sesion = Horario.OpenSession();

            IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

            while (reader.Read())
            {
                string fecha = reader["FECHA_INICIAL"].ToString();
                DateTime item = DateTime.Parse(fecha);
                if (item.ToShortDateString() == fecha_inicial.AddDays(-7).ToShortDateString())
                    return (long)reader["OID"];
            }

            CloseSession(sesion);

            return 0;
        }

        /// <summary>
        /// Función que comprueba si existe un horario para una promoción y fecha determinadas,
        /// evitando así que se intente generar otro
        /// </summary>
        /// <param name="oid_plan"></param>
        /// <param name="oid_promocion"></param>
        /// <param name="fecha_inicial"></param>
        /// <returns></returns>
        public static bool ExisteHorario(long oid_plan, long oid_promocion, DateTime fecha_inicial)
        {
            string query = SELECT_BY_PLAN_BY_PROMOCION(oid_plan, oid_promocion, fecha_inicial);
            int sesion = Horario.OpenSession();

            IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

            while (reader.Read())
            {
                string fecha = reader["FECHA_INICIAL"].ToString();
                DateTime item = DateTime.Parse(fecha);
                if (item.ToShortDateString() == fecha_inicial.ToShortDateString())
                    return true;
            }

            CloseSession(sesion);

            return false;
        }

        public virtual ListaSesiones SetSesionesActivas(ListaSesiones _lista_sesiones)
        {
            if (_lista_sesiones != null)
            {
                //de lunes a viernes a 1ª hora
                _lista_sesiones[0].Activa = this.H8AM;
                _lista_sesiones[14].Activa = this.H8AM;
                _lista_sesiones[28].Activa = this.H8AM;
                _lista_sesiones[42].Activa = this.H8AM;
                _lista_sesiones[56].Activa = this.H8AM;

                //de lunes a viernes a 2ª hora
                _lista_sesiones[1].Activa = this.H0;
                _lista_sesiones[15].Activa = this.H0;
                _lista_sesiones[29].Activa = this.H0;
                _lista_sesiones[43].Activa = this.H0;
                _lista_sesiones[57].Activa = this.H0;


                //de lunes a viernes a 3ª hora
                _lista_sesiones[2].Activa = this.H1;
                _lista_sesiones[16].Activa = this.H1;
                _lista_sesiones[30].Activa = this.H1;
                _lista_sesiones[44].Activa = this.H1;
                _lista_sesiones[58].Activa = this.H1;

                //de lunes a viernes a 4ª hora
                _lista_sesiones[3].Activa = this.H2;
                _lista_sesiones[17].Activa = this.H2;
                _lista_sesiones[31].Activa = this.H2;
                _lista_sesiones[45].Activa = this.H2;
                _lista_sesiones[59].Activa = this.H2;


                //de lunes a viernes a 5ª hora
                _lista_sesiones[4].Activa = this.H3;
                _lista_sesiones[18].Activa = this.H3;
                _lista_sesiones[32].Activa = this.H3;
                _lista_sesiones[46].Activa = this.H3;
                _lista_sesiones[60].Activa = this.H3;

                //de lunes a viernes a 6ª hora
                _lista_sesiones[5].Activa = this.H4;
                _lista_sesiones[19].Activa = this.H4;
                _lista_sesiones[33].Activa = this.H4;
                _lista_sesiones[47].Activa = this.H4;
                _lista_sesiones[61].Activa = this.H4;


                //de lunes a viernes a 7ª hora
                _lista_sesiones[6].Activa = this.H5;
                _lista_sesiones[20].Activa = this.H5;
                _lista_sesiones[34].Activa = this.H5;
                _lista_sesiones[48].Activa = this.H5;
                _lista_sesiones[62].Activa = this.H5;

                //de lunes a viernes a 8ª hora
                _lista_sesiones[7].Activa = this.H6;
                _lista_sesiones[21].Activa = this.H6;
                _lista_sesiones[35].Activa = this.H6;
                _lista_sesiones[49].Activa = this.H6;
                _lista_sesiones[63].Activa = this.H6;


                //de lunes a viernes a 9ª hora
                _lista_sesiones[8].Activa = this.H7;
                _lista_sesiones[22].Activa = this.H7;
                _lista_sesiones[36].Activa = this.H7;
                _lista_sesiones[50].Activa = this.H7;
                _lista_sesiones[64].Activa = this.H7;

                //de lunes a viernes a 10ª hora
                _lista_sesiones[9].Activa = this.H8;
                _lista_sesiones[23].Activa = this.H8;
                _lista_sesiones[37].Activa = this.H8;
                _lista_sesiones[51].Activa = this.H8;
                _lista_sesiones[65].Activa = this.H8;


                //de lunes a viernes a 11ª hora
                _lista_sesiones[10].Activa = this.H9;
                _lista_sesiones[24].Activa = this.H9;
                _lista_sesiones[38].Activa = this.H9;
                _lista_sesiones[52].Activa = this.H9;
                _lista_sesiones[66].Activa = this.H9;

                //de lunes a viernes a 12ª hora
                _lista_sesiones[11].Activa = this.H10;
                _lista_sesiones[25].Activa = this.H10;
                _lista_sesiones[39].Activa = this.H10;
                _lista_sesiones[53].Activa = this.H10;
                _lista_sesiones[67].Activa = this.H10;

                //de lunes a viernes a 13ª hora
                _lista_sesiones[12].Activa = this.H11;
                _lista_sesiones[26].Activa = this.H11;
                _lista_sesiones[40].Activa = this.H11;
                _lista_sesiones[54].Activa = this.H11;
                _lista_sesiones[68].Activa = this.H11;

                //de lunes a viernes a 14ª hora
                _lista_sesiones[13].Activa = this.H12;
                _lista_sesiones[27].Activa = this.H12;
                _lista_sesiones[41].Activa = this.H12;
                _lista_sesiones[55].Activa = this.H12;
                _lista_sesiones[69].Activa = this.H12;

                //SÁBADO
                _lista_sesiones[70].Activa = this.HS0;
                _lista_sesiones[71].Activa = this.HS1;
                _lista_sesiones[72].Activa = this.HS2;
                _lista_sesiones[73].Activa = this.HS3;
                _lista_sesiones[74].Activa = this.HS4;

                SortedBindingList<FestivoInfo> festivos = FestivoList.GetList(FechaInicial, FechaFinal);
                //Se marcar como libres los días establecidos como no lectivos
                if (festivos != null && festivos.Count > 0)
                {
                    foreach (SesionAuxiliar aux in _lista_sesiones)
                    {
                        if (aux.Activa)
                        {
                            foreach (FestivoInfo festivo in festivos)
                            {
                                if (aux.Fecha.Date >= festivo.FechaInicio.Date
                                    && aux.Fecha.Date <= festivo.FechaFin.Date)
                                {
                                    aux.Activa = false;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < 75; i++)
            {
                if (!_lista_sesiones[i].Activa && _lista_sesiones[i].Estado == 1)
                {
                    _lista_sesiones[i].Titulo = "LIBRE";
                    _lista_sesiones[i].Estado = 2;
                    _lista_sesiones[i].OidClaseTeorica = -1;
                }
            }

            return _lista_sesiones;
        }

        /// <summary>
        /// Rellena una lista de sublistas que contienen los índices de comienzo de las clases de determinada duración
        /// lista[0] : 1 hora
        /// lista[1] : 2 horas
        /// lista[2] : 3 horas
        /// </summary>
        /// <returns></returns>
        public virtual List<List<long>> RellenaHorasSemana()
        {
            List<bool> horas_lv = new List<bool>();

            horas_lv.Add(this.H8AM);
            horas_lv.Add(this.H0);
            horas_lv.Add(this.H1);
            horas_lv.Add(this.H2);
            horas_lv.Add(this.H3);
            horas_lv.Add(this.H4);
            horas_lv.Add(this.H5);
            horas_lv.Add(this.H6);
            horas_lv.Add(this.H7);
            horas_lv.Add(this.H8);
            horas_lv.Add(this.H9);
            horas_lv.Add(this.H10);
            horas_lv.Add(this.H11);
            horas_lv.Add(this.H12);

            PromocionInfo promo = PromocionInfo.Get(this.OidPromocion, true);

            List<List<long>> lista = new List<List<long>>();

            if (moleQule.Library.Instruction.Promocion.CompruebaConfiguracion(horas_lv, promo.Sesiones))
            {
                Dictionary<string, int> indices = new Dictionary<string, int>();

                DateTime hora = DateTime.Parse("8:00");

                for (int i = 0; i < 14; i++)
                {
                    lista.Add(new List<long>());
                    indices.Add(hora.ToShortTimeString(), i);
                    hora = hora.AddHours(1);
                }

                foreach (Sesion_PromocionInfo item in promo.Sesiones)
                {
                    int indice = -1;
                    if (indices.TryGetValue(item.HoraInicio.ToShortTimeString(), out indice))
                        lista[(int)item.NHoras - 1].Add(indice);
                }

                return lista;
            }
            else
            {
                horas_lv.Add(false);


                List<bool> horas_s = new List<bool>();

                horas_s.Add(this.HS0);
                horas_s.Add(this.HS1);
                horas_s.Add(this.HS2);
                horas_s.Add(this.HS3);
                horas_s.Add(this.HS4);
                horas_s.Add(false);

                List<long> lista_1 = new List<long>();
                List<long> lista_2 = new List<long>();
                List<long> lista_3 = new List<long>();

                int inicio = 0;
                int total = 0;

                for (int i = 0; i < 14; i++)
                {
                    if (horas_lv[i])
                    {
                        if (total == 0)
                            inicio = i;
                        total++;
                    }
                    else
                    {
                        if (total > 1)
                        {
                            while (total > 0)
                            {
                                if (total % 3 == 0)
                                {
                                    while (total > 0)
                                    {
                                        lista_3.Add(inicio);
                                        inicio += 3;
                                        total -= 3;
                                    }
                                }
                                else
                                {
                                    if ((total - 3) > 1)
                                    {
                                        lista_3.Add(inicio);
                                        inicio += 3;
                                        total -= 3;
                                    }
                                    else
                                    {
                                        lista_2.Add(inicio);
                                        inicio += 2;
                                        total -= 2;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (total > 0)
                                lista_1.Add(inicio);
                        }
                        total = 0;
                    }
                }

                total = 0;
                inicio = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (horas_s[i])
                    {
                        if (total == 0)
                            inicio = i;
                        total++;
                    }
                    else
                    {
                        if (total > 1)
                        {
                            while (total > 0)
                            {
                                if (total % 3 == 0)
                                {
                                    while (total > 0)
                                    {
                                        lista_3.Add(inicio + 70);
                                        inicio += 3;
                                        total -= 3;
                                    }
                                }
                                else
                                {
                                    lista_2.Add(inicio + 70);
                                    inicio += 2;
                                    total -= 2;
                                }
                            }
                        }
                        else
                        {
                            if (total > 0)
                                lista_1.Add(inicio + 70);
                        }
                        total = 0;
                    }
                }

                lista.Add(lista_1);
                lista.Add(lista_2);
                lista.Add(lista_3);

                return lista;
            }
        }

        //public static bool PosibleAsignar(Clase cl, List<Clase> lista)
        //{
        //    //hay que comprobar que no haya clases prioritarias sin colocar
        //    //si existen apartados de un submódulo previos sin programar
        //    if (cl.OrdenTerciario != 1)
        //    {
        //        foreach (Clase aux in lista)
        //        {
        //            if (aux.OrdenTerciario < cl.OrdenTerciario &&
        //                aux.OidSubmodulo == cl.OidSubmodulo &&
        //                aux.Estado == 1)
        //                return false;
        //        }
        //    }
        //    //si existen submódulos previos del mismo módulo sin programar
        //    if (cl.OrdenSecundario != 1)
        //    {
        //        foreach (Clase aux in lista)
        //        {
        //            if (aux.OrdenSecundario < cl.OrdenSecundario &&
        //                aux.OidModulo == cl.OidModulo &&
        //                aux.Estado == 1)
        //                return false;
        //        }
        //    }
        //    //si existen módulos con mayor prioridad sin programar
        //    if (cl.OrdenPrimario != 1)
        //    {
        //        foreach (Clase aux in lista)
        //        {
        //            if (aux.OrdenPrimario < cl.OrdenPrimario &&
        //                aux.Estado == 1)
        //                return false;
        //        }
        //    }

        //    return true;
        //}

        /// <summary>
        /// Comprueba que sea posible asignar una clase en función de las prioridades
        /// establecidas en el plan de estudios
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        //public static bool PosibleAsignar(Clase cl, ClaseTeoricaList lista)
        //{
        //    //hay que comprobar que no haya clases prioritarias sin colocar
        //    //si existen apartados de un submódulo previos sin programar
        //    if (cl.OrdenTerciario != 1)
        //    {
        //        foreach (ClaseTeoricaInfo aux in lista)
        //        {
        //            if (aux.OrdenTerciario < cl.OrdenTerciario &&
        //                aux.OidSubmodulo == cl.OidSubmodulo &&
        //                aux.Estado == 1)
        //                return false;
        //        }
        //    }
        //    //si existen submódulos previos del mismo módulo sin programar
        //    if (cl.OrdenSecundario != 1)
        //    {
        //        foreach (ClaseTeoricaInfo aux in lista)
        //        {
        //            if (aux.OrdenSecundario < cl.OrdenSecundario &&
        //                aux.OrdenPrimario == cl.OrdenPrimario &&
        //                aux.OidModulo == aux.OidModulo &&
        //                aux.Estado == 1)
        //                return false;
        //        }
        //    }
        //    //si existen módulos con mayor prioridad sin programar
        //    if (cl.OrdenPrimario != 1)
        //    {
        //        foreach (ClaseTeoricaInfo aux in lista)
        //        {
        //            if (aux.OrdenPrimario < cl.OrdenPrimario &&
        //                aux.Estado == 1)
        //                return false;
        //        }
        //    }

        //    return true;
        //}

        /// <summary>
        /// Comprueba que sea posible asignar una clase teórica en función de las prioridades
        /// establecidas en el plan de estudios
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static bool PosibleAsignar(ClaseTeoricaInfo cl, ClaseTeoricaList lista)
        {
            //hay que comprobar que no haya clases prioritarias sin colocar
            //si existen apartados de un submódulo previos sin programar
            if (cl.OrdenTerciario != 1)
            {
                foreach (ClaseTeoricaInfo aux in lista)
                {
                    if (aux.OrdenTerciario < cl.OrdenTerciario &&
                        aux.OidSubmodulo == cl.OidSubmodulo &&
                        aux.Estado == 1)
                        return false;
                }
            }
            //si existen submódulos previos del mismo módulo sin programar
            if (cl.OrdenSecundario != 1)
            {
                foreach (ClaseTeoricaInfo aux in lista)
                {
                    if (aux.OrdenSecundario < cl.OrdenSecundario &&
                        aux.OrdenPrimario == cl.OrdenPrimario &&
                        aux.OidModulo == cl.OidModulo &&
                        aux.Estado == 1)
                        return false;
                }
            }
            //si existen módulos con mayor prioridad sin programar
            if (cl.OrdenPrimario != 1)
            {
                foreach (ClaseTeoricaInfo aux in lista)
                {
                    if (aux.OrdenPrimario < cl.OrdenPrimario &&
                        aux.Estado == 1)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Comprueba que sea posible asignar una clase práctica en función de las prioridades
        /// establecidas en el plan de estudios
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static bool PosibleAsignar(ClasePracticaInfo cl, List<ClasePracticaList> lista)
        {
            //hay que comprobar que no haya clases prioritarias sin colocar
            //si existen apartados de un submódulo previos sin programar
            if (cl.OrdenTerciario != 1)
            {
                foreach (ClasePracticaList item in lista)
                {
                    foreach (ClasePracticaInfo aux in item)
                    {
                        if (aux.OrdenTerciario < cl.OrdenTerciario &&
                            aux.OidSubmodulo == cl.OidSubmodulo &&
                            aux.Estado == 1)
                            return false;
                    }
                }
            }
            //si existen submódulos previos del mismo módulo sin programar
            if (cl.OrdenSecundario != 1)
            {
                foreach (ClasePracticaList item in lista)
                {
                    foreach (ClasePracticaInfo aux in item)
                    {
                        if (aux.OrdenSecundario < cl.OrdenSecundario &&
                            aux.OidModulo == cl.OidModulo &&
                            aux.Estado == 1)
                            return false;
                    }
                }
            }
            //si existen módulos con mayor prioridad sin programar
            if (cl.OrdenPrimario != 1)
            {
                foreach (ClasePracticaList item in lista)
                {
                    foreach (ClasePracticaInfo aux in item)
                    {
                        if (aux.OrdenPrimario < cl.OrdenPrimario &&
                            aux.Estado == 1)
                            return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Comprueba que sea posible asignar una clase práctica en función de las prioridades
        /// establecidas en el plan de estudios y en función de las clases teóricas impartidas 
        /// hasta el momento
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static bool PosibleAsignarModulo(ClasePracticaInfo cl, ClaseTeoricaList lista)
        {
            //hay que comprobar que no haya clases prioritarias sin colocar
            //si existen módulos con mayor prioridad sin programar
            if (cl.OrdenPrimario != 1)
            {
                foreach (ClaseTeoricaInfo aux in lista)
                {
                    if (aux.OrdenPrimario < cl.OrdenPrimario &&
                        aux.Estado == 1)
                        return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Comprueba que sea posible asignar una clase práctica en función de las prioridades
        /// establecidas en el plan de estudios y en función de las clases teóricas impartidas 
        /// hasta el momento
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static bool PosibleAsignarSubodulo(ClasePracticaInfo cl, ClaseTeoricaList lista)
        {
            //hay que comprobar que no haya clases prioritarias sin colocar
            //si existen submódulos previos del mismo módulo sin programar
            if (cl.OrdenSecundario != 1)
            {
                foreach (ClaseTeoricaInfo aux in lista)
                {
                    if (aux.OrdenSecundario < cl.OrdenSecundario &&
                        aux.OidModulo == cl.OidModulo &&
                        aux.Estado == 1)
                        return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Comprueba que sea posible asignar una clase práctica en función de las prioridades
        /// establecidas en el plan de estudios y en función de las clases teóricas impartidas 
        /// hasta el momento
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="lista"></param>
        /// <returns></returns>
        public static bool PosibleAsignarClase(ClasePracticaInfo cl, ClaseTeoricaList lista)
        {
            //hay que comprobar que no haya clases prioritarias sin colocar
            //si existen apartados de un submódulo previos sin programar
            if (cl.OrdenTerciario != 1)
            {
                foreach (ClaseTeoricaInfo aux in lista)
                {
                    if (aux.OrdenTerciario < cl.OrdenTerciario &&
                        aux.OidSubmodulo == cl.OidSubmodulo &&
                        aux.Estado == 1)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Función que comprueba si es posible realizar un intercambio de una sesión que contiene una
        /// clase teórica ya asignada
        /// </summary>
        /// <param name="candidata"></param>
        /// <param name="asignada"></param>
        /// <param name="prof"></param>
        /// <param name="lista_sesiones"></param>
        /// <param name="profesores"></param>
        /// <param name="_instructores_asignados"></param>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public static bool PosibleIntercambiar(ClaseTeoricaInfo candidata,
                                                SesionAuxiliar asignada,
                                                InstructorInfo prof,
                                                ListaSesiones lista_sesiones,
                                                InstructorList profesores,
                                                List<ListaSesiones> _instructores_asignados,
                                                DateTime fecha,
                                                SortedDictionary<long, DisponibilidadInfo> disponibilidades)
        {
            if (asignada.Forzada) return false;
            //hay que comprobar que no haya clases prioritarias sin colocar
            //si existen apartados de un submódulo previos sin programar
            if (asignada.OidClasePractica == 0)
            {
                if (candidata.OrdenPrimario > asignada.OrdenPrimario)
                    return false;
                else
                {
                    if (candidata.OidModulo == asignada.OidModulo
                        && candidata.OrdenSecundario > asignada.OrdenSecundario)
                        return false;
                    else
                    {
                        if (candidata.OidSubmodulo == asignada.OidSubmodulo
                            && candidata.OrdenTerciario > asignada.OrdenTerciario)
                            return false;
                        else
                        {
                            bool colocada = false;
                            int i = 0;
                            while (i < 10 && !colocada)
                            {
                                if (lista_sesiones[i].Estado == 1)
                                {
                                    InstructorInfo profesor = profesores.GetItem(asignada.OidProfesor);
                                    //foreach (InstructorInfo p in profesores)
                                    //{
                                    //    if (p.Oid == asignada.OidProfesor)
                                    //    {
                                    //        profesor = p;
                                    //        break;
                                    //    }
                                    //}
                                    if (profesor != null
                                        && ProfesorLibre(_instructores_asignados, i, profesor.Oid, lista_sesiones, profesores, -1, fecha,disponibilidades))
                                    {
                                        //foreach (DisponibilidadInfo disp in profesor.Disponibilidades)
                                        //{
                                        //    if (disp.FechaInicio.Date.Equals(fecha.Date) && disp.Semana[i])
                                        DisponibilidadInfo disp = null;
                                        if (disponibilidades.TryGetValue(profesor.Oid, out disp) && disp.Semana[i])
                                            //{
                                            colocada = true;
                                        //break;
                                        //}
                                        //}
                                        if (colocada) break;
                                    }
                                }
                                i++;
                            }
                            if (colocada)
                            {
                                //antes de hacer el cambio hay que comprobar las prioridades
                                int j = lista_sesiones.IndexOf(asignada);
                                lista_sesiones[i].Copia(lista_sesiones[j], true);
                                lista_sesiones[i].OidProfesor = lista_sesiones[j].OidProfesor;
                                lista_sesiones[i].Estado = 2;
                                lista_sesiones[j].AsignaClaseASesion(candidata);
                                lista_sesiones[j].OidProfesor = prof.Oid;
                                lista_sesiones[j].Estado = 2;
                                candidata.Estado = 2;
                                return true;
                            }
                        }
                    }
                }
            }
            else
            {
                int i = 0;
                bool colocada = false;
                bool segunda = false;
                //si se trata de la segunda hora del día
                if (lista_sesiones.IndexOf(asignada) % 2 != 0)
                {
                    asignada = lista_sesiones[lista_sesiones.IndexOf(asignada) - 1];
                    segunda = true;
                }
                //hay que buscar hueco para las practicas
                while (i < 10 && !colocada)
                {
                    if (lista_sesiones[i].Estado == 1 && lista_sesiones[i + 1].Estado == 1)
                    {
                        InstructorInfo profesor = profesores.GetItem(asignada.OidProfesor);
                        //foreach (InstructorInfo p in profesores)
                        //{
                        //    if (p.Oid == asignada.OidProfesor)
                        //    {
                        //        profesor = p;
                        //        break;
                        //    }
                        //}
                        if (profesor != null)
                        {
                            //foreach (DisponibilidadInfo disp in profesor.Disponibilidades)
                            //{
                            //    if (disp.FechaInicio.Date.Equals(fecha.Date))
                            DisponibilidadInfo disp = null;
                            if (disponibilidades.TryGetValue(profesor.Oid, out disp))
                            {
                                if (disp.Semana[i] && disp.Semana[i + 1])
                                    //{
                                    colocada = true;
                                //break;
                                //}
                            }
                            //}
                            if (colocada) break;
                        }
                    }
                    i += 2;
                }
                if (colocada)
                {
                    //movemos las prácticas desde donde estaban al hueco libre
                    int j = lista_sesiones.IndexOf(asignada);
                    lista_sesiones[i].Copia(lista_sesiones[j], true);
                    lista_sesiones[i + 1].Copia(lista_sesiones[j + 1], true);
                    if (segunda)
                    {
                        lista_sesiones[j].AsignaClaseASesion((ClaseTeoricaInfo)null);
                        lista_sesiones[j + 1].OidProfesor = prof.Oid;
                        lista_sesiones[j + 1].AsignaClaseASesion(candidata);
                        lista_sesiones[j + 1].Estado = 2;
                    }
                    else
                    {
                        lista_sesiones[j + 1].AsignaClaseASesion((ClaseTeoricaInfo)null);
                        lista_sesiones[j].OidProfesor = prof.Oid;
                        lista_sesiones[j].AsignaClaseASesion(candidata);
                    }
                    candidata.Estado = 2;
                    return true;
                }
            }
            return false;

        }

        public static bool ProfesorLibre(List<ListaSesiones> _instructores_asignados, int index, long oid_profesor,
                                        ListaSesiones lista_sesiones, InstructorList profesores, int act_index, DateTime fecha,
                                        SortedDictionary<long,DisponibilidadInfo> disponibilidades)
        {

            if (lista_sesiones[index].OidProfesor == oid_profesor)
                return true;

            long contador = 0;
            long clases_semanales = 0;

            InstructorInfo p = profesores.GetItem(oid_profesor);

            if (p != null)
            {
                DisponibilidadInfo disp = null;
                if (disponibilidades.TryGetValue(p.Oid,out disp))
                //foreach (DisponibilidadInfo disp in p.Disponibilidades)
                //{
                //    if (disp.FechaInicio.Date.Equals(fecha.Date))
                //    {
                        clases_semanales = disp.ClasesSemanales;
                //        break;
                //    }
                //}
            }

            //foreach (InstructorInfo p in profesores)
            //{
            //    if (p.Oid == oid_profesor)
            //    {
            //        bool salir = false;
            //        foreach (DisponibilidadInfo disp in p.Disponibilidades)
            //        {
            //            if (disp.FechaInicio.Date.Equals(fecha.Date))
            //            {
            //                clases_semanales = disp.ClasesSemanales;
            //                salir = true;
            //                break;
            //            }
            //        }
            //        if (salir) break;
            //    }
            //}

            foreach (ListaSesiones list in _instructores_asignados)
            {
                if (list[index].OidProfesor == oid_profesor)
                    return false;
                else
                {
                    //puede ser que el profesor no esté asignado directamente porque se trata de una clase práctica 
                    //pero también tenga esas horas ocupadas
                    if (list[index].OidClasePractica != 0)
                    {
                        int index_aux = 0;
                        while (index_aux + index < 75 && list[index_aux + index].OidClasePractica != 0)
                            index_aux++;
                        while (index_aux > 5)
                            index_aux -= 5;
                        int limite_inferior = index + index_aux - 5;
                        for (int i = 0; i < 5; i++)
                        {
                            if (list[limite_inferior + i].OidProfesor == oid_profesor)
                                return false;
                        }

                    }
                }

                int cont_index;

                if (index % 2 == 0)
                    cont_index = index + 1;
                else
                    cont_index = index - 1;

                if (list[index].OidClasePractica != 0 && list[cont_index].OidProfesor == oid_profesor)
                    return false;

                foreach (SesionAuxiliar aux in list)
                {
                    if (aux.OidProfesor == oid_profesor)
                        contador++;
                }
            }

            foreach (SesionAuxiliar ses in lista_sesiones)
            {
                if (ses.OidProfesor == oid_profesor && 
                    (ses.OidClaseTeorica > 0
                    || ses.OidClasePractica > 0
                    || ses.OidClaseExtra > 0))
                    contador++;
            }

            if (contador >= clases_semanales && act_index == -1)
                return false;
            else return true;
        }

        /// <summary>
        /// Función que comprueba que se pueda realizar una práctica en una sesión determinada 
        /// en función del campo Incompatible de la clase práctica
        /// </summary>
        /// <param name="lista_sesiones">sesiones del horario actual</param>
        /// <param name="_instructores_asignados">lista de horarios de la misma semana para otras promociones</param>
        /// <param name="index">índice de la sesión en la que se va a insertar la clase práctica</param>
        /// <param name="incompatible">campo Incompatible de la práctica</param>
        /// <returns></returns>
        public static bool LaboratorioLibre(ListaSesiones lista_sesiones, List<ListaSesiones> _instructores_asignados, int index, long incompatible)
        {
            //se comprueban los horarios generados para otras promociones
            foreach (ListaSesiones lista in _instructores_asignados)
            {
                for (int i = index; i < index + 5; i++)
                {
                    if (lista[i].Incompatible == incompatible)
                        return false;
                }
            }

            //también se comprueba el horario actual, por si el otro grupo tuviera una práctica
            //con el mismo valor de campo Incompatible
            for (int i = index; i < index + 5; i++)
            {
                if (lista_sesiones[i].Incompatible == incompatible)
                    return false;
            }
            return true;

        }
        
        /// <summary>
        /// Función que comprueba que se pueden intercambiar dos clases de un horario
        /// </summary>
        /// <param name="lista_sesiones">lista de las sesiones del horario actual</param>
        /// <param name="index1">índice de una de las clases que se pretende cambiar en la lista anterior</param>
        /// <param name="index2">índice de una de las clases que se pretende cambiar en la lista anterior</param>
        /// <param name="profesores">listado de profesores</param>
        /// <param name="_instructores_asignados">lista de horarios programados para la misma semana</param>
        /// <param name="fecha">fecha del horario actual</param>
        /// <returns></returns>
        public static bool IntentaIntercambio(ListaSesiones lista_sesiones, int index1, int index2, InstructorList profesores,
                                            List<ListaSesiones> _instructores_asignados, DateTime fecha, 
                                            SortedDictionary<long,DisponibilidadInfo> disponibilidades)
        {
            //se comprueba que los profesores puedan hacer el cambio, ya sea por disponibilidad o porque tengan
            //ya alguna clase asignada en otro horario de la misma semana a la misma hora
            if (profesores.EstaDisponible(lista_sesiones[index1].OidProfesor, index2, fecha)
                && profesores.EstaDisponible(lista_sesiones[index2].OidProfesor, index1, fecha)
                && Horario.ProfesorLibre(_instructores_asignados, index2, lista_sesiones[index1].OidProfesor, lista_sesiones, profesores, index1, fecha, disponibilidades)
                && Horario.ProfesorLibre(_instructores_asignados, index1, lista_sesiones[index2].OidProfesor, lista_sesiones, profesores, index2, fecha, disponibilidades))
            {
                int index_dia1 = index1; //índice de index1 en las clases de su mismo día
                while (index_dia1 > 13)
                    index_dia1 -= 14;
                int index_semana1 = index1; //día de la semana de index1
                while (index_semana1 % 14 != 0)
                    index_semana1--;
                int index_dia2 = index2;//índice de index2 en las clases de su mismo día
                while (index_dia2 > 13)
                    index_dia2 -= 14;
                int index_semana2 = index2;//día de la semana de index2
                while (index_semana2 % 14 != 0)
                    index_semana2--;

                bool no_repetido = true; //indica si ya hay clases del mismo módulo en el día
                int contador = 0;

                //bucle que comprueba que no se repitan clases del mismo módulo el mismo día
                while (contador < 14 && no_repetido && index_semana1 + contador < 75)
                {
                    /*if (contador + index_semana1 != index1
                        && lista_sesiones[contador + index_semana1].OidModulo != lista_sesiones[index2].OidModulo)
                        no_repetido = false;*/
                    contador++;
                }
                contador = 0;
                while (contador < 14 && no_repetido && index_semana2 + contador < 75)
                {
                    /*if (contador + index_semana2 != index2
                        && lista_sesiones[contador + index_semana2].OidModulo != lista_sesiones[index1].OidModulo)
                        no_repetido = false;*/
                    contador++;
                }

                //si no se repiten clases del mismo módulo se realiza el intercambio
                if (no_repetido)
                {
                    lista_sesiones[index1].IntercambiaSesion(lista_sesiones[index2], true);
                    return true;
                }
                else
                    return false;
            }
            else return false;
        }

        /// <summary>
        /// Función que organiza las clases asignadas a sesiones de un horario intentando que se cumplan
        /// las prioridades establecidas en el plan de estudios.
        /// No siempre será posible por la disponibilidad de los instructores.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="lista_sesiones"></param>
        /// <param name="profesores"></param>
        /// <param name="_instructores_asignados"></param>
        /// <param name="fecha"></param>
        /// <param name="oid_promocion"></param>
        public static void OrdenaHorario(int index,
                                        ListaSesiones lista_sesiones,
                                        InstructorList profesores,
                                        List<ListaSesiones> _instructores_asignados,
                                        DateTime fecha,
                                        long oid_promocion,
                                        SortedDictionary<long,DisponibilidadInfo> disponibilidades)
        {
            int i = 1;
            while (i < index)
            {
                if (lista_sesiones[i].Estado == 2
                    && lista_sesiones[i].OidClaseTeorica > 0)
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        if (((lista_sesiones[i].OidModulo == lista_sesiones[j].OidModulo
                            && (lista_sesiones[i].OrdenPrimario < lista_sesiones[j].OrdenPrimario
                            || (lista_sesiones[i].OrdenPrimario == lista_sesiones[j].OrdenPrimario
                            && lista_sesiones[i].OrdenSecundario < lista_sesiones[j].OrdenSecundario)))
                            || (lista_sesiones[i].OidSubmodulo == lista_sesiones[j].OidSubmodulo
                            && lista_sesiones[i].OrdenTerciario < lista_sesiones[j].OrdenTerciario))
                            && !lista_sesiones[j].Forzada
                            && !lista_sesiones[i].Forzada
                            && lista_sesiones[j].Estado == 2 && lista_sesiones[i].Estado == 2
                            && lista_sesiones[i].OidClasePractica == 0 && lista_sesiones[j].OidClasePractica == 0)
                        {
                            //si hay dos clases que están desordenadas, comprueba que se pueda realizar el intercambio
                            //de las mismas, si es posible lo realiza y luego reordena nuevamente la primera parte
                            //por si se trastocó

                            if (lista_sesiones[i].OidProfesor == lista_sesiones[j].OidProfesor)
                                lista_sesiones[i].IntercambiaSesion(lista_sesiones[j], true);
                            else
                            {
                                if (lista_sesiones[i].OidSubmodulo == lista_sesiones[j].OidSubmodulo)
                                    lista_sesiones[i].IntercambiaSesion(lista_sesiones[j], false);
                                else
                                {
                                    if (!IntentaIntercambio(lista_sesiones, i, j, profesores, _instructores_asignados, fecha, disponibilidades))
                                    {
                                        InstructorInfo instructor_i = profesores.GetItem(lista_sesiones[i].OidProfesor);
                                        InstructorInfo instructor_j = profesores.GetItem(lista_sesiones[j].OidProfesor);
                                        bool capacitado = false;

                                        foreach (Instructor_PromocionInfo info in instructor_i.Promociones)
                                        {
                                            foreach (Submodulo_Instructor_PromocionInfo item in info.Submodulos)
                                            {
                                                if (item.OidPromocion == oid_promocion
                                                    && item.OidSubmodulo == lista_sesiones[j].OidSubmodulo)
                                                {
                                                    capacitado = true;
                                                    break;
                                                }
                                            }
                                            if (capacitado) break;
                                        }
                                        if (capacitado)
                                        {
                                            capacitado = false;

                                            foreach (Instructor_PromocionInfo info in instructor_j.Promociones)
                                            {
                                                foreach (Submodulo_Instructor_PromocionInfo item in info.Submodulos)
                                                {
                                                    if (item.OidPromocion == oid_promocion
                                                        && item.OidSubmodulo == lista_sesiones[i].OidSubmodulo)
                                                    {
                                                        capacitado = true;
                                                        break;
                                                    }
                                                }
                                                if (capacitado) break;
                                            }
                                        }
                                        if (capacitado)
                                            lista_sesiones[i].IntercambiaSesion(lista_sesiones[j], false);
                                    }
                                }
                            }
                            OrdenaHorario(i, lista_sesiones, profesores, _instructores_asignados, fecha, oid_promocion, disponibilidades);
                        }
                    }
                }
                i++;
            }
        }


        /// <summary>
        /// Función que rellena los huecos que quedan aún sin asignar en el horario, intentando forzar clases
        /// y profesores suplentes
        /// </summary>
        /// <param name="_teoria"></param>
        /// <param name="profesores"></param>
        /// <param name="lista_sesiones"></param>
        /// <param name="_instructores_asignados"></param>
        /// <param name="fecha"></param>
        /// <param name="no_asignables"></param>
        /// <param name="oid_promocion"></param>
        /// <param name="lista_3"></param>
        /// <param name="lista_2"></param>
        /// <param name="dias_suplente"></param>
        /// <param name="profesores_encargados"></param>
        public static void RellenaLibres(ClaseTeoricaList _teoria,
                                        InstructorList profesores,
                                        ListaSesiones lista_sesiones,
                                        List<ListaSesiones> _instructores_asignados,
                                        DateTime fecha,
                                        List<SesionNoAsignable> no_asignables,
                                        long oid_promocion,
                                        List<long> lista_3,
                                        List<long> lista_2, 
                                        List<long> lista_1,
                                        decimal dias_suplente,
                                        ProfesoresModulos profesores_encargados,
                                        SortedDictionary<long, DisponibilidadInfo> disponibilidades)
        {
            Submodulo_Instructor_PromocionList lista_suplentes = Submodulo_Instructor_PromocionList.GetPromocionList(oid_promocion);
            foreach (SesionAuxiliar obj in lista_sesiones)
            {
                if (obj.Estado == 1)
                {
                    int index = lista_sesiones.IndexOf(obj);
                    int index_dia = index;
                    while (index_dia > 13)
                        index_dia -= 14;
                    int index_semana = index;
                    while (index_semana % 14 != 0)
                        index_semana--;

                    //compruebo que la clase que se intenta asignar se tenga que asignar
                    if (!(index < 70 &&
                        (lista_1.Contains(index_dia)
                        || lista_2.Contains(index_dia) || lista_2.Contains(index_dia - 1)
                        || lista_3.Contains(index_dia) || lista_3.Contains(index_dia - 1) || lista_3.Contains(index_dia - 2))))
                        continue;

                    foreach (ClaseTeoricaInfo clase in _teoria)
                    {
                        bool asignable = true;
                        if (clase.Estado == 1) // aún no está programada
                        {
                            foreach (InstructorInfo item in profesores)
                            {
                                foreach (Instructor_PromocionInfo promo in item.Promociones)
                                {
                                    foreach (Submodulo_Instructor_PromocionInfo sub in promo.Submodulos)
                                    {
                                        if (sub.OidSubmodulo == clase.OidSubmodulo
                                           && sub.OidPromocion == oid_promocion)
                                        {
                                            if (!asignable) break;
                                            bool salir = false;
                                            DisponibilidadInfo disp = null;
                                            if (disponibilidades.TryGetValue(item.Oid,out disp))
                                            //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                            //{
                                            //    if (disp.FechaInicio.Date.Equals(fecha.Date))
                                                {
                                                    if (disp.Semana[lista_sesiones.IndexOf(obj)] == true
                                                    && ProfesorLibre(_instructores_asignados, lista_sesiones.IndexOf(obj), item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                    {
                                                        if (sub.Prioridad != 1 || !profesores_encargados.ProfesorEncargado(clase.OidSubmodulo, item.Oid, false))
                                                        {
                                                            Submodulo_Instructor_PromocionList subs = lista_suplentes.GetTitulares(sub.OidSubmodulo);
                                                            if (subs != null)
                                                            {
                                                                foreach (Submodulo_Instructor_PromocionInfo elem in subs)
                                                                {
                                                                    //comprobar la disponibilidad
                                                                    int dias_comprobados = 0, semana = 0;
                                                                    int indice = lista_sesiones.IndexOf(obj);
                                                                    InstructorInfo instructor = profesores.GetItem(elem.OidInstructor);
                                                                    DisponibilidadInfo disponibilidad = null;
                                                                    bool disponible = false, primero = true;

                                                                    if (instructor.Disponibilidades == null
                                                                        || instructor.Disponibilidades.Count == 0)
                                                                        instructor.LoadChilds(typeof(Disponibilidad), false);

                                                                    if (instructor != null)
                                                                    {
                                                                        //if (indice > 74)
                                                                            indice = 74;
                                                                        //else
                                                                        //{
                                                                            //while (indice % 14 != 13)
                                                                                //indice++;
                                                                        //}
                                                                        while (!disponible && dias_comprobados < dias_suplente)
                                                                        {
                                                                            if (indice == 74 || primero)
                                                                            {
                                                                                primero = false;
                                                                                disponibilidad = null;
                                                                                foreach (DisponibilidadInfo d in instructor.Disponibilidades)
                                                                                {
                                                                                    if (d.FechaInicio.Date.Equals(fecha.Date.AddDays(semana * (-7))))
                                                                                    {
                                                                                        disponibilidad = d;
                                                                                        break;
                                                                                    }
                                                                                }
                                                                            }

                                                                            if (disponibilidad == null)
                                                                            {
                                                                                dias_comprobados += 6;
                                                                                semana++;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (disponibilidad.Semana[indice])
                                                                                    disponible = true;
                                                                                else
                                                                                {
                                                                                    if (indice % 14 == 0)
                                                                                        dias_comprobados++;

                                                                                    if (indice == 0)
                                                                                    {
                                                                                        indice = 74;
                                                                                        semana++;
                                                                                    }
                                                                                    else
                                                                                        indice--;
                                                                                }
                                                                            }
                                                                        }
                                                                        if (disponible)
                                                                        {
                                                                            asignable = false;
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        
                                                        //int contador = 0;
                                                        foreach (SesionNoAsignable ses in no_asignables)
                                                        {
                                                            if ((item.Oid == ses.OidInstructor
                                                                || clase.OidModulo == ses.OidModulo)
                                                                && index == ses.Index)
                                                            {
                                                                asignable = false;
                                                                break;
                                                            }
                                                        }
                                                        //bucle que controlaba que un mismo profesor no diera una misma asignatura dos veces en un mismo dia
                                                        //while (asignable && contador < 14 && contador + index_semana < 75)
                                                        //{
                                                        //    if (clase.OidModulo == lista_sesiones[index_semana + contador].OidModulo
                                                        //        && index != index_semana + contador)
                                                        //        asignable = false;
                                                        //    contador++;
                                                        //}
                                                        //if (!asignable) break;

                                                        if (asignable)
                                                        {
                                                            clase.Estado = 2;
                                                            obj.AsignaClaseASesion(clase);
                                                            obj.OidProfesor = item.Oid;
                                                            //obj.Desordenada = true;
                                                            salir = true;
                                                            if ((lista_2.Contains(index_dia) && index < 70) || lista_2.Contains(index)
                                                                || lista_2.Contains(index - 1) || (lista_2.Contains(index_dia - 1) && index - 1 < 70))
                                                            {
                                                                if (((lista_2.Contains(index_dia) && index < 70) || lista_2.Contains(index)) && lista_sesiones[index + 1].Estado == 1)
                                                                {
                                                                    if (clase.OrdenTerciario < clase.TotalClases)
                                                                    {
                                                                        ClaseTeoricaInfo clase_aux = null;
                                                                        foreach (ClaseTeoricaInfo aux in _teoria)
                                                                        {
                                                                            if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                                && clase.OrdenTerciario == aux.OrdenTerciario - 1
                                                                                && aux.Estado == 1)
                                                                            {
                                                                                clase_aux = aux;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (clase_aux != null)
                                                                        {
                                                                            if (disp.Semana[index + 1]
                                                                                && ProfesorLibre(_instructores_asignados, index + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                            {
                                                                                clase_aux.Estado = 2;
                                                                                lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                                lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                                //lista_sesiones[index + 1].Desordenada = true;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        ClaseTeoricaInfo clase_aux = null;
                                                                        foreach (ClaseTeoricaInfo aux in _teoria)
                                                                        {
                                                                            if (clase.OidModulo == aux.OidModulo
                                                                                && clase.OidSubmodulo != aux.OidSubmodulo
                                                                                && clase.OrdenSecundario < aux.OrdenSecundario
                                                                                && aux.Estado == 1)
                                                                            {
                                                                                clase_aux = aux;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (clase_aux != null)
                                                                        {
                                                                            bool capacitado = false;
                                                                            foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                                            {
                                                                                if (promocion.OidPromocion == oid_promocion)
                                                                                {
                                                                                    foreach (Submodulo_Instructor_PromocionInfo info in promocion.Submodulos)
                                                                                    {
                                                                                        if (info.OidSubmodulo == clase_aux.OidSubmodulo)
                                                                                        {
                                                                                            capacitado = true;
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            if (disp.Semana[index + 1] && capacitado
                                                                                && ProfesorLibre(_instructores_asignados, index + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                            {
                                                                                clase_aux.Estado = 2;
                                                                                lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                                lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                                //lista_sesiones[index + 1].Desordenada = true;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (((lista_3.Contains(index_dia - 1) && index - 1 < 70) || lista_3.Contains(index - 1)
                                                                    || (lista_3.Contains(index_dia) && index < 70) || lista_3.Contains(index)) && lista_sesiones[index + 1].Estado == 1)
                                                                {
                                                                    if (clase.OrdenTerciario < clase.TotalClases)
                                                                    {
                                                                        ClaseTeoricaInfo clase_aux = null;
                                                                        foreach (ClaseTeoricaInfo aux in _teoria)
                                                                        {
                                                                            if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                                && clase.OrdenTerciario == aux.OrdenTerciario - 1
                                                                                && aux.Estado == 1)
                                                                            {
                                                                                clase_aux = aux;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (clase_aux != null)
                                                                        {
                                                                            if (disp.Semana[index + 1]
                                                                                && ProfesorLibre(_instructores_asignados, index + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                            {
                                                                                clase_aux.Estado = 2;
                                                                                lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                                lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                                //lista_sesiones[index + 1].Desordenada = true;
                                                                            }
                                                                        }
                                                                        if (((lista_3.Contains(index_dia) && index < 70) || lista_3.Contains(index)) && lista_sesiones[index + 2].Estado == 1)
                                                                        {
                                                                            if (clase.OrdenTerciario < clase.TotalClases - 1)
                                                                            {
                                                                                ClaseTeoricaInfo clase_aux2 = null;
                                                                                foreach (ClaseTeoricaInfo aux in _teoria)
                                                                                {
                                                                                    if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                                        && clase.OrdenTerciario == aux.OrdenTerciario - 2
                                                                                        && aux.Estado == 1)
                                                                                    {
                                                                                        clase_aux2 = aux;
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                if (clase_aux2 != null)
                                                                                {
                                                                                    if (disp.Semana[index + 2]
                                                                                        && ProfesorLibre(_instructores_asignados, index + 2, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                                    {
                                                                                        clase_aux2.Estado = 2;
                                                                                        lista_sesiones[index + 2].AsignaClaseASesion(clase_aux2);
                                                                                        lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                        //lista_sesiones[index + 2].Desordenada = true;
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                ClaseTeoricaInfo clase_aux2 = null;
                                                                                foreach (ClaseTeoricaInfo aux in _teoria)
                                                                                {
                                                                                    if (clase.OidModulo == aux.OidModulo
                                                                                        && clase.OidSubmodulo != aux.OidSubmodulo
                                                                                        && clase.OrdenSecundario < aux.OrdenSecundario
                                                                                        && aux.Estado == 1)
                                                                                    {
                                                                                        clase_aux2 = aux;
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                if (clase_aux2 != null)
                                                                                {
                                                                                    bool capacitado = false;
                                                                                    foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                                                    {
                                                                                        if (promocion.OidPromocion == oid_promocion)
                                                                                        {
                                                                                            foreach (Submodulo_Instructor_PromocionInfo info in promocion.Submodulos)
                                                                                            {
                                                                                                if (info.OidSubmodulo == clase_aux2.OidSubmodulo)
                                                                                                {
                                                                                                    capacitado = true;
                                                                                                    break;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    if (disp.Semana[index + 2] && capacitado
                                                                                        && ProfesorLibre(_instructores_asignados, index + 2, item.Oid, lista_sesiones, profesores, -2, fecha, disponibilidades))
                                                                                    {
                                                                                        clase_aux2.Estado = 2;
                                                                                        lista_sesiones[index + 2].AsignaClaseASesion(clase_aux2);
                                                                                        lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                        //lista_sesiones[index + 2].Desordenada = true;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        ClaseTeoricaInfo clase_aux = null;
                                                                        foreach (ClaseTeoricaInfo aux in _teoria)
                                                                        {
                                                                            if (clase.OidModulo == aux.OidModulo
                                                                                && clase.OidSubmodulo != aux.OidSubmodulo
                                                                                && clase.OrdenSecundario < aux.OrdenSecundario
                                                                                && aux.Estado == 1)
                                                                            {
                                                                                clase_aux = aux;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (clase_aux != null)
                                                                        {
                                                                            bool capacitado = false;
                                                                            foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                                            {
                                                                                if (promocion.OidPromocion == oid_promocion)
                                                                                {
                                                                                    foreach (Submodulo_Instructor_PromocionInfo info in promocion.Submodulos)
                                                                                    {
                                                                                        if (info.OidSubmodulo == clase_aux.OidSubmodulo)
                                                                                        {
                                                                                            capacitado = true;
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            if (disp.Semana[index + 1] && capacitado
                                                                                && ProfesorLibre(_instructores_asignados, index + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                            {
                                                                                clase_aux.Estado = 2;
                                                                                lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                                lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                                //lista_sesiones[index + 1].Desordenada = true;
                                                                            }
                                                                            if (((lista_3.Contains(index_dia) && index < 70) || lista_3.Contains(index)) && lista_sesiones[index + 2].Estado == 1)
                                                                            {
                                                                                if (clase_aux.OrdenTerciario < clase_aux.TotalClases - 1)
                                                                                {
                                                                                    ClaseTeoricaInfo clase_aux2 = null;
                                                                                    foreach (ClaseTeoricaInfo aux in _teoria)
                                                                                    {
                                                                                        if (clase_aux.OidSubmodulo == aux.OidSubmodulo
                                                                                            && clase_aux.OrdenTerciario == aux.OrdenTerciario - 1
                                                                                            && aux.Estado == 1)
                                                                                        {
                                                                                            clase_aux2 = aux;
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                    if (clase_aux2 != null)
                                                                                    {
                                                                                        if (disp.Semana[index + 2]
                                                                                            && ProfesorLibre(_instructores_asignados, index + 2, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                                        {
                                                                                            clase_aux2.Estado = 2;
                                                                                            lista_sesiones[index + 2].AsignaClaseASesion(clase_aux2);
                                                                                            lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                            //lista_sesiones[index + 2].Desordenada = true;
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    ClaseTeoricaInfo clase_aux2 = null;
                                                                                    foreach (ClaseTeoricaInfo aux in _teoria)
                                                                                    {
                                                                                        if (clase_aux.OidModulo == aux.OidModulo
                                                                                            && clase_aux.OidSubmodulo != aux.OidSubmodulo
                                                                                            && clase_aux.OrdenSecundario < aux.OrdenSecundario
                                                                                            && aux.Estado == 1)
                                                                                        {
                                                                                            clase_aux2 = aux;
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                    if (clase_aux2 != null)
                                                                                    {
                                                                                        capacitado = false;
                                                                                        foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                                                        {
                                                                                            if (promocion.OidPromocion == oid_promocion)
                                                                                            {
                                                                                                foreach (Submodulo_Instructor_PromocionInfo info in promocion.Submodulos)
                                                                                                {
                                                                                                    if (info.OidSubmodulo == clase_aux2.OidSubmodulo)
                                                                                                    {
                                                                                                        capacitado = true;
                                                                                                        break;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        if (disp.Semana[index + 2] && capacitado
                                                                                            && ProfesorLibre(_instructores_asignados, index + 2, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                                        {
                                                                                            clase_aux2.Estado = 2;
                                                                                            lista_sesiones[index + 2].AsignaClaseASesion(clase_aux2);
                                                                                            lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                            //lista_sesiones[index + 2].Desordenada = true;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        //break;
                                                    }
                                                }
                                            //}
                                            if (salir || !asignable) break;
                                        }
                                        if (!asignable || clase.Estado == 2) break;
                                    }
                                }
                                if (clase.Estado == 2 || !asignable) break;
                            }
                            if (clase.Estado == 2)
                            {
                                int new_index = lista_sesiones.IndexOf(obj);

                                for (int k = new_index + 1; k < 75; k++)
                                {
                                    if (lista_sesiones[k].OidModulo == lista_sesiones[new_index].OidModulo)
                                    {
                                        if ((lista_sesiones[k].OrdenPrimario < lista_sesiones[new_index].OrdenPrimario
                                            || (lista_sesiones[k].OrdenPrimario == lista_sesiones[new_index].OrdenPrimario
                                            && lista_sesiones[k].OrdenSecundario < lista_sesiones[new_index].OrdenSecundario)
                                            || (lista_sesiones[k].OrdenPrimario == lista_sesiones[new_index].OrdenPrimario
                                            && lista_sesiones[k].OrdenSecundario == lista_sesiones[new_index].OrdenSecundario
                                            && lista_sesiones[k].OrdenTerciario < lista_sesiones[new_index].OrdenTerciario))
                                            && lista_sesiones[k].OidClaseTeorica != 0
                                            && lista_sesiones[k].OidProfesor == lista_sesiones[new_index].OidProfesor)
                                            lista_sesiones[k].IntercambiaSesion(lista_sesiones[new_index], true);
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Marca como libre en la lista de clases, la clase que estaba asignada en la sesión que está en el índice index
        /// </summary>
        /// <param name="index">índice de la sesión actual</param>
        /// <param name="lista_sesiones">lista de sesiones del horario actual</param>
        /// <param name="_practicas">lista de clases prácticas que aún no se han asignado a la promoción actual</param>
        /// <param name="_teoria">lista de clases teóricas que aún no se han asignado a la promoción actual</param>
        /// <param name="_extra">lista de clases extra que aún no se han asignado a la promoción actual</param>
        public static void LiberarClase(int index, ListaSesiones lista_sesiones,
                                        List<ClasePracticaList> _practicas,
                                        ClaseTeoricaList _teoria,
                                        ClaseExtraList _extra)
        {
            if (lista_sesiones[index].Estado != 1)
            {
                if (lista_sesiones[index].OidClasePractica != 0)
                {
                    //foreach (ClasePracticaList lista in _practicas)
                    //{
                    //    foreach (ClasePracticaInfo clase in lista)
                    //    {
                    //        if (clase.Oid == lista_sesiones[index].OidClasePractica
                    //            && clase.Grupo == lista_sesiones[index].Grupo)
                    //        {
                    //            clase.Estado = 1;
                    //            break;
                    //        }
                    //    }
                    //}
                    ClasePracticaInfo clase = _practicas[(int)(lista_sesiones[index].Grupo)].GetItem(lista_sesiones[index].OidClasePractica);
                    clase.Estado = 1;
                }
                else
                {
                    if (lista_sesiones[index].OidClaseTeorica != 0)
                    {
                        //foreach (ClaseTeoricaInfo clase in _teoria)
                        //{
                        //    if (clase.Oid == lista_sesiones[index].OidClaseTeorica)
                        //    {
                        //        clase.Estado = 1;
                        //        break;
                        //    }
                        //}

                        ClaseTeoricaInfo clase = _teoria.GetItem(lista_sesiones[index].OidClaseTeorica);
                        clase.Estado = 1;
                    }
                    else
                    {
                        //foreach (ClaseExtraInfo clase in _extra)
                        //{
                        //    if (clase.Oid == lista_sesiones[index].OidClaseExtra)
                        //    {
                        //        clase.Estado = 1;
                        //        break;
                        //    }
                        //}
                        ClaseExtraInfo clase = _extra.GetItem(lista_sesiones[index].OidClaseExtra);
                        clase.Estado = 1;
                    }
                }
            }
        }

        public static void SetInstructor(long oid, string instructor, int index, ListaSesiones lista_sesiones)
        {
            if (lista_sesiones[index].Seleccionada)
            {
                lista_sesiones[index].OidProfesor = oid;
                lista_sesiones[index].Seleccionada = false;
            }
        }


        /// <summary>
        /// Función que devuelve el nombre del módulo a la que pertenece una clase a partir del
        /// Oid y el tipo de la misma
        /// </summary>
        /// <param name="oid"></param>
        /// <param name="tipo"></param>
        /// <param name="teoricas"></param>
        /// <param name="practicas"></param>
        /// <param name="extras"></param>
        /// <param name="modulos"></param>
        /// <returns></returns>
        public static string ObtieneNombreModulo(long oid, long tipo,
                                                    ClaseTeoricaList teoricas,
                                                    List<ClasePracticaList> practicas,
                                                    ClaseExtraList extras,
                                                    ModuloList modulos)
        {
            long oid_clase = oid;
            long oid_modulo;

            if (oid_clase < 0) return string.Empty;

            if (tipo.Equals(0))
            {
                ClaseTeoricaInfo clase = teoricas.GetItem(oid_clase);
                oid_modulo = clase.OidModulo;
            }
            else
            {
                if (tipo.Equals(1))
                {
                    ClasePracticaInfo clase = null;
                    foreach (ClasePracticaList lista in practicas)
                    {
                        clase = lista.GetItem(oid_clase);
                        if (clase != null)
                            break;
                    }
                    oid_modulo = clase.OidModulo;

                }
                else
                {
                    ClaseExtraInfo clase = extras.GetItem(oid_clase);
                    oid_modulo = clase.OidModulo;
                }
            }
            ModuloInfo modulo = modulos.GetItem(oid_modulo);
            return modulo.Texto;
        }


        /// <summary>
        /// Rellena la lista auxiliar de sesiones necesaria para la configuración del horario.
        /// Esta lista contiene más datos que una lista de sesiones básica.
        /// </summary>
        /// <param name="lista_sesiones"> clases asignadas</param>
        /// <param name="teoricas"></param>
        /// <param name="practicas"></param>
        /// <param name="extras"></param>
        public static void MuestraSesiones(Sesions sesiones,
                                            ListaSesiones lista_sesiones,
                                            ClaseTeoricaList teoricas,
                                            ClasePracticaList practicas,
                                            ClaseExtraList extras)
        {
            //rellena la lista de sesiones con la que se va a trabajar a partir de la lista de sesiones
            //básica del horario
            foreach (Sesion item in sesiones)
            {
                foreach (SesionAuxiliar aux in lista_sesiones)
                {
                    if (item.Fecha.ToShortDateString() == aux.Fecha.ToShortDateString()
                        && item.Hora.ToShortTimeString() == aux.Hora.ToShortTimeString())
                    {
                        aux.AsignaSesion(item, teoricas, practicas, extras);
                        break;
                    }
                }
            }


            //marca como desordenadas aquellas sesiones que tienen clases asignadas de forma que no se cumplen 
            //las prioridades establecidas en el plan de estudios
            /*int k = 1;
            while (k < 75)
            {
                for (int j = k - 1; j >= 0; j--)
                {
                    if (((lista_sesiones[k].OidModulo == lista_sesiones[j].OidModulo
                        && lista_sesiones[k].OrdenPrimario == lista_sesiones[j].OrdenPrimario
                        && lista_sesiones[k].OrdenSecundario < lista_sesiones[j].OrdenSecundario)
                        || (lista_sesiones[k].OidSubmodulo == lista_sesiones[j].OidSubmodulo
                        && lista_sesiones[k].OrdenSecundario == lista_sesiones[j].OrdenSecundario
                        && lista_sesiones[k].OrdenTerciario < lista_sesiones[j].OrdenTerciario))
                        && !lista_sesiones[j].Forzada
                        && !lista_sesiones[k].Forzada
                        && lista_sesiones[j].Estado > 1 && lista_sesiones[k].Estado > 1)
                    {
                        lista_sesiones[j].Desordenada = true;
                    }
                }
                k++;
            }*/

        }


        /// <summary>
        /// Rellena la lista auxiliar de sesiones necesaria para la configuración del horario.
        /// Esta lista contiene más datos que una lista de sesiones básica.
        /// </summary>
        /// <param name="lista_sesiones"> clases asignadas</param>
        /// <param name="teoricas"></param>
        /// <param name="practicas"></param>
        /// <param name="extras"></param>
        public static void MuestraSesiones(SesionList sesiones,
                                            ListaSesiones lista_sesiones,
                                            ClaseTeoricaList teoricas,
                                            ClasePracticaList practicas,
                                            ClaseExtraList extras)
        {
            //rellena la lista de sesiones con la que se va a trabajar a partir de la lista de sesiones
            //básica del horario
            foreach (SesionInfo item in sesiones)
            {
                foreach (SesionAuxiliar aux in lista_sesiones)
                {
                    if (item.Fecha.ToShortDateString() == aux.Fecha.ToShortDateString()
                        && item.Hora.ToShortTimeString() == aux.Hora.ToShortTimeString())
                    {
                        aux.AsignaSesion(item, teoricas, practicas, extras);
                        break;
                    }
                }
            }


            //marca como desordenadas aquellas sesiones que tienen clases asignadas de forma que no se cumplen 
            //las prioridades establecidas en el plan de estudios
            /*int k = 1;
            while (k < 75)
            {
                for (int j = k - 1; j >= 0; j--)
                {
                    if (((lista_sesiones[k].OidModulo == lista_sesiones[j].OidModulo
                        && lista_sesiones[k].OrdenPrimario == lista_sesiones[j].OrdenPrimario
                        && lista_sesiones[k].OrdenSecundario < lista_sesiones[j].OrdenSecundario)
                        || (lista_sesiones[k].OidSubmodulo == lista_sesiones[j].OidSubmodulo
                        && lista_sesiones[k].OrdenSecundario == lista_sesiones[j].OrdenSecundario
                        && lista_sesiones[k].OrdenTerciario < lista_sesiones[j].OrdenTerciario))
                        && !lista_sesiones[j].Forzada
                        && !lista_sesiones[k].Forzada
                        && lista_sesiones[j].Estado > 1 && lista_sesiones[k].Estado > 1)
                    {
                        lista_sesiones[j].Desordenada = true;
                    }
                }
                k++;
            }*/

        }

        public static bool SesionDisponible(ListaSesiones lista, int indice, int n_horas)
        {
            for(int index = indice; index < indice + n_horas; index++)
            {
                if (lista[index].Estado != 1)
                    return false;
            }
            return true;
        }

        public static void GeneraHorario(DateTime fecha,
                                        decimal n_practicas,
                                        InstructorList profesores,
                                        List<ListaSesiones> instructores_asignados,
                                        List<ClasePracticaList> practicas,
                                        ClaseTeoricaList clases_teoria,
                                        ListaSesiones lista_sesiones,
                                        long oid_plan, long oid_promocion,
                                        List<SesionNoAsignable> no_asignables,
                                        List<long> lista_1,
                                        List<long> lista_2,
                                        List<long> lista_3,
                                        decimal dias_suplente,
                                        ProfesoresModulos profesores_encargados,
                                        SortedDictionary<long, DisponibilidadInfo> disponibilidades,
                                        moleQule.Library.Timer t)
        {
            long clases_asignadas = 0, p_instructor;
            decimal restantes = n_practicas * 2;

            if (profesores == null) profesores = InstructorList.GetInstructoresHorariosList(oid_promocion, fecha, fecha.AddDays(6));
            int index_practica = 0;

            //Se calcula el número de clases ya asignadas poniendo como asignadas las horas que no se van a programar
            //según las horas seleccionadas
            foreach (SesionAuxiliar obj in lista_sesiones)
            {
                if (obj.Estado > 1)
                {
                    clases_asignadas++;
                }
                if ((obj.OidClasePractica != 0 && index_practica == 0) ||
                    index_practica > 0 && index_practica < 5)
                {
                    obj.Estado = 2;
                    index_practica++;
                    clases_asignadas++;
                }
                if (index_practica == 5) index_practica = 0;
            }

            t.Record("clases asignadas");

            List<List<long>> incompatibles = new List<List<long>>();

            for (int i = 0; i < 5; i++)
                incompatibles.Add(new List<long>());

            int intento = 0;

            //la condición de salida debe ser que no hayan habido cambios entre iteraciones
            //habrá que poner una variable indicando que se ha realizado algún tipo de cambio
            //y salir en función del valor de ésta
            while (intento != 3 && clases_asignadas < 75) 
            {
                int exponente = 1;
                if (restantes != 0)
                {
                    long count = 0;
                    long colocadas = 0;
                    int clases = 0;
                    int i = 0;

                    while (i < 74 && restantes > 0)
                    {
                        //si está disponible el sábado habrá que añadir las prácticas ahí
                        if (lista_sesiones[70].Estado == 1
                            && lista_sesiones[71].Estado == 1
                            && lista_sesiones[72].Estado == 1
                            && lista_sesiones[73].Estado == 1
                            && lista_sesiones[74].Estado == 1
                            && clases < practicas.Count)
                        {
                            while (count != 3 && clases < practicas.Count)
                            {
                                //el sábado está libre, ahora hay que buscar prácticas y profesores 
                                //disponibles para darlas
                                if (exponente == 1)
                                {
                                    foreach (ClasePracticaInfo clase in practicas[1])
                                    {
                                        p_instructor = 0;
                                        bool asignable = true;

                                        if (clase.Incompatible > 0 && !LaboratorioLibre(lista_sesiones, instructores_asignados, 70, clase.Incompatible))
                                            continue;

                                        if (clase.Estado == 1) // aún no está programada
                                        {
                                            bool salir = false;

                                            foreach (InstructorInfo item in profesores)
                                            {
                                                foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                {
                                                    if (promocion.OidPromocion == oid_promocion)
                                                    {
                                                        foreach (Submodulo_Instructor_PromocionInfo sub in promocion.Submodulos)
                                                        {
                                                            if (sub.OidSubmodulo == clase.OidSubmodulo
                                                                && sub.OidPromocion == oid_promocion)
                                                            {
                                                                //if (p_instructor == 0 || p_instructor > sub.Prioridad)
                                                                if (sub.Prioridad == 1 && profesores_encargados.ProfesorEncargado(clase.OidSubmodulo, item.Oid, true))
                                                                {
                                                                    //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                                                    //{
                                                                    //if (disp.FechaInicio.Date.Equals(fecha.Date))
                                                                    DisponibilidadInfo disp = null;
                                                                    if (disponibilidades.TryGetValue(item.Oid, out disp))
                                                                    {
                                                                        //se comprueba que el profesor tenga las 5 horas libres
                                                                        if (disp.Semana[70] && disp.Semana[71] && disp.Semana[72] && disp.Semana[73] && disp.Semana[74]
                                                                            && Horario.ProfesorLibre(instructores_asignados, 70, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 71, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 72, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 73, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 74, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            /*&& Horario.PosibleAsignar(clase, _practicas)*/)
                                                                        {
                                                                            //No hace falta (asignable = Horario.PosibleAsignar(clase, _practicas);)
                                                                            if (!PosibleAsignarModulo(clase, clases_teoria)) break;
                                                                            if (!PosibleAsignarSubodulo(clase, clases_teoria)) break;
                                                                            if (!PosibleAsignarClase(clase, clases_teoria)) break;
                                                                            count += clase.Grupo;
                                                                            clase.Estado = 2;
                                                                            restantes--;
                                                                            colocadas++;
                                                                            clases_asignadas++;
                                                                            lista_sesiones[70].AsignaClaseASesion(clase);
                                                                            lista_sesiones[70].OidProfesor = item.Oid;
                                                                            int index = 71;
                                                                            int orden = 1;
                                                                            while (orden < 5)
                                                                            {
                                                                                clases_asignadas++;
                                                                                lista_sesiones[index].AsignaClaseASesion(clase);
                                                                                lista_sesiones[index].OidProfesor = item.Oid;
                                                                                index++;
                                                                                orden++;
                                                                            }
                                                                            salir = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                    //}
                                                                    if (salir || !asignable) break;
                                                                    //if (salir) break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                if (salir || !asignable) break;
                                                //if (salir) break;
                                            }
                                            if (salir || !asignable) break;
                                            //if (salir) break;
                                        }
                                    }
                                    foreach (ClasePracticaInfo clase in practicas[2])
                                    {
                                        p_instructor = 0;
                                        bool asignable = true;

                                        if ((clase.Incompatible > 0 && !LaboratorioLibre(lista_sesiones, instructores_asignados, 70, clase.Incompatible))
                                            || clase.Oid == lista_sesiones[70].OidClasePractica || count == clase.Grupo)
                                            continue;

                                        if (clase.Estado == 1) // aún no está programada
                                        {
                                            bool salir = false;
                                            foreach (InstructorInfo item in profesores)
                                            {
                                                foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                {
                                                    if (promocion.OidPromocion == oid_promocion)
                                                    {
                                                        foreach (Submodulo_Instructor_PromocionInfo sub in promocion.Submodulos)
                                                        {
                                                            if (sub.OidSubmodulo == clase.OidSubmodulo
                                                                && sub.OidPromocion == oid_promocion)
                                                            {
                                                                //if (p_instructor == 0 || p_instructor > sub.Prioridad)
                                                                if (sub.Prioridad == 1)
                                                                {
                                                                    //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                                                    //{
                                                                    //if (disp.FechaInicio.Date.Equals(fecha.Date))
                                                                    DisponibilidadInfo disp = null;
                                                                    if (disponibilidades.TryGetValue(item.Oid, out disp))
                                                                    {
                                                                        if (disp.Semana[70] && disp.Semana[71] && disp.Semana[72] && disp.Semana[73] && disp.Semana[74]
                                                                            && Horario.ProfesorLibre(instructores_asignados, 70, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 71, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 72, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 73, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 74, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && lista_sesiones[70].OidProfesor != item.Oid
                                                                            /*&& Horario.PosibleAsignar(clase, _practicas)*/)
                                                                        {
                                                                            asignable = Horario.PosibleAsignar(clase, practicas);
                                                                            if (asignable) asignable = Horario.PosibleAsignarClase(clase, clases_teoria);
                                                                            if (!asignable) break;
                                                                            count += clase.Grupo;
                                                                            clase.Estado = 2;
                                                                            restantes--;
                                                                            colocadas++;
                                                                            int index = 71;
                                                                            int orden = 1;
                                                                            while (orden < 5)
                                                                            {
                                                                                if (index % 2 == 0)
                                                                                {
                                                                                    lista_sesiones[index].AsignaClaseASesion(clase);
                                                                                    lista_sesiones[index].OidProfesor = item.Oid;
                                                                                }
                                                                                index++;
                                                                                orden++;
                                                                            }
                                                                            salir = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                    //}
                                                                    if (salir || !asignable) break;
                                                                    //if (salir) break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                if (salir || !asignable) break;
                                                //if (salir) break;
                                            }
                                            if (salir || !asignable) break;
                                            //if (salir) break;
                                        }
                                    }
                                }
                                else
                                {
                                    foreach (ClasePracticaInfo clase in practicas[2])
                                    {
                                        p_instructor = 0;
                                        bool asignable = true;

                                        if (clase.Incompatible > 0 && !LaboratorioLibre(lista_sesiones, instructores_asignados, 70, clase.Incompatible))
                                            continue;

                                        if (clase.Estado == 1) // aún no está programada
                                        {
                                            bool salir = false;

                                            foreach (InstructorInfo item in profesores)
                                            {
                                                foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                {
                                                    if (promocion.OidPromocion == oid_promocion)
                                                    {
                                                        foreach (Submodulo_Instructor_PromocionInfo sub in promocion.Submodulos)
                                                        {
                                                            if (sub.OidSubmodulo == clase.OidSubmodulo
                                                                && sub.OidPromocion == oid_promocion)
                                                            {
                                                                //if (p_instructor == 0 || p_instructor > sub.Prioridad)
                                                                if (sub.Prioridad == 1 && profesores_encargados.ProfesorEncargado(clase.OidSubmodulo, item.Oid, true))
                                                                {
                                                                    //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                                                    //{
                                                                    //if (disp.FechaInicio.Date.Equals(fecha.Date))
                                                                    DisponibilidadInfo disp = null;
                                                                    if (disponibilidades.TryGetValue(item.Oid, out disp))
                                                                    {
                                                                        //se comprueba que el profesor tenga las 5 horas libres
                                                                        if (disp.Semana[70] && disp.Semana[71] && disp.Semana[72] && disp.Semana[73] && disp.Semana[74]
                                                                            && Horario.ProfesorLibre(instructores_asignados, 70, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 71, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 72, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 73, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 74, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            /*&& Horario.PosibleAsignar(clase, _practicas)*/)
                                                                        {
                                                                            asignable = Horario.PosibleAsignar(clase, practicas);
                                                                            if (asignable) asignable = Horario.PosibleAsignarClase(clase, clases_teoria);
                                                                            if (!asignable) break;
                                                                            count += clase.Grupo;
                                                                            clase.Estado = 2;
                                                                            restantes--;
                                                                            colocadas++;
                                                                            clases_asignadas++;
                                                                            lista_sesiones[70].AsignaClaseASesion(clase);
                                                                            lista_sesiones[70].OidProfesor = item.Oid;
                                                                            int index = 71;
                                                                            int orden = 1;
                                                                            while (orden < 5)
                                                                            {
                                                                                clases_asignadas++;
                                                                                lista_sesiones[index].AsignaClaseASesion(clase);
                                                                                lista_sesiones[index].OidProfesor = item.Oid;
                                                                                index++;
                                                                                orden++;
                                                                            }
                                                                            salir = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                    //}
                                                                    if (salir || !asignable) break;
                                                                    //if (salir) break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                if (salir || !asignable) break;
                                                //if (salir) break;
                                            }
                                            if (salir || !asignable) break;
                                            //if (salir) break;
                                        }
                                    }
                                    foreach (ClasePracticaInfo clase in practicas[1])
                                    {
                                        p_instructor = 0;
                                        bool asignable = true;

                                        if ((clase.Incompatible > 0 && !LaboratorioLibre(lista_sesiones, instructores_asignados, 70, clase.Incompatible))
                                            || clase.Oid == lista_sesiones[70].OidClasePractica || count == clase.Grupo)
                                            continue;

                                        if (clase.Estado == 1) // aún no está programada
                                        {
                                            bool salir = false;
                                            foreach (InstructorInfo item in profesores)
                                            {
                                                foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                {
                                                    if (promocion.OidPromocion == oid_promocion)
                                                    {
                                                        foreach (Submodulo_Instructor_PromocionInfo sub in promocion.Submodulos)
                                                        {
                                                            if (sub.OidSubmodulo == clase.OidSubmodulo
                                                                && sub.OidPromocion == oid_promocion)
                                                            {
                                                                //if (p_instructor == 0 || p_instructor > sub.Prioridad)
                                                                if (sub.Prioridad == 1)
                                                                {
                                                                    //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                                                    //{
                                                                    //if (disp.FechaInicio.Date.Equals(fecha.Date))
                                                                    DisponibilidadInfo disp = null;
                                                                    if (disponibilidades.TryGetValue(item.Oid, out disp))
                                                                    {
                                                                        if (disp.Semana[70] && disp.Semana[71] && disp.Semana[72] && disp.Semana[73] && disp.Semana[74]
                                                                            && Horario.ProfesorLibre(instructores_asignados, 70, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 71, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 72, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 73, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && Horario.ProfesorLibre(instructores_asignados, 74, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                            && lista_sesiones[70].OidProfesor != item.Oid
                                                                            /*&& Horario.PosibleAsignar(clase, _practicas)*/)
                                                                        {
                                                                            asignable = Horario.PosibleAsignar(clase, practicas);
                                                                            if (asignable) asignable = Horario.PosibleAsignarClase(clase, clases_teoria);
                                                                            if (!asignable) break;
                                                                            count += clase.Grupo;
                                                                            clase.Estado = 2;
                                                                            restantes--;
                                                                            colocadas++;
                                                                            int index = 71;
                                                                            int orden = 1;
                                                                            while (orden < 5)
                                                                            {
                                                                                if (index % 2 == 0)
                                                                                {
                                                                                    lista_sesiones[index].AsignaClaseASesion(clase);
                                                                                    lista_sesiones[index].OidProfesor = item.Oid;
                                                                                }
                                                                                index++;
                                                                                orden++;
                                                                            }
                                                                            salir = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                    //}
                                                                    if (salir || !asignable) break;
                                                                    //if (salir) break;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                if (salir || !asignable) break;
                                                //if (salir) break;
                                            }
                                            if (salir || !asignable) break;
                                            //if (salir) break;
                                        }
                                    }
                                }
                                if (count > 0)
                                    exponente = -exponente;
                                if (count > 0 && count < 3)
                                {
                                    //LiberarClase(70, lista_sesiones, _practicas, _teoria, null);
                                    int index_clase;
                                    for (index_clase = 70; index_clase < 75; index_clase++)
                                    {
                                        if (lista_sesiones[index_clase].OidClasePractica != 0)
                                            break;
                                    }
                                    for (int k = 70; i < 75; i++)
                                    {
                                        if (lista_sesiones[k].OidClasePractica == 0)
                                            lista_sesiones[k].Copia(lista_sesiones[index_clase],true);
                                    }
                                    colocadas++;
                                    restantes--;
                                    //lista_sesiones[70].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                    //lista_sesiones[71].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                    //lista_sesiones[72].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                    //lista_sesiones[73].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                    //lista_sesiones[74].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                    //colocadas--;
                                    //restantes++;
                                    //clases_asignadas -= 5;
                                    count = 0;
                                }
                                clases++;
                            }
                        }
                        else
                        {
                            //no se pueden asignar el sabado
                            while (i < 74 && restantes > 0)
                            {
                                count = 0;
                                colocadas = 0;

                                while (i < 74 && colocadas < 2)
                                {
                                    if (lista_sesiones[i].Estado == 1
                                        && lista_sesiones[i + 1].Estado == 1
                                        && lista_sesiones[i + 2].Estado == 1
                                        && lista_sesiones[i + 3].Estado == 1
                                        && lista_sesiones[i + 4].Estado == 1)
                                    {
                                        if (exponente == 1)
                                        {
                                            foreach (ClasePracticaInfo clase in practicas[1])
                                            {
                                                p_instructor = 0;
                                                bool asignable = true;

                                                if (clase.Incompatible > 0 && !LaboratorioLibre(lista_sesiones, instructores_asignados, i, clase.Incompatible))
                                                    continue;

                                                if (clase.Estado == 1) // aún no está programada
                                                {
                                                    bool salir = false;

                                                    foreach (InstructorInfo item in profesores)
                                                    {
                                                        foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                        {
                                                            if (promocion.OidPromocion == oid_promocion)
                                                            {
                                                                foreach (Submodulo_Instructor_PromocionInfo sub in promocion.Submodulos)
                                                                {
                                                                    if (sub.OidSubmodulo == clase.OidSubmodulo
                                                                        && sub.OidPromocion == oid_promocion)
                                                                    {
                                                                        //if (p_instructor == 0 || p_instructor > sub.Prioridad)
                                                                        if (sub.Prioridad == 1)
                                                                        {
                                                                            //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                                                            //{
                                                                            //if (disp.FechaInicio.Date.Equals(fecha.Date))
                                                                            DisponibilidadInfo disp = null;
                                                                            if (disponibilidades.TryGetValue(item.Oid, out disp))
                                                                            {
                                                                                //se comprueba que el profesor tenga las 5 horas libres
                                                                                if (disp.Semana[i] && disp.Semana[i + 1] && disp.Semana[i + 2] && disp.Semana[i + 3] && disp.Semana[i + 4]
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 2, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 3, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 4, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    /*&& Horario.PosibleAsignar(clase, _practicas)*/)
                                                                                {
                                                                                    asignable = Horario.PosibleAsignar(clase, practicas);
                                                                                    if (asignable) asignable = Horario.PosibleAsignarClase(clase, clases_teoria);
                                                                                    if (!asignable) break;
                                                                                    count += clase.Grupo;
                                                                                    clase.Estado = 2;
                                                                                    restantes--;
                                                                                    colocadas++;
                                                                                    clases_asignadas++;
                                                                                    lista_sesiones[i].AsignaClaseASesion(clase);
                                                                                    lista_sesiones[i].OidProfesor = item.Oid;
                                                                                    int index = i + 1;
                                                                                    int orden = 1;
                                                                                    while (orden < 5)
                                                                                    {
                                                                                        clases_asignadas++;
                                                                                        lista_sesiones[index].AsignaClaseASesion(clase);
                                                                                        lista_sesiones[index].OidProfesor = item.Oid;
                                                                                        index++;
                                                                                        orden++;
                                                                                    }
                                                                                    salir = true;
                                                                                    break;
                                                                                }
                                                                            }
                                                                            //}
                                                                            if (salir || !asignable) break;
                                                                            //if (salir) break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        if (salir || !asignable) break;
                                                        //if (salir) break;
                                                    }
                                                    if (salir || !asignable) break;
                                                    //if (salir) break;
                                                }
                                            }
                                            foreach (ClasePracticaInfo clase in practicas[2])
                                            {
                                                p_instructor = 0;
                                                bool asignable = true;

                                                if ((clase.Incompatible > 0 && !LaboratorioLibre(lista_sesiones, instructores_asignados, i, clase.Incompatible))
                                                    || clase.Oid == lista_sesiones[i].OidClasePractica || count == clase.Grupo)
                                                    continue;

                                                if (clase.Estado == 1) // aún no está programada
                                                {
                                                    bool salir = false;
                                                    foreach (InstructorInfo item in profesores)
                                                    {
                                                        foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                        {
                                                            if (promocion.OidPromocion == oid_promocion)
                                                            {
                                                                foreach (Submodulo_Instructor_PromocionInfo sub in promocion.Submodulos)
                                                                {
                                                                    if (sub.OidSubmodulo == clase.OidSubmodulo
                                                                        && sub.OidPromocion == oid_promocion)
                                                                    {
                                                                        //if (p_instructor == 0 || p_instructor > sub.Prioridad)
                                                                        if (sub.Prioridad == 1)
                                                                        {
                                                                            //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                                                            //{
                                                                            //if (disp.FechaInicio.Date.Equals(fecha.Date))
                                                                            DisponibilidadInfo disp = null;
                                                                            if (disponibilidades.TryGetValue(item.Oid, out disp))
                                                                            {
                                                                                if (disp.Semana[i] && disp.Semana[i + 1] && disp.Semana[i + 2] && disp.Semana[i + 3] && disp.Semana[i + 4]
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 2, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 3, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 4, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && lista_sesiones[i].OidProfesor != item.Oid
                                                                                    /*&& Horario.PosibleAsignar(clase, _practicas)*/)
                                                                                {
                                                                                    asignable = Horario.PosibleAsignar(clase, practicas);
                                                                                    if (asignable) asignable = Horario.PosibleAsignarClase(clase, clases_teoria);
                                                                                    if (!asignable) break;
                                                                                    count += clase.Grupo;
                                                                                    clase.Estado = 2;
                                                                                    restantes--;
                                                                                    colocadas++;
                                                                                    int index = i + 1;
                                                                                    int orden = 1;
                                                                                    while (orden < 5)
                                                                                    {
                                                                                        if (index % 2 == 0)
                                                                                        {
                                                                                            lista_sesiones[index].AsignaClaseASesion(clase);
                                                                                            lista_sesiones[index].OidProfesor = item.Oid;
                                                                                        }
                                                                                        index++;
                                                                                        orden++;
                                                                                    }
                                                                                    if (index % 14 == 13)
                                                                                    {
                                                                                        lista_sesiones[index].Estado = 2;
                                                                                        clases_asignadas++;
                                                                                    }
                                                                                    salir = true;
                                                                                    break;
                                                                                }
                                                                            }
                                                                            //}
                                                                            if (salir || !asignable) break;
                                                                            //if (salir) break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        if (salir || !asignable) break;
                                                        //if (salir) break;
                                                    }
                                                    if (salir || !asignable) break;
                                                    //if (salir) break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            foreach (ClasePracticaInfo clase in practicas[2])
                                            {
                                                p_instructor = 0;
                                                bool asignable = true;

                                                if (clase.Incompatible > 0 && !LaboratorioLibre(lista_sesiones, instructores_asignados, i, clase.Incompatible))
                                                    continue;

                                                if (clase.Estado == 1) // aún no está programada
                                                {
                                                    bool salir = false;

                                                    foreach (InstructorInfo item in profesores)
                                                    {
                                                        foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                        {
                                                            if (promocion.OidPromocion == oid_promocion)
                                                            {
                                                                foreach (Submodulo_Instructor_PromocionInfo sub in promocion.Submodulos)
                                                                {
                                                                    if (sub.OidSubmodulo == clase.OidSubmodulo
                                                                        && sub.OidPromocion == oid_promocion)
                                                                    {
                                                                        //if (p_instructor == 0 || p_instructor > sub.Prioridad)
                                                                        if (sub.Prioridad == 1)
                                                                        {
                                                                            //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                                                            //{
                                                                            //if (disp.FechaInicio.Date.Equals(fecha.Date))
                                                                            DisponibilidadInfo disp = null;
                                                                            if (disponibilidades.TryGetValue(item.Oid, out disp))
                                                                            {
                                                                                //se comprueba que el profesor tenga las 5 horas libres
                                                                                if (disp.Semana[i] && disp.Semana[i + 1] && disp.Semana[i + 2] && disp.Semana[i + 3] && disp.Semana[i + 4]
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 2, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 3, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 4, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    /*&& Horario.PosibleAsignar(clase, _practicas)*/)
                                                                                {
                                                                                    asignable = Horario.PosibleAsignar(clase, practicas);
                                                                                    if (asignable) asignable = Horario.PosibleAsignarClase(clase, clases_teoria);
                                                                                    if (!asignable) break;
                                                                                    count += clase.Grupo;
                                                                                    clase.Estado = 2;
                                                                                    restantes--;
                                                                                    colocadas++;
                                                                                    clases_asignadas++;
                                                                                    lista_sesiones[i].AsignaClaseASesion(clase);
                                                                                    lista_sesiones[i].OidProfesor = item.Oid;
                                                                                    int index = i + 1;
                                                                                    int orden = 1;
                                                                                    while (orden < 5)
                                                                                    {
                                                                                        clases_asignadas++;
                                                                                        lista_sesiones[index].AsignaClaseASesion(clase);
                                                                                        lista_sesiones[index].OidProfesor = item.Oid;
                                                                                        index++;
                                                                                        orden++;
                                                                                    }
                                                                                    salir = true;
                                                                                    break;
                                                                                }
                                                                            }
                                                                            //}
                                                                            if (salir || !asignable) break;
                                                                            //if (salir) break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        if (salir || !asignable) break;
                                                        //if (salir) break;
                                                    }
                                                    if (salir || !asignable) break;
                                                    //if (salir) break;
                                                }
                                            }
                                            foreach (ClasePracticaInfo clase in practicas[1])
                                            {
                                                p_instructor = 0;
                                                bool asignable = true;

                                                if ((clase.Incompatible > 0 && !LaboratorioLibre(lista_sesiones, instructores_asignados, i, clase.Incompatible))
                                                    || clase.Oid == lista_sesiones[i].OidClasePractica || count == clase.Grupo)
                                                    continue;

                                                if (clase.Estado == 1) // aún no está programada
                                                {
                                                    bool salir = false;
                                                    foreach (InstructorInfo item in profesores)
                                                    {
                                                        foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                                        {
                                                            if (promocion.OidPromocion == oid_promocion)
                                                            {
                                                                foreach (Submodulo_Instructor_PromocionInfo sub in promocion.Submodulos)
                                                                {
                                                                    if (sub.OidSubmodulo == clase.OidSubmodulo
                                                                        && sub.OidPromocion == oid_promocion)
                                                                    {
                                                                        //if (p_instructor == 0 || p_instructor > sub.Prioridad)
                                                                        if (sub.Prioridad == 1)
                                                                        {
                                                                            //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                                                            //{
                                                                            //if (disp.FechaInicio.Date.Equals(fecha.Date))
                                                                            DisponibilidadInfo disp = null;
                                                                            if (disponibilidades.TryGetValue(item.Oid, out disp))
                                                                            {
                                                                                if (disp.Semana[i] && disp.Semana[i + 1] && disp.Semana[i + 2] && disp.Semana[i + 3] && disp.Semana[i + 4]
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 2, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 3, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && Horario.ProfesorLibre(instructores_asignados, i + 4, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                    && lista_sesiones[i].OidProfesor != item.Oid
                                                                                    /*&& Horario.PosibleAsignar(clase, _practicas)*/)
                                                                                {
                                                                                    asignable = Horario.PosibleAsignar(clase, practicas);
                                                                                    if (asignable) asignable = Horario.PosibleAsignarClase(clase, clases_teoria);
                                                                                    if (!asignable) break;
                                                                                    count += clase.Grupo;
                                                                                    clase.Estado = 2;
                                                                                    restantes--;
                                                                                    colocadas++;
                                                                                    int index = i + 1;
                                                                                    int orden = 1;
                                                                                    while (orden < 5)
                                                                                    {
                                                                                        if (index % 2 == 0)
                                                                                        {
                                                                                            lista_sesiones[index].AsignaClaseASesion(clase);
                                                                                            lista_sesiones[index].OidProfesor = item.Oid;
                                                                                        }
                                                                                        index++;
                                                                                        orden++;
                                                                                    }
                                                                                    if (index % 14 == 13)
                                                                                    {
                                                                                        lista_sesiones[index].Estado = 2;
                                                                                        clases_asignadas++;
                                                                                    }
                                                                                    salir = true;
                                                                                    break;
                                                                                }
                                                                            }
                                                                            //}
                                                                            if (salir || !asignable) break;
                                                                            //if (salir) break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        if (salir || !asignable) break;
                                                        //if (salir) break;
                                                    }
                                                    if (salir || !asignable) break;
                                                    //if (salir) break;
                                                }
                                            } 
                                        }
                                        if (count > 0)
                                            exponente = -exponente;
                                        if (count > 0 && count < 3)
                                        {
                                            //LiberarClase(i, lista_sesiones, _practicas, _teoria, null);
                                            //lista_sesiones[i].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                            //lista_sesiones[i + 1].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                            //lista_sesiones[i + 2].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                            //lista_sesiones[i + 3].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                            //lista_sesiones[i + 4].AsignaClaseASesion((ClaseTeoricaInfo)null);
                                            //colocadas--;
                                            //restantes++;
                                            //clases_asignadas -= 5;
                                            int index_clase;
                                            for (index_clase = i; index_clase < i+5; index_clase++)
                                            {
                                                if (lista_sesiones[index_clase].OidClasePractica != 0)
                                                    break;
                                            }
                                            for (int k = i; k < i+5; k++)
                                            {
                                                if (lista_sesiones[k].OidClasePractica == 0)
                                                    lista_sesiones[k].Copia(lista_sesiones[index_clase],true);
                                            } 
                                            if ((i+5)%14 == 13)
                                            {
                                                lista_sesiones[i+5].Estado = 2;
                                                clases_asignadas++;
                                            }
                                            colocadas++;
                                            restantes--;
                                            count = 0;
                                        }
                                    }
                                    if (i % 14 == 8) i += 5;
                                    else i++;
                                }
                            }
                        }
                    }
                }

                //TEORICAS
                p_instructor = 1;
                int iteracion = 0;
                while (clases_asignadas < 75 && p_instructor < 4)
                {
                    foreach (ClaseTeoricaInfo clase in clases_teoria)
                    {
                        if (clase.Estado == 1) // aún no está programada
                        {
                            if (!Horario.PosibleAsignar(clase, clases_teoria))
                                break;
                            foreach (SesionAuxiliar obj in lista_sesiones)
                            {
                                if (obj.Estado == 1 && obj.Activa)
                                {
                                    bool asignable = true;
                                    bool no_repetido = true;
                                    foreach (InstructorInfo item in profesores)
                                    {
                                        bool salir = false;
                                        foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                        {
                                            if (promocion.OidPromocion == oid_promocion)
                                            {
                                                foreach (Submodulo_Instructor_PromocionInfo sub in promocion.Submodulos)
                                                {
                                                    if (sub.OidSubmodulo == clase.OidSubmodulo
                                                       && sub.OidPromocion == oid_promocion)
                                                    {
                                                        //if (sub.Prioridad <= p_instructor || p_instructor == 3)
                                                        if (sub.Prioridad == 1 && profesores_encargados.ProfesorEncargado(clase.OidSubmodulo, item.Oid, false))
                                                        {
                                                            //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                                            //{
                                                            //if (disp.FechaInicio.Date.Equals(fecha.Date))
                                                            DisponibilidadInfo disp = null;
                                                            if (disponibilidades.TryGetValue(item.Oid, out disp))
                                                            {
                                                                if (disp.Semana[lista_sesiones.IndexOf(obj)] == true
                                                                    && Horario.ProfesorLibre(instructores_asignados, lista_sesiones.IndexOf(obj), item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                {
                                                                    //llegado a este punto sería posible asignar la clase al hueco
                                                                    //ahora habría que comprobar varias cosas:
                                                                    //vemos en que posicion está intentando meter la clase
                                                                    int index = lista_sesiones.IndexOf(obj); //en general
                                                                    int index_dia = index; //con respecto al dia
                                                                    while (index_dia > 13)
                                                                        index_dia -= 14;
                                                                    if ((lista_2.Contains(index_dia) && index < 70) || lista_2.Contains(index))
                                                                    {
                                                                        //es un hueco de dos horas
                                                                        if (index > 14 && index_dia > 9)
                                                                        {
                                                                            if (clase.OidSubmodulo == lista_sesiones[index - 14].OidSubmodulo
                                                                                || item.Oid == lista_sesiones[index - 14].OidProfesor)
                                                                            {
                                                                                asignable = false;
                                                                                //break;
                                                                            }
                                                                        }
                                                                        //se comprueba que haya una clase posterior a esta del mismo submodulo
                                                                        if (clase.OrdenTerciario < clase.TotalClases && asignable) //hay clases posteriores 
                                                                        {
                                                                            //se comprueba que el profesor tenga libre la hora siguiente
                                                                            if (disp.Semana[index + 1]
                                                                                && ProfesorLibre(instructores_asignados, index + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))//el instructor está libre
                                                                            {
                                                                                //hay que comprobar que no se haya dado algo del mismo módulo en el mismo dia
                                                                                //ni que haya dado clase el mismo profesor
                                                                                int index_semana = index;
                                                                                while (index_semana % 14 != 0)
                                                                                    index_semana--;
                                                                                int contador = 0;
                                                                                while (contador < 14 && no_repetido)
                                                                                {
                                                                                    /*if (clase.OidModulo == lista_sesiones[index_semana + contador].OidModulo
                                                                                        && item.Oid == lista_sesiones[index_semana + contador].OidProfesor
                                                                                        && index_semana + contador != index)
                                                                                        no_repetido = false;*/
                                                                                    contador++;
                                                                                }
                                                                                //if (!no_repetido)
                                                                                //    break;
                                                                                if (no_repetido)
                                                                                {
                                                                                    //se asigna la clase siguiente al hueco siguiente
                                                                                    clase.Estado = 2;
                                                                                    clases_asignadas++;
                                                                                    obj.AsignaClaseASesion(clase);
                                                                                    obj.OidProfesor = item.Oid;
                                                                                    ClaseTeoricaInfo clase_aux = null;
                                                                                    foreach (ClaseTeoricaInfo aux in clases_teoria)
                                                                                    {
                                                                                        if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                                            && clase.OrdenTerciario == aux.OrdenTerciario - 1
                                                                                            && clase.TotalClases == aux.TotalClases
                                                                                            && aux.Estado == 1)
                                                                                        {
                                                                                            clase_aux = aux;
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                    if (clase_aux != null)
                                                                                    {
                                                                                        clase_aux.Estado = 2;
                                                                                        clases_asignadas++;
                                                                                        lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                                        lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                                    }
                                                                                    salir = true;
                                                                                }
                                                                                //break;
                                                                            }
                                                                        }
                                                                    }
                                                                    if ((lista_3.Contains(index_dia) && index < 70) || lista_3.Contains(index))
                                                                    {
                                                                        //es un hueco de tres horas
                                                                        if (index > 14 && index_dia > 9)
                                                                        {
                                                                            if (clase.OidSubmodulo == lista_sesiones[index - 14].OidSubmodulo
                                                                                || item.Oid == lista_sesiones[index - 14].OidProfesor)
                                                                            {
                                                                                asignable = false;
                                                                                //break;
                                                                            }
                                                                        }
                                                                        //es el primer hueco de alguna de las clases de dos horas de por la mañana
                                                                        //se comprueba que haya una clase posterior a esta del mismo submodulo
                                                                        if (clase.OrdenTerciario < clase.TotalClases - 1 && asignable) //hay clases posteriores 
                                                                        {
                                                                            //se comprueba que el profesor tenga libre la hora siguiente
                                                                            if (disp.Semana[index + 1] && disp.Semana[index + 2]
                                                                                && ProfesorLibre(instructores_asignados, index + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades)
                                                                                && ProfesorLibre(instructores_asignados, index + 2, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))//el instructor está libre
                                                                            {
                                                                                //hay que comprobar que no se haya dado algo del mismo módulo en el mismo dia
                                                                                int index_semana = index;
                                                                                while (index_semana % 14 != 0)
                                                                                    index_semana--;
                                                                                int contador = 0;
                                                                                while (contador < 14 && no_repetido)
                                                                                {
                                                                                    /*if (index_semana + contador < 75
                                                                                        && clase.OidModulo == lista_sesiones[index_semana + contador].OidModulo
                                                                                        && item.Oid == lista_sesiones[index_semana + contador].OidProfesor
                                                                                        && index_semana + contador != index)
                                                                                        no_repetido = false;*/
                                                                                    contador++;
                                                                                }
                                                                                //if (!no_repetido)
                                                                                //    break;
                                                                                if (no_repetido)
                                                                                {
                                                                                    //se asigna la clase siguiente al hueco siguiente
                                                                                    clase.Estado = 2;
                                                                                    clases_asignadas++;
                                                                                    obj.AsignaClaseASesion(clase);
                                                                                    obj.OidProfesor = item.Oid;
                                                                                    ClaseTeoricaInfo clase_aux = null;
                                                                                    foreach (ClaseTeoricaInfo aux in clases_teoria)
                                                                                    {
                                                                                        if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                                            && clase.OrdenTerciario == aux.OrdenTerciario - 1
                                                                                            && clase.TotalClases == aux.TotalClases
                                                                                            && aux.Estado == 1)
                                                                                        {
                                                                                            clase_aux = aux;
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                    if (clase_aux != null)
                                                                                    {
                                                                                        clase_aux.Estado = 2;
                                                                                        clases_asignadas++;
                                                                                        lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                                        lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                                    }
                                                                                    ClaseTeoricaInfo clase_aux2 = null;
                                                                                    foreach (ClaseTeoricaInfo aux in clases_teoria)
                                                                                    {
                                                                                        if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                                            && clase.OrdenTerciario == aux.OrdenTerciario - 2
                                                                                            && clase.TotalClases == aux.TotalClases
                                                                                            && aux.Estado == 1)
                                                                                        {
                                                                                            clase_aux2 = aux;
                                                                                            break;
                                                                                        }
                                                                                    }
                                                                                    if (clase_aux2 != null)
                                                                                    {
                                                                                        clase_aux2.Estado = 2;
                                                                                        clases_asignadas++;
                                                                                        lista_sesiones[index + 2].AsignaClaseASesion(clase_aux2);
                                                                                        lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                    }
                                                                                    salir = true;
                                                                                }
                                                                                //break;
                                                                            }
                                                                        }
                                                                    }
                                                                    if ((lista_1.Contains(index_dia) && index < 70) || lista_1.Contains(index))
                                                                    {
                                                                        //es un hueco de una hora
                                                                        if (index > 14 && index_dia > 9)
                                                                        {
                                                                            if (clase.OidSubmodulo == lista_sesiones[index - 14].OidSubmodulo
                                                                                || item.Oid == lista_sesiones[index - 14].OidProfesor)
                                                                            {
                                                                                asignable = false;
                                                                                //break;
                                                                            }
                                                                        }
                                                                        if (asignable)
                                                                        {
                                                                            //se asigna la clase siguiente al hueco siguiente
                                                                            clase.Estado = 2;
                                                                            clases_asignadas++;
                                                                            obj.AsignaClaseASesion(clase);
                                                                            obj.OidProfesor = item.Oid;

                                                                            salir = true;
                                                                        }
                                                                        //break;
                                                                    }
                                                                }
                                                            }
                                                            //}
                                                            if (salir || !no_repetido || !asignable) break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (salir || !no_repetido || !asignable) break;
                                    }
                                    if (clase.Estado == 2 || clases_asignadas == 75) break;
                                }
                            }
                        }
                    }
                    if (iteracion == 1)
                    {
                        iteracion = 0;
                        p_instructor++;
                    }
                    else iteracion++;
                }
                OrdenaHorario(75, lista_sesiones, profesores, instructores_asignados, fecha, oid_promocion, disponibilidades);

                p_instructor = 1;
                while (clases_asignadas < 75 && p_instructor < 4)
                {
                    foreach (ClaseTeoricaInfo clase in clases_teoria)
                    {
                        if (clase.Estado == 1 && Horario.PosibleAsignar(clase, clases_teoria)) // aún no está programada
                        {
                            foreach (SesionAuxiliar obj in lista_sesiones)
                            {
                                if (obj.Estado == 1 && obj.Activa)
                                {
                                    //bool asignable = true;
                                    bool no_repetido = true;
                                    foreach (InstructorInfo item in profesores)
                                    {
                                        bool salir = false;
                                        foreach (Instructor_PromocionInfo promocion in item.Promociones)
                                        {
                                            if (promocion.OidPromocion == oid_promocion)
                                            {
                                                foreach (Submodulo_Instructor_PromocionInfo sub in promocion.Submodulos)
                                                {
                                                    if (sub.OidSubmodulo == clase.OidSubmodulo
                                                            && sub.OidPromocion == oid_promocion)
                                                    {
                                                        if (sub.Prioridad == 1)
                                                        {
                                                            //foreach (DisponibilidadInfo disp in item.Disponibilidades)
                                                            //{
                                                            //if (disp.FechaInicio.Date.Equals(fecha.Date))
                                                            DisponibilidadInfo disp = null;
                                                            if (disponibilidades.TryGetValue(item.Oid, out disp))
                                                            {
                                                                if (disp.Semana[lista_sesiones.IndexOf(obj)] == true
                                                                    && Horario.ProfesorLibre(instructores_asignados, lista_sesiones.IndexOf(obj), item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                {
                                                                    //asignable = Horario.PosibleAsignar(clase, _teoria);
                                                                    //if (!asignable) break;                                                            //llegado a este punto sería posible asignar la clase al hueco
                                                                    //ahora habría que comprobar varias cosas:
                                                                    //vemos en que posicion está intentando meter la clase
                                                                    int index = lista_sesiones.IndexOf(obj); //en general
                                                                    int index_dia = index; //con respecto al dia
                                                                    while (index_dia > 13)
                                                                        index_dia -= 14;
                                                                    //hay que comprobar que no se haya dado algo del mismo módulo en el mismo dia
                                                                    //ni que haya dado clase el mismo profesor
                                                                    int index_semana = index;
                                                                    while (index_semana % 14 != 0)
                                                                        index_semana--;
                                                                    int contador = 0;
                                                                    while (contador < 14 && no_repetido && contador + index_semana < 75)
                                                                    {
                                                                        /*if (clase.OidModulo == lista_sesiones[index_semana + contador].OidModulo
                                                                            && item.Oid == lista_sesiones[index_semana + contador].OidProfesor
                                                                            && index_semana + contador != index)
                                                                            no_repetido = false;*/
                                                                        contador++;
                                                                    }
                                                                    //if (!no_repetido)
                                                                    //    break;
                                                                    if (no_repetido)
                                                                    {
                                                                        //si es alguna de las sesiones de los huecos de dos horas
                                                                        if ((lista_2.Contains(index_dia) && index < 70) || (lista_2.Contains(index_dia - 1) && index - 1 < 70)
                                                                            || lista_2.Contains(index) || lista_2.Contains(index - 1))
                                                                        {
                                                                            //es una clase de la mañana
                                                                            //se asigna la clase
                                                                            clase.Estado = 2;
                                                                            clases_asignadas++;
                                                                            obj.AsignaClaseASesion(clase);
                                                                            obj.OidProfesor = item.Oid;
                                                                            salir = true;
                                                                            //si no es la ultima clase de las dos y la siguiente también está libre
                                                                            //se intenta asignar una clase del mismo submodulo
                                                                            if (clase.OrdenTerciario < clase.TotalClases) //hay clases posteriores 
                                                                            {
                                                                                if ((lista_2.Contains(index) || (lista_2.Contains(index_dia) && index < 70)) && lista_sesiones[index + 1].Estado == 1)
                                                                                {
                                                                                    //se comprueba que el profesor tenga libre la hora siguiente
                                                                                    if (disp.Semana[index + 1]
                                                                                        && ProfesorLibre(instructores_asignados, index + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))//el instructor está libre
                                                                                    {
                                                                                        ClaseTeoricaInfo clase_aux = null;
                                                                                        foreach (ClaseTeoricaInfo aux in clases_teoria)
                                                                                        {
                                                                                            if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                                                && clase.OrdenTerciario == aux.OrdenTerciario - 1
                                                                                                && clase.TotalClases == aux.TotalClases
                                                                                                && aux.Estado == 1)
                                                                                            {
                                                                                                clase_aux = aux;
                                                                                                break;
                                                                                            }
                                                                                        }
                                                                                        if (clase_aux != null)
                                                                                        {
                                                                                            clase_aux.Estado = 2;
                                                                                            clases_asignadas++;
                                                                                            lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                                            lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                //intentar buscar un submodulo del mismo modulo que la clase asignada
                                                                                //con un orden secundario superior, que el instructor sea el mismo e
                                                                                //intentar asignarla al hueco
                                                                                ClaseTeoricaInfo cl_aux = null;
                                                                                foreach (ClaseTeoricaInfo clase_aux in clases_teoria)
                                                                                {
                                                                                    if (clase_aux.OidModulo == clase.OidModulo
                                                                                        && clase_aux.OidSubmodulo != clase.OidSubmodulo
                                                                                        && clase_aux.OrdenSecundario >= clase.OrdenSecundario
                                                                                        && clase_aux.Estado == 1)
                                                                                    {
                                                                                        cl_aux = clase_aux;
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                if (cl_aux != null)
                                                                                {
                                                                                    bool capacitado = false;
                                                                                    foreach (Instructor_PromocionInfo pr in item.Promociones)
                                                                                    {
                                                                                        if (pr.OidPromocion == oid_promocion)
                                                                                        {
                                                                                            foreach (Submodulo_Instructor_PromocionInfo info in pr.Submodulos)
                                                                                            {
                                                                                                if (info.OidSubmodulo == cl_aux.OidSubmodulo)
                                                                                                {
                                                                                                    capacitado = true;
                                                                                                    break;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    if (capacitado)
                                                                                    {
                                                                                        if (disp.Semana[index + 1] && lista_sesiones[index + 1].Estado == 1
                                                                                            && ProfesorLibre(instructores_asignados, index + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                                        {
                                                                                            cl_aux.Estado = 2;
                                                                                            clases_asignadas++;
                                                                                            lista_sesiones[index + 1].AsignaClaseASesion(cl_aux);
                                                                                            lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            //break;
                                                                        }
                                                                        else
                                                                        {
                                                                            //es una clase de tres horas
                                                                            //se asigna la clase
                                                                            clase.Estado = 2;
                                                                            clases_asignadas++;
                                                                            obj.AsignaClaseASesion(clase);
                                                                            obj.OidProfesor = item.Oid;
                                                                            salir = true;
                                                                            //si no es la última clase de las tres
                                                                            //se intenta asignar una clase del mismo submodulo
                                                                            if (clase.OrdenTerciario < clase.TotalClases) //hay clases posteriores 
                                                                            {
                                                                                if (((lista_3.Contains(index_dia - 1) && index - 1 < 70) || (lista_3.Contains(index_dia) && index < 70)
                                                                                    || lista_3.Contains(index - 1) || lista_3.Contains(index)) && lista_sesiones[index + 1].Estado == 1)
                                                                                {
                                                                                    //se comprueba que el profesor tenga libre la hora siguiente
                                                                                    if (disp.Semana[index + 1]
                                                                                        && ProfesorLibre(instructores_asignados, index + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))//el instructor está libre
                                                                                    {
                                                                                        ClaseTeoricaInfo clase_aux = null;
                                                                                        foreach (ClaseTeoricaInfo aux in clases_teoria)
                                                                                        {
                                                                                            if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                                                && clase.OrdenTerciario == aux.OrdenTerciario - 1
                                                                                                && clase.TotalClases == aux.TotalClases
                                                                                                && aux.Estado == 1)
                                                                                            {
                                                                                                clase_aux = aux;
                                                                                                break;
                                                                                            }
                                                                                        }
                                                                                        if (clase_aux != null)
                                                                                        {
                                                                                            clase_aux.Estado = 2;
                                                                                            clases_asignadas++;
                                                                                            lista_sesiones[index + 1].AsignaClaseASesion(clase_aux);
                                                                                            lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                                        }
                                                                                    }
                                                                                }
                                                                                if (clase.OrdenTerciario < clase.TotalClases - 1) //hay clases posteriores 
                                                                                {
                                                                                    if (((lista_3.Contains(index_dia) && index < 70) || lista_3.Contains(index)) && lista_sesiones[index + 2].Estado == 1)
                                                                                    {
                                                                                        //se comprueba que el profesor tenga libre la hora siguiente
                                                                                        if (disp.Semana[index + 2]
                                                                                            && ProfesorLibre(instructores_asignados, index + 2, item.Oid, lista_sesiones, profesores, -2, fecha, disponibilidades))//el instructor está libre
                                                                                        {
                                                                                            ClaseTeoricaInfo clase_aux2 = null;
                                                                                            foreach (ClaseTeoricaInfo aux in clases_teoria)
                                                                                            {
                                                                                                if (clase.OidSubmodulo == aux.OidSubmodulo
                                                                                                    && clase.OrdenTerciario == aux.OrdenTerciario - 2
                                                                                                    && clase.TotalClases == aux.TotalClases
                                                                                                    && aux.Estado == 1)
                                                                                                {
                                                                                                    clase_aux2 = aux;
                                                                                                    break;
                                                                                                }
                                                                                            }
                                                                                            if (clase_aux2 != null)
                                                                                            {
                                                                                                clase_aux2.Estado = 2;
                                                                                                clases_asignadas++;
                                                                                                lista_sesiones[index + 2].AsignaClaseASesion(clase_aux2);
                                                                                                lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    //intentar buscar un submodulo del mismo modulo que la clase asignada
                                                                                    //con un orden secundario superior, que el instructor sea el mismo e
                                                                                    //intentar asignarla al hueco
                                                                                    if (((lista_3.Contains(index_dia - 1) && index - 1 < 70) || (lista_3.Contains(index_dia) && index < 70)
                                                                                    || lista_3.Contains(index - 1) || lista_3.Contains(index)) && lista_sesiones[index + 2].Estado == 1)
                                                                                    {
                                                                                        ClaseTeoricaInfo cl_aux = null;
                                                                                        foreach (ClaseTeoricaInfo clase_aux in clases_teoria)
                                                                                        {
                                                                                            if (clase_aux.OidModulo == clase.OidModulo
                                                                                                && clase_aux.OidSubmodulo != clase.OidSubmodulo
                                                                                                && clase_aux.OrdenSecundario >= clase.OrdenSecundario
                                                                                                && clase_aux.Estado == 1)
                                                                                            {
                                                                                                cl_aux = clase_aux;
                                                                                                break;
                                                                                            }
                                                                                        }
                                                                                        if (cl_aux != null)
                                                                                        {
                                                                                            bool capacitado = false;
                                                                                            foreach (Instructor_PromocionInfo pr in item.Promociones)
                                                                                            {
                                                                                                if (pr.OidPromocion == oid_promocion)
                                                                                                {
                                                                                                    foreach (Submodulo_Instructor_PromocionInfo info in pr.Submodulos)
                                                                                                    {
                                                                                                        if (info.OidSubmodulo == cl_aux.OidSubmodulo)
                                                                                                        {
                                                                                                            capacitado = true;
                                                                                                            break;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            if (capacitado)
                                                                                            {
                                                                                                if (disp.Semana[index + 2] && lista_sesiones[index + 2].Estado == 1
                                                                                                    && ProfesorLibre(instructores_asignados, index + 2, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                                                {
                                                                                                    cl_aux.Estado = 2;
                                                                                                    clases_asignadas++;
                                                                                                    lista_sesiones[index + 2].AsignaClaseASesion(cl_aux);
                                                                                                    lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                //intentar buscar un submodulo del mismo modulo que la clase asignada
                                                                                //con un orden secundario superior, que el instructor sea el mismo e
                                                                                //intentar asignarla al hueco
                                                                                ClaseTeoricaInfo cl_aux = null;
                                                                                foreach (ClaseTeoricaInfo clase_aux in clases_teoria)
                                                                                {
                                                                                    if (clase_aux.OidModulo == clase.OidModulo
                                                                                        && clase_aux.OidSubmodulo != clase.OidSubmodulo
                                                                                        && clase_aux.OrdenSecundario >= clase.OrdenSecundario
                                                                                        && clase_aux.Estado == 1)
                                                                                    {
                                                                                        cl_aux = clase_aux;
                                                                                        break;
                                                                                    }
                                                                                }
                                                                                if (cl_aux != null)
                                                                                {
                                                                                    bool capacitado = false;
                                                                                    foreach (Instructor_PromocionInfo pr in item.Promociones)
                                                                                    {
                                                                                        if (pr.OidPromocion == oid_promocion)
                                                                                        {
                                                                                            foreach (Submodulo_Instructor_PromocionInfo info in pr.Submodulos)
                                                                                            {
                                                                                                if (info.OidSubmodulo == cl_aux.OidSubmodulo)
                                                                                                {
                                                                                                    capacitado = true;
                                                                                                    break;
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    if (capacitado)
                                                                                    {
                                                                                        if (disp.Semana[index + 1] && lista_sesiones[index + 1].Estado == 1
                                                                                            && ProfesorLibre(instructores_asignados, index + 1, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))
                                                                                        {
                                                                                            cl_aux.Estado = 2;
                                                                                            clases_asignadas++;
                                                                                            lista_sesiones[index + 1].AsignaClaseASesion(cl_aux);
                                                                                            lista_sesiones[index + 1].OidProfesor = item.Oid;
                                                                                            if (cl_aux.OrdenTerciario < cl_aux.TotalClases)
                                                                                            {
                                                                                                if (((lista_3.Contains(index_dia) && index < 70) || lista_3.Contains(index)) && lista_sesiones[index + 2].Estado == 1)
                                                                                                {
                                                                                                    //se comprueba que el profesor tenga libre la hora siguiente
                                                                                                    if (disp.Semana[index + 2]
                                                                                                        && ProfesorLibre(instructores_asignados, index + 2, item.Oid, lista_sesiones, profesores, -1, fecha, disponibilidades))//el instructor está libre
                                                                                                    {
                                                                                                        ClaseTeoricaInfo clase_aux2 = null;
                                                                                                        foreach (ClaseTeoricaInfo aux in clases_teoria)
                                                                                                        {
                                                                                                            if (cl_aux.OidSubmodulo == aux.OidSubmodulo
                                                                                                                && cl_aux.OrdenTerciario == aux.OrdenTerciario - 1
                                                                                                                && cl_aux.TotalClases == aux.TotalClases
                                                                                                                && aux.Estado == 1)
                                                                                                            {
                                                                                                                clase_aux2 = aux;
                                                                                                                break;
                                                                                                            }
                                                                                                        }
                                                                                                        if (clase_aux2 != null)
                                                                                                        {
                                                                                                            clase_aux2.Estado = 2;
                                                                                                            clases_asignadas++;
                                                                                                            lista_sesiones[index + 2].AsignaClaseASesion(clase_aux2);
                                                                                                            lista_sesiones[index + 2].OidProfesor = item.Oid;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            //break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            //}
                                                            if (salir || !no_repetido) break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (salir || !no_repetido) break;
                                    }
                                    if (clase.Estado == 2 || clases_asignadas == 75) break;
                                }
                            }
                        }
                    }
                    if (iteracion == 1)
                    {
                        iteracion = 0;
                        p_instructor++;
                    }
                    else iteracion++;
                }
                OrdenaHorario(75, lista_sesiones, profesores, instructores_asignados, fecha, oid_promocion, disponibilidades);
                intento++;
            }

            t.Record("Bucle principal " + clases_asignadas.ToString());

            if (clases_asignadas < 75)
                RellenaLibres(clases_teoria, profesores, lista_sesiones, instructores_asignados, fecha, no_asignables, oid_promocion, lista_3, lista_2, lista_1, dias_suplente, profesores_encargados, disponibilidades);

            t.Record("rellena libres " + clases_asignadas.ToString());

            OrdenaHorario(75, lista_sesiones, profesores, instructores_asignados, fecha, oid_promocion, disponibilidades);
            t.Record("ordena horario");

            //recorre la lista de sesiones asignadas marcando las que no cumplen las prioridades
            int y = 1;
            while (y < 75)
            {
                for (int j = y - 1; j >= 0; j--)
                {
                    if (((lista_sesiones[y].OidModulo == lista_sesiones[j].OidModulo
                        && lista_sesiones[y].OrdenPrimario == lista_sesiones[j].OrdenPrimario
                        && lista_sesiones[y].OrdenSecundario < lista_sesiones[j].OrdenSecundario)
                        || (lista_sesiones[y].OidSubmodulo == lista_sesiones[j].OidSubmodulo
                        && lista_sesiones[y].OrdenSecundario == lista_sesiones[j].OrdenSecundario
                        && lista_sesiones[y].OrdenTerciario < lista_sesiones[j].OrdenTerciario))
                        && !lista_sesiones[j].Forzada
                        && !lista_sesiones[y].Forzada
                        && lista_sesiones[j].Estado > 1 && lista_sesiones[y].Estado > 1)
                    {
                        lista_sesiones[j].Desordenada = true;
                    }
                }
                y++;
            }
            t.Record("bucle desordenadas");
        }

        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            return "SELECT H.*," +
                   "       PL.\"NOMBRE\" AS \"PLAN\"," +
                   "       PR.\"NOMBRE\" AS \"PROMOCION\"";
        }

        internal static string SELECT(long oid, bool lock_table)
        {
            string h = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string pl = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string pr = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            string query;

            query = Horario.SELECT_FIELDS() +
                    " FROM " + h + " AS H" +
                    " INNER JOIN " + pl + " AS PL ON (PL.\"OID\" = H.\"OID_PLAN\") " +
                    " INNER JOIN " + pr + " AS PR ON (PR.\"OID\" = H.\"OID_PROMOCION\")";

            if (oid > 0) query += " WHERE H.\"OID\" = " + oid.ToString();

            if (lock_table) query += " FOR UPDATE OF H NOWAIT";

            return query;
        }

        public new static string SELECT(long oid) { return Horario.SELECT(oid, true); }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_BY_PLAN_BY_PROMOCION(long oid_plan, long oid_promocion, DateTime fecha)
        {
            string h = nHManager.Instance.GetSQLTable(typeof(HorarioRecord));
            string pl = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string pr = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string f = fecha.Year.ToString("0000") + "-" + fecha.Month.ToString("00") + "-" + fecha.Day.ToString("00");

            string query;

            query = Horario.SELECT(0, false) +
                    " WHERE H.\"OID_PLAN\" = " + oid_plan.ToString() +
                    " AND H.\"OID_PROMOCION\" = " + oid_promocion.ToString() +
                    " AND H.\"FECHA_INICIAL\" >= '" + f + "'" +
                    " ORDER BY H.\"FECHA_INICIAL\"";

            //query += " FOR UPDATE OF H NOWAIT";

            return query;
        }

        #endregion

    }
}

