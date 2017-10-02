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
    public class Material_AlumnoList : ReadOnlyListBaseEx<Material_AlumnoList, Material_AlumnoInfo>
    {


        #region Factory Methods

        private Material_AlumnoList() { }

        private Material_AlumnoList(IList<Material_Alumno> lista)
        {
            Fetch(lista);
        }

        private Material_AlumnoList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a Material_AlumnoList from a IList<!--<Material_AlumnoInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Material_AlumnoList</returns>
        public static Material_AlumnoList GetChildList(IList<Material_AlumnoInfo> list)
        {
            Material_AlumnoList flist = new Material_AlumnoList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Material_AlumnoInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a Material_AlumnoList from IList<!--<Material_Alumno>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Material_AlumnoList</returns>
        public static Material_AlumnoList GetChildList(IList<Material_Alumno> list) { return new Material_AlumnoList(list); }

        public static Material_AlumnoList GetChildList(IDataReader reader) { return new Material_AlumnoList(reader); }

        #endregion

        #region Data Access

        // called to copy objects data from list
        private void Fetch(IList<Material_Alumno> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Material_Alumno item in lista)
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
                this.AddItem(Material_Alumno.GetChild(reader).GetInfo());

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
                    IDataReader reader = Material_Alumnos.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(Material_AlumnoInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Material_Alumno> list = criteria.List<Material_Alumno>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Material_Alumno item in list)
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

        public static string SELECT(AlumnoInfo item) { return Material_Alumno.SELECT(new QueryConditions() { Alumno = item }, false); }

        #endregion


    }
}

