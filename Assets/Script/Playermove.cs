using TMPro;
using UnityEngine;
using UnityEngine.UI; // 텍스트를 사용하기 위해 

public class Playermove : MonoBehaviour
{
    public float speed = 5f;
    public Transform targetStopPoint;
    public Animator playerAnimator;

    public GameObject scanObject;

    private bool hasReachedTarget = false;

    public AudioSource walkAudioSource;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerAnimator != null)//animator가 null이 아니라면
        {
            playerAnimator.SetBool("isWalking", true); //걷는 애니메이션을 해라
            if(walkAudioSource != null && !walkAudioSource.isPlaying)
            {
                walkAudioSource.loop = true;
                walkAudioSource.Play();
            }
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (!hasReachedTarget && targetStopPoint != null)//!hasReachedTarget는 false가 맞고 즉 hasReachedTarget 상태가 아니고  targetstoppoint가 null이아니라면
        {
            float xDistanceToTarget = Mathf.Abs(transform.position.x - targetStopPoint.position.x); //Mathf.abs는 절댓값을 반화한는 함수


            if (xDistanceToTarget <= 0.1f) //거리가 가까워지면
            {
                StopMovementAndIdel();

            }
            else
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (playerAnimator != null && playerAnimator.GetBool("isWalking") && walkAudioSource != null && !walkAudioSource.isPlaying)
                {
                    walkAudioSource.loop = true;
                    walkAudioSource.Play();
                }

            }
        
        }


    }

    

    void StopMovementAndIdel()
    {
        hasReachedTarget = true;

        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isWalking", false);
            if (walkAudioSource != null && walkAudioSource.isPlaying)
            {
                walkAudioSource.Stop();
            }

        }

        if (scanObject != null) // 캐릭터가 멈추면 talkmanager를 통해 대화를 시작
        {
            objData objData = scanObject.GetComponent<objData>(); //objData 타입이름 objData 변수이름
            if (objData != null && TalkManager.Instance != null) //objectData의 id를 talkmanager에 전달하여 대화를 시작
            {
                TalkManager.Instance.StartTalk(objData.id); //인스턴스화된 TalkManage에 rStartTalk함수로 가서 변수 objData의 값을 id를 전달
            }
        }

    }

    
}
