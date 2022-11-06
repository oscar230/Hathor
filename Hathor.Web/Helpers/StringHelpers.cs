namespace Hathor.Web.Helpers
{
    public static class StringHelpers
    {
        public static string? Shorten(string? input, int maxLength, string appendString = "...")
        {
            if (input is not null && input.Length > maxLength)
            {
                maxLength -= appendString.Length;
                input = input[..maxLength];
                input = string.Concat(input, appendString);
            }
            return input;
        }
    }
}
