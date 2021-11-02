using System;
using System.Collections.Generic;
using System.Text;

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
