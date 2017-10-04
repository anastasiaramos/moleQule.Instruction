using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class PreguntaExamenMap : ClassMapping<PreguntaExamenRecord>
	{	
		public PreguntaExamenMap()
		{
			Table("`PreguntaExamen`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`PreguntaExamen_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidExamen, map => { map.Column("`OID_EXAMEN`"); map.Length(32768); });
			Property(x => x.OidModulo, map => { map.Column("`OID_MODULO`"); map.Length(32768); });
			Property(x => x.OidTema, map => { map.Column("`OID_TEMA`"); map.Length(32768); });
			Property(x => x.Nivel, map => { map.Column("`NIVEL`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaAlta, map => { map.Column("`FECHA_ALTA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaPublicacion, map => { map.Column("`FECHA_PUBLICACION`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Tipo, map => { map.Column("`TIPO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Imagen, map => { map.Column("`IMAGEN`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.ModeloRespuesta, map => { map.Column("`MODELO_RESPUESTA`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.Idioma, map => { map.Column("`IDIOMA`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.ImagenGrande, map => { map.Column("`IMAGEN_GRANDE`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Orden, map => { map.Column("`ORDEN`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidSubmoduloOld, map => { map.Column("`OID_SUBMODULO_OLD`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.CodigoSubmodulo, map => { map.Column("`CODIGO_SUBMODULO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.OidPreguntaOld, map => { map.Column("`OID_PREGUNTA_OLD`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidPregunta, map => { map.Column("`OID_PREGUNTA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Anulada, map => { map.Column("`ANULADA`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
