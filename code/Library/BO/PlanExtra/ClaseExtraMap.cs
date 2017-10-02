using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class ClaseExtraMap : ClassMapping<ClaseExtraRecord>
	{	
		public ClaseExtraMap()
		{
			Table("`ClaseExtra`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`ClaseExtra_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPlan, map => { map.Column("`OID_PLAN`"); map.Length(32768); });
			Property(x => x.OidModulo, map => { map.Column("`OID_MODULO`"); map.Length(32768); });
			Property(x => x.OidSubmodulo, map => { map.Column("`OID_SUBMODULO`"); map.Length(32768); });
			Property(x => x.Titulo, map => { map.Column("`TITULO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Alias, map => { map.Column("`ALIAS`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.TotalClases, map => { map.Column("`TOTAL_CLASES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Orden, map => { map.Column("`ORDEN`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
