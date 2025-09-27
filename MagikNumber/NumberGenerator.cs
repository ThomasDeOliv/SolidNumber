namespace MagikNumber
{
    internal sealed class NumberGenerator : INumberGenerator
    {
        private readonly Lock _locker;
        private readonly Random _rnd;
        private readonly int _min;
        private readonly int _max;

        public NumberGenerator(Random rdn, Lock locker, int max, int min = 0)
        {
            _min = min;
            _max = max;
            _rnd = rdn;
            _locker = locker;
        }

        public int GetRandom()
        {
            using (_locker.EnterScope())
            {
                return this._rnd.Next(_min, _max);
            }
        }
    }
}
