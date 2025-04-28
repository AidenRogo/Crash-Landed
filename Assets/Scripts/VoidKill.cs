using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidKill : MonoBehaviour
{
    // SHRINK AND FADE

    [SerializeField]
    private Color colorToTurnTo = Color.black;

    public float shrinkSpeed = 3.5f;
    private float time = 0;
    private Vector3 spawnPoint;

    private PlayerController controller;
    private Renderer spriteRenderer;

    // SPRING PLAYER PULL


    // SET SPAWN POINT


    void Start()
    {
        spawnPoint = transform.position;

        controller = GetComponent<PlayerController>();
        spriteRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Void"))
        {
            StartCoroutine(Shrink());
        }
    }
    private IEnumerator Shrink()
    {
        yield return new WaitForSeconds(0.1f);
        controller.move.Disable();

        

        while (transform.localScale.x > 0.05f && transform.localScale.y > 0.05f)
        {
            time += Time.deltaTime;
            transform.localScale *= 1 - shrinkSpeed * Time.deltaTime;
            spriteRenderer.material.color = Color.Lerp(Color.white, colorToTurnTo, time);
            yield return null;
        }

        time = 0;
        yield return new WaitForSeconds(0.2f);
        transform.localScale = Vector3.one;
        spriteRenderer.material.color = Color.white;
        float dist = Vector3.Distance(spawnPoint, transform.position);
        transform.position = spawnPoint;
        yield return new WaitForSeconds(dist * 0.12f);
        controller.move.Enable();
    }
   
}
