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
	public class RespuestaExamenList : ReadOnlyListBaseEx<RespuestaExamenList, RespuestaExamenInfo>
	{

        #region Factory Methods

        private RespuestaExamenList() { }

        private RespuestaExamenList(IList<RespuestaExamen> lista)
        {
            Fetch(lista);
        }

        private RespuestaExamenList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a RespuestaExamenList from a IList<!--<RespuestaExamenInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>RespuestaExamenList</returns>
        public static RespuestaExamenList GetChildList(IList<RespuestaExamenInfo> list)
        {
            RespuestaExamenList flist = new RespuestaExamenList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (RespuestaExamenInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a RespuestaExamenList from IList<!--<RespuestaExamen>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>RespuestaExamenList</returns>
        public static RespuestaExamenList GetChildList(IList<RespuestaExamen> list) { return new RespuestaExamenList(list); }

        public static RespuestaExamenList GetChildList(IDataReader reader) { return new RespuestaExamenList(reader); }

        #endregion

        #region Data Access

        // called to copy objects data from list
        private void Fetch(IList<RespuestaExamen> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (RespuestaExamen item in lista)
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
                this.AddItem(RespuestaExamen.GetChild(reader).GetInfo());

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
                    //RespuestaExamen.DoLOCK( Session());

                    IDataReader reader = RespuestaExamens.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(RespuestaExamenInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<RespuestaExamen> list = criteria.List<RespuestaExamen>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (RespuestaExamen item in list)
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

        public static string SELECT_BY_PREGUNTA_EXAMEN(long oid_pregunta, long oid_examen) 
        { 
            return RespuestaExamens.SELECT_BY_PREGUNTA_EXAMEN(oid_pregunta, oid_examen, false); 
        }

        #endregion

    }
}

