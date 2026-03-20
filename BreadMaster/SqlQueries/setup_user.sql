-- sysdba権限で実行してください
-- PDBへの切り替えが必要です（管理者権限が必要）
-- PDBへの切り替えがsql例
-- ALTER SESSION SET CONTAINER = ORCLPDB1;

-- 表示設定
SET VERIFY OFF
SET FEEDBACK OFF
SET SERVEROUTPUT ON

-- 引数の定義（&1: ユーザー名, &2: パスワード）
DEFINE V_USER = "&&1"
DEFINE V_PASS = "&&2"

PROMPT ==========================================
PROMPT ターゲット: [ &V_USER ] のセットアップを開始
PROMPT ==========================================

DECLARE
    v_count NUMBER;
    v_upper_user VARCHAR2(30) := UPPER('&V_USER');
BEGIN
    -- 1. ユーザーの存在チェック
    SELECT COUNT(*) INTO v_count FROM DBA_USERS WHERE USERNAME = v_upper_user;
    
    IF v_count = 0 THEN
        DBMS_OUTPUT.PUT_LINE('>> ユーザーが存在しないため、新規作成します。');
        EXECUTE IMMEDIATE 'CREATE USER ' || v_upper_user || ' IDENTIFIED BY "&V_PASS" DEFAULT TABLESPACE USERS';
    ELSE
        DBMS_OUTPUT.PUT_LINE('>> 既存ユーザーのパスワードを更新します。');
        EXECUTE IMMEDIATE 'ALTER USER ' || v_upper_user || ' IDENTIFIED BY "&V_PASS"';
    END IF;
    
    -- 2. 作成権限（テーブル、ビュー、シーケンス、プロシージャ、トリガー）の付与
    -- ログインに必要な CREATE SESSION も含めています
    EXECUTE IMMEDIATE 'GRANT CREATE SESSION, CREATE TABLE, CREATE VIEW, CREATE SEQUENCE, CREATE PROCEDURE, CREATE TRIGGER TO ' || v_upper_user;
    
    -- 3. 表領域の割当（これがないとテーブル作成でエラーになります）
    EXECUTE IMMEDIATE 'ALTER USER ' || v_upper_user || ' QUOTA UNLIMITED ON USERS';
    
    DBMS_OUTPUT.PUT_LINE('>>> [完了] ' || v_upper_user || ' の権限付与と設定に成功しました。');

EXCEPTION
    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('!!! エラーが発生しました: ' || SQLERRM);
END;
/

-- 変数のクリア
UNDEFINE 1
UNDEFINE 2
UNDEFINE V_USER
UNDEFINE V_PASS
SET FEEDBACK ON
