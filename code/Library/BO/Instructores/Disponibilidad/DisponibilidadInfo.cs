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
    public class DisponibilidadInfo : ReadOnlyBaseEx<DisponibilidadInfo>
    {
        #region Attributes

        protected DisponibilidadBase _base = new DisponibilidadBase();


        #endregion

        #region Properties

        public DisponibilidadBase Base { get { return _base; } }


        public override long Oid { get { return _base.Record.Oid; } set { _base.Record.Oid = value; } }
        public long OidInstructor { get { return _base.Record.OidInstructor; } }
        public DateTime FechaInicio { get { return _base.Record.FechaInicio; } }
        public DateTime FechaFin { get { return _base.Record.FechaFin; } }
        public bool L1 { get { return _base.Record.L1; } }
        public bool L2 { get { return _base.Record.L2; } }
        public bool M1 { get { return _base.Record.M1; } }
        public bool M2 { get { return _base.Record.M2; } }
        public bool X1 { get { return _base.Record.X1; } }
        public bool X2 { get { return _base.Record.X2; } }
        public bool J1 { get { return _base.Record.J1; } }
        public bool J2 { get { return _base.Record.J2; } }
        public bool V1 { get { return _base.Record.V1; } }
        public bool V2 { get { return _base.Record.V2; } }
        public string Observaciones { get { return _base.Record.Observaciones; } }
        public long ClasesSemanales { get { return _base.Record.ClasesSemanales; } }
        public bool L3 { get { return _base.Record.L3; } }
        public bool L4 { get { return _base.Record.L4; } }
        public bool L5 { get { return _base.Record.L5; } }
        public bool L6 { get { return _base.Record.L6; } }
        public bool L7 { get { return _base.Record.L7; } }
        public bool L8 { get { return _base.Record.L8; } }
        public bool L9 { get { return _base.Record.L9; } }
        public bool L10 { get { return _base.Record.L10; } }
        public bool M3 { get { return _base.Record.M3; } }
        public bool M4 { get { return _base.Record.M4; } }
        public bool M5 { get { return _base.Record.M5; } }
        public bool M6 { get { return _base.Record.M6; } }
        public bool M7 { get { return _base.Record.M7; } }
        public bool M8 { get { return _base.Record.M8; } }
        public bool M9 { get { return _base.Record.M9; } }
        public bool M10 { get { return _base.Record.M10; } }
        public bool X3 { get { return _base.Record.X3; } }
        public bool X4 { get { return _base.Record.X4; } }
        public bool X5 { get { return _base.Record.X5; } }
        public bool X6 { get { return _base.Record.X6; } }
        public bool X7 { get { return _base.Record.X7; } }
        public bool X8 { get { return _base.Record.X8; } }
        public bool X9 { get { return _base.Record.X9; } }
        public bool X10 { get { return _base.Record.X10; } }
        public bool J3 { get { return _base.Record.J3; } }
        public bool J4 { get { return _base.Record.J4; } }
        public bool J5 { get { return _base.Record.J5; } }
        public bool J6 { get { return _base.Record.J6; } }
        public bool J7 { get { return _base.Record.J7; } }
        public bool J8 { get { return _base.Record.J8; } }
        public bool J9 { get { return _base.Record.J9; } }
        public bool J10 { get { return _base.Record.J10; } }
        public bool V3 { get { return _base.Record.V3; } }
        public bool V4 { get { return _base.Record.V4; } }
        public bool V5 { get { return _base.Record.V5; } }
        public bool V6 { get { return _base.Record.V6; } }
        public bool V7 { get { return _base.Record.V7; } }
        public bool V8 { get { return _base.Record.V8; } }
        public bool V9 { get { return _base.Record.V9; } }
        public bool V10 { get { return _base.Record.V10; } }
        public bool S1 { get { return _base.Record.S1; } }
        public bool S2 { get { return _base.Record.S2; } }
        public bool S3 { get { return _base.Record.S3; } }
        public bool S4 { get { return _base.Record.S4; } }
        public bool L0 { get { return _base.Record.L0; } }
        public bool M0 { get { return _base.Record.M0; } }
        public bool X0 { get { return _base.Record.X0; } }
        public bool J0 { get { return _base.Record.J0; } }
        public bool V0 { get { return _base.Record.V0; } }
        public bool S0 { get { return _base.Record.S0; } }
        public bool L11 { get { return _base.Record.L11; } }
        public bool L12 { get { return _base.Record.L12; } }
        public bool M11 { get { return _base.Record.M11; } }
        public bool M12 { get { return _base.Record.M12; } }
        public bool X11 { get { return _base.Record.X11; } }
        public bool X12 { get { return _base.Record.X12; } }
        public bool J11 { get { return _base.Record.J11; } }
        public bool J12 { get { return _base.Record.J12; } }
        public bool V11 { get { return _base.Record.V11; } }
        public bool V12 { get { return _base.Record.V12; } }
        public bool NdL { get { return _base.Record.NdL; } }
        public bool NdM { get { return _base.Record.NdM; } }
        public bool NdX { get { return _base.Record.NdX; } }
        public bool NdJ { get { return _base.Record.NdJ; } }
        public bool NdV { get { return _base.Record.NdV; } }
        public bool NdS { get { return _base.Record.NdS; } }
        public bool L8AM { get { return _base.Record.L8AM; } }
        public bool M8AM { get { return _base.Record.M8AM; } }
        public bool X8AM { get { return _base.Record.X8AM; } }
        public bool J8AM { get { return _base.Record.J8AM; } }
        public bool V8AM { get { return _base.Record.V8AM; } }

        public List<bool> Semana { get { return _base.Semana; } set { _base.Semana = value; } }

        #endregion

        #region Business Methods

        public void CopyFrom(Disponibilidad source) { _base.CopyValues(source); }

        #endregion		

        #region Factory Methods

        protected DisponibilidadInfo() { /* require use of factory methods */ }

        private DisponibilidadInfo(IDataReader reader, bool childs)
        {
            Childs = childs;
            Fetch(reader);
        }
        internal DisponibilidadInfo(Disponibilidad source)
        {
            _base.CopyValues(source);
        }


        /// <summary>
        /// Copia los datos al objeto desde un IDataReader 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static DisponibilidadInfo Get(IDataReader reader, bool childs)
        {
            return new DisponibilidadInfo(reader, childs);
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

