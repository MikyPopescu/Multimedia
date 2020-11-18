SET SERVEROUTPUT ON;

DECLARE
flux ORDImage;
BEGIN

SELECT image INTO flux
FROM Images
WHERE id_image=1;

DBMS_OUTPUT.PUT_LINE('Image Height: ' || flux.getHeight());
DBMS_OUTPUT.PUT_LINE('Image Width: ' || flux.getWidth());
DBMS_OUTPUT.PUT_LINE('File Format: ' || flux.getFileFormat());
DBMS_OUTPUT.PUT_LINE('Image Format: ' || flux.getContentFormat());
DBMS_OUTPUT.PUT_LINE('Compression Format: ' || flux.getCompressionFormat());
DBMS_OUTPUT.PUT_LINE('Data source: ' || flux.getSource());
DBMS_OUTPUT.PUT_LINE('BLOB Length: ' || flux.getContentLength());

END;
/

CREATE OR REPLACE PROCEDURE SELECT_PROCEDURE(v_id_image IN NUMBER, 
                                              flux OUT BLOB)
IS
obj ORDImage;
BEGIN

SELECT image INTO obj
FROM Images
WHERE id_image = v_id_image;

flux:=obj.getContent();
END;
/


-- take picture from http
DECLARE
obj ORDImage;
ctx RAW(64):=null;
BEGIN
-- if proxy: utl_http.set_proxy('cache.ase.ro:8080','*.ase.ro);

INSERT INTO Images 
VALUES(3,'imagine de pe web',ORDSYS.ORDImage.init(), ORDSYS.ORDImageSignature.init());

SELECT image INTO obj
FROM Images
WHERE id_image=3 FOR UPDATE;

obj.importfrom(ctx,'http','http://www.hotnews.ro/images/new/','logo.gif');

UPDATE Images
SET image = obj
WHERE id_image = 3;

COMMIT;

END;
/


--prelucrare imagini
DECLARE 
obj ORDImage;
BEGIN

SELECT image INTO obj 
FROM images
WHERE id_image=1 FOR UPDATE;

obj.PROCESS('flip');

UPDATE images
SET image=obj
WHERE id_image=1;

COMMIT;

END;
/


--recunoastere semantica
CREATE OR REPLACE PROCEDURE generate_signature_procedure
IS
--for all records
    currentImage ORDiMAGE;
    currentSignature ORDImageSignature;
    ctx RAW(4000):=null;
BEGIN
   FOR i IN (SELECT id_image FROM IMAGES)
   LOOP
     SELECT s.image, s.image_signature 
     INTO currentImage,currentSignature
     FROM images s
     WHERE s.id_image=i.id_image FOR UPDATE;
     currentSignature.generateSignature(currentImage);
     
     UPDATE images s
     SET s.image_signature = currentSignature
     WHERE s.id_image = i.id_image;
   END LOOP;
END;
/

--recunoastere semantica
--procedura pt compararea imaginilor
create or replace procedure regasire (nfis in varchar2, cculoare in decimal, ctextura in decimal, cforma in decimal, clocatie in decimal, idrez out integer)
is
scor number;
qsemn ORDImageSignature;
--img de referinta si signatura ei
qimg ORDimage;
myimg ORDImage;
mysemn ORDImageSignature;
mymin number;
begin
idrez:=0;
--img de referinta nu o sa o stocam in bd
qimg:=ORDImage.init('file','WORK_DIRECTORY',nfis);
qimg.setproperties;
qsemn:=ORDImageSignature.init();
DBMS_LOB.CREATETEMPORARY(qsemn.signature,TRUE);
qsemn.generateSignature(qimg);
mymin:=100;
for x in (select id_image from IMAGES)
loop
select s.image, s.image_signature into myimg, mysemn from IMAGES s where s.id_image=x.id_image;
scor:=ORDImageSignature.evaluateScore(qsemn,mysemn,'color='||cculoare||
' texture='|| ctextura||' shape='|| cforma||' location='||clocatie||'');
if scor<mymin then 
    mymin:=scor;
    idrez:=x.id_image;
end if;
end loop;
end;
  