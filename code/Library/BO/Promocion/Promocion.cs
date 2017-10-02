using System;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Collections.Generic;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class PromocionRecord : RecordBase
	{
		#region Attributes

		private long _oid_plan;
		private string _nombre = string.Empty;
		private string _numero = string.Empty;
		private string _observaciones = string.Empty;
		private DateTime _fecha_inicio;
		private DateTime _fecha_fin;
		private DateTime _inicio_clases;
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
		private long _oid_plan_extra;
  
		#endregion
		
		#region Properties
		
				public virtual long OidPlan { get { return _oid_plan; } set { _oid_plan = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual string Numero { get { return _numero; } set { _numero = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual DateTime FechaInicio { get { return _fecha_inicio; } set { _fecha_inicio = value; } }
		public virtual DateTime FechaFin { get { return _fecha_fin; } set { _fecha_fin = value; } }
		public virtual DateTime InicioClases { get { return _inicio_clases; } set { _inicio_clases = value; } }
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
		public virtual long OidPlanExtra { get { return _oid_plan_extra; } set { _oid_plan_extra = value; } }

		#endregion
		
		#region Business Methods
		
		public PromocionRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_plan = Format.DataReader.GetInt64(source, "OID_PLAN");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_numero = Format.DataReader.GetString(source, "NUMERO");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_fecha_inicio = Format.DataReader.GetDateTime(source, "FECHA_INICIO");
			_fecha_fin = Format.DataReader.GetDateTime(source, "FECHA_FIN");
			_inicio_clases = Format.DataReader.GetDateTime(source, "INICIO_CLASES");
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
			_oid_plan_extra = Format.DataReader.GetInt64(source, "OID_PLAN_EXTRA");

		}		
		public virtual void CopyValues(PromocionRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_plan = source.OidPlan;
			_nombre = source.Nombre;
			_numero = source.Numero;
			_observaciones = source.Observaciones;
			_fecha_inicio = source.FechaInicio;
			_fecha_fin = source.FechaFin;
			_inicio_clases = source.InicioClases;
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
			_oid_plan_extra = source.OidPlanExtra;
		}
		
		#endregion	
	}

    [Serializable()]
	public class PromocionBase 
	{	 
		#region Attributes
		
		private PromocionRecord _record = new PromocionRecord();
		
		#endregion
		
		#region Properties
		
		public PromocionRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Promocion source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(PromocionInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Promocion : BusinessBaseEx<Promocion>
	{	 
		#region Attributes
		
		protected PromocionBase _base = new PromocionBase();

        private Alumnos_Promociones _alumnos = Alumnos_Promociones.NewChildList();
        private Sesiones_Promociones _sesiones = Sesiones_Promociones.NewChildList();
		

		#endregion
		
		#region Properties
		
		public PromocionBase Base { get { return _base; } }
		
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
		public virtual string Nombre
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Nombre;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Nombre.Equals(value))
				{
					_base.Record.Nombre = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Numero
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Numero;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Numero.Equals(value))
				{
					_base.Record.Numero = value;
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
				//CanWriteProperty(true);
				
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
				//CanWriteProperty(true);
				
				if (!_base.Record.FechaFin.Equals(value))
				{
					_base.Record.FechaFin = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime InicioClases
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.InicioClases;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.InicioClases.Equals(value))
				{
					_base.Record.InicioClases = value;
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
		public virtual long OidPlanExtra
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPlanExtra;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPlanExtra.Equals(value))
				{
					_base.Record.OidPlanExtra = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual Alumnos_Promociones Alumnos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _alumnos;
            }

            set
            {
                _alumnos = value;
            }
        }
        public virtual Sesiones_Promociones Sesiones
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
        
        public override bool IsValid
        {
            get { return base.IsValid && _alumnos.IsValid && _sesiones.IsValid/*&& _examenes.IsValid && _horarios.IsValid*/; }
        }
        public override bool IsDirty
        {
            get { return base.IsDirty || _alumnos.IsDirty || _sesiones.IsDirty/*|| _examenes.IsDirty || _horarios.IsDirty*/; }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Promocion CloneAsNew()
		{
			Promocion clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Promocion.OpenSession();
			Promocion.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(PromocionInfo source)
		{
			if (source == null) return;

            _base.CopyValues(source);
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPlan", 1));

        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.PROMOCION);
        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.PROMOCION);
        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.PROMOCION);
        }

        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.PROMOCION);
        }

        #endregion

        #region Common Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        protected Promocion() { }

        public virtual PromocionInfo GetInfo(bool get_childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new PromocionInfo(this, get_childs);
        }

        public virtual PromocionInfo GetInfo()
        {
            return GetInfo(true);
        }

        #endregion

        #region Root Factory Methods

        public static Promocion New()
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return DataPortal.Create<Promocion>(new CriteriaCs(-1));
        }

        public static Promocion Get(long oid, bool childs)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            CriteriaEx criteria = Promocion.GetCriteria(Promocion.OpenSession());
            
            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Promocion.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

            criteria.Childs = childs;
            Promocion.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Promocion>(criteria);
        }

        public static Promocion Get(long oid)
        {
            return Get(oid, false);
        }

        public static Promocion Get(CriteriaEx criteria)
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Promocion.BeginTransaction(criteria.Session);
            return DataPortal.Fetch<Promocion>(criteria);
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
        /// Elimina todas los Promocions
        /// </summary>
        public static void DeleteAll()
        {
            //Iniciamos la conexion y la transaccion
            int sessCode = Promocion.OpenSession();
            ISession sess = Promocion.Session(sessCode);
            ITransaction trans = Promocion.BeginTransaction(sessCode);

            try
            {
                sess.Delete("from Promocion");
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                Promocion.CloseSession(sessCode);
            }
        }

        public override Promocion Save()
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

                //_examenes.Update(this);
                _alumnos.Update(this);
                _sesiones.Update(this);
                //_horarios.Update(this);

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

        private Promocion(Promocion source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Promocion(IDataReader reader, bool childs)
        {
            MarkAsChild();
            Childs = childs;
            Fetch(reader);
        }

        public static Promocion NewChild(PlanEstudios parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Promocion obj = new Promocion();
            obj.OidPlan = parent.Oid;
            return obj;
        }

        internal static Promocion GetChild(Promocion source)
        {
            return new Promocion(source);
        }

        internal static Promocion GetChild(IDataReader reader, bool childs)
        {
            return new Promocion(reader, childs);
        }


        internal static Promocion GetChild(IDataReader reader)
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

        public void LoadChilds(Type type, bool get_childs = false)
        {
            if (type.Equals(typeof(Alumno_Promocion)))
            {
                _alumnos = Alumnos_Promociones.GetChildList(this, get_childs);
            }
            else if (type.Equals(typeof(Sesion_Promocion)))
                _sesiones = Sesiones_Promociones.GetChildList(this, get_childs);
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

        private void Fetch(Promocion source)
        {
            try
            {
                SessionCode = source.SessionCode;

                _base.CopyValues(source);

                 //criteria = Examen.GetCriteria(Session());
                //criteria.AddEq("OidPromocion", this.Oid);
                //_examenes = Examens.GetChildList(criteria.List<Examen>());

                CriteriaEx criteria = Alumno_Promocion.GetCriteria(Session());
                criteria.AddEq("OidPromocion", this.Oid);
                _alumnos = Alumnos_Promociones.GetChildList(criteria.List<Alumno_Promocion>());

                criteria = Sesion_Promocion.GetCriteria(Session());
                criteria.AddEq("OidPromocion", this.Oid);
                criteria.AddEq("Tipo", 1);
                _sesiones = Sesiones_Promociones.GetChildList(criteria.List<Sesion_Promocion>());

                //criteria = Horario.GetCriteria(Session());
                //criteria.AddEq("OidPromocion", this.Oid);
                //_horarios = Horarios.GetChildList(criteria.List<Horario>());


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

                if (Childs)
                {

                    Alumno.DoLOCK( Session());

                    string query = Alumnos_Promociones.SELECT_BY_PROMOCION(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _alumnos = Alumnos_Promociones.GetChildList(reader);

                    Sesion_Promocion.DoLOCK( Session());

                    query = Sesiones_Promociones.SELECT(GetInfo(false));
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _sesiones = Sesiones_Promociones.GetChildList(reader);
                }
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

                //_examenes.Update(this);
                _alumnos.Update(this);
                _sesiones.Update(this);
                //_horarios.Update(this);
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

                PromocionRecord obj = parent.Session().Get<PromocionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);

                //_examenes.Update(this);
                _alumnos.Update(this);
                _sesiones.Update(this);
                //_horarios.Update(this);
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
                Session().Delete(Session().Get<PromocionRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }


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
                    Promocion.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {

                        Alumno.DoLOCK(Session());

                        string query = Alumnos_Promociones.SELECT_BY_PROMOCION(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos = Alumnos_Promociones.GetChildList(reader);

                        Sesion_Promocion.DoLOCK(Session());

                        query = Sesiones_Promociones.SELECT(GetInfo(false));
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _sesiones = Sesiones_Promociones.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((PromocionRecord)(criteria.UniqueResult()));

                    //Session().Lock(Session().Get<PromocionRecord>(Oid), LockMode.UpgradeNoWait);

                    if (Childs)
                    {
                        //criteria = Examen.GetCriteria(Session());
                        //criteria.AddEq("OidPromocion", this.Oid);
                        //_examenes = Examens.GetChildList(criteria.List<Examen>());

                        criteria = Alumno_Promocion.GetCriteria(Session());
                        criteria.AddEq("OidPromocion", this.Oid);
                        _alumnos = Alumnos_Promociones.GetChildList(criteria.List<Alumno_Promocion>());

                        criteria = Sesion_Promocion.GetCriteria(Session());
                        criteria.AddEq("OidPromocion", this.Oid);
                        criteria.AddEq("Tipo", 1);
                        _sesiones = Sesiones_Promociones.GetChildList(criteria.List<Sesion_Promocion>());
                    }
                }
            }
            catch (NHibernate.ADOException)
            {
                if (Transaction() != null) Transaction().Rollback();
                throw new iQLockException(moleQule.Library.Resources.Messages.LOCK_ERROR);
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
                    PromocionRecord obj = Session().Get<PromocionRecord>(Oid);
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
                PromocionRecord obj = (PromocionRecord)(criteria.UniqueResult());
                Session().Delete(Session().Get<PromocionRecord>(obj.Oid));

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

        public virtual bool CompruebaConfiguracion()
        {
            List<bool> activas = new List<bool>();

            activas.Add(H8AM);
            activas.Add(H0);
            activas.Add(H1);
            activas.Add(H2);
            activas.Add(H3);
            activas.Add(H4);
            activas.Add(H5);
            activas.Add(H6);
            activas.Add(H7);
            activas.Add(H8);
            activas.Add(H9);
            activas.Add(H10);
            activas.Add(H11);
            activas.Add(H12);

            return CompruebaConfiguracion(activas, Sesion_PromocionList.GetChildList(Sesiones));
        }

        public static bool CompruebaConfiguracion(List<bool> activas, Sesion_PromocionList sesiones)
        {
            SortedDictionary<string, bool> horas = new SortedDictionary<string, bool>();
            SortedDictionary<string, bool> horas_activas = new SortedDictionary<string, bool>();

            DateTime hora = DateTime.Parse("8:00");

            for (int i = 0; i < 14; i++)
            {
                horas.Add(hora.ToShortTimeString(), false);
                horas_activas.Add(hora.ToShortTimeString(), activas[i]);
                hora = hora.AddHours(1);
            }

            foreach (Sesion_PromocionInfo item in sesiones)
            { 
                hora = item.HoraInicio;

                for(int j = 0; j < item.NHoras; j++)
                {
                    bool valor = false;
                    if (horas_activas.TryGetValue(hora.ToShortTimeString(), out valor)
                        && valor)
                    {
                        valor = false;

                        if (horas.TryGetValue(hora.ToShortTimeString(), out valor))
                        {
                            if (valor)
                                return false;
                            else
                                horas[hora.ToShortTimeString()] = true;
                            hora = hora.AddHours(1);
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }

            hora = DateTime.Parse("8:00");

            for (int i = 0; i < 14; i++)
            {
                if (horas_activas[hora.ToShortTimeString()] != horas[hora.ToShortTimeString()])
                    return false;
                hora = hora.AddHours(1);
            }

            return true;
        }

        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT PR.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string pr = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            query = "   FROM   " + pr + "   AS PR";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Promocion != null && conditions.Promocion.Oid > 0)
                query += " AND PR.\"OID\" = " + conditions.Promocion.Oid.ToString();

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            query += " ORDER BY PR.\"NUMERO\"";

            if (lockTable) query += " FOR UPDATE OF PR NOWAIT";

            return query;
        }

        internal static string SELECT(long oid, bool lock_table)
        {
            QueryConditions conditions = new QueryConditions();

            conditions.Promocion = PromocionInfo.New();
            conditions.Promocion.Oid = oid;

            return SELECT(conditions, lock_table);
        }

        public static string SELECT(long oid) { return SELECT(oid, true); }


        #endregion

    }
}

