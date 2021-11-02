using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string num)
        {
            if (num == "") 
            { 
                return 0; 
            }

            List<int> nums = GetArrayOfNumbers(num);

            return GetSum(nums);
        }

        private int GetSum(List<int> nums)
        {
            CheckForNegatives(nums);

            var sum = 0;

            nums = nums.Where(x => x <= 1000).ToList();

            nums.ForEach(x => sum += x);

            return sum;
        }

        private List<int> GetArrayOfNumbers(string num)
        {
            List<int> intList = new List<int>();
            List<string> stringNumbers;
            if (num.StartsWith("//"))
            {
                stringNumbers = SplitStringWithCustomDelimeters(num).ToList();
            }
            else
            {
                stringNumbers = num.Split(new char[] { ',', '\n' }).ToList();
            }
            stringNumbers.ForEach(x => intList.Add(int.Parse(x)));
            return intList;
        }

        private string[] SplitStringWithCustomDelimeters(string num)
        {
            
            string[] tmp = num.Split('\n');

            var delimString = tmp[0];
            string numbersString = tmp[1];

            var delims = SplitDelimeters(delimString);

            return numbersString.Split(delims, StringSplitOptions.RemoveEmptyEntries);
        }

        private string[] SplitDelimeters(string delimString)
        {
            List<string> delims = new List<string>();

            if(delimString.Length == 3)
            {
                delims.Add(delimString[2].ToString());
                return delims.ToArray();
            }

            string tempChar = string.Empty;
            for (int i = 2; i < delimString.Length; i++)
            {
                if (i + 1 == delimString.Length)
                {
                    break;
                }

                if ((delimString[i] != '[' || delimString[i - 1] == '[') && (delimString[i] != ']' || delimString[i + 1] == ']'))
                {
                    tempChar += delimString[i];
                    continue;
                }

                if (delimString[i] == ']')
                {
                    delims.Add(tempChar);
                    tempChar = "";
                }
            }
            if (tempChar != "")
            {
                delims.Add(tempChar);
            }
            return delims.ToArray();
        }

        private void CheckForNegatives(List<int> nums)
        {
            var negatives = nums.Where(x => x < 0).ToList();

            if (negatives.Count > 0)
            {
                throw new ArgumentException("Negatives are not allowed: " + GetNegativesString(negatives));
            }
        }

        private string GetNegativesString(List<int> negatives)
        {
            string negativesString = string.Empty;

            negatives.ForEach(x => negativesString += x.ToString() + " ");

            return negativesString;
        }
    }
}
