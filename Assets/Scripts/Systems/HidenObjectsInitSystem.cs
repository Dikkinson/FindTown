using Leopotam.Ecs;
using UnityEngine;

public class HidenObjectsInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private SceneData _sceneData;

    public void Init()
    {
        foreach (var levelTask in _sceneData.levelTasks)
        {
            foreach (var hidenObject in levelTask.taskObjects)
            {
                var hidenObjectEntity = _ecsWorld.NewEntity();

                ref var hidenObjectComponent = ref hidenObjectEntity.Get<HidenObject>();

                hidenObject.hidenObjectEntity = hidenObjectEntity;
                hidenObjectComponent.animator = hidenObject.GetComponent<Animator>();
                hidenObjectComponent.type = levelTask.type;
            }
        }
    }
}

