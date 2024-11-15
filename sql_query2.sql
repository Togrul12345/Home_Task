
use HospitalDB
create table Hospital(
id int identity primary key,
name varchar(20)

)
create table Doctor(
id int identity primary key,
name varchar(20),
hospitalId int foreign key references Hospital(id)



)
create table Patient(
id int identity primary key,
name varchar(20),





)
create table DoctorPatient(
id int primary key identity,
doctorId int references Patient(id),
patientId int references Doctor(id)


)
insert into Hospital values('HbGuven'),('HumanitePsikiatri'),('NpBeyin')
insert into Doctor values ('Nevzat-Tarhan',1),('Sedat-Ozkan',2),('Fuad-Besirov',3)
insert into Patient values ('Togrul'),('Vusal'),('Akif')

insert into DoctorPatient values(3,1)

select * from Hospital
select * from Doctor
select * from Patient
select * from DoctorPatient



create view Database_vw 
as
select hospitalId,Hospital.name hospitalName,Doctor.name doctorName,Patient.name patientName from Hospital 
inner join Doctor on Hospital.id=Doctor.hospitalId
inner join DoctorPatient on DoctorPatient.doctorId=Doctor.id 
inner join Patient on Patient.id=DoctorPatient.patientId

select * from Database_vw










