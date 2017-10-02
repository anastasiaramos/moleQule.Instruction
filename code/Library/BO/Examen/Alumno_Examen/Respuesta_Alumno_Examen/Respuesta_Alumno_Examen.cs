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
	public class Respuesta_Alumno_ExamenRecord : RecordBase
	{
		#region Attributes

		private long _oid_alumno_examen;
		private long _oid_pregunta_examen;
		private string _opcion = string.Empty;
		private long _orden;
		private bool _correcta = false;
		private Decimal _calificacion;
  
		#endregion
		
		#region Properties
		
				public virtual long OidAlumnoExamen { get { return _oid_alumno_examen; } set { _oid_alumno_examen = value; } }
		public virtual long OidPreguntaExamen { get { return _oid_pregunta_examen; } set { _oid_pregunta_examen = value; } }
		public virtual string Opcion { get { return _opcion; } set { _opcion = value; } }
		public virtual long Orden { get { return _orden; } set { _orden = value; } }
		public virtual bool Correcta { get { return _correcta; } set { _correcta = value; } }
		public virtual Decimal Calificacion { get { return _calificacion; } set { _calificacion = value; } }

		#endregion
		
		#region Business Methods
		
		public Respuesta_Alumno_ExamenRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_alumno_examen = Format.DataReader.GetInt64(source, "OID_ALUMNO_EXAMEN");
			_oid_pregunta_examen = Format.DataReader.GetInt64(source, "OID_PREGUNTA_EXAMEN");
			_opcion = Format.DataReader.GetString(source, "OPCION");
			_orden = Format.DataReader.GetInt64(source, "ORDEN");
			_correcta = Format.DataReader.GetBool(source, "CORRECTA");
			_calificacion = Format.DataReader.GetDecimal(source, "CALIFICACION");

		}		
		public virtual void CopyValues(Respuesta_Alumno_ExamenRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_alumno_examen = source.OidAlumnoExamen;
			_oid_pregunta_examen = source.OidPreguntaExamen;
			_opcion = source.Opcion;
			_orden = source.Orden;
			_correcta = source.Correcta;
			_calificacion = source.Calificacion;
		}
		
		#endregion	
	}

    [Serializable()]
	public class Respuesta_Alumno_ExamenBase 
	{	 
		#region Attributes
		
		private Respuesta_Alumno_ExamenRecord _record = new Respuesta_Alumno_ExamenRecord();

        //NO ENLAZADOS
        private string _pregunta = string.Empty;
        private string _opcion_correcta = string.Empty;
		
		#endregion
		
		#region Properties
		
		public Respuesta_Alumno_ExamenRecord Record { get { return _record; } }

        //NO ENLAZADAS
        public virtual string Pregunta { get { return _pregunta; } set { _pregunta = value; } }
        public virtual string OpcionCorrecta { get { return _opcion_correcta; } set { _opcion_correcta = value;} }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Respuesta_Alumno_Examen source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _pregunta = source.Pregunta;
            _opcion_correcta = source.OpcionCorrecta;
		}
		public void CopyValues(Respuesta_Alumno_ExamenInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);

            _pregunta = source.Base.Pregunta;
            _opcion_correcta = source.Base.OpcionCorrecta;
		}
		
		#endregion	
	}
		
	/// <summary>
	/// Editable Root Business Object
	/// </summary>	
    [Serializable()]
	public class Respuesta_Alumno_Examen : BusinessBaseEx<Respuesta_Alumno_Examen>
	{	 
		#region Attributes
		
		protected Respuesta_Alumno_ExamenBase _base = new Respuesta_Alumno_ExamenBase();
		

		#endregion
		
		#region Properties
		
		public Respuesta_Alumno_ExamenBase Base { get { return _base; } }
		
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
		public virtual long OidAlumnoExamen
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidAlumnoExamen;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidAlumnoExamen.Equals(value))
				{
					_base.Record.OidAlumnoExamen = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidPreguntaExamen
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.OidPreguntaExamen;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.OidPreguntaExamen.Equals(value))
				{
					_base.Record.OidPreguntaExamen = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Opcion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Opcion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Opcion.Equals(value))
				{
					_base.Record.Opcion = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Orden
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Orden;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Orden.Equals(value))
				{
					_base.Record.Orden = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Correcta
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Correcta;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Correcta.Equals(value))
				{
					_base.Record.Correcta = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual Decimal Calificacion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Calificacion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Calificacion.Equals(value))
				{
					_base.Record.Calificacion = value;
					PropertyHasChanged();
				}
			}
		}

        //NO ENLAZADAS
        public virtual string Pregunta { get { return _base.Pregunta; } set { _base.Pregunta = value; } }
        public virtual string OpcionCorrecta { get { return _base.OpcionCorrecta; } set { _base.OpcionCorrecta = value; } }
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Respuesta_Alumno_Examen CloneAsNew()
		{
			Respuesta_Alumno_Examen clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Respuesta_Alumno_Examen.OpenSession();
			Respuesta_Alumno_Examen.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(Respuesta_Alumno_ExamenInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidAlumnoExamen = source.OidAlumnoExamen;
			OidPreguntaExamen = source.OidPreguntaExamen;
			Opcion = source.Opcion;
			Orden = source.Orden;
			Correcta = source.Correcta;
			Calificacion = source.Calificacion;
		}
		
			
		#endregion
        
        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidAlumnoExamen", 1));
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPreguntaExamen", 1));
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
        public Respuesta_Alumno_Examen()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private Respuesta_Alumno_Examen(Respuesta_Alumno_Examen source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Respuesta_Alumno_Examen(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Respuesta_Alumno_Examen NewChild(Alumno_Examen parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Respuesta_Alumno_Examen obj = new Respuesta_Alumno_Examen();
            obj.OidAlumnoExamen = parent.Oid;
            return obj;
        }

        internal static Respuesta_Alumno_Examen GetChild(Respuesta_Alumno_Examen source)
        {
            return new Respuesta_Alumno_Examen(source);
        }

        internal static Respuesta_Alumno_Examen GetChild(IDataReader reader)
        {
            return new Respuesta_Alumno_Examen(reader);
        }

        public virtual Respuesta_Alumno_ExamenInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Respuesta_Alumno_ExamenInfo(this);

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
        public override Respuesta_Alumno_Examen Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(Respuesta_Alumno_Examen source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader reader)
        {
            _base.CopyValues(reader);
            MarkOld();
        }

        internal void Insert(Alumno_Examen parent, ISession sesion)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAlumnoExamen = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                sesion.Save(this.Base.Record);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Alumno_Examen parent, ISession sesion)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAlumnoExamen = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                Respuesta_Alumno_ExamenRecord obj = sesion.Get<Respuesta_Alumno_ExamenRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                sesion.Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Alumno_Examen parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<Respuesta_Alumno_ExamenRecord>(Oid));
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

            query = "SELECT RAE.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string rae = nHManager.Instance.GetSQLTable(typeof(Respuesta_Alumno_ExamenRecord));

            query = "   FROM   " + rae + "   AS RAE";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Alumno_Examen != null && conditions.Alumno_Examen.Oid > 0)
                query += " AND RAE.\"OID_ALUMNO_EXAMEN\" = " + conditions.Alumno_Examen.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            query += " ORDER BY RAE.\"ORDEN\"";

            if (lockTable) query += " FOR UPDATE OF RAE NOWAIT";

            return query;
        }


        #endregion

    }
}

