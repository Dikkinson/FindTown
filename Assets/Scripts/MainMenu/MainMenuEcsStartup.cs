using Leopotam.Ecs;
using UnityEngine;

public class MainMenuEcsStartup : MonoBehaviour
{
    [SerializeField] private MainMenuData _mainMenuData;
    [SerializeField] private MainMenuUI _mainMenuUi;

    private EcsWorld _ecsWorld;

    private EcsSystems _uiSystems;
    private EcsSystems _startGameSystems;


    void Start()
    {
        _ecsWorld = new EcsWorld();

        _uiSystems = new EcsSystems(_ecsWorld);
        _startGameSystems = new EcsSystems(_ecsWorld);

        _uiSystems
            .Add(new LevelButtonsInitSystem())
            .Add(new MainMenuUIInitSystem())
            .Add(new OpenLevelButtonSystem())
            .Add(new ActivatePhoneSystem())
            .Inject(_mainMenuData)
            .Inject(_mainMenuUi);

        _startGameSystems
            .Add(new MainStartGameSystem())
            .Inject(_mainMenuData);

        _uiSystems.Init();
        _startGameSystems.Init();
    }

    private void Update()
    {
        _uiSystems?.Run();
    }

    private void OnDestroy()
    {
        _ecsWorld.Destroy();
        _ecsWorld = null;
        _uiSystems.Destroy();
        _uiSystems = null;
        _startGameSystems.Destroy();
        _startGameSystems = null;
    }
}
