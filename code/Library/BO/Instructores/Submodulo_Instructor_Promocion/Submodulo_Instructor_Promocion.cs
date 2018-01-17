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
	public class Submodulo_Instructor_PromocionRecord : RecordBase
	{
		#region Attributes

		private long _oid_submodulo;
		private long _oid_instructor;
		private long _prioridad;
		private long _oid_promocion;
		private long _oid_instructor_promocion;
  
		#endregion
		
		#region Properties
		
				public virtual long OidSubmodulo { get { return _oid_submodulo; } set { _oid_submodulo = value; } }
		public virtual long OidInstructor { get { return _oid_instructor; } set { _oid_instructor = value; } }
		public virtual long Prioridad { get { return _prioridad; } set { _prioridad = value; } }
		public virtual long OidPromocion { get { return _oid_promocion; } set { _oid_promocion = value; } }
		public virtual long OidInstructorPromocion { get { return _oid_instructor_promocion; } set { _oid_instructor_promocion = value; } }

		#endregion
		
		#region Business Methods
		
		public Submodulo_Instructor_PromocionRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_submodulo = Format.DataReader.GetInt64(source, "OID_SUBMODULO");
			_oid_instructor = Format.DataReader.GetInt64(source, "OID_INSTRUCTOR");
			_prioridad = Format.DataReader.GetInt64(source, "PRIORIDAD");
			_oid_promocion = Format.DataReader.GetInt64(source, "OID_PROMOCION");
			_oid_instructor_promocion = Format.DataReader.GetInt64(source, "OID_INSTRUCTOR_PROMOCION");

		}		
		public virtual void CopyValues(Submodulo_Instructor_PromocionRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_submodulo = source.OidSubmodulo;
			_oid_instructor = source.OidInstructor;
			_prioridad = source.Prioridad;
			_oid_promocion = source.OidPromocion;
			_oid_instructor_promocion = source.OidInstructorPromocion;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Submodulo_Instructor_PromocionBase 
	{	 
		#region Attributes
		
		private Submodulo_Instructor_PromocionRecord _record = new Submodulo_Instructor_PromocionRecord();

        //atributos auxiliares
        private long _oid_modulo;
        private string _modulo = string.Empty;
        private string _submodulo = string.Empty;
        private string _promocion = string.Empty;
		
		#endregion
		
		#region Properties
		
		public Submodulo_Instructor_PromocionRecord Record { get { return _record; } }

        public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
        public virtual string Modulo { get { return _modulo; } set { _modulo = value; } }
        public virtual string Submodulo { get { return _submodulo; } set { _submodulo = value; } }
        public virtual string Promocion { get { return _promocion; } set { _promocion = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _oid_modulo = Convert.ToInt32(source["OID_MODULO"]);
            _modulo = Convert.ToString(source["MODULO"]);
            _submodulo = Convert.ToString(source["SUBMODULO"]);
            _promocion = Convert.ToString(source["PROMOCION"]);
		}		
		public void CopyValues(Submodulo_Instructor_Promocion source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _oid_modulo = source.OidModulo;
            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _promocion = source.Promocion;
		}
		public void CopyValues(Submodulo_Instructor_PromocionInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _oid_modulo = source.OidModulo;
            _modulo = source.Modulo;
            _submodulo = source.Submodulo;
            _promocion = source.Promocion;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Submodulo_Instructor_Promocion : BusinessBaseEx<Submodulo_Instructor_Promocion>
	{	 
		#region Attributes
		
		protected Submodulo_Instructor_PromocionBase _base = new Submodulo_Instructor_PromocionBase();
		

		#endregion
		
		#region Properties
		
		public Submodulo_Instructor_PromocionBase Base { get { return _base; } }
		
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
		public virtual long OidSubmodulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidSubmodulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidSubmodulo.Equals(value))
				{
					_base.Record.OidSubmodulo = value;
					PropertyHasChanged();
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
				//CanWriteProperty(true);
				
				if (!_base.Record.OidInstructor.Equals(value))
				{
					_base.Record.OidInstructor = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Prioridad
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Prioridad;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Prioridad.Equals(value))
				{
					_base.Record.Prioridad = value;
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
		public virtual long OidInstructorPromocion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidInstructorPromocion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidInstructorPromocion.Equals(value))
				{
					_base.Record.OidInstructorPromocion = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual long OidModulo { get { return _base.OidModulo; } set { _base.OidModulo = value; } }
        public virtual string Modulo { get { return _base.Modulo; } set { _base.Modulo = value; } }
        public virtual string Submodulo { get { return _base.Submodulo; } set { _base.Submodulo = value; } }
        public virtual string Promocion { get { return _base.Promocion; } set { _base.Promocion = value; } }
		
		#endregion
		
		#region Business Methods
		
		public virtual Submodulo_Instructor_Promocion CloneAsNew()
		{
			Submodulo_Instructor_Promocion clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Submodulo_Instructor_Promocion.OpenSession();
			Submodulo_Instructor_Promocion.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Submodulo_Instructor_PromocionInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidSubmodulo = source.OidSubmodulo;
			OidInstructor = source.OidInstructor;
			Prioridad = source.Prioridad;
			OidPromocion = source.OidPromocion;
			OidInstructorPromocion = source.OidInstructorPromocion;

            OidModulo = source.OidModulo;
            Modulo = source.Modulo;
            Submodulo = source.Submodulo;
            Promocion = source.Promocion;
		}
		
			
		#endregion
		 
	     #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidSubmodulo", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidInstructor", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPromocion", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Prioridad", 1));

            ValidationRules.AddRule(CommonRules.MaxValue<long>,
                                    new CommonRules.MaxValueRuleArgs<long>("Prioridad", 100));
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
		public Submodulo_Instructor_Promocion() 
		{ 
			MarkAsChild();
			Random r = new Random();
            Oid = (long)r.Next();
            Prioridad = 1;
		}	

		private Submodulo_Instructor_Promocion(Submodulo_Instructor_Promocion source)
		{
			MarkAsChild();
			Fetch(source);
		}

		private Submodulo_Instructor_Promocion(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}

		public static Submodulo_Instructor_Promocion NewChild(Instructor parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			Submodulo_Instructor_Promocion obj = new Submodulo_Instructor_Promocion();
			obj.OidInstructor = parent.Oid;
			return obj;
		}

        public static Submodulo_Instructor_Promocion NewChild(Submodulo parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Submodulo_Instructor_Promocion obj = new Submodulo_Instructor_Promocion();
            obj.OidSubmodulo = parent.Oid;
            return obj;
        }

        public static Submodulo_Instructor_Promocion NewChild(Instructor_Promocion parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Submodulo_Instructor_Promocion obj = new Submodulo_Instructor_Promocion();
            obj.OidInstructorPromocion = parent.Oid;
            return obj;
        }

		internal static Submodulo_Instructor_Promocion GetChild(Submodulo_Instructor_Promocion source)
		{
			return new Submodulo_Instructor_Promocion(source);
		}

		internal static Submodulo_Instructor_Promocion GetChild(IDataReader reader)
		{
			return new Submodulo_Instructor_Promocion(reader);
		}

		public virtual Submodulo_Instructor_PromocionInfo GetInfo()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			return new Submodulo_Instructor_PromocionInfo(this);
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
		public override Submodulo_Instructor_Promocion Save()
		{
			throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}
			
		 #endregion
		 
		 #region Child Data Access
		 
	 	private void Fetch(Submodulo_Instructor_Promocion source)
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

				Submodulo_Instructor_PromocionRecord obj = parent.Session().Get<Submodulo_Instructor_PromocionRecord>(Oid);
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
				parent.Session().Delete(parent.Session().Get<Submodulo_Instructor_PromocionRecord>(Oid));
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
	
			MarkNew(); 
		}

        internal void Insert(Submodulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidSubmodulo = parent.Oid;

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

        internal void Update(Submodulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidSubmodulo = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Submodulo_Instructor_PromocionRecord obj = parent.Session().Get<Submodulo_Instructor_PromocionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Submodulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Submodulo_Instructor_PromocionRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Instructor_Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidInstructorPromocion = parent.Oid;
            OidInstructor = parent.OidInstructor;

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

        internal void Update(Instructor_Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidInstructorPromocion = parent.Oid;
            OidInstructor = parent.OidInstructor;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Submodulo_Instructor_PromocionRecord obj = parent.Session().Get<Submodulo_Instructor_PromocionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Instructor_Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Submodulo_Instructor_PromocionRecord>(Oid));
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

