using System;
using System.Globalization;

namespace Shared.Extensions
{
    public static class StringExtensions
    {
        public static DateTime ToDateTime(this string s)
        {
            const string format = "dd.MM.yyyy";
            return DateTime.ParseExact(s, format, CultureInfo.InvariantCulture);
        }
    }
}