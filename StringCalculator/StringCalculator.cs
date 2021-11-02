using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string inputString)
        {
            if (inputString == "") 
            { 
                return 0; 
            }

            List<int> numbers = GetArrayOfNumbers(inputString);

            CheckForNegatives(numbers);

            return GetSum(numbers);
        }

        private int GetSum(List<int> nums)
        {
            var sum = 0;

            nums = nums.Where(x => x <= 1000).ToList();

            nums.ForEach(x => sum += x);

            return sum;
        }

        private List<int> GetArrayOfNumbers(string inputString)
        {
            List<int> intList = new List<int>();
            List<string> stringNumbers;

            if (inputString.StartsWith("//"))
            {
                var stringWithoutSlashes = inputString.Remove(0, 2);
                stringNumbers = SplitStringWithCustomDelimiters(stringWithoutSlashes);
            }
            else
            {
                stringNumbers = inputString.Split(new char[] { ',', '\n' }).ToList();
            }

            stringNumbers.ForEach(x => intList.Add(int.Parse(x)));

            return intList;
        }

        private List<string> SplitStringWithCustomDelimiters(string intputString)
        {
            var delimString = string.Empty;
            string numbersString = string.Empty;

            for (int i = 0; i < intputString.Length; i++)
            {
                if(intputString[i] == '\n' && char.IsDigit(intputString[i + 1]))
                {
                    var numberStringLenght = intputString.Length - i - 1;
                    var numberStringStartIndex = i + 1;

                    delimString = intputString.Substring(0, i);
                    numbersString = intputString.Substring(numberStringStartIndex, numberStringLenght);
                    break;
                }
            }

            if(delimString.Length == 1)
            {
                return numbersString.Split(delimString, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            else
            {
                var delims = SplitDelimiters(delimString);

                return numbersString.Split(delims, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        private string[] SplitDelimiters(string delimString)
        {
            var indexOfFirstDelim = 1;
            var indexOfLastDelim = delimString.Length - 2;

            delimString = delimString.Substring(indexOfFirstDelim, indexOfLastDelim);

            if (delimString.Contains("]["))
            {
                return delimString.Split("][", StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                return new string[] { delimString };
            }
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
