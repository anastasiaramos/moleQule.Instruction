using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Material_PlanMap : ClassMapping<Material_PlanRecord>
	{	
		public Material_PlanMap()
		{
			Table("`Material_Plan`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Material_Plan_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidModulo, map => { map.Column("`OID_MODULO`"); map.Length(32768); });
			Property(x => x.OidMaterial, map => { map.Column("`OID_MATERIAL`"); map.Length(32768); });
			Property(x => x.OidRevision, map => { map.Column("`OID_REVISION`"); map.Length(32768); });
					}
	}
}
