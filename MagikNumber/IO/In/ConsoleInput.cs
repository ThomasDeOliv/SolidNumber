namespace ConsoleGames.IO.In
{
    internal class ConsoleInput : IInput
    {
        public string ReadKey()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            return key.KeyChar.ToString();
        }

        public string? ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
