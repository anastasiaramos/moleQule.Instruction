using System;
using System.ComponentModel;
using System.Data;

using Csla;
using Csla.Validation;  
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Pregunta_ExamenRecord : RecordBase
	{
		#region Attributes

		private long _oid_pregunta;
		private long _oid_examen;
  
		#endregion
		
		#region Properties
		
				public virtual long OidPregunta { get { return _oid_pregunta; } set { _oid_pregunta = value; } }
		public virtual long OidExamen { get { return _oid_examen; } set { _oid_examen = value; } }

		#endregion
		
		#region Business Methods
		
		public Pregunta_ExamenRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_pregunta = Format.DataReader.GetInt64(source, "OID_PREGUNTA");
			_oid_examen = Format.DataReader.GetInt64(source, "OID_EXAMEN");

		}		
		public virtual void CopyValues(Pregunta_ExamenRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_pregunta = source.OidPregunta;
			_oid_examen = source.OidExamen;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Pregunta_ExamenBase 
	{	 
		#region Attributes
		
		private Pregunta_ExamenRecord _record = new Pregunta_ExamenRecord();
		
		#endregion
		
		#region Properties
		
		public Pregunta_ExamenRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Pregunta_Examen source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(Pregunta_ExamenInfo source)
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
	public class Pregunta_Examen : BusinessBaseEx<Pregunta_Examen>
	{	 
		#region Attributes
		
		protected Pregunta_ExamenBase _base = new Pregunta_ExamenBase();
		

		#endregion
		
		#region Properties
		
		public Pregunta_ExamenBase Base { get { return _base; } }
		
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
		public virtual long OidPregunta
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPregunta;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPregunta.Equals(value))
				{
					_base.Record.OidPregunta = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidExamen
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidExamen;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidExamen.Equals(value))
				{
					_base.Record.OidExamen = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Pregunta_Examen CloneAsNew()
		{
			Pregunta_Examen clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Pregunta_Examen.OpenSession();
			Pregunta_Examen.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Pregunta_ExamenInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidPregunta = source.OidPregunta;
			OidExamen = source.OidExamen;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPregunta", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidExamen", 1));
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.EXAMEN);
        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.EXAMEN);
        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.EXAMEN);
        }
        
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.EXAMEN);
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public Pregunta_Examen()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private Pregunta_Examen(Pregunta_Examen source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Pregunta_Examen(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Pregunta_Examen NewChild(Pregunta parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Pregunta_Examen obj = new Pregunta_Examen();
            obj.OidPregunta = parent.Oid;
            return obj;
        }

        public static Pregunta_Examen NewChild(Examen parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Pregunta_Examen obj = new Pregunta_Examen();
            obj.OidExamen = parent.Oid;
            return obj;
        }

        internal static Pregunta_Examen GetChild(Pregunta_Examen source)
        {
            return new Pregunta_Examen(source);
        }

        internal static Pregunta_Examen GetChild(IDataReader reader)
        {
            return new Pregunta_Examen(reader);
        }

        public virtual Pregunta_ExamenInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Pregunta_ExamenInfo(this);

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
        public override Pregunta_Examen Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(Pregunta_Examen source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader reader)
        {
            _base.CopyValues(reader);
            MarkOld();
        }

        internal void Insert(Pregunta parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPregunta = parent.Oid;

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

        internal void Update(Pregunta parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPregunta = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Pregunta_ExamenRecord obj = parent.Session().Get<Pregunta_ExamenRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Pregunta parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Pregunta_ExamenRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Examen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidExamen = parent.Oid;

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

        internal void Update(Examen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidExamen = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Pregunta_ExamenRecord obj = parent.Session().Get<Pregunta_ExamenRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Examen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Pregunta_ExamenRecord>(Oid));
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

            query = "SELECT PE.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string pe = nHManager.Instance.GetSQLTable(typeof(Pregunta_ExamenRecord));

            query = "   FROM   " + pe + "   AS PE";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Examen != null && conditions.Examen.Oid > 0)
                query += " AND PE.\"OID_EXAMEN\" = " + conditions.Examen.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF PE NOWAIT";

            return query;
        }

        internal static string SELECT(long oid, bool lock_table)
        {
            string pe = nHManager.Instance.GetSQLTable(typeof(Pregunta_Examen));

            string query;

            query = Pregunta_Examen.SELECT_FIELDS() +
                    " FROM " + pe + " AS PE";

            if (oid > 0) query += " WHERE PE.\"OID\" = " + oid.ToString();

            if (lock_table) query += " FOR UPDATE OF PE NOWAIT";

            return query;
        }

        internal new static string SELECT(long oid) { return Pregunta_Examen.SELECT(oid, true); }

        #endregion
	
	}
}

