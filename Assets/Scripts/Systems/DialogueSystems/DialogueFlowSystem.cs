using Leopotam.Ecs;
using UnityEngine;

public class DialogueFlowSystem : IEcsRunSystem
{
    private EcsFilter<DialogueStart> _dialogueStartFilter;
    private EcsFilter<DialogueLineStart> _dialogueLineStartFilter;
    private EcsFilter<DialogueWriteStart> _dialogueWriteStartFilter;
    private EcsFilter<DialogueLineEnd> _dialogueWriterDoneFilter;
    private EcsFilter<DialogueWaitForPlayer> _dialogueWaitForPlayerFilter;
    private EcsFilter<PlayerInputData> _playerInputDataFilter;
    private SceneData _sceneData;
    private StaticData _staticData;
    private RuntimeData _runtimeData;
    private UI ui;

    public void Run()
    {
        if (_runtimeData.currentState != GameState.Dialogue) return;

        ref var dialogue = ref _runtimeData.dialogueEntity.Get<Dialogue>();
        DialogueLine line = _sceneData.startDialogue.dialogueLines[dialogue.currentLineIndex];

        foreach (var i in _dialogueStartFilter)
        {
            ref var entity = ref _dialogueStartFilter.GetEntity(i);

            entity.Del<DialogueStart>();

            _runtimeData.dialogueEntity.Get<DialogueLineStart>();
        }

        foreach (var i in _dialogueLineStartFilter)
        {
            _runtimeData.dialogueEntity.Del<DialogueLineStart>();

            ui.dialogueScreen.blurMaterial.color = line.BackgroundBlurColor;
            ui.dialogueScreen.leftDialogueCharacter.AnimationState.SetAnimation(0, line.LeftCharacterAnimName, true);
            ui.dialogueScreen.rightDialogueCharacter.AnimationState.SetAnimation(0, line.RightCharacterAnimName, true);

            ui.dialogueScreen.dialogueTextWriter.WriteText($"{line.characterName}: ", line.dialogueText, _staticData.timeBetweenCharsDialogue);

            _runtimeData.dialogueEntity.Get<DialogueWriteStart>();
        }

        foreach (var i in _dialogueWriteStartFilter)
        {
            if (ui.dialogueScreen.dialogueTextWriter.IsDone)
            {
                _runtimeData.dialogueEntity.Del<DialogueWriteStart>();
                _runtimeData.dialogueEntity.Get<DialogueLineEnd>();
            }
        }

        foreach (var i in _dialogueWriterDoneFilter)
        {
            ui.dialogueScreen.dialogueTextWriter.WriteText($"{line.characterName}: ", line.dialogueText);

            ui.dialogueScreen.leftDialogueCharacter.AnimationState.SetAnimation(0, line.LeftCharacterDialogueIdleAnim, true);
            ui.dialogueScreen.rightDialogueCharacter.AnimationState.SetAnimation(0, line.RightCharacterDialogueIdleAnim, true);
            _runtimeData.dialogueEntity.Del<DialogueLineEnd>();
            _runtimeData.dialogueEntity.Get<DialogueWaitForPlayer>();
        }

        foreach (var i in _playerInputDataFilter)
        {
            ref var playerInput = ref _playerInputDataFilter.Get1(i);

            if (playerInput.pointerDownOnce)
            {
                if (_dialogueWaitForPlayerFilter.GetEntitiesCount() > 0)
                {
                    if (dialogue.currentLineIndex < dialogue.lastLineIndex - 1)
                    {
                        dialogue.currentLineIndex++;
                        _runtimeData.dialogueEntity.Del<DialogueWaitForPlayer>();
                        _runtimeData.dialogueEntity.Get<DialogueLineStart>();
                    }
                    else
                    {
                        _runtimeData.dialogueEntity.Get<DialogueEnd>();
                        break;
                    }
                }
                else
                {
                    _runtimeData.dialogueEntity.Del<DialogueWriteStart>();
                    _runtimeData.dialogueEntity.Get<DialogueLineEnd>();
                }
            }
        }
    }
}