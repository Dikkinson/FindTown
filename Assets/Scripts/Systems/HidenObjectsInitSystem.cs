using Leopotam.Ecs;
using UnityEngine;

public class HidenObjectsInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;

    public void Init()
    {
        foreach (var hidenObjectView in Object.FindObjectsOfType<HidenObjectView>())
        {
            var hidenObjectEntity = _ecsWorld.NewEntity();

            ref var hidenObject = ref hidenObjectEntity.Get<HidenObject>();

            hidenObjectView.hidenObjectEntity = hidenObjectEntity;
            hidenObject.animator = hidenObjectView.GetComponent<Animator>();
            hidenObject.type = hidenObjectView.type;
        }
    }
}

