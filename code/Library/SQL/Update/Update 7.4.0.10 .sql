/* UPDATE 7.4.0.10*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '7.4.0.10' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET search_path to "0001";

ALTER TABLE "Disponibilidad" ADD COLUMN "PREDETERMINADO" boolean DEFAULT false;

SET search_path to "0002";

ALTER TABLE "Disponibilidad" ADD COLUMN "PREDETERMINADO" boolean DEFAULT false;