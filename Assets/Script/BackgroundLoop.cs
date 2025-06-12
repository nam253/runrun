using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    float width;

    void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -5*width)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector2 offset = new Vector2(5*width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
