using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class playerManagment : MonoBehaviour
{
    public Color[] playerColours = {Color.green, Color.blue, Color.red, Color.yellow, Color.magenta, Color.cyan, Color.white, Color.black, Color.gray};
    public int player1ColourIndex;
    GameObject player1;
    public bool player2Active;
    GameObject player2;
    public int player2ColourIndex;
    GameObject player2ButtonAdd;
    GameObject player2ButtonRemove;
    GameObject player3;
    public int player3ColourIndex;
    public bool player3Active;
    GameObject player3ButtonAdd;
    GameObject player3ButtonRemove;
    GameObject player4; 
    public int player4ColourIndex;
    public bool player4Active;
    GameObject player4ButtonAdd;
    GameObject player4ButtonRemove;
    GameObject[] minusButton = new GameObject[4];
    GameObject[] plusButton = new GameObject[4];

    GameObject manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created    
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("Manager");

        for (int i = 0; i < minusButton.Length; i++)
        {
            minusButton[i] = transform.GetChild(2).gameObject;
            //minusButton[i] = GameObject.Find("p" + (i + 1) + "-");
        }
        for (int i = 0; i < plusButton.Length; i++)
        {
            plusButton[i] = transform.GetChild(1).gameObject;
            //plusButton[i] = GameObject.Find("p" + (i + 1) + "+");
        }
        player1 = GameObject.Find("p1");
        player2 = GameObject.Find("p2");
        player2ButtonAdd = GameObject.Find("p2+");
        player2ButtonRemove = GameObject.Find("p2-");
        player3 = GameObject.Find("p3");
        player3ButtonAdd = GameObject.Find("p3+");
        player3ButtonRemove = GameObject.Find("p3-");
        player4 = GameObject.Find("p4");
        player4ButtonAdd = GameObject.Find("p4+");
        player4ButtonRemove = GameObject.Find("p4-");
    }

    // Update is called once per frame
    void Update()
    {
        if (player2Active == false)
        {
            player2.SetActive(false);
            player2ButtonRemove.SetActive(false);
            player2ButtonAdd.SetActive(true);
        }
        else if (player2Active == true)
        {
            player2.SetActive(true);
            player2ButtonAdd.SetActive(false);
            player2ButtonRemove.SetActive(true);
        }
        if (player3Active == false)
        {
            player3.SetActive(false);
            player3ButtonRemove.SetActive(false);
            player3ButtonAdd.SetActive(true);
        }
        else if (player3Active == true)
        {
            player3.SetActive(true);
            player3ButtonAdd.SetActive(false);
            player3ButtonRemove.SetActive(true);
        }
        if (player4Active == false)
        {
            player4.SetActive(false);
            player4ButtonRemove.SetActive(false);
            player4ButtonAdd.SetActive(true);
        }
        else if (player4Active == true)
        {
            player4.SetActive(true);
            player4ButtonAdd.SetActive(false);
            player4ButtonRemove.SetActive(true);
        }
    }
    public void addPlayer2()
    {
        player2Active = true;        
    }
    public void removePlayer2()
    {
        player2Active = false;
    }
    public void addPlayer3()
    {
        player3Active = true;
    }
    public void removePlayer3()
    {
        player3Active = false;
    }
    public void addPlayer4()
    {
        player4Active = true;
    }
    public void removePlayer4()
    {
        player4Active = false;
    } 
    //Buttons to change player colour
    public void changeColourP1Plus()
    {
        if (player1ColourIndex >= playerColours.Length - 1)
        {
            player1ColourIndex = playerColours.Length - 1;
            applyColoursP1(player1ColourIndex);
            plusButton[0].SetActive(false);
        }
        else
        {
            player1ColourIndex++;
            applyColoursP1(player1ColourIndex);

        }        
        if (player1ColourIndex > 0)
        {
            minusButton[0].SetActive(true);
        }
    }   
    public void changeColourP1Minus()
    {
        if (player1ColourIndex <= 0)
        {
            player1ColourIndex = 0;
            applyColoursP1(player1ColourIndex);
            minusButton[0].SetActive(false);
        }
        else
        {
            player1ColourIndex--;
            applyColoursP1(player1ColourIndex);

        }
        if (player1ColourIndex < playerColours.Length - 1)
        {
            plusButton[0].SetActive(true);
        }
    }
    public void changeColourP2Plus()
    {
        if (player2ColourIndex >= playerColours.Length - 1)
        {
            player2ColourIndex = playerColours.Length - 1;
            applyColoursP2(player2ColourIndex);
        }
        else
        {
            player2ColourIndex++;
            applyColoursP2(player2ColourIndex);

        }
        if (player2ColourIndex > 0)
        {
            minusButton[1].SetActive(true);
        }
    }
    public void changeColourP2Minus()
    {
        if (player2ColourIndex <= 0)
        {
            player2ColourIndex = 0;
            applyColoursP2(player2ColourIndex);
        }
        else
        {
            player2ColourIndex--;
            applyColoursP2(player2ColourIndex);

        }
        if (player2ColourIndex < playerColours.Length - 1)
        {
            plusButton[1].SetActive(true);
        }
    }
    public void changeColourP3Plus()
    {
        if (player3ColourIndex >= playerColours.Length - 1)
        {
            player3ColourIndex = playerColours.Length - 1;
            applyColoursP3(player3ColourIndex);
        }
        else
        {
            player3ColourIndex++;
            applyColoursP3(player3ColourIndex);

        }
        if (player3ColourIndex > 0)
        {
            minusButton[2].SetActive(true);
        }
    }
    public void changeColourP3Minus()
    {
        if (player3ColourIndex <= 0)
        {
            player3ColourIndex = 0;
            applyColoursP3(player3ColourIndex);
        }
        else
        {
            player3ColourIndex--;
            applyColoursP3(player3ColourIndex);

        }
        if (player3ColourIndex < playerColours.Length - 1)
        {
            plusButton[2].SetActive(true);
        }
    }
    public void changeColourP4Plus()
    {
        if (player4ColourIndex >= playerColours.Length - 1)
        {
            player4ColourIndex = playerColours.Length - 1;
            applyColoursP4(player4ColourIndex);
        }
        else
        {
            player4ColourIndex++;
            applyColoursP4(player4ColourIndex);

        }
        if (player4ColourIndex > 0)
        {
            minusButton[3].SetActive(true);
        }
    }
    public void changeColourP4Minus()
    {
        if (player4ColourIndex <= 0)
        {
            player4ColourIndex = 0;
            applyColoursP4(player4ColourIndex);
        }
        else
        {
            player4ColourIndex--;
            applyColoursP4(player4ColourIndex);

        }
        if (player4ColourIndex < playerColours.Length - 1)
        {
            plusButton[3].SetActive(true);
        }
    }
    //apply colours to players | other comments -> change player script colour variable if needed
    public void applyColoursP1(int index)
    {
        player1.GetComponent<SpriteRenderer>().color = playerColours[player1ColourIndex];
        //player1.GetComponent<playerScript>().playerColor = playerColours[player1ColourIndex];
    }
    public void applyColoursP2(int index)
    {
        player2.GetComponent<SpriteRenderer>().color = playerColours[player2ColourIndex];
        //player2.GetComponent<playerScript>().playerColor = playerColours[player2ColourIndex];
    }
    public void applyColoursP3(int index)
    {
        player3.GetComponent<SpriteRenderer>().color = playerColours[player3ColourIndex];
        //player3.GetComponent<playerScript>().playerColor = playerColours[player3ColourIndex];
    }
    public void applyColoursP4(int index)
    {
        player4.GetComponent<SpriteRenderer>().color = playerColours[player4ColourIndex];
        //player4.GetComponent<playerScript>().playerColor = playerColours[player4ColourIndex];
    }
    
}
