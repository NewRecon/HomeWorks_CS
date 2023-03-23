using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace _13._03._23_MVVM
{
    public class ViewModel : INotifyPropertyChanged
    {
        public static ObservableCollection<Car> cars { get; set; }
        Car selectedCar;

        public Car SelectedCar
        {
            get { return selectedCar; }
            set
            {
                selectedCar = value;
                OnPropertyChange("SelectedCar");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public ViewModel()
        {
            cars = new ObservableCollection<Car>
            {
                new Car{ Name = "2101", Company = "VAZ", Price = 5000},
                new Car{ Name = "Rapid", Company = "Skoda", Price = 10000},
                new Car{ Name = "Tahoe", Company = "Chevrolet", Price = 50000}
            };
        }

        RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
            {
                Car car = new Car
                {
                    Name = "CX-70",
                    Company = "Volvo",
                    Price = new Random().Next(10000,20000)
                };
                cars.Add(car);
            }));
            }
        }
    }
}
