using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
    public class Customer
    {
		IRepository<Drone> droneRepository;

		public Customer()
		{
            var factory = FactoryCreator.GetFactory();
            droneRepository = factory.GetDroneRepository();
		}

        public void sortDronesByMake()
		{
			droneRepository.Sort(new MakePredicate<Drone>());
			printDrones();
		}

        public void sortDronesByModel()
		{
			droneRepository.Sort(new ModelPredicate<Drone>());
			printDrones();
		}

        public void sortDronesByPrice()
		{
			droneRepository.Sort(new PricePredicate<Drone>());
			printDrones();
		}

        public void printDrones()
		{
			Console.WriteLine("Drones:");
			droneRepository.Print();
		}

        public string getMostPopularDroneMake()
        {
            var make = (from drone
                        in droneRepository.GetAll()
                        group drone by drone.Make into grp
                        orderby grp.Count() descending
                        select grp.Key).First();
            return make;
        }

        public string getMostPopularDroneModel()
        {
            var model = (from drone
                        in droneRepository.GetAll()
                        group drone by drone.Model into grp
                        orderby grp.Count() descending
                        select grp.Key).First();
            return model;
        }

        public decimal getTheLeastDronePrice()
        {
            var least = (from drone
                        in droneRepository.GetAll()
                        group drone by drone.Price into grp
                        orderby grp.Count() ascending
                        select grp.Key).First();
            return least;
        }

        public decimal getTheMostDronePrice()
        {
            var most = (from drone
                        in droneRepository.GetAll()
                         group drone by drone.Price into grp
                         orderby grp.Count() descending
                         select grp.Key).First();
            return most;
        }
    }
}
