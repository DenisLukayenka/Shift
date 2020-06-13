namespace Shift.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string ValueOrDefault(this string value)
        {
            return value ?? "";
        }
    }
}
