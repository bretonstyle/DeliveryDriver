using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    Driver playerOne;
    
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] bool hasPackage = false;
    [SerializeField] float destroyDelay = 0.5f;

    SpriteRenderer spriteRenderer;
    float bumpTime;
    void Start()
    {
        //Driver is attached to the same component (SpeedyCivic), so is the Sprite Renderer
        playerOne = GetComponent<Driver>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (Time.time > bumpTime + 5f ){
            playerOne.moveSpeed = playerOne.normalSpeed;
        }

    }

    async void OnCollisionEnter2D(Collision2D other) {
        playerOne.moveSpeed = playerOne.slowSpeed;
        Debug.Log ("Bumped");
        bumpTime = Time.time;
        Debug.Log ("Current Time:" + bumpTime.ToString());
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage)
        { 
            spriteRenderer.color= hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
            Debug.Log("Package Picked Up!");
            hasPackage = true;
        }      
        else if (other.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Delivered ze Package!");
            spriteRenderer.color= noPackageColor;
            hasPackage = false;
            playerOne.SetScore(playerOne.GetScore() + 1);
            Debug.Log("New score ==" + playerOne.GetScore());
        }
        else if (other.tag =="Boost")
        {
            Destroy(other.gameObject, destroyDelay);
            Debug.Log("Boost!");
            playerOne.moveSpeed = playerOne.boostSpeed;
            bumpTime = Time.time;
        }
    }
}
