CREATE OR REPLACE TRIGGER imid_insert_trigger
BEFORE INSERT ON ingredients_master
FOR EACH ROW
BEGIN
  SELECT ingredients_master_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;

