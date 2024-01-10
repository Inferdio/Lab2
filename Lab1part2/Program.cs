using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1part2
{
    class Program
    {
        //функция получения суммы всех положительных элементов строки i
        static int GetSumLine(ref int[,] Matr,int i)
        {
            
            int cur = 0;
            for (int j = 0; j < Matr.GetLength(1); j++)
            {
                if (Matr[i, j] > 0)
                {
                    cur += Matr[i, j];
                }
            }
            return cur;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число строк: ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число столбцов: ");
            int M = int.Parse(Console.ReadLine());

            int[,] Matr = new int[N, M];
            Random random = new Random(10);
            //заполнение случаными числами и сразу вывод матрицы на экран
            for (int i = 0; i < N; i++)
            {
                String S = "";
                for (int j = 0; j < M; j++)
                {
                    Matr[i, j] = random.Next(10);//заполним случайными числами.
                    S = S + Matr[i, j] + '\t';
                }
                Console.WriteLine(S);
            }

            //Дана целочисленная прямоугольная матрица. Определить количество столбцов, не содержащих ни одного нулевого элемента. 
            int colnum = 0;
            for (int j = 0; j < M; j++)
            {
                bool isZero = false;
                for (int i = 0; i < N; i++)
                {
                    if (Matr[i, j] == 0)//нашли нуль
                    {
                        isZero = true;//установим isZero и выходим из цикла
                        break;
                    }
                }
                if (!isZero)
                {
                    colnum++;
                }
            }
            Console.WriteLine("количество столбцов, не содержащих ни одного нулевого = "+ colnum.ToString());


            //Характеристикой строки целочисленной матрицы назовем сумму ее положительных четных элементов.
            //Переставляя строки заданной матрицы, расположить их в соответствии с ростом характеристик.
            //Для получения характеристики строки по номеру сделаем функцию GetSumLine

            for (int i = 0; i < N; i++)
            {
                int firstsum = GetSumLine(ref Matr, i);
                for (int j = i+1; j < N; j++)
                {
                    int cursum = GetSumLine(ref Matr, j);
                    if (cursum < firstsum)//если характеристика меньше то меняем 
                    {
                        //поменяем строки i и j местами
                        for (int k = 0; k < M; k++)
                        {
                            int temp = Matr[i, k];
                            Matr[i, k] = Matr[j, k];
                            Matr[j, k] = temp;
                        }
                        firstsum = cursum;
                    }
                }
            }

            //вывод матрицы на экран
            for (int i = 0; i < N; i++)
            {
                String S = "";
                for (int j = 0; j < M; j++)
                {
                    S = S + Matr[i, j] + '\t';
                }
                Console.WriteLine(S);
            }
            Console.ReadLine();
        }
    }
}
