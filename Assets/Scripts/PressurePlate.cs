using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public LockedDoor lockedDoor; // Reference to the LockedDoor component
    public VerticalLockedDoor verticalDoor; // Reference to the VerticalLockedDoor component

    private int objectsOnPlate = 0; // Counter for objects on the pressure plate

    void Start()
    {
        if (lockedDoor == null && verticalDoor == null)
        {
            Debug.LogError("Neither LockedDoor nor VerticalLockedDoor reference is set in the Inspector."); // Flag in the debug if there is no door tied to the pressure plate
        }
    }

    // Method to detect collision with the player or box
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box")) // Check if object colliding with the pressure plate is tagged with "Player" or "Box"
        {
            objectsOnPlate++;
            Debug.Log("Pressure plate activated"); // Log in console that the pressure plate was activated
            if (lockedDoor != null && !lockedDoor.isMoving) // Runs the function if the door is not null and not moving
            {
                lockedDoor.ButtonPressed(); // Call the ButtonPressed method in the LockedDoor script
            }
            else if (verticalDoor != null && !verticalDoor.isMoving) // Runs the function if the vertical door is not null and not moving
            {
                verticalDoor.ButtonPressed(); // Call the ButtonPressed method in the VerticalLockedDoor script
            }
        }
    }

    // Method to detect when the player or box leaves the pressure plate
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box")) // Check if object leaving the pressure plate is tagged with "Player" or "Box"
        {
            objectsOnPlate--;
            if (objectsOnPlate <= 0)
            {
                Debug.Log("Pressure plate deactivated"); // Log in console that the pressure plate was deactivated
                if (lockedDoor != null) // Runs the function if the door is not null
                {
                    if (lockedDoor.isMoving)
                    {
                        StopAllCoroutines(); // Stop the current movement
                        lockedDoor.ButtonPressed(); // Call the ButtonPressed method to reverse the movement
                    }
                    else
                    {
                        lockedDoor.ButtonPressed(); // Call the ButtonPressed method in the LockedDoor script
                    }
                }
                else if (verticalDoor != null) // Runs the function if the vertical door is not null
                {
                    if (verticalDoor.isMoving)
                    {
                        StopAllCoroutines(); // Stop the current movement
                        verticalDoor.ButtonPressed(); // Call the ButtonPressed method to reverse the movement
                    }
                    else
                    {
                        verticalDoor.ButtonPressed(); // Call the ButtonPressed method in the VerticalLockedDoor script
                    }
                }
            }
        }
    }
}