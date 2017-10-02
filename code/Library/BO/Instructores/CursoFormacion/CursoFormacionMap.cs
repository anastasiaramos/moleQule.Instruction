using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class CursoFormacionMap : ClassMapping<CursoFormacionRecord>
	{	
		public CursoFormacionMap()
		{
			Table("`CursoFormacion`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`CursoFormacion_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidProfesor, map => { map.Column("`OID_PROFESOR`"); map.Length(32768); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaRenovacion, map => { map.Column("`FECHA_RENOVACION`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.NHoras, map => { map.Column("`N_HORAS`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
