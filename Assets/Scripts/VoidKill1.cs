using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidKill1 : MonoBehaviour
{
    public GameObject parent;
    private Vector3 originalPosition;
    private Vector3 OriginalSize;
    public float shrinkSpeed = 0.1f; // Speed of the door movement
    public float shrinkFactor = 0.5f; // Adjust this value to control the shrink amount
    private Coroutine time;
    private float time2;


    private Renderer rend;

    // Color value that we can set in Inspector
    // It's White by default
    [SerializeField]
    private Color colorToTurnTo = Color.red;
    //public GameObject Wire;
    private Color color2;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = parent.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Void"))
        {
           
  
        // Assign Renderer component to rend variable
        rend = GetComponent<Renderer>();

        // Change sprite color to selected color
        color2 = rend.material.color;

        StartCoroutine(Shrink());

    
    parent.transform.position = originalPosition;
        }
    }
    private IEnumerator Shrink()
    {
        time2 = 0;

        while (transform.localScale.x > 0.01f && transform.localScale.y > 0.01f)
        {
            time2 += Time.deltaTime;
            //transform.localScale = new Vector3(shrinkFactor, shrinkFactor, shrinkSpeed * Time.deltaTime);

            transform.localScale *= 1 - shrinkSpeed * Time.deltaTime;
            rend.material.color = Color.Lerp(color2, colorToTurnTo, time2);

            Debug.Log("Scale Change");
            yield return null;
        }
        parent.transform.position = originalPosition;
    }
}
