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
    public class RevisionMaterialInfo : ReadOnlyBaseEx<RevisionMaterialInfo>
    {

        #region Business Methods

        protected RevisionMaterialBase _base = new RevisionMaterialBase();

        private Material_PlanList _materiales = null;

        #endregion

        #region Properties

        public RevisionMaterialBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidMaterial { get { return _base.Record.OidMaterial; } }
        public string Version { get { return _base.Record.Version; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public string Autor { get { return _base.Record.Autor; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }

        public virtual Material_PlanList Material_Plans { get { return _materiales; } }

        #endregion

        #region Business Methods

        public void CopyFrom(RevisionMaterial source) { _base.CopyValues(source); }

        #endregion

        #region Factory Methods

        protected RevisionMaterialInfo() { /* require use of factory methods */ }

        private RevisionMaterialInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal RevisionMaterialInfo(RevisionMaterial source, bool copy_childs)
        {
            _base.CopyValues(source);

            if (copy_childs)
            {
                _materiales = (source.Material_Plans != null) ? Material_PlanList.GetChildList(source.Material_Plans) : null;
            }
        }
        
        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static RevisionMaterialInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static RevisionMaterialInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = RevisionMaterial.GetCriteria(RevisionMaterial.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            RevisionMaterialInfo obj = DataPortal.Fetch<RevisionMaterialInfo>(criteria);
            RevisionMaterial.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static RevisionMaterialInfo Get(IDataReader reader)
        {
            return Get(reader, true);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static RevisionMaterialInfo Get(IDataReader reader, bool childs)
        {
            return new RevisionMaterialInfo(reader, childs);
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

                    //RevisionMaterial.DoLOCK( Session());

                    IDataReader reader = RevisionMaterial.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);


                    if (Childs)
                    {
                        string query = string.Empty;

                        //Material_Plan.DoLOCK( Session());

                        query = Material_PlanList.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _materiales = Material_PlanList.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((RevisionMaterialRecord)(criteria.UniqueResult()));

                    if (Childs)
                    {
                        criteria = Material_Plan.GetCriteria(criteria.Session);
                        criteria.AddEq("OidRevision", this.Oid);
                        _materiales = Material_PlanList.GetChildList(criteria.List<Material_Plan>());
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

                    query = Material_PlanList.SELECT(this);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _materiales = Material_PlanList.GetChildList(reader);
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

