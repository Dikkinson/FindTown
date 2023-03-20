
using Leopotam.Ecs;
using UnityEngine;

public class CameraCalculateSizeSystem : IEcsRunSystem
{
    private EcsFilter<CameraEcs> _filter;

    public void Run()
    {
        foreach (var i in _filter) 
        {
            ref var camera = ref _filter.Get1(i);

            if (camera.camHeight == camera.camera.orthographicSize) return;

            camera.camHeight = camera.camera.orthographicSize;
            camera.camWidth = camera.camera.aspect * camera.camHeight;
        }
    }
}

