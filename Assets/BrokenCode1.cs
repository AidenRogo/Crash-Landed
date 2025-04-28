using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrokenCode1 : MonoBehaviour
{
    // SHRINK AND FADE

    [SerializeField]
    private Color colorToTurnTo = Color.black; //color player will fade too

    public float shrinkSpeed = 3.5f; //how fast the Player shrinks

    private Vector3 spawnPoint; //position player will return too
    private float time = 0f; //time tracking varriable

    private PlayerController controller; //player controller script
    private Renderer rend; //player sprit renderer


    // SPRING PLAYER PULL

    public SpringJoint2D playerSpring; //Player spring that will be attached to the void tile they are pulled into
    public Rigidbody2D targetVoid; //rigidbody of void tile the Player collides with



    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;

        rend = GetComponent<Renderer>();
        controller = GetComponent<PlayerController>();

        playerSpring = GetComponent<SpringJoint2D>();
        playerSpring.enabled = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Void"))
        {
            playerSpring.connectedBody = other.GetComponent<Rigidbody2D>();
            playerSpring.connectedAnchor = new Vector3(-1.0f, 0, 0);
            StartCoroutine(Shrink());
        }
    }

    private IEnumerator Shrink()
    {
        yield return new WaitForSeconds(0.1f);
        controller.move.Disable();
        playerSpring.enabled = true;


        while (transform.localScale.x > 0.01f && transform.localScale.y > 0.01f)
        {
            time += Time.deltaTime;
            transform.localScale *= 1 - shrinkSpeed * Time.deltaTime;
            rend.material.color = Color.Lerp(Color.white, colorToTurnTo, time);
            yield return null;
        }

        time = 0;
        yield return new WaitForSeconds(0.15f);
        transform.localScale = Vector3.one;
        rend.material.color = Color.white;
        float dist = Vector3.Distance(spawnPoint, transform.position);
        playerSpring.connectedBody = null;
        playerSpring.enabled = false;
        transform.position = spawnPoint;
        yield return new WaitForSeconds(dist * 0.18f);
        controller.move.Enable();
    }

}