using Leopotam.Ecs;
using System.Collections.Generic;

public class RuntimeData
{
    public EcsEntity backgroundEntity;
    public Dictionary<HidenObjectType, EcsEntity> taskListEntityByType = new Dictionary<HidenObjectType, EcsEntity>();
}

