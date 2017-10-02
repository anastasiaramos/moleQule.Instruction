using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using NHibernate;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class PlantillaExamenes : BusinessListBaseEx<PlantillaExamenes, PlantillaExamen>
    {

        #region Business Methods

        public PlantillaExamen NewItem(Modulo parent)
        {
            this.AddItem(PlantillaExamen.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private PlantillaExamenes()
        {
            MarkAsChild();
        }

        private PlantillaExamenes(IList<PlantillaExamen> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private PlantillaExamenes(int session_code, IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static PlantillaExamenes NewChildList() { return new PlantillaExamenes(); }

        public static PlantillaExamenes GetChildList(IList<PlantillaExamen> lista) { return new PlantillaExamenes(lista); }

        public static PlantillaExamenes GetChildList(int session_code, IDataReader reader, bool childs) { return new PlantillaExamenes(session_code, reader, childs); }

        public static PlantillaExamenes GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static PlantillaExamenes GetList(bool childs)
        {
            CriteriaEx criteria = PlantillaExamen.GetCriteria(PlantillaExamen.OpenSession());
            criteria.Query = PlantillaExamenes.SELECT();
            criteria.Childs = childs;

            PlantillaExamen.BeginTransaction(criteria.SessionCode);
            return DataPortal.Fetch<PlantillaExamenes>(criteria);
        }

        public static PlantillaExamenes GetList() { return GetList(true); }

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <param name="get_childs">retrieving the childs</param>
        /// <returns></returns>
        public static PlantillaExamenes GetModuloList(long oid_modulo)
        {
            PlantillaExamenes lista = PlantillaExamenes.NewChildList();

            string query = PlantillaExamenes.SELECT_BY_MODULO(oid_modulo);
            IDataReader reader = nHManager.Instance.SQLNativeSelect(query);
            int session_code = PlantillaExamen.OpenSession();

            while (reader.Read())
                lista.AddItem(PlantillaExamen.GetChild(session_code, reader,true));

            CloseSession(session_code);

            return lista;
        }
        
        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<PlantillaExamen> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (PlantillaExamen item in lista)
                this.AddItem(PlantillaExamen.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(PlantillaExamen.GetChild(session_code, reader));

            this.RaiseListChangedEvents = true;
        }

        //internal void Update(Modulo parent)
        //{
        //    this.RaiseListChangedEvents = false;

        //    // update (thus deleting) any deleted child objects
        //    foreach (PlantillaExamen obj in DeletedList)
        //        obj.DeleteSelf(parent);

        //    // now that they are deleted, remove them from memory too
        //    DeletedList.Clear();

        //    // AddItem/update any current child objects
        //    foreach (PlantillaExamen obj in this)
        //    {
        //        if (obj.IsNew)
        //            obj.Insert(parent);
        //        else
        //            obj.Update(parent);
        //    }

        //    this.RaiseListChangedEvents = true;
        //}

        #endregion

        #region Root Data Access

        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            Fetch(criteria);
        }

        private void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            SessionCode = criteria.SessionCode;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    PlantillaExamen.DoLOCK(Session(SessionCode));
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query);

                    while (reader.Read())
                    {
                        PlantillaExamen obj = PlantillaExamen.GetChild(SessionCode, reader, criteria.Childs);
                        obj.SessionCode = this.SessionCode;
                        this.AddItem(obj);
                    }
                }
            }
            catch (NHibernate.ADOException ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.ThrowExceptionByCode(ex);
            }
            catch (Exception ex)
            {
                if (Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                this.RaiseListChangedEvents = true;
            }
        }

        #endregion

        #region SQL

        public new static string SELECT() { return PlantillaExamen.SELECT(0, true); }

        public static string SELECT_BY_OID(string schema, ISession sesion, object field_value)
        {
            int esquema = Convert.ToInt32(schema);
            string query = "SELECT * " +
                            "FROM \"" + esquema.ToString("0000") + "\".\"PlantillaExamen\" " +
                            "WHERE \"OID\" = " + field_value.ToString() + ";";

            return query;
        }

        public static string SELECT_BY_MODULO(long oid_modulo) { return SELECT_BY_MODULO(oid_modulo, true); }
        public static string SELECT_BY_MODULO(long oid_modulo, bool lockTable)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Modulo = ModuloInfo.New()
            };

            conditions.Modulo.Oid = oid_modulo;

            return PlantillaExamen.SELECT(conditions, lockTable);
        }

        #endregion

    }
}

