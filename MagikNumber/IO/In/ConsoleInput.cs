namespace MagikNumber.IO.In
{
    internal class ConsoleInput : IInput
    {
        public string? ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
