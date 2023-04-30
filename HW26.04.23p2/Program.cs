using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Security.Policy;
using System.Reflection;

namespace HW26._04._23p2
{
    internal class Program
    {
        static string source = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Countries;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        static void Main(string[] args)
        {
            // task 1, 2, 3

            //Add(new Cities() { CityName = "dsad", CountrieId = 1, NumberOfCitizens = 123123 });
            //Update(new Cities() { CityName = "dsadasd", CountrieId = 1, NumberOfCitizens = 123123 }, "asdasdasdd");
            //Delete(Table.Cities, "dsad");

            // task 4

            using (MyDatabase myDatabase = new MyDatabase(source))
            {
                foreach (var e in myDatabase.Top3Countries())
                {
                    Console.WriteLine(e.CountryName);
                }
            }
        }

        // task 1
        static public void Add(MyTableClass value)
        {
            using (DataContext data = new DataContext(source))
            {
                try
                {
                    if (value is Capitals)
                    {
                        var capitals = data.GetTable<Capitals>();
                        capitals.InsertOnSubmit(value as Capitals);
                    }
                    else if (value is Cities)
                    {
                        var cities = data.GetTable<Cities>();
                        if (data.GetTable<Countries>().Select(c => c.Id).Contains((value as Cities).CountrieId))
                        {
                            (value as Cities).Countries = data.GetTable<Countries>().FirstOrDefault(c => c.Id == (value as Cities).CountrieId);
                            cities.InsertOnSubmit(value as Cities);
                        }
                        else
                            throw new Exception(@"Сначала добавьте Страну");
                    }
                    else if (value is Countries)
                    {
                        var countries = data.GetTable<Countries>();
                        if (data.GetTable<Capitals>().Select(c => c.Id).Contains((value as Countries).CapitalId))
                        {
                            (value as Countries).Capitals = data.GetTable<Capitals>().FirstOrDefault(c => c.Id == (value as Countries).CapitalId);
                            countries.InsertOnSubmit(value as Countries);
                        }
                        else
                            throw new Exception(@"Сначала добавьте Столицу");
                    }
                    data.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        // task 2
        static public void Update(MyTableClass value, string name)
        {
            using (DataContext data = new DataContext(source))
            {
                try
                {
                    if (value is Capitals)
                    {
                        var capital = data.GetTable<Capitals>().First(c => c.CapitalName == name);
                        capital.NumberOfCitizens = (value as Capitals).NumberOfCitizens;
                    }
                    else if (value is Cities)
                    {
                        var city = data.GetTable<Cities>().First(c => c.CityName == name);
                        city.NumberOfCitizens = (value as Cities).NumberOfCitizens;
                        if (data.GetTable<Countries>().Select(c => c.Id).Contains((value as Cities).CountrieId))
                        {
                            city.CountrieId = (value as Cities).CountrieId;
                            city.Countries = data.GetTable<Countries>().FirstOrDefault(c => c.Id == (value as Cities).CountrieId);
                        }
                    }
                    else if (value is Countries)
                    {
                        var country = data.GetTable<Countries>().First(c => c.CountryName == name);
                        country.ChastSveta = (value as Countries).ChastSveta;
                        if (data.GetTable<Capitals>().Select(c => c.Id).Contains((value as Countries).CapitalId))
                        {
                            country.CapitalId = (value as Countries).CapitalId;
                            country.Capitals = data.GetTable<Capitals>().FirstOrDefault(c => c.Id == (value as Countries).CapitalId);
                        }
                        country.Area = (value as Countries).Area;
                        country.NumberOfCitizens = (value as Countries).NumberOfCitizens;
                    }
                    data.SubmitChanges();
                }
                catch
                {
                    Console.WriteLine("Элемент не найден");
                }
            }
        }

        // task 3
        static public void Delete(Table value, string name)
        {
            using (DataContext data = new DataContext(source))
            {
                try
                {
                    if (value.ToString() == "Capitals")
                    {
                        data.GetTable<Capitals>().DeleteOnSubmit(data.GetTable<Capitals>().First(c => c.CapitalName == name));
                    }
                    else if (value.ToString() == "Cities")
                    {
                        data.GetTable<Cities>().DeleteOnSubmit(data.GetTable<Cities>().First(c => c.CityName == name));
                    }
                    else if (value.ToString() == "Countries")
                    {
                        data.GetTable<Countries>().DeleteOnSubmit(data.GetTable<Countries>().First(c => c.CountryName == name));
                    }
                    data.SubmitChanges();
                }
                catch
                {
                    Console.WriteLine("Элемент не найден");
                }
            }
        }
    }

    public class MyTableClass { }

    [Table]
    public class Capitals : MyTableClass
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string CapitalName { get; set; }
        [Column]
        public int NumberOfCitizens { get; set; }
    }

    [Table]
    public class Countries : MyTableClass
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string CountryName { get; set; }
        [Column]
        public int CapitalId { get; set; }
        [Association]
        public Capitals Capitals { get; set; }
        [Column]
        public int NumberOfCitizens { get; set; }
        [Column]
        public int Area { get; set; }
        [Column]
        public string ChastSveta { get; set; }
    }

    [Table]
    public class Cities : MyTableClass
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }
        [Column]
        public string CityName { get; set; }
        [Column]
        public int NumberOfCitizens { get; set; }
        [Column]
        public int CountrieId { get; set; }
        [Association]
        public Countries Countries { get; set; }
    }

    enum Table
    {
        Capitals,
        Cities,
        Countries
    }

    // task 4
    class MyDatabase : DataContext
    {
        public MyDatabase(string connectionString) : base(connectionString)
        {

        }

        Table<Countries> Countries { get; set; }

        [Function(Name = "Top3Countries")]
        public IEnumerable<Countries> Top3Countries()
        {
            return ExecuteMethodCall(this, MethodInfo.GetCurrentMethod() as MethodInfo).ReturnValue as IEnumerable<Countries>;
        }

        [Function(Name = "Top3Capitals")]
        public IEnumerable<Capitals> Top3Capitals()
        {
            return ExecuteMethodCall(this, MethodInfo.GetCurrentMethod() as MethodInfo).ReturnValue as IEnumerable<Capitals>;
        }

        [Function(Name = "Top1Countries")]
        public ISingleResult<Countries> Top1Countries()
        {
            return ExecuteMethodCall(this, MethodInfo.GetCurrentMethod() as MethodInfo).ReturnValue as ISingleResult<Countries>;
        }

        [Function(Name = "Top1City")]
        public ISingleResult<Cities> Top1City()
        {
            return ExecuteMethodCall(this, MethodInfo.GetCurrentMethod() as MethodInfo).ReturnValue as ISingleResult<Cities>;
        }
    }
}
