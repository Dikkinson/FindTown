using Leopotam.Ecs;

public class DialogueInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private SceneData _sceneData;
    private RuntimeData _runtimeData;

    public void Init()
    {
        EcsEntity dialogueEntity = _ecsWorld.NewEntity();

        ref var dialogue = ref dialogueEntity.Get<Dialogue>();

        dialogue.currentLineIndex = 0;
        dialogue.lastLineIndex = _sceneData.startDialogue.dialogueLines.Count;

        _runtimeData.dialogueEntity = dialogueEntity;

        dialogueEntity.Get<DialogueStart>();
        _runtimeData.CurrentState = GameState.Dialogue;
    }
}

