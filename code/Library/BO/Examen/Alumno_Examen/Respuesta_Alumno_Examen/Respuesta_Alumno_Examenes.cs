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
    /// Editable Child Business Object
    /// </summary>
    [Serializable()]
    public class Respuesta_Alumno_Examenes : BusinessListBaseEx<Respuesta_Alumno_Examenes, Respuesta_Alumno_Examen>
    {

        #region Business Methods

        public Respuesta_Alumno_Examen NewItem(Alumno_Examen parent)
        {
            this.AddItem(Respuesta_Alumno_Examen.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Respuesta_Alumno_Examenes()
        {
            MarkAsChild();
        }

        private Respuesta_Alumno_Examenes(IList<Respuesta_Alumno_Examen> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Respuesta_Alumno_Examenes(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Respuesta_Alumno_Examenes NewChildList() { return new Respuesta_Alumno_Examenes(); }

        public static Respuesta_Alumno_Examenes GetChildList(IList<Respuesta_Alumno_Examen> lista) { return new Respuesta_Alumno_Examenes(lista); }

        public static Respuesta_Alumno_Examenes GetChildList(IDataReader reader) { return new Respuesta_Alumno_Examenes(reader); }

        public static Respuesta_Alumno_Examenes GetChildList(Alumno_Examen parent, bool childs)
        {
            CriteriaEx criteria = Respuesta_Alumno_Examen.GetCriteria(parent.SessionCode);

            criteria.Query = Respuesta_Alumno_Examenes.SELECT_BY_ALUMNO_EXAMEN(parent.Oid);
            criteria.Childs = childs;

            return DataPortal.Fetch<Respuesta_Alumno_Examenes>(criteria);
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Respuesta_Alumno_Examen> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Respuesta_Alumno_Examen item in lista)
                this.AddItem(Respuesta_Alumno_Examen.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Respuesta_Alumno_Examen.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Alumno_Examen parent, ISession sesion)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Respuesta_Alumno_Examen obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Respuesta_Alumno_Examen obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent, sesion);
                else
                    obj.Update(parent, sesion);
            }

            this.RaiseListChangedEvents = true;
        }

        #endregion

        #region Root Data Access

        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria">Criterios de la consulta</param>
        /// <remarks>LA UTILIZA EL DATAPORTAL</remarks>
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            Fetch(criteria);
        }

        /// <summary>
        /// Construye el objeto y se encarga de obtener los
        /// hijos si los tiene y se solicitan
        /// </summary>
        /// <param name="criteria">Criterios de la consulta</param>
        private void Fetch(CriteriaEx criteria)
        {
            try
            {
                this.RaiseListChangedEvents = false;
                SessionCode = criteria.SessionCode;
                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {
                    Respuesta_Alumno_Examen.DoLOCK(Session());
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    while (reader.Read())
                        this.AddItem(Respuesta_Alumno_Examen.GetChild(reader));
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

        public static string SELECT_BY_ALUMNO_EXAMEN(long oid_alumno_examen)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Alumno_Examen = Alumno_ExamenInfo.New()
            };

            conditions.Alumno_Examen.Oid = oid_alumno_examen;

            return Respuesta_Alumno_Examen.SELECT(conditions, true);
        }

        #endregion
    }
}

