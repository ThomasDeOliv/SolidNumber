namespace MagikNumber.Comparator
{
    internal class NumberComparator : IComparator
    {
        public ComparisonResult Compare(int magikNumber, int guess)
        {
            int delta = magikNumber - guess;

            return delta == 0
                ? ComparisonResult.ARE_EQUAL
                : (delta > 0
                    ? ComparisonResult.TOO_LOW
                    : ComparisonResult.TOO_HIGH);
        }
    }
}
