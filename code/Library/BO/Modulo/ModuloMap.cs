using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class ModuloMap : ClassMapping<ModuloRecord>
	{	
		public ModuloMap()
		{
			Table("`Modulo`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Modulo_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Alias, map => { map.Column("`ALIAS`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.NumeroModulo, map => { map.Column("`NUMERO_MODULO`");	map.Length(255);  });
			Property(x => x.NumeroOrden, map => { map.Column("`NUMERO_ORDEN`"); map.NotNullable(false);	map.Length(255);  });
					}
	}
}
