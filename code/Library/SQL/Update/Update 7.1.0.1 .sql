/* UPDATE 7.1.0.1*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '7.1.0.1' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET SEARCH_PATH = "0001";

CREATE TABLE "Examen_Promocion"
( 
	"OID" bigserial NOT NULL,	
	"OID_EXAMEN" bigint NOT NULL,
    "OID_PROMOCION" bigint NOT NULL,
	CONSTRAINT "EXAMEN_PROMOCION_PK" PRIMARY KEY ("OID")
) WITHOUT OIDS;

ALTER TABLE "Examen_Promocion" OWNER TO moladmin;
GRANT ALL ON TABLE "Examen_Promocion" TO GROUP "MOLEQULE_ADMINISTRATOR";

ALTER TABLE ONLY "Examen_Promocion"
    ADD CONSTRAINT "Examen_Promocion_UNIQUE_key" UNIQUE ("OID_EXAMEN", "OID_PROMOCION");

ALTER TABLE ONLY "Examen_Promocion"
    ADD CONSTRAINT "Examen_Promocion_OID_EXAMEN_fkey" FOREIGN KEY ("OID_EXAMEN") REFERENCES "Examen"("OID") ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE ONLY "Examen_Promocion"
    ADD CONSTRAINT "Examen_Promocion_OID_PROMOCION_fkey" FOREIGN KEY ("OID_PROMOCION") REFERENCES "Promocion"("OID") ON UPDATE CASCADE ON DELETE RESTRICT;

ALTER TABLE "Alumno_Practica" DROP CONSTRAINT "UQ_Alumno_Practica_NOTA_PRACTICA";

