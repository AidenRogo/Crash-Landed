using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFloor : MonoBehaviour
{
    public GameObject target;
    public GameObject targetHitBox;
    private int detected = 0;

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
            PlayerOffFloor();
        }
    }

    private void PlayerOffFloor()
    {
        
        target.transform.position = new Vector3(-8f, 14f, 0f);
    }
}
