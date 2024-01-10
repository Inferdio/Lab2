using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число элементов массива: ");            
            int N = int.Parse(Console.ReadLine());
            if (N > 0)
            {
                Console.WriteLine("Введите элементы массива: ");
                double[] Mas = new double[N];
                for (int i = 0; i < N; i++)
                {
                    Mas[i] = double.Parse(Console.ReadLine());
                }
                //В одномерном массиве, состоящем из N вещественных элементов, вычислить
                //1) сумму положительных элементов массива
                //2) произведение элементов массива, расположенных между максимальным по модулю и минимальным по модулю элементами.
                double Sum = 0;
                int tmp;
                int min = 0;//индекс мин.элемента
                int max = 0;//индекс макс.элемента
                for (int i = 0; i < N; i++)
                {
                    if (Mas[i] > 0)
                    {
                        Sum += Mas[i];
                    }

                    if (i > 0 && Math.Abs(Mas[i]) < Math.Abs(Mas[min]))
                    {
                        min = i;
                    }
                    if (i > 0 && Math.Abs(Mas[i]) > Math.Abs(Mas[max]))
                    {
                        max = i;
                    }
                }
                Console.WriteLine("Сумма положительных элементов = " + Sum.ToString());

                if (max < min)
                {
                    tmp = max;
                    max = min;
                    min = max;
                }
                if (max - min >= 2) {//между мин и макс есть хоть один элемент
                    double Pro = Mas[min + 1];
                    for (int i = min + 2; i < max; i++)
                    {
                        Pro *= Mas[i];
                    }
                    Console.WriteLine("Произведение элементов массива между мин. и макс. значениями по модулю = " + Pro.ToString());
                }
                else
                {
                    Console.WriteLine("Между мин. и макс. значениями по модулю нет элементов!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода числа элементов массива!");
            }
            Console.ReadLine();
        }
    }
}
