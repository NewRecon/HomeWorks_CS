using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace HW13._03._23
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //TASK 2

        double result = 0;
        //Символ для определения последней операции
        char operation = ' ';
        //Флаг для определения была ли нажата кнопка =
        //чтобы после нажатия = можно было начать вводить новое число поверх полученного ответа, а не дописывать ответ
        bool equal = false;

        //Ивент нажатия на цифры от 1 до 9
        private void Num_Click(object sender, RoutedEventArgs e)
        {
            if (mainField.Text == "0" || equal)
            {
                mainField.Text = (sender as Button).Content.ToString();
                equal = false;
            }
            else
                mainField.Text += (sender as Button).Content;
        }

        //Получение промежуточных результатолв вычислений
        private void GetTmpResult()
        {
            if (result == 0)
                result = Convert.ToDouble(mainField.Text);
            else
            {
                switch (operation)
                {
                    case '+':
                        result += Convert.ToDouble(mainField.Text);
                        break;
                    case '-':
                        result -= Convert.ToDouble(mainField.Text);
                        break;
                    case '/':
                        result /= Convert.ToDouble(mainField.Text);
                        break;
                    case '*':
                        result *= Convert.ToDouble(mainField.Text);
                        break;
                }
            }
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            if (mainField.Text != "0")
            {
                if (!equal)
                    mainField.Text += "0";
                else
                    mainField.Text = "0";
            }
        }

        private void ButtonCE_Click(object sender, RoutedEventArgs e)
        {
            mainField.Text = "0";
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            mainField.Text = "0";
            upperField.Text = "";
            result = 0;
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            equal = false;
            if (!mainField.Text.Contains(','))
                mainField.Text += ",";
        }

        private void ButtonDelLastChar_Click(object sender, RoutedEventArgs e)
        {
            equal = false;
            if (mainField.Text != "0")
            {
                if (mainField.Text.Length > 1)
                    mainField.Text = mainField.Text.Substring(0, mainField.Text.Length - 1);
                else
                    mainField.Text = "0";
            }
        }

        //Ивент нажатия на кнопку операции (+,-,/,*)
        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            GetTmpResult();
            upperField.Text += mainField.Text.Trim(',') + " " + (sender as Button).Content.ToString() +" ";
            operation = Convert.ToChar((sender as Button).Content);
            mainField.Text = "0";
        }

        //Ивент нажатия на кнопку =
        private void ButtonEq_Click(object sender, RoutedEventArgs e)
        {
            GetTmpResult();
            upperField.Text = "";
            operation = ' ';
            mainField.Text = result.ToString();
            result = 0;
            equal = true;
        }
    }
}