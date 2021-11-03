using System;

namespace ConsoleApplication
{
    public class ConsoleWrapper
    {
        public virtual void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        public virtual string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
