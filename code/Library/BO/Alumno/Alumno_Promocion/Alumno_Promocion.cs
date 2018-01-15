using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;

using Csla;
using Csla.Validation;
using moleQule.Library.CslaEx;
using NHibernate;

using moleQule.Library;
using moleQule.Library.Instruction;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class AlumnoPromocionRecord : RecordBase
    {
        #region Attributes

        private long _oid_promocion;
        private long _oid_alumno;

        #endregion

        #region Properties

        public virtual long OidPromocion { get { return _oid_promocion; } set { _oid_promocion = value; } }
        public virtual long OidAlumno { get { return _oid_alumno; } set { _oid_alumno = value; } }

        #endregion

        #region Business Methods

        public AlumnoPromocionRecord() { }

        public virtual void CopyValues(IDataReader source)
        {
            if (source == null) return;

            Oid = Format.DataReader.GetInt64(source, "OID");
            _oid_promocion = Format.DataReader.GetInt64(source, "OID_PROMOCION");
            _oid_alumno = Format.DataReader.GetInt64(source, "OID_ALUMNO");

        }
        public virtual void CopyValues(AlumnoPromocionRecord source)
        {
            if (source == null) return;

            Oid = source.Oid;
            _oid_promocion = source.OidPromocion;
            _oid_alumno = source.OidAlumno;
        }

        #endregion
    }

    [Serializable()]
    public class Alumno_PromocionBase
    {
        #region Attributes

        private AlumnoPromocionRecord _record = new AlumnoPromocionRecord();

        internal string _apellidos = string.Empty;
        internal string _nombre = string.Empty;
        internal string _promocion = string.Empty;
        internal string _dni = string.Empty;

        #endregion

        #region Properties

        public AlumnoPromocionRecord Record { get { return _record; } }

        public virtual string Apellidos { get { return _apellidos; } set {_apellidos = value; }}
        public virtual string Nombre { get { return _nombre; } set {_nombre = value; }}
        public virtual string Promocion { get { return _promocion; } set {_promocion = value; }}
        public virtual string Dni { get { return _dni; } set {_dni = value; }}

        #endregion

        #region Business Methods

        public void CopyValues(IDataReader source)
        {
            if (source == null) return;

            _record.CopyValues(source);

            _apellidos = Format.DataReader.GetString(source, "APELLIDOS");
            _nombre = Format.DataReader.GetString(source, "NOMBRE");
            _promocion = Format.DataReader.GetString(source, "PROMOCION");
            _dni = Format.DataReader.GetString(source, "DNI");
        }
        public void CopyValues(Alumno_Promocion source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);

            _apellidos = source.Apellidos;
            _nombre = source.Nombre;
            _promocion = source.Promocion;
            _dni = source.Dni;
        }
        public void CopyValues(Alumno_PromocionInfo source)
        {
            if (source == null) return;

            _record.CopyValues(source.Base.Record);

            _apellidos = source.Apellidos;
            _nombre = source.Nombre;
            _promocion = source.Promocion;
            _dni = source.Dni;
        }

        #endregion
    }

    /// <summary>
    /// Editable Root Business Object
    /// </summary>	
    [Serializable()]
    public class Alumno_Promocion : BusinessBaseEx<Alumno_Promocion>
    {
        #region Attributes

        protected Alumno_PromocionBase _base = new Alumno_PromocionBase();


        #endregion

        #region Properties

        public Alumno_PromocionBase Base { get { return _base; } }

        public override long Oid
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.Oid;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);
                if (!_base.Record.Oid.Equals(value))
                {
                    _base.Record.Oid = value;
                    //PropertyHasChanged();
                }
            }
        }
        public virtual long OidPromocion
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.OidPromocion;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.OidPromocion.Equals(value))
                {
                    _base.Record.OidPromocion = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual long OidAlumno
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Record.OidAlumno;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (!_base.Record.OidAlumno.Equals(value))
                {
                    _base.Record.OidAlumno = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Apellidos
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Apellidos;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Apellidos.Equals(value))
                {
                    _base.Apellidos = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Nombre
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Nombre;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Nombre.Equals(value))
                {
                    _base.Nombre = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Promocion
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Promocion;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Promocion.Equals(value))
                {
                    _base.Promocion = value;
                    PropertyHasChanged();
                }
            }
        }
        public virtual string Dni
        {
            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            get
            {
                //CanReadProperty(true);
                return _base.Dni;
            }

            [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
            set
            {
                //////CanWriteProperty(true);

                if (value == null) value = string.Empty;

                if (!_base.Dni.Equals(value))
                {
                    _base.Dni = value;
                    PropertyHasChanged();
                }
            }
        }



        #endregion

        #region Business Methods

        public virtual Alumno_Promocion CloneAsNew()
        {
            Alumno_Promocion clon = base.Clone();

            //Se definen el Oid y el Coidgo como nueva entidad
            Random rd = new Random();
            clon.Oid = rd.Next();

            clon.SessionCode = Alumno_Promocion.OpenSession();
            Alumno_Promocion.BeginTransaction(clon.SessionCode);

            clon.MarkNew();

            return clon;
        }

        protected virtual void CopyFrom(Alumno_PromocionInfo source)
        {
            if (source == null) return;

            Oid = source.Oid;
            OidPromocion = source.OidPromocion;
            OidAlumno = source.OidAlumno;

            Apellidos = source.Apellidos;
            Nombre = source.Nombre;
            Promocion = source.Promocion;
            Dni = source.Dni;
        }


        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidAlumno", 1));

            ValidationRules.AddRule(CommonRules.MinValue<long>,
                                    new CommonRules.MinValueRuleArgs<long>("OidPromocion", 1));
        }

        #endregion

        #region Autorization Rules

        public static bool CanAddObject()
        {
            return AutorizationRulesControler.CanAddObject(Resources.ElementosSeguros.ALUMNO);

        }

        public static bool CanGetObject()
        {
            return AutorizationRulesControler.CanGetObject(Resources.ElementosSeguros.ALUMNO);

        }

        public static bool CanDeleteObject()
        {
            return AutorizationRulesControler.CanDeleteObject(Resources.ElementosSeguros.ALUMNO);

        }
        public static bool CanEditObject()
        {
            return AutorizationRulesControler.CanEditObject(Resources.ElementosSeguros.ALUMNO);

        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// NO UTILIZAR DIRECTAMENTE, SE DEBE USAR LA FUNCION NewChild
        /// Debería ser private para CSLA porque la creación requiere el uso de los Factory Methods,
        /// pero debe ser protected por exigencia de NHibernate
        /// y public para que funcionen los DataGridView
        /// </summary>
        public Alumno_Promocion()
        {
            MarkAsChild();
            Random r = new Random();
            Oid = (long)r.Next();
        }

        private Alumno_Promocion(Alumno_Promocion source)
        {
            MarkAsChild();
            Fetch(source);
        }

        private Alumno_Promocion(IDataReader reader)
        {
            MarkAsChild();
            Fetch(reader);
        }

        public static Alumno_Promocion NewChild(Alumno parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Promocion obj = new Alumno_Promocion();
            obj.OidAlumno = parent.Oid;
            return obj;
        }

        public static Alumno_Promocion NewChild(Promocion parent)
        {
            if (!CanAddObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            Alumno_Promocion obj = new Alumno_Promocion();
            obj.OidPromocion = parent.Oid;
            return obj;
        }

        internal static Alumno_Promocion GetChild(Alumno_Promocion source)
        {
            return new Alumno_Promocion(source);
        }

        internal static Alumno_Promocion GetChild(IDataReader reader)
        {
            return new Alumno_Promocion(reader);
        }

        public virtual Alumno_PromocionInfo GetInfo()
        {
            if (!CanGetObject())
                throw new System.Security.SecurityException(
                  moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            return new Alumno_PromocionInfo(this);

        }

        /// <summary>
        /// Borrado aplazado, es posible el undo 
        /// (La función debe ser "no estática")
        /// </summary>
        public override void Delete()
        {
            if (!CanDeleteObject())
                throw new System.Security.SecurityException(
                    moleQule.Library.Resources.Messages.USER_NOT_ALLOWED);

            MarkDeleted();
        }

        /// <summary>
        /// No se debe utilizar esta función para guardar. Hace falta el padre.
        /// Utilizar Insert o Update en sustitución de Save.
        /// </summary>
        /// <returns></returns>
        public override Alumno_Promocion Save()
        {
            throw new iQException(moleQule.Library.Resources.Messages.CHILD_SAVE_NOT_ALLOWED);
        }


        #endregion

        #region Child Data Access

        private void Fetch(Alumno_Promocion source)
        {
            _base.CopyValues(source);
            MarkOld();
        }

        private void Fetch(IDataReader reader)
        {
            _base.CopyValues(reader);
            MarkOld();
        }

        internal void Insert(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAlumno = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidAlumno = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                AlumnoPromocionRecord obj = parent.Session().Get<AlumnoPromocionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Alumno parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<AlumnoPromocionRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }

        internal void Insert(Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPromocion = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                parent.Session().Save(this.Base.Record);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void Update(Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            OidPromocion = parent.Oid;

            try
            {
                ValidationRules.CheckRules();

                if (!IsValid)
                    throw new iQValidationException(moleQule.Library.Resources.Messages.GENERIC_VALIDATION_ERROR);

                AlumnoPromocionRecord obj = parent.Session().Get<AlumnoPromocionRecord>(Oid);
                obj.CopyValues(this.Base.Record);
                parent.Session().Update(obj);
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkOld();
        }

        internal void DeleteSelf(Promocion parent)
        {
            // if we're not dirty then don't update the database
            if (!this.IsDirty) return;

            // if we're new then don't update the database
            if (this.IsNew) return;

            try
            {
                parent.Session().Delete(parent.Session().Get<AlumnoPromocionRecord>(Oid));
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }

            MarkNew();
        }


        #endregion

        #region SQL

        internal static string SELECT_FIELDS()
        {
            string query;

            query = @"SELECT AP.*,
                        A.""APELLIDOS"" AS ""APELLIDOS"",
                        A.""NOMBRE"" AS ""NOMBRE"",
                        A.""ID"" AS ""DNI"",
                        PR.""NOMBRE"" AS ""PROMOCION""";

            return query;
        }

        internal static string JOIN()
        {
            string query;

            string alumno_promocion = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));

            query = "   FROM   " + alumno_promocion + "   AS AP" +
                    "   INNER JOIN " + alumno + " AS A ON A.\"OID\" = AP.\"OID_ALUMNO\"" +
                    "   INNER JOIN " + promocion + " AS PR ON PR.\"OID\" = AP.\"OID_PROMOCION\"";

            return query;
        }

        internal static string WHERE(QueryConditions conditions)
        {
            string query;

            query = "   WHERE TRUE";

            if (conditions.Promocion != null && conditions.Promocion.Oid > 0)
                query += " AND AP.\"OID_PROMOCION\" = " + conditions.Promocion.Oid;

            if (conditions.Alumno != null && conditions.Alumno.Oid > 0)
                query += " AND AP.\"OID_ALUMNO\" = " + conditions.Alumno.Oid;

            return query;
        }

        internal static string SELECT(QueryConditions conditions, bool lockTable)
        {
            string query = string.Empty;

            query = SELECT_FIELDS() +
                    JOIN() +
                    WHERE(conditions);

            if (lockTable) query += " FOR UPDATE OF AP NOWAIT";

            return query;
        }


        public static string SELECT_ALUMNOS_ADMITIDOS(long oid_modulo, DateTime fecha_examen, Dictionary<string, PromocionInfo> promociones)
        {
            bool criterio_nota = ModulePrincipal.GetCriterioPorcentajeMinimoExamenAprobadoSetting();
            bool criterio_faltas = ModulePrincipal.GetCriterioPorcentajeMaximoFaltasModuloSetting();

            long porcentaje_nota = ModulePrincipal.GetPorcentajeMinimoExamenAprobadoSetting();
            long porcentaje_faltas = ModulePrincipal.GetPorcentajeMaximoFaltasModuloSetting();

            string clase_teorica = nHManager.Instance.GetSQLTable(typeof(ClaseTeoricaRecord));
            string plan_estudios = nHManager.Instance.GetSQLTable(typeof(PlanEstudiosRecord));
            string modulo = nHManager.Instance.GetSQLTable(typeof(ModuloRecord));
            string promocion = nHManager.Instance.GetSQLTable(typeof(PromocionRecord));
            string alumno_promocion = nHManager.Instance.GetSQLTable(typeof(AlumnoPromocionRecord));
            string alumno = nHManager.Instance.GetSQLTable(typeof(AlumnoRecord));
            string alumno_examen = nHManager.Instance.GetSQLTable(typeof(AlumnoExamenRecord));
            string examen = nHManager.Instance.GetSQLTable(typeof(ExamenRecord));
            string parte_asistencia = nHManager.Instance.GetSQLTable(typeof(ParteAsistenciaRecord));
            string clase_parte = nHManager.Instance.GetSQLTable(typeof(Clase_ParteRecord));
            string plan_extra = nHManager.Instance.GetSQLTable(typeof(PlanExtraRecord));
            string clase_extra = nHManager.Instance.GetSQLTable(typeof(ClaseExtraRecord));
            string respuesta_alumno_examen = nHManager.Instance.GetSQLTable(typeof(Respuesta_Alumno_ExamenRecord));
            string pregunta_examen = nHManager.Instance.GetSQLTable(typeof(PreguntaExamenRecord));
            string alumno_parte = nHManager.Instance.GetSQLTable(typeof(AlumnoParteRecord));

            string query = "SELECT DISTINCT APR.*, TO_ASCII(A.\"APELLIDOS\", 'LATIN1') AS \"APELLIDOS\", TO_ASCII(A.\"NOMBRE\", 'LATIN1') AS \"NOMBRE\", PR.\"NOMBRE\" AS \"PROMOCION\", A.\"ID\" AS \"DNI\" " +
                        "FROM " + plan_estudios + " AS P " +
                /*"INNER JOIN " + clase_teorica + " AS C ON (C.\"OID_PLAN\" = P.\"OID\") " +
                "INNER JOIN " + modulo + " AS M ON (C.\"OID_MODULO\" = M.\"OID\") " +*/
                        "INNER JOIN " + promocion + " AS PR ON (PR.\"OID_PLAN\" = P.\"OID\") " +
                        "INNER JOIN " + alumno_promocion + " AS APR ON (APR.\"OID_PROMOCION\" = PR.\"OID\") " +
                        "INNER JOIN " + alumno + " AS A ON (A.\"OID\" = APR.\"OID_ALUMNO\") " +
                        "WHERE TRUE "; //M.\"OID\" = " + oid_modulo.ToString() + "  ";

            if (criterio_nota)
            {
                //if (!desarrollo)
                {
                    query += "    AND A.\"OID\" NOT IN ( " +
                            "            SELECT AL.\"OID\" " +
                            "            FROM " + alumno + " AS AL " +
                            "            INNER JOIN " + alumno_examen + " AS AE ON (AE.\"OID_ALUMNO\" = AL.\"OID\") " +
                            "            INNER JOIN " + examen + " AS E ON (E.\"OID\" = AE.\"OID_EXAMEN\") " +
                            "            WHERE E.\"OID_MODULO\" = " + oid_modulo.ToString() + " AND AE.\"PRESENTADO\" = TRUE AND E.\"DESARROLLO\" = 'FALSE' " /*+ desarrollo.ToString() + " AND E.\"OID\" != " + oid_examen.ToString() + " "*/ +
                            "            AND AE.\"CALIFICACION\" >= " + porcentaje_nota.ToString() + " " +
                            ") ";
                }
                //else
                {
                    query += "    AND A.\"OID\" NOT IN ( " +
                            "           SELECT DISTINCT AL.\"OID\" " +
                            "            FROM " + alumno + " AS AL " +
                            "            INNER JOIN " + alumno_examen + " AS AE ON (AE.\"OID_ALUMNO\" = AL.\"OID\") " +
                            "            INNER JOIN " + examen + " AS E ON (E.\"OID\" = AE.\"OID_EXAMEN\")  " +
                            "            INNER JOIN ( " +
                            "                SELECT AE.\"OID\" AS \"OID_ALUMNO_EXAMEN\", COUNT(R.\"CALIFICACION\") AS \"APROBADAS\"  " +
                            "                FROM " + alumno + " AS AL " +
                            "                INNER JOIN " + alumno_examen + " AS AE ON (AE.\"OID_ALUMNO\" = AL.\"OID\") " +
                            "                INNER JOIN " + examen + " AS E ON (E.\"OID\" = AE.\"OID_EXAMEN\") " +
                            "                INNER JOIN " + respuesta_alumno_examen + " AS R ON (R.\"OID_ALUMNO_EXAMEN\" = AE.\"OID\") " +
                            "                WHERE E.\"OID_MODULO\" = " + oid_modulo.ToString() + " AND E.\"DESARROLLO\" = 'TRUE'" /*+ desarrollo.ToString()*/ + " AND R.\"CALIFICACION\" >= " + porcentaje_nota.ToString() + " " +
                            "                GROUP BY AE.\"OID\") AS Q1 ON (Q1.\"OID_ALUMNO_EXAMEN\" = AE.\"OID\") " +
                            "            INNER JOIN ( " +
                            "                SELECT E.\"OID\" AS \"OID_EXAMEN\", COUNT(P.\"OID\") AS \"TOTALES\" " +
                            "                FROM " + examen + " AS E " +
                            "                INNER JOIN " + pregunta_examen + " AS P ON (P.\"OID_EXAMEN\" = E.\"OID\")  " +
                            "                WHERE E.\"OID_MODULO\" = " + oid_modulo.ToString() + " AND E.\"DESARROLLO\" = 'TRUE' " /*+ desarrollo.ToString() + " AND E.\"OID\" != " + oid_examen.ToString() + " "*/ +
                            "                GROUP BY E.\"OID\") AS Q2 ON (Q2.\"OID_EXAMEN\" = E.\"OID\") " +
                            "            WHERE Q1.\"APROBADAS\" = Q2.\"TOTALES\" " +
                            ") ";
                }
            }


            if (criterio_faltas)
                query += "    AND A.\"OID\" NOT IN ( " +
                        "        SELECT AL.\"OID_ALUMNO\" " +
                        "        FROM ( " +
                        "            SELECT CAST(SUM(\"DURACION\") / SUM(QUERY1.\"TOTAL\") * 100 as numeric(10,2)) AS \"PORC\", \"OID_MODULO\", QUERY1.\"OID_ALUMNO\" " +
                        "            FROM(     " +
                        "                SELECT m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", COUNT(cp.\"OID\") AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\"   " +
                        "                FROM        (         " +
                        "                    SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\"  " +
                        "                    FROM " + plan_estudios + " AS PE         " +
                        "                    INNER JOIN " + clase_teorica + " AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")  " +
                        "                    INNER JOIN " + modulo + " AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\")   " +
                        "                    GROUP BY \"PLAN2\", \"MODULO2\"        ) AS QUERY2, " + alumno_parte + " as ap   " +
                        "                INNER JOIN " + alumno + " as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")      " +
                        "                INNER JOIN " + parte_asistencia + " as p ON (p.\"OID\" = ap.\"OID_PARTE\")      " +
                        "                INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")   " +
                        "                INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\")      " +
                        "                INNER JOIN " + plan_estudios + " as pl ON (pl.\"OID\" = pr.\"OID_PLAN\")      " +
                        "                INNER JOIN " + clase_parte + " as cp ON (p.\"OID\" = cp.\"OID_PARTE\")      " +
                        "                INNER JOIN " + clase_teorica + " as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")      " +
                        "                INNER JOIN " + modulo + " as m ON (m.\"OID\" = ct.\"OID_MODULO\")      " +
                        "                WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 1         AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\"    " +
                        /*"                GROUP BY \"TOTAL\", m.\"OID\", a.\"OID\"     " +
                        "                UNION     " +
                        "                SELECT m.\"OID\" AS \"OID_MODULO\", a.\"OID\" AS \"OID_ALUMNO\", COUNT(cp.\"OID\") AS \"DURACION\", QUERY2.\"TOTAL\" AS \"TOTAL\"     " +
                        "                FROM        (         " +
                        "                    SELECT PE.\"OID\" AS \"PLAN2\", MOD.\"TEXTO\" AS \"MODULO2\", COUNT(C.\"OID\") AS \"TOTAL\"     " +
                        "                    FROM " + plan_extra + " AS PE         " +
                        "                    INNER JOIN " + clase_extra + " AS C ON ( C.\"OID_PLAN\" = PE.\"OID\")   " +
                        "                    INNER JOIN " + modulo + " AS MOD ON ( C.\"OID_MODULO\" = MOD.\"OID\")   " +
                        "                    GROUP BY \"PLAN2\", \"MODULO2\"        ) AS QUERY2, \"0001\".\"Alumno_Parte\" as ap     " +
                        "                INNER JOIN " + alumno + " as a ON (a.\"OID\" = ap.\"OID_ALUMNO\")      " +
                        "                INNER JOIN " + parte_asistencia + " as p ON (p.\"OID\" = ap.\"OID_PARTE\")   " +
                        "                INNER JOIN " + alumno_promocion + " as apromo ON (apromo.\"OID_ALUMNO\" = a.\"OID\")   " +
                        "                INNER JOIN " + promocion + " as pr ON (pr.\"OID\" = apromo.\"OID_PROMOCION\")      " +
                        "                INNER JOIN " + plan_extra + " as pl ON (pl.\"OID\" = pr.\"OID_PLAN_EXTRA\")      " +
                        "                INNER JOIN " + clase_parte + " as cp ON (p.\"OID\" = cp.\"OID_PARTE\")      " +
                        "                INNER JOIN " + clase_extra + " as ct ON  (ct.\"OID\" = cp.\"OID_CLASE\")      " +
                        "                INNER JOIN " + modulo + " as m ON (m.\"OID\" = ct.\"OID_MODULO\")      " +
                        "                WHERE ap.\"FALTA\" = 'true' AND ap.\"RECUPERADA\" = 'false' AND cp.\"TIPO\" = 3         AND \"PLAN2\" = pl.\"OID\" AND \"MODULO2\" = m.\"TEXTO\"    " +
                        */"                GROUP BY \"TOTAL\", m.\"OID\", a.\"OID\"    ) AS QUERY1 " +
                        "            WHERE \"OID_MODULO\" = " + oid_modulo.ToString() + " " +
                        "            GROUP BY \"OID_MODULO\", QUERY1.\"OID_ALUMNO\")AS AL " +
                        "      WHERE AL.\"PORC\" > " + porcentaje_faltas.ToString() + " " +
                        ") ";

            query += @" AND A.""OID"" NOT IN (
                            SELECT ""OID_ALUMNO""
                            FROM (
	                            SELECT  ""OID_ALUMNO"",
		                            COALESCE(	(SELECT DISTINCT xi.""FECHA_EXAMEN""
				                            FROM    (	SELECT AE.""OID"", AE.""OID_ALUMNO"", EX.""FECHA_EXAMEN""
						                            FROM " + alumno_examen + @" AS AE
						                            INNER JOIN " + examen + @" AS EX ON AE.""OID_EXAMEN"" = EX.""OID""
						                            WHERE AE.""PRESENTADO"" = 'TRUE' AND EX.""OID_MODULO"" = " + oid_modulo.ToString() + @" AND EX.""FECHA_EXAMEN"" > '2012-08-31') xi
				                            WHERE   xi.""OID_ALUMNO"" = xo.""OID_ALUMNO""
				                            ORDER BY ""FECHA_EXAMEN"" DESC
				                            OFFSET 0 LIMIT 1), '9999-12-31') AS ""FECHA1"",
		                            COALESCE(
				                            (SELECT DISTINCT xi.""FECHA_EXAMEN""
				                            FROM    (	SELECT AE.""OID"", AE.""OID_ALUMNO"", EX.""FECHA_EXAMEN""
						                            FROM " + alumno_examen + @" AS AE
						                            INNER JOIN " + examen + @" AS EX ON AE.""OID_EXAMEN"" = EX.""OID""
						                            WHERE AE.""PRESENTADO"" = 'TRUE' AND EX.""OID_MODULO"" = " + oid_modulo.ToString() + @" AND EX.""FECHA_EXAMEN"" > '2012-08-31') xi
				                            WHERE   xi.""OID_ALUMNO"" = xo.""OID_ALUMNO""
				                            ORDER BY ""FECHA_EXAMEN"" DESC
				                            OFFSET 1 LIMIT 1), '9999-12-31') AS ""FECHA2"",
		                            COALESCE(
				                            (SELECT DISTINCT xi.""FECHA_EXAMEN""
				                            FROM    (	SELECT AE.""OID"", AE.""OID_ALUMNO"", EX.""FECHA_EXAMEN""
						                            FROM " + alumno_examen + @" AS AE
						                            INNER JOIN " + examen + @" AS EX ON AE.""OID_EXAMEN"" = EX.""OID""
						                            WHERE AE.""PRESENTADO"" = 'TRUE' AND EX.""OID_MODULO"" = " + oid_modulo.ToString() + @" AND EX.""FECHA_EXAMEN"" > '2012-08-31') xi
				                            WHERE   xi.""OID_ALUMNO"" = xo.""OID_ALUMNO""
				                            ORDER BY ""FECHA_EXAMEN"" DESC
				                            OFFSET 2 LIMIT 1), '9999-12-31') AS ""FECHA3""
	                            FROM    (	SELECT  DISTINCT ""OID_ALUMNO""
			                            FROM    (	SELECT AE.""OID"", AE.""OID_ALUMNO"", EX.""FECHA_EXAMEN""
					                            FROM " + alumno_examen + @" AS AE
					                            INNER JOIN " + examen + @" AS EX ON AE.""OID_EXAMEN"" = EX.""OID""
					                            WHERE AE.""PRESENTADO"" = 'TRUE' AND EX.""OID_MODULO"" = " + oid_modulo.ToString() + @" AND EX.""FECHA_EXAMEN"" > '2012-08-31') AS XM) xo
                            ) AS Q
                            WHERE ""FECHA1"" != '9999-12-31' AND ""FECHA2"" != '9999-12-31' AND ""FECHA3"" != '9999-12-31'
	                            AND (date '" + fecha_examen.ToString("yyyy-MM-dd") + @"' - interval '1 year' <= ""FECHA1""
		                            OR ""FECHA1"" - interval '1 year' <= ""FECHA2""
		                            OR ""FECHA2"" - interval '1 year' <= ""FECHA3""))";

            if (promociones != null && promociones.Count > 0)
            {
                string subquery = string.Empty;
                foreach (KeyValuePair<string, PromocionInfo> item in promociones)
                    subquery += item.Value.Oid.ToString() + ", ";
                
                query += " AND PR.\"OID\" IN (" + subquery.Substring(0, subquery.Length - 2) + ") ";

            }
            query += "ORDER BY \"APELLIDOS\", \"NOMBRE\", \"PROMOCION\";";

            return query;
        }


        #endregion

    }
}

