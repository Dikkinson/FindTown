using Leopotam.Ecs;
using UnityEngine;

public struct CameraEcs
{
    public EcsEntity background;
    public Transform cameraTransform;
    public Camera camera;
    public float minCameraZoom;
    public float maxCameraZoom;
    public float cameraZoomSpeed;
    public float camWidth, camHeight;
}

