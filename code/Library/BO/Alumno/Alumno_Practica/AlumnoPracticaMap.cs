using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class AlumnoPracticaMap : ClassMapping<AlumnoPracticaRecord>
	{	
		public AlumnoPracticaMap()
		{
			Table("`Alumno_Practica`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Alumno_Practica_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAlumno, map => { map.Column("`OID_ALUMNO`"); map.Length(32768); });
			Property(x => x.OidClasePractica, map => { map.Column("`OID_CLASE_PRACTICA`"); map.Length(32768); });
			Property(x => x.Calificacion, map => { map.Column("`CALIFICACION`");	map.Length(255);  });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.OidParte, map => { map.Column("`OID_PARTE`"); map.Length(32768); });
			Property(x => x.Recuperada, map => { map.Column("`RECUPERADA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaRecuperacion, map => { map.Column("`FECHA_RECUPERACION`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
