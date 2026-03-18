CREATE TABLE sandwich_master (
	id NUMBER NOT NULL,
	sandwich_name VARCHAR2(256)  NOT NULL ,
	type_id  NUMBER ,
	insert_date date  NOT NULL,
	update_date date  NOT NULL,
	CONSTRAINT fk_type FOREIGN KEY (type_id) REFERENCES type_master(id),
	PRIMARY KEY (id)
);
ALTER TABLE sandwich_master ADD CONSTRAINT sandwich_name_unique UNIQUE (sandwich_name);
