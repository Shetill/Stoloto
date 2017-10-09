using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Stoloto
{

    class Program
    {
        static void Main(string[] args)
        {

            SetProgrammCommand("Выберите действие:\n 1 - сгенерировать набор случайных чисел; \n 2 - вывести статистику тиражей лотерии;");

            SetRestartAndEndProgramm("Начать программу сначала    - 1 \n\rЗавершить программу и выйти - любая клавиша (кроме - 1) \n\r");

        }

        static void ArrRandomNumber()
        {

            int start, end, a_lenght; //начальное и конечное число рандома. длина массива рандомных чисел (количество чисел, которые необходимо угадать)       

            int[][] array_result = new int[10][];
            Random rnd = new Random();

            Console.WriteLine("Укажите начальное число:");
            start = int.Parse(Console.ReadLine());
            Console.WriteLine("Укажите конечное число:");
            end = int.Parse(Console.ReadLine());

            int[] arr_rnd_num = Enumerable.Range(start, end).OrderBy(i => rnd.Next()).ToArray();// Создадим числовой массив и отсортируем его рандомно

            Console.WriteLine("Укажите сколько чисел необходимо угадать:");
            a_lenght = int.Parse(Console.ReadLine());
            int b = end / a_lenght; //количество массивов с рандомными числами

            //Заполним значения
            for (int i = 0; i < b; i++)
            {
                array_result[i] = new int[a_lenght];
                for (int j = 0; j < a_lenght; j++)
                    array_result[i][j] = arr_rnd_num[i * a_lenght + j];
            }

            //Очистим консольку от всех бУкОвОк
            Console.Clear();

            //выведем результат на экран
            for (int i = 0; i < b; i++)
            {
                for (int j = 0; j < a_lenght; j++)
                    Console.Write(array_result[i][j] + "\t");
                Console.WriteLine();
                Console.WriteLine("===================================================");
            }

        }

        static void StatisticsCountRepiatNumber()
        {
            /*Console.WriteLine("Введеите сколько всего чисел, в лотерее:");
            int arr_lenght = int.Parse(Console.ReadLine());*/
            int arr_lenght = 49;

            int[] arr_count = new int[arr_lenght];

            ////открываем *.csv файл, предварительно отформатированный
            string file = Files.OpenFile();

            StreamReader str = new StreamReader(file);

            //Считываем данные из файла
            while (!str.EndOfStream)
            {
                string line = str.ReadLine();
                string[] arr_str = line.Split(' ');
                foreach (var item in arr_str)
                {
                    int num = 0;
                    if (Int32.TryParse(item, out num))
                    {
                        arr_count[num - 1]++;
                    }
                }
                Console.WriteLine(line);
            }

            string save_file_csv = "";

            for (int i = 0; i < arr_count.Length; i++)
            {
                save_file_csv = save_file_csv + (i + 1) + ";выпадало;" + arr_count[i] + ";раз \n\r";
            }

            //Сохраним результат расчётов в (*.csv) файл
            Files.SaveFile(save_file_csv);

        }

        static void SetProgrammCommand(string msg)
        {
            Console.WriteLine(msg);

            int.TryParse(Console.ReadLine(), out int begin);
            switch (begin)
            {
                case 1:
                    ArrRandomNumber();
                    break;
                case 2:
                    StatisticsCountRepiatNumber();
                    break;
                default:
                    Console.WriteLine("Такой команды не существует");
                    break;

            }

        }

        static void SetRestartAndEndProgramm(string msg)
        {

            Console.WriteLine(msg);

            int.TryParse(Console.ReadLine(), out int begin_2);

            switch (begin_2)
            {
                case 1:
                    string[] arg = { "" };
                    Console.Clear();
                    Main(arg);
                    break;
                default:
                    Console.WriteLine("До свидания");
                    Environment.Exit(0);
                    break;
            }

        }

    }

}
