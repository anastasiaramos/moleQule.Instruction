using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class IncidenciaSesionCronogramaMap : ClassMapping<IncidenciaSesionCronogramaRecord>
	{	
		public IncidenciaSesionCronogramaMap()
		{
			Table("`Incidencia_Sesion_Cronograma`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Incidencia_Sesion_Cronograma_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidIncidencia, map => { map.Column("`OID_INCIDENCIA`"); map.Length(32768); });
			Property(x => x.OidClaseTeoricaProgramada, map => { map.Column("`OID_CLASE_TEORICA_PROGRAMADA`"); map.Length(32768); });
			Property(x => x.OidClasePracticaProgramada, map => { map.Column("`OID_CLASE_PRACTICA_PROGRAMADA`"); map.Length(32768); });
            Property(x => x.FechaClaseProgramada, map => { map.Column("`FECHA_CLASE_PROGRAMADA`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.HoraClaseProgramada, map => { map.Column("`HORA_CLASE_PROGRAMADA`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.OidClaseTeoricaAsignada, map => { map.Column("`OID_CLASE_TEORICA_ASIGNADA`"); map.Length(32768); });
            Property(x => x.OidClasePracticaAsignada, map => { map.Column("`OID_CLASE_PRACTICA_ASIGNADA`"); map.Length(32768); });
            Property(x => x.FechaClaseAsignada, map => { map.Column("`FECHA_CLASE_ASIGNADA`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.HoraClaseAsignada, map => { map.Column("`HORA_CLASE_ASIGNADA`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
