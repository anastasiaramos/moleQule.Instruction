using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class PlanExtraMap : ClassMapping<PlanExtraRecord>
	{	
		public PlanExtraMap()
		{
			Table("`PlanExtra`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`PlanExtra_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidProducto, map => { map.Column("`OID_PRODUCTO`"); map.Length(32768); });
			Property(x => x.OidSerie, map => { map.Column("`OID_SERIE`"); map.Length(32768); });
					}
	}
}
