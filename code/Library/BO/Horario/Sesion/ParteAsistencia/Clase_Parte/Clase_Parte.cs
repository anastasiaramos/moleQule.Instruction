using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Clase_ParteRecord : RecordBase
	{
		#region Attributes

		private long _oid_clase;
		private long _oid_parte;
		private long _tipo;
		private long _grupo;
  
		#endregion
		
		#region Properties
		
				public virtual long OidClase { get { return _oid_clase; } set { _oid_clase = value; } }
		public virtual long OidParte { get { return _oid_parte; } set { _oid_parte = value; } }
		public virtual long Tipo { get { return _tipo; } set { _tipo = value; } }
		public virtual long Grupo { get { return _grupo; } set { _grupo = value; } }

		#endregion
		
		#region Business Methods
		
		public Clase_ParteRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_clase = Format.DataReader.GetInt64(source, "OID_CLASE");
			_oid_parte = Format.DataReader.GetInt64(source, "OID_PARTE");
			_tipo = Format.DataReader.GetInt64(source, "TIPO");
			_grupo = Format.DataReader.GetInt64(source, "GRUPO");

		}		
		public virtual void CopyValues(Clase_ParteRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_clase = source.OidClase;
			_oid_parte = source.OidParte;
			_tipo = source.Tipo;
			_grupo = source.Grupo;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Clase_ParteBase 
	{	 
		#region Attributes
		
		private Clase_ParteRecord _record = new Clase_ParteRecord();
		
		#endregion
		
		#region Properties
		
		public Clase_ParteRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Clase_Parte source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(Clase_ParteInfo source)
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
	public class Clase_Parte : BusinessBaseEx<Clase_Parte>
	{	 
		#region Attributes
		
		protected Clase_ParteBase _base = new Clase_ParteBase();
		

		#endregion
		
		#region Properties
		
		public Clase_ParteBase Base { get { return _base; } }
		
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
		public virtual long OidClase
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidClase;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidClase.Equals(value))
				{
					_base.Record.OidClase = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidParte
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidParte;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidParte.Equals(value))
				{
					_base.Record.OidParte = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Tipo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Tipo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.Tipo.Equals(value))
				{
					_base.Record.Tipo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Grupo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Grupo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.Grupo.Equals(value))
				{
					_base.Record.Grupo = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Clase_Parte CloneAsNew()
		{
			Clase_Parte clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Clase_Parte.OpenSession();
			Clase_Parte.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Clase_ParteInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidClase = source.OidClase;
			OidParte = source.OidParte;
			Tipo = source.Tipo;
			Grupo = source.Grupo;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidClase", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidParte", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Tipo", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("Grupo", 1));
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.PARTE_ASISTENCIA);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.PARTE_ASISTENCIA);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.PARTE_ASISTENCIA);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.PARTE_ASISTENCIA);

        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public Clase_Parte()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private Clase_Parte(Clase_Parte source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Clase_Parte(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Clase_Parte NewChild(ParteAsistencia parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Clase_Parte obj = new Clase_Parte();
            obj.OidParte = parent.Oid;
            return obj;
        }

        internal static Clase_Parte GetChild(Clase_Parte source)
        {
            return new Clase_Parte(source);
        }

        internal static Clase_Parte GetChild(IDataReader reader)
        {
            return new Clase_Parte(reader);
        }

        public virtual Clase_ParteInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Clase_ParteInfo(this);

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
        public override Clase_Parte Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(Clase_Parte source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader reader)
        {
            _base.CopyValues(reader);
            MarkOld();
        }

        internal void Insert(ParteAsistencia parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidParte = parent.Oid;

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

        internal void Update(ParteAsistencia parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidParte = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Clase_ParteRecord obj = parent.Session().Get<Clase_ParteRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(ParteAsistencia parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Clase_ParteRecord>(Oid));
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

            query = "SELECT CP.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string clase_parte = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));

            query = "   FROM   " + clase_parte + "   AS CP";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.ParteAsistencia != null && conditions.ParteAsistencia.Oid > 0)
                query += " AND CP.\"OID_PARTE\" = " + conditions.ParteAsistencia.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF CP NOWAIT";

            return query;
        }


        #endregion

    }
}

