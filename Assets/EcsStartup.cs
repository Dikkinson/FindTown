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
    private EcsSystems _dialogueSystems;

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _systems = new EcsSystems(_ecsWorld);
        _cameraSystems = new EcsSystems(_ecsWorld);
        _hidenObjectSystems = new EcsSystems(_ecsWorld);
        _dialogueSystems = new EcsSystems(_ecsWorld);

        RuntimeData runtimeData = new RuntimeData();

        _systems
            .Add(new BackgroundInitSystem())
#if UNITY_WEBGL || UNITY_EDITOR
            .Add(new MouseInputSystem())
#else
            .Add(new TouchInputSystem())
#endif
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

        _dialogueSystems
            .Add(new DialogueInitSystem())
            .Add(new DialogueFlowSystem())
            .Add(new DialogueEndSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData)
            .Inject(ui);

        _systems.Init();
        _cameraSystems.Init();
        _hidenObjectSystems.Init();
        _dialogueSystems.Init();
    }

    private void Update()
    {
        _systems?.Run();
        _cameraSystems?.Run();
        _hidenObjectSystems?.Run();
        _dialogueSystems?.Run();
    }

    private void OnDestroy()
    {
        _cameraSystems?.Destroy();
        _cameraSystems = null;
        _systems?.Destroy();
        _systems = null;
        _hidenObjectSystems?.Destroy();
        _hidenObjectSystems = null;
        _dialogueSystems?.Destroy();
        _dialogueSystems = null;
        _ecsWorld.Destroy();
        _ecsWorld = null;
    }
}
