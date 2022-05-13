using System;
namespace DataStructures.SearchAlgos
{
    public class BinarySearch
    {
        public static bool binarySearch(int[] arr, int valueToSearch)
        {
            int start = 0;
            int end = arr.Length - 1;
            int pvoit = end / 2;

            while (end >= start)
            {
                if (arr[pvoit] == valueToSearch) return true;

                if (arr[pvoit] < valueToSearch)
                {
                    start = pvoit + 1;
                }
                else
                {
                    end = pvoit - 1;
                }

                pvoit = start + (end - start - 1) / 2;
            }

            return false;
        }
    }
}
