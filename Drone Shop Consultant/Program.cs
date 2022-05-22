using System;

namespace Drone_Shop_Admin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ConsultantMenu menu = new ConsultantMenu();
            menu.ShowMenu();
        }
    }
}
