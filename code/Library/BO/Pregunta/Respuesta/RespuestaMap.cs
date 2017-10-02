using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class RespuestaMap : ClassMapping<RespuestaRecord>
	{	
		public RespuestaMap()
		{
			Table("`Respuesta`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Respuesta_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPregunta, map => { map.Column("`OID_PREGUNTA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Opcion, map => { map.Column("`OPCION`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Correcta, map => { map.Column("`CORRECTA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidOld, map => { map.Column("`OID_OLD`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.OidPreguntaOld, map => { map.Column("`OID_PREGUNTA_OLD`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
