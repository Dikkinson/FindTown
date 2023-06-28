using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraBlockSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData> _filter;
    private EcsFilter<Interaction> _interactionFilter;
    private RuntimeData _runtimeData;

    public void Run()
    {
        foreach (var i in _filter) 
        {
            ref var input = ref _filter.Get1(i);

            if ((EventSystem.current.IsPointerOverGameObject() && input.pointerDownOnce) || !_interactionFilter.IsEmpty())
                _runtimeData.cameraEntity.Get<CameraBlock>();

            if(input.pointerUp)
                _runtimeData.cameraEntity.Del<CameraBlock>();
        }
    }
}

