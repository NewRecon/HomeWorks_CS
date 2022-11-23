using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace HW30._11._22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            // task 1

            //int[] A = new int[5];
            //double sum = 0;
            //double mult = 1;
            //double sumEven = 0;
            //double sumNotEvenColumns = 0;
            //for (int i = 0; i < A.Length; i++)
            //{
            //    A[i] = int.Parse(Console.ReadLine());
            //}
            //double max = A[0];
            //double min = A[0];
            //for (int i = 0; i < A.Length; i++)
            //{
            //    if (A[i] > max) max = A[i];
            //    if (A[i] < min) min = A[i];
            //    if (A[i] % 2 == 0) sumEven += A[i];
            //    sum += A[i];
            //    mult *= A[i];
            //    Console.Write($"{A[i]} ");
            //}
            //Console.WriteLine();
            //double[,] B = new double[3, 4];
            //for (int i = 0; i < B.GetLength(0); i++)
            //{
            //    for (int j = 0; j < B.GetLength(1); j++)
            //    {
            //        B[i, j] = random.Next(1, 100) + random.NextDouble();
            //        if (B[i, j] > max) max = B[i, j];
            //        if (B[i, j] < min) min = B[i, j];
            //        if (B[i, j] % 2 == 0) sumEven += B[i, j];
            //        if (j%2 != 0) sumNotEvenColumns += B[i, j];
            //        sum += B[i, j];
            //        mult *= B[i, j];
            //        Console.Write($"{B[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine($"Maximum value - {max}");
            //Console.WriteLine($"Minimum value - {min}");
            //Console.WriteLine($"Sum total - {sum}");
            //Console.WriteLine($"Mult total - {mult}");
            //Console.WriteLine($"Sum even elements from A array - {sumEven}");
            //Console.WriteLine($"Sum not even columns - {sumNotEvenColumns}");

            // task 2

            //int[,] array = new int[5, 5];
            //// заполняем массив
            //for (int i = 0; i < array.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array.GetLength(1); j++)
            //    {
            //        array[i, j] = random.Next(-100, 100);
            //        Console.Write($"{array[i, j]} ");
            //    }
            //    Console.WriteLine();
            //}
            //// находим минимум и максимум и записываем их индексы
            //int min = array[0, 0];
            //int max = array[0, 0];
            //int[] indexMin = new int[2];
            //int[] indexMax = new int[2];
            //for (int i = 0; i < array.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array.GetLength(1); j++)
            //    {
            //        if (array[i, j] > max)
            //        {
            //            max = array[i, j];
            //            indexMax[0] = i;
            //            indexMax[1] = j;
            //        }
            //        if (array[i, j] < min)
            //        {
            //            min = array[i, j];
            //            indexMin[0] = i;
            //            indexMin[1] = j;
            //        }
            //    }
            //}
            //// нормализуем интервал
            //if (indexMax[0] < indexMin[0])
            //{
            //    indexMin[0] = indexMax[0] + indexMin[0];
            //    indexMax[0] = indexMin[0] - indexMax[0];
            //    indexMin[0] = indexMin[0] - indexMax[0];
            //    indexMin[1] = indexMax[1] + indexMin[1];
            //    indexMax[1] = indexMin[1] - indexMax[1];
            //    indexMin[1] = indexMin[1] - indexMax[1];
            //}
            //if (indexMax[0] == indexMin[0])
            //{
            //    indexMin[1] = indexMax[1] + indexMin[1];
            //    indexMax[1] = indexMin[1] - indexMax[1];
            //    indexMin[1] = indexMin[1] - indexMax[1];
            //}
            //Console.WriteLine($"max = {max}, min = {min}");
            //Console.WriteLine($"max i = {indexMax[0]}, max j = {indexMax[1]}");
            //Console.WriteLine($"min i = {indexMin[0]}, min j = {indexMin[1]}");
            //// считаем сумму в интервале
            //int sum = 0;
            //for (int i = indexMin[0]; i <= indexMax[0]; i++)
            //{
            //    for (int j = 0, end = array.GetLength(1); j < end; j++)
            //    {
            //        if (i == indexMin[0] && j < indexMin[1]) j = indexMin[1]+1;
            //        if (i == indexMax[0] && end > indexMax[1]) end = indexMax[1];
            //        sum += array[i, j];
            //    }
            //}
            //Console.WriteLine(sum);

            // task 3

            //string str = Console.ReadLine();
            //int key = int.Parse(Console.ReadLine());
            //char[] chars = str.ToCharArray();
            //for (int i = 0;i< chars.Length;i++)
            //{
            //    if (chars[i] == ' ') continue;
            //    chars[i] = (char)(chars[i] + key);
            //}
            //Console.WriteLine(chars);
            //for (int i = 0; i < chars.Length; i++)
            //{
            //    if (chars[i] == ' ') continue;
            //    chars[i] = (char)(chars[i] - key);
            //}
            //Console.WriteLine(chars);

            // task 4

            //// задаём размер матриц
            //int row = int.Parse(Console.ReadLine());
            //int column = int.Parse(Console.ReadLine());
            //int[,] array1 = new int[row, column];
            //int[,] array2 = new int[row, column];
            //int[,] result = new int[row, column];
            //// ручной ввод значений матриц
            //for (int i = 0; i < array1.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array1.GetLength(1); j++)
            //    {
            //        array1[i, j] = int.Parse(Console.ReadLine());
            //    }
            //}
            //for (int i = 0; i < array1.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array1.GetLength(1); j++)
            //    {
            //        array2[i, j] = int.Parse(Console.ReadLine());
            //    }
            //}
            //// умножение на число
            //int num = int.Parse(Console.ReadLine());
            //for (int i = 0; i < result.GetLength(0); i++)
            //{
            //    for (int j = 0; j < result.GetLength(1); j++)
            //    {
            //        result[i, j] = num * array1[i, j];
            //    }
            //}
            //// сложение матриц
            //for (int i = 0; i < array1.GetLength(0); i++)
            //{
            //    for (int j = 0; j < array1.GetLength(1); j++)
            //    {
            //        result[i, j] = array1[i, j] + array2[i, j];
            //    }
            //}
            //// произведение матриц
            //if (row == column)
            //{
            //    for (int i = 0; i < array1.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < array1.GetLength(1); j++)
            //        {
            //            for (int m = 0; m < array2.GetLength(1); m++)
            //            {
            //                result[i, m] += array1[i, j] * array2[j, m];
            //            }
            //        }
            //    }
            //}

            // task 5

            //string str = Console.ReadLine();
            //bool flag = true;
            //for (int i = 0; i < str.Length; i++)
            //{
            //    if (str[i] == '-')
            //    {
            //        flag = false;
            //        break;
            //    }
            //}
            //float a, b, result;
            //if (flag)
            //{
            //    a = float.Parse(str.Substring(0, str.IndexOf('+')));
            //    b = float.Parse(str.Substring(str.IndexOf("+") + 1));
            //    result = a + b;
            //}
            //else
            //{
            //    a = float.Parse(str.Substring(0, str.IndexOf('-')));
            //    b = float.Parse(str.Substring(str.IndexOf("-") + 1));
            //    result = a - b;
            //}
            //Console.WriteLine(result);

            // task 6

            //string str = Console.ReadLine();
            //char[] chars = str.ToCharArray();
            //chars[0] = Char.ToUpper(chars[0]);
            //bool flag = false;
            //for (int i=0; i<chars.Length; i++)
            //{
            //    if (flag)
            //    {
            //        chars[i+1] = Char.ToUpper(chars[i+1]);
            //        flag = false;
            //    }
            //    if (chars[i] == '.' || chars[i] == '!' || chars[i] == '?') flag = true;
            //}
            //Console.WriteLine(chars);

            // task 7 

            String text = "To be, or not to be, that is the question,\r\nWhether 'tis nobler in the mind to suffer\r\nThe slings and arrows of outrageous fortune,\r\nOr to take arms against a sea of troubles,\r\nAnd by opposing end them? To die: to sleep;\r\nNo more; and by a sleep to say we end\r\nThe heart-ache and the thousand natural shocks\r\nThat flesh is heir to, 'tis a consummation\r\nDevoutly to be wish'd. To die, to sleep";
            // ввод кол-ва недопустимых слов
            int wordsCount = int.Parse(Console.ReadLine());
            string[] words = new string[wordsCount];
            // ручной ввод банка слов
            for (int i = 0; i < wordsCount;i++)
            {
                words[i] = Console.ReadLine();
            }
            // замена слов и редактирование строки
            int[] counter = new int[wordsCount];
            string buf;
            string result="";
            for (int i = 0; i < wordsCount; i++)
            {
                if (i == 0) buf = text;
                else buf = result;
                while (buf.Contains(words[i]))
                {
                    if (counter[i]==0) result = "";
                    counter[i]++;
                    result += buf.Substring(0, buf.IndexOf($"{words[i]}"));
                    for (int j = 0; j < words[i].Length; j++)
                    {
                        result += "*";
                    }
                    buf = buf.Substring(buf.IndexOf($"{words[i]}") + words[i].Length);
                }
                result += buf;
                // вывод статистики
                Console.WriteLine(counter[i]);
            }

            Console.WriteLine(result);





            Console.ReadLine();

        }
    }
}
