CREATE TABLE type_master (
	id NUMBER NOT NULL,
	type_name VARCHAR2(256)  NOT NULL ,
	insert_date date ,
	update_date date ,
	PRIMARY KEY ( id )
);
ALTER TABLE type_master ADD CONSTRAINT type_name_unique UNIQUE (type_name);
