CREATE OR REPLACE TRIGGER tmid_insert_trigger
BEFORE INSERT ON type_master
FOR EACH ROW
BEGIN
  SELECT type_master_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;
/
