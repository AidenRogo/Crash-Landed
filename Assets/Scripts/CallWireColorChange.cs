using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CallWireColorChange : MonoBehaviour
{
    public GameObject WireSet;
    private WireSetScript script;
    private int collisionCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        script = WireSet.GetComponent<WireSetScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Fuse") || collision.CompareTag("Box"))
        {
            collisionCount++;

            script.TurnOn();
            Debug.Log("testonetwothree");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Fuse") || collision.CompareTag("Box"))
        {
            collisionCount--;
            if (collisionCount == 0)
            {
                script.TurnOff();
            }
        }
    }
}
