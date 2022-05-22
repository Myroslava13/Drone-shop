using System;

namespace Drone_Shop_User
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CustomerMenu menu = new CustomerMenu();
            menu.ShowMenu();
        }
    }
}
