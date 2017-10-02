using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Sesion_PromocionMap : ClassMapping<Sesion_PromocionRecord>
	{	
		public Sesion_PromocionMap()
		{
			Table("`Sesion_Promocion`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Sesion_Promocion_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPromocion, map => { map.Column("`OID_PROMOCION`"); map.Length(32768); });
			Property(x => x.HoraInicio, map => { map.Column("`HORA_INICIO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.NHoras, map => { map.Column("`N_HORAS`"); map.Length(32768); });
			Property(x => x.Sabado, map => { map.Column("`SABADO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Tipo, map => { map.Column("`TIPO`"); map.Length(32768); });
					}
	}
}
