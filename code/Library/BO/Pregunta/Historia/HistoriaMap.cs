using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class HistoriaMap : ClassMapping<HistoriaRecord>
	{	
		public HistoriaMap()
		{
			Table("`Historia`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Historia_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPregunta, map => { map.Column("`OID_PREGUNTA`"); map.Length(32768); });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Hora, map => { map.Column("`HORA`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
