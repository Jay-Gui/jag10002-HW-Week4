using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public float speed = 10;

    void Update()
    {
        var pos = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        var dir = (Input.mousePosition - pos);
        var angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        this.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime); 
    }
}
