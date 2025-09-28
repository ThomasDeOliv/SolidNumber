using ConsoleGames.Game.GameEngine;
using ConsoleGames.IO.In;
using ConsoleGames.IO.Out;

namespace ConsoleGames.Game
{
    internal class MagikNumberGamePresenter : IGamePresenter
    {
        public const string Name = "The magic number game";

        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly MagikNumberGameEngine _engine;

        public MagikNumberGamePresenter(IInput input, IOutput output, MagikNumberGameEngine engine)
        {
            _input = input;
            _output = output;
            _engine = engine;
        }

        public void Play()
        {
            _output.WriteLineOutput("*****************************");
            _output.WriteLineOutput("Welcome to the magic number game!");
            _output.WriteLineOutput("*****************************");

            while (_engine.InProgress)
            {
                _output.WriteOutput("Make a guess : ");
                string? output = _input.ReadInput();

                if (!int.TryParse(output, out int guess))
                {
                    _output.WriteLineOutput("Invalid input. Please enter a valid number.", true);
                    continue;
                }

                switch (_engine.MakeGuess(guess))
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

                if (!_engine.IsWin)
                {
                    _output.WriteLineOutput(_engine.LeftAttempts != 0 ? $"You have {_engine.LeftAttempts} attempts left." : "You have no attempts left.");
                }
            }

            if (!_engine.IsWin)
            {
                _output.WriteLineOutput("*****************************", true);
                _output.WriteLineOutput($"Game Over! The Magik Number was {_engine.MagicNumber}.");
                _output.WriteLineOutput("*****************************");
            }
        }
    }
}
