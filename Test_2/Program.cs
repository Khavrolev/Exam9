using System;

namespace Test_2
{
    class Program
    {
        public static string[] names = new string[] { "Хавролев", "Иванов", "Васильев", "Петров", "Григорьев" };
        static void Main(string[] args)
        {
            bool flag = true;

            var commandReader = new CommandReader();
            commandReader.WayToSortEvent += Sorting;

            Console.WriteLine("Массив до сортировки:");
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            do
            {
                try
                {
                    commandReader.Read(names);
                    flag = false;

                    Console.WriteLine("Массив после сортировки:");
                    foreach (string name in names)
                    {
                        Console.WriteLine(name);
                    }
                }
                catch (FormatException e) when (e is FormatException)
                {
                    Console.WriteLine("Было введено не число формата Int, введите ещё раз");
                }
                catch (MyOwnException e) when (e is MyOwnException)
                {
                    Console.WriteLine("Наш класс ошибки, Int должен быть 1 или 2");
                }
                catch (MyOwnException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (flag == true);
            
        }

       /// <summary>
       /// Сортировка в зависимости от поступившего значения
       /// </summary>
       /// <param name="names">Массив, который нужно сортировать</param>
       /// <param name="number">Способ сортировки</param>
       /// <returns>Если number == 1, то А-Я; если number == 2, то Я-А</returns>
        static void Sorting (int number)
        {
            if (number == 1)
                Array.Sort(names, (s1, s2) => String.Compare(s1, s2));
            else if (number == 2)
                Array.Sort(names, (s1, s2) => String.Compare(s2, s1));
        }
    }

    /// <summary>
    /// Класс для создания события
    /// </summary>
    public class CommandReader
    {
        public delegate void WayToSortDelegate(int number);
        public event WayToSortDelegate WayToSortEvent;

        public void Read(string[] names)
        {
            Console.WriteLine();
            Console.WriteLine("Введите способ сортировки");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2)
                throw new MyOwnException("Число формата Int должно быть равно либо 1 (А-Я), либо 2 (Я-А)");

            NumberEvent(number);
        }

        protected virtual void NumberEvent (int number)
        {
            WayToSortEvent?.Invoke(number);
        }
    }

    /// <summary>
    /// Класс собственного исключения
    /// </summary>
    public class MyOwnException : Exception
    {
        public MyOwnException(string message) : base(message)
        {

        }
    }
}
