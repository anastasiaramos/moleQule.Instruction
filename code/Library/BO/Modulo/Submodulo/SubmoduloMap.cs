using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class SubmoduloMap : ClassMapping<SubmoduloRecord>
	{	
		public SubmoduloMap()
		{
			Table("`Submodulo`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Submodulo_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.OidModulo, map => { map.Column("`OID_MODULO`"); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.CodigoOrden, map => { map.Column("`CODIGO_ORDEN`"); map.NotNullable(false);	map.Length(255);  });
					}
	}
}
