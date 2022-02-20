using System.Globalization;

namespace PhoneDirect
{
    public static class Functions
    {
        public static string ToTitleCase(string text)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(text);
        }
    }
}
