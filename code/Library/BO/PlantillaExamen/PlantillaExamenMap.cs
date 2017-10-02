using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class PlantillaExamenMap : ClassMapping<PlantillaExamenRecord>
	{	
		public PlantillaExamenMap()
		{
			Table("`PlantillaExamen`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`PlantillaExamen_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidModulo, map => { map.Column("`OID_MODULO`"); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Idioma, map => { map.Column("`IDIOMA`");	map.Length(255);  });
			Property(x => x.Desarrollo, map => { map.Column("`DESARROLLO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.NPreguntas, map => { map.Column("`N_PREGUNTAS`"); map.Length(32768); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
