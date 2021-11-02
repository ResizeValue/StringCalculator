using StringCalculator;
using System;

namespace ConsoleApplication
{
    class ConsoleWorker
    {
        private readonly StringCalculator.StringCalculator calculator;
        private readonly ConsoleWrapper wrapper;

        public ConsoleWorker(ConsoleWrapper _wrapper)
        {
            calculator = new StringCalculator.StringCalculator();
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
                    try
                    {
                        wrapper.ShowMessage("Result: " + calculator.Add(str) + "\n");
                    }
                    catch(ArgumentException exception)
                    {
                        wrapper.ShowMessage(exception.Message);
                    }
                }
            }
        }
    }
}
