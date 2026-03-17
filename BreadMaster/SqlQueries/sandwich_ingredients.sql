CREATE TABLE sandwich_ingredients (
	id NUMBER NOT NULL,
	sandwich_id NUMBER NOT NULL,
	ingredients_id NUMBER NOT NULL,
	insert_date date NOT NULL,
	update_date date NOT NULL,
	CONSTRAINT fk_bread FOREIGN KEY (sandwich_id) REFERENCES sandwich_master(id),	CONSTRAINT fk_ingredients FOREIGN KEY (ingredients_id) REFERENCES ingredients_master(id),
	PRIMARY KEY (id)
);



