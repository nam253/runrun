using System.Collections.Generic; //코루틴을 위해 추
using System.Collections;
using UnityEngine.UI;//텍스트를 사용하기 위해 추
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public static TalkManager Instance { get; private set; }//다른 스크립트에서 접근하기 위해 싱글톤 사ㅇ
    Dictionary<int, string[]> talkData; //대화 데이터 저장

    //public Text dialogueTextUI; // 인스펙터에서 연결할 ui txt컴포넌트

    public TypeEffect typeEffect;

    public GameObject dialoguePanelUI; // 인스펙터에서 연결할 대화창 ui

    private int currentTalkId; //현재 진행 중인 대화의 id
    private int currentTalkIndex; //현재 진행 중인 대화의 인덱스 
    private bool isDialogueActive = false; //현재 대화가 진행중인지 판단
    private bool isTypingEffectPlaying = false;

    
    public GameObject startbutton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        talkData = new Dictionary<int, string[]>();
        GenerateData(); //대화 데이터를 초기화 

        if (dialoguePanelUI != null)
        {
            dialoguePanelUI.SetActive(false); //시작시 대화창 비활성화 
        }

        if (startbutton != null)
        {
            startbutton.SetActive(false);
        }

        if (typeEffect == null)
        {
            typeEffect = dialoguePanelUI.GetComponentInChildren<TypeEffect>();
        }
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕? 여우야", "그거 알아?", "이 숲에 슬라임들의 숫자가 엄청 늘어났어", "숲을 돌아다닐 땐 조심해" });
        //대화 데이터 추가
    }

    public void StartTalk(int id) //외부에서 대화를 시작할때 호출될 함수
    {
        currentTalkId = id;
        currentTalkIndex = 0; // 대화 시작시 첫 번째 문장부터

        if (dialoguePanelUI != null)
        {
            dialoguePanelUI.SetActive(true); // 대화창 활성화 
        }
        isDialogueActive = true; // 대화 시작

        DisplayNextTalk(); // 첫 대사 표시
    }

    void DisplayNextTalk()
    {
        if (isTypingEffectPlaying)
        {
            if (typeEffect != null)
            {
                typeEffect.CompleteTyping();
            }
            isTypingEffectPlaying = false;
            return;
        }

        if (currentTalkIndex >= talkData[currentTalkId].Length)
        {
            EndTalk();
            return;
        }

        string nextSentence = talkData[currentTalkId][currentTalkIndex];

        if (typeEffect != null)
        {
            typeEffect.SetMsg(nextSentence);
            isTypingEffectPlaying = true;
        }

        currentTalkIndex++;

            
        
    }
    void EndTalk() // 대화 종료 함수
    {
        isDialogueActive = false; // 대화 종료
        isTypingEffectPlaying = false;

        if (startbutton != null)
        {
            startbutton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialogueActive)// 대화가 활성화된 상태일 때만 입력을 확인
        {
            if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))// 마우스 왼쪽 클릭 또는 화면 터치 (첫 번째 터치) 감지
            {
                DisplayNextTalk(); // 다음 대사를 표시 하거나 대화를 종료
            }
        }
    }
}
