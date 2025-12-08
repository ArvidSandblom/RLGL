using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class managerScript : MonoBehaviour
{
    private GameObject light;
    //Color lightColour = new Green;     
    public bool finish;
    private GameObject player;
    private GameObject winScreen;
    public int levelIndex;
    public int playerMode; //1 = singleplayer, 2 = multiplayer, 3 = player vs ai

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        winScreen = GameObject.Find("WinScreen");
        player = GameObject.FindGameObjectWithTag("Player");
        light = GameObject.Find("LightWarning");
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && player.GetComponent<playerScript>().isSeen == false)
        {
            light.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }                    
        if (player != null && player.GetComponent<playerScript>().isSeen == true)
        {
            light.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }

        if (finish)
        {
            winLevel();
        }
    }
    public void onClickNextLevel()
    {
        winScreen.SetActive(false);
    }
    void winLevel()
    {
        winScreen.SetActive(true);
    }
    public void singleplayer()
    {        
        SceneManager.LoadScene(2);
    }
    public void multiplayer()
    {
        SceneManager.LoadScene(3);
    }
    public void playerVSAI()
    {
        SceneManager.LoadScene(3);        
    }
}
