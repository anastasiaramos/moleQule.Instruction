using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Drawing;
using System.IO;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class TemaRecord : RecordBase
	{
		#region Attributes

		private long _oid_submodulo;
		private string _codigo = string.Empty;
		private string _nombre = string.Empty;
		private string _codigo_orden = string.Empty;
		private long _oid_modulo;
		private long _nivel;
		private bool _desarrollo = false;
  
		#endregion
		
		#region Properties
		
				public virtual long OidSubmodulo { get { return _oid_submodulo; } set { _oid_submodulo = value; } }
		public virtual string Codigo { get { return _codigo; } set { _codigo = value; } }
		public virtual string Nombre { get { return _nombre; } set { _nombre = value; } }
		public virtual string CodigoOrden { get { return _codigo_orden; } set { _codigo_orden = value; } }
		public virtual long OidModulo { get { return _oid_modulo; } set { _oid_modulo = value; } }
		public virtual long Nivel { get { return _nivel; } set { _nivel = value; } }
		public virtual bool Desarrollo { get { return _desarrollo; } set { _desarrollo = value; } }

		#endregion
		
		#region Business Methods
		
		public TemaRecord(){}
		
		public virtual void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			Oid = Format.DataReader.GetInt64(source, "OID");
			_oid_submodulo = Format.DataReader.GetInt64(source, "OID_SUBMODULO");
			_codigo = Format.DataReader.GetString(source, "CODIGO");
			_nombre = Format.DataReader.GetString(source, "NOMBRE");
			_codigo_orden = Format.DataReader.GetString(source, "CODIGO_ORDEN");
			_oid_modulo = Format.DataReader.GetInt64(source, "OID_MODULO");
			_nivel = Format.DataReader.GetInt64(source, "NIVEL");
			_desarrollo = Format.DataReader.GetBool(source, "DESARROLLO");

		}		
		public virtual void CopyValues(TemaRecord source)
		{
			if (source == null) return;

			Oid = source.Oid;
			_oid_submodulo = source.OidSubmodulo;
			_codigo = source.Codigo;
			_nombre = source.Nombre;
			_codigo_orden = source.CodigoOrden;
			_oid_modulo = source.OidModulo;
			_nivel = source.Nivel;
			_desarrollo = source.Desarrollo;
		}
		
		#endregion	
	}

    [Serializable()]
	public class TemaBase 
	{	 
		#region Attributes
		
		private TemaRecord _record = new TemaRecord();
		
		#endregion
		
		#region Properties
		
		public TemaRecord Record { get { return _record; } }
		
		#endregion
		
		#region Business Methods
		
		internal void CopyValues(IDataReader source)
		{
			if (source == null) return;
			
			_record.CopyValues(source);
		}		
		public void CopyValues(Tema source)
		{
			if (source == null) return;
			
			_record.CopyValues(source.Base.Record);
		}
		public void CopyValues(TemaInfo source)
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
	public class Tema : BusinessBaseEx<Tema>
	{	 
		#region Attributes
		
		protected TemaBase _base = new TemaBase();
		

		#endregion
		
		#region Properties
		
		public TemaBase Base { get { return _base; } }
		
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
		public virtual string Nombre
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Nombre;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (value == null) value = string.Empty;
				
				if (!_base.Record.Nombre.Equals(value))
				{
					_base.Record.Nombre = value;
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
		public virtual long Nivel
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Nivel;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Nivel.Equals(value))
				{
					_base.Record.Nivel = value;
					PropertyHasChanged();
				}
			}
		}
		public virtual bool Desarrollo
		{
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			get
			{
				//CanReadProperty(true);
				return _base.Record.Desarrollo;
			}
            
			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			set
			{
				//CanWriteProperty(true);
				
				if (!_base.Record.Desarrollo.Equals(value))
				{
					_base.Record.Desarrollo = value;
					PropertyHasChanged();
				}
			}
		}
	
		
		
		#endregion
		
		#region Business Methods
		
		public virtual Tema CloneAsNew()
        {
            Tema clon = base.Clone();

            // Se define el Oid como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();

            clon.SessionCode = Tema.OpenSession();
            Tema.BeginTransaction(clon.SessionCode);
            clon.MarkNew();

            return clon;
		}
		
		protected virtual void CopyFrom(TemaInfo source)
		{
			if (source == null) return;

			Oid = source.Oid;
			OidSubmodulo = source.OidSubmodulo;
			Codigo = source.Codigo;
			Nombre = source.Nombre;
			CodigoOrden = source.CodigoOrden;
			OidModulo = source.OidModulo;
			Nivel = source.Nivel;
			Desarrollo = source.Desarrollo;
		}

        public virtual void UpdateCodigoOrden()
        {

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

            // Actualizamos el campo de ordenación
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
		
			
		#endregion

		#region Validation Rules

		protected override void AddBusinessRules()
		{
			ValidationRules.AddRule(CommonRules.StringRequired, "Codigo");

            ValidationRules.AddRule(CommonRules.StringRequired, "Nombre");

			ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidSubmodulo", 1));

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
		public Tema()
		{
			MarkAsChild();
			Random r = new Random();
            Oid = (long)r.Next();
		}

        public Tema(string codigo, string nombre)
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
            Codigo = codigo + ".0";
            Nombre = nombre;
        }

		public virtual TemaInfo GetInfo(bool get_childs)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

				return new TemaInfo(this, null, null);
		}

		public virtual TemaInfo GetInfo()
		{
			return GetInfo(true);
		}

		#endregion

		#region Root Factory Methods

		public static Tema New()
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			return DataPortal.Create<Tema>(new CriteriaCs(-1));
		}

		public static Tema Get(long oid)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			CriteriaEx criteria = Tema.GetCriteria(Tema.OpenSession());

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = Tema.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

			Tema.BeginTransaction(criteria.Session);
			return DataPortal.Fetch<Tema>(criteria);
		}

		public static Tema Get(CriteriaEx criteria)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException(
				  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			Tema.BeginTransaction(criteria.Session);
			return DataPortal.Fetch<Tema>(criteria);
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
		/// Elimina todas los Temas
		/// </summary>
		public static void DeleteAll()
		{
			//Iniciamos la conexion y la transaccion
			int sessCode = Tema.OpenSession();
			ISession sess = Tema.Session(sessCode);
			ITransaction trans = Tema.BeginTransaction(sessCode);

			try
			{
				sess.Delete("from Tema");
				trans.Commit();
			}
			catch (Exception ex)
			{
				if (trans != null) trans.Rollback();
				iQExceptionHandler.TreatException(ex);
			}
			finally
			{
				Tema.CloseSession(sessCode);
			}
		}

		public override Tema Save()
		{
			// Por interfaz Root/Child
			if (IsChild)
			{
				//throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
				//_preguntas.Update(this);
				Transaction().Commit();
                BeginTransaction();
				return this;
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

                //_preguntas.Update(this);
                //_p_examenes.Update(this);

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

		protected Tema(Tema source)
		{
			MarkAsChild();
			Fetch(source);
		}

		private Tema(IDataReader reader, bool childs)
		{
			MarkAsChild();
			Childs = childs;
			Fetch(reader);
		}

		public static Tema NewChild(Submodulo parent)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException(
					moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

			Tema obj = new Tema();
			obj.OidSubmodulo = parent.Oid;
            obj.OidModulo = parent.OidModulo;
			return obj;
		}

		internal static Tema GetChild(Tema source)
		{
			return new Tema(source);
		}

		internal static Tema GetChild(IDataReader reader, bool childs)
		{
			return new Tema(reader, childs);
		}


		internal static Tema GetChild(IDataReader reader)
		{
			return GetChild(reader, true);
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

		private void Fetch(Tema source)
		{
			try
			{
				SessionCode = source.SessionCode;

                _base.CopyValues(source);

                //CriteriaEx criteria;

                //criteria = Pregunta.GetCriteria(Session());
                //criteria.AddEq("OidTema", this.Oid);
                //_preguntas = Preguntas.GetChildList(criteria.List<Pregunta>());

                //criteria = PreguntaExamen.GetCriteria(Session());
                //criteria.AddEq("OidTema", this.Oid);
                //_p_examenes = PreguntaExamens.GetChildList(criteria.List<PreguntaExamen>());
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkOld();
		}

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

			MarkOld();
		}

		internal void Insert(Submodulo parent)
		{
            UpdateCodigoOrden();
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			//Debe obtener la sesion del padre pq el objeto es padre a su vez
			SessionCode = parent.SessionCode;

			OidSubmodulo = parent.Oid;
            OidModulo = parent.OidModulo;

			try
			{
				ValidationRules.CheckRules();

				if (!IsValid)
					throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				parent.Session().Save(this.Base.Record);

                //_preguntas.Update(this);
                //_p_examenes.Update(this);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkOld();
		}

		internal void Update(Submodulo parent)
		{
            UpdateCodigoOrden();
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			//Debe obtener la sesion del padre pq el objeto es padre a su vez
			SessionCode = parent.SessionCode;

			OidSubmodulo = parent.Oid;
            OidModulo = parent.OidModulo;

			try
			{
				ValidationRules.CheckRules();

				if (!IsValid)
					throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

				TemaRecord obj = parent.Session().Get<TemaRecord>(Oid);
				obj.CopyValues(this.Base.Record);
				parent.Session().Update(obj);

                //_preguntas.Update(this);
                //_p_examenes.Update(this);
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}

			MarkOld();
		}

		internal void DeleteSelf(Submodulo parent)
		{
			// if we're not dirty then don't update the database
			if (!this.IsDirty) return;

			// if we're new then don't update the database
			if (this.IsNew) return;

			try
			{
				SessionCode = parent.SessionCode;
				Session().Delete(Session().Get<TemaRecord>(Oid));
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
					Tema.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

					if (reader.Read())
                        _base.CopyValues(reader);

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
					TemaRecord obj = Session().Get<TemaRecord>(Oid);
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
				TemaRecord obj = (TemaRecord)(criteria.UniqueResult());
				Session().Delete(Session().Get<TemaRecord>(obj.Oid));

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
        
        #region Scripts
        
        public static void CompletaDuplicado(long oid_tema_original, long oid_tema_copia)
        {
            int sesion = nHManager.Instance.OpenSession();
            Tema.DoLOCK(nHManager.Instance.GetSession(sesion));
            string query = INSERT_PREGUNTAS_DUPLICADAS(oid_tema_original, oid_tema_copia);
            nHManager.Instance.SQLNativeExecute(query, nHManager.Instance.GetSession(sesion));

            Tema.DoLOCK(nHManager.Instance.GetSession(sesion));
            query = UPDATE_OBSERVACIONES_DUPLICADAS(oid_tema_original, oid_tema_copia);
            nHManager.Instance.SQLNativeExecute(query, nHManager.Instance.GetSession(sesion));

            CloseSession(sesion);

            Preguntas lista_duplicadas = Preguntas.GetPreguntasDuplicadasTema(oid_tema_copia);
            Preguntas lista_originales = Preguntas.GetPreguntasTema(oid_tema_original, true);

            long serial = Pregunta.GetNewSerial();
            long serial_r = Respuesta.GetNewSerial(null);

            foreach (Pregunta item in lista_duplicadas)
            {
                Pregunta original = lista_originales.GetItem(item.OidOld);

                item.Serial = serial++;
                item.Codigo = item.Serial.ToString(Resources.Defaults.PREGUNTA_CODE_FORMAT);

                foreach (Respuesta r in original.Respuestas)
                {
                    Respuesta new_r = Respuesta.NewChild(item);
                    new_r = r.Clone();
                    new_r.Serial = serial_r++;
                    new_r.Codigo = serial_r.ToString(Resources.Defaults.RESPUESTA_CODE_FORMAT);
                    item.Respuestas.Add(new_r);
                }

                if (original.Imagen != string.Empty)
                {

                    string ext = string.Empty;
                    if (!File.Exists(moleQule.Library.Instruction.ModuleController.FOTOS_PREGUNTAS_PATH + original.Imagen))
                        continue;

                    Bitmap imagen = new Bitmap(Library.Instruction.ModuleController.FOTOS_PREGUNTAS_PATH + original.Imagen);

                    if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Jpeg.Guid))
                        ext = ".jpg";
                    else
                    {
                        if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Bmp.Guid))
                            ext = ".bmp";
                        else
                        {
                            if (imagen.RawFormat.Guid.Equals(System.Drawing.Imaging.ImageFormat.Png.Guid))
                                ext = ".png";
                        }
                    }

                    item.Imagen = item.Oid.ToString("000000") + ext;

                    int maxHeight = imagen.Height > imagen.Width ? imagen.Height : imagen.Width;

                    Images.Save(original.ImagenWithPath, item.ImagenWithPath, maxHeight);

                    imagen.Dispose();
                }
                else
                    item.Imagen = string.Empty;
            }

            lista_duplicadas.Save();
            lista_duplicadas.CloseSession();
        }

        public static string INSERT_PREGUNTAS_DUPLICADAS(long oid_tema_fuente, long oid_tema_copia)
        {
            string p = nHManager.Instance.GetSQLTable(typeof(PreguntaRecord));
            string t = nHManager.Instance.GetSQLTable(typeof(TemaRecord));

            string query = "INSERT INTO " + p + " (\"TEXTO\", \"OBSERVACIONES\", \"ACTIVA\", \"REVISADA\", \"IMAGEN_GRANDE\", \"OID_OLD\", " +
                            "\"OID_MODULO\", \"OID_TEMA\", \"NIVEL\", \"TIPO\", \"IDIOMA\", \"OID_SUBMODULO\", \"FECHA_ALTA\", \"FECHA_DISPONIBILIDAD\") " +
                            "SELECT P.\"TEXTO\", P.\"OBSERVACIONES\", P.\"ACTIVA\", P.\"REVISADA\", P.\"IMAGEN_GRANDE\", P.\"OID\", " +
                                "T.\"OID_MODULO\", T.\"OID\", T.\"NIVEL\", P.\"TIPO\", P.\"IDIOMA\", T.\"OID_SUBMODULO\", now(), now() " +
                            "FROM " + p + " AS P, " + t + " AS T, " + p + " AS PR " +
                            "WHERE P.\"OID_TEMA\" = " + oid_tema_fuente.ToString() + " AND position('OK' in upper(P.\"OBSERVACIONES\")) > 0 AND T.\"OID\" = " + oid_tema_copia + " " +
                                "AND position('OK-D' in P.\"OBSERVACIONES\") = 0 " +
                            "GROUP BY P.\"TEXTO\", P.\"OBSERVACIONES\", P.\"ACTIVA\", P.\"REVISADA\", P.\"IMAGEN_GRANDE\", P.\"OID\", " +
                            "T.\"OID_MODULO\", T.\"OID\", T.\"NIVEL\", P.\"TIPO\", P.\"IDIOMA\", T.\"OID_SUBMODULO\";";
            return query;
        }

        public static string UPDATE_OBSERVACIONES_DUPLICADAS(long oid_tema_fuente, long oid_tema_copia)
        {
            string p = nHManager.Instance.GetSQLTable(typeof(PreguntaRecord));
            string t = nHManager.Instance.GetSQLTable(typeof(TemaRecord));

            string query = "UPDATE " + p + " " +
                            "SET \"OBSERVACIONES\" = overlay(\"OBSERVACIONES\" placing 'OK-D' from position('OK' in upper(\"OBSERVACIONES\")) for 4) " +
                            "WHERE position('OK' in upper(\"OBSERVACIONES\")) > 0 AND (\"OID_TEMA\" = " + oid_tema_fuente.ToString() +
                            " OR \"OID_TEMA\" = " + oid_tema_copia.ToString() + ") AND position('OK-D' in \"OBSERVACIONES\") = 0;";
            return query;
        }

        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = "SELECT T.*";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string t = nHManager.Instance.GetSQLTable(typeof(TemaRecord));

            query = "   FROM   " + t + "   AS T";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Submodulo != null && conditions.Submodulo.Oid > 0)
                query += " AND T.\"OID_SUBMODULO\" = " + conditions.Submodulo.Oid;

            if (conditions.Modulo != null && conditions.Modulo.Oid > 0)
                query += " AND T.\"OID_MODULO\" = " + conditions.Modulo.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions) +
                    " ORDER BY T.\"CODIGO_ORDEN\"";

            if (lockTable) query += " FOR UPDATE OF T NOWAIT";

            return query;
        }

        #endregion

	}
}

