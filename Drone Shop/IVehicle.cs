using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
    public interface IVehicle
    {
        string Make { get; set; }
        string Model { get; set; }
        decimal Price { get; set; }
        bool IsAvailable { get; set; }
    }
}
