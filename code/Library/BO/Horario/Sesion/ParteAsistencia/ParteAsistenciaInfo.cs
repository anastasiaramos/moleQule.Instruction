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
    public class ParteAsistenciaInfo : ReadOnlyBaseEx<ParteAsistenciaInfo>
    {

        #region Attributes

        protected ParteAsistenciaBase _base = new ParteAsistenciaBase();
        
        private Alumno_ParteList _alumnos = null;
        //private Concepto_ParteList _conceptos = null;
        private Alumno_PracticaList _alumnos_practicas = null;
        private Clase_ParteList _clases = null;

        #endregion

        #region Properties

        public ParteAsistenciaBase Base { get { return _base; } }

        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidInstructor { get { return _base.Record.OidInstructor; } }
        public long OidHorario { get { return _base.Record.OidHorario; } }
        public string Sesiones { get { return _base.Record.Sesiones; } }
        public string Texto { get { return _base.Record.Texto; } }
        public string NHoras { get { return _base.Record.NHoras; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public string HoraInicio { get { return _base.Record.HoraInicio; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public long Tipo { get { return _base.Record.Tipo; } }
        public long OidInstructorEfectivo { get { return _base.Record.OidInstructorEfectivo; } }
        public bool Confirmada { get { return _base.Record.Confirmada; } }

        public virtual Alumno_ParteList Alumno_Partes { get { return _alumnos; } }
        //public virtual Concepto_ParteList Conceptos { get { return _conceptos; } }
        public virtual Alumno_PracticaList Alumnos_Practicas { get { return _alumnos_practicas; } }
        public virtual Clase_ParteList Clases { get { return _clases; } }

        public string Instructor { get { return _base.Instructor; } }
        public string Promocion { get { return _base.Promocion; } }
        public string InstructorEfectivo { get { return _base.InstructorEfectivo; } }

        #endregion

        #region Business Methods
        
        public void CopyFrom(ParteAsistencia source)
        {
            _base.CopyValues(source);
        }

        #endregion

        #region Factory Methods

        protected ParteAsistenciaInfo() { /* require use of factory methods */ }

        private ParteAsistenciaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal ParteAsistenciaInfo(ParteAsistencia item, bool copy_childs)
        {
            _base.CopyValues(item);

            if (copy_childs)
            {
                _alumnos = (item.Alumno_Partes != null) ? Alumno_ParteList.GetChildList(item.Alumno_Partes) : null;
                //_conceptos = (item.Conceptos != null) ? Concepto_ParteList.GetChildList(item.Conceptos) : null;
                _alumnos_practicas = (item.Alumnos_Practicas != null) ? Alumno_PracticaList.GetChildList(item.Alumnos_Practicas) : null;
                _clases = (item.Clases != null) ? Clase_ParteList.GetChildList(item.Clases) : null;
            }
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static ParteAsistenciaInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static ParteAsistenciaInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = ParteAsistencia.GetCriteria(ParteAsistencia.OpenSession());
            criteria.Childs = childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ParteAsistenciaInfo.SELECT(oid);
            else
                criteria.AddOidSearch(oid);
            
            ParteAsistenciaInfo obj = DataPortal.Fetch<ParteAsistenciaInfo>(criteria);
            ParteAsistencia.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static ParteAsistenciaInfo Get(IDataReader reader, bool childs)
        {
            return new ParteAsistenciaInfo(reader, childs);
        }

        public static ParteAsistenciaInfo New(long oid = 0) { return new ParteAsistenciaInfo() { Oid = oid }; }

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
                    IDataReader reader = nHMng.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;

                        query = Instruction.Alumno_Partes.SELECT_BY_PARTE_ORDERED(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos = Alumno_ParteList.GetChildList(reader);

                        //query = Concepto_ParteList.SELECT(this);
                        //reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        //_conceptos = Concepto_ParteList.GetChildList(reader);

                        query = Instruction.Alumno_PracticaList.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos_practicas = Alumno_PracticaList.GetChildList(reader);

                        query = Clase_ParteList.SELECT(this);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _clases = Clase_ParteList.GetChildList(reader);
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
                    string query = Instruction.Alumno_Partes.SELECT_BY_PARTE_ORDERED(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _alumnos = Alumno_ParteList.GetChildList(reader);

                    //query = Concepto_ParteList.SELECT(this);
                    //reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    //_conceptos = Concepto_ParteList.GetChildList(reader);

                    query = Instruction.Alumno_PracticaList.SELECT(this);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _alumnos_practicas = Alumno_PracticaList.GetChildList(reader);

                    query = Instruction.Clases_Partes.SELECT_BY_PARTE(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _clases = Clase_ParteList.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

        #region SQL

        public static string SELECT(long oid) { return ParteAsistencia.SELECT(oid, false); }

        #endregion
    }
}

