using Leopotam.Ecs;
using UnityEngine;

public class MouseInputSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, CameraEcs> _ecsFilter;
    private StaticData _staticData;

    public void Run()
    {
        foreach (var i in _ecsFilter)
        {
            ref var input = ref _ecsFilter.Get1(i);
            ref var camera = ref _ecsFilter.Get2(i);

            input.zoomInput = Input.GetAxis("Mouse ScrollWheel") * _staticData.zoomSpeed;
            input.mouseWorldPos = camera.camera.ScreenToWorldPoint(Input.mousePosition);
            input.pointerDown = Input.GetMouseButton(0);
            input.pointerDownOnce = Input.GetMouseButtonDown(0);
        }
        
    }
}

