using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Clase_ParteMap : ClassMapping<Clase_ParteRecord>
	{	
		public Clase_ParteMap()
		{
			Table("`Clase_Parte`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Clase_Parte_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidClase, map => { map.Column("`OID_CLASE`"); map.Length(32768); });
			Property(x => x.OidParte, map => { map.Column("`OID_PARTE`"); map.Length(32768); });
			Property(x => x.Tipo, map => { map.Column("`TIPO`"); map.Length(32768); });
			Property(x => x.Grupo, map => { map.Column("`GRUPO`"); map.Length(32768); });
					}
	}
}
