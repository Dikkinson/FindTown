using UnityEngine;
using Spine.Unity;

public abstract class Window : MonoBehaviour
{
    public SkeletonGraphic background;
    [HideInInspector] public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartOpenAnim()
    {
        background.AnimationState.SetAnimation(0, "open_window", false);
    }
    public virtual void SetIdleAnim()
    {
        background.AnimationState.SetAnimation(0, "idle_window", false);
    }

    public void SetCloseAnim()
    {
        background.AnimationState.SetAnimation(0, "close_window", false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show(bool state = true)
    {
        gameObject.SetActive(state);
    }
}
