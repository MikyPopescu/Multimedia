CREATE TABLE IMAGES (
    id_image NUMBER,
    descript VARCHAR2(250),
    image ORDSYS.ORDImage,
    image_signature ORDSYS.ORDIMAGESignature
);

-- retrieve resources from disk

-- create directory
CREATE OR REPLACE DIRECTORY WORK_DIRECTORY AS 'C:\Users\Miky\Desktop\Multimedia\Lectures';

-- give privilages
GRANT READ ON DIRECTORY WORK_DIRECTORY TO PUBLIC WITH GRANT OPTION;

-- INSERT procedure
CREATE OR REPLACE PROCEDURE INSERT_PROCEDURE (v_id_image IN NUMBER, 
                                              v_description IN VARCHAR2,
                                              file_name IN VARCHAR2)   
IS
obj ORDImage;
ctx RAW(64):=null;
BEGIN

INSERT INTO IMAGES 
VALUES (v_id_image,v_description,ordsys.ordimage.init(),ordsys.ordimagesignature.init());

SELECT image INTO obj 
FROM images
WHERE id_image = v_id_image FOR UPDATE;

obj.importfrom(ctx,'file','WORK_DRECTORY',file_name);

UPDATE images
SET image = obj 
WHERE id_image = v_id_image;

COMMIT;

END;
/