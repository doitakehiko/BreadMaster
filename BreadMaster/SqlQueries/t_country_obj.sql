CREATE OR REPLACE TYPE t_country_obj AS OBJECT (
    name_jp		VARCHAR2(256),
    name_en		VARCHAR2(256),
    no			NUMBER
);
/
CREATE OR REPLACE TYPE t_country_tab AS TABLE OF t_country_obj;
/

