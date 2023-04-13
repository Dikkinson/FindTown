using Leopotam.Ecs;
using UnityEngine;
using System.Linq;

public class TaskListUpdateSystem : IEcsRunSystem
{
    private EcsFilter<HidenObject, Interaction> _foundHidenObjectFilter;
    private RuntimeData _runtimeData;
    private UI _ui;

    public void Run()
    {
        foreach (var i in _foundHidenObjectFilter)
        {
            ref var foundObject = ref _foundHidenObjectFilter.Get1(i);

            var taskListItem = _runtimeData.taskListEntityByType[foundObject.type];

            ref var task = ref taskListItem.Get<LevelTaskEcs>();

            task.foundCount++;

            if (task.foundCount == task.totalCount)
            {
                task.taskPartView.Disable();
                _runtimeData.taskListEntityByType.Remove(foundObject.type);
            }
            else
            {
                task.taskPartView.UpdateCount(task.foundCount, task.totalCount);
            }

            if (_runtimeData.taskListEntityByType.Count == 0)
            {
                _runtimeData.CurrentState = GameState.Victory;

                _ui.gameScreen.Show(false);
                _ui.victoryScreen.Show();
            }
        }
    }
}

