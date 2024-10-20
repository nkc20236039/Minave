using System;
using Unity.Entities;

public partial class DemoSystem : SystemBase
{
    public int speed;
    protected override void OnCreate()
    {
        foreach (var demoTag in SystemAPI.Query<RefRO<DemoComponentTag>>())
        {
            speed = demoTag.ValueRO.Speed;
        }
    }

    protected override void OnUpdate() { }
}