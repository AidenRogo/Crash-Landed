using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorButton : MonoBehaviour
{
    public GameObject lockedDoor; // Reference to the LockedDoor GameObject

    // Start is called before the first frame update
    void Start()
    {
        if (lockedDoor == null)
        {
            Debug.LogError("LockedDoor reference is not set in the Inspector.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to detect collision with the player
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Button pressed");
            if (lockedDoor != null)
            {
                Destroy(lockedDoor);
            }
            else
            {
                Debug.LogError("LockedDoor reference is not set.");
            }
        }
    }
}
