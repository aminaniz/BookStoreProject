create database BookStore
go

use BookStore
go


create table Category(
CategoryId int primary key identity,
[Name] char(50),
Description varchar(4096),
Image varchar(1024),
status tinyint,
position tinyint
)
go


set identity_insert Category on
go
insert into Category([CategoryId],[Name],[Description],[Image],[Status],[Position]) values (01,'Education','Educational books to keep one''s thirst for knowledge sated','https://images.unsplash.com/photo-1503676260728-1c00da094a0b?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=2022&q=80',1,1),
(02,'Travel','Travel guides and best locations','https://images.unsplash.com/photo-1488646953014-85cb44e25828?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1935&q=80',1,1),
(03,'Art, Music & Photography','Indulge in fine arts, heritage and culture','https://images.unsplash.com/photo-1535083988052-565ca9546643?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=580&q=80',1,1),
(04,'Finance','Stocks, marketting and investments','https://images.unsplash.com/photo-1567427017947-545c5f8d16ad?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=806&q=80',1,1),
(05,'Information Technology','The revolution of computing and information','https://images.unsplash.com/photo-1498050108023-c5249f4df085?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1172&q=80',1,1),
(06,'Fictional','Invented for the purposes of fiction','https://images.unsplash.com/photo-1609488895842-cd46eaf42e14?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=581&q=80',1,1),
(07,'Non-Fictional','literatures based in fact','https://images.unsplash.com/photo-1476950743170-ab77e7d4d82e?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=1211&q=80',1,1),
(08,'Personal-care','Best practices for staying healthy and 100% efficient','https://images.unsplash.com/photo-1506126613408-eca07ce68773?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=499&q=80',1,1),
(09,'Comic relief','Pass time','https://images.unsplash.com/photo-1608889825271-9696283ab804?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=580&q=80',1,1),
(10,'Decor','The decoration and scenery of a stage','https://images.unsplash.com/photo-1513519245088-0e12902e5a38?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1170&q=80',1,1),
(11,'Misc','Miscellaneous','https://images.unsplash.com/photo-1587250596956-b708d6293843?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=327&q=80',1,1)
set identity_insert Category off
go



create table Shipping_Address(
AddressId int primary key identity(900,1),
UserId int,
Line1 varchar(50),
Line2 varchar(50),
City char(50),
[State] char(50),
Pincode char(6),
)
CREATE TABLE [dbo].[Coupon](
	[CouponId] [int] IDENTITY(1,1) NOT NULL primary key,
	[Tag] [char](10) NULL,
	[Discount] [float] NULL,
	[ExpiryDate] [date] NULL,
	[MinAmount] [int] NULL,
	[Activated] [int] NULL)



