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
CREATE OR REPLACE PROCEDURE find_procedure(v_file_name IN VARCHAR2, v_color IN DECIMAL, v_texture IN DECIMAL, v_shape IN DECIMAL, v_location IN DECIMAL, id_result OUT INTEGER)
IS
  score NUMBER; 
  queryImageSignature ORDImageSignature; 
  referencedImage ORDImage; 
  currentImage ORDImage; 
  currentSignature ORDImageSignature; 
  minScore NUMBER; 
BEGIN
  id_result:=0;
  referencedImage:= ORDImage.init('file','WORK_DIRECTORY',v_file_name);
  referencedImage.setProperties;
  queryImageSignature:=ORDImageSignature.init();
  dbms_lob.createtemporary(queryImageSignature.signature, TRUE);
  currentSignature.generateSignature(referencedImage);
  minScore:=100; --maximum score
  FOR i IN (SELECT id_image FROM images)
   LOOP
    SELECT s.image, s.image_signature INTO  currentImage, currentSignature
    FROM images s
    WHERE s.id_image = i.id_image;
    score:=ORDImageSignature.evaluateScore(queryImageSignature, currentSignature, 'color=' || v_color || ' texture=' ||  v_texture || ' shape=' || v_shape || ' location=' ||v_location || '');
    
    IF score<minScore THEN
     minScore:=score;
     id_result:=i.id_image;
    END IF;
  END LOOP;
END;
/
  