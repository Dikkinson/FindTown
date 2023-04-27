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

        switch (timer.timerType)
        {
            case TimerType.Forward:
                timer.currentTime = 0;
                break;
            case TimerType.Backward:
                timer.currentTime = _sceneData.levelTime;
                break;
        }
    }
}

