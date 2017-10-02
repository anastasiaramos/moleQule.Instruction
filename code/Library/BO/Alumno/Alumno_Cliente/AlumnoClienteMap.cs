using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class AlumnoClienteMap : ClassMapping<AlumnoClienteRecord>
	{	
		public AlumnoClienteMap()
		{
			Table("`Alumno_Cliente`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Alumno_Cliente_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidAlumno, map => { map.Column("`OID_ALUMNO`"); map.Length(32768); });
			Property(x => x.OidCliente, map => { map.Column("`OID_CLIENTE`"); map.Length(32768); });
		}
	}
}
