/* UPDATE 5.2.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '5.2.0.0' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET SEARCH_PATH = "0001";

ALTER TABLE "Alumno_Examen" ADD COLUMN "PRESENTADO" boolean DEFAULT FALSE;

UPDATE "Alumno_Examen" SET "PRESENTADO" = TRUE WHERE "CALIFICACION" <> 'No Presentado';

ALTER TABLE "Alumno_Examen" DROP COLUMN "OBSERVACIONES";
ALTER TABLE "Alumno_Examen" RENAME COLUMN "CALIFICACION" TO "OBSERVACIONES";
ALTER TABLE "Alumno_Examen" ADD COLUMN "CALIFICACION" numeric(10,2) DEFAULT 0;

UPDATE "Alumno_Examen" SET "CALIFICACION" = cast(replace(substr("OBSERVACIONES", 1, position('%' in "OBSERVACIONES")-1), ',', '.') as numeric(10,2)) 
WHERE "OBSERVACIONES" <> 'No Presentado' AND position('%' in "OBSERVACIONES") > 1;

INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('PORCENTAJE_MAXIMO_FALTAS_MODULO', '15');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('PORCENTAJE_MINIMO_EXAMEN_APROBADO', '75');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('CRITERIO_PORCENTAJE_MAXIMO_FALTAS_MODULO', 'FALSE');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('CRITERIO_PORCENTAJE_MINIMO_EXAMEN_APROBADO', 'TRUE');

ALTER TABLE "Respuesta_Alumno_Examen" ADD COLUMN "CALIFICACION" numeric(10,2) DEFAULT 0;


UPDATE "Respuesta_Alumno_Examen" SET "CALIFICACION" = (SELECT AE."CALIFICACION"
								FROM "Alumno_Examen" AS AE
								INNER JOIN "Examen" AS E ON (E."OID" = AE."OID_EXAMEN")
								WHERE E."DESARROLLO" = TRUE AND AE."PRESENTADO" = TRUE AND "OID_ALUMNO_EXAMEN" = AE."OID")


UPDATE "Alumno_Examen" SET "OBSERVACIONES" = '';