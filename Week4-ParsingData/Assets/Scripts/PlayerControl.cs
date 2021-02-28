using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float forceAmount = 5; //public var for force amount
 
    Rigidbody2D rb2D; //var for the Rigidbody2D
    public GameObject _GameManager; //access GameManager object
    private GameManager script; //access the script on the GameManager

    //static variable means the value is the same for all the objects of this class type and the class itself
    public static PlayerControl instance; //this static var will hold the Singleton

    void Awake()
    {
    // {
    //     if (instance == null) //instance hasn't been set yet
    //     {
    //         DontDestroyOnLoad(gameObject); //Dont Destroy this object when you load a new scene
    //         instance = this; //set instance to this object
    //     }
    //     else //if the instance is already set to an object
    //     {
    //         Destroy(gameObject); //destroy this new object, so there is only ever one
    //     }
    }


    // Start is called before the first frame update
    void Start()
    {
        script = _GameManager.GetComponent<GameManager>(); 
        rb2D = GetComponent<Rigidbody2D>(); //get the Rigidbody2D  off of this gameObject
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //if W is pressed
        {
            rb2D.AddForce(Vector2.up * forceAmount); //apply to the up mult by the "force" var
        }

        if (Input.GetKey(KeyCode.S)) //if S is pressed
        {
            rb2D.AddForce(Vector2.down * forceAmount); //apply to the up mult by the "force" var
        }

        if (Input.GetKey(KeyCode.A)) //if A is pressed
        {
            rb2D.AddForce(Vector2.left * forceAmount); //apply to the up mult by the "force" var
        }

        if (Input.GetKey(KeyCode.D)) //if D is pressed
        {
            rb2D.AddForce(Vector2.right * forceAmount); //apply to the up mult by the "force" var
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Prize")
        {
            Destroy(this.gameObject); 
            script.UpdateClicks(); //when you die, record the mouseClicks
            script.isGame = false;  //also, since we're in the Game Over screen, stop printing the timer to the screen 
            SceneManager.LoadScene(1); 
        }
    }
}
    
