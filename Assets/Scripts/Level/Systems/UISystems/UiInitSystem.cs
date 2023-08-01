using Leopotam.Ecs;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UiInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private LevelUI _ui;
    private LevelData _levelData;

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

        for (int i = 0; i < _levelData.levelRewardData.Count; i++)
        {
            string minutesStr = string.Format("{0:00}", (int)(_levelData.levelRewardData[i].seconds / 60f));
            string secondsStr = string.Format("{0:00}", (int)(_levelData.levelRewardData[i].seconds % 60f));

            _ui.victoryScreen.rewardBlock.timeTexts[i].text = $"{minutesStr}:{secondsStr}";
        }

        if (_ui.loseScreen)
        {
            _ui.loseScreen.exitBtn.onClick.AddListener(() =>
            {
                _ui.loadingWindow.LoadLevel(0);
            });
        }
    }
}

