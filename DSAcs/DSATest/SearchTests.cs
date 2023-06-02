using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSAcs.Search;

namespace DSATest
{
    [TestClass]
    public class SearchTests
    {
        [TestMethod]
        public void TestBinarySearch()
        {
            int[] arr = new int[] { 3, 6, 10, 12, 15 };
            Assert.IsNull(BinarySearch.Run(arr, 11));
            Assert.IsNull(BinarySearch.Run(arr, 9));
            Assert.IsNull(BinarySearch.Run(arr, 5));
            Assert.IsNull(BinarySearch.Run(arr, 2));
            Assert.IsNull(BinarySearch.Run(arr, 14));
            Assert.IsNull(BinarySearch.Run(arr, 16));
            Assert.AreEqual(2, BinarySearch.Run(arr, 10));
            Assert.AreEqual(1, BinarySearch.Run(arr, 6));
            Assert.AreEqual(4, BinarySearch.Run(arr, 15));
            arr = new int[] { 2, 4, 10, 20, 23, 29 };
            Assert.IsNull(BinarySearch.Run(arr, 11));
            Assert.IsNull(BinarySearch.Run(arr, 22));
            Assert.IsNull(BinarySearch.Run(arr, 25));
            Assert.AreEqual(5, BinarySearch.Run(arr, 29));
            Assert.AreEqual(3, BinarySearch.Run(arr, 20));
            Assert.AreEqual(1, BinarySearch.Run(arr, 4));
        }

        [TestMethod]
        public void TestBinarySearchRecursion()
        {
            int[] arr = new int[] { 3, 6, 10, 12, 15 };
            int low = 0;
            int high = arr.Length - 1;
            Assert.IsNull(BinarySearch.RunRecursion(arr, 11, low, high));
            Assert.IsNull(BinarySearch.RunRecursion(arr, 9, low, high));
            Assert.IsNull(BinarySearch.RunRecursion(arr, 5, low , high));
            Assert.IsNull(BinarySearch.RunRecursion(arr, 2, low, high));
            Assert.IsNull(BinarySearch.RunRecursion(arr, 14, low, high));
            Assert.IsNull(BinarySearch.RunRecursion(arr, 16, low, high));
            Assert.AreEqual(2, BinarySearch.RunRecursion(arr, 10, low, high));
            Assert.AreEqual(1, BinarySearch.RunRecursion(arr, 6, low, high));
            Assert.AreEqual(4, BinarySearch.RunRecursion(arr, 15, low, high));
            arr = new int[] { 2, 4, 10, 20, 23, 29 };
            high = arr.Length - 1;
            Assert.IsNull(BinarySearch.RunRecursion(arr, 11, low, high));
            Assert.IsNull(BinarySearch.RunRecursion(arr, 22, low, high));
            Assert.IsNull(BinarySearch.RunRecursion(arr, 25, low, high));
            Assert.AreEqual(5, BinarySearch.RunRecursion(arr, 29, low, high));
            Assert.AreEqual(3, BinarySearch.RunRecursion(arr, 20, low, high));
            Assert.AreEqual(1, BinarySearch.RunRecursion(arr, 4, low, high));
        }

        //[TestMethod]
        //public void TestTime()
        //{
        //    int[] arr = new int[] { 3, 6, 10, 12, 15 };
        //    Search.Time(BinarySearch.Run(arr, 2));
        //}
    }
}
