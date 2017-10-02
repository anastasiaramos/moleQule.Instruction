using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Convocatoria_CursoMap : ClassMapping<Convocatoria_CursoRecord>
	{	
		public Convocatoria_CursoMap()
		{
			Table("`Convocatoria_Curso`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Convocatoria_Curso_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`"); map.Length(255); });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.FechaInicio, map => { map.Column("`FECHA_INICIO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaCaducidad, map => { map.Column("`FECHA_CADUCIDAD`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidCurso, map => { map.Column("`OID_CURSO`"); map.Length(32768); });
					}
	}
}
