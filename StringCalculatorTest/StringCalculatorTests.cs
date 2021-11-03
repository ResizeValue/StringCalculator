using NUnit.Framework;
using System;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        private readonly StringCalculator.StringCalculator calc = new StringCalculator.StringCalculator();

        [SetUp]
        public void Setup()
        {

        }

        [Test, Timeout(1000)]
        public void Add_EmptyString_Zero()
        {
            int res = calc.Add("");

            Assert.AreEqual(res, 0);
        }

        [Test, Timeout(1000)]
        public void Add_SingleNumber_ShouldReturnNumber()
        {
            int res = calc.Add("1");

            Assert.AreEqual(res, 1);
        }

        [Test, Timeout(1000)]
        public void Add_MultipleNumbers_ShouldReturnSum()
        {
            int res = calc.Add("1,2,3,4");

            Assert.AreEqual(res, 10);
        }

        [Test, Timeout(1000)]
        public void Add_NumbersWithDifferenceDelim_ShouldReturnSum()
        {
            int res = calc.Add("1\n2,3");

            Assert.AreEqual(res, 6);
        }

        [Test, Timeout(1000)]
        public void Add_NumbersWithCustomDelim_ShouldReturnSum()
        {
            int res = calc.Add("//;\n1;2");

            Assert.AreEqual(res, 3);
        }

        [Test, Timeout(1000)]
        public void Add_HasNegativeNumbers_ShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentException>(() => { calc.Add("//;\n1;-2;-7"); });

            Assert.AreEqual(exception.Message, "Negatives are not allowed: -2 -7");
        }

        [Test, Timeout(1000)]
        public void Add_ShouldIgnoreBiggerThenThousandNumber()
        {
            int res = calc.Add("//;\n1;2;3000");

            Assert.AreEqual(res, 3);
        }

        [Test, Timeout(1000)]
        public void Add_NumbersWithMultipleDifferenceDelims_ShouldReturnSum()
        {
            int res = calc.Add("//[;;][%%%][*]\n1;;2%%%3*4");

            Assert.AreEqual(res, 10);
        }
    }
}