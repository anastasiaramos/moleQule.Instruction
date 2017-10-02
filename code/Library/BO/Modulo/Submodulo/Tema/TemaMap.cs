using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class TemaMap : ClassMapping<TemaRecord>
	{	
		public TemaMap()
		{
			Table("`Tema`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Tema_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidSubmodulo, map => { map.Column("`OID_SUBMODULO`"); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`");	map.Length(255);  });
			Property(x => x.CodigoOrden, map => { map.Column("`CODIGO_ORDEN`");	map.Length(255);  });
			Property(x => x.OidModulo, map => { map.Column("`OID_MODULO`"); map.Length(32768); });
			Property(x => x.Nivel, map => { map.Column("`NIVEL`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Desarrollo, map => { map.Column("`DESARROLLO`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
