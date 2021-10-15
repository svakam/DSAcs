using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAcs.Search
{
    public static class BinarySearch
    {
        // returns position where input element is located, else return null
        public static int? Run(int[] list, int number)
        {
            if (list.Length == 1 && list[0] == number) return 0;

            int low = 0;
            int high = list.Length - 1;
            int mid;

            while (low <= high) // check between low and high, including when narrowed down to 1 element (low == high)
            {
                mid = (low + high) / 2;

                int guess = list[mid];
                if (guess < number)
                {
                    low = mid + 1; // eliminate all list INCLUDING and below the guess
                }
                else if (guess > number)
                {
                    high = mid - 1; // eliminate all list INCLUDING and above the guess
                }
                else
                {
                    return mid;
                }
            }
            return null;
        }

        public static int? RunRecursion(int[] list, int number, int low, int high)
        {
            if (low > high) return null;

            int mid = (low + high) / 2;
            int guess = list[mid];

            if (guess < number)
            {
                return RunRecursion(list, number, mid + 1, high);
            }
            else if (guess > number)
            {
                return RunRecursion(list, number, low, mid - 1);
            }
            else
            {
                return mid;
            }
        }
    }
}
