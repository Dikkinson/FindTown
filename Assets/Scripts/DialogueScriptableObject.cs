using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Animations { idle, dialogue, shadow }

[System.Serializable]
public class DialogueLine
{
    [SerializeField] private Animations leftCharacterAnim;
    public string LeftCharacterAnimName => leftCharacterAnim.ToString();

    [SerializeField] private Animations rightCharacterAnim;
    public string RightCharacterAnimName => rightCharacterAnim.ToString();

    [SerializeField] private Animations leftCharacterDialogueIdleAnim;
    public string LeftCharacterDialogueIdleAnim => leftCharacterDialogueIdleAnim.ToString();

    [SerializeField] private Animations rightCharacterDialogueIdleAnim;
    public string RightCharacterDialogueIdleAnim => rightCharacterDialogueIdleAnim.ToString();

    public Color BackgroundBlurColor;
    public string characterName;
    public Vector3 cameraPosition;
    [Multiline]
    public string dialogueText;
}

[CreateAssetMenu(fileName = "Dialogue", menuName = "FindTown/Dialogue", order = 1)]
public class DialogueScriptableObject : ScriptableObject
{
    public List<DialogueLine> dialogueLines;
}
