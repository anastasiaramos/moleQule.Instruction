/* UPDATE 7.4.0.4*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '7.4.0.4' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET SEARCH_PATH to "0001";

CREATE TABLE "Incidencia_Cronograma"
( 
	"OID" bigserial NOT NULL,	
	"OID_CRONOGRAMA" int8 NOT NULL,
	"MOTIVO" character varying,
	"OBSERVACIONES" character varying,
	CONSTRAINT "Incidencia_Cronograma_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Incidencia_Cronograma" OWNER TO moladmin;
GRANT ALL ON TABLE "Incidencia_Cronograma" TO GROUP "MOLEQULE_ADMINISTRATOR";

ALTER TABLE "Incidencia_Cronograma" ADD  CONSTRAINT fk_incidencia_cronograma_cronograma
FOREIGN KEY ("OID_CRONOGRAMA") REFERENCES "Cronograma" ("OID") MATCH SIMPLE 
ON UPDATE CASCADE ON DELETE CASCADE;	

CREATE TABLE "Incidencia_Sesion_Cronograma"
( 
	"OID" bigserial NOT NULL,	
	"OID_INCIDENCIA" int8 NOT NULL,
	"OID_CLASE_TEORICA_PROGRAMADA" int8 DEFAULT 0,
	"OID_CLASE_PRACTICA_PROGRAMADA" int8 DEFAULT 0,
	"OID_CLASE_TEORICA_ASIGNADA" int8 DEFAULT 0,
	"OID_CLASE_PRACTICA_ASIGNADA" int8 DEFAULT 0,
	"FECHA_CLASE_PROGRAMADA" date,
	"FECHA_CLASE_ASIGNADA" date,
	"HORA_CLASE_PROGRAMADA" time without time zone,
	"HORA_CLASE_ASIGNADA" time without time zone,
	CONSTRAINT "Incidencia_Sesion_Cronograma_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Incidencia_Sesion_Cronograma" OWNER TO moladmin;
GRANT ALL ON TABLE "Incidencia_Sesion_Cronograma" TO GROUP "MOLEQULE_ADMINISTRATOR";

ALTER TABLE "Incidencia_Sesion_Cronograma" ADD  CONSTRAINT fk_incidencia_sesion_cronograma
FOREIGN KEY ("OID_INCIDENCIA") REFERENCES "Incidencia_Cronograma" ("OID") MATCH SIMPLE 
ON UPDATE CASCADE ON DELETE CASCADE;		

SET SEARCH_PATH to "0002";

CREATE TABLE "Incidencia_Cronograma"
( 
	"OID" bigserial NOT NULL,	
	"OID_CRONOGRAMA" int8 NOT NULL,
	"MOTIVO" character varying,
	"OBSERVACIONES" character varying,
	CONSTRAINT "Incidencia_Cronograma_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Incidencia_Cronograma" OWNER TO moladmin;
GRANT ALL ON TABLE "Incidencia_Cronograma" TO GROUP "MOLEQULE_ADMINISTRATOR";

ALTER TABLE "Incidencia_Cronograma" ADD  CONSTRAINT fk_incidencia_cronograma_cronograma
FOREIGN KEY ("OID_CRONOGRAMA") REFERENCES "Cronograma" ("OID") MATCH SIMPLE 
ON UPDATE CASCADE ON DELETE CASCADE;	

CREATE TABLE "Incidencia_Sesion_Cronograma"
( 
	"OID" bigserial NOT NULL,	
	"OID_INCIDENCIA" int8 NOT NULL,
	"OID_CLASE_TEORICA_PROGRAMADA" int8 DEFAULT 0,
	"OID_CLASE_PRACTICA_PROGRAMADA" int8 DEFAULT 0,
	"OID_CLASE_TEORICA_ASIGNADA" int8 DEFAULT 0,
	"OID_CLASE_PRACTICA_ASIGNADA" int8 DEFAULT 0,
	"FECHA_CLASE_PROGRAMADA" date,
	"FECHA_CLASE_ASIGNADA" date,
	"HORA_CLASE_PROGRAMADA" time without time zone,
	"HORA_CLASE_ASIGNADA" time without time zone,
	CONSTRAINT "Incidencia_Sesion_Cronograma_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Incidencia_Sesion_Cronograma" OWNER TO moladmin;
GRANT ALL ON TABLE "Incidencia_Sesion_Cronograma" TO GROUP "MOLEQULE_ADMINISTRATOR";

ALTER TABLE "Incidencia_Sesion_Cronograma" ADD  CONSTRAINT fk_incidencia_sesion_cronograma
FOREIGN KEY ("OID_INCIDENCIA") REFERENCES "Incidencia_Cronograma" ("OID") MATCH SIMPLE 
ON UPDATE CASCADE ON DELETE CASCADE;
