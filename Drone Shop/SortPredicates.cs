using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
    public class MakePredicate<T> : IComparer<T> where T : IVehicle
    {
        public int Compare(T item1, T item2)
        {
            return String.Compare(item1.Make, item2.Make);
        }
    }

    public class ModelPredicate<T> : IComparer<T> where T : IVehicle
    {
        public int Compare(T item1, T item2)
        {
            return String.Compare(item1.Model, item2.Model);
        }
    }

    public class PricePredicate<T> : IComparer<T> where T : IVehicle
    {
        public int Compare(T item1, T item2)
        {
            return item1.Price.CompareTo(item2.Price);
        }
    }
}
