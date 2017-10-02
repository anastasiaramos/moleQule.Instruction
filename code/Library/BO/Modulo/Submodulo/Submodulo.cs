using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class SubmoduloRecord : RecordBase
	{
		#region Attributes

		private string _codigo = string.Empty;
		private long _oid_modulo;
		private string _texto = string.Empty;
		private string _codigo_orden = string.Empty;
  
		#endregion
		
		#region Properties
		
				public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
		public virtual string Texto { get { return _texto; } set { _texto = value; } }
		public virtual string CodigoOrden { get { return _codigo_orden; } set { _codigo_orden = value; } }

		#endregion
		
		#region Business Methods
		
		public SubmoduloRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_oid_modulo = Format.DataReader.GetInt64(source, "OID_MODULO");
			_texto = Format.DataReader.GetString(source, "TEXTO");
			_codigo_orden = Format.DataReader.GetString(source, "CODIGO_ORDEN");

		}		
		public virtual void CopyValues(SubmoduloRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_codigo = source.Codigo;
			_oid_modulo = source.OidModulo;
			_texto = source.Texto;
			_codigo_orden = source.CodigoOrden;
		}
		
		#endregion	
	}

    [Serializable()]
	public class SubmoduloBase 
	{	 
		#region Attributes
		
		private SubmoduloRecord _record = new SubmoduloRecord();
		
		#endregion
		
		#region Properties
		
		public SubmoduloRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Submodulo source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(SubmoduloInfo source)
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
	public class Submodulo : BusinessBaseEx<Submodulo>
	{	 
		#region Attributes
		
		protected SubmoduloBase _base = new SubmoduloBase();

		private Temas _temas = Temas.NewChildList();
		

		#endregion
		
		#region Properties
		
		public SubmoduloBase Base { get { return _base; } }
		
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
		public virtual string CodigoOrden
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.CodigoOrden;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.CodigoOrden.Equals(value))
				{
					_base.Record.CodigoOrden = value;
					PropertyHasChanged();
				}
			}
		}

		public virtual Temas Temas
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				CanReadProperty(true);
				return _temas;
			}

			set
			{
				_temas = value;
			}
		}

		public override bool IsValid
		{
			get { return base.IsValid && _temas.IsValid; }
		}
		public override bool IsDirty
		{
			get { return base.IsDirty || _temas.IsDirty; }
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		protected virtual void CopyFrom(SubmoduloInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			Codigo = source.Codigo;
			OidModulo = source.OidModulo;
			Texto = source.Texto;
			CodigoOrden = source.CodigoOrden;
		}

		public virtual void UpdateCodigoOrden()
		{
			// Actualizamos el campo de ordenación
            //if (_codigo.IndexOf(".") == -1)
            //{
            //    _codigo_orden = _codigo;
            //    CodigoOrden = _codigo;
            //}
            //else
            //{
            //    string pospunto = _codigo.Substring(_codigo.IndexOf(".") + 1);

            //    try
            //    {
            //        //Comprobamos que es un nº
            //        Convert.ToInt32(pospunto);

            //        if (!pospunto.StartsWith("0") && pospunto.Length == 1)
            //        {
            //            _codigo_orden = _codigo.Substring(0, _codigo.IndexOf(".") + 1) + "0" + pospunto;
            //            CodigoOrden = _codigo_orden;
            //        }
            //        else
            //        {
            //            _codigo_orden = _codigo;
            //            CodigoOrden = _codigo;
            //        }

            //    }
            //    catch
            //    {
            //        _codigo_orden = _codigo;
            //        CodigoOrden = _codigo;
            //    }
            //}// Actualizamos el campo de ordenación

            bool es_numero = false;
            CodigoOrden = string.Empty;

            for (int i = 0; i < Codigo.Length; i++)
            {
                if (Codigo[i] != '.')
                {
                    if (char.IsNumber(Codigo[i]))
                    {
                        if (!es_numero)
                        {
                            es_numero = true;
                            if (!CodigoOrden.EndsWith(".")
                                && CodigoOrden != string.Empty)
                                CodigoOrden += ".";
                        }
                    }
                    else
                    {
                        if (es_numero)
                        {
                            es_numero = false;
                            if (!CodigoOrden.EndsWith(".")
                                && CodigoOrden != string.Empty)
                                CodigoOrden += ".";
                        }
                    }
                }
                CodigoOrden += Codigo[i];
            }

            string codigo = CodigoOrden;


            if (codigo.IndexOf(".") == -1)
            {
                CodigoOrden = codigo;
                CodigoOrden = codigo;
            }
            else
            {
                CodigoOrden = string.Empty;
                string cadena = codigo;
                while (cadena != string.Empty)
                {
                    int pos = cadena.IndexOf(".");
                    string prepunto = string.Empty;

                    if (pos == -1)
                    {
                        prepunto = cadena;
                        cadena = string.Empty;
                    }
                    else
                    {
                        prepunto = cadena.Substring(0, pos);
                        cadena = cadena.Substring(pos + 1);
                    }

                    try
                    {
                        int valor = Convert.ToInt32(prepunto);
                        CodigoOrden += valor.ToString("00");
                    }
                    catch
                    {
                        CodigoOrden += prepunto;
                    }

                    if (cadena != string.Empty)
                        CodigoOrden += ".";

                }
                CodigoOrden = CodigoOrden;
            }
		}

		/// <summary>
		/// Clona la entidad y sus subentidades y las marca como nuevas
		/// </summary>
		/// <returns>Una entidad clon</returns>
		public virtual Submodulo CloneAsNew()
		{
			Submodulo clon = base.Clone();

			// Se define el Oid como nueva entidad
			Random rd = new Random();
			clon.Oid = rd.Next();

			clon.Codigo = (0).ToString(Resources.Defaults.SUBMODULO_CODE_FORMAT);
			clon.SessionCode = Submodulo.OpenSession();
			Submodulo.BeginTransaction(clon.SessionCode);
			clon.MarkNew();

			return clon;
		}
		
			
		#endregion

		#region Validation Rules

		protected override void AddBusinessRules()
		{
			ValidationRules.AddRule(CommonRules.StringRequired, "Codigo");

			ValidationRules.AddRule(CommonRules.MinValue<long>,
									new CommonRules.MinValueRuleArgs<long>("OidModulo", 1));

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

		#region Common Factory Methods

		/// <summary>
		/// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
		/// Debería ser private para CSLA porque la creación requiere el uso de los factory methods,
		/// pero debe ser protected por exigencia de NHibernate
		/// y public para que funcionen los DataGridView
		/// </summary>
		public Submodulo()
		{
			MarkAsChild();
			Random r = new Random();
            Oid = (long)r.Next();
		}

		public virtual SubmoduloInfo GetInfo(bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new SubmoduloInfo(this, get_childs);
		}

		public virtual SubmoduloInfo GetInfo()
		{
			return GetInfo(true);
		}

		#endregion

		#region Root Factory Methods

		public static Submodulo New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			return DataPortal.Create<Submodulo>(new CriteriaCs(-1));
		}

		public static Submodulo Get(long oid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			CriteriaEx criteria = Submodulo.GetCriteria(Submodulo.OpenSession());

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Submodulo.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

			Submodulo.BeginTransaction(criteria.Session);
			return DataPortal.Fetch<Submodulo>(criteria);
		}

		public static Submodulo Get(CriteriaEx criteria)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			Submodulo.BeginTransaction(criteria.Session);
			return DataPortal.Fetch<Submodulo>(criteria);
		}

		/// <summary>
		/// Borrado inmediato, no cabe "undo"
		/// (La función debe ser "estática")
		/// </summary>
		/// <param name="oid"></param>
		public static void Delete(long oid)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			DataPortal.Delete(new CriteriaCs(oid));
		}

		/// <summary>
		/// Elimina todas los Submodulos
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = Submodulo.OpenSession();
			ISession sess = Submodulo.Session(sessCode);
			ITransaction trans = Submodulo.BeginTransaction(sessCode);

			try
			{
				sess.Delete("from Submodulo");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				Submodulo.CloseSession(sessCode);
			}
		}

		public override Submodulo Save()
		{
			// Por interfaz Root/Child
			if (IsChild)
			{
				throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
			}

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

                _temas.Update(this);

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

		#region Child Factory Methods

		protected Submodulo(Submodulo source)
		{
			MarkAsChild();
			Fetch(source);
		}

		private Submodulo(int session_code, IDataReader reader, bool childs, bool g_childs)
		{
			MarkAsChild();
			Childs = childs;
            GChilds = g_childs;
			Fetch(session_code, reader);
		}

		public static Submodulo NewChild(Modulo parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			Submodulo obj = new Submodulo();
			obj.OidModulo = parent.Oid;
			return obj;
		}

		internal static Submodulo GetChild(Submodulo source)
		{
			return new Submodulo(source);
		}

		internal static Submodulo GetChild(int session_code, IDataReader reader, bool childs, bool g_childs)
		{
			return new Submodulo(session_code, reader, childs, g_childs);
		}

		internal static Submodulo GetChild(int session_code, IDataReader reader)
		{
			return GetChild(session_code, reader, true, true);
		}


		/// <summary>
		/// Borrado aplazado, es posible el undo 
		/// La función debe ser "no estática")
		/// </summary>
		public override void Delete()
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			MarkDeleted();
		}

		#endregion

		#region Common Data Access

		[RunLocal()]
		private void DataPortal_Create(CriteriaCs criteria)
		{
			Random r = new Random();
            Oid = (long)r.Next();
		}

		#endregion

		#region Child Data Access

		private void Fetch(Submodulo source)
		{
			try
			{
				SessionCode = source.SessionCode;

                _base.CopyValues(source);

				CriteriaEx criteria;

				criteria = Tema.GetCriteria(Session());
				criteria.AddEq("OidSubmodulo", this.Oid);
				_temas = Temas.GetChildList(criteria.List<Tema>());

			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkOld();
		}

		private void Fetch(int session_code, IDataReader source)
		{
			try
			{
                _base.CopyValues(source);

				if (Childs)
				{
					string query;

					Tema.DoLOCK(Session(session_code));
					query = Temas.SELECT_BY_SUBMODULO(this.Oid);
					IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(session_code));
					_temas = Temas.GetChildList(reader, GChilds);
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkOld();
		}


		internal void Insert(Modulo parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			//Debe obtener la sesion del padre pq el objeto es padre a su vez
			SessionCode = parent.SessionCode;

			OidModulo = parent.Oid;

			try
			{
				ValidationRules.CheckRules();

				if (!IsValid)
					throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				parent.Session().Save(this.Base.Record);

				_temas.Update(this);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkOld();
		}

		internal void Update(Modulo parent)
		{
			UpdateCodigoOrden();

			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			//Debe obtener la sesion del padre pq el objeto es padre a su vez
			SessionCode = parent.SessionCode;

			OidModulo = parent.Oid;

			try
			{
				ValidationRules.CheckRules();

				if (!IsValid)
					throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				SubmoduloRecord obj = parent.Session().Get<SubmoduloRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				parent.Session().Update(obj);

				_temas.Update(this);
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
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<SubmoduloRecord>(Oid));
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkNew();
		}


		#endregion

		#region Root Data Access

		// called to retrieve data from the database
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			try
			{
				SessionCode = criteria.SessionCode;

				Childs = criteria.Childs;

				if (nHMng.UseDirectSQL)
				{
					Submodulo.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());
					
					if (reader.Read())
						_base.CopyValues(reader);

					if (Childs)
					{
						string query;

						Tema.DoLOCK(Session());

                        query = Temas.SELECT_BY_OID(this.Oid);
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
						_temas = Temas.GetChildList(reader);
					}
				}
				else
				{
					_base.Record.CopyValues((SubmoduloRecord)(criteria.UniqueResult()));

					//Session().Lock(Session().Get<SubmoduloRecord>(Oid), LockMode.UpgradeNoWait);

					if (Childs)
					{
						criteria = Tema.GetCriteria(Session());
						criteria.AddEq("OidSubmodulo", this.Oid);
						_temas = Temas.GetChildList(criteria.List<Tema>());
					}
				}
			}
			catch (NHibernate.ADOException)
			{
				if (Transaction() != null) Transaction().Rollback();
				throw new iQLockException(moleQule.Library.Resources.Messages.LOCK_ERROR);
			}
			catch (Exception ex)
			{
				if (Transaction() != null) Transaction().Rollback();
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
					SubmoduloRecord obj = Session().Get<SubmoduloRecord>(Oid);
					obj.CopyValues(this.Base.Record);
					Session().Update(obj);
				}
				catch (Exception ex)
				{
					iQExceptionHandler.TreatException(ex);
				}
			}
		}

		// deferred deletion
		[Transactional(TransactionalTypes.Manual)]
		protected override void DataPortal_DeleteSelf()
		{
            DataPortal_Delete(new CriteriaCs(Oid));
		}

		// inmediate deletion
		[Transactional(TransactionalTypes.Manual)]
		private void DataPortal_Delete(CriteriaCs criterio)
		{
			try
			{
				//Iniciamos la conexion y la transaccion
				SessionCode = OpenSession();
				BeginTransaction();

				CriteriaEx criteria = GetCriteria();
				criteria.AddOidSearch(criterio.Oid);

				// Obtenemos el objeto
				SubmoduloRecord obj = (SubmoduloRecord)(criteria.UniqueResult());
				Session().Delete(Session().Get<SubmoduloRecord>(obj.Oid));

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

		
		/// <summary>
		/// Obtiene la lista de clases de prácticas asociadas a una promoción que aún no han sido programadas
		///	más las asignadas al horario actual
		/// </summary>
		/// <param name="oid_plan"></param>
		/// <param name="oid_promocion"></param>
		/// <param name="fecha"></param>
		/// <returns></returns>
		public static ListaClases GetClasesPracticas(	long oid_plan, 
														long oid_promocion, 
														long oid_horario, 
														DateTime fecha)
		{
			ListaClases lista = new ListaClases();
            //string query = SELECT_CLASES_PRACTICA(oid_plan);
            //int sesion = Submodulo.OpenSession();

            //IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

            //while (reader.Read())
            //{
            //    query = INNER_JOIN_CLASE_SESION(oid_promocion, (long)reader["OID"], 1);
            //    IDataReader sesiones = nHManager.Instance.SQLNativeSelect(query, Session(sesion));
            //    int count = 0;
            //    while (sesiones.Read())
            //    {
            //        DateTime _fecha = DateTime.Parse(sesiones["FECHA"].ToString());
            //        if (_fecha.Date < fecha.Date)
            //        {
            //            if ((long)sesiones["ESTADO"] == 3)
            //            {
            //                if ((long)sesiones["GRUPO"] == 1)
            //                {
            //                    if (count == 2 || count == 0)
            //                        count++;
            //                }
            //                else
            //                {
            //                    if (count == 1 || count == 0)
            //                        count += 2;
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if ((long)sesiones["GRUPO"] == 1)
            //            {
            //                if (count == 2 || count == 0)
            //                    count++;
            //            }
            //            else
            //            {
            //                if (count == 1 || count == 0)
            //                    count += 2;
            //            }
            //        }
            //    }
            //    if (count < 3)
            //    {
            //        if (count == 2 || count == 0)
            //        {
            //            Clase clase = new Clase();

            //            clase.Oid = (long)reader["OID"];
            //            clase.OidSubmodulo = (long)reader["OID_SUBMODULO"];
            //            clase.OidModulo = (long)reader["OID_MODULO"];
            //            clase.Tipo = 1;
            //            clase.Titulo = (string)reader["ALIAS"];
            //            clase.OrdenPrimario = (long)reader["ORDEN_PRIMARIO"];
            //            clase.OrdenSecundario = (long)reader["ORDEN_SECUNDARIO"];
            //            clase.OrdenTerciario = (long)reader["ORDEN_TERCIARIO"];
            //            clase.Incompatible = (long)reader["INCOMPATIBLE"];
            //            clase.Grupo = 1;

            //            lista.Add(clase);
            //        }
            //        if (count == 1 || count == 0)
            //        {
            //            Clase clase = new Clase();

            //            clase.Oid = (long)reader["OID"];
            //            clase.OidSubmodulo = (long)reader["OID_SUBMODULO"];
            //            clase.OidModulo = (long)reader["OID_MODULO"];
            //            clase.Tipo = 1;
            //            clase.Titulo = (string)reader["ALIAS"];
            //            clase.OrdenPrimario = (long)reader["ORDEN_PRIMARIO"];
            //            clase.OrdenSecundario = (long)reader["ORDEN_SECUNDARIO"];
            //            clase.OrdenTerciario = (long)reader["ORDEN_TERCIARIO"];
            //            clase.Incompatible = (long)reader["INCOMPATIBLE"];
            //            clase.Grupo = 2;

            //            lista.Add(clase);
            //        }
            //    }
            //    else
            //    {
            //        Clase clase = new Clase();

            //        clase.Oid = (long)reader["OID"];
            //        clase.OidSubmodulo = (long)reader["OID_SUBMODULO"];
            //        clase.OidModulo = (long)reader["OID_MODULO"];
            //        clase.Tipo = 1;
            //        clase.Titulo = (string)reader["ALIAS"];
            //        clase.OrdenPrimario = (long)reader["ORDEN_PRIMARIO"];
            //        clase.OrdenSecundario = (long)reader["ORDEN_SECUNDARIO"];
            //        clase.OrdenTerciario = (long)reader["ORDEN_TERCIARIO"];
            //        clase.Incompatible = (long)reader["INCOMPATIBLE"];
            //        clase.Grupo = 1;
            //        clase.Estado = 2;

            //        lista.Add(clase);

            //        Clase clase2 = new Clase();

            //        clase2.Oid = (long)reader["OID"];
            //        clase2.OidSubmodulo = (long)reader["OID_SUBMODULO"];
            //        clase2.OidModulo = (long)reader["OID_MODULO"];
            //        clase2.Tipo = 1;
            //        clase2.Titulo = (string)reader["ALIAS"];
            //        clase2.OrdenPrimario = (long)reader["ORDEN_PRIMARIO"];
            //        clase2.OrdenSecundario = (long)reader["ORDEN_SECUNDARIO"];
            //        clase2.OrdenTerciario = (long)reader["ORDEN_TERCIARIO"];
            //        clase2.Incompatible = (long)reader["INCOMPATIBLE"];
            //        clase2.Grupo = 2;
            //        clase2.Estado = 2;

            //        lista.Add(clase2);
            //    }
            //}

            //CloseSession(sesion);

			return lista;
		}


		public static ListaClases GetClasesExtra()
		{
			ListaClases lista = new ListaClases();
			string query = SELECT_CLASE_EXTRA();
			int sesion = Submodulo.OpenSession();

			IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

			while (reader.Read())
			{
				Clase clase = new Clase();

				clase.Oid = (long)reader["OID"];
				clase.OidSubmodulo = (long)reader["OID_SUBMODULO"];
				clase.OidModulo = (long)reader["OID_MODULO"];
				clase.Tipo = 2;
				clase.Titulo = "Extra " + (string)reader["ALIAS"];

				lista.Add(clase);
			}

			CloseSession(sesion);

			return lista;
		}

		public static HComboBoxSourceList GetComboClases(ClaseTeoricaList teoricas, 
                                                        ClasePracticaList practicas, 
                                                        ClaseExtraList extras)
		{
			HComboBoxSourceList lista_combo = new HComboBoxSourceList();

			//lista_combo.Add(new ComboBoxSource());
			lista_combo.Add(new ComboBoxSource(-1, "LIBRE"));
			lista_combo.Add(new ComboBoxSource(-2, "NO ASIGNADA"));

            if (teoricas != null && practicas != null && extras != null)
            {
                foreach (ClaseTeoricaInfo item in teoricas)
                {
                    ComboBoxSource combo = new ComboBoxSource();
                    combo.Oid = item.Oid;
                    combo.OidAjeno = item.OidSubmodulo;
                    combo.Tipo = item.Tipo;
                    combo.Texto = "T " + item.Alias;

                    lista_combo.Add(combo);
                }


                foreach (ClaseExtraInfo item in extras)
                {
                    ComboBoxSource combo = new ComboBoxSource();
                    combo.Oid = item.Oid;
                    combo.OidAjeno = item.OidSubmodulo;
                    combo.Tipo = 2;
                    combo.Texto = "E " + item.Alias;

                    lista_combo.Add(combo);
                }

                foreach (ClasePracticaInfo item in practicas)
                {
                    ComboBoxSource combo = new ComboBoxSource();
                    combo.Oid = item.Oid;
                    combo.OidAjeno = item.OidSubmodulo;
                    combo.Tipo = item.Tipo;
                    combo.Texto = "P " + item.Alias + " G" + item.Grupo;

                    lista_combo.Add(combo);
                }
            }


			return lista_combo;
		}



		#endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT SM.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string sm = nHManager.Instance.GetSQLTable(typeof(SubmoduloRecord));

            query = "   FROM   " + sm + "   AS SM";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Modulo != null && conditions.Modulo.Oid > 0)
                query += " AND SM.\"OID_MODULO\" = " + conditions.Modulo.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY SM.\"CODIGO_ORDEN\"";

            if (lockTable) query += " FOR UPDATE OF SM NOWAIT";

            return query;
        }

		/// <summary>
		/// Construye la tabla 
		/// </summary>
		/// <param name="type"></param>
		/// <param name="schema"></param>
		/// <param name="sesion"></param>
		/// <returns></returns>
		private static string SELECT_CLASES_TEORIA(long oid_plan)
		{
			string clase_teorica = nHManager.Instance.Cfg.GetClassMapping(typeof(ClaseTeoricaRecord)).Table.Name;

			string query;

			string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

			query = "SELECT * " +
					"FROM \"" + esquema + "\".\"" + clase_teorica + "\" " +
					"WHERE \"OID_PLAN\" = " + oid_plan.ToString() + " " +
					"ORDER BY \"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\"";

			return query;
		}

		/// <summary>
		/// Construye la tabla 
		/// </summary>
		/// <param name="type"></param>
		/// <param name="schema"></param>
		/// <param name="sesion"></param>
		/// <returns></returns>
		private static string SELECT_CLASES_PRACTICA(long oid_plan)
		{
			string clase_practica = nHManager.Instance.Cfg.GetClassMapping(typeof(ClasePracticaRecord)).Table.Name;

			string query;

			string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

			query = "SELECT *  " +
					"FROM \"" + esquema + "\".\"" + clase_practica + "\" " +
					"WHERE \"OID_PLAN\" = " + oid_plan.ToString() + " " +
					"ORDER BY \"ORDEN_PRIMARIO\", \"ORDEN_SECUNDARIO\", \"ORDEN_TERCIARIO\"";

			return query;
		}


		/// <summary>
		/// Construye la tabla 
		/// </summary>
		/// <param name="type"></param>
		/// <param name="schema"></param>
		/// <param name="sesion"></param>
		/// <returns></returns>
		private static string UNION_CLASES(long oid_plan)
		{
			string clase_practica = nHManager.Instance.Cfg.GetClassMapping(typeof(ClasePracticaRecord)).Table.Name;
			string clase_teorica = nHManager.Instance.Cfg.GetClassMapping(typeof(ClaseTeoricaRecord)).Table.Name;
			string clase_extra = nHManager.Instance.Cfg.GetClassMapping(typeof(ClaseExtraRecord)).Table.Name;

			string query;

			string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

			query = "SELECT \"OID\", \"OID_SUBMODULO\" , \"ALIAS\", 0 AS TIPO " +
					"FROM \"" + esquema + "\".\"" + clase_teorica + "\" " +
					"WHERE \"OID_PLAN\" = " + oid_plan.ToString() + " " +
					"UNION " +
					"SELECT \"OID\", \"OID_SUBMODULO\" , \"ALIAS\", 1 AS TIPO " +
					"FROM \"" + esquema + "\".\"" + clase_practica + "\" " +
					"WHERE \"OID_PLAN\" = " + oid_plan.ToString() + " " +
					"UNION " +
					"SELECT \"OID\", \"OID_SUBMODULO\" , \"ALIAS\", 2 AS TIPO " +
					"FROM \"" + esquema + "\".\"" + clase_extra + "\" ";

			return query;
		}

		/// <summary>
		/// Construye la tabla 
		/// Dado un Oid de Clase (Teórica o Práctica), comprueba que dicha clase no contenga ya una sesión
		/// asociada en otro horario de la misma promoción
		/// </summary>
		/// <param name="type"></param>
		/// <param name="schema"></param>
		/// <param name="sesion"></param>
		/// <returns></returns>
		private static string INNER_JOIN_CLASE_SESION(long oid_promocion, long oid_clase, long tipo)
		{
			string sesion = nHManager.Instance.Cfg.GetClassMapping(typeof(SesionRecord)).Table.Name;
			string horario = nHManager.Instance.Cfg.GetClassMapping(typeof(HorarioRecord)).Table.Name;
			string teoria = "OID_CLASE_TEORICA";
			string practica = "OID_CLASE_PRACTICA";

			string query;

			string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

			query = "SELECT s.*, h.\"OID_PROMOCION\"  " +
					"FROM \"" + esquema + "\".\"" + sesion + "\" AS s " +
						"INNER JOIN \"" + esquema + "\".\"" + horario + "\" AS h " +
						"ON (s.\"OID_HORARIO\" = h.\"OID\") " +
				   "WHERE h.\"OID_PROMOCION\" = " + oid_promocion.ToString() + " ";
			
            if (tipo == 0)
				query += "AND s.\"" + teoria + "\" = " + oid_clase.ToString();
			else
				query += "AND s.\"" + practica + "\" = " + oid_clase.ToString();

			return query;
		}


		/// <summary>
		/// Construye la tabla 
		/// </summary>
		/// <param name="type"></param>
		/// <param name="schema"></param>
		/// <param name="sesion"></param>
		/// <returns></returns>
		private static string SELECT_CLASE_EXTRA()
		{
			string clase_extra = nHManager.Instance.Cfg.GetClassMapping(typeof(ClaseExtraRecord)).Table.Name;

			string query;

			string esquema = Convert.ToInt32(AppContext.ActiveSchema.Code).ToString("0000");

			query = "SELECT * " +
					"FROM \"" + esquema + "\".\"" + clase_extra + "\" ";

			return query;
		}
		
		#endregion

	}
}

