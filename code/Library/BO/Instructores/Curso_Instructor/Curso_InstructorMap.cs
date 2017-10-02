using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Curso_InstructorMap : ClassMapping<Curso_InstructorRecord>
	{	
		public Curso_InstructorMap()
		{
			Table("`Curso_Instructor`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Curso_Instructor_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidCurso, map => { map.Column("`OID_CURSO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidProfesor, map => { map.Column("`OID_PROFESOR`"); map.Length(32768); });
					}
	}
}
