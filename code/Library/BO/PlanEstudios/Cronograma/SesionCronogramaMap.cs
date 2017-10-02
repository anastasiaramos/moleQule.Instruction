using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class SesionCronogramaMap : ClassMapping<SesionCronogramaRecord>
	{	
		public SesionCronogramaMap()
		{
			Table("`SesionCronograma`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`SesionCronograma_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidCronograma, map => { map.Column("`OID_CRONOGRAMA`"); map.Length(32768); });
			Property(x => x.OidClaseTeorica, map => { map.Column("`OID_CLASE_TEORICA`"); map.Length(32768); });
			Property(x => x.OidClasePractica, map => { map.Column("`OID_CLASE_PRACTICA`"); map.Length(32768); });
			Property(x => x.Semana, map => { map.Column("`SEMANA`"); map.Length(32768); });
			Property(x => x.Dia, map => { map.Column("`DIA`"); map.Length(32768); });
			Property(x => x.Turno, map => { map.Column("`TURNO`"); map.Length(32768); });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.Texto, map => { map.Column("`TEXTO`"); map.NotNullable(false); map.Length(255); });
            Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.Hora, map => { map.Column("`HORA`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
