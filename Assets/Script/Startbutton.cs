using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Startbutton : MonoBehaviour
{
    public GameObject gb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartGame()
    {
        SceneManager.LoadScene("intro");
        gb = GameObject.Find("touchtext");

    }

    void OnDestroy()
    {
        DOTween.Kill(gb);
        
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
