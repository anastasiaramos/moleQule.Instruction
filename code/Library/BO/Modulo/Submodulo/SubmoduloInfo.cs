using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// ReadOnly Child Business Object with ReadOnly Childs
	/// </summary>
	[Serializable()]
	public class SubmoduloInfo : ReadOnlyBaseEx<SubmoduloInfo>
	{

        #region Business Methods

        protected SubmoduloBase _base = new SubmoduloBase();

        private TemaList _temas = null;

        #endregion

        #region Properties

        public SubmoduloBase Base { get { return _base; } }

        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long OidModulo { get { return _base.Record.OidModulo; } }
        public string Texto { get { return _base.Record.Texto; } }
        public string CodigoOrden { get { return _base.Record.CodigoOrden; } }


        public virtual TemaList Temas { get { return _temas; } }


        #endregion

        #region Business Methods

        public void CopyFrom(Submodulo source) { _base.CopyValues(source); }

		#endregion

		#region Factory Methods

		protected SubmoduloInfo() { /* require use of factory methods */ }

		private SubmoduloInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}

		internal SubmoduloInfo(Submodulo item, bool copy_childs)
		{
            _base.CopyValues(item);

            if (copy_childs)
            {
                _temas = (item.Temas != null) ? TemaList.GetChildList(item.Temas) : null;
            }
		}

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static SubmoduloInfo Get(long oid) { return Get(oid, false); }

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static SubmoduloInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = Submodulo.GetCriteria(Submodulo.OpenSession());
            criteria.Childs = childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = SubmoduloInfo.SELECT(typeof(SubmoduloRecord), oid);
            else
                criteria.AddOidSearch(oid);  
			
			SubmoduloInfo obj = DataPortal.Fetch<SubmoduloInfo>(criteria);
			Submodulo.CloseSession(criteria.SessionCode);
			return obj;
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static SubmoduloInfo Get(IDataReader reader, bool childs)
		{
			return new SubmoduloInfo(reader, childs);
		}

        public static SubmoduloInfo New(long oid = 0) { return new SubmoduloInfo() { Oid = oid }; }

		#endregion

		#region Data Access

		// called to retrieve data from db
		private void DataPortal_Fetch(CriteriaEx criteria)
		{
			SessionCode = criteria.SessionCode;
			Childs = criteria.Childs;

			try
			{
				SessionCode = criteria.SessionCode;
				Childs = criteria.Childs;

				if (nHMng.UseDirectSQL)
				{
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

					if (reader.Read())
                        _base.CopyValues(reader);

					if (Childs)
					{
						string query = string.Empty;

						query = Instruction.Temas.SELECT_BY_SUBMODULO(this.Oid);
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
						_temas = TemaList.GetChildList(reader);
					}
				}
				else
				{
                    _base.Record.CopyValues((SubmoduloRecord)(criteria.UniqueResult()));

					if (Childs)
					{
						criteria = Tema.GetCriteria(criteria.Session);
						criteria.AddEq("OidSubmodulo", this.Oid);
						_temas = TemaList.GetChildList(criteria.List<Tema>());
					}
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}

		//called to copy data from IDataReader
		private void Fetch(IDataReader source)
		{
			try
			{
                _base.CopyValues(source);

				if (Childs)
                {
                    string query = string.Empty;
                    IDataReader reader;

                    query = TemaList.SELECT_BY_SUBMODULO(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _temas = TemaList.GetChildList(reader);
				}
			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}

		#endregion

	}
}

