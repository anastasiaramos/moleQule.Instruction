/* UPDATE 4.4.0.0*/

SET SEARCH_PATH = "COMMON";

UPDATE "Variable" SET "VALUE" = '4.4.0.0' WHERE "NAME" = 'INSTRUCTION_DB_VERSION';

SET SEARCH_PATH = "0001";

CREATE TABLE "Clase_Parte"
(
  "OID" bigserial NOT NULL,
  "OID_CLASE" bigint NOT NULL,
  "OID_PARTE" bigint NOT NULL,
  "TIPO" bigint NOT NULL,
  "GRUPO" bigint NOT NULL,
  CONSTRAINT "Clase_Parte_pkey" PRIMARY KEY ("OID"),
  CONSTRAINT "Clase_Parte_OID_PARTE_fkey" FOREIGN KEY ("OID_PARTE")
      REFERENCES "ParteAsistencia" ("OID") MATCH SIMPLE
      ON UPDATE CASCADE ON DELETE CASCADE
)
WITH (
  OIDS=FALSE
);
ALTER TABLE "Clase_Parte" OWNER TO moladmin;
GRANT ALL ON TABLE "Clase_Parte" TO moladmin;
GRANT ALL ON TABLE "Clase_Parte" TO "MOLEQULE_ADMINISTRATOR";

ALTER TABLE "Clase_Parte" ADD CONSTRAINT "UQ_CLASE_PARTE_OID_CLASE_GRUPO" UNIQUE ("OID_CLASE", "GRUPO", "OID_PARTE");

--SELECT *
--		FROM "0001"."ParteAsistencia"
--		WHERE "OID" NOT IN (
--SELECT DISTINCT "OID_PARTE"
--				FROM (
INSERT INTO "0001"."Clase_Parte" ("OID_PARTE","OID_CLASE","TIPO","GRUPO")  
SELECT Q."OID_PARTE" AS "OID_PARTE", Q."OID_CLASE" AS "OID_CLASE", Q."TIPO" AS "TIPO", Q."GRUPO" AS "GRUPO"
FROM(
				SELECT ct."ALIAS" AS "ALIAS_CLASE", cast("OID_CLASE" as bigint) as "OID_CLASE", Q1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 1 AS "TIPO"
FROM (
	SELECT regexp_split_to_table( p1."SESIONES", ' ') AS "OID_CLASE", p1."OID" AS "OID_PARTE", p1."TEXTO" AS "TEXTO"
	FROM (
		SELECT P."OID", P."SESIONES", P."TEXTO"
		FROM "0001"."ParteAsistencia" AS P
		WHERE "OID" NOT IN (
				SELECT DISTINCT "OID_PARTE"
				FROM (
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 1 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClaseTeorica" AS ct
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND ct."OID" = cast(QUERY1."OID_CLASE" as bigint) AND ct."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 1 AS "GRUPO", 2 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' G1 ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClasePractica" AS cp
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND cp."OID" = cast(QUERY1."OID_CLASE" as bigint) AND cp."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 2 AS "GRUPO", 2 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' G2 ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClasePractica" AS cp
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND cp."OID" = cast(QUERY1."OID_CLASE" as bigint) AND cp."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 3 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClaseExtra" AS ce
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND ce."OID" = cast(QUERY1."OID_CLASE" as bigint) AND ce."ALIAS" = QUERY2."ALIAS_CLASE"
					ORDER BY "OID_PARTE", "OID_CLASE"
				) 
		AS QUERY)
	) AS p1) AS Q1,
"0001"."ClaseTeorica" AS ct
WHERE Q1."OID_CLASE" <> '' AND ct."OID" = cast(Q1."OID_CLASE" as bigint) AND position(ct."ALIAS" in Q1."TEXTO") > 0
UNION
SELECT cp."ALIAS" AS "ALIAS_CLASE", cast("OID_CLASE" as bigint) as "OID_CLASE", Q1."OID_PARTE" AS "OID_PARTE", 1 AS "GRUPO", 2 AS "TIPO"
FROM (
	SELECT regexp_split_to_table( p1."SESIONES", ' ') AS "OID_CLASE", p1."OID" AS "OID_PARTE", p1."TEXTO" AS "TEXTO"
	FROM (
		SELECT P."OID", P."SESIONES", P."TEXTO"
		FROM "0001"."ParteAsistencia" AS P
		WHERE "OID" NOT IN (
				SELECT DISTINCT "OID_PARTE"
				FROM (
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 1 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClaseTeorica" AS ct
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND ct."OID" = cast(QUERY1."OID_CLASE" as bigint) AND ct."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 1 AS "GRUPO", 2 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' G1 ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClasePractica" AS cp
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND cp."OID" = cast(QUERY1."OID_CLASE" as bigint) AND cp."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 2 AS "GRUPO", 2 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' G2 ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClasePractica" AS cp
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND cp."OID" = cast(QUERY1."OID_CLASE" as bigint) AND cp."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 3 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClaseExtra" AS ce
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND ce."OID" = cast(QUERY1."OID_CLASE" as bigint) AND ce."ALIAS" = QUERY2."ALIAS_CLASE"
					ORDER BY "OID_PARTE", "OID_CLASE"
				) 
		AS QUERY)
	) AS p1) AS Q1,
"0001"."ClasePractica" AS cp
WHERE Q1."OID_CLASE" <> '' AND cp."OID" = cast(Q1."OID_CLASE" as bigint) AND position(cp."ALIAS" in Q1."TEXTO") > 0
UNION
SELECT cp."ALIAS" AS "ALIAS_CLASE", cast("OID_CLASE" as bigint) as "OID_CLASE", Q1."OID_PARTE" AS "OID_PARTE", 2 AS "GRUPO", 2 AS "TIPO"
FROM (
	SELECT regexp_split_to_table( p1."SESIONES", ' ') AS "OID_CLASE", p1."OID" AS "OID_PARTE", p1."TEXTO" AS "TEXTO"
	FROM (
		SELECT P."OID", P."SESIONES", P."TEXTO"
		FROM "0001"."ParteAsistencia" AS P
		WHERE "OID" NOT IN (
				SELECT DISTINCT "OID_PARTE"
				FROM (
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 1 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClaseTeorica" AS ct
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND ct."OID" = cast(QUERY1."OID_CLASE" as bigint) AND ct."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 1 AS "GRUPO", 2 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' G1 ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClasePractica" AS cp
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND cp."OID" = cast(QUERY1."OID_CLASE" as bigint) AND cp."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 2 AS "GRUPO", 2 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' G2 ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClasePractica" AS cp
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND cp."OID" = cast(QUERY1."OID_CLASE" as bigint) AND cp."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 3 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClaseExtra" AS ce
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND ce."OID" = cast(QUERY1."OID_CLASE" as bigint) AND ce."ALIAS" = QUERY2."ALIAS_CLASE"
					ORDER BY "OID_PARTE", "OID_CLASE"
				) 
		AS QUERY)
	) AS p1) AS Q1,
"0001"."ClasePractica" AS cp
WHERE Q1."OID_CLASE" <> '' AND cp."OID" = cast(Q1."OID_CLASE" as bigint) AND position(cp."ALIAS" in Q1."TEXTO") > 0
UNION
SELECT ce."ALIAS" AS "ALIAS_CLASE", cast("OID_CLASE" as bigint) as "OID_CLASE", Q1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 1 AS "TIPO"
FROM (
	SELECT regexp_split_to_table( p1."SESIONES", ' ') AS "OID_CLASE", p1."OID" AS "OID_PARTE", p1."TEXTO" AS "TEXTO"
	FROM (
		SELECT P."OID", P."SESIONES", P."TEXTO"
		FROM "0001"."ParteAsistencia" AS P
		WHERE "OID" NOT IN (
				SELECT DISTINCT "OID_PARTE"
				FROM (
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 1 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClaseTeorica" AS ct
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND ct."OID" = cast(QUERY1."OID_CLASE" as bigint) AND ct."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 1 AS "GRUPO", 2 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' G1 ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClasePractica" AS cp
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND cp."OID" = cast(QUERY1."OID_CLASE" as bigint) AND cp."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 2 AS "GRUPO", 2 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' G2 ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClasePractica" AS cp
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND cp."OID" = cast(QUERY1."OID_CLASE" as bigint) AND cp."ALIAS" = QUERY2."ALIAS_CLASE"
					UNION
					SELECT "ALIAS_CLASE", "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 3 AS "TIPO"
					FROM (
						SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
					     (  SELECT regexp_split_to_table( p."TEXTO", ' ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
						FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
						"0001"."ClaseExtra" AS ce
					WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND ce."OID" = cast(QUERY1."OID_CLASE" as bigint) AND ce."ALIAS" = QUERY2."ALIAS_CLASE"
					ORDER BY "OID_PARTE", "OID_CLASE"
				) 
		AS QUERY)
	) AS p1) AS Q1,
"0001"."ClaseExtra" AS ce
WHERE Q1."OID_CLASE" <> '' AND ce."OID" = cast(Q1."OID_CLASE" as bigint) AND position(ce."ALIAS" in Q1."TEXTO") > 0
UNION
SELECT "ALIAS_CLASE", cast("OID_CLASE" as bigint) as "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 1 AS "TIPO"
FROM (
	SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
	FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
     (  SELECT regexp_split_to_table( p."TEXTO", ' ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
	FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
	"0001"."ClaseTeorica" AS ct
WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND ct."OID" = cast(QUERY1."OID_CLASE" as bigint) AND ct."ALIAS" = QUERY2."ALIAS_CLASE"
UNION
SELECT "ALIAS_CLASE", cast("OID_CLASE" as bigint) as "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 1 AS "GRUPO", 2 AS "TIPO"
FROM (
	SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
	FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
     (  SELECT regexp_split_to_table( p."TEXTO", ' G1 ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
	FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
	"0001"."ClasePractica" AS cp
WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND cp."OID" = cast(QUERY1."OID_CLASE" as bigint) AND cp."ALIAS" = QUERY2."ALIAS_CLASE"
UNION
SELECT "ALIAS_CLASE", cast("OID_CLASE" as bigint) as "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 2 AS "GRUPO", 2 AS "TIPO"
FROM (
	SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
	FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
     (  SELECT regexp_split_to_table( p."TEXTO", ' G2 ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
	FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
	"0001"."ClasePractica" AS cp
WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND cp."OID" = cast(QUERY1."OID_CLASE" as bigint) AND cp."ALIAS" = QUERY2."ALIAS_CLASE"
UNION
SELECT "ALIAS_CLASE", cast("OID_CLASE" as bigint) as "OID_CLASE", QUERY1."OID_PARTE" AS "OID_PARTE", 3 AS "GRUPO", 3 AS "TIPO"
FROM (
	SELECT regexp_split_to_table( p."SESIONES", ' ') AS "OID_CLASE", p."OID" AS "OID_PARTE"
	FROM "0001"."ParteAsistencia" AS p) AS QUERY1,
     (  SELECT regexp_split_to_table( p."TEXTO", ' ') AS "ALIAS_CLASE", p."OID" AS "OID_PARTE"
	FROM "0001"."ParteAsistencia" AS p) AS QUERY2,
	"0001"."ClaseExtra" AS ce
WHERE QUERY1."OID_PARTE" = QUERY2."OID_PARTE" AND QUERY1."OID_CLASE" <> '' AND ce."OID" = cast(QUERY1."OID_CLASE" as bigint) AND ce."ALIAS" = QUERY2."ALIAS_CLASE"
ORDER BY "OID_PARTE", "OID_CLASE")AS Q
--)AS TOTAL
--)
--ORDER BY "OID"