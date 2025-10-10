using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;

namespace BepInExUtils.Extensions;

public static class TypeExtensions
{
    extension(Type type)
    {
        [UsedImplicitly]
        public T? MethodInvokeInType<T>(string methodName, params object?[] parameters)
        {
            var method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException($"Method {methodName} not found.");
            if (method.GetParameters().Length != parameters?.Length)
                throw new TargetParameterCountException($"Method {methodName} parameters count not match.");
            var result = method.Invoke(null, parameters ?? []);
            return result is T a ? a : default;
        }

        [UsedImplicitly]
        public void MethodInvokeInType(string methodName, params object?[] parameters)
        {
            var method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException($"Method {methodName} not found.");
            if (method.GetParameters().Length != parameters?.Length)
                throw new TargetParameterCountException($"Method {methodName} parameters count not match.");
            method.Invoke(null, parameters ?? []);
        }

        [UsedImplicitly]
        public T? GetFieldValueInType<T>(string fieldName)
        {
            var field = AccessTools.Field(type, fieldName);
            if (field == null)
                throw new FieldAccessException($"Field {fieldName} not found.");
            var result = field.GetValue(null);
            return result is T a ? a : default;
        }

        [UsedImplicitly]
        public void SetFieldValueInType<T>(string fieldName, T value)
        {
            var field = AccessTools.Field(type, fieldName);
            if (field == null)
                throw new FieldAccessException($"Field {fieldName} not found.");
            field.SetValue(null, value);
        }

        [UsedImplicitly]
        public T? GetPropertyValueInType<T>(string propertyName)
        {
            var property = AccessTools.Property(type, propertyName);
            if (property == null)
                throw new MemberAccessException($"Property {propertyName} not found.");
            var getProperty = property.GetMethod;
            if (getProperty == null)
                throw new MethodAccessException($"Property {propertyName} don't have any getter.");
            var result = property.GetValue(null);
            return result is T a ? a : default;
        }

        [UsedImplicitly]
        public void SetPropertyValueInType<T>(string propertyName, T value)
        {
            var property = AccessTools.Property(type, propertyName);
            if (property == null)
                throw new MemberAccessException($"Property {propertyName} not found.");
            var setProperty = property.SetMethod;
            if (setProperty == null)
                throw new MethodAccessException($"Property {propertyName} don't have any setter.");
            property.SetValue(null, value);
        }
    }
}