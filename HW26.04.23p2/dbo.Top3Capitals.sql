CREATE procedure Top3Capitals
as
select top(3) Id, CapitalName from Capitals order by NumberOfCitizens desc