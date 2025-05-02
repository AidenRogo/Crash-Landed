using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenDoor : MonoBehaviour
{
    public Generator generator; // Reference to the Generator script
    public Transform topSide; // Reference to the top sprite
    public Transform bottomSide; // Reference to the bottom sprite

    public float moveSpeed = 1f; // Speed of the door movement

    private Vector3 originalPositionTop; // Original position for the top sprite
    private Vector3 originalPositionBottom; // Original position for the bottom sprite

    private bool isOpen = false; // Flag to check if the door is open
    private bool isMoving = false; // Flag to check if the door is currently moving

    void Start()
    {
        // Store the original positions of the sprites
        originalPositionTop = topSide.position;
        originalPositionBottom = bottomSide.position;
    }

    public void OpenDoor()
    {
        if (!isMoving && !isOpen)
        {
            StopAllCoroutines();
            StartCoroutine(MoveDoor(true));
        }
    }

    public void CloseDoor()
    {
        if (!isMoving && isOpen)
        {
            StopAllCoroutines();
            StartCoroutine(MoveDoor(false));
        }
    }

    private IEnumerator MoveDoor(bool opening)
    {
        isMoving = true;

        // Adjust the target positions
        Vector3 targetPositionTop = opening ? originalPositionTop + new Vector3(0, 1.4f, 0) : originalPositionTop;
        Vector3 targetPositionBottom = opening ? originalPositionBottom + new Vector3(0, -1.4f, 0) : originalPositionBottom;

        // Move the door parts until they reach their target positions
        while (Vector3.Distance(topSide.position, targetPositionTop) > 0.01f ||
               Vector3.Distance(bottomSide.position, targetPositionBottom) > 0.01f)
        {
            topSide.position = Vector3.MoveTowards(topSide.position, targetPositionTop, moveSpeed * Time.deltaTime);
            bottomSide.position = Vector3.MoveTowards(bottomSide.position, targetPositionBottom, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Snap to the final positions
        topSide.position = targetPositionTop;
        bottomSide.position = targetPositionBottom;

        isOpen = opening;
        isMoving = false;
    }

    void Update()
    {
        // Check if the generator is powered
        if (generator != null && generator.isPowered)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }
}






