using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;

namespace HW26._04._23p1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DataContext data = new DataContext(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Countries;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                // task 2
                var countries = data.GetTable<Countries>();
                //foreach (var e in countries)
                //    Console.WriteLine(e.CountryName + " " + e.NumberOfCitizens + " " + e.Area + " " + e.ChastSveta);

                var capitals = data.GetTable<Capitals>();
                //foreach (var e in capitals)
                //    Console.WriteLine(e.CapitalName);

                var cities = data.GetTable<Cities>().Where(c => c.CountrieId == 1);
                //foreach(var e in cities)
                //    Console.WriteLine(e.CityName);

                var capitals1 = data.GetTable<Capitals>().Where(c => c.NumberOfCitizens > 5000000);
                //foreach (var e in capitals1)
                //    Console.WriteLine(e.CapitalName);

                var countries1 = data.GetTable<Countries>().Where(c => c.ChastSveta == "Europ");
                //foreach (var e in countries1)
                //    Console.WriteLine(e.CountryName);

                var countries2 = data.GetTable<Countries>().Where(c => c.Area > 16000000);
                //foreach (var e in countries2)
                //    Console.WriteLine(e.CountryName);

                // task 3
                var countries3 = data.GetTable<Countries>().Where(c => c.CountryName.Contains("u") && c.CountryName.Contains("r"));
                //foreach (var e in countries3)
                //    Console.WriteLine(e.CountryName);

                var countries4 = data.GetTable<Countries>().Where(c => c.CountryName.StartsWith("c"));
                //foreach (var e in countries4)
                //    Console.WriteLine(e.CountryName);

                var countries5 = data.GetTable<Countries>().Where(c => c.Area > 16000000 && c.Area < 18000000);
                //foreach (var e in countries5)
                //    Console.WriteLine(e.CountryName);

                var countries6 = data.GetTable<Countries>().Where(c => c.NumberOfCitizens > 5000000);
                //foreach (var e in countries6)
                //    Console.WriteLine(e.CountryName);

                //task 4
                var countries7 = data.GetTable<Countries>().OrderByDescending(c => c.Area).Take(5);
                //foreach (var e in countries7)
                //    Console.WriteLine(e.CountryName);

                var capitals2 = data.GetTable<Capitals>().OrderByDescending(c => c.NumberOfCitizens).Take(5);
                //foreach (var e in capitals2)
                //    Console.WriteLine(e.CapitalName);

                var countries8 = data.GetTable<Countries>().OrderByDescending(c => c.Area).FirstOrDefault();
                //Console.WriteLine(countries8.CountryName);

                var capitals3 = data.GetTable<Capitals>().OrderByDescending(c => c.NumberOfCitizens).FirstOrDefault();
                //Console.WriteLine(capitals3.CapitalName);

                var countries9 = data.GetTable<Countries>().OrderBy(c => c.Area).Where(c => c.ChastSveta == "Europ").FirstOrDefault();
                //Console.WriteLine(countries9.CountryName);

                var avgAreaInEurop = data.GetTable<Countries>().Where(c=>c.ChastSveta == "Asia").Average(c => c.Area);
                //Console.WriteLine(avgAreaInEurop);

                var cities1 = data.GetTable<Cities>().Where(c => c.CountrieId == 1).OrderByDescending(c => c.NumberOfCitizens).Take(3);
                //foreach (var e in cities1)
                //    Console.WriteLine(e.CityName);

                var countriesCount = data.GetTable<Countries>().Count();
                //Console.WriteLine(countriesCount);

                var chastSvetaWithMaxCountries = data.GetTable<Countries>().GroupBy(c => c.ChastSveta);
                int counter = 0;
                var s = chastSvetaWithMaxCountries.FirstOrDefault();
                foreach (var e in chastSvetaWithMaxCountries)
                {
                    if (e.Count() > counter)
                    {
                        counter = e.Count();
                        s = e;
                    }
                }
                //Console.WriteLine(s.Select(c => c.ChastSveta).FirstOrDefault());

                var countriesCountInEveryChastSveta = data.GetTable<Countries>().GroupBy(c => c.ChastSveta);
                foreach (var e in countriesCountInEveryChastSveta)
                {
                    //var s = e.Select(c => c.ChastSveta).FirstOrDefault();
                    //Console.WriteLine(s + " " + e.Count());
                }
                    
            }
        }
    }

    [Table]
    class Countries
    {
        [Column]
        public int Id { get; set; }
        [Column]
        public string CountryName { get; set; }
        [Column]
        public int CapitalId { get; set; }
        [Column]
        public int NumberOfCitizens { get; set; }
        [Column]
        public int Area { get; set; }
        [Column]
        public string ChastSveta { get; set; }
    }

    [Table]
    class Capitals
    {
        [Column]
        public int Id { get; set; }
        [Column]
        public string CapitalName { get; set; }
        [Column]
        public int NumberOfCitizens { get; set;}
    }

    [Table]
    class Cities
    {
        [Column]
        public int Id { get; set; }
        [Column]
        public string CityName { get; set; }
        [Column]
        public int NumberOfCitizens { get; set; }
        [Column]
        public int CountrieId { get; set; }
    }
}
