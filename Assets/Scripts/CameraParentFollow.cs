using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraParentFollow : MonoBehaviour
{
    public GameObject target;
    public float speed = 1f;
    private Rigidbody2D rb;
    private bool onTarget = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        float distance = Mathf.Sqrt(Mathf.Pow(target.transform.position.x - transform.position.x, 2) + Mathf.Pow(target.transform.position.x - transform.position.x, 2));
        //Debug.Log("Direction: " + direction + "\nDistance: " + distance + "\n\n");
        if (!onTarget)
        {
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == target.GetComponent<BoxCollider2D>())
        {
            onTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == target.GetComponent<BoxCollider2D>())
        {
            onTarget = false;
        }
    }
}
