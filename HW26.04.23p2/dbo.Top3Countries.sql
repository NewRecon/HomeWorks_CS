CREATE procedure Top3Countries
as
select top(3) Id, CountryName from Countries order by NumberOfCitizens desc