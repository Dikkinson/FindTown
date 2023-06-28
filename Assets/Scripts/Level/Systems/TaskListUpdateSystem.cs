using Leopotam.Ecs;
using UnityEngine;
using System.Linq;

public class TaskListUpdateSystem : IEcsRunSystem
{
    private EcsFilter<HidenObject, Interaction> _foundHidenObjectFilter;
    private RuntimeData _runtimeData;
    private LevelData _levelData;
    private LevelUI _ui;

    public void Run()
    {
        foreach (var i in _foundHidenObjectFilter)
        {
            ref var foundObject = ref _foundHidenObjectFilter.Get1(i);

            var taskListItem = _runtimeData.taskListEntityByType[foundObject.itemIndex];

            ref var task = ref taskListItem.Get<LevelTaskEcs>();

            task.foundCount++;

            if (task.foundCount == task.totalCount)
            {
                task.taskPartView.Disable();
                _runtimeData.taskListEntityByType.Remove(foundObject.itemIndex);
            }
            else
            {
                task.taskPartView.UpdateCount(task.foundCount, task.totalCount);
            }

            if (_runtimeData.taskListEntityByType.Count == 0)
            {
                _runtimeData.CurrentState = GameState.Victory;
                PlayerPrefs.SetInt("OpenedLevels", _levelData.levelIndex + 1);
                _ui.gameScreen.Show(false);
                _ui.victoryScreen.Show();
            }
        }
    }
}

