using Domain.Manage;
using System;
using Repository;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            gPartido gPartido = new gPartido();
           // string path = @"C:\Users\Oscar\Downloads\SP1.csv";

           // var lines = AppManage.getData();

            //foreach (var line in lines)
            //{
            //    var data = Manage.SubArray(line.Split(','), 1, 6);
            //}

            //for (int i = 1; i < lines.Length; i++)
            //{
            //    var data = AppManage.SubArray(lines[i].Split(','), 0, 6);
            //    var partido = AppManage.createMatch(data);
            //    gPartido.save(partido);
            //}

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}