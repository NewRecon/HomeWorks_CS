using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _13._03._23_MVVM
{
    public class Car : INotifyPropertyChanged
    {
        string name;
        int price;
        string company;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChange();
            }
        }

        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChange();
            }
        }

        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
                OnPropertyChange();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}