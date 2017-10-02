using System;
using System.Collections.Generic;
using System.Data;

using Csla;

using moleQule.Library.CslaEx;
using moleQule.Library.Invoice;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// Editable Child Business Object
	/// </summary>
    [Serializable()]
	public class Alumno_Convocatorias : BusinessListBaseEx<Alumno_Convocatorias, Alumno_Convocatoria>
	{

        #region Business Methods

        public Alumno_Convocatoria NewItem(Convocatoria_Curso parent)
        {
            this.AddItem(Alumno_Convocatoria.NewChild(parent));
            return this[Count - 1];
        }

        public Alumno_Convocatoria NewItem(Convocatoria_Curso parent, AlumnoInfo alumno, ClienteInfo cliente)
        {
            this.AddItem(Alumno_Convocatoria.NewChild(parent, alumno, cliente));
            return this[Count - 1];
        }

        public Alumno_Convocatoria NewItem(Convocatoria_Curso parent, AlumnoClienteInfo source)
        {
            this.AddItem(Alumno_Convocatoria.NewChild(parent, source));
            return this[Count - 1];
        }

        public Alumno_Convocatoria GetItemByAlumno(long oid_alumno)
        {
            foreach (Alumno_Convocatoria item in this)
                if (item.OidAlumno == oid_alumno)
                    return item;

            return null;
        }

        #endregion

        #region Factory Methods

        private Alumno_Convocatorias()
        {
            MarkAsChild();
        }

        private Alumno_Convocatorias(IList<Alumno_Convocatoria> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private Alumno_Convocatorias(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Alumno_Convocatorias NewChildList() { return new Alumno_Convocatorias(); }

        public static Alumno_Convocatorias GetChildList(IList<Alumno_Convocatoria> lista) { return new Alumno_Convocatorias(lista); }

        public static Alumno_Convocatorias GetChildList(IDataReader reader) { return new Alumno_Convocatorias(reader); }

        #endregion

        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<Alumno_Convocatoria> lista)
        {
            this.RaiseListChangedEvents = false;

            foreach (Alumno_Convocatoria item in lista)
                this.AddItem(Alumno_Convocatoria.GetChild(item));

            this.RaiseListChangedEvents = true;
        }

        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            while (reader.Read())
                this.AddItem(Alumno_Convocatoria.GetChild(reader));

            this.RaiseListChangedEvents = true;
        }


        internal void Update(Convocatoria_Curso parent)
        {
            this.RaiseListChangedEvents = false;

            // update (thus deleting) any deleted child objects
            foreach (Alumno_Convocatoria obj in DeletedList)
                obj.DeleteSelf(parent);

            // now that they are deleted, remove them from memory too
            DeletedList.Clear();

            // AddItem/update any current child objects
            foreach (Alumno_Convocatoria obj in this)
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

        public static string SELECT_BY_CONVOCATORIA(long oid_convocatoria)
        {
            QueryConditions conditions = new QueryConditions()
            {
                Convocatoria_Curso = Convocatoria_CursoInfo.New()
            };

            conditions.Convocatoria_Curso.Oid = oid_convocatoria;

            return Alumno_Convocatoria.SELECT(conditions, true);
        }

        #endregion
    }
}

