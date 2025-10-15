using System.Reflection;
using HarmonyLib;
using JetBrains.Annotations;

namespace BepInExUtils.Extensions;

public static class TypeExtensions
{
    extension(Type type)
    {
        [PublicAPI]
        public T? MethodInvokeInType<T>(string methodName, params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (method.IsGenericMethod)
                throw new MethodAccessException("use Type.GenericMethodInvokeInType instead.");
            if (method.GetParameters().Length != parameters.Length)
                throw new TargetParameterCountException($"Method {methodName} parameters count not match.");
            var result = method.Invoke(null, parameters);
            return result is T a ? a : default;
        }

        [PublicAPI]
        public object? GenericMethodInvokeInType<T>(string methodName, params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(null, parameters);
        }

        [PublicAPI]
        public object? GenericMethodInvokeInType<T, T2>(string methodName, params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(null, parameters);
        }

        [PublicAPI]
        public object? GenericMethodInvokeInType<T, T2, T3>(string methodName, params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(null, parameters);
        }

        [PublicAPI]
        public object? GenericMethodInvokeInType<T, T2, T3, T4>(string methodName, params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(null, parameters);
        }

        [PublicAPI]
        public object? GenericMethodInvokeInType<T, T2, T3, T4, T5>(string methodName, params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(null, parameters);
        }

        [PublicAPI]
        public object? GenericMethodInvokeInType<T, T2, T3, T4, T5, T6>(string methodName, params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(null, parameters);
        }

        [PublicAPI]
        public object? GenericMethodInvokeInType<T, T2, T3, T4, T5, T6, T7>(string methodName,
            params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6),
                typeof(T7));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(null, parameters);
        }

        [PublicAPI]
        public object? GenericMethodInvokeInType<T, T2, T3, T4, T5, T6, T7, T8>(string methodName,
            params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6),
                typeof(T7), typeof(T8));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(null, parameters);
        }

        [PublicAPI]
        public object? GenericMethodInvokeInType<T, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName,
            params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6),
                typeof(T7), typeof(T8), typeof(T9));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(null, parameters);
        }

        [PublicAPI]
        public object? GenericMethodInvokeInType<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string methodName,
            params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6),
                typeof(T7), typeof(T8), typeof(T9), typeof(T10));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(null, parameters);
        }

        [PublicAPI]
        public void MethodInvokeInType(string methodName, params object?[] parameters)
        {
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(type, methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(type, methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (method.IsGenericMethod)
                throw new MethodAccessException("use Type.GenericMethodInvokeInType instead.");
            if (method.GetParameters().Length != parameters.Length)
                throw new TargetParameterCountException($"Method {methodName} parameters count not match.");
            method.Invoke(null, parameters);
        }

        [PublicAPI]
        public T? GetFieldValueInType<T>(string fieldName)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentNullException(nameof(fieldName));
            var field = AccessTools.Field(type, fieldName);
            if (field == null)
                throw new FieldAccessException($"Field {fieldName} not found.");
            var result = field.GetValue(null);
            return result is T a ? a : default;
        }

        [PublicAPI]
        public void SetFieldValueInType<T>(string fieldName, T value)
        {
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentNullException(nameof(fieldName));
            var field = AccessTools.Field(type, fieldName);
            if (field == null)
                throw new FieldAccessException($"Field {fieldName} not found.");
            field.SetValue(null, value);
        }

        [PublicAPI]
        public T? GetPropertyValueInType<T>(string propertyName)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));
            var property = AccessTools.Property(type, propertyName);
            if (property == null)
                throw new MemberAccessException($"Property {propertyName} not found.");
            var getProperty = property.GetMethod;
            if (getProperty == null)
                throw new MethodAccessException($"Property {propertyName} don't have any getter.");
            var result = property.GetValue(null);
            return result is T a ? a : default;
        }

        [PublicAPI]
        public void SetPropertyValueInType<T>(string propertyName, T value)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));
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