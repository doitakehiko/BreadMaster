create or replace trigger filling_master_trigger
before insert or update on filling_master
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
alter trigger filling_master_trigger enable;
