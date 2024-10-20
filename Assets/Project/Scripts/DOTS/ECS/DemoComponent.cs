using Unity.Entities;

public struct DemoComponent : IComponentData { }

public struct DemoComponentTag : IComponentData
{
    public int Speed;
}