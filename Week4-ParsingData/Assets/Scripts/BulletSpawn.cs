using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    public GameObject laser;
    public Transform laserSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // is mouse left click is pressed, spawn laser prefab at laserSpawner position
        if (Input.GetMouseButtonDown(0))                       // GetButton("Fire1"))
        {
            Instantiate(laser, laserSpawner.position, laserSpawner.rotation);
            //Debug.Log("Shoot!");
        }
    }
}
    
  //  private void FixedUpdate()
   // {
        // hotkeys shoot to mouse left click
        // bool shoot = Input.GetButton("Fire1");

      //  bool shoot = Input.GetMouseButton(0); 

        
