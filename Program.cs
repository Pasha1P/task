//Погудин Павел 2ИСП
//Есть массив целых чисел размером 10. Значения задаются двумя способами:
//a) Вводятся пользователем с клавиатуры.
//b) Генерируются случайные числа в заданном пользователем диапазоне.
//С клавиатуры вводится два числа - порядковые номера элементов массива, которые
//необходимо суммировать. Например, если ввели 3 и 5 - суммируются 3-й и 5-й элементы.
//Нужно предусмотреть случаи, когда были введены не числа, и когда одно из чисел, или оба
//больше размера массива.

using System;

namespace Задание
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int input = 0, exit = 1, number1, number2, err = 1;
            int[] massiv = new int[10];
            Console.Title = "Задание";
            Console.WriteLine("\tЗдраствуйте!");

            while (exit == 1)
            {
                try
                {
                    while (true)
                    {
                        Console.Write("Если вы хотите заполнить масив вручную нажмите 1 иначе другую цифру:  ");
                        input = Convert.ToInt32(Console.ReadLine());

                        if (input == 1)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                try
                                {
                                    Console.Write("\tВведите {0} элемент ", i + 1);
                                    massiv[i] = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException fe)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Исключение формата. Ошибка: " + fe.Message);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    i--;
                                }
                                catch (Exception e)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Что то пошло не так. Ошибка: " + e.Message);
                                    Console.ForegroundColor = ConsoleColor.White;
                                    i--;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                massiv[i] = r.Next(100);
                            }
                        }
                        Console.WriteLine("\tполучился мвссив: ");
                        for (int i = 0; i < 10; i++)
                        {
                            Console.Write("\t" + massiv[i]);
                        }
                        Console.WriteLine("   ");
                        while (err == 1)
                        {
                            Console.Write("Введите номер первого числа ");
                            number1 = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите еомер второго числа ");
                            number2 = Convert.ToInt32(Console.ReadLine());

                            if (number1 <= 10 && number2 <= 10 && number1 > 0 && number2 > 0)
                            {
                                Console.WriteLine("Сумма элементов: {0}", massiv[number1 - 1] + massiv[number2 - 1]);
                                err = 0;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Произошла ошибка!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        err = 1;
                        Console.WriteLine("если хотите выйти нажмите 0, иначе другую цифру");
                        exit = Convert.ToInt32(Console.ReadLine());
                        if (exit == 0) break;
                        Console.Clear();
                    }
                }
                catch (InvalidCastException ice)                  //Исключение, которое выдается в случае недопустимого приведения или явного преобразования.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Недопустимое исключение приведения. Ошибка: " + ice.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (ArgumentOutOfRangeException aoore)        //Исключение, которое выдается, если значение аргумента не соответствует допустимому диапазону значений, установленному вызванным методом.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Исключение аргумента вне диапазона. Ошибка: " + aoore.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (FormatException fe)                       //Исключение, которое возникает в случае, если формат аргумента недопустим или строка составного формата построена неправильно.
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Исключение формата. Ошибка: " + fe.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (Exception e)                              //все исключения
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Что то пошло не так. Ошибка: " + e.Message);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            Console.WriteLine("\tДо свидания!");
            Console.ReadKey();
        }
    }
}
