using System.Data;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    //public TextMeshProUGUI scoreText;
    public TextMeshProUGUI TiemText;

    public TextMeshProUGUI BestTiemText;
    public GameObject gameoverUI;
    public AudioSource backgroundMusic;

    //private int score = 0;
    private float currenttime = 0;

    private float besttimeRecore = 0;

    private const string Best_Time_Key = "BestTIme";
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
        besttimeRecore = PlayerPrefs.GetFloat(Best_Time_Key, 0f);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (isGameover && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }*/
        if (!isGameover)
        {
            currenttime += Time.deltaTime;
            TiemText.text = "Time " + SetTime(currenttime);
        }


    }

    /*public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
            
        }

    }*/

    string SetTime(float t)
    {
        int minutes = (int)(t / 60);
        int seconds = (int)(t % 60);
        return string.Format("{0:00} : {1:00}", minutes, seconds);


    }

    public void OnPlayerDead()
    {
        isGameover = true;
        gameoverUI.SetActive(true);
        backgroundMusic.enabled = false;
        BestTime();

    }

    public void BestTime()
    {
        if (currenttime > besttimeRecore)
        {
            besttimeRecore = currenttime;
            PlayerPrefs.SetFloat(Best_Time_Key, besttimeRecore);
            PlayerPrefs.Save();
        }
        UpdateBestTimeUi();

    }
    void UpdateBestTimeUi()
    {
        if (BestTiemText != null)
        {
            BestTiemText.text = "최고기록 : " + SetTime(besttimeRecore);
        }
    }
    public void Restartbuttone()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
