using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

public class TaskPartView : MonoBehaviour
{
    public EcsEntity taskPartEnity;

    [SerializeField] private Text taskText;
    [SerializeField] private Image taskImage;

    public void SetUpView(TaskType type, LevelTask task)
    {
        HideAll();
        switch (type) 
        {
            case TaskType.Counter:
                taskText.gameObject.SetActive(true);
                SetText(task.Name);
                SetCount(0, task.taskObjects.Count);
            break;
            case TaskType.Word:
                taskText.gameObject.SetActive(true);
                SetText(task.Name);
                break;
            case TaskType.Picture:
                taskImage.gameObject.SetActive(true);
                SetImage(task.taskObjects[0].GetComponent<SpriteRenderer>().sprite);
            break;
        }
    }

    public void SetImage(Sprite objectsprite)
    {
        taskImage.sprite = objectsprite;
    }

    public void SetText(string title)
    {
        taskText.text = title;
    }

    public void SetCount(int currentCount, int totalCount)
    {
        taskText.text += "\n" + currentCount.ToString() + "/" + totalCount.ToString();
    }

    public void UpdateCount(int currentCount, int totalCount)
    {
        taskText.text = taskText.text.Remove(taskText.text.IndexOf('\n'));
        SetCount(currentCount, totalCount);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    private void HideAll()
    {
        taskText.gameObject.SetActive(false);
        taskImage.gameObject.SetActive(false);
    }
}
