using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelTask
{
    public string Name;
    public Sprite hintSprite;
    public HidenObjectType type;
    public List<HidenObjectView> taskObjects;
}

