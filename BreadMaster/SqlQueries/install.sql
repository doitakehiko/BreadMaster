SET ECHO ON;       -- 実行するコマンドを画面に表示
SET FEEDBACK ON;   -- "xx行選択されました"などのメッセージを表示
SET SERVEROUTPUT ON; -- DBMS_OUTPUT.PUT_LINEの出力を有効化
PROMPT  *** 処理を開始します ***
@makeCountryMaster.sql
@makeBreadMaster.sql
