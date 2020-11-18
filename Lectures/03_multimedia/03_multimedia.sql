--(
SET SERVEROUTPUT ON;

EXEC ORD_DICOM.SETDATAMODEL;

SELECT * FROM ORDDCM_DOCUMENTS;

CREATE TABLE med_images(id_med_img NUMBER, dicom_src ORDDICOM);

INSERT INTO med_images (id_med_img, dicom_src)
VALUES (1, ORDDICOM('FILE','WORK_DIRECTORY','MEDICAL1.DCM',1));

DECLARE
obj ORDDICOM;
meta XMLTYPE;

BEGIN

SELECT dicom_src INTO obj
FROM med_images
WHERE id_med_img=1;

meta:=obj.EXTRACTMETADATA();
dbms_output.put_line('Metadata: '||meta.GETCLOBVAL());

END;
/
--)



--video
CREATE TABLE Video(id_video NUMBER NOT NULL, descrip VARCHAR2(40), video ORDVideo);

DECLARE 
obj ORDVideo;
ctx RAW(64):=NULL;
BEGIN

INSERT INTO video VALUES (123, 'Film 1', OrdVideo.init());

SELECT