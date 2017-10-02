using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class AlumnoMap : ClassMapping<AlumnoRecord>
	{	
		public AlumnoMap()
		{
			Table("`Alumno`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`Alumno_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.NExpediente, map => { map.Column("`N_EXPEDIENTE`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`"); map.NotNullable(false);	map.Length(255);  });
            Property(x => x.Apellidos, map => { map.Column("`APELLIDOS`"); map.NotNullable(false); map.Length(255); });
            Property(x => x.Identificador, map => { map.Column("`ID`"); map.NotNullable(false); map.Length(255); });
			Property(x => x.TipoId, map => { map.Column("`TIPO_ID`"); map.Length(32768); });
			Property(x => x.Email, map => { map.Column("`EMAIL`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Direccion, map => { map.Column("`DIRECCION`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.CodPostal, map => { map.Column("`COD_POSTAL`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Localidad, map => { map.Column("`LOCALIDAD`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Municipio, map => { map.Column("`MUNICIPIO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Provincia, map => { map.Column("`PROVINCIA`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Telefono, map => { map.Column("`TELEFONO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.NivelEstudios, map => { map.Column("`NIVEL_ESTUDIOS`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Foto, map => { map.Column("`FOTO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Grupo, map => { map.Column("`GRUPO`"); map.Length(32768); });
			Property(x => x.FechaNacimiento, map => { map.Column("`FECHA_NACIMIENTO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Requisitos, map => { map.Column("`REQUISITOS`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.PruebaAcceso, map => { map.Column("`PRUEBA_ACCESO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.LugarTrabajo, map => { map.Column("`LUGAR_TRABAJO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.LugarEstudio, map => { map.Column("`LUGAR_ESTUDIO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Formacion, map => { map.Column("`FORMACION`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Idiomas, map => { map.Column("`IDIOMAS`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
