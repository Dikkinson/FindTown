using Leopotam.Ecs;

public class HidenObjectFoundSystem : IEcsRunSystem
{
    private EcsFilter<HidenObject, Found> _ecsFilter;
    private RuntimeData _runtimeData;

    public void Run()
    {
        foreach (var i in _ecsFilter) 
        {
            ref var entity = ref _ecsFilter.GetEntity(i);
            ref var hidenObject = ref _ecsFilter.Get1(i);

            if (_runtimeData.currentState != GameState.Game)
            {
                entity.Del<Found>();
            }else
            {
                hidenObject.animator.SetTrigger("Find");
                entity.Destroy();
            }
        }
    }
}

