CREATE TABLE country_code_master (
	id NUMBER NOT NULL,
	country_master_id NUMBER NOT NULL,
	country_code NUMBER(5, 0) NOT NULL,
	insert_date date  NOT NULL ,
	update_date date  NOT NULL ,
	PRIMARY KEY (id),
	CONSTRAINT fk_country_code FOREIGN KEY (country_master_id) REFERENCES country_master(id),
	CONSTRAINT uk_country UNIQUE (country_master_id, country_code)
);
