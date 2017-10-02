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
    public class HistoriaList : ReadOnlyListBaseEx<HistoriaList, HistoriaInfo>
    {

        #region Factory Methods

        private HistoriaList() { }

        private HistoriaList(IList<Historia> lista)
        {
            Fetch(lista);
        }

        private HistoriaList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a HistoriaList from a IList<!--<HistoriaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>HistoriaList</returns>
        public static HistoriaList GetChildList(IList<HistoriaInfo> list)
        {
            HistoriaList flist = new HistoriaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (HistoriaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a HistoriaList from IList<!--<Historia>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>HistoriaList</returns>
        public static HistoriaList GetChildList(IList<Historia> list) { return new HistoriaList(list); }

        public static HistoriaList GetChildList(IDataReader reader) { return new HistoriaList(reader); }

        #endregion

        #region Data Access

        // called to copy objects data from list
        private void Fetch(IList<Historia> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Historia item in lista)
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
                this.AddItem(Historia.GetChild(reader).GetInfo());

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
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(HistoriaInfo.GetChild(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Historia> list = criteria.List<Historia>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Historia item in list)
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

        internal static string SELECT_BY_PREGUNTA(long oid) { return Historias.SELECT_BY_PREGUNTA(oid, false); }

        #endregion
    }
}

