CREATE TABLE regions(
	 id INT PRIMARY KEY,
	name VARCHAR(20),




) 
	CREATE TABLE country(
	id	INT PRIMARY KEY,
	countryName VARCHAR(20),
	regionId	INT FOREIGN KEY REFERENCES regions(id)
	
	)
	CREATE TABLE locations(
	id INT PRIMARY KEY,
	streetAdress VARCHAR(20),
	postalCode  VARCHAR(10),
	city VARCHAR(20),
	stateProvince VARCHAR(15),
	countryId INT FOREIGN KEY REFERENCES country(id)
	
	
	)


CREATE TABLE departments(
id INT PRIMARY KEY,
name VARCHAR(20),
locationId INT FOREIGN KEY REFERENCES locations(id)



)
CREATE TABLE jobs(
id INT PRIMARY KEY,
jobTitle VARCHAR(20),
minSalary DECIMAL(15,15),
maxSalary DECIMAL(15,15)


)

CREATE TABLE employees(
id INT PRIMARY KEY,
firstName VARCHAR(20),
lastName VARCHAR(20),
email VARCHAR(20),
phoneNumber VARCHAR(20),
jobId INT FOREIGN KEY REFERENCES jobs(id),
departmentId INT FOREIGN KEY REFERENCES departments(id) 




)
CREATE TABLE jobHistory(
employeeId INT FOREIGN KEY REFERENCES employees(id),
departmentId INT FOREIGN KEY REFERENCES departments(id),
jobId INT FOREIGN KEY REFERENCES jobs(id),
startDate DATE PRIMARY KEY,
endDate DATE

)
SELECT * FROM country
SELECT * FROM regions
INSERT INTO regions(id,name) VALUES(1,'Asia')
INSERT INTO regions(id,name) VALUES(2,'Europe'),(3,'North-America'),(4,'Africa')
INSERT INTO country (id,countryName,regionId) VALUES(5,'Azerbaijan',2),(6,'USA',3),(7,'SUDAN',4)
INSERT INTO country (id,countryName,regionId) VALUES(8,'Turkey',2),(9,'Mexica',3),(10,'UK',2)
SELECT * FROM country as cr right join regions as rg on cr.regionId=rg.id
SELECT * FROM country as cr left join regions as rg on cr.regionId=rg.id
SELECT * FROM country as cr inner join regions as rg on cr.regionId=rg.id













