using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartElevator : MonoBehaviour
{
    public SpriteRenderer elevatorSprite; // Reference to the SpriteRenderer component of the elevator
    public Animator ElevetorAnimator;
    public BoxCollider2D myCollider;
    // Start is called before the first frame update
    void Start()
    {
        myCollider.isTrigger = false;
    }

    
}
