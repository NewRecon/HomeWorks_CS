using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace HW19._04._23_ADO.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HW19.04.23;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                if (connection.State == System.Data.ConnectionState.Open)
                    Console.WriteLine("DB is connect\n");
                else if (connection.State == System.Data.ConnectionState.Broken)
                    Console.WriteLine("DB is not connect\n");
                SqlCommand command = new SqlCommand(@"select * from VegetablesAndFruits;
                                                      select [Name] from VegetablesAndFruits;
                                                      select Color from VegetablesAndFruits;
                                                      select max(Calories) from VegetablesAndFruits;
                                                      select min(Calories) from VegetablesAndFruits;
                                                      select avg(Calories) from VegetablesAndFruits;
                                                      select count(*) from VegetablesAndFruits where [Type] = 'vegetable';
                                                      select count(*) from VegetablesAndFruits where [Type] = 'fruit';
                                                      select count(*) from VegetablesAndFruits where Color = 'red';
                                                      select distinct Color, count(*) from VegetablesAndFruits group by Color;
                                                      select * from VegetablesAndFruits where Calories < 40;
                                                      select * from VegetablesAndFruits where Calories > 40;
                                                      select * from VegetablesAndFruits where Calories between 35 and 45;
                                                      select * from VegetablesAndFruits where Color = 'yellow' or Color = 'red'", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    do
                    {
                        Console.WriteLine();
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write(reader[i] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                    while (reader.NextResult());
                }
            }
        }
    }
}