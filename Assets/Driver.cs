using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    private int score = 0;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] public float moveSpeed = 20f;
    [SerializeField] public float boostSpeed = 40f;
    [SerializeField] public float slowSpeed = 10f;
    [SerializeField] public float normalSpeed = 20f;


    void Start()
    {
            
    }

    public int GetScore()
    {
        return score;    
    }
    public void SetScore(int scoreToSet)
    {
        score = scoreToSet;
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
