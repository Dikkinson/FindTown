using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonView : MonoBehaviour
{
    public string levelName;

    [Multiline]
    public string levelDescription;

    public GameObject marker;
    public SkeletonDataAsset previewCharacter;
    public string previewCharacterName;
    public int levelNumber;
}
