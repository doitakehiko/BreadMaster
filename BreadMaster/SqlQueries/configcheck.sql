CREATE OR REPLACE PROCEDURE configcheck AUTHID CURRENT_USER AS
    TYPE priv_list IS TABLE OF VARCHAR2(50);
    target_privs priv_list := priv_list(
        'CREATE TABLE',
        'CREATE VIEW',
        'CREATE SEQUENCE',
        'CREATE TRIGGER',
        'CREATE PROCEDURE'
    );
    v_count NUMBER;
BEGIN
    FOR i IN 1..target_privs.COUNT LOOP
        -- SESSION_PRIVS を参照すれば、直接権限とロール経由の両方を一括チェックできます
        SELECT COUNT(*) INTO v_count 
        FROM SESSION_PRIVS 
        WHERE PRIVILEGE = target_privs(i);

        IF v_count > 0 THEN
            DBMS_OUTPUT.PUT_LINE('[ OK ] ' || target_privs(i));
        ELSE
            DBMS_OUTPUT.PUT_LINE('[ NG ] ' || target_privs(i));
        END IF;
    END LOOP;
END;
/
