using JetBrains.Annotations;

namespace BepInExUtils.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
[UsedImplicitly]
public class AccessFieldAttribute<T>(string fieldName) : Attribute
{
    [UsedImplicitly] public string FieldName { get; protected set; } = fieldName;
}