using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace HW18._01._23
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    //task 1
    public class Loger
    {
        string _path;
        string user;
        public enum LogMode
        {
            Error,
            Exeption,
            Message,
            Info,
            Warning,
        }
        public Loger(string path, string user)
        {
            _path = path + @"\log.txt";
            using (FileStream fs = new FileStream(_path, FileMode.Create)) { }

            this.user = user;
        }
        public void WriteLog(LogMode mode, string msg)
        {
            using (FileStream fs = new FileStream(_path, FileMode.Append, FileAccess.Write))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(DateTime.Now.ToString() + "\t" + mode.ToString() + "\t" + user + "\t" + msg + "\n");
                fs.Write(bytes, 0, bytes.Count());
            }
        }
    }

    //task 2, 4
    [Serializable]
    public class Zakaz
    {
        public List<Tovar> tovarList = new List<Tovar>();
        public Zakaz() { }
        public void AddTovarVZakaz(Tovar tovar)
        {
            tovarList.Add(tovar);
        }
        public void Save()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Tovar>));
            using(FileStream fs = new FileStream("Zakaz.xml",FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, tovarList);
            }
        }
        public void Load()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Tovar>));

            using (FileStream fs = new FileStream("Zakaz.xml", FileMode.OpenOrCreate))
            {
                tovarList = (List<Tovar>)xmlSerializer.Deserialize(fs);
            }

            foreach(var e in tovarList)
            {
                Console.WriteLine(e.ToString()); 
            }
        }

    }
    public class Tovar
    {
        public string name;
        public int age;
        public bool flag;
        public Tovar() { }
        public Tovar(string name, int age, bool flag)
        {
            this.name = name;
            this.age = age;
            this.flag = flag;
        }
        public override string ToString()
        {
            return $"{name}, {age}, {flag}";
        }
    }

    
}
