using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public Transform laser;
    public float collisionRadius;
    public bool collided = false;
    public LayerMask collide;
    
    private void FixedUpdate()
    {
        // grab the position of the laser
        collided = Physics2D.OverlapCircle(laser.position, collisionRadius, collide);

        // if laser collides with any solid object or goes offscreen, it is destroyed
        if (collided) Destroy(gameObject);
        if (!GetComponent<Renderer>().isVisible) Destroy(gameObject);
    }
}
