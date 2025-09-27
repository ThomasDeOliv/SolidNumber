namespace MagikNumber
{
    internal static class Program
    {
        private const int MAX = 100;
        private const int MAX_ATTEMPTS = 10;

        internal static void Main(string[] args)
        {
            Game game = new Game(
                new NumberGenerator(new Random(), new Lock(), MAX),
                new NumberComparator(),
                new Output(),
                new Input(),
                MAX_ATTEMPTS
            );
            game.Play();
        }
    }
}