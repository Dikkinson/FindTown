using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HidenObjectView : MonoBehaviour, IPointerClickHandler
{
    public EcsEntity hidenObjectEntity;
    public HidenObjectType type;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!hidenObjectEntity.IsAlive()) return;
        hidenObjectEntity.Get<Found>();
    }
}
