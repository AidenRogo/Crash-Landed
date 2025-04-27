using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidPullScript : MonoBehaviour
{

    public SpringJoint2D spring;
    public GameObject player;
    public Rigidbody2D playerBody;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //spring.connectedBody = collision.GetComponentInParent<Rigidbody2D>();
        }
    }
}
