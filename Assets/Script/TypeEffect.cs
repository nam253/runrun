using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using JetBrains.Annotations;

public class TypeEffect : MonoBehaviour
{

    private string currentTargetMsg; //현재 목표 대사(전체 문자열)
    Text msgText; //텍스트를 표시할 ui 컴포넌트

    public float typingSpeed = 1f; //글자가 나타나는 간격을 조절하는 변수

    private Coroutine typingCoroutine; //현재 진행 중인 타이핑 코루틴 이전에 시작된 타이핑 코루틴을 중지 시킬수 있다


    public void Awake()
    {
        msgText = GetComponent<Text>(); // text 컴포넌트를 찾아 할당
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SetMsg(string msg)
    {
        currentTargetMsg = msg; //전달받은 대사를 현재 목표 대사로 설정
        if (typingCoroutine != null) //이전 진행 중인 타이핑 코루틴이 있다면
        {
            StopCoroutine(typingCoroutine); //그 코루틴을 중지
        }
        typingCoroutine = StartCoroutine(TypeSentenceCoroutine(currentTargetMsg)); //새로운 타이핑 코루틴을 시작 및 참조 저장
    }

    // Update is called once per frame
    IEnumerator TypeSentenceCoroutine(string sentence)
    {
        msgText.text = ""; //현재 표시되는 텍스트를 초기화

        foreach (char letter in sentence.ToCharArray()) //전달 받은 문장을 글자 하나씩 순회
        {
            msgText.text += letter;//현재 텍스트에 한글자씩 추가
            yield return new WaitForSeconds(typingSpeed); //typingSpeed만큼 기다림
        }
    }

    public void CompleteTyping()
    {
        if (typingCoroutine != null) //현재 타이핑 코루틴이 진행 중이라면
        {
            StopCoroutine(typingCoroutine); //그 코루틴을 즉시 중지
            typingCoroutine = null; //코루틴 참조를 null로 초기화 
        }
        msgText.text = currentTargetMsg; //msgText에 전체 대사를 한 번에 표시
   

}


}
