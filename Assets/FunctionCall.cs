using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionCall : MonoBehaviour
{
    public WireChangeColor script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        WireChangeColor.ChangeColor();
    }
}
