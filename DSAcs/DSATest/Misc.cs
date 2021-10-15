using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATest
{
    [TestClass]
    public class Misc
    {
        [TestMethod]
        public void TestMath()
        {
            int low = 0;
            int high = 10;
            int high2 = 9;
            int z = low + high / 2;
            Assert.AreEqual(5, z);
            z = low + high2 / 2;
            Assert.AreEqual(4, z); // automatically rounds ints down

            decimal low2 = 0;
            decimal high3 = 9;
            decimal y = Math.Ceiling(low2 + high3 / 2); // if all values are decimal type, can call ceiling to round up
            Assert.AreEqual(5, y);

            int a = 5;
            int b = 6;
            decimal c = (decimal) (a + b) / 2; // can cast int final result of operation to decimal to get decimal output; (5 + 6) / 2 = (decimal) 5 -> 5.5
            Assert.AreEqual((decimal) 5.5, c);
        }
    }
}
