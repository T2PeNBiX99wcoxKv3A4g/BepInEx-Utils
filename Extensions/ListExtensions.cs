using JetBrains.Annotations;

namespace BepInExUtils.Extensions;

public static class ListExtensions
{
    extension<T>(IList<T> list)
    {
        [PublicAPI]
        public bool TryGetValue(int index, out T? value)
        {
            if (index < 0 || index >= list.Count)
            {
                value = default;
                return false;
            }

            value = list[index];
            return true;
        }

        [PublicAPI]
        public T? GetValueOrDefault(int index) => list.TryGetValue(index, out var value) ? value : default;

        [PublicAPI]
        public bool TrySetValue(int index, T value)
        {
            if (index < 0 || index >= list.Count) return false;
            list[index] = value;
            return true;
        }
    }

    extension<T>(T[] array)
    {
        [PublicAPI]
        public bool TryGetValue(int index, out T? value)
        {
            if (index < 0 || index >= array.Length)
            {
                value = default;
                return false;
            }

            value = array[index];
            return true;
        }

        [PublicAPI]
        public T? GetValueOrDefault(int index) => array.TryGetValue(index, out var value) ? value : default;

        [PublicAPI]
        public bool TrySetValue(int index, T value)
        {
            if (index < 0 || index >= array.Length) return false;
            array[index] = value;
            return true;
        }
    }
}