using ConsoleGames.Game.GamePresenter;
using ConsoleGames.IO.In;
using ConsoleGames.IO.Out;

namespace ConsoleGames.Selector
{
    internal enum GameSelection
    {
        NONE,
        MAGIK_NUMBER,
    }

    internal class GameLauncher
    {
        private readonly IInput _input;
        private readonly IOutput _output;
        private readonly List<(string name, IGamePresenter game)> _games;

        public GameLauncher(IInput input, IOutput output, List<(string name, IGamePresenter game)> games)
        {
            _input = input;
            _output = output;
            _games = games;
        }

        public IGamePresenter? SelectGame()
        {
            _output.WriteLineOutput("*****************************");

            for (int i = 0; i < _games.Count; i++)
            {
                _output.WriteLineOutput($"{i + 1} - {_games[i].name}");
            }

            _output.WriteLineOutput("*****************************");

            string selection = _input.ReadKey();
            _output.WriteOutput("", true);

            if (int.TryParse(selection, out int gameSelection) && 1 <= gameSelection && gameSelection <= _games.Count)
            {
                return _games[gameSelection - 1].game;
            }

            _output.WriteLineOutput("No game selected. Exiting the program now.");
            return null;
        }
    }
}
