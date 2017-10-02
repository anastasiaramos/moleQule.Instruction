using System;
using System.Collections;
using System.Collections.Generic;
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
	public class ModuloRecord : RecordBase
	{
		#region Attributes

		private string _codigo = string.Empty;
		private string _texto = string.Empty;
		private long _numero;
		private long _serial;
		private string _alias = string.Empty;
		private string _numero_modulo = string.Empty;
		private string _numero_orden = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual long Numero { get { return _numero; } set { _numero = value; } }
		public virtual long Serial { get { return _serial; } set { _serial = value; } }
		public virtual string Alias { get { return _alias; } set { _alias = value; } }
		public virtual string NumeroModulo { get { return _numero_modulo; } set { _numero_modulo = value; } }
		public virtual string NumeroOrden { get { return _numero_orden; } set { _numero_orden = value; } }

		#endregion
		
		#region Business Methods
		
		public ModuloRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_numero = Format.DataReader.GetInt64(source, "NUMERO");
			_serial = Format.DataReader.GetInt64(source, "SERIAL");
			_alias = Format.DataReader.GetString(source, "ALIAS");
			_numero_modulo = Format.DataReader.GetString(source, "NUMERO_MODULO");
			_numero_orden = Format.DataReader.GetString(source, "NUMERO_ORDEN");

		}		
		public virtual void CopyValues(ModuloRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_codigo = source.Codigo;
			_texto = source.Texto;
			_numero = source.Numero;
			_serial = source.Serial;
			_alias = source.Alias;
			_numero_modulo = source.NumeroModulo;
			_numero_orden = source.NumeroOrden;
		}
		
		#endregion	
	}

    [Serializable()]
	public class ModuloBase 
	{	 
		#region Attributes
		
		private ModuloRecord _record = new ModuloRecord();
		
		#endregion
		
		#region Properties
		
		public ModuloRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Modulo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(ModuloInfo source)
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
	public class Modulo : BusinessBaseEx<Modulo>
	{	 
		#region Attributes
		
		protected ModuloBase _base = new ModuloBase();

        private Submodulos _submodulos = Submodulos.NewChildList();
        private Material_Plans _materiales = Material_Plans.NewChildList();		

		#endregion
		
		#region Properties
		
		public ModuloBase Base { get { return _base; } }
		
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
		public virtual string Codigo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Codigo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Codigo.Equals(value))
				{
					_base.Record.Codigo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Texto
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Texto;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Texto.Equals(value))
				{
					_base.Record.Texto = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Numero
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Numero;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Numero.Equals(value))
				{
					_base.Record.Numero = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual long Serial
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Serial;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Serial.Equals(value))
				{
					_base.Record.Serial = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string Alias
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Alias;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Alias.Equals(value))
				{
					_base.Record.Alias = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string NumeroModulo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NumeroModulo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.NumeroModulo.Equals(value))
				{
					_base.Record.NumeroModulo = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual string NumeroOrden
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.NumeroOrden;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.NumeroOrden.Equals(value))
				{
					_base.Record.NumeroOrden = value;
					PropertyHasChanged();
				}
			}
		}
	

        public virtual Submodulos Submodulos
        {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        get
        {
            CanReadProperty(true);
            return _submodulos;
        }

        set
        {
            _submodulos = value;
        }
        }
        public virtual Material_Plans Materiales
        {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        get
        {
            CanReadProperty(true);
            return _materiales;
        }

        set
        {
            _materiales = value;
        }
        }

        public override bool IsValid
        {
        get { return base.IsValid /*&& _p_examenes.IsValid*/ && _submodulos.IsValid /*&& _examenes.IsValid*/ && _materiales.IsValid /*&& _plantillas.IsValid*/; }
        }
        public override bool IsDirty
        {
        get { return base.IsDirty /*|| _p_examenes.IsDirty*/ || _submodulos.IsDirty /*|| _examenes.IsDirty*/ || _materiales.IsDirty /*|| _plantillas.IsDirty*/; }
        }
		
		
		#endregion
		
		#region Business Methods

        /// <summary>
        /// Clona la entidad y sus subentidades y las marca como nuevas
        /// </summary>
        /// <returns>Una entidad clon</returns>		
        public virtual Modulo CloneAsNew()
        {
        Modulo clon = base.Clone();

        // Se define el Oid como nueva entidad
        Random rd = new Random();
        clon.Oid = rd.Next();
        clon.Codigo = (0).ToString(Resources.Defaults.MODULO_CODE_FORMAT);
        clon.SessionCode = Modulo.OpenSession();
        Modulo.BeginTransaction(clon.SessionCode);

        clon.MarkNew();
        //clon.Preguntas.MarkAsNew();
        //clon.PExamenes.MarkAsNew();
        clon.Submodulos.MarkAsNew();
        //clon.Examenes.MarkAsNew();
        clon.Materiales.MarkAsNew();
        //clon.Plantillas.MarkAsNew();
        return clon;
        }

        /// <summary>
        /// Devuelve el siguiente código de Módulo.
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        public static string GetNewCode()
        {
        Int64 lastcode = Modulo.GetNewSerial();

        // Devolvemos el siguiente codigo de cliente 
        return lastcode.ToString(Resources.Defaults.MODULO_CODE_FORMAT);
        }

        /// <summary>
        /// Devuelve el siguiente Serial de Alumno.
        /// </summary>
        /// <returns>Código de 9 cifras</returns>
        private static Int64 GetNewSerial()
        {
        // Obtenemos la lista de clientes ordenados por serial
        SortedBindingList<ModuloInfo> modulos =
            ModuloList.GetSortedList("Serial", ListSortDirection.Ascending);

        // Obtenemos el último serial de servicio
        Int64 lastcode;

        if (modulos.Count > 0)
            lastcode = modulos[modulos.Count - 1].Serial;
        else
            lastcode = Convert.ToInt64(Resources.Defaults.MODULO_CODE_FORMAT);

        lastcode++;
        return lastcode;
        }
        
        public virtual void UpdateNumeroOrden()
        {
        // Actualizamos el campo de ordenación

        NumeroOrden = string.Empty;

        int i = 0;
        while (i < NumeroModulo.Length && Char.IsNumber(NumeroModulo[i]))
        {
            NumeroOrden = NumeroOrden += NumeroModulo[i].ToString();
            i++;
        }

        if (NumeroOrden != string.Empty)
            NumeroOrden = Convert.ToInt32(NumeroOrden).ToString(Resources.Defaults.MODULO_CODE_FORMAT);

        //todavía quedan caracteres
        if (NumeroModulo.Length > i)
            NumeroOrden += "-" + NumeroModulo.Substring(i);

        }
			
		#endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Codigo");

            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "Alias");

            ValidationRules.AddRule(
                Csla.Validation.CommonRules.StringRequired, "NumeroModulo");


            //ValidationRules.AddRule(
            //    Csla.Validation.CommonRules.StringRequired, "NumeroOrden");

        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.MODULO);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.MODULO);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.MODULO);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.MODULO);

        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION New
        /// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
        /// pero es protected por exigencia de NHibernate.
        /// </summary>
        protected Modulo() { }

        private Modulo(IDataReader reader)
        {
            Fetch(reader);
        }

        private Modulo (Modulo source)
        {
            Fetch(source);
        }

        public static Modulo New()
        {
            if (!CanAddObject())
	            throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
            return DataPortal.Create<Modulo>(new CriteriaCs(-1));
        }

        public static Modulo Get(long oid, bool childs)
        {
	        if (!CanGetObject())
		        throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

	        CriteriaEx criteria = Modulo.GetCriteria(Modulo.OpenSession());
            criteria.Childs = childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Modulo.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

	        Modulo.BeginTransaction(criteria.Session);
	        return DataPortal.Fetch<Modulo>(criteria);
        }

        public static Modulo Get(long oid) { return Get(oid, true); }

        internal static Modulo Get(IDataReader reader) { return new Modulo(reader); }

        internal static Modulo Get(Modulo source) { return new Modulo(source); }

        public virtual void LoadChilds(Type type, bool get_childs, bool get_gchilds)
        {
            if (type.Equals(typeof(Submodulos)))
            {
                _submodulos = Submodulos.GetChildList(this, get_childs, get_gchilds);
            }
            else if (type.Equals(typeof(Material_Plans)))
            {
                _materiales = Material_Plans.GetChildList(this, get_childs);
            }
        }

        /// <summary>
        /// Construye y devuelve un objeto de solo lectura copia de si mismo.
        /// </summary>
        /// <param name="get_childs">True si se quiere que traiga los hijos</param>
        /// <returns></returns>
        public virtual ModuloInfo GetInfo(bool get_childs)
        {  
	        if (!CanGetObject())
		        throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new ModuloInfo(this, get_childs);
        }

        public virtual ModuloInfo GetInfo() { return GetInfo(true); }

        /// <summary>
        /// Borrado inmediato, no cabe "undo"
        /// (La función debe ser "estática")
        /// </summary>
        /// <param name="oid"></param>
        public static void Delete(long oid)
        {
	        if (!CanDeleteObject())
		        throw new System.Security.SecurityException(moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
        	
	        DataPortal.Delete(new CriteriaCs(oid));
        }

        /// <summary>
        /// Elimina todos los Clientes, Contactos de Cliente y Cuentas de Cliente
        /// </summary>
        public static void DeleteAll()
        {
	        //Iniciamos la conexion y la transaccion
	        int sessCode = Modulo.OpenSession();
	        ISession sess = Modulo.Session(sessCode);
	        ITransaction trans = Modulo.BeginTransaction(sessCode);

	        try
	        {
	        sess.Delete("from  Modulo");
		        trans.Commit();
	        }
	        catch (Exception ex)
	        {
		        if (trans != null) trans.Rollback();
		        iQExceptionHandler.TreatException(ex);
	        }
	        finally
	        {
		        Modulo.CloseSession(sessCode);
	        }
        }

        public override Modulo Save()
        {
	        // Por la posible doble interfaz Root/Child
            if (IsChild) throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);

	        if (IsDeleted && !CanDeleteObject())
		        throw new System.Security.SecurityException(
		          moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
	        else if (IsNew && !CanAddObject())
		        throw new System.Security.SecurityException(
		          moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
	        else if (!CanEditObject())
	        {
		        throw new System.Security.SecurityException(
		          moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);
	        }

            try
            {
                ValidationRules.CheckRules();

                base.Save();

                //_preguntas.Update(this);
                //if (_p_examenes != null) _p_examenes.Update(this);
                if (_submodulos != null) _submodulos.Update(this);
                //if (_examenes != null) _examenes.Update(this);
                if (_materiales != null) _materiales.Update(this);
                //if (_plantillas != null) _plantillas.Update(this);

                if (!SharedTransaction) Transaction().Commit();
                return this;
            }
            catch (Exception ex)
            {
                if (!SharedTransaction) if (!SharedTransaction && Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
                return this;
            }
            finally
            {
                if (!SharedTransaction)
                {
                    if (CloseSessions && (this.IsNew || Transaction().WasCommitted)) CloseSession();
                    else BeginTransaction();
                }
            }
        }

        #endregion

        #region Common Data Access

        [RunLocal()]
        private void DataPortal_Create(CriteriaCs criteria)
        {
	        Random r = new Random();
	        Oid = (long)r.Next();
            Codigo = (0).ToString(Resources.Defaults.MODULO_CODE_FORMAT);
            //_preguntas = Preguntas.NewChildList();
            //_p_examenes = PreguntaExamens.NewChildList();
            _submodulos = Submodulos.NewChildList();
            //_examenes = Examens.NewChildList();
            _materiales = Material_Plans.NewChildList();
            //_plantillas = PlantillaExamenes.NewChildList();
        }

        #endregion

        #region Root Data Access

        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            try
            {
                SessionCode = criteria.SessionCode;
                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {
                    Modulo.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;
                        
                        Submodulo.DoLOCK(Session());
                        query = Submodulos.SELECT_BY_MODULO(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _submodulos = Submodulos.GetChildList(criteria.SessionCode, reader);
                        
                        Material_Plan.DoLOCK(Session());
                        query = Material_Plans.SELECT(GetInfo(false));
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _materiales = Material_Plans.GetChildList(reader);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
        }

        private void Fetch(Modulo source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        //Fetch independiente de DataPortal para generar un Cliente a partir de un IDataReader
        private void Fetch(IDataReader source)
        {
            try
            {
                _base.CopyValues(source);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Insert()
        {
            try
            {
                SessionCode = OpenSession();
                BeginTransaction();
                UpdateNumeroOrden();
                Codigo = GetNewCode();
                Serial = GetNewSerial();
                Session().Save(this.Base.Record);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_Update()
        {
            if (IsDirty)
            {
                try
                {
                    ModuloRecord obj = Session().Get<ModuloRecord>(Oid);

                    UpdateNumeroOrden();
                    obj.CopyValues(this.Base.Record);
                    Session().Update(obj);
                }
                catch (Exception ex)
                {
                    iQExceptionHandler.TreatException(ex);
                }
            }
        }

        [Transactional(TransactionalTypes.Manual)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new CriteriaCs(Oid));
        }

        [Transactional(TransactionalTypes.Manual)]
        private void DataPortal_Delete(CriteriaCs criteria)
        {
            try
            {
                // Iniciamos la conexion y la transaccion
                SessionCode = OpenSession();
                BeginTransaction();
                CriteriaEx criterio = GetCriteria();
                criterio.AddOidSearch(criteria.Oid);
                Session().Delete((ModuloRecord)(criterio.UniqueResult()));

                Transaction().Commit();
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                CloseSession();
            }
        }

        #endregion

        #region Commands

        public static bool Exists(string codigo)
        {
            ExistsCmd result;
            result = DataPortal.Execute<ExistsCmd>(new ExistsCmd(codigo));
            return result.Exists;
        }

        [Serializable()]
        private class ExistsCmd : CommandBase
        {
        private string _codigo;
        private bool _exists = false;

        public bool Exists
        {
            get { return _exists; }
        }

        public ExistsCmd(string codigo)
        {
            _codigo = codigo;
        }

        protected override void DataPortal_Execute()
        {
            // Buscar por codigo
            CriteriaEx criteria = Modulo.GetCriteria(Modulo.OpenSession());
            criteria.AddCodeSearch(_codigo);
            ModuloList list = ModuloList.GetList(criteria);
            _exists = !(list.Count == 0);
        }
        }
        
        #endregion
    }
}

