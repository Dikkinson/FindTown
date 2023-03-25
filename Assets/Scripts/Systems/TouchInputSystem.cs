using Leopotam.Ecs;
using UnityEngine;

public class TouchInputSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, CameraEcs> _ecsFilter;

    public void Run()
    {
        foreach (var i in _ecsFilter)
        {
            ref var input = ref _ecsFilter.Get1(i);
            ref var camera = ref _ecsFilter.Get2(i);

            input.pointerDown = Input.touchCount == 1;
            input.pointerDownOnce = Input.GetTouch(0).phase == TouchPhase.Began;
            if (Input.touchCount == 0) input.mouseWorldPos = Vector2.zero;
            else input.mouseWorldPos = camera.camera.ScreenToWorldPoint(Input.GetTouch(0).position);

            if (Input.touchCount < 2) input.zoomInput = 0;

            Touch firstTouch = Input.GetTouch(0);
            Touch secondTouch = Input.GetTouch(1);

            Vector2 firstTouchLastPos = firstTouch.position - firstTouch.deltaPosition;
            Vector2 secondTouchLasPos = secondTouch.position - secondTouch.deltaPosition;

            float distTouch = (firstTouchLastPos - secondTouchLasPos).magnitude;
            float currentDistTouch = (firstTouch.position - secondTouch.position).magnitude;

            float difference = currentDistTouch - distTouch;

            input.zoomInput = difference * Time.deltaTime;
        }

    }
}

