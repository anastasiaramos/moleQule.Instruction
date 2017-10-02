using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class ClaseTeoricaMap : ClassMapping<ClaseTeoricaRecord>
	{	
		public ClaseTeoricaMap()
		{
			Table("`ClaseTeorica`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`ClaseTeorica_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPlan, map => { map.Column("`OID_PLAN`"); map.Length(32768); });
			Property(x => x.OidModulo, map => { map.Column("`OID_MODULO`"); map.Length(32768); });
			Property(x => x.OidSubmodulo, map => { map.Column("`OID_SUBMODULO`"); map.Length(32768); });
			Property(x => x.OrdenPrimario, map => { map.Column("`ORDEN_PRIMARIO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OrdenSecundario, map => { map.Column("`ORDEN_SECUNDARIO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Titulo, map => { map.Column("`TITULO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.OrdenTerciario, map => { map.Column("`ORDEN_TERCIARIO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Alias, map => { map.Column("`ALIAS`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.TotalClases, map => { map.Column("`TOTAL_CLASES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Duracion, map => { map.Column("`DURACION`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
