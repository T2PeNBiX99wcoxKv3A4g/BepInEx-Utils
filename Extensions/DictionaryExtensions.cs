using JetBrains.Annotations;

namespace BepInExUtils.Extensions;

public static class DictionaryExtensions
{
    extension<TKey, TValue>(IDictionary<TKey, TValue> dict)
    {
        [PublicAPI]
        public TValue? GetValueOrDefault(TKey key) => dict.TryGetValue(key, out var value) ? value : default;
    }
}