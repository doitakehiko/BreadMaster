spool install.log
SET ECHO ON
SET FEEDBACK ON
SET SERVEROUTPUT ON
PROMPT  *** 処理を開始します ***
@configcheck.sql
@makeCountryMaster.sql
@makeBreadMaster.sql
@makeWorldSandwichData.sql
commit;
PROMPT  *** 処理が終了しました ***
spool off
