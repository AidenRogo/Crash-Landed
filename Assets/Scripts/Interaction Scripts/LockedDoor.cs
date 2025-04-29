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

    public bool isOpen = false; // Flag to check if the door is open
    public bool isMoving = false; // Flag to check if the door is currently moving

    private Coroutine currentCoroutine; // Reference to the current coroutine

    void Start()
    {
        // Store the original positions of the sprites
        originalPositionTopLeft = topLeftSide.position;
        originalPositionBottomLeft = bottomLeftSide.position;
        originalPositionTopRight = topRightSide.position;
        originalPositionBottomRight = bottomRightSide.position;
    }

    public void OpenDoor()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(MoveDoor(true));
    }

    public void CloseDoor()
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(MoveDoor(false));
    }

    private IEnumerator MoveDoor(bool opening)
    {
        isMoving = true;
        Vector3 targetPositionTopLeft = opening ? originalPositionTopLeft + new Vector3(-1.5f, 0, 0) : originalPositionTopLeft;
        Vector3 targetPositionBottomLeft = opening ? originalPositionBottomLeft + new Vector3(-1.5f, 0, 0) : originalPositionBottomLeft;
        Vector3 targetPositionTopRight = opening ? originalPositionTopRight + new Vector3(1.2f, 0, 0) : originalPositionTopRight;
        Vector3 targetPositionBottomRight = opening ? originalPositionBottomRight + new Vector3(1.2f, 0, 0) : originalPositionBottomRight;

        while (Vector3.Distance(topLeftSide.position, targetPositionTopLeft) > 0.01f ||
               Vector3.Distance(bottomLeftSide.position, targetPositionBottomLeft) > 0.01f ||
               Vector3.Distance(topRightSide.position, targetPositionTopRight) > 0.01f ||
               Vector3.Distance(bottomRightSide.position, targetPositionBottomRight) > 0.01f)
        {
            topLeftSide.position = Vector3.MoveTowards(topLeftSide.position, targetPositionTopLeft, moveSpeed * Time.deltaTime);
            bottomLeftSide.position = Vector3.MoveTowards(bottomLeftSide.position, targetPositionBottomLeft, moveSpeed * Time.deltaTime);
            topRightSide.position = Vector3.MoveTowards(topRightSide.position, targetPositionTopRight, moveSpeed * Time.deltaTime);
            bottomRightSide.position = Vector3.MoveTowards(bottomRightSide.position, targetPositionBottomRight, moveSpeed * Time.deltaTime);
            yield return null;
        }

        topLeftSide.position = targetPositionTopLeft;
        bottomLeftSide.position = targetPositionBottomLeft;
        topRightSide.position = targetPositionTopRight;
        bottomRightSide.position = targetPositionBottomRight;

        isOpen = opening;
        isMoving = false;
        currentCoroutine = null;
    }
}