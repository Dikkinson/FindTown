using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class DragableObjectView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public EcsEntity dragableObjectEntity;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!dragableObjectEntity.IsAlive()) return;
        dragableObjectEntity.Get<Interaction>();

        ref var dragableObject = ref dragableObjectEntity.Get<DragableObject>();
        dragableObject.pointerOffset = transform.position - eventData.pointerCurrentRaycast.worldPosition;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!dragableObjectEntity.IsAlive()) return;
        dragableObjectEntity.Del<Interaction>();
    }
}
