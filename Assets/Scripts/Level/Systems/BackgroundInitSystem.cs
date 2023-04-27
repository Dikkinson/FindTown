using Leopotam.Ecs;

public class BackgroundInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private LevelData _sceneData;
    private RuntimeData _runtimeData;

    public void Init()
    {
        EcsEntity backgroundEntity = _ecsWorld.NewEntity();

        ref var background = ref backgroundEntity.Get<Background>();

        background.backgroundCollider = _sceneData.backgroundCollider;
        background.xMin = _sceneData.backgroundCollider.bounds.min.x;
        background.xMax = _sceneData.backgroundCollider.bounds.max.x;
        background.yMin = _sceneData.backgroundCollider.bounds.min.y;
        background.yMax = _sceneData.backgroundCollider.bounds.max.y;

        _runtimeData.backgroundEntity = backgroundEntity;
    }
}

