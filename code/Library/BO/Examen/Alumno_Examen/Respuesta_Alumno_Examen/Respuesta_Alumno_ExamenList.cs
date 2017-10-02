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
    public class Respuesta_Alumno_ExamenList : ReadOnlyListBaseEx<Respuesta_Alumno_ExamenList, Respuesta_Alumno_ExamenInfo>
    {

        #region Factory Methods

        private Respuesta_Alumno_ExamenList() { }

        private Respuesta_Alumno_ExamenList(IList<Respuesta_Alumno_Examen> lista)
        {
            Fetch(lista);
        }

        private Respuesta_Alumno_ExamenList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a Respuesta_Alumno_ExamenList from a IList<!--<Respuesta_Alumno_ExamenInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Respuesta_Alumno_ExamenList</returns>
        public static Respuesta_Alumno_ExamenList GetChildList(IList<Respuesta_Alumno_ExamenInfo> list)
        {
            Respuesta_Alumno_ExamenList flist = new Respuesta_Alumno_ExamenList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Respuesta_Alumno_ExamenInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a Respuesta_Alumno_ExamenList from IList<!--<Respuesta_Alumno_Examen>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Respuesta_Alumno_ExamenList</returns>
        public static Respuesta_Alumno_ExamenList GetChildList(IList<Respuesta_Alumno_Examen> list) { return new Respuesta_Alumno_ExamenList(list); }

        public static Respuesta_Alumno_ExamenList GetChildList(IDataReader reader) { return new Respuesta_Alumno_ExamenList(reader); }

        #endregion

        #region Data Access

        // called to copy objects data from list
        private void Fetch(IList<Respuesta_Alumno_Examen> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Respuesta_Alumno_Examen item in lista)
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
                this.AddItem(Respuesta_Alumno_Examen.GetChild(reader).GetInfo());

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
                    IDataReader reader = Respuesta_Alumno_Examenes.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(Respuesta_Alumno_ExamenInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Respuesta_Alumno_Examen> list = criteria.List<Respuesta_Alumno_Examen>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Respuesta_Alumno_Examen item in list)
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

        public static string SELECT(Alumno_ExamenInfo item) { return Respuesta_Alumno_Examen.SELECT(new QueryConditions() { Alumno_Examen = item }, false); }

        #endregion

    }
}

