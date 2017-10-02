-- INSTRUCTION MODULE SCHEMA DATA SCRIPT

-- USERS PRIVILEGES

INSERT INTO "Privilege" ("OID_USER", "OID_ITEM", "READ", "CREATE", "MODIFY", "DELETE") 
	SELECT u."OID", i."OID", FALSE, FALSE, FALSE, FALSE 
	FROM "COMMON"."User" AS u, "COMMON"."SecureItem" AS i
	WHERE (u."OID", i."OID") NOT IN (SELECT "OID_USER", "OID_ITEM" FROM "Privilege");

-- INSERTS

INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('CRITERIO_PORCENTAJE_MAXIMO_FALTAS_MODULO', 'FALSE');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('CRITERIO_PORCENTAJE_MINIMO_EXAMEN_APROBADO', 'TRUE');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('HORA_FIN_DISPONIBILIDAD_MANANA', '7');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('HORA_FIN_DISPONIBILIDAD_TARDE1', '10');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('HORA_FIN_DISPONIBILIDAD_TARDE2', '13');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('HORA_INICIO_DISPONIBILIDAD_MANANA', '1');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('HORA_INICIO_DISPONIBILIDAD_TARDE1', '8');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('HORA_INICIO_DISPONIBILIDAD_TARDE2', '11');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('PORCENTAJE_MAXIMO_FALTAS_MODULO', '15');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('PORCENTAJE_MINIMO_EXAMEN_APROBADO', '75');
INSERT INTO "Setting" ("NAME" , "VALUE") VALUES ('MOSTRAR_INSTRUCTORES_AUTORIZADOS', 'FALSE');