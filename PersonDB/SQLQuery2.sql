use Personnel 
Create Table UserInfo(
ID int identity(1,1)primary key not null,
UserName nvarchar(50) not null,
Password nvarchar(50) not null,
Sex nvarchar(50) not null,
IDCard nvarchar(200) not null,
DutiesID int,
DepartmentID int
)

create table DePartment(
ID int identity (1,1) primary key not null,
DeMane nvarchar(50)
)
create table Duties(
ID int identity (1,1) primary key not null,
Dumane nvarchar(50)
)
select * from UserInfo,DePartment,Duties

truncate table Duties
insert into Duties values ('Ա��')
insert into Duties values ('�鳤')
insert into Duties values ('����')
insert into Duties values ('����')

insert into DePartment values ('�з���')
insert into DePartment values ('���̲�')
insert into DePartment values ('����')
insert into DePartment values ('������Դ��')

select * from Duties,DePartment

insert into UserInfo values('admin','123456','��','420612198709083331',1,1)

select * from UserInfo