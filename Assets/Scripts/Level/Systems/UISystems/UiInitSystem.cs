using Leopotam.Ecs;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UiInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private LevelUI _ui;

    public void Init()
    {
        _ui.loadingWindow = Object.FindObjectOfType<LoadingWindow>();

        _ui.gameScreen.pauseButton.onClick.AddListener(() =>
        {
            _ecsWorld.NewEntity().Get<PauseEvent>();
        });

        _ui.pauseScreen.continueButton.onClick.AddListener(() =>
        {
            _ecsWorld.NewEntity().Get<PauseEvent>();
        });

        _ui.pauseScreen.mainMenuButton.onClick.AddListener(() =>
        {
            _ui.loadingWindow.LoadLevel(0);
        });

        _ui.victoryScreen.continueButton.onClick.AddListener(() =>
        {
            _ui.loadingWindow.LoadLevel(0);
        });

        if (_ui.loseScreen)
        {
            _ui.loseScreen.exitBtn.onClick.AddListener(() =>
            {
                _ui.loadingWindow.LoadLevel(0);
            });
        }
    }
}

