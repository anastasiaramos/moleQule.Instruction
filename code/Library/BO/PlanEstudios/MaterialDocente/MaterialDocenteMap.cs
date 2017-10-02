using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class MaterialDocenteMap : ClassMapping<MaterialDocenteRecord>
	{	
		public MaterialDocenteMap()
		{
			Table("`MaterialDocente`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`MaterialDocente_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidCurso, map => { map.Column("`OID_CURSO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`");	map.Length(255);  });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidModulo, map => { map.Column("`OID_MODULO`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
