using ConsoleGames.Comparator;

namespace ConsoleGames.Game.GameEngine
{
    internal enum MagikNumberGameEngineResult
    {
        ARE_EQUAL,
        TOO_HIGH,
        TOO_LOW,
    }

    internal class MagikNumberGameEngine
    {
        private readonly IComparator _comparator;

        public int MagicNumber { get; }
        public bool IsWin { get; private set; }
        public int LeftAttempts { get; private set; }
        public bool InProgress { get => !IsWin && LeftAttempts > 0; }

        public MagikNumberGameEngine(IComparator comparator, int magikNumber, int maxAttempts = 10)
        {
            _comparator = comparator;

            MagicNumber = magikNumber;
            IsWin = false;
            LeftAttempts = maxAttempts;
        }

        public MagikNumberGameEngineResult MakeGuess(int guess)
        {
            ComparisonResult comparison = _comparator.Compare(MagicNumber, guess);

            if (comparison == ComparisonResult.ARE_EQUAL)
            {
                IsWin = true;
                return MagikNumberGameEngineResult.ARE_EQUAL;
            }

            LeftAttempts--;
            return comparison == ComparisonResult.TOO_HIGH
                ? MagikNumberGameEngineResult.TOO_HIGH
                : MagikNumberGameEngineResult.TOO_LOW;
        }
    }
}

