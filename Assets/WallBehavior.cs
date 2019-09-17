using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
       
        if (col.gameObject.tag == "Bullet")
        {
            Debug.Log("bullet destroyed");
            Destroy(col.gameObject);
        }
    }
}
