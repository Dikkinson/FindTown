﻿using Leopotam.Ecs;
using UnityEngine;
public class TaskListInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private LevelData _sceneData;
    private LevelUI _ui;
    private RuntimeData _runtimeData;

    public void Init()
    {
        foreach (var levelTask in _sceneData.levelTasks)
        {
            EcsEntity levelTaskEntity = _ecsWorld.NewEntity();

            var taskListItem = Object.Instantiate(_ui.gameScreen.TaskViewPrefab, _ui.gameScreen.TaskListParent);
            taskListItem.SetUpView(_sceneData.levelTaskType, levelTask);
            ref var levelTaskEcs = ref levelTaskEntity.Get<LevelTaskEcs>();
            levelTaskEcs.foundCount = 0;
            levelTaskEcs.totalCount = levelTask.taskObjects.Count;
            levelTaskEcs.itemIndex = levelTask.itemIndex;
            _runtimeData.taskListEntityByType.Add(levelTask.itemIndex, levelTaskEntity);
            levelTaskEcs.taskPartView = taskListItem;
        }
    }
}

