alter session set "_ORACLE_SCRIPT"=true;
CREATE USER RIS1_user IDENTIFIED BY Stalker2; --pc1
CREATE USER RIS2_user IDENTIFIED BY Stalker2; --pc2

GRANT ALL PRIVILEGES TO RIS1_user; --pc1
GRANT ALL PRIVILEGES TO RIS2_user; --pc2

--pc1
DROP PUBLIC DATABASE LINK anotherdb;
CREATE PUBLIC DATABASE LINK anotherdb 
   CONNECT TO RIS2_user
   IDENTIFIED BY "Stalker2" 
   USING 'dblink';
--pc1

--pc1
drop table Users;
create table Users
(
  id int primary key,
  name varchar2(20)
)
insert into Users values(1, 'pc1table');

select * from Users;

commit;
--pc1

--pc2
drop table Users;
create table Users
(
  id int primary key,
  name varchar2(20)
)
insert into Users values(1, 'pc2_table');

select * from Users;

commit;
--pc2

--pc1 task6
--insert/insert
BEGIN
insert into Users values(2, 'testinsert');
insert into Users@anotherdb values(2, 'testinsert');
END;

select * from Users;
select * from Users@anotherdb;

--insert/update
BEGIN
insert into Users values(3, 'testinsert_2');
update Users@anotherdb SET name='updated_name' where id = 2;
END;

select * from Users;
select * from Users@anotherdb;

--update/insert
BEGIN
UPDATE Users SET name='updated_name' where id = 2;
insert into Users@anotherdb values(3, 'testinsert_2');
END;

select * from Users;
select * from Users@anotherdb;

--pc1 task6

--pc1 task7
BEGIN
insert into Users@anotherdb values(1, 'key_crash');
END;
--pc1 task7

--pc2 task8
set transaction isolation level serializable;
commit;
--pc2 task8

--pc2 task8
set transaction isolation level serializable;
commit;
declare 
x int:=10;
BEGIN
while x<100000
  LOOP
  insert into Users values (x, 'UserName');
  x:=x+1;
  end loop;
END;
commit;
select * from Users;
rollback;
--pc2 task8

--pc1 task8
insert into Users@anotherdb values (10, 'UserName');
commit;
--pc1 task8

rollback;
select * from Users@anotherdb;

--pc2 task8
set transaction isolation level read committed;
commit;
--pc2 task8

