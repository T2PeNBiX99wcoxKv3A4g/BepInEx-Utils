using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;

namespace BepInExUtils.Extensions;

public static class ObjectExtensions
{
    extension(object obj)
    {
        [UsedImplicitly]
        public T? MethodInvoke<T>(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new NullReferenceException($"obj {nameof(obj)} is null.");
            var method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException($"Method {methodName} not found.");
            if (method.GetParameters().Length != parameters?.Length)
                throw new TargetParameterCountException($"Method {methodName} parameters count not match.");
            var result = method.Invoke(method.IsStatic ? null : obj, parameters ?? []);
            return result is T a ? a : default;
        }

        [UsedImplicitly]
        public void MethodInvoke(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new NullReferenceException($"obj {nameof(obj)} is null.");
            var method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException($"Method {methodName} not found.");
            if (method.GetParameters().Length != parameters?.Length)
                throw new TargetParameterCountException($"Method {methodName} parameters count not match.");
            method.Invoke(method.IsStatic ? null : obj, parameters ?? []);
        }

        [UsedImplicitly]
        public T? GetFieldValue<T>(string fieldName)
        {
            if (obj == null)
                throw new NullReferenceException($"obj {nameof(obj)} is null.");
            var field = AccessTools.Field(obj.GetType(), fieldName);
            if (field == null)
                throw new FieldAccessException($"Field {fieldName} not found.");
            var result = field.GetValue(field.IsStatic ? null : obj);
            return result is T a ? a : default;
        }

        [UsedImplicitly]
        public void SetFieldValue<T>(string fieldName, T value)
        {
            if (obj == null)
                throw new NullReferenceException($"obj {nameof(obj)} is null.");
            var field = AccessTools.Field(obj.GetType(), fieldName);
            if (field == null)
                throw new FieldAccessException($"Field {fieldName} not found.");
            field.SetValue(field.IsStatic ? null : obj, value);
        }

        [UsedImplicitly]
        public T? GetPropertyValue<T>(string propertyName)
        {
            if (obj == null)
                throw new NullReferenceException($"obj {nameof(obj)} is null.");
            var property = AccessTools.Property(obj.GetType(), propertyName);
            if (property == null)
                throw new MemberAccessException($"Property {propertyName} not found.");
            var getProperty = property.GetMethod;
            if (getProperty == null)
                throw new MethodAccessException($"Property {propertyName} don't have any getter.");
            var result = property.GetValue(getProperty.IsStatic ? null : obj);
            return result is T a ? a : default;
        }

        [UsedImplicitly]
        public void SetPropertyValue<T>(string propertyName, T value)
        {
            if (obj == null)
                throw new NullReferenceException($"obj {nameof(obj)} is null.");
            var property = AccessTools.Property(obj.GetType(), propertyName);
            if (property == null)
                throw new MemberAccessException($"Property {propertyName} not found.");
            var setProperty = property.SetMethod;
            if (setProperty == null)
                throw new MethodAccessException($"Property {propertyName} don't have any setter.");
            property.SetValue(setProperty.IsStatic ? null : obj, value);
        }
    }
}