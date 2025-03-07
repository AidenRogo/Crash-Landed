using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFloor : MonoBehaviour
{
    public GameObject targetHitBox;
    private int detected = 0;
    private DetectableHitBox target;
    public void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetHitBox.tag))
        {
            detected++;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetHitBox.tag))
        {
            detected--;
        }
        if (detected < 1)
        {

        }
    }
}
