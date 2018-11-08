using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximunProductSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testNums = new int[] { 3, -1, 4 }; //4
            //testNums = new int[] { 1, -2, 3, -4, -3, -4, -3 }; //432
            //testNums = new int[] { 1, 2, -1, -2, 2, 1, -2, 1, 4, -5, 4 }; //1280
            testNums = new int[] { -1, -2, -2, -2, 3, 2, -2, 0 }; //96
            //testNums = new int[] { -1, 1, -3, -2, 2, -1, -2, 1, 2, -3 }; //144
            Console.WriteLine(MaximunProduct1(testNums));
            Console.ReadLine();
        }
        static int MaximunProduct2(int[] nums)
        {
            List<int> numsAnswer = Recursion(nums.ToList());
            return numsAnswer.Max();
        }
        static int MaximumProduct3(int[] nums)
        {
            int firstSum = 1;
            int secondSum = 1;
            int temp = 0;
            bool minus = false;
            for(int i=0; i<nums.Length; ++i)
            {
                if (nums[i] > 0)
                {
                    firstSum *= nums[i];
                }
                if (nums[i] < 0)
                {
                    temp = nums[i];
                    i++;
                    minus = true;
                }
                if (minus)
                {
                    secondSum *= nums[i];
                }
            }
        }
        static int MaximunProduct1(int[] nums)
        {
            List<int> numsAnswer = nums.ToList();
            int index = 0;
            int twoSum = 0;
            int threeSum = 0;
            bool isEdit = true;
            int max = 0;
            while (isEdit)
            {
                isEdit = false;
                index = 0;
                List<int> newNums = new List<int>();
                while (index < numsAnswer.Count())
                {
                    twoSum = 0;
                    threeSum = 0;
                    if (index + 1 < numsAnswer.Count())
                        twoSum = numsAnswer[index] * numsAnswer[index + 1];
                    if (index + 2 < numsAnswer.Count())
                        threeSum = numsAnswer[index] * numsAnswer[index + 1] * numsAnswer[index + 2];
                    if (twoSum > 0)
                    {
                        newNums.Add(twoSum);
                        isEdit = true;
                        index++;
                        if (twoSum > max)
                            max = twoSum;
                    }
                    else if (threeSum > 0)
                    {
                        newNums.Add(threeSum);
                        isEdit = true;
                        index += 2;
                        if (threeSum > max)
                            max = threeSum;
                    }
                    else
                    {
                        newNums.Add(numsAnswer[index]);
                    }
                    index++;
                }
                numsAnswer = newNums;
            }
            return max;
        }
        static List<int> Recursion(List<int> nums)
        {
            List<int> newNums = new List<int>();
            int index = 0;
            int twoSum = 0;
            int threeSum = 0;
            bool isEdit = false;
            while(index < nums.Count())
            {
                twoSum = 0;
                threeSum = 0;
                if(index+1<nums.Count())
                    twoSum = nums[index] * nums[index + 1];
                if (index + 2 < nums.Count())
                    threeSum = nums[index] * nums[index + 1] * nums[index + 2];
                if (twoSum > 0)
                {
                    newNums.Add(twoSum);
                    isEdit = true;
                    index++;
                }
                else if (threeSum > 0)
                {
                    newNums.Add(threeSum);
                    isEdit = true;
                    index += 2;
                }
                else
                {
                    newNums.Add(nums[index]);
                }
                index++;
            }
            if (!isEdit) return newNums;
            return Recursion(newNums);
        }

        static int MaximunProduct(int[] nums)
        {
            int max = -2147483648;
            int left,right = 0;
            int current = 0;
            //int[] otherNums = new int[nums.Length];
            //nums.CopyTo(otherNums, 0);
            //Array.Sort(otherNums);
            //for(int i=0; i<nums.Length; ++i)
            //{
            //    if( otherNums[i] >= 0)
            //    {
            //        if(i%2 == 0)
            //        {
            //            max = 1;
            //            for(i=0;i<nums.Length; ++i)
            //            {
            //                max *= otherNums[i];
            //            }
            //            return max;
            //        }
            //    }
            //}
            for(int index=0; index < nums.Length; ++index)
            {
                if(nums[index] == 0 )
                {
                    if(nums[index] > max)
                        max = 0;
                }
                else
                {
                    //currentAnswer = RunTwoSides(nums, i, nums[i]);
                    left = 0;
                    right = 0;
                    current = nums[index];
                    if (nums[index] < 0)
                    {
                        if (index - left - 1 >= 0 && nums[index - left - 1] < 0)
                        {
                            left++;
                            current *= nums[index - left];
                        }
                        else if (index + right + 1 < nums.Length && nums[index + right + 1] < 0)
                        {
                            right++;
                            current *= nums[index + right];
                        }
                        else
                        {
                            if (current > max)
                                max = current;
                            continue;
                        }
                    }
                    while (true)
                    {
                        if (index - left - 1 >= 0 && nums[index - left - 1] > 0)
                        {
                            left++;
                            current *= nums[index - left];
                        }
                        else if (index + right + 1 < nums.Length && nums[index + right + 1] > 0)
                        {
                            right++;
                            current *= nums[index + right];
                        }
                        else if (index - left - 1 >= 0 &&
                                   nums[index - left - 1] < 0 &&
                                   index + right + 1 < nums.Length &&
                                   nums[index + right + 1] < 0
                            )
                        {
                            right++;
                            current *= nums[index + right];
                            left++;
                            current *= nums[index - left];
                        }
                        else if (index - left - 2 >= 0 &&
                            nums[index - left - 1] < 0 &&
                            nums[index - left - 2] < 0)
                        {
                            left++;
                            current *= nums[index - left];
                            left++;
                            current *= nums[index - left];
                        }else if (index + right + 2 < nums.Length &&
                            nums[index + right + 1] < 0 &&
                            nums[index + right + 2] < 0)
                        {
                            right++;
                            current *= nums[index + right];
                            right++;
                            current *= nums[index + right];
                        }
                        else { break; }
                    }
                    if (current > max)
                        max = current;
                    if (right > 0)
                        index += right-1;
                }
            }
            return max;
        }
        static int RunTwoSides(int[] nums, int index, int current)
        {
            int left =0, right = 0;
            if(nums[index] < 0)
            {
                if (index - left - 1 >= 0 && nums[index - left - 1] < 0)
                {
                    left++;
                    current *= nums[index - left];
                }
                else if (index + right + 1 < nums.Length && nums[index + right + 1] < 0)
                {
                    right++;
                    current *= nums[index + right];
                }
            }
            while(true)
            {
                if (index - left - 1 >= 0 && nums[index - left - 1] > 0)
                {
                    left++;
                    current *= nums[index - left];
                }
                else if (index + right + 1 < nums.Length && nums[index + right + 1] > 0)
                {
                    right++;
                    current *= nums[index + right];
                }
                else if(index - left - 1 >= 0 &&
                           nums[index - left - 1] < 0 &&
                           index + right + 1 < nums.Length &&
                           nums[index + right + 1] < 0
                    )
                {
                    right++;
                    current *= nums[index + right];
                    left++;
                    current *= nums[index - left];
                }
                else { break; }
            }
            return current;
        }

        //for(int index=0; index<nums.Length; ++index)
        //    {
        //        if(nums[index] == 0 )
        //        {
        //            if(nums[index] > max)
        //                max = 0;
        //        }
        //        else
        //        {
        //            //currentAnswer = RunTwoSides(nums, i, nums[i]);
        //            left = 0;
        //            right = 0;
        //            current = nums[index];
        //            if (nums[index] < 0)
        //            {
        //                if (index - left - 1 >= 0 && nums[index - left - 1] < 0)
        //                {
        //                    left++;
        //                    current *= nums[index - left];
        //                }
        //                else if (index + right + 1 < nums.Length && nums[index + right + 1] < 0)
        //                {
        //                    right++;
        //                    current *= nums[index + right];
        //                }
        //                else
        //                {
        //                    if (current > max)
        //                        max = current;
        //                    continue;
        //                }

        //                if(index -left -2>=0 &&
        //                    nums[index - left - 1] < 0 &&
        //                    nums[index - left - 2] < 0)
        //                {
        //                    left++;
        //                    current *= nums[index - left];
        //                    left++;
        //                    current *= nums[index - left];
        //                }

        //                if (index + right + 2 < nums.Length &&
        //                    nums[index + right + 1] < 0 &&
        //                    nums[index + right + 2] < 0)
        //                {
        //                    right++;
        //                    current *= nums[index + right];
        //                    right++;
        //                    current *= nums[index + right];
        //                }

        //                if (index - left - 1 >= 0 &&
        //                    index + right + 1 < nums.Length &&
        //                    nums[index - left - 1] < 0 &&
        //                    nums[index + right + 1] < 0 )
        //                {
        //                    left++;
        //                    current *= nums[index - left];
        //                    right++;
        //                    current *= nums[index + right];
        //                }
        //            }
        //            while (true)
        //            {
        //                if (index - left - 1 >= 0 && nums[index - left - 1] > 0)
        //                {
        //                    left++;
        //                    current *= nums[index - left];
        //                }
        //                else if (index + right + 1 < nums.Length && nums[index + right + 1] > 0)
        //                {
        //                    right++;
        //                    current *= nums[index + right];
        //                }
        //                else if (index - left - 1 >= 0 &&
        //                           nums[index - left - 1] < 0 &&
        //                           index + right + 1 < nums.Length &&
        //                           nums[index + right + 1] < 0
        //                    )
        //                {
        //                    right++;
        //                    current *= nums[index + right];
        //                    left++;
        //                    current *= nums[index - left];
        //                }
        //                else { break; }
        //            }
        //            if (current > max)
        //                max = current;
        //            if (right > 0)
        //                index += right-1;
        //        }
        //    }
    }
}
