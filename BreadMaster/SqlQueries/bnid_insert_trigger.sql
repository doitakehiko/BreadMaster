CREATE OR REPLACE TRIGGER bnid_insert_trigger
BEFORE INSERT ON bread_name_master
FOR EACH ROW
BEGIN
  SELECT bread_name_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;
/
