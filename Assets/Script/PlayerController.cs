using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip;
    public float jumpForce = 700f;

    private int jumpCount = 0;
    private bool isGrounded = false;
    private bool isDead = false;

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private AudioSource playerAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
     void Update()
    {
        if (isDead)
        {
            return;
        }

        if (Input.GetButtonDown("Jump"))
        {
            TryJump();
        }
        else if (Input.GetButtonUp("Jump") && playerRigidbody.linearVelocity.y > 0)
        {
            playerRigidbody.linearVelocity = playerRigidbody.linearVelocity * 0.5f;
        }

        animator.SetBool("Grounded", isGrounded);

    }

    public void JumpButtonOnclick()
    {
        if (isDead)
        {
            return;
        }
        TryJump();

    }

    void TryJump()
    {
        if (jumpCount < 2)
        {
            jumpCount++;
            playerRigidbody.linearVelocity = Vector2.zero;
            playerRigidbody.AddForce(new Vector2(0, jumpForce));

            if (playerAudio != null)
            {
                playerAudio.Play();
            }
        }
    }


    void Die()
    {
        animator.SetTrigger("Die");

        playerAudio.clip = deathClip;

        playerAudio.Play();

        playerRigidbody.linearVelocity = Vector2.zero;

        isDead = true;

        GameManager.instance.OnPlayerDead();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dead" && !isDead)
        {
            Die();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;
            jumpCount = 0;
        }

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        
    }
}
