using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WireChangeColor : MonoBehaviour
{
    public Color color;
    private Tilemap wires;

    // Start is called before the first frame update
    void Start()
    {
        wires = GetComponent<Tilemap>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColor()
    {

    }
}
