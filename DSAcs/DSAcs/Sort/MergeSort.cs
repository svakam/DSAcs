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
            if (low < high)
            {
                int mid = (low + high) / 2;
                Ascending(arr, helper, low, mid);
                Ascending(arr, helper, mid + 1, high);
                Merge(arr, helper, low, mid, high);
            }
        }

        public static void Merge(int[] arr, int[] helper, int low, int mid, int high)
        {
            for (int i = low; i <= high; i++)
            {
                helper[i] = arr[i];
            }

            int helperLeft = low;
            int helperRight = mid + 1;
            int current = low;

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

            int remaining = mid - helperLeft;
            for (int i = 0; i <= remaining; i++)
            {
                arr[current + i] = helper[helperLeft + i];
            }
        }
    }
}
