use BookStore

select * from Users
drop table Users
***********************************************
create table Users(
UserId int primary key identity(1000, 1),
[Name] varchar(50),
Email varchar(50),
ContactNo varchar(10),
Password varchar(32),
[Status] tinyint default(1),
[Admin] tinyint default(0),
[Image] varchar(1024) default 'https://icon-library.com/images/users-icon-png/users-icon-png-15.jpg'
)

delete from Users
alter table Users add Unique(ContactNo)

select * from Users
*****************************************************************************************
insert into Users(Name, Email, ContactNo, Password) values('Mark','m@gmail.com','1234567890','m1234')

create proc register
(@Name char(50) = null,
@Email varchar(50) = null,
@ContactNo varchar(50) = null,
@Password varchar(50) = null)
as
begin

Insert into Users
([Name], Email, ContactNo, Password)
values(@Name, @Email, @ContactNo, @Password )
end
create proc view_customers
as begin
select * from Users
end
***************************************************************************
select * from Users

exec register'tajinder','t@gmail.com','123456478','t@tj12345'

exec view_customers
*****************************************************************
create proc login (
@Email varchar(50)=null,
@Password varchar(50) = null)
as begin
select *from Users where Email = @Email and Password = @Password and status = 1
end

exec login 'sr93344@gmail.com' ,'Sr93344@gmail.com'

*****************************************************

insert into Users(Name, Email, ContactNo, Password, Status) values('Kabir','kab@gmail.com','9835081849','K@game1234',0)


