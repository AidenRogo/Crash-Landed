//Author: Aiden Rogowski
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{

//Declare variables
    public SpriteRenderer elevatorSprite; // Reference to the SpriteRenderer component of the elevator
    public Generator generator; // Reference to the Generator component
    public int nextLevelIndex; // reference to the next level index
    public Animator ElevetorAnimator;
    public BoxCollider2D myCollider;


    private void Start()
    {
        //BoxCollider2D myCollider = GetComponent<BoxCollider2D>();
        myCollider.isTrigger = false;
    }


    public void GeneratorPowered() //Called when the generator is powered, allowing you to progress to the next level
    {

        Debug.Log("Level is Complete!"); //Debug
        ElevetorAnimator.SetBool("isPowered", true);
        myCollider.isTrigger = true;

        if (elevatorSprite != null)
        {
            // Change the color of the elevator sprite
            //elevatorSprite.color = Color.green; // Change to green or any other color you prefer
           
        }
        else
        {
            Debug.LogError("Elevator sprite reference is not set.");
        }
    }

    // For future!
    // Add a method for when the generator is no longer powered


    void OnTriggerEnter2D(Collider2D other) //Ensure that the collision is 2D!!!
    {
        if (other.CompareTag("Player")) //Check if object colliding with the button is tagged with "Player"
        {
            Debug.Log("Player has entered the elevator");
            if (generator.isPowered == true) 
            {
                Debug.Log("Elevator moving to next level");

                //changes the scene to the next level in the index
                SceneManager.LoadScene(nextLevelIndex);


            }
            else
            {
                Debug.Log("Generator is not powered."); // Won't move to the next level if the generator is not powered
            }
        }
    }
}


