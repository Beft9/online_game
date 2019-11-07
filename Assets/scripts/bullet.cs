using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    // Use this for initialization
    private void OnCollisionEnter(Collision collision)
    {
        GameObject hit = collision.gameObject;
        health point = hit.GetComponent<health>();
        if(point != null)
        {
            point.Take_damage(10);
        }
        Destroy(gameObject);
    }
}
