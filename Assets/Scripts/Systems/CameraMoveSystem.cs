using Leopotam.Ecs;
using UnityEngine;

public class CameraMoveSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, CameraEcs> _filter;
    private bool drag;
    private Vector3 mouseOrigin;

    public void Run()
    {
        foreach (var i in _filter) 
        {
            ref var input = ref _filter.Get1(i);
            ref var camera = ref _filter.Get2(i);

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

