﻿/* UPDATE 7.4.0.5*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '7.4.0.5' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET search_path to "0001";

INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('TIEMPO_PREGUNTA_DESARROLLO', '00:20:00');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('TIEMPO_PREGUNTA_TEST', '00:01:15');

SET search_path to "0002";

INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('TIEMPO_PREGUNTA_DESARROLLO', '00:20:00');
INSERT INTO "Setting" ("NAME", "VALUE") VALUES ('TIEMPO_PREGUNTA_TEST', '00:01:15');