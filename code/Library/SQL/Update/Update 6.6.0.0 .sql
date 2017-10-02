/* UPDATE 6.6.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '6.6.0.0' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET SEARCH_PATH = "0001";

INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('MOSTRAR_INSTRUCTORES_AUTORIZADOS', 'FALSE');

ALTER TABLE "Submodulo_Instructor" DROP COLUMN "AUTORIZADO";
ALTER TABLE "Submodulo_Instructor" ADD COLUMN "FECHA_INICIO" date DEFAULT '1999-12-31';
ALTER TABLE "Submodulo_Instructor" ADD COLUMN "FECHA_FIN" date DEFAULT '2999-01-01';

