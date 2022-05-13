using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures.ArrayAlgos
{
    public class ArrayProblems
    {
        public static int[] MergerTwoIntegerArrays(int[] arr1, int[] arr2)
        {
            var totalLength = arr1.Length + arr2.Length;
            int[] mergedArr = new int[totalLength];
            var arr1Index = 0;
            var arr2Index = 0;
            var index = 0;

            bool arr1Over = false;
            bool arr2Over = false;

            while(index < totalLength )
            {
                if(arr1[arr1Index] < arr2[arr2Index])
                {
                    mergedArr[index] = arr1[arr1Index];
                    arr1Index++;
                    index++;
                }
                else
                {
                    
                    mergedArr[index] = arr2[arr2Index];
                    arr2Index++;
                    index++;
                }

                if(arr1Index == arr1.Length)
                {
                    arr1Over = true;
                    break;
                }


                if (arr2Index == arr2.Length)
                {
                    arr2Over = true;
                    break;
                }
            }

            if(arr1Over && !arr2Over)
            {
                for(int i=arr2Index; i<arr2.Length; i++)
                {
                    mergedArr[index] = arr2[i];
                    index++;
                }
            }
            else if(arr2Over && !arr1Over)
            {
                for (int i = arr1Index; i < arr1.Length; i++)
                {
                    mergedArr[index] = arr1[i];
                    index++;
                }
            }

            return mergedArr;
        }

        public static string SubArrayWithHighestSum(int[] arr)
        {
            var length = arr.Length;
            var subArray = new int[length];

            var dic = new Dictionary<int, string>();
            for(int i=0; i<length; i++)
            {
                var temp = arr[i];
                var subSet = arr[i].ToString();
                for (int j=i+1; j<length; j++)
                {
                    subSet += "," + arr[j].ToString();
                    temp += arr[j];
                    if(!dic.ContainsKey(temp))
                        dic.Add(temp, subSet);
                }
            }

            var max = dic.Keys.First();
            foreach(var key in dic.Keys)
            {
                if (key > max)
                    max = key;
            }

            return dic[max];
        }

        public static string maxSubArraySum(int[] a)
        {
            int max_so_far = 0, max_ending_here = 0;
            string subArray = "";
            for (int i = 0; i < a.Length; i++)
            {
                max_ending_here = max_ending_here + a[i];
                subArray += a[i].ToString() + ","; 
                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                //if (max_ending_here < 0)
                //{
                //    max_ending_here = 0;
                //    subArray = "";
                //}
            }
            return subArray;
        }

        public static int[] MoveZerosToEnd(int[] arr)
        {
            if (arr.Length < 2)
                return arr;

            int zeroCounter = 0;
            int i = 0;
            while (i < arr.Length)
            {
                if (arr[i] == 0)
                {
                    zeroCounter++;
                }

                else if (zeroCounter > 0)
                {

                    arr[i - zeroCounter] = arr[i];
                    arr[i] = 0;
                }
                i++;
            }

            return arr;
        }

        public static int RemoveElement(int[] nums, int val)
        {
            int vi = 0, i = 0;

            while (i < nums.Length)
            {
                if (nums[i] == val)
                {
                    vi++;
                }
                else if (vi > 0)
                {
                    nums[i - vi] = nums[i];
                    nums[i] = -1;
                   
                }

                i++;
            }

            for(int j = nums.Length-vi; j < nums.Length; j++)
            {
                nums[j] = -1;
            }

            return vi+1;
        }

        
        public static int ThreeSum(int[] arr, int target)
        {
            int closest = 0;
            if (arr.Length >= 3)
            {
                closest = arr[0] + arr[1] + arr[2];
          
                int index = 1;
                while (index < arr.Length - 2)
                {
                    var sum = arr[index] + arr[index + 1] + arr[index + 2];
                    var diff2 = sum >= target ? sum - target : target - sum;
                    var diff1 = closest >= target ? closest - target : target - closest;

                    if (diff2 < diff1)
                    {
                        closest = sum;
                    }

                    index++;
                }
            }

            return closest;
        }

        public static bool ContainDuplicate(int[] arr, int target)
        {
            var hashset = new HashSet<int>();
            
            for(int i=0; i<arr.Length; i++)
            {
                if (!hashset.Contains(arr[i]))
                    hashset.Add(arr[i]);
                else
                    return true;

            }



            return false;
        }

        public static int M(int[] arr)
        {
            if (arr.Length == 0 || (arr.Length == 1 && arr[0] != 1))
                return -1;
            else if (arr.Length == 1 && arr[0] == 1)
                return 1;
            else
            {
                var dic = new Dictionary<int, int>();
                for(int i=0; i<arr.Length; i++)
                {
                    if (dic.ContainsKey(arr[i]))
                        dic[arr[i]] = dic[arr[i]] + 1;
                    else
                        dic.Add(arr[i], 1);
                }

                var res = dic.Where(d => d.Key == d.Value);
                if(res != null)
                {
                    var res2 = res.Max();
                    return res2.Key;
                }
            }

            return -1;

        }

        public static int FirstDuplicate(int[] arr)
        {
            var hashSet = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!hashSet.Contains(arr[i]))
                    hashSet.Add(arr[i]);
                else
                {
                    return arr[i];
                }
            }

        


            return -1;
        }


        public static string dd(int[] arr)
        {
            var hashSet = new HashSet<int>();
            var dupplicate = 0;
            var missing = 0;
            for(int i=0; i< arr.Length; i++)
            {
                if (!hashSet.Contains(arr[i]))
                    hashSet.Add(arr[i]);
                else
                    dupplicate = arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
                if (arr[i] != i + 1)
                    missing = i + 1;


            return dupplicate.ToString() + missing.ToString();
        }

        public static int[] RotateArray(int[] arr, int k)
        {

            var len = arr.Length;
            for (int i = 1; i <= k; i++)
            {
                var kValue = arr[len - 1];
    

                for (int j = len-1; j >= 1; j--)
                {
                    arr[j] = arr[j-1];

                }

                arr[0] = kValue;
            }

            return arr;
        }

        public static int[] RotateArray2(int[] arr, int k)
        {
            var len = arr.Length;
            Queue<int> elements = new Queue<int>();
            for(int i=0; i<=len-k; i++)
            {
                if(i <= k ) elements.Enqueue(arr[len - i - 1]);
                arr[len - i - 1] = arr[len - k - i];
            }

            for(int i=k-1; i>=0; i--)
            {
                arr[i] = elements.Dequeue();
            }

            return arr;
        }

        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {

            if (nums1.Length < 1)
            {
                return CalculateMedian(nums2);
            }
            else if (nums2.Length < 1)
            {
                return CalculateMedian(nums1);
            }
            else if (nums1.Length < 1 && nums2.Length < 1)
                return 0;
            else
            {
                var totalLength = nums1.Length + nums2.Length;
                var newNums = new int[totalLength];
                int num1Index = 0;
                int num2Index = 0;
                int index = 0;

                bool arr1over = false;
                bool arr2over = false;


                while (index < totalLength)
                {
                    if (nums1[num1Index] < nums2[num2Index])
                    {
                        newNums[index] = nums1[num1Index];
                        num1Index++;
                        index++;
                    }
                    else if (nums2[num2Index] < nums1[num1Index])
                    {
                        newNums[index] = nums2[num2Index];
                        num1Index++;
                        index++;
                    }
                    else
                    {
                        newNums[index] = nums2[num2Index];
                        newNums[index + 1] = nums1[num1Index];
                        num2Index++;
                        num2Index++;
                        index += 2;
                    }

                    if (num2Index == nums2.Length)
                    {
                        arr2over = true;
                        break;
                    }

                    if (num1Index == nums1.Length)
                        {
                            arr1over = true;
                            break;
                        }
                }

                if (arr1over)
                {
                    for (int i = num2Index; i < nums2.Length; i++)
                    {
                        newNums[index] = nums2[i];
                        index++;
                    }
                }
                else if(arr2over)
                {
                    for (int i = num1Index; i < nums1.Length; i++)
                    {
                        newNums[index] = nums1[i];
                        index++;
                    }
                }

                Console.Write(newNums[0].ToString() + newNums[1].ToString() + newNums[2].ToString() + newNums[3].ToString());
                return CalculateMedian(newNums);
            }

        }

        private static double CalculateMedian(int[] nums)
        {
            if (nums.Length % 2 == 0)
            {
                int index = nums.Length / 2;
                return (nums[index - 1] + nums[index]) / 2.0;
            }
            else
            {
                int index = nums.Length / 2;
                return nums[index];
            }

        }
    }
} 
