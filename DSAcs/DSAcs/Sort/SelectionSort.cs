using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Sort
{
    public class SelectionSort
    {
        // iterate over all elements, store index of where the smallest element is, and swap ith element with where current smallest element is
        public static int[] SmallestToLargest(int[] arr)
        {
            int idxOfSmallest;

            for (int i = 0; i < arr.Length; i++) // iterate over every element
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
                arr = SwapElements(arr, i, idxOfSmallest);
            }

            return arr;
        }

        public static int[] LargestToSmallest(int[] arr)
        {
            int idxOfLargest;
            
            for (int i = 0; i < arr.Length; i++)
            {
                idxOfLargest = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > arr[idxOfLargest])
                    {
                        idxOfLargest = j;
                    }
                }

                // swap
                arr = SwapElements(arr, i, idxOfLargest);
            }

            return arr;
        }

        private static int[] SwapElements(int[] arr, int current, int idxOfLargestOrSmallest)
        {
            int temp = arr[idxOfLargestOrSmallest];
            arr[idxOfLargestOrSmallest] = arr[current];
            arr[current] = temp;
            return arr;
        }
    }
}
