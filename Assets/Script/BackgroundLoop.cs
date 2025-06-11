using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    float with;

    void Awake()
    {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        with = backgroundCollider.size.x;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -with)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector2 offset = new Vector2(with * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
