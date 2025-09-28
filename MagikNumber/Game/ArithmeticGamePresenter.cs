using ConsoleGames.Game.GameEngine;
using ConsoleGames.IO.In;
using ConsoleGames.IO.Out;

namespace ConsoleGames.Game
{
    internal class ArithmeticGamePresenter : IGamePresenter
    {
        public const string Name = "The arithmetic game";

        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly ArithmeticGamePresenterEngine _engine;

        public ArithmeticGamePresenter(IInput input, IOutput output, ArithmeticGamePresenterEngine engine)
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
