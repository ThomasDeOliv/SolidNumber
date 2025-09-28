using ConsoleGames.Game.GameEngine;
using ConsoleGames.IO.In;
using ConsoleGames.IO.Out;

namespace ConsoleGames.Game
{
    internal class MagikNumberGamePresenter : IGamePresenter
    {
        private readonly MagikNumberGameEngine _gameEngine;
        private readonly IInput _input;
        private readonly IOutput _output;

        public MagikNumberGamePresenter(MagikNumberGameEngine gameEngine, IInput input, IOutput output)
        {
            _gameEngine = gameEngine;
            _input = input;
            _output = output;
        }

        public void Play()
        {
            _output.WriteLineOutput("*****************************");
            _output.WriteLineOutput("Welcome to Magik Number Game!");
            _output.WriteLineOutput("*****************************");

            while (_gameEngine.InProgress)
            {
                _output.WriteOutput("Make a guess : ");
                string? output = _input.ReadInput();

                if (!int.TryParse(output, out int guess))
                {
                    _output.WriteLineOutput("Invalid input. Please enter a valid number.", true);
                    continue;
                }

                switch (_gameEngine.MakeGuess(guess))
                {
                    case MagikNumberGameEngineResult.ARE_EQUAL:
                        _output.WriteLineOutput("Congratulations! You've guessed the Magik Number!", true);
                        break;
                    case MagikNumberGameEngineResult.TOO_LOW:
                        _output.WriteLineOutput("Your guess is too low.", true);
                        break;
                    case MagikNumberGameEngineResult.TOO_HIGH:
                        _output.WriteLineOutput("Your guess is too high.", true);
                        break;
                }

                if (!_gameEngine.IsWin)
                {
                    _output.WriteLineOutput(_gameEngine.LeftAttempts != 0 ? $"You have {_gameEngine.LeftAttempts} attempts left." : "You have no attempts left.");
                }
            }

            if (!_gameEngine.IsWin)
            {
                _output.WriteLineOutput("*****************************", true);
                _output.WriteLineOutput($"Game Over! The Magik Number was {_gameEngine.MagicNumber}.");
                _output.WriteLineOutput("*****************************");
            }
        }
    }
}
