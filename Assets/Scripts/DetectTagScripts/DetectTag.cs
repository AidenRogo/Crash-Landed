using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DetectTag : MonoBehaviour
{
    public string targetTag;
    private int detected = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            detected++;
            GotOnTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            detected--;
        }
        if (detected < 1)
        {
            GotOffTarget();
        }
    }
    abstract public void GotOnTarget();

    abstract public void GotOffTarget();

    //parent.transform.position = new Vector3(-8f, 14f, 0f);
}
