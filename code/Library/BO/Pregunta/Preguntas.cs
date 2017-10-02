using System;
using System.Collections.Generic;
using System.Collections;
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
    public class Preguntas : BusinessListBaseEx<Preguntas, Pregunta>
    {

        #region Business Methods
        
        //public Pregunta NewItem(Modulo parent)
        //{
        //    this.AddItem(Pregunta.NewChild(parent));
        //    return this[Count - 1];
        //}

        //public Pregunta NewItem(Tema parent)
        //{
        //    this.AddItem(Pregunta.NewChild(parent));
        //    return this[Count - 1];
        //}

        public static void UpdateFechaDisponibilidad()
        {
            Preguntas lista = Preguntas.GetList(false);
            foreach (Pregunta item in lista)
            {
                if (item.FechaDisponibilidad < item.FechaAlta)
                    item.FechaDisponibilidad = item.FechaAlta;
                //else
                //    item.FechaDisponibilidad = item.FechaDisponibilidad.AddMonths(-6);
            }
            lista.Save();
        }

        /// <summary>
        /// Pega dos listas
        /// </summary>
        /// <param name="criteria">Filtro</param>
        /// <returns>Lista</returns>
        public static Preguntas Merge(Preguntas list1, Preguntas list2)
        {
            Preguntas list = new Preguntas();

            foreach (Pregunta item in list1)
                list.AddItem(item);

            foreach (Pregunta item in list2)
                list.AddItem(item);

            return list;
        }

        #endregion

        #region Child Factory Methods

        private Preguntas(bool is_child)
        {
            if (is_child)
                MarkAsChild();
        }

        private Preguntas()
        {
        }

        private Preguntas(IList<Pregunta> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Preguntas(int session_code, IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(session_code, reader, childs);
        }

        public static Preguntas NewChildList() { return new Preguntas(true); }

        public static Preguntas GetChildList(IList<Pregunta> lista) { return new Preguntas(lista); }

        public static Preguntas GetChildList(int session_code, IDataReader reader, bool childs) { return new Preguntas(session_code, reader, childs); }

        public static Preguntas GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }

        #endregion

        #region Root Factory Methods

        public static Preguntas NewList() 
        { 
            Preguntas list = new Preguntas();
            list.SessionCode = OpenSession();
            list.BeginTransaction();
            return list;
        }

        public static Preguntas GetList() { return GetList(true); }

        public static Preguntas GetList(bool childs)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            criteria.Query = Preguntas.SELECT();
            criteria.Childs = childs;

            Pregunta.BeginTransaction(criteria.SessionCode);
            return DataPortal.Fetch<Preguntas>(criteria);
        }

        public static Preguntas GetPreguntasByList(string lista_preguntas, int sessionCode = -1)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(sessionCode);

            if (lista_preguntas == string.Empty) lista_preguntas = "-1";
            criteria.Query = Preguntas.SELECT_BY_LIST(lista_preguntas);
            criteria.Childs = true;

            //Pregunta.BeginTransaction(criteria.SessionCode);
            Preguntas list = null;
            list = DataPortal.Fetch<Preguntas>(criteria);
            list.SharedTransaction = sessionCode == -1 ? false : true;
            return list;
        }
        
        public static Preguntas GetPreguntasModulo(long oid_modulo, bool childs)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());

            criteria.Query = Preguntas.SELECT_BY_MODULO(oid_modulo);
            criteria.Childs = childs;

            Pregunta.BeginTransaction(criteria.SessionCode);
            return DataPortal.Fetch<Preguntas>(criteria);
        }

        public static Preguntas GetPreguntasTema(long oid_tema, bool childs)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());

            criteria.Query = Preguntas.SELECT_BY_TEMA(oid_tema);
            criteria.Childs = childs;

            Pregunta.BeginTransaction(criteria.SessionCode);
            return DataPortal.Fetch<Preguntas>(criteria);
        }

        public static Preguntas GetPreguntasModulo(long oid_modulo)
        {
            return GetPreguntasModulo(oid_modulo, true);
        }

        public static Preguntas GetPreguntasTema(long oid_tema)
        {
            return GetPreguntasTema(oid_tema, false);
        }

        public static Preguntas GetPreguntasDuplicadasTema(long oid_tema)
        {
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());

            criteria.Query = PreguntaList.SELECT_BY_TEMA_DUPLICADAS(oid_tema);
            criteria.Childs = false;

            Pregunta.BeginTransaction(criteria.SessionCode);
            return DataPortal.Fetch<Preguntas>(criteria);
        }

        public static Preguntas GetPreguntasFiltradas(long oid_modulo, long oid_tema, long nivel,
                                                        string tipo, string idioma, DateTime fecha_alta,
                                                        DateTime fecha_disponibilidad, bool revisada,
                                                        bool activa, string texto, bool filtros, bool reservada, long numero)
        {
 
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());

            criteria.Query = Preguntas.SELECT_PREGUNTAS_FILTRADAS(oid_modulo, oid_tema, nivel, tipo,
                                                                    idioma, fecha_alta, fecha_disponibilidad,
                                                                    revisada, activa, texto, filtros, reservada, numero);
            criteria.Childs = true;

            Pregunta.BeginTransaction(criteria.SessionCode);
            return DataPortal.Fetch<Preguntas>(criteria);
        }

        public static Preguntas GetList(IList<Pregunta> list)
        {
            Preguntas flist = new Preguntas();

            if (list.Count > 0)
            {
                foreach (Pregunta item in list)
                    flist.AddItem(item);
            }

            return flist;
        }

        public static Preguntas GetList(PreguntaExamenList lista)
        {
            Preguntas list = new Preguntas();

            foreach (PreguntaExamenInfo item in lista)
                list.AddItem(Pregunta.NewChild(item));

            return list;
        }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Pregunta> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Pregunta item in lista)
            {
                Pregunta pregunta = Pregunta.GetChild(item);
                this.AddItem(pregunta);
            }

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader, bool childs)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
            {
                Pregunta pregunta = Pregunta.GetChild(session_code, reader, childs);
                this.AddItem(pregunta);
            }

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader)
        {
            Fetch(session_code, reader, true);
        }

        //public void DoUpdate(Modulo parent)
        //{
        //    this.Update(parent);
        //    //Transaction().Commit();
        //}

        //internal void Update(Modulo parent)
        //{
        //    this.RaiseListChangedEvents = false;

        //    // update (thus deleting) any deleted child objects
        //    foreach (Pregunta obj in DeletedList)
        //        obj.DeleteSelf(parent);

        //    // now that they are deleted, remove them from memory too
        //    DeletedList.Clear();

        //    // AddItem/update any current child objects
        //    foreach (Pregunta obj in this)
        //    {
        //        if (obj.IsNew)
        //            obj.Insert(parent);
        //        else
        //            obj.Update(parent);
        //    }

        //    this.RaiseListChangedEvents = true;
        //}

        //internal void Update(Tema parent)
        //{
        //    this.RaiseListChangedEvents = false;

        //    // update (thus deleting) any deleted child objects
        //    foreach (Pregunta obj in DeletedList)
        //        obj.DeleteSelf(parent);

        //    // now that they are deleted, remove them from memory too
        //    DeletedList.Clear();

        //    // AddItem/update any current child objects
        //    foreach (Pregunta obj in this)
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
#if TRACE
            Controler.Instance.Timer.Record("Preguntas.Fetch BEGIN");
#endif
            try
            {
                if (nHMng.UseDirectSQL)
                {
                    Pregunta.DoLOCK(Session(criteria.SessionCode));
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query);
#if TRACE
                    Controler.Instance.Timer.Record("Preguntas");
#endif
                    while (reader.Read())
                    {
                        Pregunta obj = Pregunta.GetChild(criteria.SessionCode, reader, criteria.Childs);
                        obj.SessionCode = this.SessionCode;
                        this.AddItem(obj);
                    }
#if TRACE
                    Controler.Instance.Timer.Record("Asignación de Preguntas");
#endif
                }
#if TRACE
                Controler.Instance.Timer.Record("Preguntas.Fetch END");
#endif
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
            foreach (Pregunta obj in DeletedList)
                obj.DeleteSelf(this);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            try
            {
                // AddItem/update any current child objects
                foreach (Pregunta obj in this)
                {
                    if (obj.IsNew)
                        obj.Insert(this);
                    else
                        obj.Update(this);
                }    
                
                if (!SharedTransaction) Transaction().Commit();
                success = true;
            }
            catch (Exception ex)
            {
                if (!SharedTransaction) if (!SharedTransaction && Transaction() != null) Transaction().Rollback();
                iQExceptionHandler.TreatException(ex);
                success = true;
            }
            finally
            {
                if (!success)
                    if (Transaction() != null) Transaction().Rollback();

                if (!SharedTransaction)
                    BeginTransaction();

                this.RaiseListChangedEvents = true;
            }
        }

        #endregion

        #region Commands

        public static List<Pregunta> GetPreguntasOrdenadas()
        {
            List<Pregunta> lista = new List<Pregunta>();
            string query = SELECT_PREGUNTAS();
            int sesion = Pregunta.OpenSession();

            IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));

            while (reader.Read())
            {
                Pregunta p = Pregunta.Get((long)reader["OID"]);

                lista.Add(p);
            }

            CloseSession(sesion);

            return lista;
        }

        #endregion

        #region SQL

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public new static string SELECT() 
        {
            string query;
            query = Pregunta.SELECT(0, true, string.Empty);
            return query;
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_PREGUNTAS()
        {
            string query = PreguntaList.SELECT_PREGUNTAS();
            return query; // +" FOR UPDATE OF P NOWAIT;";
        }

        public static string SELECT_BY_FIELD(string field, long value)
        {
            string query = PreguntaList.SELECT_BY_FIELD(field, value);
            return query;// +" FOR UPDATE OF P NOWAIT;";
        }

        public static string SELECT_BY_MODULO(long oid_modulo)
        {
            string query = PreguntaList.SELECT_BY_MODULO(oid_modulo);
            return query; // +" FOR UPDATE OF P NOWAIT;";
        }

        public static string SELECT_BY_TEMA(long oid_tema)
        {
            string query = PreguntaList.SELECT_BY_TEMA(oid_tema);
            return query; // +" FOR UPDATE OF P NOWAIT;";
        }

        public static string SELECT_BY_MODULO_LIST(long oid, string lista_preguntas)
        {
            string query = PreguntaList.SELECT_BY_MODULO_LIST(oid, lista_preguntas);
            return query; // +" FOR UPDATE OF P NOWAIT;";
        }


        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_BY_LIST(string lista_preguntas)
        {
            string query = PreguntaList.SELECT_BY_LIST(lista_preguntas);
            return query; // +" FOR UPDATE OF P NOWAIT";
        }

        /// <summary>
        /// Construye la tabla 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="schema"></param>
        /// <param name="sesion"></param>
        /// <returns></returns>
        public static string SELECT_PREGUNTAS_FILTRADAS(long oid_modulo, long oid_tema, long nivel,
                                                        string tipo, string idioma, DateTime fecha_alta,
                                                        DateTime fecha_disponibilidad, bool revisada,
                                                        bool activa, string texto, bool filtros, bool reservada,
                                                        long numero)
        {

            string query = PreguntaList.SELECT_PREGUNTAS_FILTRADAS(oid_modulo, oid_tema, nivel,
                                                        tipo, idioma, fecha_alta,
                                                        fecha_disponibilidad, revisada,
                                                        activa, texto, filtros, reservada,
                                                        numero);

            return query; // +" FOR UPDATE OF P NOWAIT;";
        }

        #endregion

    }
}

