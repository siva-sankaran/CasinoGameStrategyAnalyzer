
using System;

namespace RouletteGame
{
    public class Outcome : IComparable<Outcome>
    {
        private readonly string _name;
        private readonly int _odds;
        public Outcome(string name, int odds)
        {
            _name = name;
            _odds = odds;
        }

        public int WinAmount(int amount) => _odds * amount;

        public int CompareTo(Outcome outcome)
        {
            return outcome == null ? 1 : String.Compare(_name, outcome._name, StringComparison.Ordinal);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:RouletteGame.Outcome"/> is equal to the current <see cref="T:RouletteGame.Outcome"/>.
        /// </summary>
        /// <returns>
        /// true if the specified <see cref="T:RouletteGame.Outcome"/> is equal to the current <see cref="T:RouletteGame.Outcome"/>; otherwise, false.
        /// </returns>
        /// <param name="obj">The <see cref="T:RouletteGame.Outcome"/> to compare with the current <see cref="T:RouletteGame.Outcome"/>. </param><filterpriority>2</filterpriority>
        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            Outcome o = (Outcome)obj;
            return ReferenceEquals(_name, o._name);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + _name.GetHashCode();
                return hash;
            }
        }

        public override string ToString() => $"{_name} ({_odds}:1)";
    }
}
