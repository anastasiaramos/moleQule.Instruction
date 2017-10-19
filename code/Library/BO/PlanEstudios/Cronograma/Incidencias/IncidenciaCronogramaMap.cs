using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class IncidenciaCronogramaMap : ClassMapping<IncidenciaCronogramaRecord>
	{	
		public IncidenciaCronogramaMap()
		{
			Table("`Incidencia_Cronograma`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Incidencia_Cronograma_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidCronograma, map => { map.Column("`OID_CRONOGRAMA`"); map.Length(32768); });
			Property(x => x.Motivo, map => { map.Column("`MOTIVO`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
        }
	}
}
