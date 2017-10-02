using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Concepto_ParteMap : ClassMapping<Concepto_ParteRecord>
	{	
		public Concepto_ParteMap()
		{
			Table("`Concepto_Parte`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Concepto_Parte_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidConcepto, map => { map.Column("`OID_CONCEPTO`"); map.Length(32768); });
			Property(x => x.OidParte, map => { map.Column("`OID_PARTE`"); map.Length(32768); });
					}
	}
}
