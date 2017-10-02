using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Common;

namespace moleQule.Library.Instruction
{
	/// <summary>
	/// ReadOnly Child Business Object with ReadOnly Childs
	/// </summary>
	[Serializable()]
	public class SesionInfo : ReadOnlyBaseEx<SesionInfo>
    {
        #region Attributes

        protected SesionBase _base = new SesionBase();


        #endregion

        #region Properties

        public SesionBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidHorario { get { return _base.Record.OidHorario; } }
        public long OidClaseTeorica { get { return _base.Record.OidClaseTeorica; } }
        public long OidClasePractica { get { return _base.Record.OidClasePractica; } }
        public long OidClaseExtra { get { return _base.Record.OidClaseExtra; } }
        public long OidProfesor { get { return _base.Record.OidProfesor; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public long Grupo { get { return _base.Record.Grupo; } }
        public long Estado { get { return _base.Record.Estado; } }
        public DateTime Hora { get { return _base.Record.Hora; } }
        public bool Forzada { get { return _base.Record.Forzada; } }


        //LINKED
        public virtual EEstado EStatus { get { return _base.EStatus; } }
        public virtual string StatusLabel { get { return _base.StatusLabel; } }


        #endregion

        #region Business Methods

        public void CopyFrom(Sesion source) { _base.CopyValues(source); }

        public SesionPrint GetPrintObject(ClaseTeoricaList teoricas, ClasePracticaList practicas,
            ClaseExtraList extras, string clases, long grupo, bool print_alumno)
        {
            //HorarioInfo horario = HorarioInfo.Get(this.OidHorario);
            InstructorInfo instructor = InstructorInfo.Get(this.OidProfesor, true);
            return SesionPrint.New(this, instructor, teoricas, practicas, extras, clases, grupo, print_alumno);
        }

        #endregion		

        #region Factory Methods

        protected SesionInfo() { /* require use of factory methods */ }

        private SesionInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }        

		internal SesionInfo(Sesion source, bool copy_childs)
		{
            _base.CopyValues(source);

		}
        
        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static SesionInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static SesionInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = Sesion.GetCriteria(Sesion.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            SesionInfo obj = DataPortal.Fetch<SesionInfo>(criteria);
            Sesion.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static SesionInfo Get(IDataReader reader, bool childs)
        {
            return new SesionInfo(reader, childs);
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
                    IDataReader reader = Sesion.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);
                    
                }
                else
                {
                    _base.Record.CopyValues((SesionRecord)(criteria.UniqueResult()));
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

