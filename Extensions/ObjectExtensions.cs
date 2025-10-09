using HarmonyLib;
using JetBrains.Annotations;

namespace BepInExUtils.Extensions;

public static class ObjectExtensions
{
    extension(object obj)
    {
        [UsedImplicitly]
        public T? MethodAccess<T>(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new NullReferenceException($"obj {nameof(obj)} is null.");
            var method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException($"Method {methodName} not found.");
            var result = method.Invoke(obj, parameters);
            return result is T a ? a : default;
        }

        [UsedImplicitly]
        public void MethodAccess(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new NullReferenceException($"obj {nameof(obj)} is null.");
            var method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException($"Method {methodName} not found.");
            method.Invoke(obj, parameters);
        }

        [UsedImplicitly]
        public T? FieldAccess<T>(string fieldName) => Traverse.Create(obj).Field<T>(fieldName).Value;

        [UsedImplicitly]
        public T? PropertyAccess<T>(string propertyName, params object[]? index) =>
            Traverse.Create(obj).Property<T>(propertyName, index).Value;
    }
}