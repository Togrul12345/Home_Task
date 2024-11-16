create database 
use AcademyDB
create table Students(
id int primary key identity,
firstName nvarchar(20),
lastName nvarchar(20),
dateOfBirth date,
userName nvarchar(20),
password nvarchar(20),
enrollmentDate date


)
create table Departments(
id int primary key identity,
departmentName nvarchar(20)

)
create table Instructors(
id int primary key identity,
firstName nvarchar(20),
lastName nvarchar(20),
hireDate date,
departmentId int foreign key references Departments(id),
userName nvarchar(20),
password nvarchar(20),
pin nvarchar(20)


)
create table Groups(
id int primary key identity,
groupName nvarchar(20),
departmentId int foreign key references Departments(id),
startDate date,
endDate date,


)
create table Enrollment(
id int primary key,
studentId int foreign key references Students(id),
groupId int foreign key references Groups(id)

)
create table Classes(
id int primary key,
groupId int foreign key references Groups(id),
instructorId int foreign key references Instructors(id),
schedule nvarchar(20),
roomName nvarchar(20)


)

create procedure Inserting
as
insert into Students values ('Togrul','Bagirov','2004-07-05','Togrul12345','12345rtfg','2024-11-02')

exec Inserting
select * from Students