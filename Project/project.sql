SET SERVEROUTPUT ON;


CREATE TABLE CAINI(
id_caine NUMBER,
rasa VARCHAR2(255),
data_nastere VARCHAR2(255),
poza ORDImage,
semnatura_poza ORDImageSignature
);

--DROP TABLE CAINI;
CREATE OR REPLACE DIRECTORY DIRECTOR_LUCRU AS 'D:\Media';

--dau drepturi utilizatorului care vine din front end
GRANT READ ON DIRECTORY DIRECTOR_LUCRU TO PUBLIC WITH GRANT OPTION; --dau drepturi inafara bd pt a citi informatie

-- FAZA 1 PROIECT --
--inserare
CREATE OR REPLACE PROCEDURE PROCEDURA_INSERARE (v_id IN NUMBER, v_rasa IN VARCHAR2, v_data_nastere IN VARCHAR2, nume_fisier IN VARCHAR2) --ia calea din directorul de lucru, dar are nevoie de nume
IS
obj ORDImage;
ctx RAW(64):=NULL;
BEGIN

 --aloc spatiu
 INSERT INTO caini (id_caine,rasa,data_nastere,poza,semnatura_poza)
 VALUES(v_id,v_rasa,v_data_nastere,ORDImage.init(),ORDImageSignature.init());
 
 --import in obj
 SELECT poza INTO obj
 FROM caini
 WHERE id_caine=v_id FOR UPDATE;
 
 obj.importFrom(ctx,'file','DIRECTOR_LUCRU',nume_fisier); --am in obj imaginea
 
 --update din obj in poza din tabela
 UPDATE caini
 SET poza = obj
 WHERE id_caine=v_id;
 
 COMMIT;
END;

--afisare
CREATE OR REPLACE PROCEDURE PROCEDURA_AFISARE(v_id IN NUMBER, flux OUT BLOB)
IS
obj ORDImage; --preluare imagine
BEGIN

SELECT poza INTO obj
FROM caini
WHERE id_caine=v_id;

flux:=obj.getContent();--getContent returneaza continutul din atributul de tip ordimage

END;

--export
CREATE OR REPLACE PROCEDURE PROCEDURA_EXPORT(v_id IN NUMBER, nume_fisier IN VARCHAR2)
IS
obj ORDImage;
ctx RAW(64):=NULL;
BEGIN
--incarc in obj ceea ce contine tuplul curent in atributul poza
SELECT poza INTO obj
FROM caini
WHERE id_caine = v_id FOR UPDATE;

obj.export(ctx,'file','DIRECTOR_LUCRU',nume_fisier);
END;

--inserare de pe internet
DECLARE
obj ORDImage;
ctx RAW(64):=null;
BEGIN

INSERT INTO caini 
VALUES(3,'Saint-Bernard','12-MAR-2015',ORDSYS.ORDImage.init(), ORDSYS.ORDImageSignature.init());

SELECT poza INTO obj
FROM caini
WHERE id_caine=3 FOR UPDATE;

obj.importfrom(ctx,'http','http://cdn.working-dog.net/static/images/race/','113.jpg?v=5');

UPDATE caini
SET poza = obj
WHERE id_caine = 3;

COMMIT;

END;
/


--prelucrare imagini
DECLARE 
obj ORDImage;
BEGIN

SELECT poza INTO obj 
FROM caini
WHERE id_caine=2 FOR UPDATE;

obj.PROCESS('flip');

UPDATE caini
SET poza=obj
WHERE id_caine=2;

COMMIT;

END;
/