namespace ConsoleGames.IO.Out
{
    internal interface IOutput
    {
        void WriteOutput(string message, bool refresh = false, params string[] args);
        void WriteLineOutput(string message, bool refresh = false, params string[] args);
    }
}
