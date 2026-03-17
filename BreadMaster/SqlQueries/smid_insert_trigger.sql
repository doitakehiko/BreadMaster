CREATE OR REPLACE TRIGGER smid_insert_trigger
BEFORE INSERT ON sandwich_master
FOR EACH ROW
BEGIN
  SELECT sandwich_master_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;

