
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPZ_Sluck
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimerConvert();
            Console.WriteLine();
            Console.WriteLine();
            PrimerNoConvert();
            Console.Read();
        }
        private static void PrimerConvert()
        {
            Console.WriteLine("Пример с исправным кодом, с конвертацией типов: ");
            Console.Write("Введите число A: ");
            object A = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введите число В: ");
            object B = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Результат: {Multiplication(A, B)}");

            Console.WriteLine("Конец программы");

        }

        private static void PrimerNoConvert() //для предусмотрения исключения InvalidCastException
        {
            Console.WriteLine("Пример с неисправным кодом, без конвертации типов: ");
            Console.Write("Введите число A: ");
            object A = Console.ReadLine();

            Console.Write("Введите число В: ");
            object B = Console.ReadLine();

            Console.WriteLine($"Результат: {Multiplication(A, B)}");

            Console.WriteLine("Конец программы");

        }

        private static float Multiplication(object A1, object B1)
        {
            float result = 0;

            try
            {
                double A = (double)A1;
                double B = (double)B1;
                double C = A * B;

                result = (float)C;

                if (double.IsInfinity(C) || (Math.Abs(C - result) > double.Epsilon))
                    throw new UnderflowException("Потеря младших разрядов!");
            }

            catch (UnderflowException)
            {
                Console.WriteLine("Потеря младших разрядов!");
            }

            catch (InvalidCastException)
            {
                Console.WriteLine("Недопустимое преобразование!");
            }

            return result;
        }

        public class UnderflowException : Exception
        {
            public UnderflowException(string message) : base(message)
            {
            }
        }
    }
}
