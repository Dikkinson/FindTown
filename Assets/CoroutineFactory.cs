using System.Collections;
using UnityEngine;

public class CoroutineFactory : MonoBehaviour
{
    private static CoroutineFactory Instance
    {
        get
        {
            if(_instance == null)
            {
                var go = new GameObject("[COROUTINE]");
                _instance = go.AddComponent<CoroutineFactory>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    private static CoroutineFactory _instance;

    public static Coroutine StartRoutine(IEnumerator routine)
    {
        return Instance.StartCoroutine(routine);
    }

    public void StopCoroutine()
    {
        Instance.StopCoroutine();
    }
}
