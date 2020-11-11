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