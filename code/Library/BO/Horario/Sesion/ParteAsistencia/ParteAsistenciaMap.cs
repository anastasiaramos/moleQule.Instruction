using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class ParteAsistenciaMap : ClassMapping<ParteAsistenciaRecord>
	{	
		public ParteAsistenciaMap()
		{
			Table("`ParteAsistencia`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`ParteAsistencia_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidHorario, map => { map.Column("`OID_HORARIO`"); map.Length(32768); });
			Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Duracion, map => { map.Column("`DURACION`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Sesiones, map => { map.Column("`SESIONES`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.OidInstructor, map => { map.Column("`OID_INSTRUCTOR`"); map.Length(32768); });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Hora, map => { map.Column("`HORA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Tipo, map => { map.Column("`TIPO`"); map.Length(32768); });
			Property(x => x.NHoras, map => { map.Column("`N_HORAS`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.HoraInicio, map => { map.Column("`HORA_INICIO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Confirmada, map => { map.Column("`CONFIRMADA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidInstructorEfectivo, map => { map.Column("`OID_INSTRUCTOR_EFECTIVO`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
