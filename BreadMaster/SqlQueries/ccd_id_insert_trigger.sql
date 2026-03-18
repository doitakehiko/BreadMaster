CREATE OR REPLACE TRIGGER ccd_id_insert_trigger
BEFORE INSERT ON country_code_master
FOR EACH ROW
BEGIN
  SELECT country_code_master_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;
/
