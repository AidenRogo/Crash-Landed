using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidKill : MonoBehaviour
{
    private Vector3 originalPosition;
    private Vector3 OriginalSize;
    public float shrinkSpeed = 0.1f; // Speed of the door movement
    //public float shrinkFactor = 0.5f; // Adjust this value to control the shrink amount
    private Coroutine time;
    private float time2;

    //controler script can be set here and made private
    public PlayerController controller;

    private Renderer rend;

    // Color value that we can set in Inspector
    // It's White by default
    [SerializeField]
    private Color colorToTurnTo = Color.red;
    
    //Base Color used to get color inbetween it and the goal color
    //can be removed and color.white used instead
    private Color color2;

    // Start is called before the first frame update
    void Start()
    {
        OriginalSize = transform.localScale;
        originalPosition = transform.position;
        //originalPosition = parent.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Void"))
        {
           
  
            // Assign Renderer component to rend variable
            rend = GetComponent<Renderer>();

            // Change sprite color to selected color
            color2 = rend.material.color;
            //color2 = Color.green;

            StartCoroutine(Shrink()); //this is the corutine

        }
    }
    private IEnumerator Shrink()
    {
        time2 = 0;

        yield return new WaitForSeconds(0.2f);
        controller.move.Disable();
        

        while (transform.localScale.x > 0.01f && transform.localScale.y > 0.01f)
        {
            time2 += Time.deltaTime;
            //transform.localScale = new Vector3(shrinkFactor, shrinkFactor, shrinkSpeed * Time.deltaTime);

            transform.localScale *= 1 - shrinkSpeed * Time.deltaTime;

            rend.material.color = Color.Lerp(color2, colorToTurnTo, time2);
            //Lerp gets a color between a and b multiplied by t split up like a loading bar
            //Each loop of this increasses Time2 making it closer to the goal color

            Debug.Log("Scale Change");
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        transform.localScale = OriginalSize;
        rend.material.color = Color.white;
        //using transform instead of the parent
        transform.position = originalPosition;
        yield return new WaitForSeconds(1f);
        controller.move.Enable();
    }
   
}
