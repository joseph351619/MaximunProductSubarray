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
            int[] testNums = new int[] { -2, -3};
            Console.WriteLine(MaximunProduct(testNums));
            Console.ReadLine();
        }

        static int MaximunProduct(int[] nums)
        {
            int max = -2147483648;
            int left,right = 0;
            int currentAnswer = 0;
            for(int i=0; i<nums.Length; ++i)
            {
                if(nums[i] == 0 )
                {
                    if(nums[i] > max)
                        max = 0;
                }
                //else if(nums[i] <0)
                //{
                //    if (nums[i] > max)
                //        max = nums[i];
                //}
                else
                {
                    currentAnswer = RunTwoSides(nums, i, nums[i]);
                    if (currentAnswer > max)
                        max = currentAnswer;
                }
            }
            return max;
        }
        static int RunTwoSides(int[] nums, int index, int current)
        {
            int left =0, right = 0;
            while(true)
            {
                if (index - left-1 >= 0 && nums[index-left-1] >0)
                {
                    left++;
                    current *= nums[index - left];
                }
                else if(index +right+1 <nums.Length && nums[index+right+1] >0)
                {
                    right++;
                    current *= nums[index + right];
                }else if(index + right + 1 < nums.Length && 
                          nums[index + right + 1] < 0 &&
                          index - left - 1 >= 0 && 
                          nums[index - left - 1] < 0)
                {
                    left++;
                    current *= nums[index - left];
                    right++;
                    current *= nums[index + right];
                }
                else { break; }
            }
            return current;
        }
    }
}
