using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevatorOpenLeft : MonoBehaviour
{
    public GameObject elevatorDoorLeft; // Reference to the LockedDoor GameObject
    public float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (elevatorDoorLeft == null)
        {
            Debug.LogError("ElevatorDoorLeft reference is not set in the Inspector.");
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Button pressed");
            if (elevatorDoorLeft != null)
            {

                elevatorDoorLeft.transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
                
            }
            else
            {
                Debug.LogError("ElevatorDoorLeft reference is not set.");
            }
        }
    }
}
