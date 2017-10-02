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
    public class Convocatoria_CursoInfo : ReadOnlyBaseEx<Convocatoria_CursoInfo>
    {
        #region Attributes

        protected Convocatoria_CursoBase _base = new Convocatoria_CursoBase();

        private Alumno_ConvocatoriaList _alumnos = null;


        #endregion

        #region Properties

        public Convocatoria_CursoBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public DateTime FechaInicio { get { return _base.Record.FechaInicio; } }
        public DateTime FechaCaducidad { get { return _base.Record.FechaCaducidad; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public long OidCurso { get { return _base.Record.OidCurso; } }

        
        public virtual Alumno_ConvocatoriaList Alumnos { get { return _alumnos; } }

        #endregion

        #region Business Methods

        public void CopyFrom(Convocatoria_Curso source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected Convocatoria_CursoInfo() { /* require use of factory methods */ }

        private Convocatoria_CursoInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal Convocatoria_CursoInfo(Convocatoria_Curso source, bool copy_childs)
        {
            _base.CopyValues(source);

            if (copy_childs)
            {
                _alumnos = (source.Alumnos != null) ?  Alumno_ConvocatoriaList.GetChildList(source.Alumnos) : null;
            }
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static Convocatoria_CursoInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static Convocatoria_CursoInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = Convocatoria_Curso.GetCriteria(Convocatoria_Curso.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            Convocatoria_CursoInfo obj = DataPortal.Fetch<Convocatoria_CursoInfo>(criteria);
            Convocatoria_Curso.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Convocatoria_CursoInfo Get(IDataReader reader, bool childs)
        {
            return new Convocatoria_CursoInfo(reader, childs);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Convocatoria_CursoInfo Get(IDataReader reader)
        {
            return new Convocatoria_CursoInfo(reader, true);
        }

        public static Convocatoria_CursoInfo New(long oid = 0) { return new Convocatoria_CursoInfo() { Oid = oid }; }

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

                    IDataReader reader = Convocatoria_Curso.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;
                        
                        query = AlumnoCursos.SELECT_BY_CONVOCATORIA(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos = Alumno_ConvocatoriaList.GetChildList(reader);

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
                    string query = Alumno_Convocatorias.SELECT_BY_CONVOCATORIA(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _alumnos = Alumno_ConvocatoriaList.GetChildList(reader);
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

