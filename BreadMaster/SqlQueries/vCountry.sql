CREATE OR REPLACE VIEW vCountry AS
SELECT 
	country_master.id , 
	country_master.country_name_jp ,
	country_master.country_name_en ,
	country_code_master.country_code
FROM 
	country_master, country_code_master 
WHERE 
	country_master.id = country_code_master.country_master_id;
