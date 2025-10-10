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
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (method.IsGenericMethod)
                throw new MethodAccessException("use object.GenericMethodInvoke instead.");
            if (method.GetParameters().Length != parameters.Length)
                throw new TargetParameterCountException($"Method {methodName} parameters count not match.");
            var result = method.Invoke(method.IsStatic ? null : obj, parameters);
            return result is T a ? a : default;
        }

        [UsedImplicitly]
        public object? GenericMethodInvoke<T>(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(method.IsStatic ? null : obj, parameters);
        }

        [UsedImplicitly]
        public object? GenericMethodInvoke<T, T2>(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(method.IsStatic ? null : obj, parameters);
        }

        [UsedImplicitly]
        public object? GenericMethodInvoke<T, T2, T3>(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(method.IsStatic ? null : obj, parameters);
        }

        [UsedImplicitly]
        public object? GenericMethodInvoke<T, T2, T3, T4>(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(method.IsStatic ? null : obj, parameters);
        }

        [UsedImplicitly]
        public object? GenericMethodInvoke<T, T2, T3, T4, T5>(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(method.IsStatic ? null : obj, parameters);
        }

        [UsedImplicitly]
        public object? GenericMethodInvoke<T, T2, T3, T4, T5, T6>(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(method.IsStatic ? null : obj, parameters);
        }

        [UsedImplicitly]
        public object? GenericMethodInvoke<T, T2, T3, T4, T5, T6, T7>(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6),
                typeof(T7));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(method.IsStatic ? null : obj, parameters);
        }

        [UsedImplicitly]
        public object? GenericMethodInvoke<T, T2, T3, T4, T5, T6, T7, T8>(string methodName,
            params object?[] parameters)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6),
                typeof(T7), typeof(T8));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(method.IsStatic ? null : obj, parameters);
        }

        [UsedImplicitly]
        public object? GenericMethodInvoke<T, T2, T3, T4, T5, T6, T7, T8, T9>(string methodName,
            params object?[] parameters)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6),
                typeof(T7), typeof(T8), typeof(T9));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(method.IsStatic ? null : obj, parameters);
        }

        [UsedImplicitly]
        public object? GenericMethodInvoke<T, T2, T3, T4, T5, T6, T7, T8, T9, T10>(string methodName,
            params object?[] parameters)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (!method.IsGenericMethod)
                throw new MethodAccessException($"Method {methodName} is not generic method.");
            method = method.MakeGenericMethod(typeof(T), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6),
                typeof(T7), typeof(T8), typeof(T9), typeof(T10));
            return method.GetParameters().Length != parameters.Length
                ? throw new TargetParameterCountException($"Method {methodName} parameters count not match.")
                : method.Invoke(method.IsStatic ? null : obj, parameters);
        }

        [UsedImplicitly]
        public void MethodInvoke(string methodName, params object?[] parameters)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(methodName))
                throw new ArgumentNullException(nameof(methodName));
            var parametersTypes = AccessTools.GetTypes(parameters);
            var method = AccessTools.Method(obj.GetType(), methodName, parametersTypes);
            if (method == null)
                method = AccessTools.Method(obj.GetType(), methodName);
            if (method == null)
                throw new MethodAccessException(
                    $"Method {methodName} with parameters [{string.Join(", ", parametersTypes.ToList())}] not found.");
            if (method.IsGenericMethod)
                throw new MethodAccessException("use object.GenericMethodInvoke instead.");
            if (method.GetParameters().Length != parameters.Length)
                throw new TargetParameterCountException($"Method {methodName} parameters count not match.");
            method.Invoke(method.IsStatic ? null : obj, parameters);
        }

        [Obsolete("Use object.MethodInvoke instead.")]
        [UsedImplicitly]
        public void MethodAccess(string methodName, params object?[] parameters) =>
            obj.MethodInvoke(methodName, parameters);

        [Obsolete("Use object.MethodInvoke instead.")]
        [UsedImplicitly]
        public T? MethodAccess<T>(string methodName, params object?[] parameters) =>
            obj.MethodInvoke<T>(methodName, parameters);

        [UsedImplicitly]
        public T? GetFieldValue<T>(string fieldName)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentNullException(nameof(fieldName));
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
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(fieldName))
                throw new ArgumentNullException(nameof(fieldName));
            var field = AccessTools.Field(obj.GetType(), fieldName);
            if (field == null)
                throw new FieldAccessException($"Field {fieldName} not found.");
            field.SetValue(field.IsStatic ? null : obj, value);
        }

        [UsedImplicitly]
        public T? GetPropertyValue<T>(string propertyName)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));
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
                throw new ArgumentNullException(nameof(obj));
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));
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