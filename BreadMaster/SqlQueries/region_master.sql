CREATE TABLE region_master (
	id NUMBER NOT NULL,
	region_name VARCHAR2(256)  NOT NULL ,
	country_id NUMBER NOT NULL,
	insert_date date ,
	update_date date ,
	CONSTRAINT fk_country FOREIGN KEY (country_id) REFERENCES country_master(id),
	PRIMARY KEY (id)
);

ALTER TABLE region_master ADD CONSTRAINT region_name_unique UNIQUE (region_name);

