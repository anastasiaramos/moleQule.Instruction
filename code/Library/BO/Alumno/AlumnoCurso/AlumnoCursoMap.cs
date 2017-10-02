using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class AlumnoCursoMap : ClassMapping<AlumnoCursoRecord>
	{	
		public AlumnoCursoMap()
		{
			Table("`Alumno_Curso`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Alumno_Curso_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.Empresa, map => { map.Column("`EMPRESA`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.OidConvocatoria, map => { map.Column("`OID_CONVOCATORIA`"); map.Length(32768); });
			Property(x => x.Apellidos, map => { map.Column("`APELLIDOS`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Ident, map => { map.Column("`IDENT`"); map.NotNullable(false);	map.Length(255);  });
					}
	}
}
