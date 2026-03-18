CREATE TABLE bread_name_master (
	id NUMBER NOT NULL,
	bread_name VARCHAR2(256)  NOT NULL ,
	insert_date date  NOT NULL ,
	update_date date  NOT NULL ,
	PRIMARY KEY (id)
);
ALTER TABLE bread_name_master ADD CONSTRAINT bread_name_unique UNIQUE (bread_name);
