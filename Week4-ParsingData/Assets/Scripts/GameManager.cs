using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization; 
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //static variable means the value is the same for all the objects of this class type and the class itself
    public static GameManager instance; //this static var will hold the Singleton

    public float gameTIme = 8;
    private float timer;

    public int score;

    public TextMesh text; //TextMesh Component to tell you the time and the score

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    public int mouseClick = 0;
    List<int> clicks;

    public bool isGame = true;

    private const string FILE_CLICKS = "/clicks.txt"; 
    private string FILE_PATH_MOUSE_CLICKS;
    
    void Awake()
    {
        if (instance == null) //instance hasn't been set yet
        {
            DontDestroyOnLoad(gameObject); //Dont Destroy this object when you load a new scene
            instance = this; //set instance to this object
        }
        else //if the instance is already set to an object
        {
            Destroy(gameObject); //destroy this new object, so there is only ever one
        }
    }

    void Start()
    {
        timer = 0;
        FILE_PATH_MOUSE_CLICKS = Application.dataPath + FILE_CLICKS; //the computer's path to wherever this is running 
        if (!File.Exists(FILE_PATH_MOUSE_CLICKS)) // if the file does not exist
        {
            File.Create(FILE_PATH_MOUSE_CLICKS); // create file 
        }
        else // and if it does exist
        {
             UpdateClicks(); //fill it with mouseClick
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!isGame) // if not in game, display number of clicks 
        {
            string clicksString = "Clicks\n\n";

            for (int i = 0; i < clicks.Count; i++) 
            {
                clicksString += clicks[i] + "\n";
            }

            text.text = clicksString;
        }
        else // if in game, display timer and score
        {
            text.text = "Time: " + (int) (gameTIme - timer); // + " Score: " + score;
        }
        
        if (gameTIme < timer && isGame) //when the timer runs out and we're still in game, go to Game Over screen and fill the file with mouseClick 
        {
            UpdateClicks(); 
            SceneManager.LoadScene(1);
            isGame = false;
        }

        if (Input.GetMouseButtonDown(0)) //add to mouseClick counter every time I click the left mouse button 
        {
            mouseClick++;
            //Debug.Log("Click Number: " + mouseClick);
        }
    }

    public void UpdateClicks()
    {
        if (clicks == null) // if no clicks list
        {
            clicks = new List<int>(); // make clicks list
            string fileContents = File.ReadAllText(FILE_PATH_MOUSE_CLICKS);  
            //Debug.Log(fileContents);
            string[] fileClicks = fileContents.Split('|'); //separate every click number with pipe 

            for (int i = 0; i < fileClicks.Length - 1; i++)
            {
                clicks.Add(Int32.Parse(fileClicks[i]));
                //Debug.Log("clicks: " + clicks[i]);
            }
        }

        for (int i = 0; i < clicks.Count; i++)
        {
            if (mouseClick > clicks[i])
            {
                clicks.Insert(i, mouseClick); //insert "high score" mouseClicks
                break;
            }
        }

        string saveClicksString = "";

        for (int i = 0; i < clicks.Count; i++)
        {
            saveClicksString += clicks[i] + " | "; 
        }
        File.WriteAllText(FILE_PATH_MOUSE_CLICKS, saveClicksString);
    }
}
