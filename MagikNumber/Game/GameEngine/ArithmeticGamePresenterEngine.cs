using ConsoleGames.Comparator;

namespace ConsoleGames.Game.GameEngine
{
    internal enum Operation
    {
        ADDITION,
        SUBSTRACTION,
        MULTIPLICATION,
        DIVISION
    }

    internal enum ArithmeticGamePresenterEngineState
    {
        FIRST,
        SECOND,
        THIRD,
        FOURTH,
        LAST
    }

    internal class ArithmeticGamePresenterEngine
    {
        private readonly IComparator _comparator;
        private readonly Random _random;

        public bool InProgress { get => }
        public ArithmeticGamePresenterEngineState State { get; private set; }
        public int CurrentNumber1 { get; private set; }
        public int CurrentNumber2 { get; private set; }
        public Operation CurrentOperation { get; private set; }
        public byte Score { get; private set; }

        public ArithmeticGamePresenterEngine(IComparator comparator, Random random)
        {
            _comparator = comparator;
            _random = random;

            State = ArithmeticGamePresenterEngineState.FIRST;
            Score = 0;
            CurrentNumber1 = 0;
            CurrentNumber2 = 0;
            CurrentOperation = Operation.ADDITION;
        }
    }
}
