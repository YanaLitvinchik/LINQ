using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Изучаемые методы LINQ:
//• First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault(поэлементные операции);
//• Count, Sum, Average, Max, Min, Aggregate(агрегирование);
//• Range(генерирование последовательностей).

namespace Linq_tasks_begin
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            var data = new int[] {r.Next(-10,10), r.Next(-10, 10), r.Next(-10, 10), r.Next(-10, 10), r.Next(-10, 10), r.Next(-10, 10),
                                    r.Next(-100,100),r.Next(-100,100),r.Next(-100,100),r.Next(-100,100),r.Next(-100,100),r.Next(-100,100),r.Next(-100,100)};

            var strings = new string[] { "One", "Two", "Data", "Dobro", "Ukraine", "Found", "Environment", "redivider", "A", "B", "C" };

            var bigs = new string[] { "ONE", "LOVE", "ABCD", "REDIVIDER", "TOGETHER" };
            int A = r.Next(0, 10);
            int B = r.Next(A + 1, 20);
            char C = 'o';
            int D = r.Next(0, 10);
            int L = r.Next(0, 10);
            float N = r.Next(1, 15);

            foreach (var item in data)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            foreach (var item in strings)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();
            //1.Вывести первый положительный элемент и последний отрицательный элемент коллекции data.
            Console.WriteLine($"First positive element :{data.Where(item => item > 0).First()}");
            //2. Дана цифра D (однозначное целое число) и целочисленная последовательность data.
            //Вывести первый положительный элемент последовательности data, оканчивающийся цифрой D.
            //Если требуемых элементов в последовательности data нет, то вывести 0.
            Console.WriteLine($"Element ended number 5 :{data.Where(x => x > 0 && x % 10 == D).FirstOrDefault() }");
            //3. Дано целое число L (> 0) и строковая последовательность strings.Вывести последнюю строку из strings, 
            //начинающуюся с цифры и имеющую длину L.Если требуемых строк в последовательности strings нет, то вывести строку «Not found».
            //Указание.Для обработки ситуации, связанной с отсутствием требуемых строк, использовать оператор ??.null??right            
            Console.WriteLine($"3){strings.LastOrDefault(x => x.Length == L && Char.IsDigit(x.First())) ?? "Not found"}");
            //char C = (char)r.Next(97, 123);
            //4. Дан символ С и строковая последовательность strings.Если strings содержит единственный 
            //элемент, оканчивающийся символом C, то вывести этот элемент; если требуемых строк в strings нет,
            //то вывести пустую строку; если требуемых строк больше одной, то вывести строку «Error».
            //Указание.Использовать try-блок для перехвата возможного исключения.
            try
            {
                Console.WriteLine(strings.SingleOrDefault(x => x.Last() == C) ?? "");

            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }

            //5. Дан символ С и строковая последовательность strings.Найти количество элементов strings,
            //которые содержат более одного символа и при этом начинаются и оканчиваются символом C.
            Console.WriteLine($"{strings.Where(x => x.Last() == C && x.Last() == C || x.First() == C).Count()}");
            //6. Дана строковая последовательность strings. Найти сумму длин всех строк, входящих в данную последовательность.
            Console.WriteLine(strings.Sum(x => x.Length));
            //7. Дана целочисленная последовательность data. Найти количество ее отрицательных элементов,
            //а также их сумму. Если отрицательные элементы отсутствуют, то дважды вывести 0.

            Console.WriteLine(data.Where(x => x < 0).Sum());
            Console.WriteLine(data.Where(x => x < 0).Count());

            //8. Дана целочисленная последовательность data. Найти количество ее положительных двузначных элементов,
            //а также их среднее арифметическое (как вещественное число). Если требуемые элементы отсутствуют, 
            //то дважды вывести 0 (первый раз как целое, второй — как вещественное).
            Console.WriteLine("\n----------------------------8-----------------------------\n");
            Console.WriteLine(data.Where(x => x > 9 && x < 100).Count());
            Console.WriteLine(data.Where(x => x > 9 && x < 100).Average());
            //9. Дана целочисленная последовательность data. Вывести ее минимальный положительный элемент или число 0,
            //если последовательность не содержит положительных элементов.
            Console.WriteLine("\n----------------------------9-----------------------------\n");
            Console.WriteLine(data.Where(x => x > 0).Min());

            //10.Дано целое число L(> 0) и строковая последовательность bigs.Строки последовательности bigs содержат только заглавные
            //буквы латинского алфавита.Среди всех строк из bigs, имеющих длину L, найти наибольшую(в смысле лексикографического порядка). 
            //Вывести эту строку или пустую строку, если последовательность не содержит строк длины L.
            Console.WriteLine("\n----------------------------10-----------------------------\n");

            var bigs2 = new List<string>();
            foreach (string s in bigs)
            {
                if (s.ToUpper().StartsWith("A"))
                    bigs2.Add(s);
            }
            bigs2.Sort();

            foreach (string s in bigs2)
                Console.WriteLine(s);

            //11. Дана последовательность непустых строк strings. Используя метод Aggregate, 
            //получить строку, состоящую из начальных символов всех строк исходной последовательности.
            Console.WriteLine("\n----------------------------11-----------------------------\n");

            string result = strings.Aggregate
            (
                new StringBuilder(strings.Length),
                 (buff, c) => buff.Append(c[0]),
        
                buff => buff.ToString()
            );
           
            foreach (var item in result)
            {
                Console.Write(item+ " ");
                
            }
            Console.WriteLine();
            //12.Дана целочисленная последовательность data.Используя метод Aggregate,
            //найти произведение последних цифр всех элементов последовательности.
            //Чтобы избежать целочисленного переполнения, при вычислении произведения использовать вещественный числовой тип.     
            Console.WriteLine(  data.Aggregate(1,(a, b) => a * (b % 10)));
            //13. Дано целое число N (> 0). Используя методы Range и Sum, найти сумму 1 + (1/2) + … + (1/N) (как вещественное число).

            //14. Даны целые числа A и B(A<B). Используя методы Range и Average, найти среднее арифметическое квадратов всех целых чисел от A до B включительно: (A^2 + (A+1)^2 + … + B^2)/(B − A + 1) (как вещественное число).

            //15. Дано целое число N(0 ≤ N ≤ 15). Используя методы Range и Aggregate, найти факториал числа N: N! = 1·2·…·N при N ≥ 1; 0! = 1. Чтобы избежать целочисленного переполнения, при вычислении факториала использовать вещественный числовой тип.
        }
    }
}
