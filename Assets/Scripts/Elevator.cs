using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public SpriteRenderer elevatorSprite; // Reference to the SpriteRenderer component of the elevator
    public Generator generator; // Reference to the Generator component

    
    


    public void GeneratorPowered()
    {
        Debug.Log("Level is Complete!");

        if (elevatorSprite != null)
        {
            // Change the color of the elevator sprite
            elevatorSprite.color = Color.green; // Change to green or any other color you prefer
           
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
            }
            else
            {
                Debug.Log("Generator is not powered.");
            }
        }
    }
}


