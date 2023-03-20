using Leopotam.Ecs;
using UnityEngine;

public class CameraZoomSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, CameraEcs> _filter;

    public void Run()
    {
        foreach (var i in _filter) 
        {
            ref var input = ref _filter.Get1(i);
            ref var camera = ref _filter.Get2(i);

            //camera.camera.orthographicSize -= input.zoomInput;
            camera.camera.orthographicSize = Mathf.Clamp(camera.camera.orthographicSize - input.zoomInput, camera.minCameraZoom, camera.maxCameraZoom);
        }
    }
}

