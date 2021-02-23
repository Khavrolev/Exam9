using System;

namespace Test_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var exceptions = new Exception[]{ new MyOwnException("Моё собственное исключение"),
                                              new FormatException(),
                                              new OverflowException(),
                                              new RankException(),
                                              new UriFormatException() };

            foreach(Exception exception in exceptions)
            {
                try
                {
                    throw exception;
                }
                catch (Exception e) when (e is MyOwnException)
                {
                    Console.WriteLine("Моя созданная ошибка");
                }
                catch (Exception e) when (e is FormatException)
                {
                    Console.WriteLine("Значение не находится в соответствующем формате для преобразования из строки методом преобразования");
                }
                catch (Exception e) when (e is OverflowException)
                {
                    Console.WriteLine("Арифметическое, приведение или операция преобразования приводят к переполнению");
                }
                catch (Exception e) when (e is RankException)
                {
                    Console.WriteLine("В метод передается массив с неправильным числом измерений");
                }
                catch (Exception e) when (e is UriFormatException)
                {
                    Console.WriteLine("Используется недопустимый универсальный код ресурса (URI)");
                }
                finally
                {
                    Console.WriteLine($"Конец данной итерации, где {exception.Message}");
                    Console.WriteLine();
                }
            }

            Console.Read();
        }
    }
    public class MyOwnException : Exception
    {
        public MyOwnException(string message) : base(message)
        {

        }
    }
}
