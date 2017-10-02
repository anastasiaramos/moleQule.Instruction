-- INSTRUCTION MODULE DETAIL SCHEMA SCRIPT


CREATE TABLE "Alumno"
( 
	"OID" bigserial NOT NULL,
	"N_EXPEDIENTE" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "NOMBRE" character varying(255),
    "APELLIDOS" character varying(255),
    "ID" character varying(255),
    "TIPO_ID" bigint NOT NULL,
    "EMAIL" character varying(255),
    "DIRECCION" character varying(255),
    "COD_POSTAL" character varying(255),
    "LOCALIDAD" character varying(255),
    "MUNICIPIO" character varying(255),
    "PROVINCIA" character varying(255),
    "TELEFONO" character varying(255),
    "NIVEL_ESTUDIOS" character varying(255),
    "OBSERVACIONES" text,
    "FOTO" character varying(255),
    "CODIGO" character varying(255) NOT NULL,
    "GRUPO" bigint NOT NULL,
    "FECHA_NACIMIENTO" date,
    "REQUISITOS" boolean DEFAULT true,
    "PRUEBA_ACCESO" boolean DEFAULT true,
    "LUGAR_TRABAJO" character varying(255),
    "LUGAR_ESTUDIO" character varying(255),
    "FORMACION" text,
    "IDIOMAS" text,
	CONSTRAINT "ALUMNO_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Alumno" OWNER TO moladmin;
GRANT ALL ON TABLE "Alumno" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Alumno_Convocatoria"
( 
	"OID" bigserial NOT NULL,	
	"OID_CONVOCATORIA" bigint NOT NULL,
    "OID_ALUMNO" bigint NOT NULL,
    "OID_CLIENTE" bigint,
    "FECHA" date,
	CONSTRAINT "ALUMNO_CONVOCATORIA_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Alumno_Convocatoria" OWNER TO moladmin;
GRANT ALL ON TABLE "Alumno_Convocatoria" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Alumno_Curso"
( 
	"OID" bigserial NOT NULL,
	"EMPRESA" character varying(255),
    "NOMBRE" character varying(255),
    "OID_CONVOCATORIA" bigint NOT NULL,
    "APELLIDOS" character varying(255),
    "IDENT" character varying(255),
	CONSTRAINT "ALUMNO_CURSO_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Alumno_Curso" OWNER TO moladmin;
GRANT ALL ON TABLE "Alumno_Curso" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Alumno_Examen" 
( 
	"OID" bigserial NOT NULL,
	"OID_ALUMNO" bigint NOT NULL,
    "OID_EXAMEN" bigint NOT NULL,
    "OBSERVACIONES" character varying(255) NOT NULL,
    "PRESENTADO" boolean DEFAULT false,
    "CALIFICACION" numeric(10,2) DEFAULT 0,
	CONSTRAINT "ALUMNO_EXAMEN_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Alumno_Examen" OWNER TO moladmin;
GRANT ALL ON TABLE "Alumno_Examen" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Alumno_Parte" 
( 
	"OID" bigserial NOT NULL,
	"OID_ALUMNO" bigint NOT NULL,
    "OID_PARTE" bigint NOT NULL,
    "FALTA" boolean,
    "RETRASO" boolean,
    "OBSERVACIONES" text,
    "RECUPERADA" boolean DEFAULT false,
    "FECHA_RECUPERACION" date,
	CONSTRAINT "ALUMNO_PARTE_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Alumno_Parte" OWNER TO moladmin;
GRANT ALL ON TABLE "Alumno_Parte" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Alumno_Practica" 
( 
	"OID" bigserial NOT NULL,
	"OID_ALUMNO" bigint NOT NULL,
    "OID_CLASE_PRACTICA" bigint NOT NULL,
    "CALIFICACION" character varying(255) NOT NULL,
    "OBSERVACIONES" character varying(255),
    "OID_PARTE" bigint NOT NULL,
    "RECUPERADA" boolean DEFAULT false,
    "FECHA_RECUPERACION" date,
	CONSTRAINT "ALUMNO_PRACTICA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Alumno_Practica" OWNER TO moladmin;
GRANT ALL ON TABLE "Alumno_Practica" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Alumno_Promocion" 
( 
	"OID" bigserial NOT NULL,
	"OID_PROMOCION" bigint NOT NULL,
    "OID_ALUMNO" bigint NOT NULL,
	CONSTRAINT "Alumno_Promocion_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Alumno_Promocion" OWNER TO moladmin;
GRANT ALL ON TABLE "Alumno_Promocion" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "ClaseExtra" 
( 
	"OID" bigserial NOT NULL,
	"OID_PLAN" bigint NOT NULL,
    "OID_MODULO" bigint NOT NULL,
    "OID_SUBMODULO" bigint NOT NULL,
    "TITULO" character varying(255),
    "OBSERVACIONES" text,
    "ALIAS" character varying(255),
    "TOTAL_CLASES" bigint DEFAULT 1,
    "ORDEN" bigint DEFAULT 1,
	CONSTRAINT "CLASE_EXTRA_PK" PRIMARY KEY ("OID")	
)WITHOUT OIDS;

ALTER TABLE "ClaseExtra" OWNER TO moladmin;
GRANT ALL ON TABLE "ClaseExtra" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Clase_Parte"
(
	"OID" bigserial NOT NULL,
	"OID_CLASE" bigint NOT NULL,
	"OID_PARTE" bigint NOT NULL,
	"TIPO" bigint NOT NULL,
	"GRUPO" bigint NOT NULL,
  CONSTRAINT "Clase_Parte_pkey" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Clase_Parte" OWNER TO moladmin;
GRANT ALL ON TABLE "Clase_Parte" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "ClasePractica" 
( 
	"OID" bigserial NOT NULL,
	"OID_PLAN" bigint NOT NULL,
    "OID_MODULO" bigint NOT NULL,
    "OID_SUBMODULO" bigint NOT NULL,
    "ORDEN_PRIMARIO" bigint,
    "ORDEN_SECUNDARIO" bigint,
    "TITULO" character varying(255),
    "OBSERVACIONES" text,
    "ORDEN_TERCIARIO" bigint,
    "ALIAS" character varying(255),
    "INCOMPATIBLE" bigint DEFAULT 0,
    "TOTAL_CLASES" bigint DEFAULT 1,
    "DURACION" bigint DEFAULT 5,
	CONSTRAINT "CLASE_PRACTICA_PK" PRIMARY KEY ("OID")	
)WITHOUT OIDS;

ALTER TABLE "ClasePractica" OWNER TO moladmin;
GRANT ALL ON TABLE "ClasePractica" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "ClaseTeorica" 
( 
	"OID" bigserial NOT NULL,
	"OID_PLAN" bigint NOT NULL,
    "OID_MODULO" bigint NOT NULL,
    "OID_SUBMODULO" bigint NOT NULL,
    "ORDEN_PRIMARIO" bigint,
    "ORDEN_SECUNDARIO" bigint,
    "TITULO" character varying(255),
    "OBSERVACIONES" text,
    "ORDEN_TERCIARIO" bigint,
    "ALIAS" character varying(255),
    "TOTAL_CLASES" bigint DEFAULT 1,
    "DURACION" bigint DEFAULT 1,
	CONSTRAINT "CLASE_TEORICA_PK" PRIMARY KEY ("OID")	
)WITHOUT OIDS;

ALTER TABLE "ClaseTeorica" OWNER TO moladmin;
GRANT ALL ON TABLE "ClaseTeorica" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Concepto_Parte"
( 
	"OID" bigserial NOT NULL,	
	"OID_CONCEPTO" bigint NOT NULL,
    "OID_PARTE" bigint NOT NULL,
	CONSTRAINT "CONCEPTO_PARTE_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Concepto_Parte" OWNER TO moladmin;
GRANT ALL ON TABLE "Concepto_Parte" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Convocatoria_Curso"
(
	"OID" bigserial NOT NULL,
	"CODIGO" character varying(50) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "NOMBRE" character varying(255),
    "FECHA_INICIO" date,
    "FECHA_CADUCIDAD" date,
    "OBSERVACIONES" text,
    "OID_CURSO" bigint NOT NULL,
  CONSTRAINT "CONVOCATORIA_CURSO_PK" PRIMARY KEY ("OID")
)
WITHOUT OIDS;

ALTER TABLE "Convocatoria_Curso" OWNER TO moladmin;
GRANT ALL ON TABLE "Convocatoria_Curso" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Cronograma"
(
	"OID" bigserial NOT NULL,
	"OID_PLAN" bigint NOT NULL,
    "OID_PROMOCION" bigint NOT NULL,
    "OBSERVACIONES" text,
    "FECHA_CREACION" date,
	CONSTRAINT "CRONOGRAMA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Cronograma" OWNER TO moladmin;
GRANT ALL ON TABLE "Cronograma" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Curso" 
( 
	"OID" bigserial NOT NULL,
	"CODIGO" character varying(50) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "NOMBRE" character varying(255),
    "N_HORAS" bigint,
    "OBSERVACIONES" text,
	CONSTRAINT "CURSO_PK" PRIMARY KEY ("OID")	
)WITHOUT OIDS;

ALTER TABLE "Curso" OWNER TO moladmin;
GRANT ALL ON TABLE "Curso" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "CursoFormacion" 
( 
	"OID" bigserial NOT NULL,
	"OID_PROFESOR" bigint NOT NULL,
    "NOMBRE" character varying(255),
    "FECHA" date,
    "FECHA_RENOVACION" date,
    "OBSERVACIONES" text,
    "N_HORAS" bigint,
	CONSTRAINT "CURSO_FORMACION_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "CursoFormacion" OWNER TO moladmin;
GRANT ALL ON TABLE "CursoFormacion" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Curso_Instructor" 
( 
	"OID" bigserial NOT NULL,
	"OID_CURSO" bigint,
    "OID_PROFESOR" bigint NOT NULL,
	CONSTRAINT "CURSO_INSTRUCTOR_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Curso_Instructor" OWNER TO moladmin;
GRANT ALL ON TABLE "Curso_Instructor" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Disponibilidad" ( 
	"OID" bigserial NOT NULL,
	"OID_INSTRUCTOR" bigint NOT NULL,
    "FECHA_INICIO" date NOT NULL,
    "FECHA_FIN" date NOT NULL,
    "L1" boolean DEFAULT false,
    "L2" boolean DEFAULT false,
    "M1" boolean DEFAULT false,
    "M2" boolean DEFAULT false,
    "X1" boolean DEFAULT false,
    "X2" boolean DEFAULT false,
    "J1" boolean DEFAULT false,
    "J2" boolean DEFAULT false,
    "V1" boolean DEFAULT false,
    "V2" boolean DEFAULT false,
    "OBSERVACIONES" character varying(255),
    "CLASES_SEMANALES" bigint DEFAULT 10,
    "L3" boolean DEFAULT false,
    "L4" boolean DEFAULT false,
    "L5" boolean DEFAULT false,
    "L6" boolean DEFAULT false,
    "L7" boolean DEFAULT false,
    "L8" boolean DEFAULT false,
    "L9" boolean DEFAULT false,
    "L10" boolean DEFAULT false,
    "M3" boolean DEFAULT false,
    "M4" boolean DEFAULT false,
    "M5" boolean DEFAULT false,
    "M6" boolean DEFAULT false,
    "M7" boolean DEFAULT false,
    "M8" boolean DEFAULT false,
    "M9" boolean DEFAULT false,
    "M10" boolean DEFAULT false,
    "X3" boolean DEFAULT false,
    "X4" boolean DEFAULT false,
    "X5" boolean DEFAULT false,
    "X6" boolean DEFAULT false,
    "X7" boolean DEFAULT false,
    "X8" boolean DEFAULT false,
    "X9" boolean DEFAULT false,
    "X10" boolean DEFAULT false,
    "J3" boolean DEFAULT false,
    "J4" boolean DEFAULT false,
    "J5" boolean DEFAULT false,
    "J6" boolean DEFAULT false,
    "J7" boolean DEFAULT false,
    "J8" boolean DEFAULT false,
    "J9" boolean DEFAULT false,
    "J10" boolean DEFAULT false,
    "V3" boolean DEFAULT false,
    "V4" boolean DEFAULT false,
    "V5" boolean DEFAULT false,
    "V6" boolean DEFAULT false,
    "V7" boolean DEFAULT false,
    "V8" boolean DEFAULT false,
    "V9" boolean DEFAULT false,
    "V10" boolean DEFAULT false,
    "S1" boolean DEFAULT false,
    "S2" boolean DEFAULT false,
    "S3" boolean DEFAULT false,
    "S4" boolean DEFAULT false,
    "L0" boolean DEFAULT false,
    "M0" boolean DEFAULT false,
    "X0" boolean DEFAULT false,
    "J0" boolean DEFAULT false,
    "V0" boolean DEFAULT false,
    "S0" boolean DEFAULT false,
    "L11" boolean DEFAULT false,
    "L12" boolean DEFAULT false,
    "M11" boolean DEFAULT false,
    "M12" boolean DEFAULT false,
    "X11" boolean DEFAULT false,
    "X12" boolean DEFAULT false,
    "J11" boolean DEFAULT false,
    "J12" boolean DEFAULT false,
    "V11" boolean DEFAULT false,
    "V12" boolean DEFAULT false,
    "ND_L" boolean DEFAULT false,
    "ND_M" boolean DEFAULT false,
    "ND_X" boolean DEFAULT false,
    "ND_J" boolean DEFAULT false,
    "ND_V" boolean DEFAULT false,
    "ND_S" boolean DEFAULT false,	
	CONSTRAINT "DISPONIBILIDAD_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Disponibilidad" OWNER TO moladmin;
GRANT ALL ON TABLE "Disponibilidad" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Examen" 
( 
	"OID" bigserial NOT NULL,
	"OID_PROMOCION" bigint NOT NULL,
    "OID_PROFESOR" bigint NOT NULL,
    "OID_MODULO" bigint NOT NULL,
    "FECHA_EXAMEN" date,
    "FECHA_CREACION" date,
    "FECHA_EMISION" date,
    "TIPO" character varying(255),
    "DESARROLLO" boolean DEFAULT false,
    "TITULO" character varying,
    "DURACION" time without time zone,
    "MEMO_PREGUNTAS" character varying,
    "NUMERO" bigint,
	CONSTRAINT "EXAMEN_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Examen" OWNER TO moladmin;
GRANT ALL ON TABLE "Examen" TO GROUP "MOLEQULE_ADMINISTRATOR";
	
	CREATE TABLE "Examen_Promocion"
( 
	"OID" bigserial NOT NULL,	
	"OID_EXAMEN" bigint NOT NULL,
    "OID_PROMOCION" bigint NOT NULL,
	CONSTRAINT "EXAMEN_PROMOCION_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Examen_Promocion" OWNER TO moladmin;
GRANT ALL ON TABLE "Examen_Promocion" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Festivos"
( 
	"OID" bigserial NOT NULL,	
	"FECHA_INICIO" date,
	"FECHA_FIN" date,
    "ANUAL" boolean DEFAULT 'TRUE',
	"TIPO" bigint DEFAULT 1,
	"TITULO" character varying(255),
	"DESCRIPCION" character varying,
	CONSTRAINT "FESTIVOS_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Festivos" OWNER TO moladmin;
GRANT ALL ON TABLE "Festivos" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Historia" 
( 
	"OID" bigserial NOT NULL,
	"OID_PREGUNTA" bigint NOT NULL,
    "FECHA" date,
    "TEXTO" character varying,
    "HORA" time without time zone,
	CONSTRAINT "HISTORIA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Historia" OWNER TO moladmin;
GRANT ALL ON TABLE "Historia" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Horario" 
( 
	"OID" bigserial NOT NULL,
	"OID_PLAN" bigint NOT NULL,
    "OID_PROMOCION" bigint NOT NULL,
    "FECHA_INICIAL" date,
    "FECHA_FINAL" date,
    "OBSERVACIONES" text,
    "H1" boolean DEFAULT true,
    "H2" boolean DEFAULT true,
    "H3" boolean DEFAULT true,
    "H4" boolean DEFAULT true,
    "H5" boolean DEFAULT true,
    "H6" boolean DEFAULT true,
    "H7" boolean DEFAULT true,
    "H8" boolean DEFAULT true,
    "H9" boolean DEFAULT true,
    "H10" boolean DEFAULT true,
    "HS1" boolean DEFAULT true,
    "HS2" boolean DEFAULT true,
    "HS3" boolean DEFAULT true,
    "HS4" boolean DEFAULT true,
    "H0" boolean DEFAULT true,
    "HS0" boolean DEFAULT true,
    "H11" boolean DEFAULT true,
    "H12" boolean DEFAULT true,
	CONSTRAINT "HORARIO_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Horario" OWNER TO moladmin;
GRANT ALL ON TABLE "Horario" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Instructor_Promocion" 
( 
	"OID" bigserial NOT NULL,
	"OID_INSTRUCTOR" bigint NOT NULL,
    "OID_PROMOCION" bigint NOT NULL,
	CONSTRAINT "INSTRUCTOR_PROMOCION_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Instructor_Promocion" OWNER TO moladmin;
GRANT ALL ON TABLE "Instructor_Promocion" TO GROUP "MOLEQULE_ADMINISTRATOR";

/*CREATE TABLE "Empleado"
(
	"OID" bigserial NOT NULL,
	"OID_IMPUESTO" bigint,
	"TIPO" bigint DEFAULT 8,
	"CODIGO" varchar(255) NOT NULL UNIQUE,
	"SERIAL" int8 NOT NULL,
	"ESTADO" bigint DEFAULT 10,
	"NOMBRE" varchar(255),
	"APELLIDOS" varchar(255),
	"ALIAS" character varying(255) NOT NULL,
  	"ID" varchar(50),
	"TIPO_ID" int8 NOT NULL DEFAULT 0,
	"DIRECCION" varchar(255),
	"COD_POSTAL" varchar(255),
	"LOCALIDAD" varchar(255),
	"MUNICIPIO" varchar(255),
	"PROVINCIA" varchar(255),
	"PAIS" character varying(255),
  	"TELEFONO" varchar(255),
    "EMAIL" character varying(255),
	"FOTO" varchar(255),
	"PERFIL" int8 NOT NULL,
	"ACTIVO" bool DEFAULT true,
	"INICIO_CONTRATO" date,
	"FIN_CONTRATO" date,	
	"CUENTA_BANCARIA" character varying(255),
	"OID_CUENTA_BANCARIA_ASOCIADA" bigint DEFAULT 0,
	"CUENTA_CONTABLE" character varying(255),
	"MEDIO_PAGO" bigint DEFAULT 1,
	"FORMA_PAGO" bigint DEFAULT 1,
	"DIAS_PAGO" bigint,
	"CONTACTO" character varying(255),
	"NIVEL_ESTUDIOS" varchar(255),
	"OBSERVACIONES" text,
	"SUELDO_BRUTO" numeric(10,2) DEFAULT 0,
	"P_IRPF" numeric(10,2) DEFAULT 0,	
	CONSTRAINT "EMPLEADO_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Empleado" OWNER TO moladmin;
GRANT ALL ON TABLE "Empleado" TO GROUP "MOLEQULE_ADMINISTRATOR";*/

CREATE TABLE "MaterialDocente" 
( 
	"OID" bigserial NOT NULL,
	"OID_CURSO" bigint,
    "NOMBRE" character varying(255) NOT NULL,
    "OBSERVACIONES" text,
    "OID_MODULO" bigint,
	CONSTRAINT "MATERIAL_DOCENTE_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "MaterialDocente" OWNER TO moladmin;
GRANT ALL ON TABLE "MaterialDocente" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Material_Alumno" 
( 
	"OID" bigserial NOT NULL,
	"OID_MATERIAL" bigint NOT NULL,
    "OID_ALUMNO" bigint NOT NULL,
    "ENTREGADO" boolean,
	CONSTRAINT "MATERIAL_ALUMNO_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Material_Alumno" OWNER TO moladmin;
GRANT ALL ON TABLE "Material_Alumno" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Material_Plan" 
( 
	"OID" bigserial NOT NULL,
	"OID_MODULO" bigint NOT NULL,
    "OID_MATERIAL" bigint NOT NULL,
    "OID_REVISION" bigint NOT NULL,
	CONSTRAINT "MATERIAL_PLAN_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Material_Plan" OWNER TO moladmin;
GRANT ALL ON TABLE "Material_Plan" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Modulo" 
( 
	"OID" bigserial NOT NULL,
	"CODIGO" character varying(255) NOT NULL,
    "TEXTO" character varying(255),
    "NUMERO" bigint DEFAULT 11,
    "SERIAL" bigint,
    "ALIAS" character varying(255),
    "NUMERO_MODULO" character varying(255) NOT NULL,
    "NUMERO_ORDEN" character varying(255) DEFAULT '0',
	CONSTRAINT "MODULO_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Modulo" OWNER TO moladmin;
GRANT ALL ON TABLE "Modulo" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "ParteAsistencia" 
( 
	"OID" bigserial NOT NULL,
	"OBSERVACIONES" text,
    "OID_HORARIO" bigint DEFAULT 0 NOT NULL,
    "TEXTO" character varying(255),
    "DURACION" time without time zone,
    "SESIONES" character varying(255),
    "OID_INSTRUCTOR" bigint NOT NULL,
    "FECHA" date,
    "HORA" time without time zone,
    "TIPO" bigint DEFAULT 1 NOT NULL,
    "N_HORAS" character varying(255),
    "HORA_INICIO" character varying(255),
    "CONFIRMADA" boolean DEFAULT false,
    "OID_INSTRUCTOR_EFECTIVO" bigint DEFAULT 0,
	CONSTRAINT "PARTE_ASISTENCIA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "ParteAsistencia" OWNER TO moladmin;
GRANT ALL ON TABLE "ParteAsistencia" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "PlanEstudios" 
( 
	"OID" bigserial NOT NULL,
	"NOMBRE" character varying(255),
    "FECHA" date,
    "OBSERVACIONES" text,
    "OID_PRODUCTO" bigint DEFAULT 1 NOT NULL,
    "OID_SERIE" bigint DEFAULT 1 NOT NULL,
	CONSTRAINT "PLAN_ESTUDIOS_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "PlanEstudios" OWNER TO moladmin;
GRANT ALL ON TABLE "PlanEstudios" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "PlanExtra" 
( 
	"OID" bigserial NOT NULL,
	"NOMBRE" character varying(255),
    "FECHA" date,
    "OBSERVACIONES" text,
    "OID_PRODUCTO" bigint DEFAULT 1 NOT NULL,
    "OID_SERIE" bigint DEFAULT 1 NOT NULL,
	CONSTRAINT "PLAN_EXTRA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "PlanExtra" OWNER TO moladmin;
GRANT ALL ON TABLE "PlanExtra" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "PlantillaExamen" 
( 
	"OID" bigserial NOT NULL,
	"OID_MODULO" bigint NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "SERIAL" bigint NOT NULL,
    "IDIOMA" character varying(255) NOT NULL,
    "DESARROLLO" boolean DEFAULT false,
    "N_PREGUNTAS" bigint NOT NULL,
    "NOMBRE" character varying,
	CONSTRAINT "PLANTILLA_EXAMEN_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "PlantillaExamen" OWNER TO moladmin;
GRANT ALL ON TABLE "PlantillaExamen" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Pregunta" 
( 
	"OID" bigserial NOT NULL,
	"OID_MODULO" bigint NOT NULL,
    "OID_TEMA" bigint NOT NULL,
    "NIVEL" bigint,
    "FECHA_ALTA" date,
    "FECHA_PUBLICACION" date,
    "TEXTO" character varying,
    "TIPO" character varying(255),
    "IMAGEN" character varying(255),
    "OBSERVACIONES" text,
    "FECHA_DISPONIBILIDAD" date,
    "IDIOMA" character varying(255),
    "ACTIVA" boolean,
    "REVISADA" boolean,
    "IMAGEN_GRANDE" boolean,
    "BLOQUEADA" boolean DEFAULT false,
    "OID_SUBMODULO" bigint NOT NULL,
    "OID_OLD" bigint DEFAULT 0 NOT NULL,
    "SERIAL" bigint DEFAULT 0,
    "CODIGO" character varying(255),
    "RESERVADA" boolean DEFAULT false,
	CONSTRAINT "PREGUNTA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Pregunta" OWNER TO moladmin;
GRANT ALL ON TABLE "Pregunta" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "PreguntaExamen" 
( 
	"OID" bigserial NOT NULL,
	"OID_EXAMEN" bigint NOT NULL,
    "OID_MODULO" bigint NOT NULL,
    "OID_TEMA" bigint NOT NULL,
    "NIVEL" bigint,
    "FECHA_ALTA" date,
    "FECHA_PUBLICACION" date,
    "TEXTO" character varying,
    "TIPO" character varying(255),
    "IMAGEN" character varying,
    "IDIOMA" character varying(255),
    "IMAGEN_GRANDE" boolean DEFAULT false,
    "OBSERVACIONES" character varying DEFAULT '',
    "ORDEN" bigint,
    "OID_SUBMODULO_OLD" bigint,
    "CODIGO_SUBMODULO" character varying(255) DEFAULT '',
    "OID_PREGUNTA_OLD" bigint,
    "OID_PREGUNTA" bigint,
    "ANULADA" boolean DEFAULT false,
	CONSTRAINT "PREGUNTAEXAMEN_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "PreguntaExamen" OWNER TO moladmin;
GRANT ALL ON TABLE "PreguntaExamen" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Pregunta_Examen" 
( 
	"OID" bigserial NOT NULL,
	"OID_PREGUNTA" bigint NOT NULL,
    "OID_EXAMEN" bigint NOT NULL,
	CONSTRAINT "Pregunta_Examen_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Pregunta_Examen" OWNER TO moladmin;
GRANT ALL ON TABLE "Pregunta_Examen" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Preguntas_Plantilla" 
( 
	"OID" bigserial NOT NULL,
	"OID_PLANTILLA" bigint NOT NULL,
    "OID_SUBMODULO" bigint NOT NULL,
    "N_PREGUNTAS" bigint,
    "OID_TEMA" bigint NOT NULL,
	CONSTRAINT "PREGUNTAS_PLANTILLA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Preguntas_Plantilla" OWNER TO moladmin;
GRANT ALL ON TABLE "Preguntas_Plantilla" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Promocion" 
( 
	"OID" bigserial NOT NULL,
	"OID_PLAN" bigint NOT NULL,
    "NOMBRE" character varying(255) NOT NULL,
    "NUMERO" character varying(255) NOT NULL,
    "OBSERVACIONES" text,
    "FECHA_INICIO" date NOT NULL,
    "FECHA_FIN" date,
    "INICIO_CLASES" date,
    "H1" boolean DEFAULT true,
    "H2" boolean DEFAULT true,
    "H3" boolean DEFAULT true,
    "H4" boolean DEFAULT true,
    "H5" boolean DEFAULT true,
    "H6" boolean DEFAULT true,
    "H7" boolean DEFAULT true,
    "H8" boolean DEFAULT true,
    "H9" boolean DEFAULT true,
    "H10" boolean DEFAULT true,
    "HS1" boolean DEFAULT true,
    "HS2" boolean DEFAULT true,
    "HS3" boolean DEFAULT true,
    "HS4" boolean DEFAULT true,
    "H0" boolean DEFAULT true,
    "HS0" boolean DEFAULT true,
    "H11" boolean DEFAULT true,
    "H12" boolean DEFAULT true,
    "OID_PLAN_EXTRA" bigint,
	CONSTRAINT "PROMOCION_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Promocion" OWNER TO moladmin;
GRANT ALL ON TABLE "Promocion" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Respuesta" 
( 
	"OID" bigserial NOT NULL,
	"OID_PREGUNTA" bigint,
    "TEXTO" character varying,
    "OPCION" character varying(255),
    "CORRECTA" boolean,
    "OID_OLD" bigint,
    "SERIAL" bigint DEFAULT 0,
    "CODIGO" character varying(255),
    "OID_PREGUNTA_OLD" bigint,
	CONSTRAINT "RESPUESTA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Respuesta" OWNER TO moladmin;
GRANT ALL ON TABLE "Respuesta" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "RespuestaExamen" 
( 
	"OID" bigserial NOT NULL,
	"OID_PREGUNTA" bigint DEFAULT 0,
    "TEXTO" character varying,
    "OPCION" character varying(255),
    "CORRECTA" boolean,
    "OID_PREGUNTA_OLD" bigint,
    "OID_RESPUESTA_OLD" bigint,
    "OID_EXAMEN" bigint,
    "OID_RESPUESTA" bigint,
	CONSTRAINT "RESPUESTA_EXAMEN_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "RespuestaExamen" OWNER TO moladmin;
GRANT ALL ON TABLE "RespuestaExamen" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Respuesta_Alumno_Examen" 
( 
	"OID" bigserial NOT NULL,
	"OID_ALUMNO_EXAMEN" bigint NOT NULL,
    "OID_PREGUNTA_EXAMEN" bigint NOT NULL,
    "OPCION" character varying(255),
    "ORDEN" bigint NOT NULL,
    "CORRECTA" boolean DEFAULT false,
    "CALIFICACION" numeric(10,2) DEFAULT 0,
	CONSTRAINT "RESPUESTA_ALUMNO_EXAMEN_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Respuesta_Alumno_Examen" OWNER TO moladmin;
GRANT ALL ON TABLE "Respuesta_Alumno_Examen" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "RevisionMaterial" 
( 
	"OID" bigserial NOT NULL,
	"OID_MATERIAL" bigint NOT NULL,
    "VERSION" character varying(255),
    "FECHA" date,
    "AUTOR" character varying(255),
    "OBSERVACIONES" text,
	CONSTRAINT "REVISION_MATERIAL_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "RevisionMaterial" OWNER TO moladmin;
GRANT ALL ON TABLE "RevisionMaterial" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Sesion" 
( 
	"OID" bigserial NOT NULL,
	"OID_HORARIO" bigint NOT NULL,
    "OID_CLASE_TEORICA" bigint NOT NULL,
    "OID_CLASE_PRACTICA" bigint NOT NULL,
    "OID_CLASE_EXTRA" bigint NOT NULL,
    "OID_PROFESOR" bigint NOT NULL,
    "FECHA" date,
    "OBSERVACIONES" text,
    "GRUPO" bigint NOT NULL,
    "ESTADO" bigint,
    "HORA" time without time zone,
    "FORZADA" boolean,
	CONSTRAINT "SESION_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Sesion" OWNER TO moladmin;
GRANT ALL ON TABLE "Sesion" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Sesion_Promocion" 
( 
	"OID" bigserial NOT NULL,
	"OID_PROMOCION" bigint NOT NULL,
    "HORA_INICIO" time without time zone,
    "N_HORAS" bigint NOT NULL,
    "SABADO" boolean DEFAULT false,
    "TIPO" bigint NOT NULL,
	CONSTRAINT "Sesion_Promocion_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Sesion_Promocion" OWNER TO moladmin;
GRANT ALL ON TABLE "Sesion_Promocion" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "SesionCronograma"
(
	"OID" bigserial NOT NULL,
	"OID_CRONOGRAMA" bigint NOT NULL,
	"OID_CLASE_TEORICA" bigint NOT NULL,
    "OID_CLASE_PRACTICA" bigint NOT NULL,
    "SEMANA" bigint NOT NULL,
    "DIA" bigint NOT NULL,
    "TURNO" bigint NOT NULL,
    "NUMERO" bigint,
    "TEXTO" character varying(255),
	CONSTRAINT "SESION_CRONOGRAMA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "SesionCronograma" OWNER TO moladmin;
GRANT ALL ON TABLE "SesionCronograma" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Submodulo" 
( 
	"OID" bigserial NOT NULL,
	"CODIGO" character varying(255) NOT NULL,
    "OID_MODULO" bigint NOT NULL,
    "TEXTO" character varying(255),
    "CODIGO_ORDEN" character varying(255),
	CONSTRAINT "SUBMODULO_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Submodulo" OWNER TO moladmin;
GRANT ALL ON TABLE "Submodulo" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Submodulo_Instructor" 
( 
	"OID" bigserial NOT NULL,
	"OID_INSTRUCTOR" bigint NOT NULL,
    "OID_SUBMODULO" bigint NOT NULL,
    "OID_INSTRUCTOR_SUPLENTE" bigint NOT NULL,
	"FECHA_INICIO" date DEFAULT '1999-12-31',
	"FECHA_FIN" date DEFAULT '2999-01-01',
	CONSTRAINT "SUBMODULO_INSTRUCTOR_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Submodulo_Instructor" OWNER TO moladmin;
GRANT ALL ON TABLE "Submodulo_Instructor" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Submodulo_Instructor_Promocion" ( 
	"OID" bigserial NOT NULL,
	"OID_SUBMODULO" bigint NOT NULL,
    "OID_INSTRUCTOR" bigint NOT NULL,
    "PRIORIDAD" bigint,
    "OID_PROMOCION" bigint DEFAULT 7 NOT NULL,
    "OID_INSTRUCTOR_PROMOCION" bigint NOT NULL,
	CONSTRAINT "SUBMODULO_INSTRUCTOR_PROMOCION_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Submodulo_Instructor_Promocion" OWNER TO moladmin;
GRANT ALL ON TABLE "Submodulo_Instructor_Promocion" TO GROUP "MOLEQULE_ADMINISTRATOR";

CREATE TABLE "Tema" 
( 
	"OID" bigserial NOT NULL,
	"OID_SUBMODULO" bigint NOT NULL,
    "CODIGO" character varying(255) NOT NULL,
    "NOMBRE" character varying(255) NOT NULL,
    "CODIGO_ORDEN" character varying(255) NOT NULL,
    "OID_MODULO" bigint NOT NULL,
    "NIVEL" bigint DEFAULT 0,
    "DESARROLLO" boolean DEFAULT false,
	CONSTRAINT "TEMA_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Tema" OWNER TO moladmin;
GRANT ALL ON TABLE "Tema" TO GROUP "MOLEQULE_ADMINISTRATOR";

-- FOREIGN KEYS
ALTER TABLE ONLY "Alumno_Examen"
    ADD CONSTRAINT "Alumno_Examen_OID_ALUMNO_fkey" FOREIGN KEY ("OID_ALUMNO") REFERENCES "Alumno"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Alumno_Examen"
    ADD CONSTRAINT "Alumno_Examen_OID_EXAMEN_fkey" FOREIGN KEY ("OID_EXAMEN") REFERENCES "Examen"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Alumno_Parte"
    ADD CONSTRAINT "Alumno_Parte_OID_ALUMNO_fkey" FOREIGN KEY ("OID_ALUMNO") REFERENCES "Alumno"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Alumno_Parte"
    ADD CONSTRAINT "Alumno_Parte_OID_PARTE_fkey" FOREIGN KEY ("OID_PARTE") REFERENCES "ParteAsistencia"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "ClaseExtra"
    ADD CONSTRAINT "ClaseExtra_OID_MODULO_fkey" FOREIGN KEY ("OID_MODULO") REFERENCES "Modulo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "ClaseExtra"
    ADD CONSTRAINT "ClaseExtra_OID_PLAN_fkey" FOREIGN KEY ("OID_PLAN") REFERENCES "PlanExtra"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "ClaseExtra"
    ADD CONSTRAINT "ClaseExtra_OID_SUBMODULO_fkey" FOREIGN KEY ("OID_SUBMODULO") REFERENCES "Submodulo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "ClasePractica"
    ADD CONSTRAINT "ClasePractica_OID_MODULO_fkey" FOREIGN KEY ("OID_MODULO") REFERENCES "Modulo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

	ALTER TABLE ONLY "ClasePractica"
    ADD CONSTRAINT "ClasePractica_OID_PLAN_fkey" FOREIGN KEY ("OID_PLAN") REFERENCES "PlanEstudios"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "ClasePractica"
    ADD CONSTRAINT "ClasePractica_OID_SUBMODULO_fkey" FOREIGN KEY ("OID_SUBMODULO") REFERENCES "Submodulo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "ClaseTeorica"
    ADD CONSTRAINT "ClaseTeorica_OID_MODULO_fkey" FOREIGN KEY ("OID_MODULO") REFERENCES "Modulo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "ClaseTeorica"
    ADD CONSTRAINT "ClaseTeorica_OID_PLAN_fkey" FOREIGN KEY ("OID_PLAN") REFERENCES "PlanEstudios"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "ClaseTeorica"
    ADD CONSTRAINT "ClaseTeorica_OID_SUBMODULO_fkey" FOREIGN KEY ("OID_SUBMODULO") REFERENCES "Submodulo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Clase_Parte"
    ADD CONSTRAINT "Clase_Parte_OID_PARTE_fkey" FOREIGN KEY ("OID_PARTE") REFERENCES "ParteAsistencia"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Convocatoria_Curso"
    ADD CONSTRAINT "Convocatoria_Curso_OID_CURSO_fkey" FOREIGN KEY ("OID_CURSO") REFERENCES "Curso"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Cronograma"
    ADD CONSTRAINT "Cronograma_OID_PLAN_fkey" FOREIGN KEY ("OID_PLAN") REFERENCES "PlanEstudios"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "CursoFormacion"
    ADD CONSTRAINT "CursoFormacion_OID_PROFESOR_fkey" FOREIGN KEY ("OID_PROFESOR") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Curso_Instructor"
    ADD CONSTRAINT "Curso_Instructor_OID_CURSO_fkey" FOREIGN KEY ("OID_CURSO") REFERENCES "Curso"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Curso_Instructor"
    ADD CONSTRAINT "Curso_Instructor_OID_PROFESOR_fkey" FOREIGN KEY ("OID_PROFESOR") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Disponibilidad"
    ADD CONSTRAINT "Disponibilidad_OID_INSTRUCTOR_fkey" FOREIGN KEY ("OID_INSTRUCTOR") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Examen"
    ADD CONSTRAINT "Examen_OID_MODULO_fkey" FOREIGN KEY ("OID_MODULO") REFERENCES "Modulo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "ReciboAlumno"
    ADD CONSTRAINT "FK_ReciboAlumno_Alumno" FOREIGN KEY ("OID_ALUMNO") REFERENCES "Alumno"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;
	
ALTER TABLE ONLY "Historia"
    ADD CONSTRAINT "Historia_OID_PREGUNTA_fkey" FOREIGN KEY ("OID_PREGUNTA") REFERENCES "Pregunta"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Horario"
    ADD CONSTRAINT "Horario_OID_PLAN_fkey" FOREIGN KEY ("OID_PLAN") REFERENCES "PlanEstudios"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Horario"
    ADD CONSTRAINT "Horario_OID_PROMOCION_fkey" FOREIGN KEY ("OID_PROMOCION") REFERENCES "Promocion"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Material_Alumno"
    ADD CONSTRAINT "Material_Alumno_OID_ALUMNO_fkey" FOREIGN KEY ("OID_ALUMNO") REFERENCES "Alumno"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Material_Alumno"
    ADD CONSTRAINT "Material_Alumno_OID_MATERIAL_fkey" FOREIGN KEY ("OID_MATERIAL") REFERENCES "MaterialDocente"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Material_Plan"
    ADD CONSTRAINT "Material_Plan_OID_MATERIAL_fkey" FOREIGN KEY ("OID_MATERIAL") REFERENCES "MaterialDocente"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "ParteAsistencia"
    ADD CONSTRAINT "ParteAsistencia_OID_HORARIO_fkey" FOREIGN KEY ("OID_HORARIO") REFERENCES "Horario"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "ParteAsistencia"
    ADD CONSTRAINT "ParteAsistencia_OID_INSTRUCTOR_fkey" FOREIGN KEY ("OID_INSTRUCTOR") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "PreguntaExamen"
    ADD CONSTRAINT "PreguntaExamen_OID_EXAMEN_fkey" FOREIGN KEY ("OID_EXAMEN") REFERENCES "Examen"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "PreguntaExamen"
    ADD CONSTRAINT "PreguntaExamen_OID_MODULO_fkey" FOREIGN KEY ("OID_MODULO") REFERENCES "Modulo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "PreguntaExamen"
    ADD CONSTRAINT "PreguntaExamen_OID_TEMA_fkey" FOREIGN KEY ("OID_TEMA") REFERENCES "Tema"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Pregunta_Examen"
    ADD CONSTRAINT "Pregunta_Examen_OID_EXAMEN_fkey" FOREIGN KEY ("OID_EXAMEN") REFERENCES "Examen"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Pregunta_Examen"
    ADD CONSTRAINT "Pregunta_Examen_OID_PREGUNTA_fkey" FOREIGN KEY ("OID_PREGUNTA") REFERENCES "Pregunta"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Pregunta"
    ADD CONSTRAINT "Pregunta_OID_MODULO_fkey" FOREIGN KEY ("OID_MODULO") REFERENCES "Modulo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Pregunta"
    ADD CONSTRAINT "Pregunta_OID_TEMA_fkey" FOREIGN KEY ("OID_TEMA") REFERENCES "Tema"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Promocion"
    ADD CONSTRAINT "Promocion_OID_PLAN_fkey" FOREIGN KEY ("OID_PLAN") REFERENCES "PlanEstudios"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Respuesta_Alumno_Examen"
    ADD CONSTRAINT "Respuesta_Alumno_Examen_OID_ALUMNO_EXAMEN_fkey" FOREIGN KEY ("OID_ALUMNO_EXAMEN") REFERENCES "Alumno_Examen"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Respuesta_Alumno_Examen"
    ADD CONSTRAINT "Respuesta_Alumno_Examen_OID_PREGUNTA_EXAMEN_fkey" FOREIGN KEY ("OID_PREGUNTA_EXAMEN") REFERENCES "PreguntaExamen"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Respuesta"
    ADD CONSTRAINT "Respuesta_OID_PREGUNTA_fkey" FOREIGN KEY ("OID_PREGUNTA") REFERENCES "Pregunta"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "RevisionMaterial"
    ADD CONSTRAINT "RevisionMaterial_OID_MATERIAL_fkey" FOREIGN KEY ("OID_MATERIAL") REFERENCES "MaterialDocente"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "SesionCronograma"
    ADD CONSTRAINT "SesionCronograma_OID_CRONOGRAMA_fkey" FOREIGN KEY ("OID_CRONOGRAMA") REFERENCES "Cronograma"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Sesion"
    ADD CONSTRAINT "Sesion_OID_HORARIO_fkey" FOREIGN KEY ("OID_HORARIO") REFERENCES "Horario"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Submodulo_Instructor_Promocion"
    ADD CONSTRAINT "Submodulo_Instructor_OID_INSTRUCTOR_fkey" FOREIGN KEY ("OID_INSTRUCTOR") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Submodulo_Instructor_Promocion"
    ADD CONSTRAINT "Submodulo_Instructor_OID_SUBMODULO_fkey" FOREIGN KEY ("OID_SUBMODULO") REFERENCES "Submodulo"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "PlanEstudios"
    ADD CONSTRAINT "fk_PLAN_ESTUDIOS_PRODUCTO" FOREIGN KEY ("OID_PRODUCTO") REFERENCES "Producto"("OID") ON UPDATE CASCADE;

ALTER TABLE ONLY "PlanEstudios"
    ADD CONSTRAINT "fk_PLAN_ESTUDIOS_SERIE" FOREIGN KEY ("OID_SERIE") REFERENCES "Serie"("OID") ON UPDATE CASCADE;

ALTER TABLE ONLY "PlanExtra"
    ADD CONSTRAINT "fk_PLAN_EXTRA_PRODUCTO" FOREIGN KEY ("OID_PRODUCTO") REFERENCES "Producto"("OID") ON UPDATE CASCADE;

ALTER TABLE ONLY "PlanExtra"
    ADD CONSTRAINT "fk_PLAN_EXTRA_SERIE" FOREIGN KEY ("OID_SERIE") REFERENCES "Serie"("OID") ON UPDATE CASCADE;

ALTER TABLE ONLY "Alumno_Curso"
    ADD CONSTRAINT fk_alumno_convocatoria_curso FOREIGN KEY ("OID_CONVOCATORIA") REFERENCES "Convocatoria_Curso"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Alumno_Convocatoria"
    ADD CONSTRAINT fk_alumno_convocatoria_curso FOREIGN KEY ("OID_CONVOCATORIA") REFERENCES "Convocatoria_Curso"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Alumno_Practica"
    ADD CONSTRAINT fk_alumno_practica_alumno FOREIGN KEY ("OID_ALUMNO") REFERENCES "Alumno"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Alumno_Practica"
    ADD CONSTRAINT fk_alumno_practica_clasepractica FOREIGN KEY ("OID_CLASE_PRACTICA") REFERENCES "ClasePractica"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Alumno_Practica"
    ADD CONSTRAINT fk_alumno_practica_parte_asistencia FOREIGN KEY ("OID_PARTE") REFERENCES "ParteAsistencia"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Alumno_Promocion"
    ADD CONSTRAINT fk_alumno_promocion_alumno FOREIGN KEY ("OID_ALUMNO") REFERENCES "Alumno"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Alumno_Promocion"
    ADD CONSTRAINT fk_alumno_promocion_promocion FOREIGN KEY ("OID_PROMOCION") REFERENCES "Promocion"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Concepto_Parte"
    ADD CONSTRAINT fk_concepto_parte_concepto FOREIGN KEY ("OID_CONCEPTO") REFERENCES "ConceptoAlbaranProveedor"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Concepto_Parte"
    ADD CONSTRAINT fk_concepto_parte_parte FOREIGN KEY ("OID_PARTE") REFERENCES "ParteAsistencia"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Curso_Cliente"
    ADD CONSTRAINT fk_curso_cliente_curso FOREIGN KEY ("OID_CURSO") REFERENCES "Curso"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;
	
ALTER TABLE ONLY "Examen_Promocion"
    ADD CONSTRAINT "Examen_Promocion_UNIQUE_key" UNIQUE ("OID_EXAMEN", "OID_PROMOCION");

ALTER TABLE ONLY "Examen_Promocion"
    ADD CONSTRAINT "Examen_Promocion_OID_EXAMEN_fkey" FOREIGN KEY ("OID_EXAMEN") REFERENCES "Examen"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Examen_Promocion"
    ADD CONSTRAINT "Examen_Promocion_OID_PROMOCION_fkey" FOREIGN KEY ("OID_PROMOCION") REFERENCES "Promocion"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;
	
ALTER TABLE ONLY "Instructor_Promocion"
    ADD CONSTRAINT fk_instructor_promocion_instructor FOREIGN KEY ("OID_INSTRUCTOR") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Instructor_Promocion"
    ADD CONSTRAINT fk_instructor_promocion_promocion FOREIGN KEY ("OID_PROMOCION") REFERENCES "Promocion"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Material_Plan"
    ADD CONSTRAINT fk_material_plan_planestudios FOREIGN KEY ("OID_MODULO") REFERENCES "Modulo"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Material_Plan"
    ADD CONSTRAINT fk_material_plan_revision FOREIGN KEY ("OID_REVISION") REFERENCES "RevisionMaterial"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "PlantillaExamen"
    ADD CONSTRAINT fk_plantilla_examen_modulo FOREIGN KEY ("OID_MODULO") REFERENCES "Modulo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Preguntas_Plantilla"
    ADD CONSTRAINT fk_preguntas_plantilla_plantilla FOREIGN KEY ("OID_PLANTILLA") REFERENCES "PlantillaExamen"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Preguntas_Plantilla"
    ADD CONSTRAINT fk_preguntas_plantilla_submodulo FOREIGN KEY ("OID_SUBMODULO") REFERENCES "Submodulo"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Preguntas_Plantilla"
    ADD CONSTRAINT fk_preguntas_plantilla_tema FOREIGN KEY ("OID_TEMA") REFERENCES "Tema"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Submodulo_Instructor"
    ADD CONSTRAINT fk_submodulo_instructor_instructor FOREIGN KEY ("OID_INSTRUCTOR") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Submodulo_Instructor"
    ADD CONSTRAINT fk_submodulo_instructor_instructor_suplente FOREIGN KEY ("OID_INSTRUCTOR_SUPLENTE") REFERENCES "Empleado"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Submodulo_Instructor_Promocion"
    ADD CONSTRAINT fk_submodulo_instructor_promocion FOREIGN KEY ("OID_INSTRUCTOR_PROMOCION") REFERENCES "Instructor_Promocion"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Submodulo_Instructor_Promocion"
    ADD CONSTRAINT fk_submodulo_instructor_promocion_promocion FOREIGN KEY ("OID_PROMOCION") REFERENCES "Promocion"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Submodulo_Instructor"
    ADD CONSTRAINT fk_submodulo_instructor_submodulo FOREIGN KEY ("OID_SUBMODULO") REFERENCES "Submodulo"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Submodulo"
    ADD CONSTRAINT fk_submodulo_modulo FOREIGN KEY ("OID_MODULO") REFERENCES "Modulo"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Tema"
    ADD CONSTRAINT fk_tema_modulo FOREIGN KEY ("OID_MODULO") REFERENCES "Modulo"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE ONLY "Tema"
    ADD CONSTRAINT fk_tema_submodulo FOREIGN KEY ("OID_SUBMODULO") REFERENCES "Submodulo"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

--Create indexes
ALTER TABLE ONLY "Alumno"
    ADD CONSTRAINT "Alumno_N_EXPEDIENTE_key" UNIQUE ("N_EXPEDIENTE");

ALTER TABLE ONLY "Alumno"
    ADD CONSTRAINT "Alumno_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Convocatoria_Curso"
    ADD CONSTRAINT "Convocatoria_Curso_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Convocatoria_Curso"
    ADD CONSTRAINT "Convocatoria_Curso_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Curso"
    ADD CONSTRAINT "Curso_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Curso"
    ADD CONSTRAINT "Curso_SERIAL_key" UNIQUE ("SERIAL");

ALTER TABLE ONLY "Empleado"
    ADD CONSTRAINT "Instructores_ALIAS_key" UNIQUE ("ALIAS");

ALTER TABLE ONLY "Examen_Promocion"
    ADD CONSTRAINT "Examen_Promocion_UNIQUE_key" UNIQUE ("OID_EXAMEN", "OID_PROMOCION");

ALTER TABLE ONLY "Material_Alumno"
    ADD CONSTRAINT "Material_Alumno_OID_MATERIAL_key" UNIQUE ("OID_MATERIAL", "OID_ALUMNO");

ALTER TABLE ONLY "Modulo"
    ADD CONSTRAINT "Modulo_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Submodulo"
    ADD CONSTRAINT "Submodulo_CODIGO_key" UNIQUE ("CODIGO");

ALTER TABLE ONLY "Alumno_Examen"
    ADD CONSTRAINT "UQ_Alumno_Examen_NOTA_EXAMEN" UNIQUE ("OID_ALUMNO", "OID_EXAMEN");
	
ALTER TABLE ONLY "Clase_Parte"
    ADD CONSTRAINT "UQ_CLASE_PARTE_OID_CLASE_GRUPO" UNIQUE ("OID_CLASE", "GRUPO", "OID_PARTE");

ALTER TABLE ONLY "Submodulo_Instructor_Promocion"
    ADD CONSTRAINT uk_submodulo_instructor_promocion UNIQUE ("OID_SUBMODULO", "OID_PROMOCION", "OID_INSTRUCTOR");

ALTER TABLE ONLY "Curso_Cliente"
    ADD CONSTRAINT uq_curso_cliente_oid UNIQUE ("OID");
	

