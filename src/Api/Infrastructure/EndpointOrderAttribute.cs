namespace Api.Infrastructure;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public sealed class EndpointOrderAttribute(int order) : Attribute
{
    public int Order { get; } = order;
}
