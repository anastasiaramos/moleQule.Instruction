using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
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
	public class ExamenPromocionRecord : RecordBase
	{
		#region Attributes

		private long _oid_examen;
		private long _oid_promocion;
  
		#endregion
		
		#region Properties
		public virtual long OidExamen { get { return _oid_examen; } set { _oid_examen = value; } }
		public virtual long OidPromocion { get { return _oid_promocion; } set { _oid_promocion = value; } }
		
		#endregion
		
		#region Business Methods
		
		public ExamenPromocionRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_examen = Format.DataReader.GetInt64(source, "OID_EXAMEN");
			_oid_promocion = Format.DataReader.GetInt64(source, "OID_PROMOCION");

		}
		
		public virtual void CopyValues(ExamenPromocionRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_examen = source.OidExamen;
			_oid_promocion = source.OidPromocion;
		}
		#endregion	
	}

    [Serializable()]
	public class ExamenPromocionBase 
	{	 
		#region Attributes
		
		public ExamenPromocionRecord _record = new ExamenPromocionRecord();
		
		#endregion
		
		#region Properties
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}
		
		internal void CopyValues(ExamenPromocion source)
		{
			if (source == null) return;
			
			_record.CopyValues(source._base._record);
		}
		internal void CopyValues(ExamenPromocionInfo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base._record);
		}
		#endregion	
	}
		
	/// <summary>
	/// Editable Child Business Object
	/// </summary>	
    [Serializable()]
	public class ExamenPromocion : BusinessBaseEx<ExamenPromocion>
	{	 
		#region Attributes
		
		public ExamenPromocionBase _base = new ExamenPromocionBase();
		

		#endregion
		
		#region Properties
public override long Oid
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _base._record.Oid;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				
				if (!_base._record.Oid.Equals(value))
				{
					_base._record.Oid = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidExamen
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _base._record.OidExamen;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				
				if (!_base._record.OidExamen.Equals(value))
				{
					_base._record.OidExamen = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long OidPromocion
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _base._record.OidPromocion;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				CanWriteProperty(true);
				
				if (!_base._record.OidPromocion.Equals(value))
				{
					_base._record.OidPromocion = value;
					PropertyHasChanged();
				}
			}
		}
			
		
		#endregion
		
		#region Business Methods
		
		public virtual ExamenPromocion CloneAsNew()
		{
			ExamenPromocion clon = base.Clone();
			
			//Se definen el Oid y el Coidgo como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();
			
			clon.SessionCode = ExamenPromocion.OpenSession();
			ExamenPromocion.BeginTransaction(clon.SessionCode);
			
			clon.MarkNew();
			
			return clon;
		}
		
		protected virtual void CopyFrom(ExamenPromocionInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidExamen = source.OidExamen;
			OidPromocion = source.OidPromocion;
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
		 
		#region Common Factory Methods
		 
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New o NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
		/// pero debe ser protected por exigencia de NHibernate.
		/// Debe ser public para que funcionen los DataGridView
		/// </summary>
		protected ExamenPromocion ()
		{
			// Si se necesita constructor público para este objeto hay que añadir el MarkAsChild() debido a la interfaz Child
			// y el código que está en el DataPortal_Create debería ir aquí
		
		}
				
		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE. LAS UTILIZAN LAS FUNCIONES DE CREACION DE LISTAS
		/// </summary>
		private ExamenPromocion(ExamenPromocion source, bool childs)
        {
			MarkAsChild();
			Childs = childs;
            Fetch(source);
        }
        private ExamenPromocion(int sessionCode, IDataReader source, bool childs)
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
		public static ExamenPromocion NewChild() 
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);
			
			ExamenPromocion obj = DataPortal.Create<ExamenPromocion>(new CriteriaCs(-1));		
			obj.MarkAsChild();
            return obj;
		}
		
		/// <summary>
		/// Crea un objeto
		/// </summary>
		/// <param name="source">ExamenPromocion con los datos para el objeto</param>
		/// <returns>Objeto creado</returns>
		/// <remarks>
		/// La utiliza la BusinessListBaseEx correspondiente para montar la lista
		/// NO OBTIENE los hijos. Para ello utilice GetChild(ExamenPromocion source, bool childs)
		/// <remarks/>
		internal static ExamenPromocion GetChild(ExamenPromocion source) { return new ExamenPromocion(source, false); }
		internal static ExamenPromocion GetChild(ExamenPromocion source, bool childs) { return new ExamenPromocion(source, childs); }
        internal static ExamenPromocion GetChild(int sessionCode, IDataReader source) { return new ExamenPromocion(sessionCode, source, false); }
        internal static ExamenPromocion GetChild(int sessionCode, IDataReader source, bool childs) { return new ExamenPromocion(sessionCode, source, childs); }
		
		/// <summary>
		/// Construye y devuelve un objeto de solo lectura copia de si mismo.
		/// </summary>
		/// <param name="get_childs">Flag para solicitar que se copien los hijos</param>
		/// <returns>Réplica de solo lectura del objeto</returns>
		public virtual ExamenPromocionInfo GetInfo() { return GetInfo(true); }	
		public virtual ExamenPromocionInfo GetInfo (bool childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);
			
			return new ExamenPromocionInfo(this, childs);
		}
		
		#endregion
				
		
		#region Child Factory Methods
		
		/// <summary>
        /// NO UTILIZAR DIRECTAMENTE. LO UTILIZA LA FUNCION DE CREACION DE LA LISTA DEL PADRE
        /// </summary>
        private ExamenPromocion(Examen parent)
        {
            OidExamen = parent.Oid;
            MarkAsChild();
        }
		
		/// <summary>
		/// Crea un nuevo objeto hijo
		/// </summary>
		/// <param name="parent">Objeto padre</param>
		/// <returns>Nuevo objeto creado</returns>
		internal static ExamenPromocion NewChild(Examen parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);

			return new ExamenPromocion(parent);
		}
				
		/// <summary>
        /// Borrado aplazado, es posible el undo 
        /// (La función debe ser "no estática")
        /// </summary>
        public override void Delete()
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException(Library.Resources.Messages.USER_NOT_ALLOWED);

            MarkDeleted();
        }
		
		/// <summary>
		/// No se debe utilizar esta función para guardar. Hace falta el padre, que
		/// debe utilizar Insert o Update en sustitución de Save.
		/// </summary>
		/// <returns></returns>
		public override ExamenPromocion Save()
		{
			throw new iQException(Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
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
		private void Fetch(ExamenPromocion source)
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
		internal void Insert(ExamenPromociones parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
					
			ValidationRules.CheckRules();

			if (!IsValid)
				throw new iQValidationException(Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

			parent.Session().Save(this._base._record);
			
			MarkOld();
		}
	
		/// <summary>
		/// Actualiza el registro en la base de datos
		/// </summary>
		/// <param name="parent">Lista padre</param>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para actualizar elementos<remarks/>
		internal void Update(ExamenPromociones parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;
			
			ValidationRules.CheckRules();

			if (!IsValid)
				throw new iQValidationException(Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

			SessionCode = parent.SessionCode;
			ExamenPromocionRecord obj = Session().Get<ExamenPromocionRecord>(Oid);
			obj.CopyValues(this._base._record);
			Session().Update(obj);
			
			MarkOld();
		}
		
		/// <summary>
		/// Borra el registro de la base de datos
		/// </summary>
		/// <param name="parent">Lista padre</param>
		/// <remarks>La utiliza la BusinessListBaseEx correspondiente para borrar elementos<remarks/>
		internal void DeleteSelf(ExamenPromociones parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;

			SessionCode = parent.SessionCode;
			Session().Delete(Session().Get<ExamenPromocion>(Oid));
		
			MarkNew(); 
		}

		#endregion
		
		#region Child Data Access

		
		/// <summary>
		/// Inserta un registro en la base de datos
		/// </summary>
		/// <param name="parent">Objeto padre</param>
		internal void Insert(Examen parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			//Debe obtener la sesion del padre pq el objeto es padre a su vez
			SessionCode = parent.SessionCode;

			OidExamen = parent.Oid;	
			
			ValidationRules.CheckRules();
			
			if (!IsValid)
				throw new iQValidationException(Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

			parent.Session().Save(this._base._record);			
			
			MarkOld();
		}

		/// <summary>
		/// Actualiza un registro en la base de datos
		/// </summary>
		/// <param name="parent">Objeto padre</param>
		internal void Update(Examen parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			//Debe obtener la sesion del padre pq el objeto es padre a su vez
			SessionCode = parent.SessionCode;

			OidExamen = parent.Oid;

			ValidationRules.CheckRules();

			if (!IsValid)
				throw new iQValidationException(Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

			ExamenPromocionRecord obj = parent.Session().Get<ExamenPromocionRecord>(Oid);
			obj.CopyValues(this._base._record);
			parent.Session().Update(obj);
			
			MarkOld();
		}

		/// <summary>
		/// Borra un registro de la base de datos.
		/// </summary>
		/// <param name="parent">Objeto padre</param>
		/// <remarks>Borrado inmediato<remarks/>
		internal void DeleteSelf(Examen parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;

			SessionCode = parent.SessionCode;
			Session().Delete(Session().Get<ExamenPromocionRecord>(Oid));

			MarkNew();
		}
		
		#endregion
				
        #region SQL

        public new static string SELECT(long oid) { return SELECT(oid, true); }
		public static string SELECT(QueryConditions conditions) { return SELECT(conditions, true); }
		
		public static string SELECT(Examen item) 
		{ 
			Library.Instruction.QueryConditions conditions = new Library.Instruction.QueryConditions { Examen = item.GetInfo(false) };
			return SELECT(conditions, false); 
		}
			
		
        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT E.*";

            return query;
        }

		internal static string WHERE(QueryConditions conditions)
		{
			string query;

			query = " WHERE TRUE";//(E.\"FECHA\" BETWEEN '" + conditions.FechaIniLabel + "' AND '" + conditions.FechaFinLabel + "')";
 
            if (conditions.ExamenPromocion != null)
		       if (conditions.ExamenPromocion.Oid != 0)
                   query += " AND E.\"OID\" = " + conditions.ExamenPromocion.Oid;
				
			
            if (conditions.Examen != null) query += " AND E.\"OID_EXAMEN\" = " + conditions.Examen.Oid;
            
			

			return query;
		}
		
        internal static string SELECT(long oid, bool lock_table)
        {			
			string query = string.Empty;

			QueryConditions conditions = new QueryConditions { ExamenPromocion = ExamenPromocion.NewChild().GetInfo(false) };
			conditions.ExamenPromocion.Oid = oid;

			query = SELECT(conditions, lock_table);

			return query;
        }
	
	    internal static string SELECT(QueryConditions conditions, bool lock_table)
        {
            string e = nHManager.Instance.GetSQLTable(typeof(ExamenPromocionRecord));
            
			string query;

            query = SELECT_FIELDS() +
                    " FROM " + e + " AS E";
					
			query += WHERE(conditions);	
		
			//if (lock_table) query += " FOR UPDATE OF E NOWAIT";

            return query;
        }
		
		#endregion

	}
	
	[Serializable()]
	public class ExamenPromocionMap : ClassMapping<ExamenPromocionRecord>
	{
	
		public ExamenPromocionMap()
		{
			Table("`Examen_Promocion`");
			//Schema("``");
			Lazy(true);



            Id(x => x.Oid, map => 
            { map.Generator(Generators.Sequence, 
                gmap => gmap.Params(new { sequence = "`Examen_Promocion_OID_seq`" })); 
                map.Column("`OID`"); });
			
			Property(x => x.OidExamen, map =>
			{
				map.Column("`OID_EXAMEN`");
			
			
				map.Length(32768);
			
			});
			
			Property(x => x.OidPromocion, map =>
			{
				map.Column("`OID_PROMOCION`");
			
			
				map.Length(32768);
			
			});
			
		}
	}
}
