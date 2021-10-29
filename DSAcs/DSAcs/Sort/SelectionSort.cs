using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Sort
{
    public class SelectionSort : Helper // select the smallest or largest every iteration and sort it in the array
    {
        // iterate over all elements, store index of where the smallest element is, and swap ith element with where current smallest element is
        public static int[] Ascending(int[] arr)
        {
            int idxOfSmallest;

            for (int i = 0; i < arr.Length - 1; i++) // iterate over every element EXCEPT the very last, since j's iteration will take care of the last
            {
                idxOfSmallest = i;
                for (int j = i + 1; j < arr.Length; j++) // iterate over all elements AFTER ith element to see if jth element is smaller than ith element, and if so, store that index
                {
                    if (arr[j] < arr[idxOfSmallest])
                    {
                        idxOfSmallest = j;
                    }
                }

                // swap smallest element with ith element
                arr = Swap(arr, i, idxOfSmallest);
            }

            return arr;
        }

        //public static int[] Descending(int[] arr)
        //{
        //    int idxOfLargest;
            
        //    for (int i = 0; i < arr.Length - 1; i++)
        //    {
        //        idxOfLargest = i;
        //        for (int j = i + 1; j < arr.Length; j++)
        //        {
        //            if (arr[j] > arr[idxOfLargest])
        //            {
        //                idxOfLargest = j;
        //            }
        //        }

        //        // swap
        //        arr = Swap(arr, i, idxOfLargest);
        //    }

        //    return arr;
        //}
    }
}
