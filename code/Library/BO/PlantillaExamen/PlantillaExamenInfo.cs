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
    public class PlantillaExamenInfo : ReadOnlyBaseEx<PlantillaExamenInfo>
    {

        #region Business Methods

        protected PlantillaExamenBase _base = new PlantillaExamenBase();

        private Preguntas_PlantillaList _preguntas = null;
        #endregion

        #region Properties

        public PlantillaExamenBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidModulo { get { return _base.Record.OidModulo; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Idioma { get { return _base.Record.Idioma; } }
        public bool Desarrollo { get { return _base.Record.Desarrollo; } }
        public long NPreguntas { get { return _base.Record.NPreguntas; } }
        public string Nombre { get { return _base.Record.Nombre; } }

        public virtual Preguntas_PlantillaList Preguntas { get { return _preguntas; } }

        public string Modulo { get { return _base.Modulo; } }


        #endregion

        #region Business Methods

        public void CopyFrom(PlantillaExamen source) { _base.CopyValues(source); }

        #endregion

        #region Factory Methods

        protected PlantillaExamenInfo() { /* require use of factory methods */ }

        private PlantillaExamenInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reader"><see cref="BusinessBaseEx"/> origen</param>
        /// <param name="copy_childs">Flag para copiar los hijos</param>
        /// <remarks>
        ///  NO UTILIZAR DIRECTAMENTE. Object creation require use of factory methods
        /// </remarks>
		internal PlantillaExamenInfo(PlantillaExamen item, bool copy_childs)
		{
            _base.CopyValues(item);
			
			if (copy_childs)
			{
                _preguntas = (item.Preguntas != null) ? Preguntas_PlantillaList.GetChildList(item.Preguntas) : null;
			}
		}


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static PlantillaExamenInfo Get(long oid)
        {
            return Get(oid, true);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static PlantillaExamenInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = PlantillaExamen.GetCriteria(PlantillaExamen.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            criteria.Query = PlantillaExamen.SELECT(oid);
            PlantillaExamenInfo obj = DataPortal.Fetch<PlantillaExamenInfo>(criteria);
            PlantillaExamen.CloseSession(criteria.SessionCode);
            return obj;
        }

        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static PlantillaExamenInfo Get(IDataReader reader, bool childs)
        {
            return new PlantillaExamenInfo(reader, childs);
        }

        public static PlantillaExamenInfo New(long oid = 0) { return new PlantillaExamenInfo() { Oid = oid }; }

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

                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session()); //PlantillaExamen.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;

                        query = Preguntas_PlantillaList.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _preguntas = Preguntas_PlantillaList.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((PlantillaExamenRecord)(criteria.UniqueResult()));

                    if (Childs)                    {

                        criteria = Preguntas_Plantilla.GetCriteria(criteria.Session);
                        criteria.AddEq("OidPlantilla", this.Oid);
                        _preguntas = Preguntas_PlantillaList.GetChildList(criteria.List<Preguntas_Plantilla>());
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

                    query = Preguntas_PlantillaList.SELECT(this);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _preguntas = Preguntas_PlantillaList.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

        #region SQL

        internal static string SELECT(long oid) { return PlantillaExamen.SELECT(oid, false); }

        #endregion
    }
}

