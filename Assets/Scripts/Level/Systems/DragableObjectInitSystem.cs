using Leopotam.Ecs;
using UnityEngine;

public class DragableObjectInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;

    public void Init()
    {
        foreach (var item in Object.FindObjectsOfType<DragableObjectView>())
        {
            Rigidbody2D rigidbody = item.GetComponent<Rigidbody2D>();
            EcsEntity dragableObjectEntity = _ecsWorld.NewEntity();

            item.dragableObjectEntity = dragableObjectEntity;

            ref var dragableObjectComponent = ref dragableObjectEntity.Get<DragableObject>();
            
            dragableObjectComponent.rigidbody = rigidbody;
            dragableObjectComponent.transform = item.transform;
        }
    }
}

