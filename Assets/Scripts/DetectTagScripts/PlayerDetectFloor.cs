using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectFloor : DetectTag
{
    public GameObject parent;
    private Vector3 originalPosition;
    private bool isOnPressurePlate = false;

    private void Start()
    {
        originalPosition = parent.transform.position;
    }

    public override void GotOffTarget()
    {
        if (!isOnPressurePlate)
        {
            parent.transform.position = originalPosition;
        }
    }

    public override void GotOnTarget()
    {
        // Additional logic for when the player gets on the target can be added here
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PressurePlate"))
        {
            isOnPressurePlate = true;
        }
        else if (other.CompareTag("Pit"))
        {
            parent.transform.position = originalPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PressurePlate"))
        {
            isOnPressurePlate = false;
        }
    }
}
