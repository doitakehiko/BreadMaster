CREATE TABLE bread_master (
	id NUMBER NOT NULL,
	filling_id NUMBER,
	sauce_id NUMBER,
	sandwich_id NUMBER NOT NULL ,
	region_id  NUMBER NOT NULL ,
	bread_name_id NUMBER NOT NULL ,
	insert_date date ,
	update_date date ,
	CONSTRAINT fk_filling FOREIGN KEY (filling_id) REFERENCES filling_master(id),
	CONSTRAINT fk_sauce FOREIGN KEY (sauce_id) REFERENCES sauce_master(id),
	CONSTRAINT fk_sandwich FOREIGN KEY (sandwich_id) REFERENCES sandwich_master(id),
	CONSTRAINT fk_region FOREIGN KEY (region_id) REFERENCES region_master(id),
	CONSTRAINT fk_bread_name_master FOREIGN KEY (bread_name_id) REFERENCES bread_name_master(id),
	CONSTRAINT uk_bread_master UNIQUE (filling_id ,	sauce_id ,sandwich_id ,region_id, bread_name_id),
	PRIMARY KEY (id)
);
