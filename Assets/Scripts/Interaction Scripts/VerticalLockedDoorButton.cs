using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLockedDoorButton : MonoBehaviour
{
    public LockedDoor VerticalLockedDoor; // Reference to the LockedDoor component

    //----------------------------------------------------------------------------------------------------------
    void Start()
    {
        if (VerticalLockedDoor == null)
        {
            Debug.LogError("LockedDoor reference is not set in the Inspector."); //Flag in the debug if there is no door tied to the button
        }
    }
    //----------------------------------------------------------------------------------------------------------
    // Method to detect collision with the player
    void OnTriggerEnter2D(Collider2D other) //Ensure that the collision is 2D!!!
    {
        if (other.CompareTag("Player")) //Check if object colliding with the button is tagged with "Player"
        {
            Debug.Log("Button pressed"); //Log in console that the button was pressed
            if (VerticalLockedDoor != null) //Runs the function if the door is not null
            {
                VerticalLockedDoor.ButtonPressed(); // Call the ButtonPressed method in the LockedDoor script
            }
            else
            {
                Debug.LogError("VerticalLockedDoor reference is not set."); //Log in the console that the door is not set
            }
        }
    }
}