CREATE TABLE country_master (
	id NUMBER NOT NULL,
	country_name_jp VARCHAR2(100)  NOT NULL ,
	country_name_en VARCHAR2(50)  NOT NULL ,
	insert_date date NOT NULL ,
	update_date date NOT NULL ,
	PRIMARY KEY (id)
);
ALTER TABLE country_master ADD CONSTRAINT country_name_jp_unique UNIQUE (country_name_jp);
ALTER TABLE country_master ADD CONSTRAINT country_name_en_unique UNIQUE (country_name_en);

