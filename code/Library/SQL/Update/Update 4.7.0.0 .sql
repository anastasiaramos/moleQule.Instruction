/* UPDATE 4.7.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '4.7.0.0' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET SEARCH_PATH = "0001";


CREATE TABLE "Alumno_Promocion"
( 
	"OID" bigserial NOT NULL,
	"OID_PROMOCION" int8 NOT NULL,
	"OID_ALUMNO" int8 NOT NULL,
	CONSTRAINT "ALUMNO_PROMOCION_PK" PRIMARY KEY ("OID")
)WITHOUT OIDS;

ALTER TABLE "Alumno_Promocion" OWNER TO moladmin;
GRANT ALL ON TABLE "Alumno_Promocion" TO GROUP "MOLEQULE_ADMINISTRATOR";


ALTER TABLE "Alumno_Promocion" ADD  CONSTRAINT fk_alumno_promocion_alumno FOREIGN KEY ("OID_ALUMNO") 
	REFERENCES "Alumno" ("OID") MATCH SIMPLE ON UPDATE CASCADE ON DELETE RESTRICT;	
ALTER TABLE "Alumno_Promocion" ADD  CONSTRAINT fk_alumno_promocion_promocion FOREIGN KEY ("OID_PROMOCION") 
	REFERENCES "Promocion" ("OID") MATCH SIMPLE ON UPDATE CASCADE ON DELETE RESTRICT;	


INSERT INTO "Alumno_Promocion" ("OID_ALUMNO", "OID_PROMOCION")  
SELECT "OID" AS "OID_ALUMNO", "OID_PROMOCION" AS "OID_PROMOCION"
FROM "Alumno";

ALTER TABLE "Alumno" DROP COLUMN "OID_PROMOCION";