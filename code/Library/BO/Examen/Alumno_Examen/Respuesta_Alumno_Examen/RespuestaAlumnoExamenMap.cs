using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Respuesta_Alumno_ExamenMap : ClassMapping<Respuesta_Alumno_ExamenRecord>
	{	
		public Respuesta_Alumno_ExamenMap()
		{
			Table("`Respuesta_Alumno_Examen`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Respuesta_Alumno_Examen_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAlumnoExamen, map => { map.Column("`OID_ALUMNO_EXAMEN`"); map.Length(32768); });
			Property(x => x.OidPreguntaExamen, map => { map.Column("`OID_PREGUNTA_EXAMEN`"); map.Length(32768); });
			Property(x => x.Opcion, map => { map.Column("`OPCION`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Orden, map => { map.Column("`ORDEN`"); map.Length(32768); });
			Property(x => x.Correcta, map => { map.Column("`CORRECTA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Calificacion, map => { map.Column("`CALIFICACION`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
