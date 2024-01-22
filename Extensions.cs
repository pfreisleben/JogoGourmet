namespace JogoGourmet
{
    internal static class Extensions
    {
        public static string GetRandom(this List<string> list)
        {
            var random = new Random();
            var index = random.Next(0, list.Count - 1);
            var result = list[index];
            return result;
        }
    }
}
