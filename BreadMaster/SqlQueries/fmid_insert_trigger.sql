CREATE OR REPLACE TRIGGER fmid_insert_trigger
BEFORE INSERT ON filling_master
FOR EACH ROW
BEGIN
  SELECT filling_master_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;
