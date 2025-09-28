namespace MagikNumber.Generator
{
    internal sealed class RandomNumberGenerator : IGenerator
    {
        private readonly Lock _locker;
        private readonly Random _rnd;
        private readonly int _min;
        private readonly int _max;

        public RandomNumberGenerator(Random rdn, Lock locker, int max, int min = 0)
        {
            _min = min;
            _max = max;
            _rnd = rdn;
            _locker = locker;
        }

        public int Generate()
        {
            using (_locker.EnterScope())
            {
                return _rnd.Next(_min, _max);
            }
        }
    }
}
