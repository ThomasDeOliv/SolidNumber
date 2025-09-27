namespace MagikNumber
{
    internal class NumberComparator : INumberComparator
    {
        public int Compare(int magikNumber, int guess)
        {
            return guess == magikNumber
                ? 0
                : (
                guess < magikNumber
                    ? -1
                    : 1
                );
        }
    }
}
