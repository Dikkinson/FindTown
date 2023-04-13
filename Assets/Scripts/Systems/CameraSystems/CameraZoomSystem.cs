using Leopotam.Ecs;
using UnityEngine;

public class CameraZoomSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, CameraEcs> _ecsFilter;

    public void Run()
    {
        foreach (var i in _ecsFilter) 
        {
            ref var input = ref _ecsFilter.Get1(i);
            ref var camera = ref _ecsFilter.Get2(i);

            //camera.camera.orthographicSize -= input.zoomInput;
            camera.camera.orthographicSize = Mathf.Clamp(camera.camera.orthographicSize - input.zoomInput, camera.minCameraZoom, camera.maxCameraZoom);
        }
    }
}

