using Leopotam.Ecs;
using UnityEngine;

public class OpenLevelButtonSystem : IEcsRunSystem
{
    private EcsFilter<UpdateLevelButtons> _filter;
    private EcsFilter<LevelButton> _filterButtons;

    public void Run()
    {
        foreach (var i in _filter) 
        {
            _filter.GetEntity(i).Del<UpdateLevelButtons>();
        }
        foreach (var i in _filterButtons)
        {
            ref var lvlButton = ref _filterButtons.Get1(i);

            if(lvlButton.levelNumber <= PlayerPrefs.GetInt("OpenedLevels"))
            {
                lvlButton.marker.SetActive(false);
                lvlButton.isOpen = true;
                lvlButton.buttonComponent.interactable = lvlButton.isOpen;

                if (lvlButton.levelNumber == PlayerPrefs.GetInt("OpenedLevels"))
                {
                    lvlButton.marker.SetActive(true);
                }
            }
        }
    }
}

