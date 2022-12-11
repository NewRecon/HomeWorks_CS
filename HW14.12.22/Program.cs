using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14._12._22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Jurnal j1 = new Jurnal("1", 1997, "dsd", "123", "dff", 2);
            //Jurnal j2 = new Jurnal("1", 1997, "dsd", "121", "dff", 2);

            //j2 = j2 + 3;
            //Console.WriteLine(j1 == j2);
            //Console.WriteLine(j1.Equals(j2));

            //j1.ShowInfo();
            //j2.ShowInfo();

            //Book b1 = new Book("111");
            //Book b2 = new Book("222");

            //BookList bl = new BookList();
            //bl.Add(b1);
            //bl.Add(b2);
        }
    }

    // task 1
    class Jurnal
    {
        string _title;
        int _foundationYear;
        string _description;
        string _phone;
        string _email;
        int _employerCounter;
        string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        int FoundationYear
        {
            get { return _foundationYear; }
            set { _foundationYear = value; }
        }
        string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        int EmployerCounter
        {
            get { return _employerCounter; }
            set { _employerCounter = value; }
        }
        public Jurnal(string title, int foundationYear, string description, string phone, string email, int employerCounter)
        {
            _title = title;
            _foundationYear = foundationYear;
            _description = description;
            _phone = phone;
            _email = email;
            _employerCounter = employerCounter;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{_title}, {_foundationYear}, {_description}, {_phone}, {_email}, {_employerCounter}");
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
        public string GetEmail()
        {
            return _email;
        }

        static public Jurnal operator + (Jurnal left, int right)
        {
            return new Jurnal ( left.Title, left.FoundationYear, left.Description, left.Phone, left.Email, left.EmployerCounter + right );
        }
        static public Jurnal operator - (Jurnal left, int right)
        {
            return new Jurnal( left.Title, left.FoundationYear, left.Description, left.Phone, left.Email, left.EmployerCounter - right );
        }
        static public bool operator == (Jurnal left, Jurnal right)
        {
            return left.EmployerCounter == right.EmployerCounter;
        }
        static public bool operator != (Jurnal left, Jurnal right)
        {
            return left.EmployerCounter != right.EmployerCounter;
        }
        static public bool operator < (Jurnal left, Jurnal right)
        {
            return left.EmployerCounter < right.EmployerCounter;
        }
        static public bool operator > (Jurnal left, Jurnal right)
        {
            return left.EmployerCounter > right.EmployerCounter;
        }
        public override string ToString()
        {
            return $"{Title}, {FoundationYear}, {Description}, {Phone}, {Email}, {EmployerCounter}";
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
    }

    // task 2
    class Shop
    {
        string _title;
        string _adress;
        string _description;
        string _phone;
        string _email;
        double _square;

        string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        string Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }
        string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        double Square
        {
            get { return _square; }
            set { _square = value; }
        }

        public Shop(string title, string adress, string description, string phone, string email, double square)
        {
            _title = title;
            _adress = adress;
            _description = description;
            _phone = phone;
            _email = email;
            _square = square;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"{_title}, {_adress}, {_description}, {_phone}, {_email}, {_square}");
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
        static public Shop operator +(Shop left, double right)
        {
            return new Shop( left.Title, left.Adress, left.Description, left.Phone, left.Email, left.Square + right );
        }
        static public Shop operator -(Shop left, double right)
        {
            return new Shop( left.Title, left.Adress, left.Description, left.Phone, left.Email, left.Square - right );
        }
        static public bool operator ==(Shop left, Shop right)
        {
            return left.Square == right.Square;
        }
        static public bool operator !=(Shop left, Shop right)
        {
            return left.Square != right.Square;
        }
        static public bool operator <(Shop left, Shop right)
        {
            return left.Square < right.Square;
        }
        static public bool operator >(Shop left, Shop right)
        {   
            return left.Square > right.Square;
        }
        public override string ToString()
        {
            return $"{Title}, {Adress}, {Description}, {Phone}, {Email}, {Square}";
        }
        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }
    }

    // task 3
    class BookList
    {
        List<Book> books = new List<Book>();
        public void Add (Book book)
        {
            books.Add(book);
        }
        public void Delete (int index)
        {
            books.Remove(books[index]);
        }
        public void ShowBookList()
        {
            foreach(Book book in books)
            {
                Console.WriteLine(book);
            }
        }
        public bool CheckBook(Book book)
        {
            for (int i=0;i<books.Count;i++)
            {
                if (book == books[i]) return true;
            }
            return false;
        }
        public Book this[int index]
        {
            get { return books[index]; }
            set { books[index] = value; }
        }
        static public bool operator < (BookList left, BookList right)
        {
            return left.books.Count < right.books.Count;
        }
        static public bool operator > (BookList left, BookList right)
        {
            return left.books.Count > right.books.Count;
        }
    }
    class Book
    {
        public string Title { get; set; }
        public Book(string title)
        {
            Title = title;
        }
        public override string ToString()
        {
            return Title;
        }

    }
}
