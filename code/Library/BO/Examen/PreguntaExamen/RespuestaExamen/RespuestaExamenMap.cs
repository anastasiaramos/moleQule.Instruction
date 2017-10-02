using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class RespuestaExamenMap : ClassMapping<RespuestaExamenRecord>
	{	
		public RespuestaExamenMap()
		{
			Table("`RespuestaExamen`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`RespuestaExamen_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPregunta, map => { map.Column("`OID_PREGUNTA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Opcion, map => { map.Column("`OPCION`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Correcta, map => { map.Column("`CORRECTA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidPreguntaOld, map => { map.Column("`OID_PREGUNTA_OLD`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidRespuestaOld, map => { map.Column("`OID_RESPUESTA_OLD`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidExamen, map => { map.Column("`OID_EXAMEN`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidRespuesta, map => { map.Column("`OID_RESPUESTA`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
