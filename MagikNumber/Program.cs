using ConsoleGames.Comparator;
using ConsoleGames.Game;
using ConsoleGames.Game.GameEngine;
using ConsoleGames.Generator;
using ConsoleGames.IO.In;
using ConsoleGames.IO.Out;
using ConsoleGames.Selector;

namespace ConsoleGames
{
    internal static class Program
    {
        private const int MAX = 100;
        private const int MAX_ATTEMPTS = 10;

        internal static void Main(string[] args)
        {
            IInput input = new ConsoleInput();
            IOutput output = new ConsoleOutput();

            List<(string name, IGamePresenter game)> games = new List<(string name, IGamePresenter game)>()
            {
                (
                    "Guess the magik number",
                    new MagikNumberGamePresenter(
                            new MagikNumberGameEngine(
                                new NumberComparator(),
                                (new RandomNumberGenerator(new Random(), new Lock(), MAX)).Generate(),
                                MAX_ATTEMPTS
                            ),
                            input,
                            output
                        )
                ),
            };

            GameLauncher gameSelector = new GameLauncher(input, output, games);
            IGamePresenter? selectedGame = gameSelector.SelectGame();
            selectedGame?.Play();
        }
    }
}