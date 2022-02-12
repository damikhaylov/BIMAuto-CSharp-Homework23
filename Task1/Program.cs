using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ***** Условие задачи *****

            Разработать асинхронный метод для вычисления факториала числа. В методе Main выполнить проверку работы метода.
            */

            Console.WriteLine("Определение факториала числа с использованием асинхронного метода");

            // Получение от пользователя аргумента факториала с помощью метода InputFactorialArgument
            ulong factorialArgument = InputFactorialArgument();


            FactorialAsync(factorialArgument); // Вызов асинхронного метода, вычисляющего факториал числа

            // Отрисовка на экране ряда из 70-ти звёздочек (выполняется одновременно с вычислением факториала)
            for (int i = 0; i < 70; i++)
            {
                Console.Write('*');
            }

            Console.ReadKey();
        }
        static ulong Factorial(ulong f)
        // Метод для вычисления факториала
        {
            ulong result = 1;
            for (ulong i = 1; i <= f; i++)
            {
                result *= i;
            }
            return result;
        }
        static async void FactorialAsync(ulong f)
        // Асинхронный метод для вычисления факториала, выводит результат в консоль
        {
            ulong factorialResult = 0;
            Console.WriteLine($"Начало вычисления факториала числа {f}\n");
            await Task.Run(() => { factorialResult = Factorial(f); }); // выполняется асинхронно
            Console.Write($" Факториал числа {f} равен {factorialResult} ");
        }

        static ulong InputFactorialArgument()
        // Метод запрашивает у пользователя аргумент факториала и проверяет ошибки ввода
        {
            ulong factorialArgument;
            while (true)
            {
                Console.Write("\nВведите аргумент факториала: ");
                try
                {
                    factorialArgument = Convert.ToUInt64(Console.ReadLine());
                    if (factorialArgument > 0)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception("Значение аргумента факториала — неположительное число.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nОшибка! {ex.Message}");
                }
            }
            Console.WriteLine();
            return factorialArgument;
        }
    }
}
