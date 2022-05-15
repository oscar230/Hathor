namespace Hathor.Common.Helpers
{
    public class RandomHelper
    {
        private static readonly Random random = new();

        // Credit: https://stackoverflow.com/a/1344242/4961901
        public static string RandomStringNonSecure(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
