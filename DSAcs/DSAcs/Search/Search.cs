using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DSAcs.Search
{
    public static class Search
    {
        // inherited by any search class
        // search class inherits a stopwatch
        // stopwatch can be started, run the action, stopped, and return elapsed time
        public static Stopwatch Stopwatch {get; set;}

        public static TimeSpan Time(Action action)
        {
            Stopwatch = Stopwatch.StartNew();
            action();
            Stopwatch.Stop();
            return Stopwatch.Elapsed;
        }
    }
}
