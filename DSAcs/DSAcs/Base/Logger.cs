using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Base
{
    public class Logger
    {
        public static void Log(object log)
        {
            Console.WriteLine(log.ToString());
        }
    }
}
