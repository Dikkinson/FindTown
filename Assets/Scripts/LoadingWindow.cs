using Spine.Unity;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingWindow : Window
{
    public Transform transitionWindowTransform;

    private SkeletonGraphic _transitionWindowGraphic;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _transitionWindowGraphic = transitionWindowTransform.GetComponent<SkeletonGraphic>();
    }

    public void LoadLevel(int levelIndex)
    {
        StartCoroutine(LoadLevelAsync(levelIndex));
    }

    private IEnumerator LoadLevelAsync(int levelIndex) 
    {
        _transitionWindowGraphic.gameObject.SetActive(true);
        _transitionWindowGraphic.AnimationState.SetAnimation(0, "trans_open", false);
        SceneManager.LoadSceneAsync(levelIndex);
        _transitionWindowGraphic.AnimationState.AddAnimation(0, "trans_idle", true, 0);
        _transitionWindowGraphic.AnimationState.AddAnimation(0, "trans_close", false, 2f);
        yield return new WaitForSeconds(4f);
        _transitionWindowGraphic.gameObject.SetActive(false);
    }
}
