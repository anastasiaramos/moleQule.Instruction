/* UPDATE 4.8.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '4.8.0.0' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET SEARCH_PATH = "0001";

ALTER TABLE "Promocion" ADD COLUMN "OID_PLAN_EXTRA" bigint;