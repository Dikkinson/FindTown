using UnityEngine;

public abstract class Window : MonoBehaviour
{
    public virtual void Show(bool state = true)
    {
        gameObject.SetActive(state);
    }
}
