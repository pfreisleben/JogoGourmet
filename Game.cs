using System.Collections.ObjectModel;

namespace JogoGourmet
{
    internal class Game
    {
        private static List<string> _availableDishes = new List<string> { "Lasanha", "Massa", "Bolo de Chocolate" };
        public ReadOnlyCollection<string> AvailableDishes => _availableDishes.AsReadOnly();
    }
}
