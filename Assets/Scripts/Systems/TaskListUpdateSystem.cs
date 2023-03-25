using Leopotam.Ecs;
using UnityEngine;
using System.Linq;

public class TaskListUpdateSystem : IEcsRunSystem
{
    private EcsFilter<HidenObject, Found> _foundHidenObjectFilter;
    private RuntimeData _runtimeData;

    public void Run()
    {
        if (_runtimeData.currentState != GameState.Game) return;

        foreach (var i in _foundHidenObjectFilter)
        {
            ref var foundObject = ref _foundHidenObjectFilter.Get1(i);

            var taskListItem = _runtimeData.taskListEntityByType[foundObject.type];

            ref var task = ref taskListItem.Get<LevelTaskEcs>();

            task.foundCount++;

            if (task.foundCount == task.totalCount)
            {
                task.taskPartView.Disable();
            }else
            {
                task.taskPartView.UpdateCount(task.foundCount, task.totalCount);
            }
            
        }
    }
}

