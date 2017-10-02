using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class ExamenMap : ClassMapping<ExamenRecord>
	{	
		public ExamenMap()
		{
			Table("`Examen`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Examen_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidPromocion, map => { map.Column("`OID_PROMOCION`"); map.Length(32768); });
			Property(x => x.OidProfesor, map => { map.Column("`OID_PROFESOR`"); map.Length(32768); });
			Property(x => x.OidModulo, map => { map.Column("`OID_MODULO`"); map.Length(32768); });
			Property(x => x.FechaExamen, map => { map.Column("`FECHA_EXAMEN`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaCreacion, map => { map.Column("`FECHA_CREACION`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FechaEmision, map => { map.Column("`FECHA_EMISION`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Tipo, map => { map.Column("`TIPO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Desarrollo, map => { map.Column("`DESARROLLO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Titulo, map => { map.Column("`TITULO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Duracion, map => { map.Column("`DURACION`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.MemoPreguntas, map => { map.Column("`MEMO_PREGUNTAS`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Numero, map => { map.Column("`NUMERO`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
