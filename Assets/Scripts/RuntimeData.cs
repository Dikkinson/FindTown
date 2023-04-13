using Leopotam.Ecs;
using System.Collections.Generic;

public enum GameState { Dialogue, Game, Victory, Lose, Pause }

public class RuntimeData
{
    public GameState CurrentState 
    { 
        get 
        {
            return _currentState;
        } 
        set 
        {
            _previousState = _currentState;
            _currentState = value;
        } 
    }
    public GameState PreviousState => _previousState;

    private GameState _currentState;
    private GameState _previousState;

    public EcsEntity backgroundEntity;
    public EcsEntity dialogueEntity;
    public EcsEntity cameraEntity;

    public Dictionary<HidenObjectType, EcsEntity> taskListEntityByType = new Dictionary<HidenObjectType, EcsEntity>();
}

