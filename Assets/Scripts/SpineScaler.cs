using Leopotam.Ecs;
using UnityEngine;
using Spine.Unity;

public class SpineScaler : MonoBehaviour
{
    const float REFERENCE_WIDTH = 2532f;

    private void Start()
    {
        Vector3 referenceScale = GetComponent<RectTransform>().localScale;
        float scale = REFERENCE_WIDTH / (float)Camera.main.pixelWidth;
        Debug.Log(Camera.main.pixelWidth);
        Debug.Log(scale);
        GetComponent<RectTransform>().localScale = referenceScale * scale;
    }
}

