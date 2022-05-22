using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
	[Serializable]
	public class Drone : IVehicle
	{
		public Drone()
		{
			Console.WriteLine("Enter make:");
			this.Make = Console.ReadLine();
			Console.WriteLine("Enter model:");
			this.Model = Console.ReadLine();
			Console.WriteLine("Enter price:");
			decimal price = decimal.Parse(Console.ReadLine());
			if (price < 0)
				throw new Error(ErrorCode.IncorrectPrice);
			this.Price = price;
			Console.WriteLine("Enter status (+/-):");
			string status = Console.ReadLine();
			this.IsAvailable = (status == "+") ? true : false;
		}

		public Drone(string make = "", string model = "", decimal price = 0)
		{
			this.Make = make;
			this.Model = model;
			if (price < 0)
				throw new Error(ErrorCode.IncorrectPrice);
			this.Price = price;
		}

		public static bool operator ==(Drone d1, Drone d2)
		{
			return (d1.Make == d2.Make
						&& d1.Model == d2.Model
						&& d1.Price == d2.Price);
		}

		public static bool operator !=(Drone d1, Drone d2)
		{
			return !(d1 == d2);
		}

		public static bool operator >(Drone d1, Drone d2)
		{
			return (d1.Price > d2.Price);
		}

		public static bool operator <(Drone d1, Drone d2)
		{
			return (d1.Price < d2.Price);
		}

		public override string ToString()
		{
			string status = (IsAvailable == true) ? "+" : "-";
			return $"Drone: {Make} {Model} {Price}$, status: {status}";
		}

		public string Make { get; set; }
		public string Model { get; set; }
		public decimal Price { get; set; }
		public bool IsAvailable { get; set; }
	}
}
