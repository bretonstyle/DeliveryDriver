using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    Driver playerOne;
    
    [SerializeField] bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;
    void Start()
    {
        playerOne = FindObjectOfType<Driver>().GetComponent<Driver>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Whoops!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage)
        { 
            Destroy(other.gameObject, destroyDelay);
            Debug.Log("Package Picked Up!");
            hasPackage = true;
        }      
        else if (other.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Delivered ze Package!");
            hasPackage = false;
            playerOne.SetScore(playerOne.GetScore() + 1);
            Debug.Log("New score ==" + playerOne.GetScore());
        }
    }
}
