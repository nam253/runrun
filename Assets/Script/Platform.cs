using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject[] obstacles;
    private bool stepped = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnEnable()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 2) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && !stepped)
        {
            stepped = true;
            GameManager.instance.AddScore(100);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
