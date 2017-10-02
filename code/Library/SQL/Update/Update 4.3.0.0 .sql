/* UPDATE 4.3.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '4.3.0.0' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET SEARCH_PATH = "0001";

ALTER TABLE "Alumno_Examen" ADD CONSTRAINT "UQ_Alumno_Examen_NOTA_EXAMEN" UNIQUE ("OID_ALUMNO", "OID_EXAMEN");
ALTER TABLE "Alumno_Practica" ADD CONSTRAINT "UQ_Alumno_Practica_NOTA_PRACTICA" UNIQUE ("OID_ALUMNO", "OID_CLASE_PRACTICA");

