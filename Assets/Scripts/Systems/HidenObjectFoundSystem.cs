using Leopotam.Ecs;

public class HidenObjectFoundSystem : IEcsRunSystem
{
    private EcsFilter<HidenObject, Found> _ecsFilter;
    public void Run()
    {
        foreach (var i in _ecsFilter) 
        {
            ref var entity = ref _ecsFilter.GetEntity(i);
            ref var hidenObject = ref _ecsFilter.Get1(i);
            hidenObject.animator.SetTrigger("Find");
            entity.Destroy();
        }
    }
}

