using System;

namespace ConsoleApplication
{
    class ConsoleWrapper
    {
        public virtual void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
