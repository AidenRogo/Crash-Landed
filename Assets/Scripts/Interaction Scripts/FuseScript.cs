using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FuseScript : MonoBehaviour
{
    public GameObject elevatorDoorLeft; // Reference to the LockedDoor GameObject
    public GameObject generator;
    public float speed = 3;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (generator == null)
        {
            Debug.LogError("generator reference is not set in the Inspector.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fuse")&& count ==0)
        {
            Debug.Log("Fuse Touches Generator");
            if (generator != null)
            {
                count++;
                elevatorDoorLeft.transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
               
            }
            else
            {
                Debug.LogError("generator reference is not set.");
            }
        }
    }

}
