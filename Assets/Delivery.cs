using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    Driver playerOne;
    
    [SerializeField] bool hasPackage = false;
    void Start()
    {
        playerOne = FindObjectOfType<Driver>().GetComponent<Driver>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Big ass collision");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package")
        {
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
        else if (other.tag == "Customer" && hasPackage == false)
        {
            Debug.Log("No package to deliver!");            
        }
        else
        {
            Debug.Log("Triggerred");
            
        }  
    }
}
