using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class CronogramaMap : ClassMapping<CronogramaRecord>
	{	
		public CronogramaMap()
		{
			Table("`Cronograma`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Cronograma_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPlan, map => { map.Column("`OID_PLAN`"); map.Length(32768); });
			Property(x => x.OidPromocion, map => { map.Column("`OID_PROMOCION`"); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaCreacion, map => { map.Column("`FECHA_CREACION`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
