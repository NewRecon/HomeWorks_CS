using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace HW21._04._23_ADO.NET
{
    internal class Program
    {
        static void Main(string[] args){}
        //task 1
        static void AddObject(SqlConnection conn, Table table, string name)
        {
            SqlCommand cmd = new SqlCommand($@"insert into [{table}] values ('{name}')", conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Добавлены данные в таблицу {table}");
        }
        //task 2
        static void UpdateObject(SqlConnection conn, Table table, string ObjectName, string NewObjectName)
        {
            SqlCommand cmd = new SqlCommand($@"update [{table}] set {table}Name = '{NewObjectName}' where {table}Name = '{ObjectName}'", conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Изменены данные в таблице {table}");
        }
        //task 3
        static void DeleteObject(SqlConnection conn, Table table, string ObjectName)
        {
            SqlCommand cmd = new SqlCommand($@"delete [{table}] where {table}Name = '{ObjectName}'", conn);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"удалены данные из таблицы {table}");
        }
        //task 4
        static void ShowInfoOnTheProductCount(SqlConnection conn, Table table, Value value)
        {
            SqlCommand cmd = new SqlCommand($@"select * from {table} where Id =
                                               (select {table}Id from Orders where ProductCount =
                                               (select {value}(ProductCount) from Orders))" , conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    Console.WriteLine(reader[0] + " " + reader[1]);
            }
        }
        static void ShowInfoOnTheDeliveryDate(SqlConnection conn, int days)
        {
            SqlCommand cmd = new SqlCommand($@"select * from Orders where DeliveryDate = CAST(GETDATE()-{days} as date)", conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3] + " " + reader[4] + " " + reader[5] + " " + reader[6]);
            }
        }
    }
    public enum Table
    {
        Products,
        ProductsType,
        Providers
    }
    public enum Value
    {
        max,
        min
    }
}
