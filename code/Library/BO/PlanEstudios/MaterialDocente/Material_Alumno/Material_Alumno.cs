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
	public class Material_AlumnoRecord : RecordBase
	{
		#region Attributes

		private long _oid_material;
		private long _oid_alumno;
		private bool _entregado = false;
  
		#endregion
		
		#region Properties
		
				public virtual long OidMaterial { get { return _oid_material; } set { _oid_material = value; } }
		public virtual long OidAlumno { get { return _oid_alumno; } set { _oid_alumno = value; } }
		public virtual bool Entregado { get { return _entregado; } set { _entregado = value; } }

		#endregion
		
		#region Business Methods
		
		public Material_AlumnoRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_material = Format.DataReader.GetInt64(source, "OID_MATERIAL");
			_oid_alumno = Format.DataReader.GetInt64(source, "OID_ALUMNO");
			_entregado = Format.DataReader.GetBool(source, "ENTREGADO");

		}		
		public virtual void CopyValues(Material_AlumnoRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_material = source.OidMaterial;
			_oid_alumno = source.OidAlumno;
			_entregado = source.Entregado;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Material_AlumnoBase 
	{	 
		#region Attributes
		
		private Material_AlumnoRecord _record = new Material_AlumnoRecord();
		
		#endregion
		
		#region Properties
		
		public Material_AlumnoRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Material_Alumno source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(Material_AlumnoInfo source)
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
	public class Material_Alumno : BusinessBaseEx<Material_Alumno>
	{	 
		#region Attributes
		
		protected Material_AlumnoBase _base = new Material_AlumnoBase();
		

		#endregion
		
		#region Properties
		
		public Material_AlumnoBase Base { get { return _base; } }
		
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
		public virtual long OidAlumno
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidAlumno;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidAlumno.Equals(value))
				{
					_base.Record.OidAlumno = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Entregado
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Entregado;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Entregado.Equals(value))
				{
					_base.Record.Entregado = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Material_Alumno CloneAsNew()
		{
			Material_Alumno clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Material_Alumno.OpenSession();
			Material_Alumno.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Material_AlumnoInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidMaterial = source.OidMaterial;
			OidAlumno = source.OidAlumno;
			Entregado = source.Entregado;
		}
		
			
		#endregion

        #region Validation Rules


        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidMaterial", 1));


            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidAlumno", 1));
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.ALUMNO);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.ALUMNO);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.ALUMNO);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.ALUMNO);

        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public Material_Alumno()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private Material_Alumno(Material_Alumno source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Material_Alumno(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Material_Alumno NewChild(MaterialDocente parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Material_Alumno obj = new Material_Alumno();
            obj.OidMaterial = parent.Oid;
            return obj;
        }

        public static Material_Alumno NewChild(Alumno parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Material_Alumno obj = new Material_Alumno();
            obj.OidAlumno = parent.Oid;
            return obj;
        }

        internal static Material_Alumno GetChild(Material_Alumno source)
        {
            return new Material_Alumno(source);
        }

        internal static Material_Alumno GetChild(IDataReader reader)
        {
            return new Material_Alumno(reader);
        }

        public virtual Material_AlumnoInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Material_AlumnoInfo(this);

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
        public override Material_Alumno Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(Material_Alumno source)
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

                Material_AlumnoRecord obj = parent.Session().Get<Material_AlumnoRecord>(Oid);
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
                parent.Session().Delete(parent.Session().Get<Material_AlumnoRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAlumno = parent.Oid;

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

        internal void Update(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAlumno = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Material_AlumnoRecord obj = parent.Session().Get<Material_AlumnoRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Material_AlumnoRecord>(Oid));
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

            query = "SELECT MA.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string material_alumno = nHManager.Instance.GetSQLTable(typeof(Material_AlumnoRecord));

            query = "   FROM   " + material_alumno + "   AS MA";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Alumno != null && conditions.Alumno.Oid > 0)
                query += " AND MA.\"OID_ALUMNO\" = " + conditions.Alumno.Oid;
            if (conditions.MaterialDocente != null && conditions.MaterialDocente.Oid > 0)
                query += " AND MA.\"OID_MATERIAL\" = " + conditions.MaterialDocente.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF MA NOWAIT";

            return query;
        }


        #endregion
	
	}
}

