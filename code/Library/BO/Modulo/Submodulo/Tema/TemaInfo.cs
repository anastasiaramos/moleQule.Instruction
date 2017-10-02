using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// ReadOnly Child Business Object with ReadOnly Childs
	/// </summary>
	[Serializable()]
	public class TemaInfo : ReadOnlyBaseEx<TemaInfo>
    {
        #region Attributes

        protected TemaBase _base = new TemaBase();


        #endregion

        #region Properties

        public TemaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidSubmodulo { get { return _base.Record.OidSubmodulo; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public string CodigoOrden { get { return _base.Record.CodigoOrden; } }
        public long OidModulo { get { return _base.Record.OidModulo; } }
        public long Nivel { get { return _base.Record.Nivel; } }
        public bool Desarrollo { get { return _base.Record.Desarrollo; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Tema source) { _base.CopyValues(source); }

        #endregion		

		#region Factory Methods

		protected TemaInfo() { /* require use of factory methods */ }

		private TemaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}

		internal TemaInfo(	Tema item, PreguntaList preguntas,
								PreguntaExamenList p_examenes)
		{
            _base.CopyValues(item);

            //_preguntas = preguntas != null ? preguntas.Clone() : null;
            //_p_examenes = p_examenes != null ? p_examenes.Clone() : null;

		}


		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static TemaInfo Get(long oid)
		{
			return Get(oid, false);
		}

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static TemaInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = Tema.GetCriteria(Tema.OpenSession());
            criteria.Childs = childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = TemaInfo.SELECT(typeof(TemaRecord), oid);
            else
                criteria.AddOidSearch(oid);
			
			TemaInfo obj = DataPortal.Fetch<TemaInfo>(criteria);
			Tema.CloseSession(criteria.SessionCode);
			return obj;
		}


		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static TemaInfo Get(IDataReader reader, bool childs)
		{
			return new TemaInfo(reader, childs);
		}

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
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

					if (reader.Read())
                        _base.CopyValues(reader);

				}
				else
				{
                    _base.Record.CopyValues((TemaRecord)(criteria.UniqueResult()));

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

			}
			catch (Exception ex)
			{
				iQExceptionHandler.TreatException(ex);
			}
		}

		#endregion

	}
}

