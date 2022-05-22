using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
    static public class FactoryCreator
    {
        public static IFactory GetFactory()
        {
            var type = ConfigurationManager.AppSettings["FactoryType"];

            if (type == "text")
                return new TextFileFactory();
            else
                return new MemoryFactory();
        }
    }
}
