using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stoloto

{

    class Files
    {

        static public string OpenFile()
        {
            //открываем *.csv файл, предварительно отформатированный
            Console.WriteLine("Укажите имя открываемого файла");
            string fileNameOpen = Console.ReadLine();
            return @"D:\stoloto\" + fileNameOpen + ".csv";
        }

        static public void SaveFile(string file_csv)
        {
            Console.WriteLine("Введите имя (*csv)файла:");
            string fileNameSave = Console.ReadLine();
            File.WriteAllText(@"D:\stoloto\" + fileNameSave + ".csv", file_csv, Encoding.UTF8);

        }
    }

}
