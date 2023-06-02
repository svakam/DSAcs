using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Sort
{
    public class HeapSort : Helper
    {
        public static void Ascending(int[] arr)
        {
            int n = arr.Length;

            // build max heap on full tree starting at bottommost level above leaves going left up to the root
            for (int i = (n / 2) - 1; i >=0; i--)
            {
                Heapify(arr, n, i);
            }

            // heapsort: swap between last leaf and root, re-heapify at root, and repeat with next last leaf
            for (int i = n - 1; i >= 0; i--)
            {
                Swap(arr, i, 0);
                Heapify(arr, i, 0);
            }

        }

        private static void Heapify(int[] arr, int n, int i)
        {
            // set up references to current node, left and right children
            int largest = i; // temporary largest
            int left = (2 * i) + 1;
            int right = (2 * i) + 2;

            if (left < n && arr[largest] < arr[left]) // ensure a left child exists and set largest to largest between left and current
            {
                largest = left;
            }
            if (right < n && arr[largest] < arr[right]) // ensure a right child exists and set largest to largest amongst all 3
            {
                largest = right;
            }

            if (largest != i) // if largest isn't already current, swap with largest and heapify on where largest was to carry the smallest down until its children are smaller
            {
                // swap
                Swap(arr, i, largest);

                // heapify
                Heapify(arr, n, largest);
            }
        }
    }
}
