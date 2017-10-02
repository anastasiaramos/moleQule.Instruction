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
	public class Material_PlanRecord : RecordBase
	{
		#region Attributes

		private long _oid_modulo;
		private long _oid_material;
		private long _oid_revision;
  
		#endregion
		
		#region Properties
		
				public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
		public virtual long OidMaterial { get { return _oid_material; } set { _oid_material = value; } }
		public virtual long OidRevision { get { return _oid_revision; } set { _oid_revision = value; } }

		#endregion
		
		#region Business Methods
		
		public Material_PlanRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_modulo = Format.DataReader.GetInt64(source, "OID_MODULO");
			_oid_material = Format.DataReader.GetInt64(source, "OID_MATERIAL");
			_oid_revision = Format.DataReader.GetInt64(source, "OID_REVISION");

		}		
		public virtual void CopyValues(Material_PlanRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_modulo = source.OidModulo;
			_oid_material = source.OidMaterial;
			_oid_revision = source.OidRevision;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Material_PlanBase 
	{	 
		#region Attributes
		
		private Material_PlanRecord _record = new Material_PlanRecord();

        //NO ENLAZADAS
        private string _modulo;
        private string _material;
        private string _revision;
		
		#endregion
		
		#region Properties
		
		public Material_PlanRecord Record { get { return _record; } }


        public virtual string Modulo { get { return _modulo; } set { _modulo = value; } }
        public virtual string Material { get { return _material; } set { _material = value; } }
        public virtual string Revision { get { return _revision; } set { _revision = value; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);

            _modulo = Format.DataReader.GetString(source, "MODULO");
            _material = Format.DataReader.GetString(source, "MATERIAL");
            _revision = Format.DataReader.GetString(source, "REVISION");
		}		
		public void CopyValues(Material_Plan source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _material = source.Material;
            _revision = source.Revision;
		}
		public void CopyValues(Material_PlanInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _modulo = source.Modulo;
            _material = source.Material;
            _revision = source.Revision;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Material_Plan : BusinessBaseEx<Material_Plan>
	{	 
		#region Attributes
		
		protected Material_PlanBase _base = new Material_PlanBase();
		

		#endregion
		
		#region Properties
		
		public Material_PlanBase Base { get { return _base; } }
		
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
		public virtual long OidModulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidModulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidModulo.Equals(value))
				{
					_base.Record.OidModulo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidMaterial
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidMaterial;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidMaterial.Equals(value))
				{
					_base.Record.OidMaterial = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidRevision
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidRevision;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidRevision.Equals(value))
				{
					_base.Record.OidRevision = value;
					PropertyHasChanged();
				}
			}
		}

        //NO ENLAZADAS
        public virtual string Modulo
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Modulo;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Modulo.Equals(value))
                {
                    _base.Modulo = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Material
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Material;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Material.Equals(value))
                {
                    _base.Material = value;
                }
            }
        }
        public virtual string Revision
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Revision;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                ////CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (!_base.Revision.Equals(value))
                {
                    _base.Revision = value;
                }
            }
        }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Material_Plan CloneAsNew()
		{
			Material_Plan clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Material_Plan.OpenSession();
			Material_Plan.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Material_PlanInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidModulo = source.OidModulo;
			OidMaterial = source.OidMaterial;
			OidRevision = source.OidRevision;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidMaterial", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidModulo", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidRevision", 1));
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.PLAN_ESTUDIOS);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.PLAN_ESTUDIOS);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.PLAN_ESTUDIOS);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.PLAN_ESTUDIOS);

        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public Material_Plan()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private Material_Plan(Material_Plan source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Material_Plan(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Material_Plan NewChild(MaterialDocente parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Material_Plan obj = new Material_Plan();
            obj.OidMaterial = parent.Oid;
            return obj;
        }

        public static Material_Plan NewChild(Modulo parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Material_Plan obj = new Material_Plan();
            obj.OidModulo = parent.Oid;
            return obj;
        }

        public static Material_Plan NewChild(RevisionMaterial parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Material_Plan obj = new Material_Plan();
            obj.OidRevision = parent.Oid;
            return obj;
        }

        internal static Material_Plan GetChild(Material_Plan source)
        {
            return new Material_Plan(source);
        }

        internal static Material_Plan GetChild(IDataReader reader)
        {
            return new Material_Plan(reader);
        }

        public virtual Material_PlanInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Material_PlanInfo(this, false);

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
        public override Material_Plan Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(Material_Plan source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader reader)
        {
            _base.CopyValues(reader);
            MarkOld();
        }

        internal void Insert(MaterialDocente parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidMaterial = parent.Oid;

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

        internal void Update(MaterialDocente parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidMaterial = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Material_PlanRecord obj = parent.Session().Get<Material_PlanRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(MaterialDocente parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Material_PlanRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Modulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidModulo = parent.Oid;

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

        internal void Update(Modulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidModulo = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Material_PlanRecord obj = parent.Session().Get<Material_PlanRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Modulo parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Material_PlanRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(RevisionMaterial parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidRevision = parent.Oid;

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

        internal void Update(RevisionMaterial parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidRevision = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Material_PlanRecord obj = parent.Session().Get<Material_PlanRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(RevisionMaterial parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Material_PlanRecord>(Oid));
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

            query = "SELECT MP.*," +
                    "       (M.\"NUMERO_MODULO\" || ' ' || M.\"TEXTO\") AS \"MODULO\"," +
                    "       MD.\"NOMBRE\" AS \"MATERIAL\"," +
                    "       RM.\"VERSION\" AS \"REVISION\"";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string rm = nHManager.Instance.GetSQLTable(typeof(RevisionMaterialRecord));
            string mp = nHManager.Instance.GetSQLTable(typeof(Material_PlanRecord));
            string md = nHManager.Instance.GetSQLTable(typeof(MaterialDocenteRecord));
            string m = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));

            query = "   FROM   " + mp + "   AS MP" +
                    "   INNER JOIN " + m + " AS M ON M.\"OID\" = MP.\"OID_MODULO\"" +
                    "   INNER JOIN " + md + " AS MD ON MD.\"OID\" = MP.\"OID_MATERIAL\"" +
                    "   INNER JOIN " + rm + " AS RM ON RM.\"OID\" = MP.\"OID_REVISION\"";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.MaterialDocente != null && conditions.MaterialDocente.Oid > 0)
                query += " AND MP.\"OID_MATERIAL\" = " + conditions.MaterialDocente.Oid;
            if (conditions.Modulo != null && conditions.Modulo.Oid > 0)
                query += " AND MP.\"OID_MODULO\" = " + conditions.Modulo.Oid;
            if (conditions.RevisionMaterial != null && conditions.RevisionMaterial.Oid > 0)
                query += " AND MP.\"OID_REVISION\" = " + conditions.RevisionMaterial.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF MP NOWAIT";

            return query;
        }


        #endregion
	
	}
}

