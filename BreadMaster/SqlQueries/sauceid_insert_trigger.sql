CREATE OR REPLACE TRIGGER sauceid_insert_trigger
BEFORE INSERT ON sauce_master
FOR EACH ROW
BEGIN
  SELECT sauce_master_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;

