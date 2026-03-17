CREATE OR REPLACE TRIGGER cm_id_insert_trigger
BEFORE INSERT ON country_master
FOR EACH ROW
BEGIN
  SELECT country_master_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;

