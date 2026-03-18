create or replace trigger bread_trigger
before insert or update on bread_master
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
alter trigger bread_trigger enable;
