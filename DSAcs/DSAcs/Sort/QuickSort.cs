using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Sort
{
    public class QuickSort : Helper
    {
        public static PivotMethod MethodOfPivot { get; set; }
        public static void Ascending(int[] arr, PivotMethod pivotMethod)
        {
            MethodOfPivot = pivotMethod;
            Ascending(arr, 0, arr.Length - 1);
        }

        public static void Ascending(int[] arr, int left, int right)
        {
            // partition, then sort each side around pivot in each
            int indexToPartitionOn = Partition(arr, left, right);
            if (left < indexToPartitionOn - 1) // if there is still a left side to quick sort (size of subset is > 1), then recurse to re-partition it and swap
            {
                Ascending(arr, left, indexToPartitionOn - 1);
            }
            if (indexToPartitionOn < right) // if there is still a right side to quick sort (size of subset is > 1), then recurse to re-partition it and swap
            {
                Ascending(arr, indexToPartitionOn, right);
            }
        }

        // pick a pivot point, swap all elements around the pivot until all elements left of pivot are smaller than all elements on the right of pivot
        private static int Partition(int[] arr, int left, int right)
        {   
            int pivotIndex = SetPivot(arr, left, right, MethodOfPivot);
            int pivot = arr[pivotIndex];

            while (left <= right) // only break out of swapping potential when left and right bounds have crossed
            {
                while (arr[left] < pivot) left++; // find element on left of pivot that's larger than pivot and which should be swapped to the right with an element that's smaller than or is the pivot
                while (arr[right] > pivot) right--; // find element on right of pivot that's smaller than pivot and which should be swapped to the left with an element that's larger than or is the pivot

                if (left <= right) // swap the given elements left and right of the pivot; potential exists for swapping on the pivot/same element
                {
                    Swap(arr, left, right);

                    left++;
                    right--; // move left and right one more, now that swap is complete, to further check rest of the partition
                }
            }

            return left; // this acts as a reference to decide the midpoint of next partition if needed
        }

        private static int SetPivot(int[] arr, int left, int right, PivotMethod methodOfPivot)
        { 
            switch (methodOfPivot)
            {
                case PivotMethod.FIRST:
                    return left;
                case PivotMethod.LAST:
                    return right;
                case PivotMethod.MIDDLE:
                    return (left + right) / 2;
                case PivotMethod.RANDOM:
                    Random rand = new();
                    return rand.Next(left, right + 1);
                case PivotMethod.MEDIANOFTHREE:
                    return MedianOfThree(arr, left, right);
                default:
                    return (left + right) / 2;
            }
        }

        private static int MedianOfThree(int[] arr, int left, int right)
        {
            int mid = (left + right) / 2;
            if (arr[right] < arr[left]) Swap(arr, left, right);
            if (arr[mid] < arr[left]) Swap(arr, left, mid);
            if (arr[right] < arr[mid]) Swap(arr, mid, right);
            return mid;
        }
    }

    public enum PivotMethod
    {
        FIRST,
        LAST,
        MIDDLE,
        RANDOM,
        MEDIANOFTHREE
    }
}
