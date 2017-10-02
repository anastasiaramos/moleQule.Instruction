using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class RevisionMaterialMap : ClassMapping<RevisionMaterialRecord>
	{	
		public RevisionMaterialMap()
		{
			Table("`RevisionMaterial`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`RevisionMaterial_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidMaterial, map => { map.Column("`OID_MATERIAL`"); map.Length(32768); });
			Property(x => x.Version, map => { map.Column("`VERSION`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Autor, map => { map.Column("`AUTOR`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
