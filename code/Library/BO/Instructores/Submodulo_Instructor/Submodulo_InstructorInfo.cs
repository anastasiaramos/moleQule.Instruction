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
    public class Submodulo_InstructorInfo : ReadOnlyBaseEx<Submodulo_InstructorInfo>
    {

        #region Attributes

        protected Submodulo_InstructorBase _base = new Submodulo_InstructorBase();

        #endregion

        #region Properties

        public Submodulo_InstructorBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidInstructor { get { return _base.Record.OidInstructor; } }
        public long OidSubmodulo { get { return _base.Record.OidSubmodulo; } }
        public long OidInstructorSuplente { get { return _base.Record.OidInstructorSuplente; } }
        public DateTime FechaInicio { get { return _base.Record.FechaInicio; } }
        public DateTime FechaFin { get { return _base.Record.FechaFin; } }

        public long OidModulo { get { return _base.OidModulo; } }

        #endregion

        #region Business Methods

        public void CopyFrom(Submodulo_Instructor source) { _base.CopyValues(source); }

        #endregion

        #region Factory Methods

        protected Submodulo_InstructorInfo() { /* require use of factory methods */ }

        private Submodulo_InstructorInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal Submodulo_InstructorInfo(Submodulo_Instructor item)
        {
            _base.CopyValues(item);
        }


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static Submodulo_InstructorInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static Submodulo_InstructorInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = ClasePractica.GetCriteria(ClasePractica.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            Submodulo_InstructorInfo obj = DataPortal.Fetch<Submodulo_InstructorInfo>(criteria);
            ClasePractica.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Submodulo_InstructorInfo Get(IDataReader reader, bool childs)
        {
            return new Submodulo_InstructorInfo(reader, childs);
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

                    //ClasePractica.DoLOCK( Session());

                    IDataReader reader = ClasePractica.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);
                }
                else
                {
                    _base.Record.CopyValues((Submodulo_InstructorRecord)(criteria.UniqueResult()));

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

            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

    }
}

