/* UPDATE 7.4.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '7.4.0.0' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET SEARCH_PATH to "0001";

INSERT INTO "Setting" ("NAME","VALUE") VALUES ('IMPRESION_EMPRESA_DEFAULT_BOOL','false');
INSERT INTO "Setting" ("NAME","VALUE") VALUES ('IMPRESION_EMPRESA_DEFAULT_OID', '0');