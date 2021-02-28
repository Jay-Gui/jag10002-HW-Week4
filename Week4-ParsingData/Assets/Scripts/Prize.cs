
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Prize : MonoBehaviour
{
    
    public float speed = 5f;
    private Vector2 newPosition;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = transform.position;

        newPosition.x += speed * Time.deltaTime;
        newPosition.y += speed * Time.deltaTime;

        transform.position = newPosition;

        
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Right Wall") {
            //Debug.Log("pushLeft");
            rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
        }
        
        else if (other.gameObject.tag == "Left Wall")
        {
          //  Debug.Log("pushRight");
            rb.AddForce(Vector2.right * speed, ForceMode2D.Impulse);
        }
        
        else if (other.gameObject.tag == "Top Wall")
        {
        //    Debug.Log("pushDown");
            rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
        }
        else if (other.gameObject.tag == "Bottom Wall")
        {
         //   Debug.Log("pushUp");
            rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }

        if (other.gameObject.tag == "Laser")
        {
            transform.position = new Vector2( //teleport to a random location
                Random.Range(-10, 10),
                Random.Range(-4.8f, 6.8f));
            speed++; 

            GameManager.instance.score++; //increase the player's score using the Singleton!

            print("Score: " + GameManager.instance.score);
        }
    }
}
