namespace ConsoleGames.Comparator
{
    internal enum ComparisonResult
    {
        ARE_EQUAL,
        TOO_HIGH,
        TOO_LOW,
    }

    internal interface IComparator
    {
        ComparisonResult Compare(int magikNumber, int guess);
    }
}
