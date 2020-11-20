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
--flip
DECLARE 
obj ORDImage;
BEGIN

SELECT poza INTO obj 
FROM caini
WHERE id_caine=1 FOR UPDATE;

obj.PROCESS('flip');

UPDATE caini
SET poza=obj
WHERE id_caine=1;

COMMIT;

END;
/

--crop
DECLARE 
obj ORDImage;
BEGIN

SELECT poza INTO obj 
FROM caini
WHERE id_caine=2 FOR UPDATE;

obj.PROCESS('cut=10,10,60,60');

UPDATE caini
SET poza=obj
WHERE id_caine=2;

COMMIT;

END;
/


-- FAZA 2 PROIECT --
-- Generare semnaturi
CREATE OR REPLACE PROCEDURE PROCEDURA_GENERARE_SEMNATURI
IS
    currentImage ORDImage;
    currentSignature ORDImageSignature;
    ctx RAW(4000):=null;
BEGIN
   FOR i IN (SELECT id_caine FROM caini)
   LOOP
     SELECT s.poza, s.semnatura_poza 
     INTO currentImage,currentSignature
     FROM caini s
     WHERE s.id_caine=i.id_caine FOR UPDATE;
     currentSignature.generateSignature(currentImage);
     
     UPDATE caini s
     SET s.semnatura_poza = currentSignature
     WHERE s.id_caine = i.id_caine;
   END LOOP;
END;
/

--recunoastere semantica
--procedura pt compararea imaginilor
CREATE OR REPLACE PROCEDURE regasire (nfis in varchar2, cculoare in decimal, ctextura in decimal, cforma in decimal, clocatie in decimal, idrez out integer)
IS
scor NUMBER;
qsemn ORDImageSignature;
--img de referinta si signatura ei
qimg ORDimage;
myimg ORDImage;
mysemn ORDImageSignature;
mymin number;
BEGIN
idrez:=0;
--img de referinta nu o sa o stocam in bd
qimg:=ORDImage.init('file','DIRECTOR_LUCRU',nfis);
qimg.setproperties;
qsemn:=ORDImageSignature.init();
DBMS_LOB.CREATETEMPORARY(qsemn.signature,TRUE);
qsemn.generateSignature(qimg);
mymin:=100;
FOR x IN (SELECT id_caine FROM caini)
LOOP
SELECT s.poza, s.semnatura_poza INTO myimg, mysemn FROM caini s WHERE s.id_caine=x.id_caine;
scor:=ORDImageSignature.evaluateScore(qsemn,mysemn,'color='||cculoare||
' texture='|| ctextura||' shape='|| cforma||' location='||clocatie||'');
IF scor<mymin THEN 
    mymin:=scor;
    idrez:=x.id_caine;
END IF;
END LOOP;
END;
  
  
 -- FAZA 3 PROIECT --
CREATE TABLE Videos(id_video NUMBER NOT NULL, descrip VARCHAR2(40), video ORDVideo);
--inserare video
DECLARE 
obj ORDVideo;
ctx RAW(64):=NULL;
BEGIN

INSERT INTO Videos VALUES (124, 'Film 2', OrdVideo.init());

SELECT video INTO obj
FROM Videos
WHERE id_video=124 FOR UPDATE;

obj.importFrom(ctx,'file','DIRECTOR_LUCRU','training.mp4');

UPDATE Videos
SET video=obj
WHERE id_video=124;

COMMIT;
END;
/
--afisare video
CREATE OR REPLACE PROCEDURE PROCEDURA_AFISARE_VIDEO(v_id IN NUMBER, flux OUT BLOB)
IS
obj ORDVideo;
BEGIN
SELECT video INTO obj
FROM Videos
WHERE id_video=v_id;
flux:=obj.getContent();
END;
/