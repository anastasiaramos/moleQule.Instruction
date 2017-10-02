using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Submodulo_InstructorMap : ClassMapping<Submodulo_InstructorRecord>
	{	
		public Submodulo_InstructorMap()
		{
			Table("`Submodulo_Instructor`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Submodulo_Instructor_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidInstructor, map => { map.Column("`OID_INSTRUCTOR`"); map.Length(32768); });
			Property(x => x.OidSubmodulo, map => { map.Column("`OID_SUBMODULO`"); map.Length(32768); });
			Property(x => x.OidInstructorSuplente, map => { map.Column("`OID_INSTRUCTOR_SUPLENTE`"); map.Length(32768); });
			Property(x => x.FechaInicio, map => { map.Column("`FECHA_INICIO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaFin, map => { map.Column("`FECHA_FIN`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
