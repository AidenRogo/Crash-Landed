using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidPlayerPull : MonoBehaviour
{
    public SpringJoint2D spring;
    //public GameObject player;
    public Rigidbody2D Void;
    // Start is called before the first frame update
    void Start()
    {
        //spring.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Void"))
        {
            //spring.connectedBody = collision.GetComponent<Rigidbody2D>();
            //spring.enabled = true;
        }
    }
}
