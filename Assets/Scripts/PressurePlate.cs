using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public LockedDoor lockedDoor; // Reference to the LockedDoor component
    public VerticalLockedDoor verticalDoor; // Reference to the VerticalLockedDoor component
    public float closeDelay = 3f; // Time in seconds to wait before closing the door

    private int objectsOnPlate = 0; // Counter for objects on the pressure plate
    private Coroutine closeCoroutine; // Reference to the close coroutine

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
            if (objectsOnPlate == 1) // Only open the door if this is the first object on the plate
            {
                if (closeCoroutine != null)
                {
                    StopCoroutine(closeCoroutine);
                }
                if (lockedDoor != null && !lockedDoor.isMoving) // Runs the function if the door is not null and not moving
                {
                    lockedDoor.OpenDoor(); // Call the OpenDoor method in the LockedDoor script
                }
                else if (verticalDoor != null && !verticalDoor.isMoving) // Runs the function if the vertical door is not null and not moving
                {
                    verticalDoor.OpenDoor(); // Call the OpenDoor method in the VerticalLockedDoor script
                }
                Debug.Log("Pressure plate activated, door opened");
            }
        }
    }

    // Method to detect when the player or box leaves the pressure plate
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Box")) // Check if object leaving the pressure plate is tagged with "Player" or "Box"
        {
            objectsOnPlate--;
            if (objectsOnPlate == 0) // Only start the close timer if there are no objects left on the plate
            {
                closeCoroutine = StartCoroutine(CloseDoorAfterDelay());
                Debug.Log("Pressure plate deactivated, starting close timer");
            }
        }
    }

    private IEnumerator CloseDoorAfterDelay()
    {
        yield return new WaitForSeconds(closeDelay);
        if (lockedDoor != null) // Runs the function if the door is not null
        {
            lockedDoor.CloseDoor(); // Call the CloseDoor method in the LockedDoor script
        }
        else if (verticalDoor != null) // Runs the function if the vertical door is not null
        {
            verticalDoor.CloseDoor(); // Call the CloseDoor method in the VerticalLockedDoor script
        }
        Debug.Log("Close timer expired, door closed");
    }
}