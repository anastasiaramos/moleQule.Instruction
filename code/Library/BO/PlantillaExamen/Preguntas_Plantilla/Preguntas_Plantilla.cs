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
	public class Preguntas_PlantillaRecord : RecordBase
	{
		#region Attributes

		private long _oid_plantilla;
		private long _oid_submodulo;
		private long _n_preguntas;
		private long _oid_tema;
  
		#endregion
		
		#region Properties
		
				public virtual long OidPlantilla { get { return _oid_plantilla; } set { _oid_plantilla = value; } }
		public virtual long OidSubmodulo { get { return _oid_submodulo; } set { _oid_submodulo = value; } }
		public virtual long NPreguntas { get { return _n_preguntas; } set { _n_preguntas = value; } }
		public virtual long OidTema { get { return _oid_tema; } set { _oid_tema = value; } }

		#endregion
		
		#region Business Methods
		
		public Preguntas_PlantillaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_plantilla = Format.DataReader.GetInt64(source, "OID_PLANTILLA");
			_oid_submodulo = Format.DataReader.GetInt64(source, "OID_SUBMODULO");
			_n_preguntas = Format.DataReader.GetInt64(source, "N_PREGUNTAS");
			_oid_tema = Format.DataReader.GetInt64(source, "OID_TEMA");

		}		
		public virtual void CopyValues(Preguntas_PlantillaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_plantilla = source.OidPlantilla;
			_oid_submodulo = source.OidSubmodulo;
			_n_preguntas = source.NPreguntas;
			_oid_tema = source.OidTema;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Preguntas_PlantillaBase 
	{	 
		#region Attributes
		
		private Preguntas_PlantillaRecord _record = new Preguntas_PlantillaRecord();
		
		#endregion
		
		#region Properties
		
		public Preguntas_PlantillaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Preguntas_Plantilla source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(Preguntas_PlantillaInfo source)
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
	public class Preguntas_Plantilla : BusinessBaseEx<Preguntas_Plantilla>
	{	 
		#region Attributes
		
		protected Preguntas_PlantillaBase _base = new Preguntas_PlantillaBase();
		

		#endregion
		
		#region Properties
		
		public Preguntas_PlantillaBase Base { get { return _base; } }
		
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
		public virtual long OidPlantilla
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPlantilla;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPlantilla.Equals(value))
				{
					_base.Record.OidPlantilla = value;
					PropertyHasChanged();
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
		public virtual long NPreguntas
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NPreguntas;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.NPreguntas.Equals(value))
				{
					_base.Record.NPreguntas = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidTema
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidTema;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidTema.Equals(value))
				{
					_base.Record.OidTema = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Preguntas_Plantilla CloneAsNew()
		{
			Preguntas_Plantilla clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Preguntas_Plantilla.OpenSession();
			Preguntas_Plantilla.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Preguntas_PlantillaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidPlantilla = source.OidPlantilla;
			OidSubmodulo = source.OidSubmodulo;
			NPreguntas = source.NPreguntas;
			OidTema = source.OidTema;
		}
		
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPlantilla", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidSubmodulo", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidTema", 1));
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
        public Preguntas_Plantilla()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private Preguntas_Plantilla(Preguntas_Plantilla source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Preguntas_Plantilla(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Preguntas_Plantilla NewChild(PlantillaExamen parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Preguntas_Plantilla obj = new Preguntas_Plantilla();
            obj.OidPlantilla = parent.Oid;
            return obj;
        }

        internal static Preguntas_Plantilla GetChild(Preguntas_Plantilla source)
        {
            return new Preguntas_Plantilla(source);
        }

        internal static Preguntas_Plantilla GetChild(IDataReader reader)
        {
            return new Preguntas_Plantilla(reader);
        }

        public virtual Preguntas_PlantillaInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Preguntas_PlantillaInfo(this);

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
        public override Preguntas_Plantilla Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(Preguntas_Plantilla source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader reader)
        {
            _base.CopyValues(reader);
            MarkOld();
        }

        internal void Insert(PlantillaExamen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPlantilla = parent.Oid;

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

        internal void Update(PlantillaExamen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPlantilla = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Preguntas_PlantillaRecord obj = parent.Session().Get<Preguntas_PlantillaRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(PlantillaExamen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Preguntas_PlantillaRecord>(Oid));
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

            query = "SELECT PP.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string pp = nHManager.Instance.GetSQLTable(typeof(Preguntas_PlantillaRecord));

            query = "   FROM   " + pp + "   AS PP";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.PlantillaExamen != null && conditions.PlantillaExamen.Oid > 0)
                query += " AND PP.\"OID_PLANTILLA\" = " + conditions.PlantillaExamen.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF PP NOWAIT";

            return query;
        }

        #endregion

    }
}

