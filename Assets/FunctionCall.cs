using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionCall : MonoBehaviour
{
    public GameObject layer;
    private WireChangeColor script;
    // Start is called before the first frame update
    void Start()
    {
        script = layer.GetComponent<WireChangeColor>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        script.TurnOn();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        script.TurnOff();
    }
}
