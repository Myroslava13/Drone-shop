using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Drone_Shop;

namespace Drone_Shop_Admin
{
    public class ConsultantMenu
    {
        Consultant consultant;

        public ConsultantMenu()
        {
            consultant = new Consultant();
        }

        public void ShowMenu()
        {
            string consultantInput = "";
            do
            {
                showConsultantMenu();
                consultantInput = Console.ReadLine();
                safeHandleConsultantInput(consultantInput);
            }
            while (consultantInput != "0");
        }

        void showConsultantMenu()
        {
            string menu = @"
Consultant menu
Choose an option:
1: Add a new drone
2: Add the several drones
3: Remove a drone 
4: Remove the several last drones
5: Remove drones by make
6: Remove drones by model
7: Replace a drone
s: Sell a drone
p: Print all drones
ps: Print sold drones
m: Get current amount of money
0: Exit consultant menu";
            Console.WriteLine(menu);
        }

        void handleAdminInput(string adminInput)
        {
            switch (adminInput)
            {
                case "1":
                    consultant.addDrone();
                    Console.WriteLine("Drone was successfully added");
                    break;
                case "2":
                    consultant.addSeveralDrones(consultant.enterQuantity());
                    Console.WriteLine("Drones were successfully added");
                    break;
                case "3":
                    consultant.removeDrone(consultant.enterIdx());
                    Console.WriteLine("Drone was successfully removed");
                    break;
                case "4":
                    consultant.removeLastDrones(consultant.enterQuantity());
                    Console.WriteLine("Drones were successfully removed");
                    break;
                case "5":
                    consultant.removeDronesByMake(consultant.enterMake());
                    Console.WriteLine("Drones were successfully removed");
                    break;
                case "6":
                    consultant.removeDronesByModel(consultant.enterModel());
                    Console.WriteLine("Drones were successfully removed");
                    break;
                case "7":
                    consultant.replaceDrone(consultant.enterIdx());
                    Console.WriteLine("Drone was successfully replaced");
                    break;
                case "s":
                    consultant.SellDrone(consultant.enterIdx());
                    Console.WriteLine("Drone was successfully sold");
                    break;
                case "p":
                    consultant.printDrones();
                    break;
                case "ps":
                    consultant.printSoldDrones();
                    break;
                case "m":
                    Console.WriteLine(consultant.getCurrentAmountOfMoney() + "$");
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Wrong option\n");
                    break;
            }
        }

        void safeHandleConsultantInput(string consultantInput)
        {
            try
            {
                handleAdminInput(consultantInput);
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
