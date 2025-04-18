using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CallWireColorChange : MonoBehaviour
{
    public GameObject WireSet;
    private WireSetScript script;
    
    // Start is called before the first frame update
    void Start()
    {
        script = WireSet.GetComponent<WireSetScript>();
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
