using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        public virtual int Add(string inputString)
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
            return nums.Where(x => x <= 1000).Sum();
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

        private List<string> SplitStringWithCustomDelimiters(string inputString)
        {
            var delimitersString = string.Empty;
            var numbersString = string.Empty;

            for (int i = 0; i < inputString.Length; i++)
            {
                if(inputString[i] == '\n' && char.IsDigit(inputString[i + 1]))
                {
                    var numberStringLenght = inputString.Length - i - 1;
                    var numberStringStartIndex = i + 1;

                    delimitersString = inputString.Substring(0, i);
                    numbersString = inputString.Substring(numberStringStartIndex, numberStringLenght);
                    break;
                }
            }

            if(delimitersString.Length == 1)
            {
                return numbersString.Split(delimitersString, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            else
            {
                var delims = SplitDelimiters(delimitersString);

                return numbersString.Split(delims, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }

        private string[] SplitDelimiters(string delimitersString)
        {
            var indexOfFirstDelimiter = 1;
            var indexOfLastDelimiter = delimitersString.Length - 2;

            delimitersString = delimitersString.Substring(indexOfFirstDelimiter, indexOfLastDelimiter);

            if (delimitersString.Contains("]["))
            {
                return delimitersString.Split("][", StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                return new string[] { delimitersString };
            }
        }

        private void CheckForNegatives(List<int> numbers)
        {
            var negatives = numbers.Where(x => x < 0);

            if (negatives.Count() > 0)
            {
                throw new ArgumentException("Negatives are not allowed: " + string.Join(" ", negatives));
            }
        }

    }
}
