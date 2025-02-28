using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{

//--------------------------------------------------------------------------------------------
    // These reference all side of the door sprite
    // These are the sprites that will move when the button is pressed
    public Transform topLeftSide;
    public Transform bottomLeftSide;
    public Transform topRightSide;
    public Transform bottomRightSide;
//----------------------------------------------------------------------------------------------------------
// These allow the sprites to move back to their original positions when the button is pressed again
    private Vector3 originalPositionTopLeft; // Original position for the top left sprite
    private Vector3 originalPositionBottomLeft; // Original position for the bottom left sprite
    private Vector3 originalPositionTopRight; // Original position for the top right sprite
    private Vector3 originalPositionBottomRight; // Original position for the bottom right sprite
    //-------------------------------------------------------------------------------------------------------

    private bool isOpen = false; // Flag to check if the door is open

//--------------------------------------------------------------------------------------------
    void Start()
    {
        // Store the original positions of the sprites
        originalPositionTopLeft = topLeftSide.position;
        originalPositionBottomLeft = bottomLeftSide.position;
        originalPositionTopRight = topRightSide.position;
        originalPositionBottomRight = bottomRightSide.position;
    }


//--------------------------------------------------------------------------------------------
    // Method to handle the button press
    public void ButtonPressed()
    {
        if (!isOpen)
        {
            // Move the sprites by 1 unit either side
            topLeftSide.position += new Vector3(-1, 0, 0); // Move the top left sprite to the left -1 unit
            bottomLeftSide.position += new Vector3(-1, 0, 0); // Move the bottom left sprite to the left -1 unit
            topRightSide.position += new Vector3(1, 0, 0); // Move the top right sprite to the right 1 unit
            bottomRightSide.position += new Vector3(1, 0, 0); // Move the bottom right sprite to the right 1 unit;
        }
        else
        {
            // Move the sprites back to their original positions
            // This is if the door is already open and the button is pressed again
            topLeftSide.position = originalPositionTopLeft; // Revert position
            bottomLeftSide.position = originalPositionBottomLeft; // Revert position
            topRightSide.position = originalPositionTopRight; // Revert position
            bottomRightSide.position = originalPositionBottomRight; // Revert position
        }
        isOpen = !isOpen; // Toggle the isOpen flag
    }
}