using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class SesionMap : ClassMapping<SesionRecord>
	{	
		public SesionMap()
		{
			Table("`Sesion`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Sesion_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidHorario, map => { map.Column("`OID_HORARIO`"); map.Length(32768); });
			Property(x => x.OidClaseTeorica, map => { map.Column("`OID_CLASE_TEORICA`"); map.Length(32768); });
			Property(x => x.OidClasePractica, map => { map.Column("`OID_CLASE_PRACTICA`"); map.Length(32768); });
			Property(x => x.OidClaseExtra, map => { map.Column("`OID_CLASE_EXTRA`"); map.Length(32768); });
			Property(x => x.OidProfesor, map => { map.Column("`OID_PROFESOR`"); map.Length(32768); });
			Property(x => x.Fecha, map => { map.Column("`FECHA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Grupo, map => { map.Column("`GRUPO`"); map.Length(32768); });
			Property(x => x.Estado, map => { map.Column("`ESTADO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Hora, map => { map.Column("`HORA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Forzada, map => { map.Column("`FORZADA`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
