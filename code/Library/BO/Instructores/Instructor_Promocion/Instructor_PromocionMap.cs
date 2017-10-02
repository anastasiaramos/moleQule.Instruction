using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Instructor_PromocionMap : ClassMapping<Instructor_PromocionRecord>
	{	
		public Instructor_PromocionMap()
		{
			Table("`Instructor_Promocion`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Instructor_Promocion_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidInstructor, map => { map.Column("`OID_INSTRUCTOR`"); map.Length(32768); });
			Property(x => x.OidPromocion, map => { map.Column("`OID_PROMOCION`"); map.Length(32768); });
					}
	}
}
