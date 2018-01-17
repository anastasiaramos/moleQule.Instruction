using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class DisponibilidadMap : ClassMapping<DisponibilidadRecord>
	{	
		public DisponibilidadMap()
		{
			Table("`Disponibilidad`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Disponibilidad_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidInstructor, map => { map.Column("`OID_INSTRUCTOR`"); map.Length(32768); });
			Property(x => x.FechaInicio, map => { map.Column("`FECHA_INICIO`"); map.Length(32768); });
            Property(x => x.FechaFin, map => { map.Column("`FECHA_FIN`"); map.Length(32768); });
            Property(x => x.L8AM, map => { map.Column("`L8AM`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.M8AM, map => { map.Column("`M8AM`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.X8AM, map => { map.Column("`X8AM`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.J8AM, map => { map.Column("`J8AM`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.V8AM, map => { map.Column("`V8AM`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L1, map => { map.Column("`L1`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L2, map => { map.Column("`L2`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M1, map => { map.Column("`M1`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M2, map => { map.Column("`M2`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X1, map => { map.Column("`X1`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X2, map => { map.Column("`X2`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J1, map => { map.Column("`J1`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J2, map => { map.Column("`J2`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V1, map => { map.Column("`V1`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V2, map => { map.Column("`V2`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.ClasesSemanales, map => { map.Column("`CLASES_SEMANALES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L3, map => { map.Column("`L3`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L4, map => { map.Column("`L4`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L5, map => { map.Column("`L5`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L6, map => { map.Column("`L6`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L7, map => { map.Column("`L7`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L8, map => { map.Column("`L8`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L9, map => { map.Column("`L9`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L10, map => { map.Column("`L10`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M3, map => { map.Column("`M3`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M4, map => { map.Column("`M4`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M5, map => { map.Column("`M5`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M6, map => { map.Column("`M6`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M7, map => { map.Column("`M7`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M8, map => { map.Column("`M8`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M9, map => { map.Column("`M9`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M10, map => { map.Column("`M10`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X3, map => { map.Column("`X3`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X4, map => { map.Column("`X4`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X5, map => { map.Column("`X5`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X6, map => { map.Column("`X6`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X7, map => { map.Column("`X7`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X8, map => { map.Column("`X8`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X9, map => { map.Column("`X9`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X10, map => { map.Column("`X10`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J3, map => { map.Column("`J3`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J4, map => { map.Column("`J4`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J5, map => { map.Column("`J5`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J6, map => { map.Column("`J6`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J7, map => { map.Column("`J7`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J8, map => { map.Column("`J8`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J9, map => { map.Column("`J9`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J10, map => { map.Column("`J10`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V3, map => { map.Column("`V3`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V4, map => { map.Column("`V4`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V5, map => { map.Column("`V5`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V6, map => { map.Column("`V6`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V7, map => { map.Column("`V7`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V8, map => { map.Column("`V8`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V9, map => { map.Column("`V9`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V10, map => { map.Column("`V10`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.S1, map => { map.Column("`S1`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.S2, map => { map.Column("`S2`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.S3, map => { map.Column("`S3`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.S4, map => { map.Column("`S4`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L0, map => { map.Column("`L0`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M0, map => { map.Column("`M0`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X0, map => { map.Column("`X0`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J0, map => { map.Column("`J0`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V0, map => { map.Column("`V0`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.S0, map => { map.Column("`S0`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L11, map => { map.Column("`L11`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.L12, map => { map.Column("`L12`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M11, map => { map.Column("`M11`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.M12, map => { map.Column("`M12`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X11, map => { map.Column("`X11`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.X12, map => { map.Column("`X12`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J11, map => { map.Column("`J11`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.J12, map => { map.Column("`J12`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V11, map => { map.Column("`V11`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.V12, map => { map.Column("`V12`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.NdL, map => { map.Column("`ND_L`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.NdM, map => { map.Column("`ND_M`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.NdX, map => { map.Column("`ND_X`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.NdJ, map => { map.Column("`ND_J`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.NdV, map => { map.Column("`ND_V`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.NdS, map => { map.Column("`ND_S`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.Predeterminado, map => { map.Column("`PREDETERMINADO`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
