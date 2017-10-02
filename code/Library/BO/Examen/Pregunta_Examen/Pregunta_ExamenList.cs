using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{
    /// <summary>
    /// ReadOnly Root Collection of Business Objects With Child Collection
    /// </summary>
    [Serializable()]
    public class Pregunta_ExamenList : ReadOnlyListBaseEx<Pregunta_ExamenList, Pregunta_ExamenInfo>
    {

        #region Factory Methods

        private Pregunta_ExamenList() { }

        private Pregunta_ExamenList(IList<Pregunta_Examen> lista)
        {
            Fetch(lista);
        }

        private Pregunta_ExamenList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a Pregunta_ExamenList from a IList<!--<Pregunta_ExamenInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Pregunta_ExamenList</returns>
        public static Pregunta_ExamenList GetChildList(IList<Pregunta_ExamenInfo> list)
        {
            Pregunta_ExamenList flist = new Pregunta_ExamenList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Pregunta_ExamenInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a Pregunta_ExamenList from IList<!--<Pregunta_Examen>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Pregunta_ExamenList</returns>
        public static Pregunta_ExamenList GetChildList(IList<Pregunta_Examen> list) { return new Pregunta_ExamenList(list); }

        public static Pregunta_ExamenList GetChildList(IDataReader reader) { return new Pregunta_ExamenList(reader); }

        #endregion

        #region Data Access

        // called to copy objects data from list
        private void Fetch(IList<Pregunta_Examen> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Pregunta_Examen item in lista)
                this.AddItem(item.GetInfo());

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }


        // called to copy objects data from list
        private void Fetch(IDataReader reader)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            while (reader.Read())
                this.AddItem(Pregunta_ExamenInfo.Get(reader, Childs));

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to retrieve data from db
        protected override void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    //Pregunta_Examen.DoLOCK( Session());

                    IDataReader reader = Pregunta_Examens.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(Pregunta_ExamenInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Pregunta_Examen> list = criteria.List<Pregunta_Examen>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Pregunta_Examen item in list)
                            this.AddItem(item.GetInfo());

                        IsReadOnly = true;
                    }
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            this.RaiseListChangedEvents = true;
        }

        #endregion

        #region SQL

        public static string SELECT_BY_EXAMEN(long oid_examen) { return Pregunta_Examens.SELECT_BY_EXAMEN(oid_examen, false); }
        
        #endregion

    }
}

