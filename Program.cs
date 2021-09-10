using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
u




namespace ConsoleApp33
{
    class MM
    {
        static void Main(string[] args)
        {
            DirectoryInfo d = new DirectoryInfo(@"d:\");
            string curDir = Environment.CurrentDirectory;

            char[] chars = Path.GetInvalidPathChars();

            foreach(char ch in chars)
            {
                if(curDir.Contains(ch))
                {
                    Console.WriteLine("Некорректный путь");
                }
            }


            //

            if (!d.Exists)
            {
                Console.WriteLine("Каталог не существует");
            }


            DirectoryInfo[] di = d.GetDirectories();

            foreach(DirectoryInfo d1 in di )
            {
                Console.WriteLine(" Full directory name {0}",d1.FullName);
                Console.WriteLine(" Directory LastAccess time {0}",d1.LastAccessTime);
                FileAttributes ff = d1.Attributes;
                Console.WriteLine("{0}", ff);


//                TimeSpan ts = DateTime.Now - d1.LastAccessTime;
//                if (ts.TotalMinutes > 30)
//                    d1.Delete();

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            FileInfo[] fi = d.GetFiles();

            long size = 0;

            foreach(FileInfo f1 in fi)
            {
                Console.WriteLine(" File full name {0}", f1.FullName);

                char[] charsf = Path.GetInvalidFileNameChars();

                foreach(char chf in charsf)
                {
                    if(f1.FullName.Contains(chf))
                    {
                        Console.WriteLine("Некорректное наименование файла");
                    }
                }

                Console.WriteLine(" File last access time {0}", f1.LastAccessTime);
                FileSecurity fs = f1.GetAccessControl();
                size += f1.Length;

//                TimeSpan ts = DateTime.Now - f1.LastAccessTime;
//                if (ts.TotalMinutes > 30)
//                f1.Delete();
            }

            Console.Read();
        }
    }
}
