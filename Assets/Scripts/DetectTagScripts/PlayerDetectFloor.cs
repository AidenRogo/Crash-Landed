using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectFloor : DetectTag
{
    public GameObject parent;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = parent.transform.position;
    }

    public override void GotOffTarget()
    {
        parent.transform.position = originalPosition;
    }

    public override void GotOnTarget()
    {
        
    }
}
