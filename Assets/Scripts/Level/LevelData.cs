using System.Collections.Generic;
using UnityEngine;

public enum TaskType { Counter, Picture, Word}
public enum HidenObjectType { Cat, Backpack, Diary, Headphones, Doll, Player, Glasses }

public class LevelData : MonoBehaviour
{
    public Transform sceneCameraTransform;
    public float minCameraZoom;
    public BoxCollider backgroundCollider;
    public DialogueScriptableObject startDialogue;
    public TaskType levelTaskType;
    public List<LevelTask> levelTasks;
    public TimerType timerType;
    public int levelTime;
}

