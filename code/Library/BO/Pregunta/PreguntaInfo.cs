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
	public class PreguntaInfo : ReadOnlyBaseEx<PreguntaInfo>
	{

        #region Attributes

        protected PreguntaBase _base = new PreguntaBase();

        //NO ENLAZADOS
        protected string _modulo;
        protected string _submodulo;
        protected string _tema;

        private RespuestaList _respuestas = null;
        private HistoriaList _historias = null;

        #endregion

        #region Properties

        public PreguntaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidModulo { get { return _base.Record.OidModulo; } }
        public long OidTema { get { return _base.Record.OidTema; } }
        public long Nivel { get { return _base.Record.Nivel; } }
        public DateTime FechaAlta { get { return _base.Record.FechaAlta; } }
        public DateTime FechaPublicacion { get { return _base.Record.FechaPublicacion; } }
        public string Texto { get { return _base.Record.Texto; } }
        public string Tipo { get { return _base.Record.Tipo; } }
        public string Imagen { get { return _base.Record.Imagen; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public DateTime FechaDisponibilidad { get { return _base.Record.FechaDisponibilidad; } }
        public string Idioma { get { return _base.Record.Idioma; } }
        public bool Activa { get { return _base.Record.Activa; } }
        public bool Revisada { get { return _base.Record.Revisada; } }
        public bool ImagenGrande { get { return _base.Record.ImagenGrande; } }
        public bool Bloqueada { get { return _base.Record.Bloqueada; } }
        public long OidSubmodulo { get { return _base.Record.OidSubmodulo; } }
        public long OidOld { get { return _base.Record.OidOld; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public bool Reservada { get { return _base.Record.Reservada; } }

		public virtual RespuestaList Respuestas { get { return _respuestas; } }
        public virtual HistoriaList Historias { get { return _historias; } }

        // NO ENLAZADAS
        public bool Disponible { get { return _base.Record.FechaPublicacion <= DateTime.Today; } }
        public string ImagenWithPath { get { return ModuleController.FOTOS_PREGUNTAS_PATH + Imagen; } }
        public string Modulo { get { return _base.Modulo; } }
        public string Submodulo { get { return _base.Submodulo; } }
        public string Tema { get { return _base.Tema; } }
        public DateTime FechaModificacion { get { return _base.FechaModificacion; } }

        #endregion

        #region Business Methods

        public void CopyFrom(Pregunta source) { _base.CopyValues(source); }

        public void CopyFrom(PreguntaExamenInfo source)
        {
            Oid = source.OidPregunta;
            _base.Record.OidModulo = source.OidModulo;
            _base.Record.OidTema = source.OidTema;
            _base.Record.Nivel = source.Nivel;
            _base.Record.FechaAlta = source.FechaAlta;
            _base.Record.FechaPublicacion = source.FechaPublicacion;
            _base.Record.Texto = source.Texto;
            _base.Record.Tipo = source.Tipo;
            _base.Record.Imagen = source.Imagen;
            _base.Record.Observaciones = source.Observaciones;
            _base.Record.Idioma = source.Idioma;
            _base.Record.ImagenGrande = source.ImagenGrande;

            _submodulo = source.Submodulo;
            _tema = source.Tema;
        }

		#endregion

		#region Factory Methods

		protected PreguntaInfo() { /* require use of factory methods */ }

		private PreguntaInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}

		internal PreguntaInfo(Pregunta item, bool copy_childs)
		{
            _base.CopyValues(item);

            if (copy_childs)
            {
                _respuestas = (item.Respuestas != null) ? RespuestaList.GetChildList(item.Respuestas) : null;
                _historias = (item.Historias != null) ? HistoriaList.GetChildList(item.Historias) : null;
            }
		}

        internal PreguntaInfo(PreguntaExamenInfo item)
        {
            CopyFrom(item);
        }

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static PreguntaInfo Get(long oid) { return Get(oid, false); }

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static PreguntaInfo Get(long oid, bool get_childs)
		{
			CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            criteria.Childs = get_childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = PreguntaInfo.SELECT(oid);
            else
                criteria.AddOidSearch(oid);            			
			
            PreguntaInfo obj = DataPortal.Fetch<PreguntaInfo>(criteria);
			Pregunta.CloseSession(criteria.SessionCode);
			return obj;
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static PreguntaInfo Get(IDataReader reader, bool childs)
		{
			return new PreguntaInfo(reader, childs);
        }
     
        public PreguntaPrint GetPrintObject(int orden)
        {
            PreguntaPrint itemPrint = PreguntaPrint.New(this, orden);
            return itemPrint;
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
						string query = RespuestaList.SELECT_BY_PREGUNTA(Oid);
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
						_respuestas = RespuestaList.GetChildList(reader);

						query = HistoriaList.SELECT_BY_PREGUNTA(Oid);
						reader = nHManager.Instance.SQLNativeSelect(query, Session());
						_historias = HistoriaList.GetChildList(reader);
					}
				}
				else
				{
                    _base.Record.CopyValues((PreguntaRecord)(criteria.UniqueResult()));

					if (Childs)
					{
						criteria = Respuesta.GetCriteria(criteria.Session);
						criteria.AddEq("OidPregunta", this.Oid);
						_respuestas = RespuestaList.GetChildList(criteria.List<Respuesta>());

						criteria = Historia.GetCriteria(criteria.Session);
						criteria.AddEq("OidPregunta", this.Oid);
						_historias = HistoriaList.GetChildList(criteria.List<Historia>());
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

					query = RespuestaList.SELECT_BY_PREGUNTA(Oid);
					IDataReader reader = nHManager.Instance.SQLNativeSelect(query, Session());
					_respuestas = RespuestaList.GetChildList(reader);

					query = HistoriaList.SELECT_BY_PREGUNTA(Oid);
					reader = nHManager.Instance.SQLNativeSelect(query, Session());
					_historias = HistoriaList.GetChildList(reader);
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
            string query = PreguntaList.UPDATE_IMAGEN(this.Oid, imagen);
            CriteriaEx criteria = Pregunta.GetCriteria(Pregunta.OpenSession());
            nHManager.Instance.SQLNativeExecute(query, Session());
            CloseSession(criteria.SessionCode);
        }

        #endregion

        #region SQL

        public static string SELECT(long oid) { return Pregunta.SELECT(oid, false, string.Empty); }

        #endregion

    }
}

