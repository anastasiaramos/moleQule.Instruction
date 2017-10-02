/* UPDATE 4.5.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '4.5.0.0' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET SEARCH_PATH = "0001";

CREATE TABLE "Sesion_Promocion"
(
  "OID" bigserial NOT NULL,
  "OID_PROMOCION" bigint NOT NULL,
  "HORA_INICIO" time without time zone,
  "N_HORAS" bigint NOT NULL,
  "SABADO" boolean DEFAULT false,
  "TIPO" bigint NOT NULL,
  CONSTRAINT "Sesion_Promocion_pkey" PRIMARY KEY ("OID")
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "Sesion_Promocion" OWNER TO moladmin;
GRANT ALL ON TABLE "Sesion_Promocion" TO moladmin;
GRANT ALL ON TABLE "Sesion_Promocion" TO "MOLEQULE_ADMINISTRATOR";