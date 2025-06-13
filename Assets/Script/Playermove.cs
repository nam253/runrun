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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isWalking", true);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!hasReachedTarget && targetStopPoint != null)
        {
            float xDistanceToTarget = Mathf.Abs(transform.position.x - targetStopPoint.position.x);


            if (xDistanceToTarget <= 0.1f)
            {
                StopMovementAndIdel();

            }
            else
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);

            }
        
        }


    }

    

    void StopMovementAndIdel()
    {
        hasReachedTarget = true;

        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isWalking", false);
            
        }

        if (scanObject != null) // 캐릭터가 멈추면 talkmanager를 통해 대화를 시작
        {
            objData objData = scanObject.GetComponent<objData>();
            if (objData != null && TalkManager.Instance != null) //objectData의 id를 talkmanager에 전달하여 대화를 시작
            {
                TalkManager.Instance.StartTalk(objData.id);
            }
        }

    }

    
}
