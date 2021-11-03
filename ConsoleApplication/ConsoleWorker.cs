using System;

namespace ConsoleApplication
{
    public class ConsoleWorker
    {
        private readonly StringCalculator.StringCalculator calculator;
        private readonly ConsoleWrapper wrapper;

        public ConsoleWorker(ConsoleWrapper _wrapper, StringCalculator.StringCalculator _calculator)
        {
            calculator = _calculator;
            wrapper = _wrapper;
        }

        public void Run()
        {
            wrapper.ShowMessage("Enter comma separated numbers (enter to exit):");

            while (true)
            {
                var inputString = wrapper.ReadLine();

                inputString = (inputString.Contains("\\n") ? inputString.Replace("\\n", "\n") : inputString);

                if (inputString.Length == 0)
                {
                    break;
                }
                else
                {
                    try
                    {
                        var result = calculator.Add(inputString);
                        wrapper.ShowMessage("Result: " + result + "\n");
                    }
                    catch(ArgumentException exception)
                    {
                        wrapper.ShowMessage(exception.Message);
                    }
                }

                wrapper.ShowMessage("you can enter other numbers (enter to exit)?");
            }
        }
    }
}
