namespace HathorCommon.Helpers
{
    public static class EnumerableHelper
    {
        private static readonly Random random = new();

        public static IEnumerable<T> Shuffle<T>(IEnumerable<T> enumerable)
        {
            var list = enumerable.ToList();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list.AsEnumerable();
        }

        public static T RandomOne<T>(IEnumerable<T> enumerable)
        {
            var list = enumerable.ToList();
            var randomNumber = random.Next(list.Count);
            return list[randomNumber];
        }
    }
}
