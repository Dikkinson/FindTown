using Leopotam.Ecs;
using UnityEngine;

public class PlayerInputSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, CameraEcs> _filter;
    private StaticData _staticData;

    public void Run()
    {
        foreach (var i in _filter)
        {
            ref var input = ref _filter.Get1(i);
            ref var camera = ref _filter.Get2(i);

            input.zoomInput = Input.GetAxis("Mouse ScrollWheel") * _staticData.zoomSpeed;
            input.mouseWorldPos = camera.camera.ScreenToWorldPoint(Input.mousePosition);
            input.pointerDown = Input.GetMouseButton(0);
        }
        
    }
}

