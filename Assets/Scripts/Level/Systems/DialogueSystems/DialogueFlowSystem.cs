using DG.Tweening;
using Leopotam.Ecs;
using System.Collections;
using UnityEngine;

public class DialogueFlowSystem : IEcsRunSystem
{
    private EcsFilter<Dialogue, DialogueStart> _dialogueFilter;
    private EcsFilter<DialogueWaitForPlayer> _dialogueWaitForPlayerFilter;
    private EcsFilter<PlayerInputData> _playerInputDataFilter;

    private LevelData _sceneData;
    private RuntimeData _runtimeData;
    private LevelUI _ui;

    private EcsWorld _ecsWorld;

    public void Run()
    {
        if (_runtimeData.CurrentState != GameState.Dialogue) return;

        ref var dialogue = ref _runtimeData.dialogueEntity.Get<Dialogue>();
        ref var camera = ref _runtimeData.cameraEntity.Get<CameraEcs>();

        foreach (var i in _dialogueFilter)
        {
            DialogueLine line = _sceneData.startDialogue.dialogueLines[dialogue.currentLineIndex];

            camera.cameraTransform.position = line.cameraPosition;

            _ui.dialogueScreen.blurMaterial.color = line.BackgroundBlurColor;
            _ui.dialogueScreen.leftDialogueCharacter.AnimationState.SetAnimation(0, line.LeftCharacterAnimName, true);
            _ui.dialogueScreen.rightDialogueCharacter.AnimationState.SetAnimation(0, line.RightCharacterAnimName, true);

            _ui.dialogueScreen.dialogueText.text = $"{line.characterName}: {line.dialogueText}";

            _runtimeData.dialogueEntity.Del<DialogueStart>();
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
                        _runtimeData.dialogueEntity.Get<DialogueStart>();
                    }
                    else
                    {
                        _ecsWorld.NewEntity().Get<StartGame>();
                    }
                }
            }
        }
    }
}