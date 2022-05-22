using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
    public interface IFactory
    {
        IRepository<Drone> GetDroneRepository();
    }
}
