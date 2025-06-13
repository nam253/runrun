using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using JetBrains.Annotations;

public class TypeEffect : MonoBehaviour
{

    private string currentTargetMsg;
    Text msgText;

    public float typingSpeed = 1f;

    private Coroutine typingCoroutine;


    public void Awake()
    {
        msgText = GetComponent<Text>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetMsg(string msg)
    {
        currentTargetMsg = msg;
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeSentenceCoroutine(currentTargetMsg));
    }

    // Update is called once per frame
    IEnumerator TypeSentenceCoroutine(string sentence)
    {
        msgText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            msgText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void CompleteTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
            typingCoroutine = null;
        }
        msgText.text = currentTargetMsg;

    }


}
