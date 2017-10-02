using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Hipatia;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// ReadOnly Root Business Object with ReadOnly Childs
    /// </summary>
    [Serializable()]
    public class CursoInfo : ReadOnlyBaseEx<CursoInfo>, IAgenteHipatia
    {
        #region Attributes

        protected CursoBase _base = new CursoBase();

        private Curso_InstructorList _c_profesores = null;
        private Convocatoria_CursoList _convocatorias = null;
        private MaterialDocenteList _materiales = null;


        #endregion

        #region Properties

        public CursoBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public long NHoras { get { return _base.Record.NHoras; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }

        public virtual Curso_InstructorList CProfesores { get { return _c_profesores; } }
        public virtual Convocatoria_CursoList Convocatorias { get { return _convocatorias; } }
        public virtual MaterialDocenteList Materiales { get { return _materiales; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Curso source) { _base.CopyValues(source); }

        #endregion		

        #region IAgenteHipatia

        public string NombreHipatia { get { return Nombre; } }
        public string IDHipatia { get { return Codigo; } }
        public string ObservacionesHipatia { get { return Observaciones; } }
        public Type TipoEntidad { get { return typeof(Curso); } }

        #endregion
        
        #region Factory Methods

        private CursoInfo() { /* require use of factory methods */ }

        private CursoInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal CursoInfo(Curso source, bool copy_childs)
        {
            _base.CopyValues(source);

            if (copy_childs)
            {
                _c_profesores = (source.Curso_Instructors != null) ?  Curso_InstructorList.GetChildList(source.Curso_Instructors) : null;
                _convocatorias = (source.Convocatorias != null) ?  Convocatoria_CursoList.GetChildList(source.Convocatorias) : null;
                _materiales = (source.MaterialDocentes != null) ?  MaterialDocenteList.GetChildList(source.MaterialDocentes) : null;
            }
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static CursoInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static CursoInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = Curso.GetCriteria(Curso.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            CursoInfo obj = DataPortal.Fetch<CursoInfo>(criteria);
            Curso.CloseSession(criteria.SessionCode);
            return obj;
        }

        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static CursoInfo Get(IDataReader reader, bool childs)
        {
            return new CursoInfo(reader, childs);
        }

        public static CursoInfo New(long oid = 0) { return new CursoInfo() { Oid = oid }; }

        #endregion

        #region Data Access

        // called to retrieve data from db
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
            SessionCode = criteria.SessionCode;
            Childs = criteria.Childs;

            try
            {
                _base.Record.CopyValues((CursoRecord)(criteria.UniqueResult()));

                if (Childs)
                {
                    criteria = Curso_Instructor.GetCriteria(criteria.Session);
                    criteria.AddEq("OidCurso", this.Oid);
                    _c_profesores = Curso_InstructorList.GetChildList(criteria.List<Curso_Instructor>());

                    criteria = Convocatoria_Curso.GetCriteria(criteria.Session);
                    criteria.AddEq("OidCurso", this.Oid);
                    _convocatorias = Convocatoria_CursoList.GetChildList(criteria.List<Convocatoria_Curso>());

                    criteria = MaterialDocente.GetCriteria(criteria.Session);
                    criteria.AddEq("OidCurso", this.Oid);
                    _materiales = MaterialDocenteList.GetChildList(criteria.List<MaterialDocente>());
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
                    string query = Curso_Instructors.SELECT_BY_CURSO(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _c_profesores = Curso_InstructorList.GetChildList(reader);

                    query = Convocatoria_Cursos.SELECT_BY_CURSO(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _convocatorias = Convocatoria_CursoList.GetChildList(reader);

                    query = MaterialDocentes.SELECT_BY_CURSO(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _materiales = MaterialDocenteList.GetChildList(reader);
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

