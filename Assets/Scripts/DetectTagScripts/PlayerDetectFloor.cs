using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectFloor : DetectTag
{
    public GameObject parent;

    public override void GotOffTarget()
    {
        parent.transform.position = new Vector3(-8f, 14f, 0f);
    }

    public override void GotOnTarget()
    {
        
    }
}
