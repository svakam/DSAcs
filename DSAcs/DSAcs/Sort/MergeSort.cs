using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSAcs.Sort
{
    public class MergeSort
    {
        public static void Ascending(int[] arr)
        {
            int[] helper = new int[arr.Length];
            Ascending(arr, helper, 0, arr.Length - 1);
        }

        public static void Ascending(int[] arr, int[] helper, int low, int high)
        {
            if (low < high) // no recursion if subarray is just 1 element
            {
                int mid = (low + high) / 2;
                Ascending(arr, helper, low, mid);
                Ascending(arr, helper, mid + 1, high); // recurse on two halves of the given array/subarray
                Merge(arr, helper, low, mid, high); // sort and 'merge' the two halves back into the array
            }
        }

        public static void Merge(int[] arr, int[] helper, int low, int mid, int high)
        {
            // copy both halves into helper
            for (int i = low; i <= high; i++)
            {
                helper[i] = arr[i];
            }

            int helperLeft = low;
            int helperRight = mid + 1;
            int current = low;

            // iterate through helper array
            // compare left and right half, copying back the smaller of the two elements into the original array
            while (helperLeft <= mid && helperRight <= high)
            {
                if (helper[helperLeft] <= helper[helperRight])
                {
                    arr[current] = helper[helperLeft];
                    helperLeft++;
                }
                else
                {
                    arr[current] = helper[helperRight];
                    helperRight++;
                }
                current++;
            }

            // copy the rest of the left side of the array into the target array
            // won't be copied if the left has already been fully copied over
            // don't need to copy the right half because it's already been already there
            int remaining = mid - helperLeft;
            for (int i = 0; i <= remaining; i++)
            {
                arr[current + i] = helper[helperLeft + i];
            }
        }
    }
}
