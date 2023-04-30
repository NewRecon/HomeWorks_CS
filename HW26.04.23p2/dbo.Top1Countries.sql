CREATE procedure Top1Countries
as
select Id, CountryName from Countries where NumberOfCitizens = (select max(NumberOfCitizens) from Countries)