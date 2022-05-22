using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone_Shop
{
    public class Logger
    {
        private static Logger instance = new Logger();
        string fileName = "C:/Users/Private/source/repos/Drone Shop/Errors.txt";

        private Logger() { }

        public static Logger Instance()
        {
            return instance;
        }

        public void LogError(Error error)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(error.ToString() + " " + DateTime.Now.ToString("d", DateTimeFormatInfo.InvariantInfo));
            }
        }
    }
}
