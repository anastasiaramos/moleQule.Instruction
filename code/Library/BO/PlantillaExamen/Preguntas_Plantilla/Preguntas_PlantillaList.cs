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
    public class Preguntas_PlantillaList : ReadOnlyListBaseEx<Preguntas_PlantillaList, Preguntas_PlantillaInfo>
    {

        #region Factory Methods

        private Preguntas_PlantillaList() { }

        private Preguntas_PlantillaList(IList<Preguntas_Plantilla> lista)
        {
            Fetch(lista);
        }

        private Preguntas_PlantillaList(IDataReader reader)
        {
            Fetch(reader);
        }
        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public static Preguntas_PlantillaList GetDisponiblesList(long oid_plantilla, DateTime fecha_disponibilidad)
        {
            CriteriaEx criteria = Preguntas_Plantilla.GetCriteria(Preguntas_Plantilla.OpenSession());
            criteria.Childs = false;
            criteria.Query = Preguntas_Plantillas.SELECT_DISPONIBLES(oid_plantilla, fecha_disponibilidad);
            //No criteria. Retrieve all de List
            Preguntas_PlantillaList list = DataPortal.Fetch<Preguntas_PlantillaList>(criteria);

            CloseSession(criteria.SessionCode);

            return list;
        }

        /// <summary>
        /// Builds a Preguntas_PlantillaList from a IList<!--<Preguntas_PlantillaInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Preguntas_PlantillaList</returns>
        public static Preguntas_PlantillaList GetChildList(IList<Preguntas_PlantillaInfo> list)
        {
            Preguntas_PlantillaList flist = new Preguntas_PlantillaList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Preguntas_PlantillaInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a Preguntas_PlantillaList from IList<!--<Preguntas_Plantilla>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Preguntas_PlantillaList</returns>
        public static Preguntas_PlantillaList GetChildList(IList<Preguntas_Plantilla> list) { return new Preguntas_PlantillaList(list); }

        public static Preguntas_PlantillaList GetChildList(IDataReader reader) { return new Preguntas_PlantillaList(reader); }

        #endregion

        #region Data Access

        // called to copy objects data from list
        private void Fetch(IList<Preguntas_Plantilla> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Preguntas_Plantilla item in lista)
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
                this.AddItem(Preguntas_PlantillaInfo.Get(reader,Childs));

            IsReadOnly = true;

            this.RaiseListChangedEvents = true;
        }

        // called to retrieve data from db
/*        protected override void Fetch(CriteriaEx criteria)
        {
            this.RaiseListChangedEvents = false;

            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                if (nHMng.UseDirectSQL)
                {
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(Preguntas_PlantillaInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Preguntas_Plantilla> list = criteria.List<Preguntas_Plantilla>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Preguntas_Plantilla item in list)
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
        }*/

        #endregion

        #region SQL

        public static string SELECT_BY_FIELD(string field, long value)
        {
            string pp = nHManager.Instance.GetSQLTable(typeof(Preguntas_PlantillaRecord));
            string search_field = nHManager.Instance.GetTableField(typeof(Preguntas_PlantillaRecord), field);

            string query;

            query = "SELECT PP.*" +
                    " FROM " + pp + " AS PP" +
                    " WHERE PP.\"" + search_field + "\" = " + value.ToString();

            return query;
        }
        public static string SELECT(PlantillaExamenInfo item) { return Preguntas_Plantilla.SELECT(new QueryConditions() { PlantillaExamen = item }, false); }

        #endregion

    }
}

