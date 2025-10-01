using ConsoleGames.Game.GameEngine;
using ConsoleGames.IO.In;
using ConsoleGames.IO.Out;

namespace ConsoleGames.Game.GamePresenter
{
    internal class ArithmeticGamePresenter : IGamePresenter
    {
        public const string NAME = "The arithmetic game";

        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly ArithmeticPresenterGameEngine _engine;

        public ArithmeticGamePresenter(IInput input, IOutput output, ArithmeticPresenterGameEngine engine)
        {
            _input = input;
            _output = output;
            _engine = engine;
        }

        public void Play()
        {
            _output.WriteLineOutput("*****************************");
            _output.WriteLineOutput("Welcome to the arithmetic game!");
            _output.WriteLineOutput("*****************************");

            while (_engine.InProgress)
            {
                _engine.Next();
            }
        }
    }
}
