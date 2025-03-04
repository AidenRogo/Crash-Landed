using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public Transform topLeftSide; // Reference to the top left sprite
    public Transform bottomLeftSide; // Reference to the bottom left sprite
    public Transform topRightSide; // Reference to the top right sprite
    public Transform bottomRightSide; // Reference to the bottom right sprite

    public float moveSpeed = 1f; // Speed of the door movement

    private Vector3 originalPositionTopLeft; // Original position for the top left sprite
    private Vector3 originalPositionBottomLeft; // Original position for the bottom left sprite
    private Vector3 originalPositionTopRight; // Original position for the top right sprite
    private Vector3 originalPositionBottomRight; // Original position for the bottom right sprite

    private bool isOpen = false; // Flag to check if the door is open
    public bool isMoving = false; // Flag to check if the door is currently moving

    void Start()
    {
        // Store the original positions of the sprites
        originalPositionTopLeft = topLeftSide.position;
        originalPositionBottomLeft = bottomLeftSide.position;
        originalPositionTopRight = topRightSide.position;
        originalPositionBottomRight = bottomRightSide.position;
    }

    // Method to handle the button press
    public void ButtonPressed()
    {
        if (!isMoving)
        {
            if (!isOpen)
            {
                // Move the sprites by 1 unit either side
                StartCoroutine(MoveSprite(topLeftSide, topLeftSide.position + new Vector3(-1, 0, 0)));
                StartCoroutine(MoveSprite(bottomLeftSide, bottomLeftSide.position + new Vector3(-1, 0, 0)));
                StartCoroutine(MoveSprite(topRightSide, topRightSide.position + new Vector3(1, 0, 0)));
                StartCoroutine(MoveSprite(bottomRightSide, bottomRightSide.position + new Vector3(1, 0, 0)));
            }
            else
            {
                // Move the sprites back to their original positions
                StartCoroutine(MoveSprite(topLeftSide, originalPositionTopLeft));
                StartCoroutine(MoveSprite(bottomLeftSide, originalPositionBottomLeft));
                StartCoroutine(MoveSprite(topRightSide, originalPositionTopRight));
                StartCoroutine(MoveSprite(bottomRightSide, originalPositionBottomRight));
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