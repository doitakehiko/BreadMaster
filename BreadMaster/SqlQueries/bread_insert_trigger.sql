CREATE OR REPLACE TRIGGER bread_insert_trigger
BEFORE INSERT ON bread_master
FOR EACH ROW
BEGIN
  SELECT bread_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;
