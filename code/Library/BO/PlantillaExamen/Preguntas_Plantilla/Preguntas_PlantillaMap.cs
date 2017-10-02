using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Preguntas_PlantillaMap : ClassMapping<Preguntas_PlantillaRecord>
	{	
		public Preguntas_PlantillaMap()
		{
			Table("`Preguntas_Plantilla`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Preguntas_Plantilla_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPlantilla, map => { map.Column("`OID_PLANTILLA`"); map.Length(32768); });
			Property(x => x.OidSubmodulo, map => { map.Column("`OID_SUBMODULO`"); map.Length(32768); });
			Property(x => x.NPreguntas, map => { map.Column("`N_PREGUNTAS`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidTema, map => { map.Column("`OID_TEMA`"); map.Length(32768); });
					}
	}
}
