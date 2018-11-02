using System;
using System.Diagnostics.Contracts;

namespace RouletteGame
{
    /// <summary>
    /// A Wheel has 38 bins.Index values 0 to 36 serves for their respective bins. For 00, index 37 will serve.
    /// </summary>
    class Wheel
    {
        private Bin[] _bins;
        private Random _random;

        public Wheel(Random random)
        {
            _bins = new Bin[38];
            _random = random;
        }

        public void AddOutcome(int bin, Outcome outcome)
        {
            if (_bins[bin] == null)
                _bins[bin] = new Bin();
            _bins[bin].Add(outcome);
        }

        public Bin Next()
        {
            return _bins[_random.Next(0, 37)];
        }

        public Bin GetBin(int bin)
        {
            Contract.Requires(bin >= 0 && bin <38);
            return _bins[bin];
        }
    }
}
