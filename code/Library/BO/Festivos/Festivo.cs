using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class FestivoRecord : RecordBase
	{
		#region Attributes

		private DateTime _fecha_inicio;
        private DateTime _fecha_fin;
		private bool _anual = false;
        private long _tipo;
        private string _titulo = string.Empty;
		private string _descripcion = string.Empty;
  
		#endregion
		
		#region Properties
		public virtual DateTime FechaInicio { get { return _fecha_inicio; } set { _fecha_inicio = value; } }
        public virtual DateTime FechaFin { get { return _fecha_fin; } set { _fecha_fin = value; } }
		public virtual bool Anual { get { return _anual; } set { _anual = value; } }
		public virtual long Tipo { get { return _tipo; } set { _tipo = value; } }
        public virtual string Titulo { get { return _titulo; } set{ _titulo = value; } }
		public virtual string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
		
		#endregion
		
		#region Business Methods
		
		public FestivoRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
            _fecha_inicio = Format.DataReader.GetDateTime(source, "FECHA_INICIO");
            _fecha_fin = Format.DataReader.GetDateTime(source, "FECHA_FIN");
			_anual = Format.DataReader.GetBool(source, "ANUAL");
			_tipo = Format.DataReader.GetInt64(source, "TIPO");
			_titulo = Format.DataReader.GetString(source, "TITULO");
			_descripcion = Format.DataReader.GetString(source, "DESCRIPCION");

		}
		
		public virtual void CopyValues(FestivoRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_fecha_inicio = source.FechaInicio;
            _fecha_fin = source.FechaFin;
			_anual = source.Anual;
			_tipo = source.Tipo;
            _titulo = source.Titulo;
			_descripcion = source.Descripcion;
		}
		#endregion	
	}

    [Serializable()]
	public class FestivoBase
    {
        #region Attributes

        private FestivoRecord _record = new FestivoRecord();

        #endregion

        #region Properties

        public FestivoRecord Record { get { return _record; } }

        public ETipoDiaNoLectivo ETipo { get { return (ETipoDiaNoLectivo)_record.Tipo; } set { _record.Tipo = (long)value; } }

        #endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}

        public void CopyValues(Festivo source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);
        }
        public void CopyValues(FestivoInfo source)
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
	public class Festivo : BusinessBaseEx<Festivo>
    {
		#region Attributes
		
		protected FestivoBase _base = new FestivoBase();
		
		#endregion

        #region Properties

        public FestivoBase Base { get { return _base; } }

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
		public virtual DateTime FechaInicio
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _base.Record.FechaInicio;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				
				if (!_base.Record.FechaInicio.Equals(value))
				{
					_base.Record.FechaInicio = value;
					PropertyHasChanged();
				}
			}
		}
        public virtual DateTime FechaFin
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                CanReadProperty(true);
                return _base.Record.FechaFin;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                CanWriteProperty(true);

                if (!_base.Record.FechaFin.Equals(value))
                {
                    _base.Record.FechaFin = value;
                    PropertyHasChanged();
                }
            }
        }
		public virtual bool Anual
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _base.Record.Anual;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				
				if (!_base.Record.Anual.Equals(value))
				{
					_base.Record.Anual = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Tipo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _base.Record.Tipo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				
				if (!_base.Record.Tipo.Equals(value))
				{
					_base.Record.Tipo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Titulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _base.Record.Titulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Titulo.Equals(value))
				{
					_base.Record.Titulo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Descripcion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _base.Record.Descripcion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Descripcion.Equals(value))
				{
					_base.Record.Descripcion = value;
					PropertyHasChanged();
				}
			}
		}

        public virtual ETipoDiaNoLectivo ETipo { get { return _base.ETipo; } set { Tipo = (long)value; } }
        public virtual string TipoLabel { get { return Library.Instruction.EnumText<ETipoDiaNoLectivo>.GetLabel(ETipo); } }
		
		#endregion
		
		#region Business Methods
		
		public virtual Festivo CloneAsNew()
		{
			Festivo clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = Festivo.OpenSession();
			Festivo.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected void CopyValues(FestivoInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_base.CopyValues(source);
		}
		
		protected virtual void CopyFrom(FestivoInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			FechaInicio = source.FechaInicio;
            FechaFin = source.FechaFin;
			Anual = source.Anual;
			Tipo = source.Tipo;
            Titulo = source.Titulo;
			Descripcion = source.Descripcion;
		}
		
			
		#endregion
		 
	    #region Validation Rules

		/// <summary>
		/// Añade las reglas de validación necesarias para el objeto
		/// </summary>
		protected override void AddBusinessRules()
		{
			ValidationRules.AddRule(CheckValidation, "Oid");
		}

		private bool CheckValidation(object target, Csla.Validation.RuleArgs e)
		{
						
			
			//Propiedad
			/*if (Propiedad <= 0)
			{
				e.Description = String.Format(Library.Resources.Messages.NO_VALUE_SELECTED, "Propiedad");
				throw new iQValidationException(e.Description, string.Empty);
			}*/

			return true;
		}	
		 
		#endregion
		 
		#region Autorization Rules
				
		public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(moleQule.Library.Common.Resources.SecureItems.AUXILIARES);
        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(moleQule.Library.Common.Resources.SecureItems.AUXILIARES);
        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(moleQule.Library.Common.Resources.SecureItems.AUXILIARES);
        }

        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(moleQule.Library.Common.Resources.SecureItems.AUXILIARES);
        }

		#endregion
		 
		#region Common Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New o NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate.
		/// </summary>
		protected Festivo () 
        {
            FechaInicio = DateTime.Today;
            FechaFin = DateTime.Today;
            Anual = false;
            ETipo = ETipoDiaNoLectivo.Otros;
        }
				
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
		private Festivo(Festivo source, bool childs)
        {
			MarkAsChild();
			Childs = childs;
            Fetch(source);
        }
        private Festivo(int sessionCode, IDataReader source, bool childs)
        {
            MarkAsChild();	
			Childs = childs;
			SessionCode = sessionCode;
            Fetch(source);
        }

		/// <summary>
		/// Crea un nuevo objeto
		/// </summary>
		/// <returns>Nuevo objeto creado</returns>
		/// La utiliza la BusinessListBaseEx correspondiente para crear nuevos elementos
		public static Festivo NewChild() 
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);
			
			Festivo obj = DataPortal.Create<Festivo>(new CriteriaCs(-1));		
			obj.MarkAsChild();
            return obj;
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">Festivo con los datos para el objeto</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>
		/// La utiliza la BusinessListBaseEx correspondiente para montar la lista
		/// NO OBTIENE los hijos. Para ello utilice GetChild(Festivo source, bool childs)
		/// <remarks/>
		internal static Festivo GetChild(Festivo source) { return new Festivo(source, false); }
		internal static Festivo GetChild(Festivo source, bool childs) { return new Festivo(source, childs); }
        internal static Festivo GetChild(int sessionCode, IDataReader source) { return new Festivo(sessionCode, source, false); }
        internal static Festivo GetChild(int sessionCode, IDataReader source, bool childs) { return new Festivo(sessionCode, source, childs); }
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">Flag para solicitar que se copien los hijos</param>
		/// <returns>Réplica de solo lectura del objeto</returns>
		public virtual FestivoInfo GetInfo() { return GetInfo(true); }	
		public virtual FestivoInfo GetInfo (bool childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new FestivoInfo(this, childs);
		}
		
		#endregion
		
		#region Root Factory Methods
		
		/// <summary>
		/// Crea un nuevo objeto
		/// </summary>
		/// <returns>Nuevo objeto creado</returns>
		public static Festivo New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return DataPortal.Create<Festivo>(new CriteriaCs(-1));
		}

        public static Festivo New(ETipoDiaNoLectivo tipo, bool anual)
        {
            Festivo item = Festivo.New();

            item.ETipo = tipo;
            item.Anual = anual;

            return item;
        }
		
		public static Festivo Get(long oid) { return Get(oid, true); }
		public static Festivo Get(long oid, bool childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);
			
			CriteriaEx criteria = GetCriteria(OpenSession());
			criteria.Childs = childs;
			
			if (nHManager.Instance.UseDirectSQL)
				criteria.Query = SELECT(oid);
				
			BeginTransaction(criteria.Session);
			
			return DataPortal.Fetch<Festivo>(criteria);
		}
		
		/// <summary>
		/// Borrado inmediato, no cabe "undo"
		/// (La función debe ser "estática")
		/// </summary>
		/// <param name="oid"></param>
		public static void Delete(long oid)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);
			
			DataPortal.Delete(new CriteriaCs(oid));
		}
		
		/// <summary>
		/// Elimina todos los Festivo. 
		/// Si no existe integridad referencial, hay que eliminar las listas hijo en esta función.
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = Festivo.OpenSession();
			ISession sess = Festivo.Session(sessCode);
			ITransaction trans = Festivo.BeginTransaction(sessCode);
			
			try
			{	
				sess.Delete("from Festivo");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				throw new iQPersistentException(iQExceptionHandler.GetAllMessages(ex));
			}
			finally
			{
				Festivo.CloseSession(sessCode);
			}
		}
		
		/// <summary>
		/// Guarda en la base de datos todos los cambios del objeto.
		/// También guarda los cambios de los hijos si los tiene
		/// </summary>
		/// <returns>Objeto actualizado y con los flags reseteados</returns>
		public override Festivo Save()
		{
			// Por la posible doble interfaz Root/Child
			if (IsChild) throw new iQException(Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);			
		
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);
			else if (!CanEditObject())
				throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);

			try
			{
				ValidationRules.CheckRules();
			}
			catch (iQValidationException ex)
			{
				iQExceptionHandler.TreatException(ex);
				return this;
			}

			try
			{	
				base.Save();				
				
				Transaction().Commit();
				return this;
			}
			catch (Exception ex)
			{
				if (Transaction() != null) Transaction().Rollback();
				iQExceptionHandler.TreatException(ex);
				return this;
			}
			finally
			{
				if (CloseSessions) CloseSession(); 
				else BeginTransaction();
			}
		}
				
		#endregion
				
		
		#region Common Data Access
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="criteria">Criterios de consulta</param>
		/// <remarks>La llama el DataPortal a partir del New o NewChild</remarks>		
		[RunLocal()]
		private void DataPortal_Create(CriteriaCs criteria)
		{
			
			// El código va al constructor porque los DataGrid no llamana al DataPortal sino directamente al constructor
			
		}
		
		/// <summary>
		/// Construye el objeto y se encarga de obtener los
		/// hijos si los tiene y se solicitan
		/// </summary>
		/// <param name="source">Objeto fuente</param>
		private void Fetch(Festivo source)
		{
			SessionCode = source.SessionCode;

			_base.CopyValues(source);
			 

			MarkOld();
		}

		/// <summary>
		/// Construye el objeto y se encarga de obtener los
		/// hijos si los tiene y se solicitan
		/// </summary>
		/// <param name="source">DataReader fuente</param>
        private void Fetch(IDataReader source)
        {
			_base.CopyValues(source);

			   

            MarkOld();
        }

		/// <summary>
		/// Inserta el registro en la base de datos
		/// </summary>
		/// <param name="parent">Lista padre</param>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para insertar elementos<remarks/>
		internal void Insert(Festivos parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
					
			ValidationRules.CheckRules();

			if (!IsValid)
				throw new iQValidationException(Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

			parent.Session().Save(this);
			
			MarkOld();
		}
	
		/// <summary>
		/// Actualiza el registro en la base de datos
		/// </summary>
		/// <param name="parent">Lista padre</param>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para actualizar elementos<remarks/>
		internal void Update(Festivos parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			ValidationRules.CheckRules();

			if (!IsValid)
				throw new iQValidationException(Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

			SessionCode = parent.SessionCode;
			FestivoRecord obj = Session().Get<FestivoRecord>(Oid);
			obj.CopyValues(this._base.Record);
			Session().Update(obj);
			
			MarkOld();
		}
		
		/// <summary>
		/// Borra el registro de la base de datos
		/// </summary>
		/// <param name="parent">Lista padre</param>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para borrar elementos<remarks/>
		internal void DeleteSelf(Festivos parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;

			SessionCode = parent.SessionCode;
			Session().Delete(Session().Get<Festivo>(Oid));
		
			MarkNew(); 
		}

		#endregion
		
		#region Root Data Access
		
		/// <summary>
		/// Obtiene un registro de la base de datos
		/// </summary>
		/// <param name="criteria">Criterios de consulta</param>
		/// <remarks>Lo llama el DataPortal tras generar el objeto</remarks>
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			try
			{
				SessionCode = criteria.SessionCode;
				Childs = criteria.Childs;
				
				if (nHMng.UseDirectSQL)
				{
					//Festivo.DoLOCK(Session());
					IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());
					
					if (reader.Read())
						_base.CopyValues(reader);					
		}

				MarkOld();
			}
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
		}
		
		/// <summary>
		/// Inserta un elemento en la tabla
		/// </summary>
		/// <remarks>Lo llama el DataPortal cuando se llama al Save y el objeto isNew</remarks>
		[Transactional(TransactionalTypes.Manual)]
		protected override void DataPortal_Insert()
		{
			SessionCode = OpenSession();
			BeginTransaction();

			Session().Save(this.Base.Record);
		}
		
		/// <summary>
		/// Modifica un elemento en la tabla
		/// </summary>
		/// <remarks>Lo llama el DataPortal cuando se llama al Save y el objeto isDirty</remarks>
		[Transactional(TransactionalTypes.Manual)]
		protected override void DataPortal_Update()
		{
			if (!IsDirty) return;
			
			FestivoRecord obj = Session().Get<FestivoRecord>(Oid);
			obj.CopyValues(this._base.Record);
			Session().Update(obj);
			MarkOld();
			
		}
		
		/// <summary>
		/// Borrado aplazado, no se ejecuta hasta que se llama al Save
		/// </summary>
		[Transactional(TransactionalTypes.Manual)]
		protected override void DataPortal_DeleteSelf()
		{
            DataPortal_Delete(new CriteriaCs(Oid));
		}
		
		/// <summary>
		/// Elimina un elemento en la tabla
		/// </summary>
		/// <remarks>Lo llama el DataPortal</remarks>
		[Transactional(TransactionalTypes.Manual)]
		private void DataPortal_Delete(CriteriaCs criteria)
		{
			try
			{
				// Iniciamos la conexion y la transaccion
				SessionCode = OpenSession();
				BeginTransaction();
					
				//Si no hay integridad referencial, aquí se deben borrar las listas hijo
				CriteriaEx criterio = GetCriteria();
				criterio.AddOidSearch(criteria.Oid);
				Session().Delete((FestivoRecord)(criterio.UniqueResult()));
				Transaction().Commit();
			}
			catch (Exception ex)
			{
				if (Transaction() != null) Transaction().Rollback();
				throw new iQPersistentException(iQExceptionHandler.GetAllMessages(ex));
			}
			finally
			{
				CloseSession();
			}
		}		
		
		#endregion
		
				
        #region SQL

        public new static string SELECT(long oid) { return SELECT(oid, true); }
		public static string SELECT(QueryConditions conditions) { return SELECT(conditions, true); }
		
        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT F.*";

            return query;
        }

		internal static string WHERE(QueryConditions conditions)
		{
			string query = " WHERE TRUE";

			//query = " WHERE (F.\"FECHA\" BETWEEN '" + conditions.FechaIniLabel + "' AND '" + conditions.FechaFinLabel + "')";
 
            if (conditions.Festivo != null)
		       if (conditions.Festivo.Oid != 0)
                   query += " AND F.\"OID\" = " + conditions.Festivo.Oid;
				
			

			return query;
		}
		
        internal static string SELECT(long oid, bool lock_table)
        {			
			string query = string.Empty;

			QueryConditions conditions = new QueryConditions { Festivo = Festivo.New().GetInfo(false) };
			conditions.Festivo.Oid = oid;

			query = SELECT(conditions, lock_table);

			return query;
        }
	
	    internal static string SELECT(QueryConditions conditions, bool lock_table)
        {
            string f = nHManager.Instance.GetSQLTable(typeof(FestivoRecord));
            
			string query;

            query = SELECT_FIELDS() +
                    " FROM " + f + " AS F";
					
			query += WHERE(conditions);	
		
			//if (lock_table) query += " FOR UPDATE OF F NOWAIT";

            return query;
        }
		
		#endregion

	}
	
	[Serializable()]
	public class FestivoMap : ClassMapping<FestivoRecord>
	{
	
		public FestivoMap()
		{
			Table("`Festivos`");
			//Schema("``");
			Lazy(true);

            Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Festivos_OID_seq`" })); map.Column("`OID`"); });
			
			Property(x => x.FechaInicio, map =>
			{
				map.Column("`FECHA_INICIO`");
			
				map.NotNullable(false);
			
			
				map.Length(32768);

            });

            Property(x => x.FechaFin, map =>
            {
                map.Column("`FECHA_FIN`");

                map.NotNullable(false);


                map.Length(32768);

            });
			
			Property(x => x.Anual, map =>
			{
				map.Column("`ANUAL`");
			
				map.NotNullable(false);
			
			
				map.Length(32768);
			
			});
			
			Property(x => x.Tipo, map =>
			{
				map.Column("`TIPO`");
			
				map.NotNullable(false);
			
			
				map.Length(32768);
			
			});
			
			Property(x => x.Titulo, map =>
			{
				map.Column("`TITULO`");
			
				map.NotNullable(false);
			
			
				map.Length(32768);

            });
			
			Property(x => x.Descripcion, map =>
			{
				map.Column("`DESCRIPCION`");
			
				map.NotNullable(false);
			
			
				map.Length(32768);

            });
			
		}
	}
}
