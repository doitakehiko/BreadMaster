create or replace trigger country_master_trigger
before insert or update on country_master
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

ALTER TRIGGER cm_id_insert_trigger ENABLE;
ALTER TRIGGER country_master_trigger ENABLE;

