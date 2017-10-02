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
	public class PreguntaExamens : BusinessListBaseEx<PreguntaExamens, PreguntaExamen>
	{
	
        #region Business Methods

        public PreguntaExamen NewItem(Examen parent)
        {
	        this.AddItem(PreguntaExamen.NewChild(parent));
	        return this[Count - 1];
        }

        //public PreguntaExamen NewItem(Modulo parent)
        //{
        //    this.AddItem(PreguntaExamen.NewChild(parent));
        //    return this[Count - 1];
        //}

        //public PreguntaExamen NewItem(Tema parent)
        //{
        //    this.AddItem(PreguntaExamen.NewChild(parent));
        //    return this[Count - 1];
        //}

        public PreguntaExamen GetItemByPregunta(long oid_pregunta)
        {
            foreach (PreguntaExamen item in this)
                if (item.OidPregunta == oid_pregunta)
                    return item;
            
            return null;
        }

        #endregion

        #region Factory Methods

        private PreguntaExamens()
        {
            MarkAsChild();
        }

        private PreguntaExamens(IList<PreguntaExamen> lista)
        {
            MarkAsChild();
            Fetch(lista);
        }

        private PreguntaExamens(int session_code, IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(session_code, reader);
        }

        public static PreguntaExamens NewChildList() { return new PreguntaExamens(); }

        public static PreguntaExamens GetChildList(IList<PreguntaExamen> lista) { return new PreguntaExamens(lista); }

        public static PreguntaExamens GetChildList(int session_code, IDataReader reader, bool childs) { return new PreguntaExamens(session_code, reader, childs); }

        public static PreguntaExamens GetChildList(int session_code, IDataReader reader) { return GetChildList(session_code, reader, true); }

        #endregion
		
        #region Child Data Access

        // called to copy objects data from list
        private void Fetch(IList<PreguntaExamen> lista)
        {
	        this.RaiseListChangedEvents = false;
        	
	        foreach (PreguntaExamen item in lista)
		        this.AddItem(PreguntaExamen.GetChild(item));
        	
	        this.RaiseListChangedEvents = true;
        }

        private void Fetch(int session_code, IDataReader reader)
        {
	        this.RaiseListChangedEvents = false;

	        while (reader.Read())
		        this.AddItem(PreguntaExamen.GetChild(session_code, reader));

	        this.RaiseListChangedEvents = true;
        }


        internal void Update(Examen parent)
        {
	        this.RaiseListChangedEvents = false;

	        // update (thus deleting) any deleted child objects
	        foreach (PreguntaExamen obj in DeletedList)
		        obj.DeleteSelf(parent);

	        // now that they are deleted, remove them from memory too
	        DeletedList.Clear();

	        // AddItem/update any current child objects
	        foreach (PreguntaExamen obj in this)
	        {
		        if (obj.IsNew)
			        obj.Insert(parent);
		        else
			        obj.Update(parent);
	        }

	        this.RaiseListChangedEvents = true;
        }

        //internal void Update(Modulo parent)
        //{
        //    this.RaiseListChangedEvents = false;

        //    // update (thus deleting) any deleted child objects
        //    foreach (PreguntaExamen obj in DeletedList)
        //        obj.DeleteSelf(parent);

        //    // now that they are deleted, remove them from memory too
        //    DeletedList.Clear();

        //    // AddItem/update any current child objects
        //    foreach (PreguntaExamen obj in this)
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
        //    foreach (PreguntaExamen obj in DeletedList)
        //        obj.DeleteSelf(parent);

        //    // now that they are deleted, remove them from memory too
        //    DeletedList.Clear();

        //    // AddItem/update any current child objects
        //    foreach (PreguntaExamen obj in this)
        //    {
        //        if (obj.IsNew)
        //            obj.Insert(parent);
        //        else
        //            obj.Update(parent);
        //    }

        //    this.RaiseListChangedEvents = true;
        //}

        #endregion

        #region SQL

        public new static string SELECT() { return PreguntaExamen.SELECT(0); }

        public static string SELECT_BY_EXAMEN(long oid_examen) { return SELECT_BY_EXAMEN(oid_examen, true); }
        public static string SELECT_BY_EXAMEN(long oid_examen, bool lockTable) 
        {
            QueryConditions conditions = new QueryConditions 
            { 
                Examen = ExamenInfo.New()
            };
            conditions.Examen.Oid = oid_examen;

            return PreguntaExamen.SELECT(conditions, lockTable);
        }

        #endregion
	}
}

