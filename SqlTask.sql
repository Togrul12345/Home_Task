
--Creating DB and Tables
create database LibraryDB
use LibraryDB

create table Authors(
id int primary key identity,
name varchar(20),
surname varchar(20)

)
create table Books(
id int primary key identity,
authorId int references Authors(id),
name varchar(20),
pageCount int
)
insert into Authors values('Celil','Memmedquluzade'),('Ismayil','Sixli'),('Semed','Vurgun'),('Abbas','Sehhet')
insert into Books values(1,'Molla-Nesreddin',300),(3,'Uzaq-Sahillerde',421),(2,'Firildaq',450),(4,'Yagis',350)
--Creating view
create view BookAuthor_vw
as
select Books.authorId,Books.name,pageCount,CONCAT(Authors.name,surname)  AuthorFullname from Books
join Authors on Books.authorId=Authors.id

select * from BookAuthor_vw
drop view BookAuthor_vw
--Creating procedure and exec
create procedure GetInfo @BookName nvarchar(20),@AuthorName nvarchar(20)
as
select Books.authorId,Books.name,pageCount,CONCAT(Authors.name,surname)  AuthorFullname from Books
join Authors on Books.authorId=Authors.id 
where Books.name=@BookName and Authors.name=@AuthorName

exec GetInfo @BookName='Molla-Nesreddin',@AuthorName='Celil'
--Creating function and executing
create function dbo.GetBookCount (@MinPageCount int)
returns table
as return (select name,pageCount from Books where pageCount>@MinPageCount)
select * from dbo.GetBookCount(400)

