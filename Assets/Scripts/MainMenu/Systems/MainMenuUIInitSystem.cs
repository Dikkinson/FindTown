using Leopotam.Ecs;
using UnityEngine;

public class MainMenuUIInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private MainMenuUI _mainMenuUi;
    private MainMenuData _mainMenuData;

    public void Init()
    {
        _ecsWorld.NewEntity().Get<UpdateLevelButtons>();

        _mainMenuUi.mainMenuWindow.phoneButton.onClick.AddListener(
        () =>
        {
            _mainMenuUi.mainMenuWindow.phoneButton.interactable = false;
            PlayerPrefs.SetInt("OpenedLevels", PlayerPrefs.GetInt("OpenedLevels") + 1);
            _ecsWorld.NewEntity().Get<UpdateLevelButtons>();
            _mainMenuData.phoneGraphic.AnimationState.SetAnimation(0, "idle", true);
        });

        _mainMenuUi.mainMenuWindow.settingsButton.onClick.AddListener(
        () =>
        {
            PlayerPrefs.DeleteAll();
        });

        _mainMenuUi.preStartWindow.closeWindowButton.onClick.AddListener(() => {
            _mainMenuUi.preStartWindow.Show(false);
        });
    }
}

