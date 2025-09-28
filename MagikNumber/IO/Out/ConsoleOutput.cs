namespace ConsoleGames.IO.Out
{
    internal class ConsoleOutput : IOutput
    {
        public ConsoleOutput()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public void WriteOutput(string message, bool refresh = false, params string[] args)
        {
            if (refresh)
            {
                Console.Clear();
            }

            Console.Write(string.Format(message, args));
        }

        public void WriteLineOutput(string message, bool refresh = false, params string[] args)
        {
            if (refresh)
            {
                Console.Clear();
            }

            Console.WriteLine(string.Format(message, args));
        }
    }
}
