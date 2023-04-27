using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public struct LevelButton
{
    public Button buttonComponent;
    public bool isOpen;
    public string levelName;
    public GameObject marker;
    public SkeletonDataAsset previewCharacter;
    public int levelNumber;
}
