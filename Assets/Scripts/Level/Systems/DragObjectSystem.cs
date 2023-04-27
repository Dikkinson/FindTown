using Leopotam.Ecs;
using UnityEngine;

internal class DragObjectSystem : IEcsRunSystem
{
    private EcsFilter<DragableObject, Interaction> _filter;
    private RuntimeData _runtimeData;

    public void Run()
    {
        if (_filter.IsEmpty())
            _runtimeData.cameraEntity.Del<CameraBlock>();
        else
            _runtimeData.cameraEntity.Get<CameraBlock>();

        ref var playerInput = ref _runtimeData.cameraEntity.Get<PlayerInputData>();

        foreach (var i in _filter) 
        {
            ref var dragableObject = ref _filter.Get1(i);

            Vector3 targetPosition = playerInput.mouseWorldPos + dragableObject.pointerOffset;
            dragableObject.rigidbody.velocity = (targetPosition - dragableObject.transform.position) / Time.fixedDeltaTime;
        }
    }
}

