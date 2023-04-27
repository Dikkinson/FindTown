using Leopotam.Ecs;
using UnityEngine;

public struct CameraEcs
{
    public Transform cameraTransform;
    public Camera camera;
    public Vector3 startPosition;
    public float minCameraZoom;
    public float maxCameraZoom;
    public float cameraZoomSpeed;
    public float camWidth, camHeight;
}

