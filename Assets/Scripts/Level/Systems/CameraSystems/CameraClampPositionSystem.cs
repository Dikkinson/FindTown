using Leopotam.Ecs;
using UnityEngine;

public class CameraClampPositionSystem : IEcsRunSystem
{
    private EcsFilter<CameraEcs> _filterCamera;
    private RuntimeData _runtimeData;

    public void Run()
    {
        foreach (var i in _filterCamera)
        {
            
            ref var camera = ref _filterCamera.Get1(i);
            ref var background = ref _runtimeData.backgroundEntity.Get<Background>();

            Vector3 move = camera.cameraTransform.position;

            move.x = Mathf.Clamp(move.x, background.xMin + camera.camWidth, background.xMax - camera.camWidth);
            move.y = Mathf.Clamp(move.y, background.yMin + camera.camHeight, background.yMax - camera.camHeight);

            if (camera.camWidth >= background.xMax) camera.cameraTransform.position = new Vector3(0,0,-10f);
            else camera.cameraTransform.position = move;
        }
    }
}