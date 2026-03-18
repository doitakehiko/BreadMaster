CREATE OR REPLACE TYPE t_country_obj AS OBJECT (
    name_jp		VARCHAR2(256),
    name_en		VARCHAR2(256),
    no			NUMBER
);
/
CREATE OR REPLACE TYPE t_country_tab AS TABLE OF t_country_obj;
/

CREATE OR REPLACE PROCEDURE cno (p_country IN t_country_tab) AS
BEGIN
    FOR i IN 1..p_country.COUNT LOOP
        DBMS_OUTPUT.PUT_LINE('name_jp: ' || p_country(i).name_jp || ', name_en: ' || p_country(i).name_en || 'no:' ||  p_country(i).no);
        -- ここでINSERTなどの処理を行う
    END LOOP;
END;
/
