using Leopotam.Ecs;

public class DialogueEndSystem : IEcsRunSystem
{
    private EcsFilter<DialogueEnd> _filter;
    private RuntimeData _runtimeData;
    private UI ui;

    public void Run()
    {
        foreach (var i in _filter) 
        {
            _runtimeData.currentState = GameState.Game;

            ui.dialogueScreen.Show(false);
            ui.gameScreen.Show();
        }
    }
}

