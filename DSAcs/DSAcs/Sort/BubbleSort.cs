using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Sort
{
    public class BubbleSort : Helper
    {
        public static int[] AscendingFlag(int[] arr)
        {
            bool swappedOnThisPass;
            do
            {
                swappedOnThisPass = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    // if no elements were swapped, then array is fully sorted, exit while loop and return the array
                    if (arr[i] > arr[i + 1])
                    {
                        swappedOnThisPass = true; // swapped should occur, do the swap, then loop

                        // swap
                        arr = Swap(arr, i, i + 1);
                    }
                }
            }
            while (swappedOnThisPass);

            return arr;
        }

        public static int[] Ascending(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++) // iterate over all elements except last; j's iteration will include last; this will run regardless of when the array gets sorted, so n^2 time always
            {
                for (int j = 0; j < arr.Length - i - 1; j++) // for every iteration, the next largest element of the list is sorted toward the end, so don't need to deal with that side of the array anymore
                {
                    if (arr[j] > arr[j + 1])
                    {
                        arr = Swap(arr, j, j + 1);
                    }
                }
            }
            return arr;
        }
        
        public static int[] Descending(int[] arr)
        {
            StringBuilder sb = new StringBuilder("initial: ");
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append(arr[i]);
            }
            Console.WriteLine(sb.ToString());
            for (int i = arr.Length - 1; i > 0; i--)
            {
                for (int j = arr.Length - 1; j > arr.Length - i; j--)
                {
                    if (arr[j] > arr[j - 1])
                    {
                        arr = Swap(arr, j, j - 1);
                    }
                }
                int k = i - arr.Length;
                sb = new StringBuilder($"on {k}");
                for (k = 0; k < arr.Length; k++)
                {
                    sb.Append(arr[k]);
                }
                Console.WriteLine(sb.ToString());
            }
            return arr;
        }
    }
}
