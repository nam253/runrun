using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Playermove : MonoBehaviour
{
    public float speed = 5f;
    public Transform targetStopPoint;
    public Animator playerAnimator;

    public GameObject canvas;

    public TalkManager talkManager;

    public GameObject scanObject;

    private bool hasReachedTarget = false;

    public Text talkText;


    public int talkIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isWalking", true);
        }

        canvas.SetActive(false);

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

        if (canvas != null)
        {
            objData objData = scanObject.GetComponent<objData>();
            Talk(objData.id);
            canvas.SetActive(true);
        }

    }

    void Talk(int id)
    {
        string taklData = talkManager.GetTalk(id, talkIndex);

        if (taklData == null)
        {
            return;
        }
        talkText.text = taklData;
        talkIndex++;
        
    }
}
