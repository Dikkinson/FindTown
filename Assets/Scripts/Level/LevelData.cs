using System.Collections.Generic;
using UnityEngine;

public enum TaskType { Counter, Picture, Word}

public class LevelData : MonoBehaviour
{
    public int levelIndex;
    public Transform sceneCameraTransform;
    public float minCameraZoom;
    public BoxCollider2D backgroundCollider;
    public DialogueScriptableObject startDialogue;
    public TaskType levelTaskType;
    public List<LevelTask> levelTasks;
    public List<HidenSpotView> hideSpotsList;
    public TimerType timerType;
    public int levelTime;
    public List<LevelRewardData> levelRewardData;
}

