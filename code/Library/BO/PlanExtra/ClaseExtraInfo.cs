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
    public class ClaseExtraInfo : ReadOnlyBaseEx<ClaseExtraInfo>
    {
        #region Attributes

        protected ClaseExtraBase _base = new ClaseExtraBase();

        private SesionList _sesions = null;


        #endregion

        #region Properties

        public ClaseExtraBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPlan { get { return _base.Record.OidPlan; } }
        public long OidModulo { get { return _base.Record.OidModulo; } }
        public long OidSubmodulo { get { return _base.Record.OidSubmodulo; } }
        public string Titulo { get { return _base.Record.Titulo; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public string Alias { get { return _base.Record.Alias; } }
        public long TotalClases { get { return _base.Record.TotalClases; } }
        public long Orden { get { return _base.Record.Orden; } }

        public string Modulo { get { return _base.Modulo; } }
        public string Submodulo { get { return _base.Submodulo; } }
        //Está definido el ser porque es necesario modificarlo en lógica de negocio
        //pero nunca se modifica en la base de datos
        public long Estado { get { return _base.Estado; } set { _base.Estado = value; } }
        public long Tipo { get { return _base.Tipo; } }

        public virtual SesionList Sesions { get { return _sesions; } }



        #endregion

        #region Business Methods

        public void CopyFrom(ClaseExtra source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected ClaseExtraInfo() { /* require use of factory methods */ }

        private ClaseExtraInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }
		internal ClaseExtraInfo(ClaseExtra source, bool copy_childs)
		{
			_base.CopyValues(source);
			
			if (copy_childs)
			{
				_sesions = (source.Sesions != null) ? SesionList.GetChildList(source.Sesions) : null;
			}
		}


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static ClaseExtraInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static ClaseExtraInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = ClaseExtra.GetCriteria(ClaseExtra.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            ClaseExtraInfo obj = DataPortal.Fetch<ClaseExtraInfo>(criteria);
            ClaseExtra.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static ClaseExtraInfo Get(IDataReader reader, bool childs)
        {
            return new ClaseExtraInfo(reader, childs);
        }

        public static ClaseExtraInfo New(long oid = 0) { return new ClaseExtraInfo() { Oid = oid }; }

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
                    //ClaseExtra.DoLOCK( Session());

                    IDataReader reader = ClaseExtra.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);


                    if (Childs)
                    {
                        //Sesion.DoLOCK( Session());

                        string query = Instruction.Sesions.SELECT_BY_CLASE_EXTRA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _sesions = SesionList.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((ClaseExtraRecord)(criteria.UniqueResult()));

                    if (Childs)
                    {
                        criteria = Sesion.GetCriteria(criteria.Session);
                        criteria.AddEq("OidClaseExtra", this.Oid);
                        _sesions = SesionList.GetChildList(criteria.List<Sesion>());
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
                    string query = Instruction.Sesions.SELECT_BY_CLASE_EXTRA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _sesions = SesionList.GetChildList(reader);
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

