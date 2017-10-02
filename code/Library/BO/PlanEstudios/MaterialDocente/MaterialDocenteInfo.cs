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
	public class MaterialDocenteInfo : ReadOnlyBaseEx<MaterialDocenteInfo>
	{

        #region Attributes

        protected MaterialDocenteBase _base = new MaterialDocenteBase();

        private RevisionMaterialList _revisiones = null;
        private Material_PlanList _planes = null;
        private Material_AlumnoList _alumnos = null;

        #endregion

        #region Properties

        public MaterialDocenteBase Base { get { return _base; } }

        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidCurso { get { return _base.Record.OidCurso; } }
        public long OidModulo { get { return _base.Record.OidModulo; } }
        public string Nombre { get { return _base.Record.Nombre; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }

        public virtual RevisionMaterialList Revisiones { get { return _revisiones; } }
        public virtual Material_PlanList Planes { get { return _planes; } }
        public virtual Material_AlumnoList Alumnos { get { return _alumnos; } }

        public string Modulo { get { return _base.Modulo; } }
        public string Curso { get { return _base.Curso; } }

        #endregion

        #region Business Methods
        
        public void CopyFrom(MaterialDocente source) { _base.CopyValues(source); }

        #endregion

        #region Factory Methods

        protected MaterialDocenteInfo() { /* require use of factory methods */ }

        private MaterialDocenteInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal MaterialDocenteInfo(MaterialDocente source, bool copy_childs)
		{
            _base.CopyValues(source);

            if (copy_childs)
            {
                _revisiones = (source.Revisiones != null) ? RevisionMaterialList.GetChildList(source.Revisiones) : null;
                _planes = (source.Planes != null) ? Material_PlanList.GetChildList(source.Planes) : null;
                _alumnos = (source.Alumnos != null) ? Material_AlumnoList.GetChildList(source.Alumnos) : null;
            }
		}

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static MaterialDocenteInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static MaterialDocenteInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = MaterialDocente.GetCriteria(MaterialDocente.OpenSession());
            criteria.Childs = childs;
            criteria.Query = MaterialDocenteInfo.SELECT(oid);
            
            MaterialDocenteInfo obj = DataPortal.Fetch<MaterialDocenteInfo>(criteria);
            MaterialDocente.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static MaterialDocenteInfo Get(IDataReader reader)
        {
            return new MaterialDocenteInfo(reader, true);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static MaterialDocenteInfo Get(IDataReader reader, bool childs)
        {
            return new MaterialDocenteInfo(reader, childs);
        }

        public static MaterialDocenteInfo New(long oid = 0) { return new MaterialDocenteInfo() { Oid = oid }; }

        #endregion

        #region Data Access

        // called to retrieve data from db
        private void DataPortal_Fetch(CriteriaEx criteria)
        {
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
                        string query = RevisionMaterials.SELECT_BY_MATERIAL(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _revisiones = RevisionMaterialList.GetChildList(reader);

                        query = Material_Plans.SELECT_BY_MATERIAL(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _planes = Material_PlanList.GetChildList(reader);

                        query = Material_Alumnos.SELECT_BY_MATERIAL(this.Oid);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _alumnos = Material_AlumnoList.GetChildList(reader);
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
                    string query = RevisionMaterials.SELECT_BY_MATERIAL(this.Oid);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _revisiones = RevisionMaterialList.GetChildList(reader);

                    query = Material_PlanList.SELECT(this);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _planes = Material_PlanList.GetChildList(reader);

                    query = Material_Alumnos.SELECT_BY_MATERIAL(this.Oid);
                    reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _alumnos = Material_AlumnoList.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

        #region SQL

        public static string SELECT(long oid)
        {
            string md = nHManager.Instance.GetSQLTable(typeof(MaterialDocenteRecord));
            string m = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string c = nHManager.Instance.GetSQLTable(typeof(CursoRecord));
            string query;

            query = "SELECT MD.*," +
                    "       (M.\"NUMERO_MODULO\" || ' ' || M.\"TEXTO\") AS \"MODULO\"," +
                    "       C.\"NOMBRE\" AS \"CURSO\"" +
                    " FROM " + md + " AS MD" +
                    " LEFT JOIN " + m + " AS M ON MD.\"OID_MODULO\" = M.\"OID\"" +
                    " LEFT JOIN " + c + " AS C ON MD.\"OID_CURSO\" = C.\"OID\"";

            if (oid > 0) query += " WHERE MD.\"OID\" = " + oid.ToString();

            return query;
        }

        #endregion
	}
}

