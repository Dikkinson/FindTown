using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    private Text text;

    private bool _isDone = true;
    public bool IsDone => _isDone;

    private void OnEnable()
    {
        text = GetComponent<Text>();
    }

    public void WriteText(string startText, string textToWrite, float timeBetweenChars)
    {
        StopWriting();
        StartCoroutine(WriteTextCo(startText, textToWrite, timeBetweenChars));
    }

    public void WriteText(string startText, string textToWrite)
    {
        StopWriting();
        text.text = startText + textToWrite;
    }

    public void StopWriting()
    {
        StopAllCoroutines();
        _isDone = true;
    }

    private IEnumerator WriteTextCo(string startText, string textToWrite, float timeBetweenChars)
    {
        _isDone = false;
        text.text = string.Empty;
        text.text = startText;

        for (int i = 0; i < textToWrite.Length; i++)
        {
            text.text += textToWrite[i];
            yield return new WaitForSeconds(timeBetweenChars);
        }
        _isDone = true;
    }
}
