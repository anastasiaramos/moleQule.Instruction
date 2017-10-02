using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class AlumnoExamenMap : ClassMapping<AlumnoExamenRecord>
	{	
		public AlumnoExamenMap()
		{
			Table("`Alumno_Examen`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Alumno_Examen_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAlumno, map => { map.Column("`OID_ALUMNO`"); map.Length(32768); });
			Property(x => x.OidExamen, map => { map.Column("`OID_EXAMEN`"); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`");	map.Length(255);  });
			Property(x => x.Presentado, map => { map.Column("`PRESENTADO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Calificacion, map => { map.Column("`CALIFICACION`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
