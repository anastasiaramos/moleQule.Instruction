using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class PromocionMap : ClassMapping<PromocionRecord>
	{	
		public PromocionMap()
		{
			Table("`Promocion`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Promocion_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPlan, map => { map.Column("`OID_PLAN`"); map.Length(32768); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`");	map.Length(255);  });
			Property(x => x.Numero, map => { map.Column("`NUMERO`");	map.Length(255);  });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaInicio, map => { map.Column("`FECHA_INICIO`"); map.Length(32768); });
			Property(x => x.FechaFin, map => { map.Column("`FECHA_FIN`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.InicioClases, map => { map.Column("`INICIO_CLASES`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.H8AM, map => { map.Column("`H8AM`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H1, map => { map.Column("`H1`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H2, map => { map.Column("`H2`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H3, map => { map.Column("`H3`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H4, map => { map.Column("`H4`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H5, map => { map.Column("`H5`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H6, map => { map.Column("`H6`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H7, map => { map.Column("`H7`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H8, map => { map.Column("`H8`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H9, map => { map.Column("`H9`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H10, map => { map.Column("`H10`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Hs1, map => { map.Column("`HS1`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Hs2, map => { map.Column("`HS2`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Hs3, map => { map.Column("`HS3`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Hs4, map => { map.Column("`HS4`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H0, map => { map.Column("`H0`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Hs0, map => { map.Column("`HS0`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H11, map => { map.Column("`H11`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.H12, map => { map.Column("`H12`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidPlanExtra, map => { map.Column("`OID_PLAN_EXTRA`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
