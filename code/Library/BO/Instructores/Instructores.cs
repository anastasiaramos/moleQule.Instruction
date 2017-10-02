using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using NHibernate;

using moleQule.Library;
using moleQule.Library.Store;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// Editable Child Business Object
    /// </summary>
    [Serializable()]
    public class Instructores : BusinessListBaseEx<Instructores, Instructor>
    {

        #region Business Methods

        #endregion

        #region Factory Methods

        private Instructores() 
        {
        }

        private Instructores(IList<Instructor> lista)
        {
            Fetch(lista);
        }

        private Instructores(IDataReader reader)
        {
            Fetch(reader);
        }

        public static Instructores New() { return new Instructores(); }

        public static Instructores GetChildList(IList<Instructor> lista) { return new Instructores(lista); }

        public static Instructores GetChildList(IDataReader reader) { return new Instructores(reader); }

        public static Instructores GetList(bool childs)
        {
            CriteriaEx criteria = Instructor.GetCriteria(Instructor.OpenSession());

            Instructor.BeginTransaction(criteria.SessionCode);
            criteria.Query = Instructores.SELECT();
            criteria.Childs = childs;

            //No criteria. Retrieve all de List
            return DataPortal.Fetch<Instructores>(criteria);
        }

        public static Instructores GetList()
        {
            return GetList(true);
        }


        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Instructor> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Instructor item in lista)
                this.AddItem(Instructor.Get(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Instructor.Get(reader));

            this.RaiseListChangedEvents = true;
        }


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
                    Instructor.DoLOCK( Session());

                    IDataReader reader = null;

                    reader = Instructores.DoNativeSELECT(AppContext.ActiveSchema.Code, criteria.Session);

                    while (reader.Read())
                    {
                        Instructor item = Instructor.GetChild(reader);
                        item.MarkItemOld();
                        this.AddItem(item);
                    }
                }
                else
                {
                    IList list = criteria.List();

                    foreach (Instructor item in list)
                    {
                        //Bloqueamos todos los elementos de la lista
                        //Session().Lock(Session().Get<InstructorRecord>(item.Oid), LockMode.UpgradeNoWait);
                        this.AddItem(Instructor.Get(item));
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
            finally
            {
                this.RaiseListChangedEvents = true;
            }
        }

        protected override void DataPortal_Update()
        {
            bool success = false;

            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Instructor obj in DeletedList)
                obj.DeleteSelf(this);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            try
            {
                // AddItem/update any current child objects
                foreach (Instructor obj in this)
                {
                    if (obj.IsNew)
                        obj.Insert(this);
                    else
                        obj.Update(this);

                }

                Transaction().Commit();

                success = true;
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
            finally
            {
                if (!success)
                    if (Transaction() != null) Transaction().Rollback();

                BeginTransaction();

                this.RaiseListChangedEvents = true;
            }
        }

        #endregion

        #region Commands

        public static void SetCodigoInstructor()
        {
            Instructores lista = GetList(false);
            int serial = 1;

            foreach (Instructor item in lista)
            {
                if (item.Serial == 0)
                {
                    item.Codigo = serial.ToString(Resources.Defaults.EMPLEADO_CODE_FORMAT);
                    item.Serial = serial++;
                }
            }

            lista.Save();
            lista.CloseSession();
        }

        #endregion

        #region SQL

        public static string SELECT() { return Instructor.SELECT(0);/* SELECT(new moleQule.Library.Store.QueryConditions());*/ }
        //public static string SELECT(moleQule.Library.Store.QueryConditions conditions) { return ProviderBaseInfo.SELECT(conditions, ETipoAcreedor.Instructor); }

        #endregion

    }
}

