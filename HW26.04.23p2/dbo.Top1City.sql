CREATE procedure Top1City
as
select Id, CityName from Cities where NumberOfCitizens = (select max(NumberOfCitizens) from Cities)