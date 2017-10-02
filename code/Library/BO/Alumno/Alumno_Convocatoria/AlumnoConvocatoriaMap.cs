using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class AlumnoConvocatoriaMap : ClassMapping<AlumnoConvocatoriaRecord>
	{	
		public AlumnoConvocatoriaMap()
		{
			Table("`Alumno_Convocatoria`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Alumno_Convocatoria_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidConvocatoria, map => { map.Column("`OID_CONVOCATORIA`"); map.Length(32768); });
			Property(x => x.OidAlumno, map => { map.Column("`OID_ALUMNO`"); map.Length(32768); });
			Property(x => x.OidCliente, map => { map.Column("`OID_CLIENTE`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
