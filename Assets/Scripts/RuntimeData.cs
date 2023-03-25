using Leopotam.Ecs;
using System.Collections.Generic;

public enum GameState { Dialogue, Game, Victory }

public class RuntimeData
{
    public GameState currentState;
    public EcsEntity backgroundEntity;
    public EcsEntity dialogueEntity;
    public Dictionary<HidenObjectType, EcsEntity> taskListEntityByType = new Dictionary<HidenObjectType, EcsEntity>();
}

