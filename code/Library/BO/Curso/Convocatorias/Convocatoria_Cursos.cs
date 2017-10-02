using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// Editable Child Collection
    /// </summary>
    [Serializable()]
    public class Convocatoria_Cursos : BusinessListBaseEx<Convocatoria_Cursos, Convocatoria_Curso>
    {

        #region Business Methods

        public Convocatoria_Curso NewItem(Curso parent)
        {
            this.AddItem(Convocatoria_Curso.NewChild(parent));
            return this[Count - 1];
        }

        #endregion

        #region Factory Methods

        private Convocatoria_Cursos()
        {
            MarkAsChild();
        }

        private Convocatoria_Cursos(IList<Convocatoria_Curso> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Convocatoria_Cursos(int session_code, IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(session_code, reader);
        }


        public static Convocatoria_Cursos NewChildList() { return new Convocatoria_Cursos(); }

        public static Convocatoria_Cursos GetChildList(IList<Convocatoria_Curso> lista) { return new Convocatoria_Cursos(lista); }

        public static Convocatoria_Cursos GetChildList(int session_code, IDataReader reader, bool childs) { return new Convocatoria_Cursos(session_code, reader, childs); }

        public static Convocatoria_Cursos GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Convocatoria_Curso> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Convocatoria_Curso item in lista)
                this.AddItem(Convocatoria_Curso.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Convocatoria_Curso.GetChild(session_code, reader));

            this.RaiseListChangedEvents = true;
        }

        internal void Update(Curso parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Convocatoria_Curso obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Convocatoria_Curso obj in this)
            {
                if (obj.IsNew)
                    obj.Insert(parent);
                else
                    obj.Update(parent);
            }

            this.RaiseListChangedEvents = true;
        }

        #endregion

        #region SQL

        public static string SELECT_BY_CURSO(long oid_curso)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Curso = CursoInfo.New()
            };

            conditions.Curso.Oid = oid_curso;

            return Convocatoria_Curso.SELECT(conditions, true);
        }

        #endregion

    }
}

