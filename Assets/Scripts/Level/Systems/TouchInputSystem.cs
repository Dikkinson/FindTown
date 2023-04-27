using Leopotam.Ecs;
using UnityEngine;

public class TouchInputSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, CameraEcs>.Exclude<InputBlock> _ecsFilter;
    private StaticData _staticData;

    public void Run()
    {
        foreach (var i in _ecsFilter)
        {
            ref var input = ref _ecsFilter.Get1(i);
            ref var camera = ref _ecsFilter.Get2(i);

            input.pointerDown = Input.touchCount == 1;
            if(Input.touchCount > 0 && Input.touchCount < 2)
            {
                input.pointerDownOnce = Input.GetTouch(0).phase == TouchPhase.Began;
                input.mouseWorldPos = camera.camera.ScreenToWorldPoint(Input.GetTouch(0).position);
                input.zoomInput = 0;
            }
            else
            {
                input.mouseWorldPos = Vector2.zero;
                input.pointerDownOnce = false;
            }

            if (Input.touchCount >= 2)
            {
                Touch firstTouch = Input.GetTouch(0);
                Touch secondTouch = Input.GetTouch(1);

                Vector2 firstTouchLastPos = firstTouch.position - firstTouch.deltaPosition;
                Vector2 secondTouchLasPos = secondTouch.position - secondTouch.deltaPosition;

                float distTouch = (firstTouchLastPos - secondTouchLasPos).magnitude;
                float currentDistTouch = (firstTouch.position - secondTouch.position).magnitude;

                float difference = currentDistTouch - distTouch;
                Debug.Log(difference);
                input.zoomInput = difference * Time.deltaTime * _staticData.zoomSpeedPhone;
            }
        }

    }
}

