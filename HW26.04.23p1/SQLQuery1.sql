--create table Capitals
--(
--Id int identity(1,1) primary key,
--CapitalName varchar(100),
--NumberOfCitizens int
--)

--create table Countries
--(
--Id int identity(1,1) primary key,
--CountryName varchar(100),
--CapitalId int foreign key (CapitalId) references Capitals (Id),
--NumberOfCitizens int,
--Area float,
--ChastSveta varchar(100)
--)

--create table Cities
--(
--Id int identity(1,1) primary key,
--CityName varchar(100),
--NumberOfCitizens int,
--CountrieId int foreign key (CountrieId) references Countries (Id)
--)

--insert into Capitals values
--('Moscow', 12000000),
--('China', 15000000)

--insert into Countries values
--('Russia', 1, 147000000,17100000, 'Eurasia'),
--('China', 1, 1412000000,15100000, 'Asia')

--insert into Cities values
--('Rostov-on-Don', 1500000, 1),
--('Novosibirsk', 2500000, 1),
--('Shanhai', 24000000, 2),
--('Uhan', 9700000, 2)