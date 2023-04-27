using Leopotam.Ecs;
using UnityEngine.SceneManagement;

public class UiInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private LevelUI _ui;

    public void Init()
    {
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
            SceneManager.LoadScene(0);
        });

        _ui.pauseScreen.restartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });

        _ui.victoryScreen.continueButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }
}

