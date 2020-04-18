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
insert into Duties values ('员工')
insert into Duties values ('组长')
insert into Duties values ('主管')
insert into Duties values ('经理')

insert into DePartment values ('研发部')
insert into DePartment values ('招商部')
insert into DePartment values ('管理部')
insert into DePartment values ('人力资源部')

select * from Duties,DePartment

insert into UserInfo values('admin','123456','男','420612198709083331',1,1)

select * from UserInfo