using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{

    private Renderer rend;
    private Color colorToTurnTo = Color.white;

    void SetColorOn()
    {
        rend = GetComponent<Renderer>();

        // Change sprite color to selected color
        rend.material.color = colorToTurnTo;
    }
    void SetColorOff()
    {
        rend = GetComponent<Renderer>();

        // Change sprite color to selected color
        rend.material.color = Color.white;
    }
}
