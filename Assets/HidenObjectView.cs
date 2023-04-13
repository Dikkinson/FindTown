using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

public class HidenObjectView : MonoBehaviour, IPointerClickHandler
{
    public EcsEntity hidenObjectEntity;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!hidenObjectEntity.IsAlive()) return;
        hidenObjectEntity.Get<Interaction>();
    }
}
