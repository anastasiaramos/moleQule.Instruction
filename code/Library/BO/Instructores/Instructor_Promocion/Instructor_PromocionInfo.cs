using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// ReadOnly Child Business Object with ReadOnly Childs
    /// </summary>
    [Serializable()]
    public class Instructor_PromocionInfo : ReadOnlyBaseEx<Instructor_PromocionInfo>
    {
        #region Attributes

        protected Instructor_PromocionBase _base = new Instructor_PromocionBase();

        private Submodulo_Instructor_PromocionList _submodulos = null;


        #endregion

        #region Properties

        public Instructor_PromocionBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidInstructor { get { return _base.Record.OidInstructor; } }
        public long OidPromocion { get { return _base.Record.OidPromocion; } }

        public virtual Submodulo_Instructor_PromocionList Submodulos { get { return _submodulos; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Instructor_Promocion source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected Instructor_PromocionInfo() { /* require use of factory methods */ }

        private Instructor_PromocionInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal Instructor_PromocionInfo(Instructor_Promocion item, bool copy_childs)
        {
            _base.CopyValues(item);

            if (copy_childs)
            {
                _submodulos = (item.Submodulos != null) ? Submodulo_Instructor_PromocionList.GetChildList(item.Submodulos) : null;
            }
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static Instructor_PromocionInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static Instructor_PromocionInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = Instructor_Promocion.GetCriteria(Instructor_Promocion.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            Instructor_PromocionInfo obj = DataPortal.Fetch<Instructor_PromocionInfo>(criteria);
            Instructor_Promocion.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Instructor_PromocionInfo Get(IDataReader reader)
        {
            return new Instructor_PromocionInfo(reader, true);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Instructor_PromocionInfo Get(IDataReader reader, bool childs)
        {
            return new Instructor_PromocionInfo(reader, childs);
        }

        public void LoadSubmodulo_Instructor_PromocionChilds(long oid_promocion, DateTime fecha_inicio, DateTime fecha_fin)
        {
            int sesion = Submodulo_Instructor_Promocion.OpenSession();
            string query = Submodulos_Instructores_Promociones.SELECT_BY_INSTRUCTOR_PROMOCION(this.Oid, fecha_inicio, fecha_fin);
            IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session(sesion));
            _submodulos = Submodulo_Instructor_PromocionList.GetChildList(reader);
            Submodulo_Instructor_Promocion.CloseSession(sesion);
        }


        #endregion

        #region Data Access

        // called to retrieve data from db
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                SessionCode = criteria.SessionCode;
                Childs = criteria.Childs;

                if (nHMng.UseDirectSQL)
                {

                    IDataReader reader = Instructor_Promocion.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;

                        query = Submodulos_Instructores_Promociones.SELECT_BY_INSTRUCTOR_PROMOCION(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _submodulos = Submodulo_Instructor_PromocionList.GetChildList(reader);

                    }
                }
                else
                {
                    _base.Record.CopyValues((Instructor_PromocionRecord)(criteria.UniqueResult()));

                    if (Childs)
                    {

                        criteria = Submodulo_Instructor_Promocion.GetCriteria(criteria.Session);
                        criteria.AddEq("OidInstructorPromocion", this.Oid);
                        _submodulos = Submodulo_Instructor_PromocionList.GetChildList(criteria.List<Submodulo_Instructor_Promocion>());

                    }
                }

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        //called to copy data from IDataReader
        private void Fetch(IDataReader source)
        {
            try
            {
                _base.CopyValues(source);

                if (Childs)
                {
                    string query = string.Empty;
                    IDataReader reader;

                    query = Submodulos_Instructores_Promociones.SELECT_BY_INSTRUCTOR_PROMOCION(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _submodulos = Submodulo_Instructor_PromocionList.GetChildList(reader);

                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

    }
}

