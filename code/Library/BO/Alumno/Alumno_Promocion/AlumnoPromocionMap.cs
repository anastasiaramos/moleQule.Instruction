using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
    [Serializable()]
    public class AlumnoPromocionMap : ClassMapping<AlumnoPromocionRecord>
    {
        public AlumnoPromocionMap()
        {
            Table("`Alumno_Promocion`");
            Lazy(true);

            Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Alumno_Promocion_OID_seq`" })); map.Column("`OID`"); });
            Property(x => x.OidPromocion, map => { map.Column("`OID_PROMOCION`"); map.Length(32768); });
            Property(x => x.OidAlumno, map => { map.Column("`OID_ALUMNO`"); map.Length(32768); });
        }
    }
}
