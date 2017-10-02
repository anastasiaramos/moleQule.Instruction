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
	public class ClaseTeoricaInfo : ReadOnlyBaseEx<ClaseTeoricaInfo>
    {
        #region Attributes

        protected ClaseTeoricaBase _base = new ClaseTeoricaBase();


        #endregion

        #region Properties

        public ClaseTeoricaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPlan { get { return _base.Record.OidPlan; } }
        public long OidModulo { get { return _base.Record.OidModulo; } }
        public long OidSubmodulo { get { return _base.Record.OidSubmodulo; } }
        public long OrdenPrimario { get { return _base.Record.OrdenPrimario; } }
        public long OrdenSecundario { get { return _base.Record.OrdenSecundario; } }
        public string Titulo { get { return _base.Record.Titulo; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public long OrdenTerciario { get { return _base.Record.OrdenTerciario; } }
        public string Alias { get { return _base.Record.Alias; } }
        public long TotalClases { get { return _base.Record.TotalClases; } }
        public long Duracion { get { return _base.Record.Duracion; } }

        public string Modulo { get { return _base.Modulo; } }
        public string Submodulo { get { return _base.Submodulo; } }
        public string CodigoOrden { get { return _base.CodigoOrden; } }
        //Está definido el ser porque es necesario modificarlo en lógica de negocio
        //pero nunca se modifica en la base de datos
        public long Estado { get { return _base.Estado; } set { _base.Estado = value; } }
        public virtual EEstadoClase EEstadoClase { get { return (EEstadoClase)_base.Estado; } set { _base.Estado = (long)value; } }
        public virtual string Instructor { get { return _base.Instructor; } }
        public virtual DateTime Fecha { get { return _base.Fecha; } }
        public virtual DateTime Hora { get { return _base.Hora; } }
        public long TotalModulo { get { return _base.TotalModulo; } }
        public long TotalSubmodulo { get { return _base.TotalSubmodulo; } }
        public long Tipo { get { return _base.Tipo; } }


        #endregion

        #region Business Methods

        public void CopyFrom(ClaseTeorica source) { _base.CopyValues(source); }

        #endregion		

		#region Factory Methods

		protected ClaseTeoricaInfo() { /* require use of factory methods */ }

		private ClaseTeoricaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}

		internal ClaseTeoricaInfo(ClaseTeorica item)
		{
            _base.CopyValues(item);
		}

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static ClaseTeoricaInfo Get(long oid)
		{
			return Get(oid, false);
		}

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static ClaseTeoricaInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = ClaseTeorica.GetCriteria(ClaseTeorica.OpenSession());
			criteria.AddOidSearch(oid);
			criteria.Childs = childs;
			ClaseTeoricaInfo obj = DataPortal.Fetch<ClaseTeoricaInfo>(criteria);
			ClaseTeorica.CloseSession(criteria.SessionCode);
			return obj;
		}


		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static ClaseTeoricaInfo Get(IDataReader reader, bool childs)
		{
			return new ClaseTeoricaInfo(reader, childs);
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

                    string query = ClaseTeorica.SELECT(criteria.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query);

					if (reader.Read())
                        _base.CopyValues(reader);

				}
				else
				{
                    _base.Record.CopyValues((ClaseTeoricaRecord)(criteria.UniqueResult()));
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

