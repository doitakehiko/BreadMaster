spool uninstall.log
SET ECHO ON
SET FEEDBACK ON
SET SERVEROUTPUT ON
PROMPT  *** 処理を開始します ***
@drop.sql
PROMPT  *** 処理が終了しました ***
spool off
