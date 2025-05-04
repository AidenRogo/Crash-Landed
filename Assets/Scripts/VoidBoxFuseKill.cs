using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidBoxFuseKill : MonoBehaviour
{
    // SHRINK AND FADE

    [SerializeField]
    private Color colorToTurnTo = Color.black;

    public float shrinkSpeed = 3.5f;
    public float minSize = 0.05f;
    private float time = 0;
    public Renderer spriteRenderer;

    // SPRING PLAYER PULL

    public SpringJoint2D ItemSpring;
    public Collider2D hitBox;


    // SET SPAWN POINT

    private Vector3 spawnPoint;


    void Start()
    {
        spawnPoint = transform.position;
        ItemSpring.enabled = false;

        //hitBox = GetComponent<Collider2D>();
        //spriteRenderer = GetComponent<Renderer>();
        //controller = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Void"))
        {
            ItemSpring.connectedBody = collision.GetComponent<Rigidbody2D>();
            ItemSpring.connectedAnchor = collision.GetComponent<VoidAnchorPoint>().anchorPoint;
            hitBox.enabled = false;
            ItemSpring.enabled = true;
            StartCoroutine(Shrink());
        }
    }
    private IEnumerator Shrink()
    {
        yield return new WaitForSeconds(0.1f);

        

        while (transform.localScale.x > 0.05f && transform.localScale.y > 0.05f)
        {
            time += Time.deltaTime;
            transform.localScale *= 1 - shrinkSpeed * Time.deltaTime;
            spriteRenderer.material.color = Color.Lerp(Color.white, colorToTurnTo, time);
            yield return null;
        }

        time = 0;
        ItemSpring.enabled = false;
        yield return new WaitForSeconds(0.2f);
        transform.localScale = Vector3.one;
        spriteRenderer.material.color = Color.white;
        float dist = Vector3.Distance(spawnPoint, transform.position);
        transform.position = spawnPoint;
        yield return new WaitForSeconds(dist * 0.12f);
        hitBox.enabled = true;
    }
   
}
