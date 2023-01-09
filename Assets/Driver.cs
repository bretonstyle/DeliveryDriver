using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    int hitPoints = 20;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 10f;

    void Start()
    {
            
    }

    void Update()
    {
        //Define this here so we find it every frame
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
}