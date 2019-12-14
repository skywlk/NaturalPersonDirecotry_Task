using System.Linq;

namespace NPD.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsGeorgian(this string text)
        {
            return text.Any(c => c >= 0x10D0 && c <= 0x10F0);
        }

        public static bool IsLatin(this string text)
        {
            return text.Any(c => c >= 0x0041 && c <= 0x005A) || text.Any(c => c >= 0x0061 && c <= 0x007A);
        }

        public static bool IsLatinOrGeorgian(this string text)
        {
            return text.IsLatin() ^ text.IsGeorgian();
        }
    }
}
