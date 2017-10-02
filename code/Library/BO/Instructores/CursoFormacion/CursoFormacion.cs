using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;  
using moleQule.Library.CslaEx;

using moleQule.Library;

using NHibernate;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class CursoFormacionRecord : RecordBase
	{
		#region Attributes

		private long _oid_profesor;
		private string _nombre = string.Empty;
		private DateTime _fecha;
		private DateTime _fecha_renovacion;
		private string _observaciones = string.Empty;
		private long _n_horas;
  
		#endregion
		
		#region Properties
		
				public virtual long OidProfesor { get { return _oid_profesor; } set { _oid_profesor = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual DateTime Fecha { get { return _fecha; } set { _fecha = value; } }
		public virtual DateTime FechaRenovacion { get { return _fecha_renovacion; } set { _fecha_renovacion = value; } }
		public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
		public virtual long NHoras { get { return _n_horas; } set { _n_horas = value; } }

		#endregion
		
		#region Business Methods
		
		public CursoFormacionRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_profesor = Format.DataReader.GetInt64(source, "OID_PROFESOR");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_fecha = Format.DataReader.GetDateTime(source, "FECHA");
			_fecha_renovacion = Format.DataReader.GetDateTime(source, "FECHA_RENOVACION");
			_observaciones = Format.DataReader.GetString(source, "OBSERVACIONES");
			_n_horas = Format.DataReader.GetInt64(source, "N_HORAS");

		}		
		public virtual void CopyValues(CursoFormacionRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_profesor = source.OidProfesor;
			_nombre = source.Nombre;
			_fecha = source.Fecha;
			_fecha_renovacion = source.FechaRenovacion;
			_observaciones = source.Observaciones;
			_n_horas = source.NHoras;
		}
		
		#endregion	
	}

    [Serializable()]
	public class CursoFormacionBase 
	{	 
		#region Attributes
		
		private CursoFormacionRecord _record = new CursoFormacionRecord();
		
		#endregion
		
		#region Properties
		
		public CursoFormacionRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(CursoFormacion source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(CursoFormacionInfo source)
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
	public class CursoFormacion : BusinessBaseEx<CursoFormacion>
	{	 
		#region Attributes
		
		protected CursoFormacionBase _base = new CursoFormacionBase();
		

		#endregion
		
		#region Properties
		
		public CursoFormacionBase Base { get { return _base; } }
		
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
		public virtual long OidProfesor
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidProfesor;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidProfesor.Equals(value))
				{
					_base.Record.OidProfesor = value;
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
				//////CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Nombre.Equals(value))
				{
					_base.Record.Nombre = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime Fecha
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Fecha;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.Fecha.Equals(value))
				{
					_base.Record.Fecha = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual DateTime FechaRenovacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.FechaRenovacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.FechaRenovacion.Equals(value))
				{
					_base.Record.FechaRenovacion = value;
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
		public virtual long NHoras
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NHoras;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.NHoras.Equals(value))
				{
					_base.Record.NHoras = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual CursoFormacion CloneAsNew()
		{
			CursoFormacion clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = CursoFormacion.OpenSession();
			CursoFormacion.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(CursoFormacionInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidProfesor = source.OidProfesor;
			Nombre = source.Nombre;
			Fecha = source.Fecha;
			FechaRenovacion = source.FechaRenovacion;
			Observaciones = source.Observaciones;
			NHoras = source.NHoras;
		}
		
			
		#endregion

		#region Validation Rules

		protected override void AddBusinessRules()
		{

			ValidationRules.AddRule(CommonRules.MinValue<long>,
									new CommonRules.MinValueRuleArgs<long>("OidProfesor", 1));
		}

		#endregion

		#region Autorization Rules

		public static bool CanAddObject()
		{
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.CURSO_FORMACION);

		}

		public static bool CanGetObject()
		{
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.CURSO_FORMACION);

		}

		public static bool CanDeleteObject()
		{
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.CURSO_FORMACION);

		}
		public static bool CanEditObject()
		{
			return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.CURSO_FORMACION);

		}

		#endregion

		#region Factory Methods

		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate
		/// y public para que funcionen los DataGridView
		/// </summary>
		public CursoFormacion()
		{
			MarkAsChild();
			Random r = new Random();
            Oid = (long)r.Next();
			//Rellenar si hay más campos que deban ser inicializados aquí
		}

		private CursoFormacion(CursoFormacion source)
		{
			MarkAsChild();
			Fetch(source);
		}

		private CursoFormacion(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}

		public static CursoFormacion NewChild(Instructor parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			CursoFormacion obj = new CursoFormacion();
			obj.OidProfesor = parent.Oid;
			return obj;
		}

		internal static CursoFormacion GetChild(CursoFormacion source)
		{
			return new CursoFormacion(source);
		}

		internal static CursoFormacion GetChild(IDataReader reader)
		{
			return new CursoFormacion(reader);
		}

		public virtual CursoFormacionInfo GetInfo()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			return new CursoFormacionInfo(this);

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
		public override CursoFormacion Save()
		{
			throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}


		#endregion

		#region Child Data Access

		private void Fetch(CursoFormacion source)
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

			OidProfesor = parent.Oid;

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

			OidProfesor = parent.Oid;

			try
			{
				ValidationRules.CheckRules();

				if (!IsValid)
					throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				CursoFormacionRecord obj = parent.Session().Get<CursoFormacionRecord>(Oid);
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
				parent.Session().Delete(parent.Session().Get<CursoFormacionRecord>(Oid));
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkNew();
		}


        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT CF.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string curso_formacion = nHManager.Instance.GetSQLTable(typeof(CursoFormacionRecord));

            query = "   FROM   " + curso_formacion + "   AS CF";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Instructor != null && conditions.Instructor.Oid > 0)
                query += " AND CF.\"OID_PROFESOR\" = " + conditions.Instructor.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF CF NOWAIT";

            return query;
        }


        #endregion

	}
}

