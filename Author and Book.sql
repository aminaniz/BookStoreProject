Declare @JSON2 varchar(max)
SELECT @JSON2=BulkColumn
FROM OPENROWSET (BULK 'C:\Users\Amina Nizam\Downloads\csvjson.json', SINGLE_CLOB) import
SELECT * INTO Book 
FROM OPENJSON (@JSON2)
WITH 
(
	[AuthorName] varchar(500) '$.Author',
    [Image] varchar(1024) '$.Image',
	[Title] varchar(1024)'$.Title',
	[Format] varchar(20) '$.Format',
	[Rating] float '$.Rating',
	[Price] float '$.Price',
	[ISBN] bigint '$.ISBN',
	[CatId] int '$.CatID',
	[Year] date '$.Year',
	[Position] int '$.Position',
	[Status] varchar(20) '$.Status',
	[Description] varchar (1024) '$.Description'
	    
)
Alter table Book add BookId int Identity(1000,1)

Declare @JSON1 varchar(max)
SELECT @JSON1=BulkColumn
FROM OPENROWSET (BULK 'C:\Users\Amina Nizam\Downloads\csvjson.json', SINGLE_CLOB) import
SELECT * INTO  Author
FROM OPENJSON (@JSON1)
WITH 
(
    [Name] varchar(20) '$.Author'
	    
)

delete from Author 
where AuthorId not in
(
    select min(AuthorId)
    from Author
    group by Name 
);

alter table Author add AuthorId int Identity(100,1)


SELECT *
FROM Book where BookId=3978
INNER JOIN Author ON Author.Name=Book.Author;

select * from category

drop table Book

