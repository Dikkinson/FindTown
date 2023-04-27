using Leopotam.Ecs;

public class StartGameSystem : IEcsRunSystem
{
    private EcsFilter<StartGame> _filter;

    private LevelUI _levelUI;
    private RuntimeData _runtimeData;

    public void Run()
    {
        foreach (var i in _filter) 
        { 
            _filter.GetEntity(i).Del<StartGame>();

            _levelUI.dialogueScreen.Show(false);

            _runtimeData.CurrentState = GameState.Game;
        }
    }
}

