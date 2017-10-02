using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class AlumnoParteMap : ClassMapping<AlumnoParteRecord>
	{	
		public AlumnoParteMap()
		{
			Table("`Alumno_Parte`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Alumno_Parte_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAlumno, map => { map.Column("`OID_ALUMNO`"); map.Length(32768); });
			Property(x => x.OidParte, map => { map.Column("`OID_PARTE`"); map.Length(32768); });
			Property(x => x.Falta, map => { map.Column("`FALTA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Retraso, map => { map.Column("`RETRASO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Recuperada, map => { map.Column("`RECUPERADA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaRecuperacion, map => { map.Column("`FECHA_RECUPERACION`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
