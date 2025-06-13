using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StopButton : MonoBehaviour
{
    public GameObject pasuePannel;

    public void Menu_Btn()
    {
        Time.timeScale = 0f;

        pasuePannel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pasuePannel.SetActive(false);
    }

    public void GameEnd()
    {
        Application.Quit();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
