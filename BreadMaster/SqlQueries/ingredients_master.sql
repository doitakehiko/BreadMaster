CREATE TABLE ingredients_master (
	id NUMBER NOT NULL,
	ingredients_name VARCHAR2(256) NOT NULL ,
	insert_date date  NOT NULL ,
	update_date date  NOT NULL ,
	PRIMARY KEY (id)
);

ALTER TABLE ingredients_master ADD CONSTRAINT ingredients_name_unique UNIQUE (ingredients_name);

