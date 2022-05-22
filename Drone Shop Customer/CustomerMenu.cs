using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drone_Shop;

namespace Drone_Shop_User
{
    public class CustomerMenu
    {
		Customer customer;
		Consultant consultant;

		public CustomerMenu()
        {
			customer = new Customer();
			consultant = new Consultant();
        }

		public void ShowMenu()
		{
			string customerInput = "";
			do
			{
				ShowMainMenu();
				customerInput = Console.ReadLine();
				safeHandleCustomerInput(customerInput);
			}
			while (customerInput != "0");
		}

		void ShowMainMenu()
		{
			string menu = @"
Customer menu
Choose an option:
1: Get the most popular drone's make
2: Get the most popular drone's model
3: Get the cheapest drone's price
4: Get the most expensive drone's price
5: Sort drones by make 
6: Sort drones by model
7: Sort drones by price
b: Buy a drone
p: Print all drones
0: Exit customer menu";

			Console.WriteLine(menu);
		}

		void handleCustomerInput(string customerInput)
		{
			switch (customerInput)
			{
				case "1":
					Console.WriteLine(customer.getMostPopularDroneMake());
					break;
				case "2":
					Console.WriteLine(customer.getMostPopularDroneModel());
					break;
				case "3":
					Console.WriteLine(customer.getTheLeastDronePrice());
					break;
				case "4":
					Console.WriteLine(customer.getTheMostDronePrice());
					break;
				case "5":
					customer.sortDronesByMake();
					break;
				case "6":
					customer.sortDronesByModel();
					break;
				case "7":
					customer.sortDronesByPrice();
					break;
				case "b":
					consultant.SellDrone(consultant.enterIdx());
					break;
				case "p":
					customer.printDrones();
					break;
				case "0":
					break;
				default:
					Console.WriteLine("Wrong option\n");
					break;
			}
		}

		void safeHandleCustomerInput(string customerInput)
		{
			try
			{
				handleCustomerInput(customerInput);
			}
			catch (Error error)
			{
				Logger.Instance().LogError(error);
			}

			catch
			{
				Logger.Instance().LogError(new Error(ErrorCode.UnknownError));
			}
		}
	}
}
