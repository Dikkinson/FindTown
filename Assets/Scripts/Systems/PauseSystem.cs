﻿using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

public class PauseSystem : IEcsRunSystem
{
    private EcsFilter<PauseEvent> _filter;
    private RuntimeData _runtimeData;
    private UI _ui;

    public void Run()
    {
        foreach (var i in _filter)
        {
            _filter.GetEntity(i).Del<PauseEvent>();
            if (_runtimeData.CurrentState != GameState.Pause)
            {
                _runtimeData.CurrentState = GameState.Pause;
                _ui.pauseScreen.Show(true);
            }
            else
            {
                _ui.pauseScreen.Show(false);
                _runtimeData.CurrentState = _runtimeData.PreviousState;
            }
            
        }
    }
}
