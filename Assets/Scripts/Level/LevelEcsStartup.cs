using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelEcsStartup : MonoBehaviour
{
    [SerializeField] private StaticData configuration;
    [SerializeField] private LevelData sceneData;
    [SerializeField] private LevelUI ui;
    private RuntimeData runtimeData;

    private EcsWorld _ecsWorld;
    private EcsSystems _systems;
    private EcsSystems _cameraSystems;
    private EcsSystems _hidenObjectSystems;
    private EcsSystems _dialogueSystems;
    private EcsSystems _dragableObjectSystems;
    private EcsSystems _timerSystems;
    private EcsSystems _uiSystems;
    private EcsSystems _rewardSystems;

    private void Start()
    {
        _ecsWorld = new EcsWorld();

        _systems = new EcsSystems(_ecsWorld);
        _cameraSystems = new EcsSystems(_ecsWorld);
        _hidenObjectSystems = new EcsSystems(_ecsWorld);
        _dialogueSystems = new EcsSystems(_ecsWorld);
        _dragableObjectSystems = new EcsSystems(_ecsWorld);
        _timerSystems = new EcsSystems(_ecsWorld);
        _uiSystems = new EcsSystems(_ecsWorld);
        _rewardSystems = new EcsSystems(_ecsWorld);

         runtimeData = new RuntimeData();

        _systems
            .Add(new BackgroundInitSystem())
            .Add(new StartGameSystem())
#if UNITY_WEBGL || UNITY_EDITOR
            .Add(new MouseInputSystem())
#else
            .Add(new TouchInputSystem())
#endif
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData)
            .Inject(ui);

        _cameraSystems
            .Add(new CameraInitSystem())
            .Add(new CameraSmoothZoomOutSystem())
            .Add(new CameraZoomSystem())
            .Add(new CameraMoveSystem())
            .Add(new CameraCalculateSizeSystem())
            .Add(new CameraClampPositionSystem())
            .Add(new CameraBlockSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData)
            .Inject(ui);

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
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData)
            .Inject(ui);

        _dragableObjectSystems
            .Add(new DragableObjectInitSystem())
            .Add(new DragObjectSystem())
            .Inject(configuration)
            .Inject(sceneData)
            .Inject(runtimeData)
            .Inject(ui);

        _timerSystems
            .Add(new TimerInitSystem())
            .Add(new TimerRunSystem())
            .Inject(sceneData)
            .Inject(runtimeData)
            .Inject(ui);

        _uiSystems
            .Add(new UiInitSystem())
            .Add(new PauseSystem())
            .Inject(ui)
            .Inject(runtimeData)
            .Inject(sceneData);

        _rewardSystems
            .Add(new RewardSystem())
            .Inject(ui)
            .Inject(runtimeData)
            .Inject(sceneData);

        _uiSystems.Init();
        _systems.Init();
        _cameraSystems.Init();
        _hidenObjectSystems.Init();
        _dialogueSystems.Init();
        _dragableObjectSystems.Init();
        _timerSystems.Init();
        _rewardSystems.Init();
    }

    private void Update()
    {
        _uiSystems?.Run();
        _systems?.Run();
        _dialogueSystems?.Run();
        _rewardSystems?.Run();

        if (runtimeData.CurrentState != GameState.Game) return;

        _cameraSystems?.Run();
        _hidenObjectSystems?.Run();
        
    }

    private void FixedUpdate()
    {
        if (runtimeData.CurrentState != GameState.Game) return;
        _dragableObjectSystems?.Run();
        _timerSystems?.Run();
    }

    private void OnDestroy()
    {
        _uiSystems?.Destroy();
        _uiSystems = null;
        _cameraSystems?.Destroy();
        _cameraSystems = null;
        _systems?.Destroy();
        _systems = null;
        _hidenObjectSystems?.Destroy();
        _hidenObjectSystems = null;
        _dialogueSystems?.Destroy();
        _dialogueSystems = null;
        _dragableObjectSystems?.Destroy();
        _dragableObjectSystems = null;
        _timerSystems?.Destroy();
        _timerSystems = null;
        _rewardSystems?.Destroy();
        _rewardSystems = null;
        _ecsWorld.Destroy();
        _ecsWorld = null;
    }
}
