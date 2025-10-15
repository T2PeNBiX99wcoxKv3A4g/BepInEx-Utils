using JetBrains.Annotations;

namespace BepInExUtils.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
[PublicAPI]
public class AccessFieldAttribute<T>(string fieldName) : Attribute
{
    public string FieldName { get; protected set; } = fieldName;
}