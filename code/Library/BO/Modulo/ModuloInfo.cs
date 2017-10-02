using System;
using System.Collections.Generic;
using System.Data;

using Csla;
using moleQule.Library.CslaEx;

using moleQule.Library;
using moleQule.Library.Instruction;
using moleQule.Library.Hipatia;

namespace moleQule.Library.Instruction
{

	/// <summary>
	/// ReadOnly Root Business Object with ReadOnly Childs
    /// </summary>
	[Serializable()]
    public class ModuloInfo : ReadOnlyBaseEx<ModuloInfo>, IAgenteHipatia
    {
        #region IAgenteHipatia

        public string NombreHipatia { get { return NumeroModulo + " " + Texto; } }
        public string IDHipatia { get { return Codigo; } }
        public string ObservacionesHipatia { get { return string.Empty; } }
        public Type TipoEntidad { get { return typeof(Modulo); } }

        #endregion

        #region Attributes

        protected ModuloBase _base = new ModuloBase();

        //private PreguntaList _preguntas = null;
        //private PreguntaExamenList _p_examenes = null;
        private SubmoduloList _submodulos = null;
        //private ExamenList _examenes = null;
        private Material_PlanList _materiales = null;
        //private PlantillaExamenList _plantillas = null;

        #endregion

        #region Properties

        public ModuloBase Base { get { return _base; } }

        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public string Codigo { get { return _base.Record.Codigo; } }
        public string Texto { get { return _base.Record.Texto; } }
        public long Numero { get { return _base.Record.Numero; } }
        public long Serial { get { return _base.Record.Serial; } }
        public string Alias { get { return _base.Record.Alias; } }
        public string NumeroModulo { get { return _base.Record.NumeroModulo; } }
        public string NumeroOrden { get { return _base.Record.NumeroOrden; } }

        //public virtual PreguntaList Preguntas { get { return _preguntas; } }
        //public virtual PreguntaExamenList PExamenes { get { return _p_examenes; } }
        public virtual SubmoduloList Submodulos { get { return _submodulos; } }
        //public virtual ExamenList Examenes { get { return _examenes; } } 
        public virtual Material_PlanList Materiales { get { return _materiales;} }
        //public virtual PlantillaExamenList Plantillas { get { return _plantillas; } }

        #endregion

        #region Business Methods

        public void CopyFrom(Modulo source)
        {
            _base.CopyValues(source);
        }

        #endregion

		#region Factory Methods
		 
	 	private ModuloInfo() { /* require use of factory methods */ }

		private ModuloInfo(IDataReader reader, bool childs)
		{
			Childs = childs;
			Fetch(reader);
		}
		
		internal ModuloInfo(Modulo item, bool copy_childs)
		{
            _base.CopyValues(item);

            if (copy_childs)
            {
                //_p_examenes = (item.PExamenes != null) ? PreguntaExamenList.GetChildList(item.PExamenes) : null;
                _submodulos = (item.Submodulos != null) ? SubmoduloList.GetChildList(item.Submodulos) : null;
                //_examenes = (item.Examenes != null) ? ExamenList.GetChildList(item.Examenes) : null;
                _materiales = (item.Materiales != null) ? Material_PlanList.GetChildList(item.Materiales) : null;
                //_plantillas = (item.Plantillas != null) ? PlantillaExamenList.GetChildList(item.Plantillas) : null;
            }
		}

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static ModuloInfo Get(long oid) { return Get(oid, false); }

		/// <summary>
		/// Devuelve un ClienteInfo tras consultar la base de datos
		/// </summary>
		/// <param name="oid"></param>
		/// <returns></returns>
		public static ModuloInfo Get(long oid, bool childs)
		{
			CriteriaEx criteria = Modulo.GetCriteria(Modulo.OpenSession());
			criteria.Childs = childs;

            if (nHManager.Instance.UseDirectSQL)
                criteria.Query = ModuloInfo.SELECT(typeof(ModuloRecord), oid);
            else
                criteria.AddOidSearch(oid);  

            ModuloInfo obj = DataPortal.Fetch<ModuloInfo>(criteria);
			Modulo.CloseSession(criteria.SessionCode);
			return obj;
		}

		/// <summary>
		/// Copia los datos al objeto desde un IDataReader 
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static ModuloInfo Get(IDataReader reader, bool childs)
		{
   			return new ModuloInfo(reader, childs);
		}

        public static ModuloInfo New(long oid = 0) { return new ModuloInfo() { Oid = oid }; }
	
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

                        //query = ExamenList.SELECT(typeof(ExamenRecord), "OidModulo", this.Oid);
                        //reader = nHMng.SQLNativeSelect(query, Session());
                        //_examenes = ExamenList.GetChildList(reader);

                        query = Material_PlanList.SELECT(this);
                        reader = nHMng.SQLNativeSelect(query, Session());
                        _materiales = Material_PlanList.GetChildList(reader);

                        //query = PlantillaExamenList.SELECT(typeof(PlantillaExamenRecord), "OidModulo", this.Oid);
                        //reader = nHMng.SQLNativeSelect(query, Session());
                        //_plantillas = PlantillaExamenList.GetChildList(reader);

                        //query = PreguntaExamenList.SELECT(typeof(PreguntaExamenRecord), "OidModulo", this.Oid);
                        //reader = nHMng.SQLNativeSelect(query, Session());
                        //_p_examenes = PreguntaExamenList.GetChildList(reader, false);

                        query = SubmoduloList.SELECT_BY_MODULO(this.Oid);
                        reader = nHMng.SQLNativeSelect(query, Session());
                        _submodulos = SubmoduloList.GetChildList(reader, Childs);
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
                    IDataReader reader;
                    string query = string.Empty;

                    //query = ExamenList.SELECT(typeof(ExamenRecord), "OidModulo", this.Oid);
                    //reader = nHMng.SQLNativeSelect(query, Session());
                    //_examenes = ExamenList.GetChildList(reader);

                    query = Material_PlanList.SELECT(this);
                    reader = nHMng.SQLNativeSelect(query, Session());
                    _materiales = Material_PlanList.GetChildList(reader);

                    //query = PlantillaExamenList.SELECT(typeof(PlantillaExamenRecord), "OidModulo", this.Oid);
                    //reader = nHMng.SQLNativeSelect(query, Session());
                    //_plantillas = PlantillaExamenList.GetChildList(reader);

                    //query = PreguntaExamenList.SELECT(typeof(PreguntaExamenRecord), "OidModulo", this.Oid);
                    //reader = nHMng.SQLNativeSelect(query, Session());
                    //_p_examenes = PreguntaExamenList.GetChildList(reader, false);

                    query = SubmoduloList.SELECT_BY_MODULO(this.Oid);
                    reader = nHMng.SQLNativeSelect(query, Session());
                    _submodulos = SubmoduloList.GetChildList(reader);
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

