
create table Cart(
CartId int primary key identity(10,2),
UserId int,
[Stauts] int
)

create table CartItem(
CartItem_ID int primary key identity (11,2),
BookId int,
UserId int,
Active int,
Price float,
Quantity int
)
drop table CartItem

drop table Cart

select * from CartItem

select * from Author 
join  Book on Book.Author=Author.Name

insert into CartItem (UserId, BookId, Active, Price, Quantity) values(1013,19810,1,17.03,3)

select *, (Book.Image) from CartItem 
join Book on CartItem.BookId = Book.BookId where UserId = 1013


************************************************************

create table Orders(
OrderId int primary key Identity(1,3),
UserId int,
BookId int,
Status int default 1,
Price float,
Quantity int,
TotalPrice float,
CouponCode varchar(50) default,
Discount float default 2.5,
GrandTotal float
)
use bookstore

select * from Orders

drop table Orders

INSERT INTO Orders (UserId, BookId, Price, Quantity, TotalPrice)
SELECT UserId, BookId, Price, Quantity, TotalAmount
FROM CartItem where UserId = 1015


select* from CartItem

UPDATE Orders
SET GrandTotal= TotalPrice-Discount
WHERE GrandTotal IS NULL;

create table Wishlist(
WishId int primary key identity(9000,1),
UserId int,
BookId int
)

select * from Orders 
inner join Book on
Orders.BookId = Book.BookId where UserId = 1015