using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Pregunta_ExamenMap : ClassMapping<Pregunta_ExamenRecord>
	{	
		public Pregunta_ExamenMap()
		{
			Table("`Pregunta_Examen`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Pregunta_Examen_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPregunta, map => { map.Column("`OID_PREGUNTA`"); map.Length(32768); });
			Property(x => x.OidExamen, map => { map.Column("`OID_EXAMEN`"); map.Length(32768); });
					}
	}
}
