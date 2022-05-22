using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
    public class TextFileFactory : IFactory
    {
        public IRepository<Drone> GetDroneRepository()
        {
            return new TextFileRepository<Drone>();
        }
    }
}
