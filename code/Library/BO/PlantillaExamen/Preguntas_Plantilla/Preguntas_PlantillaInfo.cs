using System;
using System.Collections.Generic;
using System.Data;

using moleQule.Library.CslaEx;

using moleQule.Library;

namespace moleQule.Library.Instruction
{

    /// <summary>
    /// ReadOnly Child Business Object
    /// </summary>
    [Serializable()]
    public class Preguntas_PlantillaInfo : ReadOnlyBaseEx<Preguntas_PlantillaInfo>
    {
        #region Attributes

        protected Preguntas_PlantillaBase _base = new Preguntas_PlantillaBase();


        #endregion

        #region Properties

        public Preguntas_PlantillaBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidPlantilla { get { return _base.Record.OidPlantilla; } }
        public long OidSubmodulo { get { return _base.Record.OidSubmodulo; } }
        public long NPreguntas { get { return _base.Record.NPreguntas; } }
        public long OidTema { get { return _base.Record.OidTema; } }



        #endregion

        #region Business Methods

        public void CopyFrom(Preguntas_Plantilla source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected Preguntas_PlantillaInfo() { /* require use of factory methods */ }

        private Preguntas_PlantillaInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }

        internal Preguntas_PlantillaInfo(Preguntas_Plantilla item)
        {
            _base.CopyValues(item);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Preguntas_PlantillaInfo Get(IDataReader reader, bool childs)
        {
            return new Preguntas_PlantillaInfo(reader, childs);
        }

        #endregion

        #region Data Access

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

