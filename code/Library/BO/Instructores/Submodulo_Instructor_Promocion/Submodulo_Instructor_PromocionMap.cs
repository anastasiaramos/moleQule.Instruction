using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Submodulo_Instructor_PromocionMap : ClassMapping<Submodulo_Instructor_PromocionRecord>
	{	
		public Submodulo_Instructor_PromocionMap()
		{
			Table("`Submodulo_Instructor_Promocion`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Submodulo_Instructor_Promocion_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidSubmodulo, map => { map.Column("`OID_SUBMODULO`"); map.Length(32768); });
			Property(x => x.OidInstructor, map => { map.Column("`OID_INSTRUCTOR`"); map.Length(32768); });
			Property(x => x.Prioridad, map => { map.Column("`PRIORIDAD`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OidPromocion, map => { map.Column("`OID_PROMOCION`"); map.Length(32768); });
			Property(x => x.OidInstructorPromocion, map => { map.Column("`OID_INSTRUCTOR_PROMOCION`"); map.Length(32768); });
					}
	}
}
