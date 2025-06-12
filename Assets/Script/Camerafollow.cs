using UnityEngine;

public class Camerafollow : MonoBehaviour
{

    Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + new Vector3(5, 2.5f, -15);
    }
}
