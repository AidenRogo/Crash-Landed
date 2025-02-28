using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldButton : MonoBehaviour
{

    public GameObject Triggered;
    public float speed = 3;
    BoxCollider2D trig;

    // Start is called before the first frame update
    void Start()
    {

        if (Triggered == null)
        {
            Debug.LogError("Triggered reference is not set in the Inspector.");
        }


    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            Triggered.GetComponent<SpriteRenderer>().enabled = false;
            trig = Triggered.GetComponent<BoxCollider2D>();
            trig.enabled = false;
            Debug.Log("On");

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Box")
        {
            Triggered.GetComponent<SpriteRenderer>().enabled = true;
            trig = Triggered.GetComponent<BoxCollider2D>();
            trig.enabled = true;
            Debug.Log("Off");

        }


    }


}
