using DG.Tweening;
using Leopotam.Ecs;
using UnityEngine;

internal class CameraSmoothZoomOutSystem : IEcsRunSystem
{
    private EcsFilter<CameraEcs, CameraZoomOut, PlayerInputData> _cameraFilter;
    private StaticData _staticData;
    private LevelUI _ui;
    private RuntimeData _runtimeData;

    public void Run()
    {
        foreach (var i in _cameraFilter)
        {
            ref var camera = ref _cameraFilter.Get1(i);

            ref var cameraEntity = ref _cameraFilter.GetEntity(i);
            cameraEntity.Get<InputBlock>();

            Sequence zoomOutSequence = DOTween.Sequence();

            zoomOutSequence
                .Append(
                camera.camera
                .DOOrthoSize(camera.maxCameraZoom, _staticData.zoomOutSpeed)
                .SetEase(Ease.InBack)
                .SetAutoKill(true))
                .Insert(1f,
                camera.cameraTransform
                .DOMove(new Vector3(0, 0, -10), _staticData.cameraLerpSpeed)
                .From(camera.startPosition)
                .SetEase(Ease.Linear)
                .SetAutoKill(true)
            ).PrependInterval(_staticData.timeBeforeGameStart)
            .OnComplete(
                () =>
                {
                    ref EcsEntity cameraEntity = ref _cameraFilter.GetEntity(i);

                    cameraEntity.Del<InputBlock>();
                    _ui.gameScreen.Show();

                    _runtimeData.CurrentState = GameState.Game;
                });

            cameraEntity.Del<CameraZoomOut>();
        }
    }
}
