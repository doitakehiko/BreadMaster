CREATE TABLE sauce_master (
	id NUMBER NOT NULL,
	sauce_name VARCHAR2(256)  NOT NULL ,
	insert_date date  NOT NULL ,
	update_date date  NOT NULL ,
	PRIMARY KEY (id)
);
ALTER TABLE sauce_master ADD CONSTRAINT sauce_name_unique UNIQUE (sauce_name);
