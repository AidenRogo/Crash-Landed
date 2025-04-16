using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FunctionCall : MonoBehaviour
{
    public Tilemap layer;
    private WireChangeColor script;
    
    // Start is called before the first frame update
    void Start()
    {
        script = layer.GetComponent<WireChangeColor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        script.TurnOn();
        Debug.Log("testonetwothree");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        script.TurnOff();
    }
}
