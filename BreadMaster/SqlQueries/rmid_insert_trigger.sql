CREATE OR REPLACE TRIGGER rmid_insert_trigger
BEFORE INSERT ON region_master
FOR EACH ROW
BEGIN
  SELECT region_master_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;
/
