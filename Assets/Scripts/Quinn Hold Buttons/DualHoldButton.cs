using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualHoldButton : MonoBehaviour
{
    public GameObject Triggered1;
    public GameObject Triggered2;
    //public float speed = 50;
    BoxCollider2D trig;
    public int collide = 0;

    // Start is called before the first frame update
    void Start()
    {

        if (Triggered1 == null)
        {
            Debug.LogError("Triggered1&2 reference is not set in the Inspector.");
        }


    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if ((collision.gameObject.tag == "Player" && collision.gameObject.tag == "Box") || (collision.gameObject.tag == "Box" && collision.gameObject.tag == "Box") || (collision.gameObject.tag == "Player" && collision.gameObject.tag == "Box2"))
        //{
        //    Triggered1.GetComponent<SpriteRenderer>().enabled = false;
        //    trig = Triggered1.GetComponent<BoxCollider2D>();
        //    //trig.enabled = false;
        //    Debug.Log("On");
        //}

        if (collision.gameObject.tag == "Player")
            {
            collide++;
            }
        if (collision.gameObject.tag == "Box")
        {
            collide++;
        }
        //if (collision.gameObject.tag == "Box2")
        //{
        //    collide++;
        //}

        if (collide == 2)
        {
            Triggered1.GetComponent<SpriteRenderer>().enabled = false;
            trig = Triggered1.GetComponent<BoxCollider2D>();
            Triggered2.GetComponent<SpriteRenderer>().enabled = false;
            trig = Triggered2.GetComponent<BoxCollider2D>();
            trig.enabled = false;
            Debug.Log("On");
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        //if ((collision.gameObject.tag == "Player" && collision.gameObject.tag == "Box") || (collision.gameObject.tag == "Box" && collision.gameObject.tag == "Box") || (collision.gameObject.tag == "Player" && collision.gameObject.tag == "Box2"))
        //{
        //    Triggered1.GetComponent<SpriteRenderer>().enabled = true;
        //    trig = Triggered1.GetComponent<BoxCollider2D>();
        //    //trig.enabled = true;
        //    Debug.Log("Off");
        //}
       
        if (collision.gameObject.tag == "Player")
        {
            collide--;
        }
        if (collision.gameObject.tag == "Box")
        {
            collide--;
        }
        //if (collision.gameObject.tag == "Box2")
        //{
        //    collide--;
        //}

        if (collide != 2)
        {
            Triggered1.GetComponent<SpriteRenderer>().enabled = true;
            trig = Triggered1.GetComponent<BoxCollider2D>();
            Triggered2.GetComponent<SpriteRenderer>().enabled = true;
            trig = Triggered2.GetComponent<BoxCollider2D>();
            trig.enabled = true;
            Debug.Log("Off");
        }

    }
}
