using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLockedDoor : MonoBehaviour
{
    public float moveSpeed = 1f;

//--------------------------------------------------------------------------------------------
    // These reference all side of the door sprite
    // These are the sprites that will move when the button is pressed
    public Transform topSide;
    public Transform bottomSide;
    
//----------------------------------------------------------------------------------------------------------
// These allow the sprites to move back to their original positions when the button is pressed again
    private Vector3 originalPositionTop; // Original position for the top left sprite
    private Vector3 originalPositionBottom; // Original position for the bottom left sprite
   
    //-------------------------------------------------------------------------------------------------------

    private bool isOpen = false; // Flag to check if the door is open
    public bool isMoving = false; // Flag to check if the door is moving

//--------------------------------------------------------------------------------------------
    void Start()
    {
        // Store the original positions of the sprites
        originalPositionTop = topSide.position;
        originalPositionBottom = bottomSide.position;
       
    }


//--------------------------------------------------------------------------------------------
    // Method to handle the button press
   public void ButtonPressed()
    {
        if(!isMoving)
        {
         
        if (!isOpen)
        {
            // Move the sprites by 1 unit either side
            StartCoroutine(MoveSprite(topSide, topSide.position + new Vector3(0, 1, 0)));
            StartCoroutine(MoveSprite(bottomSide, bottomSide.position + new Vector3(0, -1, 0)));
           
        }
        else
        {
            // Move the sprites back to their original positions
            StartCoroutine(MoveSprite(topSide, originalPositionTop));
            StartCoroutine(MoveSprite(bottomSide, originalPositionBottom));
           
        }
        isOpen = !isOpen; // Toggle the isOpen flag
    }
    }

    // Coroutine to smoothly move a sprite to a target position
    private IEnumerator MoveSprite(Transform sprite, Vector3 targetPosition)
    {
        isMoving = true; // Set the isMoving flag to true
        while (Vector3.Distance(sprite.position, targetPosition) > 0.01f)
        {
            sprite.position = Vector3.MoveTowards(sprite.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        sprite.position = targetPosition; // Ensure the sprite reaches the target position
        isMoving = false; // Set the isMoving flag to false
    }
}