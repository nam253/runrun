using System.Runtime.InteropServices;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public int count = 4;

    public float timeBestSpawnMin = 1.25f;
    public float timeBestSpawnMax = 2.25f;
    private float timeBestSpawn;

    public float yMin = -5.7f;
    public float yMax = 1f;
    private float xPos = 25f;

    private GameObject[] platforms;
    private int currentIndex = 0;

    private Vector2 poolPosition = new Vector2(0, -25);
    private float lastSpawnTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        platforms = new GameObject[count];

        for (int i = 0; i < count; i++)
        {
            platforms[i] = Instantiate(platformPrefab, poolPosition, Quaternion.identity);

            lastSpawnTime = 0f;

            timeBestSpawn = 0f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }

        if (Time.time >= lastSpawnTime + timeBestSpawn)
        {
            lastSpawnTime = Time.time;

            timeBestSpawn = Random.Range(timeBestSpawnMin, timeBestSpawnMax);

            float yPos = Random.Range(yMin, yMax);

            platforms[currentIndex].SetActive(false);
            platforms[currentIndex].SetActive(true);

            platforms[currentIndex].transform.position = new Vector2(xPos, yPos);

            currentIndex++;

            if (currentIndex >= count)
            {
                currentIndex = 0;
            }
        }
        
    }
}
