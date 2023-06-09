﻿using Leopotam.Ecs;
using UnityEngine;

public class CameraInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private LevelData _sceneData;
    private RuntimeData _runtimeData;

    public void Init()
    {
        EcsEntity cameraEntity = _ecsWorld.NewEntity();

        ref var camera = ref cameraEntity.Get<CameraEcs>();
        ref var inputData = ref cameraEntity.Get<PlayerInputData>();

        camera.cameraTransform = _sceneData.sceneCameraTransform;
        camera.camera = camera.cameraTransform.GetComponent<Camera>();
        camera.minCameraZoom = _sceneData.minCameraZoom;


        float backgroundMaxX = _sceneData.backgroundCollider.bounds.max.x;
        float backgroundMaxY = _sceneData.backgroundCollider.bounds.max.y;

        float maxCamHeight = backgroundMaxY;
        float maxCamWidth = camera.camera.aspect * maxCamHeight;

        camera.maxCameraZoom = backgroundMaxX < maxCamWidth ? backgroundMaxX / camera.camera.aspect : backgroundMaxY;

        camera.startPosition = camera.cameraTransform.position;

        _runtimeData.cameraEntity = cameraEntity;

        cameraEntity.Get<CameraZoomOut>();
    }
}

