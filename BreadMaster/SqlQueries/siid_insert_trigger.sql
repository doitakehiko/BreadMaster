CREATE OR REPLACE TRIGGER siid_insert_trigger
BEFORE INSERT ON sandwich_ingredients
FOR EACH ROW
BEGIN
  SELECT sandwich_ingredients_seq.NEXTVAL
  INTO   :new.id
  FROM   dual;
END;

