using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class PreguntaMap : ClassMapping<PreguntaRecord>
	{	
		public PreguntaMap()
		{
			Table("`Pregunta`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Pregunta_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidModulo, map => { map.Column("`OID_MODULO`"); map.Length(32768); });
			Property(x => x.OidTema, map => { map.Column("`OID_TEMA`"); map.Length(32768); });
			Property(x => x.Nivel, map => { map.Column("`NIVEL`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaAlta, map => { map.Column("`FECHA_ALTA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaPublicacion, map => { map.Column("`FECHA_PUBLICACION`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Tipo, map => { map.Column("`TIPO`"); map.NotNullable(false);	map.Length(255);  });
            Property(x => x.Imagen, map => { map.Column("`IMAGEN`"); map.NotNullable(false); map.Length(255); });
            Property(x => x.ModeloRespuesta, map => { map.Column("`MODELO_RESPUESTA`"); map.NotNullable(false); map.Length(255); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaDisponibilidad, map => { map.Column("`FECHA_DISPONIBILIDAD`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Idioma, map => { map.Column("`IDIOMA`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Activa, map => { map.Column("`ACTIVA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Revisada, map => { map.Column("`REVISADA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.ImagenGrande, map => { map.Column("`IMAGEN_GRANDE`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Bloqueada, map => { map.Column("`BLOQUEADA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidSubmodulo, map => { map.Column("`OID_SUBMODULO`"); map.Length(32768); });
			Property(x => x.OidOld, map => { map.Column("`OID_OLD`"); map.Length(32768); });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Reservada, map => { map.Column("`RESERVADA`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
