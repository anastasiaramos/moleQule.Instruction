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
    public class Sesion_PromocionList : ReadOnlyListBaseEx<Sesion_PromocionList, Sesion_PromocionInfo>
    {


        #region Factory Methods

        private Sesion_PromocionList() { }

        private Sesion_PromocionList(IList<Sesion_Promocion> lista)
        {
            Fetch(lista);
        }

        private Sesion_PromocionList(IDataReader reader)
        {
            Fetch(reader);
        }

        /// <summary>
        /// Builds a Clase_ParteList from a IList<!--<Clase_ParteInfo>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Clase_ParteList</returns>
        public static Sesion_PromocionList GetChildList(IList<Sesion_PromocionInfo> list)
        {
            Sesion_PromocionList flist = new Sesion_PromocionList();

            if (list.Count > 0)
            {
                flist.IsReadOnly = false;

                foreach (Sesion_PromocionInfo item in list)
                    flist.AddItem(item);

                flist.IsReadOnly = true;
            }

            return flist;
        }

        /// <summary>
        /// Builds a Clase_ParteList from IList<!--<Clase_Parte>-->
        /// </summary>
        /// <param name="list"></param>
        /// <returns>Clase_ParteList</returns>
        public static Sesion_PromocionList GetChildList(IList<Sesion_Promocion> list) { return new Sesion_PromocionList(list); }

        public static Sesion_PromocionList GetChildList(IDataReader reader) { return new Sesion_PromocionList(reader); }

        #endregion

        #region Data Access

        // called to copy objects data from list
        private void Fetch(IList<Sesion_Promocion> lista)
        {
            this.RaiseListChangedEvents = false;

            IsReadOnly = false;

            foreach (Sesion_Promocion item in lista)
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
                this.AddItem(Sesion_Promocion.GetChild(reader).GetInfo());

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
                    IDataReader reader = Conceptos_Partes.DoNativeSELECT(AppContext.ActiveSchema.Code, Session());

                    IsReadOnly = false;

                    while (reader.Read())
                    {
                        this.AddItem(Sesion_PromocionInfo.Get(reader, Childs));
                    }

                    IsReadOnly = true;
                }
                else
                {
                    IList<Sesion_Promocion> list = criteria.List<Sesion_Promocion>();

                    if (list.Count > 0)
                    {
                        IsReadOnly = false;

                        foreach (Sesion_Promocion item in list)
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

        public static string SELECT(PromocionInfo item) { return Sesion_Promocion.SELECT(new QueryConditions() { Promocion = item, ESesionPromocion = ESesionPromocion.Promocion }, false); }

        #endregion


    }
}

