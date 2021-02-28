using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float laserForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "FirePoint")
        {
            GetComponent<Rigidbody2D>().AddForce(transform.right * laserForce);
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Right Wall")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Left Wall")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Top Wall")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Bottom Wall")
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Prize")
        {
            Destroy(this.gameObject);
        }
    }
}
