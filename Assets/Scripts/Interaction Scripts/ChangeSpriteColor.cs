using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteColor : MonoBehaviour
{
    // Reference to Sprite Renderer component
    private Renderer rend;

    // Color value that we can set in Inspector
    // It's White by default
    [SerializeField]
    private Color colorToTurnTo = Color.white;
    public GameObject Wire;      

    void OnTriggerEnter2D()
    {
            // Assign Renderer component to rend variable
            rend = GetComponent<Renderer>();

            // Change sprite color to selected color
            rend.material.color = colorToTurnTo;
    }

}
