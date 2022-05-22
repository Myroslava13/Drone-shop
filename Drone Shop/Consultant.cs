using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
    public class Consultant
    {
        IRepository<Drone> droneRepository;
        IRepository<Drone> soldDroneRepository;
        Money money;

        public Consultant()
        {
            var factory = FactoryCreator.GetFactory();
            droneRepository = factory.GetDroneRepository();
            soldDroneRepository = new MemoryRepository<Drone>();
            money = new Money();
        }

        public void addDrone()
        {
            droneRepository.Add(new Drone());
        }

        public void addSeveralDrones(int n)
        {
            Drone drone = new Drone();
            for (int i = 0; i < n; i++)
            {
                droneRepository.Add(drone);
            }
        }

        public void removeDrone(int idx)
        {
            droneRepository.Remove(idx);
        }

        public void removeLastDrones(int n)
        {
            for (int i = 0; i < n; i++)
            {
                droneRepository.Remove(droneRepository.Size - 1);
            }
        }

        public void removeDronesByMake(string make)
        {
            for (int i = 0; i < droneRepository.Size; i++)
            {
                if (droneRepository[i].Make == make)
                {
                    droneRepository.Remove(i);
                    i--;
                }
            }
        }

        public void removeDronesByModel(string model)
        {
            for (int i = 0; i < droneRepository.Size; i++)
            {
                if (droneRepository[i].Model == model)
                {
                    droneRepository.Remove(i);
                    i--;
                }
            }
        }

        public void replaceDrone(int idx)
        {
            droneRepository.Replace(new Drone(), idx);
        }

        public void printDrones()
        {
            Console.WriteLine("Drons:");
            droneRepository.Print();
        }

        public void printSoldDrones()
        {
            Console.WriteLine("Sold drones:");
            soldDroneRepository.Print();
        }

        public int enterIdx()
        {
            int idx;
            Console.WriteLine("Enter drone's id:");
            idx = int.Parse(Console.ReadLine());

            return idx;
        }

        public int enterQuantity()
        {
            int quantity;
            Console.WriteLine("Enter quantity:");
            quantity = int.Parse(Console.ReadLine());

            return quantity;
        }

        public string enterMake()
        {
            string make;
            Console.WriteLine("Enter drone's make:");
            make = Console.ReadLine();
            return make;
        }

        public string enterModel()
        {
            string model;
            Console.WriteLine("Enter drone's model:");
            model = Console.ReadLine();

            return model;
        }

        public bool makeIsInStock(string make)
        {
            if (droneRepository.GetAll().Find(d => d.Make == make) != null)
                return true;
            else
                return false;
        }

        public bool modelIsInStock(string model)
        {
            if (droneRepository.GetAll().Find(d => d.Model == model) != null)
                return true;
            else
                return false;
        }

        public decimal getCurrentAmountOfMoney()
        {
            return money.MoneyCount;
        }

        public void SellDrone(int idx)
        {
            money.AddToMoney(droneRepository[idx].Price);
            soldDroneRepository.Add(droneRepository[idx]);
            droneRepository.Remove(idx);
        }
    }
}
