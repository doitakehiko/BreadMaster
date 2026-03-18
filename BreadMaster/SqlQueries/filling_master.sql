CREATE TABLE filling_master(
	id NUMBER NOT NULL,
	filling_name VARCHAR2(256)  NOT NULL ,
	insert_date date NOT NULL ,
	update_date date NOT NULL ,
	PRIMARY KEY (id)
);
ALTER TABLE filling_master ADD CONSTRAINT filling_name_unique UNIQUE (filling_name);
