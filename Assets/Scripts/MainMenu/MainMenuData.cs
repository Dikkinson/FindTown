using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;
using Spine;

public class MainMenuData : MonoBehaviour
{
    public Camera mainMenuCamera;
    public List<LevelButtonView> levelButtons;

    public string phoneCallAnimationName;
    public SkeletonGraphic phoneGraphic;
}
