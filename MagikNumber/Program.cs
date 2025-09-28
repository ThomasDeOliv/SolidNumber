using MagikNumber.Comparator;
using MagikNumber.Game;
using MagikNumber.Game.GameEngine;
using MagikNumber.Generator;
using MagikNumber.IO.In;
using MagikNumber.IO.Out;

namespace MagikNumber
{
    internal static class Program
    {
        private const int MAX = 100;
        private const int MAX_ATTEMPTS = 10;

        internal static void Main(string[] args)
        {
            IGamePresenter game = new MagikNumberGamePresenter(
                new MagikNumberGameEngine(
                    new NumberComparator(),
                    (new RandomNumberGenerator(new Random(), new Lock(), MAX)).Generate(),
                    MAX_ATTEMPTS
                ),
                new ConsoleInput(),
                new ConsoleOutput()
            );
            game.Play();
        }
    }
}