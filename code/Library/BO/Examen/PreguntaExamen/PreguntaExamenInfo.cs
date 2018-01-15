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
    public class PreguntaExamenInfo : ReadOnlyBaseEx<PreguntaExamenInfo>
    {

        #region Business Methods

        protected PreguntaExamenBase _base = new PreguntaExamenBase();

        protected RespuestaExamenList _respuestas = null;


        #endregion

        #region Properties

        public PreguntaExamenBase Base { get { return _base; } }

        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidExamen { get { return _base.Record.OidExamen; } }
        public long OidModulo { get { return _base.Record.OidModulo; } }
        public long OidTema { get { return _base.Record.OidTema; } }
        public long OidPregunta { get { return _base.Record.OidPregunta; } }
        public long Nivel { get { return _base.Record.Nivel; } }
        public DateTime FechaAlta { get { return _base.Record.FechaAlta; } }
        public string Texto { get { return _base.Record.Texto; } }
        public string Tipo { get { return _base.Record.Tipo; } }
        public string Imagen { get { return _base.Record.Imagen; } }
        public string ModeloRespuesta { get { return _base.Record.ModeloRespuesta; } }
        public string Idioma { get { return _base.Record.Idioma; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public bool ImagenGrande { get { return _base.Record.ImagenGrande; } }
        public long Orden { get { return _base.Record.Orden; } }
        public long OidPreguntaOld { get { return _base.Record.OidPreguntaOld; } }
        public bool Anulada { get { return _base.Record.Anulada; } }

        public virtual RespuestaExamenList RespuestaExamenes { get { return _respuestas; } }

        //NO ENLAZADOS
        public virtual string ImagenWithPath { get { return ModuleController.FOTOS_PREGUNTAS_EXAMEN_PATH + OidExamen.ToString("00000") + "\\" + Imagen; } }
        public virtual string ModeloRespuestaPath { get { return ModuleController.MODELO_PREGUNTAS_EXAMEN_PATH + OidExamen.ToString("00000") + "\\" + ModeloRespuesta; } }
        public virtual string Submodulo { get { return _base.Submodulo; } set { _base.Submodulo = value; } }
        public virtual string NPregunta { get { return _base.NPregunta; } set { _base.NPregunta = value; } }
        public virtual string Tema { get { return _base.Tema; } set { _base.Tema = value; } }



        #endregion

        #region Business Methods

        public void CopyFrom(PreguntaExamen source) { _base.CopyValues(source); }

        /// <summary>
        /// Copia los atributos del objeto
        /// </summary>
        /// <param name="source">Objeto origen</param>
        public virtual void CopyValues(PreguntaInfo source)
        {
            if (source == null) return;

            _base.Record.OidModulo = source.OidModulo;
            _base.Record.OidTema = source.OidTema;
            _base.Record.OidPregunta = source.Oid;
            _base.Record.Nivel = source.Nivel;
            _base.Record.FechaAlta = source.FechaAlta;
            _base.Record.Texto = source.Texto;
            _base.Record.Tipo = source.Tipo;
            _base.Record.Imagen = string.Empty;
            _base.Record.ModeloRespuesta = source.ModeloRespuesta;
            _base.Record.Idioma = source.Idioma;
            //if (source.Idioma == "Español") _idioma = "Espanol";
            //else
            //{
            //    if (source.Idioma == "Inglés") _idioma = "Ingles";
            //    else _idioma = source.Idioma;
            //}
            _base.Record.Observaciones = source.Observaciones;

            _base.Submodulo = source.Modulo;
            _base.NPregunta = source.Codigo;
            _base.Tema = source.Tema;
        }


        public PreguntaExamenPrint GetPrintObject(Preguntas preguntas)
        {
            return PreguntaExamenPrint.New(this, preguntas);
        }

        public PreguntaExamenPrint GetPrintObject(PreguntaList preguntas)
        {
            return PreguntaExamenPrint.New(this, preguntas);
        }

        #endregion

        #region Factory Methods

        protected PreguntaExamenInfo() { /* require use of factory methods */ }

        private PreguntaExamenInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal PreguntaExamenInfo(PreguntaExamen item, bool copy_childs)
        {
            CopyFrom(item);

            if (copy_childs)
            {
                _respuestas = (item.RespuestaExamens != null) ? RespuestaExamenList.GetChildList(item.RespuestaExamens) : null;
            }
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static PreguntaExamenInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static PreguntaExamenInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = PreguntaExamen.GetCriteria(PreguntaExamen.OpenSession());
            criteria.Childs = childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = PreguntaExamenInfo.SELECT(oid);
            else
                criteria.AddOidSearch(oid);

            PreguntaExamenInfo obj = DataPortal.Fetch<PreguntaExamenInfo>(criteria);
            PreguntaExamen.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static PreguntaExamenInfo Get(IDataReader reader, bool childs)
        {
            return new PreguntaExamenInfo(reader, childs);
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
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(criteria.Query, Session());

                    if (reader.Read())
                        _base.CopyValues(reader);

                    if (Childs)
                    {
                        string query = string.Empty;

                        query = RespuestaExamenList.SELECT_BY_PREGUNTA_EXAMEN(this.Oid, this.OidExamen);
                        reader = nHManager.Instance.SQLNativeSelect(query, Session());
                        _respuestas = RespuestaExamenList.GetChildList(reader);
                    }
                }
                else
                {
                    _base.Record.CopyValues((PreguntaExamenRecord)(criteria.UniqueResult()));

                    if (Childs)
                    {
                        criteria = RespuestaExamen.GetCriteria(criteria.Session);
                        criteria.AddEq("OidPregunta", this.Oid);
                        _respuestas = RespuestaExamenList.GetChildList(criteria.List<RespuestaExamen>());
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
                    
                    query = RespuestaExamenList.SELECT_BY_PREGUNTA_EXAMEN(this.Oid, this.OidExamen);
                    IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
                    _respuestas = RespuestaExamenList.GetChildList(reader);
                }
            }
            catch (Exception ex)
            {
                iQExceptionHandler.TreatException(ex);
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Retrieve the complete list from db
        /// </summary>
        /// <returns>PreguntaList</returns>
        public void FormatImagen(string imagen)
        {
            //cambiar el nombre de la imagen
            string query = PreguntaExamenList.UPDATE_IMAGEN(this.Oid, imagen);
            CriteriaEx criteria = PreguntaExamen.GetCriteria(PreguntaExamen.OpenSession());
            nHManager.Instance.SQLNativeExecute(query, Session());
            CloseSession(criteria.SessionCode);
        }

        #endregion

        #region SQL

        public static string SELECT(long oid) { return PreguntaExamen.SELECT(new QueryConditions() { Oid = oid }, false); }

        #endregion

    }
}

