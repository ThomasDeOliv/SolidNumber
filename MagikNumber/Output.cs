namespace MagikNumber
{
    internal class Output : IOutput
    {
        public Output()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }

        public void Display(string message, params string[] args)
        {
            Console.Write(string.Format(message, args));
        }

        public void DisplayLine(string message, params string[] args)
        {
            Console.WriteLine(string.Format(message, args));
        }

        public void Refresh()
        {
            Console.Clear();
        }
    }
}
