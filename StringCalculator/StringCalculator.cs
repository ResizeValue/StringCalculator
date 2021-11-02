using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculatorSpace
{
    public class StringCalculator
    {
        public int Add(string num)
        {
            if (num == "") 
            { 
                return 0; 
            }

            string[] nums = GetArrayOfNumbers(num);

            return GetSum(nums);
        }

        private int GetSum(string[] nums)
        {
            var sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int tmpNum = int.Parse(nums[i]);

                if (tmpNum < 0)
                {
                    throw new ArgumentException("Negatives are not allowed: " + FindAllNegatives(nums, i));
                }
                else if (tmpNum > 1000)
                {
                    continue;
                }
                else
                {
                    sum += tmpNum;
                }
            }
            return sum;
        }

        private string[] GetArrayOfNumbers(string num)
        {
            if (num.StartsWith("//"))
            {
                return SplitStringWithCustomDelimeters(num);
            }
            else
            {
                return num.Split(new char[] { ',', '\n' });
            }
        }

        private string[] SplitStringWithCustomDelimeters(string num)
        {
            string[] tmp = num.Split('\n');
            var delims = tmp[0].Remove(0, 2).Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
            string numbers = tmp[1];

            return numbers.Split(delims, StringSplitOptions.RemoveEmptyEntries);
        }

        private string FindAllNegatives(string[] numbers, int index)
        {
            string negatives = "";

            for (int i = index; i < numbers.Length; i++)
            {
                int tmpNum = int.Parse(numbers[i]);

                if (tmpNum < 0)
                {
                    negatives += tmpNum + " ";
                }
            }

            return negatives;
        }
    }
}
