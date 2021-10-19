using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Sort
{
    public class Helper
    {
        public static int[] Swap(int[] arr, int i, int j)
        {
            int temp = arr[j]; // temp store the next smallest/largest element
            arr[j] = arr[i]; // 'swap' ith element with where smallest/largest element was in array
            arr[i] = temp; // put smallest/largest element next in line (at i)
            return arr;
        }
    }
}
