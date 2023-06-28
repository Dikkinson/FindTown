using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButtonsInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private MainMenuData _mainMenuData;
    private MainMenuUI _mainMenuUI;

    public void Init()
    {
        for (int i = 0; i < _mainMenuData.levelButtons.Count; i++)
        {
            EcsEntity lvlButtonEntity = _ecsWorld.NewEntity();

            ref var lvlButton = ref lvlButtonEntity.Get<LevelButton>();

            LevelButtonView lvlButtonView = _mainMenuData.levelButtons[i];

            lvlButton.buttonComponent = lvlButtonView.GetComponent<Button>();
           
            lvlButton.isOpen = false;
            lvlButton.levelNumber = lvlButtonView.levelNumber;
            lvlButton.marker = lvlButtonView.marker;
            lvlButton.marker.SetActive(false);
            lvlButton.isOpen = false;
            lvlButton.buttonComponent.interactable = lvlButton.isOpen;

            lvlButton.buttonComponent.onClick.AddListener(() =>
            {
                _mainMenuUI.preStartWindow.levelTitleText.text = lvlButtonView.levelName;
                _mainMenuUI.preStartWindow.levelDescText.text = lvlButtonView.levelDescription;
                _mainMenuUI.preStartWindow.previewCharacterGraphic.skeletonDataAsset = lvlButtonView.previewCharacter;
                _mainMenuUI.preStartWindow.characterNameText.text = lvlButtonView.previewCharacterName;
                _mainMenuUI.preStartWindow.startLevelButton.onClick.AddListener(() =>
                {
                    _mainMenuUI.loadingWindow.LoadLevel(lvlButtonView.levelNumber);
                });
                _mainMenuUI.preStartWindow.Show();
            });
        }
    }
}
