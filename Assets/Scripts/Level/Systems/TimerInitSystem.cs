using Leopotam.Ecs;

public class TimerInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private LevelData _sceneData;

    public void Init()
    {
        EcsEntity timerEntity = _ecsWorld.NewEntity();

        ref var timer = ref timerEntity.Get<Timer>();

        timer.timerType = _sceneData.timerType;
        timer.currentTime = 0;
    }
}

