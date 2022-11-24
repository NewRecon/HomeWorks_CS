using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HW24._11._22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //task1('*', 5);

            //Console.WriteLine(task2(1221));
            
            //int[] ar = task3(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5 });
            //for (int i=0;i<ar.Length;i++)
            //{
            //    Console.WriteLine(ar[i]);
            //}
        }
        static void task1(char symbol, int side)
        {
            for (int i = 0; i < side; i++)
            {
                Console.WriteLine(new string(symbol, side));
            }
        }
        static bool task2(int num)
        {
            string str = num.ToString();
            for (int i=0;i<str.Length/2;i++)
            {
                if (str[i] != str[str.Length-i-1])
                    return false;
            }
            return true;
        }
        static int[] task3(int[] array, int[] filter)
        {
            for (int i=0;i< array.Length;i++)
            {
                for (int j=0;j< filter.Length;j++)
                {
                    if (array[i] == filter[j])
                    {
                        for (int k=i;k<array.Length-1;k++)
                        {
                            Array.Reverse(array, k, 2);
                        }
                        Array.Resize(ref array, array.Length-1);
                        i--;
                        break;
                    }
                }
            }
            return array;
        }
    }

    // task 4
    class WebSite
    {
        string _name;
        string _path;
        string _discription;
        string _url;
        public WebSite(string name, string path, string discription, string url)
        {
            _name = name;
            _path = path;
            _discription = discription;
            _url = url;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{_name}, {_path}, {_discription}, {_url}");
        }
        public void SetName(string name)
        {
            _name = name;
        }
        public string GetName()
        {
            return _name;
        }
        public void SetPath(string path)
        {
            _path = path;
        }
        public string GetPath()
        {
            return _path;
        }
        public void SetDiscription(string discription)
        {
            _discription = discription;
        }
        public string GetDiscription()
        {
            return _discription;
        }
        public void SetUrl(string url)
        {
            _url = url;
        }
        public string GetUrl ()
        {
            return _url;
        }
    }

    // task 5
    class Jurnal
    {
        string _title;
        int _foundationYear;
        string _description;
        string _phone;
        string _email;
        public Jurnal(string title, int foundationYear, string description, string phone, string email)
        {
            _title = title;
            _foundationYear = foundationYear;
            _description = description;
            _phone = phone;
            _email = email;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{_title}, {_foundationYear}, {_description}, {_phone}, {_email}");
        }
        public void SetTitle(string title)
        {
            _title = title;
        }
        public string GetTitle()
        {
            return _title;
        }
        public void SetFoundationYear(int foundationYear)
        {
            _foundationYear = foundationYear;
        }
        public int GetFoundationYear()
        {
            return _foundationYear;
        }
        public void SetDescription(string description)
        {
            _description = description;
        }
        public string GetDescription()
        {
            return _description;
        }
        public void SetPhone(string phone)
        {
            _phone = phone;
        }
        public string GetPhone()
        {
            return _phone;
        }
        public void SetEmail(string email)
        {
            _email = email;
        }
        public string GetEmail ()
        {
            return _email;
        }
    }

    // task 6
    class Shop
    {
        string _title;
        string _adress;
        string _description;
        string _phone;
        string _email;

        public Shop(string title, string adress, string description, string phone, string email)
        {
            _title = title;
            _adress = adress;
            _description = description;
            _phone = phone;
            _email = email;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{_title}, {_adress}, {_description}, {_phone}, {_email}");
        }
        public void SetTitle(string title)
        {
            _title = title;
        }
        public string GetTitle()
        {
            return _title;
        }
        public void SetAdress(string adress)
        {
            _adress = adress;
        }
        public string GetAdress()
        {
            return _adress;
        }
        public void SetDescription(string description)
        {
            _description = description;
        }
        public string GetDescription()
        {
            return _description;
        }
        public void SetPhone(string phone)
        {
            _phone = phone;
        }
        public string GetPhone()
        {
            return _phone;
        }
        public void SetEmail(string email)
        {
            _email = email;
        }
        public string GetEmail()
        {
            return _email;
        }
    }
}
