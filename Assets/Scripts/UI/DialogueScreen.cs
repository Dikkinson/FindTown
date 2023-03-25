using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScreen : Screen
{
    public TextWriter dialogueTextWriter;
    public SkeletonGraphic leftDialogueCharacter;
    public SkeletonGraphic rightDialogueCharacter;
    public Material blurMaterial;
}