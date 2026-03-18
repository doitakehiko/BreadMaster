create or replace trigger country_code_master_trigger
before insert or update on country_code_master
    for each row
begin

    if inserting then
        :new.insert_date :=localtimestamp;
        :new.update_date   :=localtimestamp;
    end if;
    if updating then
        :new.update_date   :=localtimestamp;
    end if;
end;
/
alter trigger country_code_master_trigger enable;
