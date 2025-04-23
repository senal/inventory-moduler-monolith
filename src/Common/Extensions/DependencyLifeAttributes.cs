namespace Extensions;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class TransientAttribute : Attribute;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ScopedAttribute : Attribute;
