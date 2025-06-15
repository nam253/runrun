using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using JetBrains.Annotations;

public class TypeEffect : MonoBehaviour
{

    private string currentTargetMsg; //���� ��ǥ ���(��ü ���ڿ�)
    Text msgText; //�ؽ�Ʈ�� ǥ���� ui ������Ʈ

    public float typingSpeed = 1f; //���ڰ� ��Ÿ���� ������ �����ϴ� ����

    private Coroutine typingCoroutine; //���� ���� ���� Ÿ���� �ڷ�ƾ ������ ���۵� Ÿ���� �ڷ�ƾ�� ���� ��ų�� �ִ�


    public void Awake()
    {
        msgText = GetComponent<Text>(); // text ������Ʈ�� ã�� �Ҵ�
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetMsg(string msg)
    {
        currentTargetMsg = msg; //���޹��� ��縦 ���� ��ǥ ���� ����
        if (typingCoroutine != null) //���� ���� ���� Ÿ���� �ڷ�ƾ�� �ִٸ�
        {
            StopCoroutine(typingCoroutine); //�� �ڷ�ƾ�� ����
        }
        typingCoroutine = StartCoroutine(TypeSentenceCoroutine(currentTargetMsg)); //���ο� Ÿ���� �ڷ�ƾ�� ���� �� ���� ����
    }

    // Update is called once per frame
    IEnumerator TypeSentenceCoroutine(string sentence)
    {
        msgText.text = ""; //���� ǥ�õǴ� �ؽ�Ʈ�� �ʱ�ȭ

        foreach (char letter in sentence.ToCharArray()) //���� ���� ������ ���� �ϳ��� ��ȸ
        {
            msgText.text += letter;//���� �ؽ�Ʈ�� �ѱ��ھ� �߰�
            yield return new WaitForSeconds(typingSpeed); //typingSpeed��ŭ ��ٸ�
        }
    }

    public void CompleteTyping()
    {
        if (typingCoroutine != null) //���� Ÿ���� �ڷ�ƾ�� ���� ���̶��
        {
            StopCoroutine(typingCoroutine); //�� �ڷ�ƾ�� ��� ����
            typingCoroutine = null; //�ڷ�ƾ ������ null�� �ʱ�ȭ 
        }
        msgText.text = currentTargetMsg; //msgText�� ��ü ��縦 �� ���� ǥ��
   

}


}
