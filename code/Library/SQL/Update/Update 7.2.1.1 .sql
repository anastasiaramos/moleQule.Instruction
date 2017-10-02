/* UPDATE 7.2.1.1*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '7.2.1.1' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET SEARCH_PATH = "0001";

ALTER TABLE "SesionCronograma" ADD COLUMN "FECHA" date;
ALTER TABLE "SesionCronograma" ADD COLUMN "HORA" time without time zone;
