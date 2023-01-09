using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Big ass collision");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package")
        {
            Debug.Log("Package Picked Up!");
        }      
        else if (other.tag == "Customer")
        {
            Debug.Log("Delivered ze Package!");
        }
        else
        {
            Debug.Log("Triggerred");
        }  
    }
}
