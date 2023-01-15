using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW19._12._22
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    // task 1
    class Money
    {
        protected int _dollar;
        protected int _cent;
        public void ShowMoney()
        {
            Console.WriteLine($"You have {_dollar}.{_cent}$");
        }
        public void ChangeValue(int dollar, int cent)
        {
            _dollar = dollar;
            _cent = cent;
        }
    }
    class Product : Money
    {
        string _productName;
        public void ReducePrice(int dollar, int cent)
        {
            _dollar -= dollar;
            _cent -= cent;
        }
    }

    // task 2
    abstract class Device
    {
        protected string _name;
        abstract public void Sound();
        abstract public void Show();
        abstract public void Desc();
    }
    class Teapot : Device
    {
        float _capacity;
        string _color;
        string _material;
        public Teapot(string name, float capacity, string color, string material)
        {
            _name = name;
            _capacity = capacity;
            _color = color;
            _material = material;
        }
        public override void Desc()
        {
            Console.WriteLine($"capacity - {_capacity}, color - {_color}, material - {_material}");
        }
        public override void Show()
        {
            Console.WriteLine(_name);
        }
        public override void Sound()
        {
            Console.WriteLine("Make teapot sound");
        }
    }
    class Microwave : Device
    {
        float _power;
        public Microwave(string name, float power)
        {
            _name = name;
            _power = power;
        }
        public override void Desc()
        {
            Console.WriteLine($"power - {_power}");
        }
        public override void Show()
        {
            Console.WriteLine(_name);
        }
        public override void Sound()
        {
            Console.WriteLine("Make microwave sound");
        }
    }
    class Car : Device
    {
        float _engineCapacity;
        string _color;
        float _horsePower;
        public Car(string name, float engineCapacity, string color, float horsePower)
        {
            _name = name;
            _engineCapacity = engineCapacity;
            _color = color;
            _horsePower = horsePower;
        }
        public override void Desc()
        {
            Console.WriteLine($"engine capacity - {_engineCapacity}, horse power - {_horsePower}, color - {_color}");
        }
        public override void Show()
        {
            Console.WriteLine(_name);
        }
        public override void Sound()
        {
            Console.WriteLine("Make car sound");
        }
    }
    class Steamboat : Device
    {
        float _displacement;
        float _engineCapacity;
        public Steamboat(string name, float displacement, float engineCapacity)
        {
            _name = name;
            _displacement = displacement;
            _engineCapacity = engineCapacity;
        }
        public override void Desc()
        {
            Console.WriteLine($"displacement - {_displacement}, engine capacity - {_engineCapacity}");
        }
        public override void Show()
        {
            Console.WriteLine(_name);
        }
        public override void Sound()
        {
            Console.WriteLine("Make steamboat sound");
        }
    }

    // task 3
    abstract class MusicalInstrument
    {
        protected string _name;
        abstract public void Sound();
        abstract public void Show();
        abstract public void Desc();
        abstract public void History();
    }
    class Violin : MusicalInstrument
    {
        string _ViolinDiscriptoin;
        public Violin(string name, string discriptoin)
        {
            _name = name;
            _ViolinDiscriptoin = discriptoin;
        }
        public override void Desc()
        {
            Console.WriteLine($"violin disciption - {_ViolinDiscriptoin}");
        }
        public override void History()
        {
            Console.WriteLine("Violin history");
        }
        public override void Show()
        {
            Console.WriteLine(_name);
        }
        public override void Sound()
        {
            Console.WriteLine("Make Violin sound");
        }
    }
    class Trombone : MusicalInstrument
    {
        string _TromboneDiscriptoin;
        public Trombone(string name, string discriptoin)
        {
            _name = name;
            _TromboneDiscriptoin = discriptoin;
        }
        public override void Desc()
        {
            Console.WriteLine($"Trombone disciption - {_TromboneDiscriptoin}");
        }
        public override void History()
        {
            Console.WriteLine("Trombone history");
        }
        public override void Show()
        {
            Console.WriteLine(_name);
        }
        public override void Sound()
        {
            Console.WriteLine("Make Trombone sound");
        }
    }
    class Ukulele : MusicalInstrument
    {
        string _UkuleleDiscriptoin;
        public Ukulele(string name, string discriptoin)
        {
            _name = name;
            _UkuleleDiscriptoin = discriptoin;
        }
        public override void Desc()
        {
            Console.WriteLine($"Ukulele disciption - {_UkuleleDiscriptoin}");
        }
        public override void History()
        {
            Console.WriteLine("Ukulele history");
        }
        public override void Show()
        {
            Console.WriteLine(_name);
        }
        public override void Sound()
        {
            Console.WriteLine("Make Ukulele sound");
        }
    }
    class Cello : MusicalInstrument
    {
        string _CelloDiscriptoin;
        public Cello (string name, string discriptoin)
        {
            _name = name;
            _CelloDiscriptoin = discriptoin;
        }
        public override void Desc()
        {
            Console.WriteLine($"Cello disciption - {_CelloDiscriptoin}");
        }
        public override void History()
        {
            Console.WriteLine("Cello history");
        }
        public override void Show()
        {
            Console.WriteLine(_name);
        }
        public override void Sound()
        {
            Console.WriteLine("Make Cello sound");
        }
    }

    // task 4
    abstract class Worker
    {
        abstract public void Print();
    }
    class Presidante : Worker
    {
        public override void Print()
        {
            Console.WriteLine("Presidante");
        }
    }
    class Security : Worker
    {
        public override void Print()
        {
            Console.WriteLine("Security");
        }
    }
    class Manager : Worker
    {
        public override void Print()
        {
            Console.WriteLine("Manager");
        }
    }
    class Engineer : Worker
    {
        public override void Print()
        {
            Console.WriteLine("Engineer");
        }
    }
}
