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
	public class Curso_InstructorRecord : RecordBase
	{
		#region Attributes

		private long _oid_curso;
		private long _oid_profesor;
  
		#endregion
		
		#region Properties
		
				public virtual long OidCurso { get { return _oid_curso; } set { _oid_curso = value; } }
		public virtual long OidProfesor { get { return _oid_profesor; } set { _oid_profesor = value; } }

		#endregion
		
		#region Business Methods
		
		public Curso_InstructorRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_curso = Format.DataReader.GetInt64(source, "OID_CURSO");
			_oid_profesor = Format.DataReader.GetInt64(source, "OID_PROFESOR");

		}		
		public virtual void CopyValues(Curso_InstructorRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_curso = source.OidCurso;
			_oid_profesor = source.OidProfesor;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Curso_InstructorBase 
	{	 
		#region Attributes
		
		private Curso_InstructorRecord _record = new Curso_InstructorRecord();
		
		#endregion
		
		#region Properties
		
		public Curso_InstructorRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Curso_Instructor source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(Curso_InstructorInfo source)
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
	public class Curso_Instructor : BusinessBaseEx<Curso_Instructor>
	{	 
		#region Attributes
		
		protected Curso_InstructorBase _base = new Curso_InstructorBase();
		

		#endregion
		
		#region Properties
		
		public Curso_InstructorBase Base { get { return _base; } }
		
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
		public virtual long OidCurso
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidCurso;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//////CanWriteProperty(true);
				
				if (!_base.Record.OidCurso.Equals(value))
				{
					_base.Record.OidCurso = value;
					PropertyHasChanged();
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
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Curso_Instructor CloneAsNew()
		{
			Curso_Instructor clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Curso_Instructor.OpenSession();
			Curso_Instructor.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Curso_InstructorInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidCurso = source.OidCurso;
			OidProfesor = source.OidProfesor;
		}
		
			
		#endregion

		#region Validation Rules

		protected override void AddBusinessRules()
		{
			ValidationRules.AddRule(CommonRules.MinValue<long>,
									new CommonRules.MinValueRuleArgs<long>("OidCurso", 1));

			ValidationRules.AddRule(CommonRules.MinValue<long>,
									new CommonRules.MinValueRuleArgs<long>("OidProfesor", 1));
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
		public Curso_Instructor()
		{
			MarkAsChild();
			Random r = new Random();
            Oid = (long)r.Next();
		}

		private Curso_Instructor(Curso_Instructor source)
		{
			MarkAsChild();
			Fetch(source);
		}

		private Curso_Instructor(IDataReader reader)
		{
			MarkAsChild();
			Fetch(reader);
		}

		public static Curso_Instructor NewChild(Curso parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			Curso_Instructor obj = new Curso_Instructor();
			obj.OidCurso = parent.Oid;
			return obj;
		}

		public static Curso_Instructor NewChild(Instructor parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			Curso_Instructor obj = new Curso_Instructor();
			obj.OidProfesor = parent.Oid;
			return obj;
		}

		internal static Curso_Instructor GetChild(Curso_Instructor source)
		{
			return new Curso_Instructor(source);
		}

		internal static Curso_Instructor GetChild(IDataReader reader)
		{
			return new Curso_Instructor(reader);
		}

		public virtual Curso_InstructorInfo GetInfo()
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			return new Curso_InstructorInfo(this);

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
		public override Curso_Instructor Save()
		{
			throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
		}


		#endregion

		#region Child Data Access

		private void Fetch(Curso_Instructor source)
		{
            _base.CopyValues(source);
			MarkOld();
		}

		private void Fetch(IDataReader reader)
		{
            _base.CopyValues(reader);
			MarkOld();
		}

		internal void Insert(Curso parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			OidCurso = parent.Oid;

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

		internal void Update(Curso parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			OidCurso = parent.Oid;

			try
			{
				ValidationRules.CheckRules();

				if (!IsValid)
					throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				Curso_InstructorRecord obj = parent.Session().Get<Curso_InstructorRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				parent.Session().Update(obj);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkOld();
		}

		internal void DeleteSelf(Curso parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;

			try
			{
				parent.Session().Delete(parent.Session().Get<Curso_InstructorRecord>(Oid));
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkNew();
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

				Curso_InstructorRecord obj = parent.Session().Get<Curso_InstructorRecord>(Oid);
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
				parent.Session().Delete(parent.Session().Get<Curso_InstructorRecord>(Oid));
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

            query = "SELECT CI.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string curso_instructor = nHManager.Instance.GetSQLTable(typeof(Curso_InstructorRecord));

            query = "   FROM   " + curso_instructor + "   AS CI";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Curso != null && conditions.Curso.Oid > 0)
                query += " AND CI.\"OID_CURSO\" = " + conditions.Curso.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF CI NOWAIT";

            return query;
        }


        #endregion

	}
}

