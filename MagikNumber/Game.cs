namespace MagikNumber
{
    internal class Game
    {
        private readonly INumberGenerator _generator;
        private readonly INumberComparator _comparator;
        private readonly IOutput _output;
        private readonly IInput _input;

        private int _magicNumber;
        private bool _isWin;
        private int _leftAttempts;

        public Game(INumberGenerator generator, INumberComparator comparator, IOutput output, IInput input, int maxAttempts = 10)
        {
            _generator = generator;
            _comparator = comparator;
            _output = output;
            _input = input;

            _isWin = false;
            _leftAttempts = maxAttempts;
        }

        public void Play()
        {
            _magicNumber = _generator.GetRandom();

            _output.DisplayLine("*****************************");
            _output.DisplayLine("Welcome to Magik Number Game!");
            _output.DisplayLine("*****************************");

            while (!_isWin && _leftAttempts > 0)
            {
                _output.Display("Make a guess : ");
                string? output = _input.ReadInput();

                if (!int.TryParse(output, out int guess))
                {
                    _output.DisplayLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                int comparisonResult = _comparator.Compare(_magicNumber, guess);

                _output.Refresh();

                switch (comparisonResult)
                {
                    case -1:
                        _output.DisplayLine("Your guess is too low.");
                        break;
                    case 1:
                        _output.DisplayLine("Your guess is too high.");
                        break;
                    case 0:
                        _isWin = true;
                        _output.DisplayLine("Congratulations! You've guessed the Magik Number!");
                        break;
                }

                if (!_isWin)
                {
                    _leftAttempts--;
                    _output.DisplayLine(_leftAttempts != 0 ? $"You have {_leftAttempts} attempts left." : "You have no attempts left.");
                }
            }

            if (!_isWin)
            {
                _output.DisplayLine("*****************************");
                _output.DisplayLine($"Game Over! The Magik Number was {_magicNumber}.");
                _output.DisplayLine("*****************************");
            }
        }
    }
}
