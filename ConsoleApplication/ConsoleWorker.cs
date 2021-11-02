using StringCalculatorSpace;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication
{
    class ConsoleWorker
    {
        private readonly StringCalculator calculator;
        private readonly ConsoleWrapper wrapper;

        public ConsoleWorker(ConsoleWrapper _wrapper)
        {
            calculator = new StringCalculator();
            wrapper = _wrapper;
        }

        public void Run()
        {
            while (true)
            {
                wrapper.ShowMessage("Enter comma separated numbers (enter to exit):");

                var str = Console.ReadLine();

                str = (str.Contains("\\n") ? str.Replace("\\n", "\n") : str);

                if (str.Length == 0)
                {
                    break;
                }
                else
                {
                    wrapper.ShowMessage("Result: " + calculator.Add(str) + "\n");
                }
            }
        }
    }
}
