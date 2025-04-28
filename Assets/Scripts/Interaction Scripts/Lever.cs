using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

/*public class LockedDoorButton : MonoBehaviour
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
*/
public class Lever : MonoBehaviour
{
    public LockedDoor lockedDoor; // Reference to the LockedDoor component
    public VerticalLockedDoor verticalLockedDoor; // Reference to the VerticalLockedDoor component
    public PlayerController playerController;
    public HighlightInteractable highlight;
    public Animator leverAnimation;
    private bool isFlipped = false; // Flag to check if the lever is flipped

    void Start()
    {
        if (lockedDoor == null && verticalLockedDoor == null)
        {
            Debug.LogError("Neither LockedDoor nor VerticalLockedDoor reference is set in the Inspector."); // Flag in the debug if there is no door tied to the lever
        }
    }
    /*private void Update()
    {
        if (isFlipped)
        {
            transform.eulerAngles = Vector3.forward * 180;

        }
        else
        {
            transform.eulerAngles = Vector3.forward * 0;

        }
    }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wrench"))
        {
            highlight.Highlight();

        }
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(verticalLockedDoor != null)
            if ((other.CompareTag("Wrench") && playerController.isSwinging && !verticalLockedDoor.isMoving)) // Check if the player collides with the lever
            {

                isFlipped = !isFlipped; // Toggle the lever state
                StartCoroutine(OpenVerticleDoor());
            }

        if (lockedDoor != null)
        {
            if ((other.CompareTag("Wrench") && playerController.isSwinging && !lockedDoor.isMoving))
            {
                isFlipped = !isFlipped; // Toggle the lever state
                StartCoroutine(OpenDoor());
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        highlight.unHighlight();

    }

    IEnumerator OpenDoor()
    {

        yield return new WaitForSeconds(.29f);
            if (lockedDoor != null) // Runs the function if the door is not null
            {
                if (isFlipped)
                {
                    lockedDoor.OpenDoor(); // Call the OpenDoor method in the LockedDoor script
                    leverAnimation.SetBool("isFlipped", true);
            }
            else
                {
                    lockedDoor.CloseDoor(); // Call the CloseDoor method in the LockedDoor script
                    leverAnimation.SetBool("isFlipped", false);

            }
        }
            
            Debug.Log("Lever flipped, door state toggled");
        yield return null;
        }
    IEnumerator OpenVerticleDoor()
    {
        yield return new WaitForSeconds(.29f);
        
        if (verticalLockedDoor != null) // Runs the function if the vertical door is not null
        {
            if (isFlipped)
            {
                verticalLockedDoor.OpenDoor(); // Call the OpenDoor method in the VerticalLockedDoor script
                leverAnimation.SetBool("isFlipped", true);

            }
            else
            {
                verticalLockedDoor.CloseDoor(); // Call the CloseDoor method in the VerticalLockedDoor script
                leverAnimation.SetBool("isFlipped", false);

            }
        }
        Debug.Log("Lever flipped, door state toggled");
        yield return null;
    }
}

