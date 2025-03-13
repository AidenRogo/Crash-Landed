using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorButton : MonoBehaviour
{
    public LockedDoor lockedDoor; // Reference to the LockedDoor component
      public VerticalLockedDoor verticalLockedDoor; // Reference to the VerticalLockedDoor component

    //----------------------------------------------------------------------------------------------------------
     void Start()
    {
        if (lockedDoor == null && verticalLockedDoor == null)
        {
            Debug.LogError("Neither LockedDoor nor VerticalLockedDoor reference is set in the Inspector."); // Flag in the debug if there is no door tied to the button
        }
    }
    //----------------------------------------------------------------------------------------------------------
    // Method to detect collision with the player
    void OnTriggerEnter2D(Collider2D other) // Ensure that the collision is 2D
    {
        if (other.CompareTag("Wrench")) // Check if object colliding with the button is tagged with "Player"
        {
            Debug.Log("Button pressed"); // Log in console that the button was pressed
            if (lockedDoor != null) // Runs the function if the door is not null
            {
                lockedDoor.OpenDoor(); // Call the ButtonPressed method in the LockedDoor script
            }
            else if (verticalLockedDoor != null) // Runs the function if the vertical door is not null
            {
                verticalLockedDoor.OpenDoor(); // Call the ButtonPressed method in the VerticalLockedDoor script
            }
            else
            {
                Debug.LogError("LockedDoor or VerticalLockedDoor reference is not set."); // Log in the console that the door is not set
            }
        }
    }
}