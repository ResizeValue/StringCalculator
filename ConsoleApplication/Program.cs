namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleWorker worker = new ConsoleWorker(new ConsoleWrapper(), new StringCalculator.StringCalculator());

            worker.Run();
        }
    }
}
