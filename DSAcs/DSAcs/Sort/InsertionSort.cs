using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Sort
{
    public class InsertionSort
    {
        public static int[] Ascending(int[] arr)
        {
            int n = arr.Length; // this helps when array length is 1; for loop never runs and arr is immediately returned
            for (int i = 1; i < n; i++)
            {
                int key = arr[i]; // 'key' is the potential element to be sorted
                int j = i - 1; // reference to previous index

                // if key less than previous element, shift previous element up 1 until it's larger than the next previous element
                if (key < arr[j])
                {
                    while (j >= 0 && key < arr[j]) // (ensure j doesn't go below 0)
                    {
                        arr[j + 1] = arr[j];
                        j--;
                    }
                    arr[j + 1] = key;
                }
            }

            return arr;
        }
    }
}
