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
	public class Concepto_ParteRecord : RecordBase
	{
		#region Attributes

		private long _oid_concepto;
		private long _oid_parte;
  
		#endregion
		
		#region Properties
		
				public virtual long OidConcepto { get { return _oid_concepto; } set { _oid_concepto = value; } }
		public virtual long OidParte { get { return _oid_parte; } set { _oid_parte = value; } }

		#endregion
		
		#region Business Methods
		
		public Concepto_ParteRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_concepto = Format.DataReader.GetInt64(source, "OID_CONCEPTO");
			_oid_parte = Format.DataReader.GetInt64(source, "OID_PARTE");

		}		
		public virtual void CopyValues(Concepto_ParteRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_concepto = source.OidConcepto;
			_oid_parte = source.OidParte;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Concepto_ParteBase 
	{	 
		#region Attributes
		
		private Concepto_ParteRecord _record = new Concepto_ParteRecord();
		
		#endregion
		
		#region Properties
		
		public Concepto_ParteRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Concepto_Parte source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(Concepto_ParteInfo source)
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
	public class Concepto_Parte : BusinessBaseEx<Concepto_Parte>
	{	 
		#region Attributes
		
		protected Concepto_ParteBase _base = new Concepto_ParteBase();
		

		#endregion
		
		#region Properties
		
		public Concepto_ParteBase Base { get { return _base; } }
		
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
		public virtual long OidConcepto
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidConcepto;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidConcepto.Equals(value))
				{
					_base.Record.OidConcepto = value;
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
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Concepto_Parte CloneAsNew()
		{
			Concepto_Parte clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Concepto_Parte.OpenSession();
			Concepto_Parte.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Concepto_ParteInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidConcepto = source.OidConcepto;
			OidParte = source.OidParte;
		}
		
			
		#endregion
		 
	     #region Validation Rules

            protected override void AddBusinessRules()
            {
                ValidationRules.AddRule(CommonRules.MinValue<long>,
                                        new CommonRules.MinValueRuleArgs<long>("OidConcepto", 1));

                ValidationRules.AddRule(CommonRules.MinValue<long>,
                                        new CommonRules.MinValueRuleArgs<long>("OidParte", 1));
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
			public Concepto_Parte() 
			{ 
				MarkAsChild();
				Random r = new Random();
                Oid = (long)r.Next();
			}

            private Concepto_Parte(Concepto_Parte source)
			{
				MarkAsChild();
				Fetch(source);
			}

            private Concepto_Parte(IDataReader reader)
			{
				MarkAsChild();
				Fetch(reader);
			}

            public static Concepto_Parte NewChild(ParteAsistencia parent)
			{
				if (!CanAddObject())
					throw new System.Security.SecurityException(
						moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

                Concepto_Parte obj = new Concepto_Parte();
				obj.OidParte = parent.Oid;
				return obj;
			}

            internal static Concepto_Parte GetChild(Concepto_Parte source)
			{
                return new Concepto_Parte(source);
			}

            internal static Concepto_Parte GetChild(IDataReader reader)
			{
				return new Concepto_Parte(reader);
			}

            public virtual Concepto_ParteInfo GetInfo()
			{
				if (!CanGetObject())
					throw new System.Security.SecurityException(
					  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

                return new Concepto_ParteInfo(this);

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
			public override Concepto_Parte Save()
			{
				throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
			}

			
		 #endregion
		 
		 #region Child Data Access

            private void Fetch(Concepto_Parte source)
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

                    Concepto_ParteRecord obj = parent.Session().Get<Concepto_ParteRecord>(Oid);
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
                    parent.Session().Delete(parent.Session().Get<Concepto_ParteRecord>(Oid));
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

                string concepto_parte = nHManager.Instance.GetSQLTable(typeof(Concepto_ParteRecord));

                query = "   FROM   " + concepto_parte + "   AS CP";

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

