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
    public class SesionCronogramaInfo : ReadOnlyBaseEx<SesionCronogramaInfo>
    {

        #region Business Methods

        protected string _submodulo = string.Empty;
        protected string _titulo = string.Empty;
        protected string _alias = string.Empty;
        protected ETipoClase _tipo;
        private long _orden_primario = 0;
        private long _orden_secundario = 0;
        private long _orden_terciario = 0;
        private long _incompatible;
        private long _grupo = 3;

        protected SesionCronogramaBase _base = new SesionCronogramaBase();

        #endregion

        #region Properties

        public SesionCronogramaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidCronograma { get { return _base.Record.OidCronograma; } }
        public long OidClaseTeorica { get { return _base.Record.OidClaseTeorica; } }
        public long OidClasePractica { get { return _base.Record.OidClasePractica; } }
        public long Semana { get { return _base.Record.Semana; } }
        public long Dia { get { return _base.Record.Dia; } }
        public long Turno { get { return _base.Record.Turno; } }
        public long Numero { get { return _base.Record.Numero; } }
        public string Texto { get { return _base.Record.Texto; } }
        public DateTime Fecha { get { return _base.Record.Fecha; } }
        public DateTime Hora { get { return _base.Record.Hora; } }

        public string Clase { get { return _base.Clase; } }
        public string Modulo { get { return _base.Modulo; } }
        public string Duracion { get { return _base.Duracion; } }
        public virtual string Submodulo { get { return _submodulo; } set { _submodulo = value; } }
        public virtual string Titulo { get { return _titulo; } set { _titulo = value; } }
        public virtual string Alias { get { return _alias; } set { _alias = value; } }
        public virtual ETipoClase ETipoClase { get { return _tipo; } set { _tipo = value; } }
        public virtual string Tipo { get { return Library.Instruction.EnumText<ETipoClase>.GetLabel(ETipoClase); } }
        public virtual long OrdenPrimario { get { return _orden_primario; } set { _orden_primario = value; } }
        public virtual long OrdenSecundario { get { return _orden_secundario; } set { _orden_secundario = value; } }
        public virtual long OrdenTerciario { get { return _orden_terciario; } set { _orden_terciario = value; } }
        public virtual long Grupo { get { return _grupo; } set { _grupo = value; } }
        public virtual long Incompatible { get { return _incompatible; } set { _incompatible = value; } }
        public virtual string FechaLabel { get { return _base.Record.Fecha.ToString("dd/MM/yyyy"); } }
        public virtual string HoraLabel { get { return _base.Record.Hora.ToString("HH:mm"); } }

        public SesionCronogramaPrint GetPrintObject(ModuloList modulos, ClaseTeoricaList teoricas, ClasePracticaList practicas)
        {
            return SesionCronogramaPrint.New(this, modulos, teoricas, practicas);
        }
        
        #endregion

        #region Business Methods

        public void CopyFrom(SesionCronograma source) { _base.CopyValues(source); }

        public void CopyValues(SesionCronograma source)
        {
            _base.CopyValues(source);

            _submodulo = source.Submodulo;
            _titulo = source.Titulo != string.Empty ? source.Titulo : source.Modulo + " " + source.Alias;
            _alias = source.Alias;
            _tipo = source.ETipoClase;
            _orden_primario = source.OrdenPrimario;
            _orden_secundario = source.OrdenSecundario;
            _orden_terciario = source.OrdenTerciario;
            _grupo = source.Grupo;
            _incompatible = source.Incompatible;
        }

        #endregion

        #region Factory Methods

        protected SesionCronogramaInfo() { /* require use of factory methods */ }

        private SesionCronogramaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal SesionCronogramaInfo(SesionCronograma item)
        {
            CopyValues(item);

        }


        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static SesionCronogramaInfo Get(long oid)
        {
            return Get(oid, false);
        }

        /// <summary>
        /// Devuelve un ClienteInfo tras consultar la base de datos
        /// </summary>
        /// <param name="oid"></param>
        /// <returns></returns>
        public static SesionCronogramaInfo Get(long oid, bool childs)
        {
            CriteriaEx criteria = SesionCronograma.GetCriteria(SesionCronograma.OpenSession());
            criteria.AddOidSearch(oid);
            criteria.Childs = childs;
            SesionCronogramaInfo obj = DataPortal.Fetch<SesionCronogramaInfo>(criteria);
            SesionCronograma.CloseSession(criteria.SessionCode);
            return obj;
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static SesionCronogramaInfo Get(IDataReader reader, bool childs)
        {
            return new SesionCronogramaInfo(reader, childs);
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

                    IDataReader reader = SesionCronograma.DoSELECT(AppContext.ActiveSchema.Code, Session(), criteria.Oid);

                    if (reader.Read())
                        _base.CopyValues(reader);

                }
                else
                {
                    _base.Record.CopyValues((SesionCronogramaRecord)(criteria.UniqueResult()));

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

