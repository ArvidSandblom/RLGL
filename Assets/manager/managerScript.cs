using UnityEngine;
using System.Collections;


public class managerScript : MonoBehaviour
{
    public GameObject light;
    //Color lightColour = new Green; 
    public GameObject LightSource;
    public bool finish;
    private GameObject player;
    public GameObject winScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (LightSource.GetComponent<playerScript>().isSeen == false && LightSource != null)
        {
            light.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }                    
        if (LightSource.GetComponent<playerScript>().isSeen == true && LightSource != null)
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
}
