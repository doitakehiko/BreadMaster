CREATE OR REPLACE PROCEDURE cno (p_country IN t_country_tab) 
IS
    -- 件数確認
    CURSOR c_count (cp_jp VARCHAR2, cp_en VARCHAR2) IS
        SELECT count(m_code.id) 
        FROM country_master m, country_code_master m_code 
        WHERE m.id = m_code.country_master_id 
          AND m.country_name_jp = cp_jp 
          AND m.country_name_en = cp_en;

    -- ID取得
    CURSOR c_id (cp_name_jp VARCHAR2, cp_name_en VARCHAR2) IS
        SELECT id FROM country_master 
        WHERE country_name_jp = cp_name_jp AND country_name_en = cp_name_en;

    v_count NUMBER;
    v_id    NUMBER;
BEGIN
    FOR i IN 1..p_country.COUNT LOOP
        
        -- 現在のループの国名で件数をチェック
        OPEN c_count(p_country(i).name_jp, p_country(i).name_en);
        FETCH c_count INTO v_count;
        CLOSE c_count;

        -- 1. すでに登録があるか、あるいは新規に登録する必要がある場合
        -- (元のELSE句にあった「二重ループ」は、外側のループだけで完結できるため削除しました)
        
        OPEN c_id(p_country(i).name_jp, p_country(i).name_en);
        FETCH c_id INTO v_id;
        
        IF c_id%FOUND THEN
            -- IDが見つかった場合のみINSERTを実行
            INSERT INTO country_code_master (country_master_id, country_code) 
            VALUES (v_id, p_country(i).no);
            
            DBMS_OUTPUT.PUT_LINE('Inserted: ' || p_country(i).name_jp || ' ID:' || v_id);
        ELSE
            DBMS_OUTPUT.PUT_LINE('Skipped: country_masterにデータがありません');
        END IF;
        
        CLOSE c_id;

    END LOOP;
    
    COMMIT; -- 最後にまとめて確定
EXCEPTION
    WHEN OTHERS THEN
        ROLLBACK;
        RAISE;
END;
/
