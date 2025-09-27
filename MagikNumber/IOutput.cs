namespace MagikNumber
{
    internal interface IOutput
    {
        void Display(string message, params string[] args);
        void DisplayLine(string message, params string[] args);
        void Refresh();
    }
}
