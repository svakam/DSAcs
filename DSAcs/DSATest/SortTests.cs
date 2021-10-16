using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSAcs.Sort;

namespace DSATest
{
    [TestClass]
    public class SortTests
    {
        [TestMethod]
        public void TestSelectionSortAsc()
        {
            int[] arr = new int[] { 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            int[] actual = SelectionSort.SmallestToLargest(arr);
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void TestSelectionSortDesc()
        {
            int[] arr = new int[] { 5, 3, 8, 7, 6, 9, 10, 1, 2, 4 };
            int[] actual = SelectionSort.LargestToSmallest(arr);
            int[] expected = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            for (int i = 0; i < arr.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }
    }
}
