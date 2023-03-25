﻿using Leopotam.Ecs;
using UnityEngine;

public class CameraInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private SceneData _sceneData;

    public void Init()
    {
        EcsEntity cameraEntity = _ecsWorld.NewEntity();

        ref var camera = ref cameraEntity.Get<CameraEcs>();
        ref var inputData = ref cameraEntity.Get<PlayerInputData>();

        camera.cameraTransform = _sceneData.sceneCameraTransform;
        camera.camera = camera.cameraTransform.GetComponent<Camera>();
        camera.minCameraZoom = _sceneData.minCameraZoom;
        camera.maxCameraZoom = _sceneData.backgroundCollider.bounds.max.y;
    }
}
