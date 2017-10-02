/* UPDATE 5.0.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '5.0.0.0' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

UPDATE "Entidad" SET "OBSERVACIONES" = 'Alumnos' WHERE "TIPO" = 'Alumno';
UPDATE "Entidad" SET "OBSERVACIONES" = 'Promociones' WHERE "TIPO" = 'Promocion';
UPDATE "Entidad" SET "OBSERVACIONES" = 'Cursos' WHERE "TIPO" = 'Curso';
UPDATE "Entidad" SET "OBSERVACIONES" = 'Módulos' WHERE "TIPO" = 'Modulo';
UPDATE "Entidad" SET "OBSERVACIONES" = 'Facturas de Instructor' WHERE "TIPO" = 'FacturaInstructor';

SET SEARCH_PATH = "0001";
