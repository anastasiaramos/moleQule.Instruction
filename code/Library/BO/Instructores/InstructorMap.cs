using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace moleQule.Library.Instruction
{
	[Serializable()]
	public class InstructorMap : ClassMapping<InstructorRecord>
	{	
		public InstructorMap()
		{
			Table("`STEmployee`");
			Lazy(true);	
			
			Id(x => x.Oid, map => { map.Generator(Generators.Sequence, gmap => gmap.Params(new { sequence = "`STEmployee_OID_seq`" })); map.Column("`OID`"); });
			Property(x => x.OidImpuesto, map => { map.Column("`OID_IMPUESTO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.TipoAcreedor, map => { map.Column("`TIPO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Codigo, map => { map.Column("`CODIGO`");	map.Length(255);  });
			Property(x => x.Serial, map => { map.Column("`SERIAL`"); map.Length(32768); });
			Property(x => x.Estado, map => { map.Column("`ESTADO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Nombre, map => { map.Column("`NOMBRE`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.NombrePropio, map => { map.Column("`NOMBRE_PROPIO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Apellidos, map => { map.Column("`APELLIDOS`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Alias, map => { map.Column("`ALIAS`");	map.Length(255);  });
			Property(x => x.Identificador, map => { map.Column("`ID`"); map.NotNullable(false); map.Length(255); });
			Property(x => x.TipoId, map => { map.Column("`TIPO_ID`"); map.Length(32768); });
			Property(x => x.Direccion, map => { map.Column("`DIRECCION`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.CodPostal, map => { map.Column("`COD_POSTAL`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Localidad, map => { map.Column("`LOCALIDAD`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Municipio, map => { map.Column("`MUNICIPIO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Provincia, map => { map.Column("`PROVINCIA`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Pais, map => { map.Column("`PAIS`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Telefono, map => { map.Column("`TELEFONO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Email, map => { map.Column("`EMAIL`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Foto, map => { map.Column("`FOTO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Perfil, map => { map.Column("`PERFIL`"); map.Length(32768); });
            Property(x => x.Activo, map => { map.Column("`ACTIVO`"); map.NotNullable(false); map.Length(32768); });
            Property(x => x.MTOE, map => { map.Column("`MTOE`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.InicioContrato, map => { map.Column("`INICIO_CONTRATO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FinContrato, map => { map.Column("`FIN_CONTRATO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.CuentaBancaria, map => { map.Column("`CUENTA_BANCARIA`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.OidCuentaBAsociada, map => { map.Column("`OID_CUENTA_BANCARIA_ASOCIADA`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.CuentaContable, map => { map.Column("`CUENTA_CONTABLE`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.MedioPago, map => { map.Column("`MEDIO_PAGO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.FormaPago, map => { map.Column("`FORMA_PAGO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.DiasPago, map => { map.Column("`DIAS_PAGO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.Contacto, map => { map.Column("`CONTACTO`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.NivelEstudios, map => { map.Column("`NIVEL_ESTUDIOS`"); map.NotNullable(false);	map.Length(255);  });
			Property(x => x.Observaciones, map => { map.Column("`OBSERVACIONES`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.SueldoBruto, map => { map.Column("`SUELDO_BRUTO`"); map.NotNullable(false); map.Length(32768); });
			Property(x => x.PIRPF, map => { map.Column("`P_IRPF`"); map.NotNullable(false); map.Length(32768); });
					}
	}
}
