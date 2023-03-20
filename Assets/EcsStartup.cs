using Leopotam.Ecs;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    [SerializeField] private StaticData configuration;
    [SerializeField] private SceneData sceneData;
    [SerializeField] private UI ui;

    private EcsWorld _ecsWorld;
    private EcsSystems _systems;
    private EcsSystems _cameraSystems;
    private EcsSystems _hidenObjectSystems;

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _systems = new EcsSystems(_ecsWorld);
        _cameraSystems = new EcsSystems(_ecsWorld);
        _hidenObjectSystems = new EcsSystems(_ecsWorld);

        RuntimeData runtimeData = new RuntimeData();

        _systems
            .Add(new BackgroundInitSystem())
            .Add(new PlayerInputSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData);

        _cameraSystems
            .Add(new CameraInitSystem())
            .Add(new CameraZoomSystem())
            .Add(new CameraMoveSystem())
            .Add(new CameraCalculateSizeSystem())
            .Add(new CameraClampPositionSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData);

        _hidenObjectSystems
            .Add(new HidenObjectsInitSystem())
            .Add(new TaskListInitSystem())
            .Add(new TaskListUpdateSystem())
            .Add(new HidenObjectFoundSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData)
            .Inject(ui);

        _systems.Init();
        _cameraSystems.Init();
        _hidenObjectSystems.Init();
    }

    private void Update()
    {
        _systems?.Run();
        _cameraSystems?.Run();
        _hidenObjectSystems?.Run();
    }

    private void OnDestroy()
    {
        _cameraSystems?.Destroy();
        _cameraSystems = null;
        _systems?.Destroy();
        _systems = null;
        _ecsWorld.Destroy();
        _ecsWorld = null;
    }
}
