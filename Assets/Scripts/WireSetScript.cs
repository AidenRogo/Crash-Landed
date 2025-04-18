using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WireSetScript : MonoBehaviour
{
    public Color wireColor;
    public Tilemap colorSet;
    public Tilemap lightSet;
    // Start is called before the first frame update
    private void Start()
    {
        lightSet.GetComponentInChildren<Tilemap>().color = wireColor;
    }

    public void TurnOn()
    {
        colorSet.color = wireColor;
    }

    public void TurnOff()
    {
        colorSet.color = Color.black;
    }
}
