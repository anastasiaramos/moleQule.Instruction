using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class Material_AlumnoMap : ClassMapping<Material_AlumnoRecord>
	{	
		public Material_AlumnoMap()
		{
			Table("`Material_Alumno`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Material_Alumno_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidMaterial, map => { map.Column("`OID_MATERIAL`"); map.Length(32768); });
			Property(x => x.OidAlumno, map => { map.Column("`OID_ALUMNO`"); map.Length(32768); });
			Property(x => x.Entregado, map => { map.Column("`ENTREGADO`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
