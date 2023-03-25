using Leopotam.Ecs;
using UnityEngine;

public class CameraMoveSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, CameraEcs> _ecsFilter;
    private RuntimeData _runtimeData;
    private bool drag;
    private Vector3 mouseOrigin;

    public void Run()
    {
        if (_runtimeData.currentState != GameState.Game) return;

        foreach (var i in _ecsFilter) 
        {
            ref var input = ref _ecsFilter.Get1(i);
            ref var camera = ref _ecsFilter.Get2(i);

            if (!input.pointerDown)
            {
                drag = false;
                return;
            }
            
            Vector3 difference = input.mouseWorldPos - camera.cameraTransform.position;

            if (!drag)
            {
                drag = true;
                mouseOrigin = input.mouseWorldPos;
            }

            Vector3 move = mouseOrigin - difference;
            camera.cameraTransform.position = move;
        }
    }
}

