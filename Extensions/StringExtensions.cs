using JetBrains.Annotations;

namespace BepInExUtils.Extensions;

public static class StringExtensions
{
    extension(string str)
    {
        [PublicAPI]
        public string? FirstPath(char value)
        {
            var findEnd = str.LastIndexOf(value);
            return findEnd < 0 ? null : str.Substring(0, findEnd);
        }

        [PublicAPI]
        public string? FirstPath(string value)
        {
            var findEnd = str.LastIndexOf(value, StringComparison.Ordinal);
            return findEnd < 0 ? null : str.Substring(0, findEnd - value.Length + 1);
        }

        [PublicAPI]
        public string? LastPath(char value)
        {
            var findStart = str.IndexOf(value);
            return findStart < 0 ? null : str.Substring(findStart + 1);
        }

        [PublicAPI]
        public string? LastPath(string value)
        {
            var findStart = str.IndexOf(value, StringComparison.Ordinal);
            return findStart < 0 ? null : str.Substring(findStart + value.Length);
        }

        [PublicAPI]
        public string? MiddlePath(char first, char last) => str.FirstPath(last)?.LastPath(first);

        [PublicAPI]
        public string? MiddlePath(string first, string last) => str.FirstPath(last)?.LastPath(first);

        [PublicAPI]
        public string? MiddlePath(char first, string last) => str.FirstPath(last)?.LastPath(first);

        [PublicAPI]
        public string? MiddlePath(string first, char last) => str.FirstPath(last)?.LastPath(first);

        [PublicAPI]
        public bool TryGetValue(int index, out char? value)
        {
            if (index < 0 || index >= str.Length)
            {
                value = null;
                return false;
            }

            value = str[index];
            return true;
        }

        [PublicAPI]
        public char? GetValueOrDefault(int index) => str.TryGetValue(index, out var value) ? value : null;
    }
}