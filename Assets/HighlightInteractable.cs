using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightInteractable : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
    }

    // Update is called once per frame
    public void unHighlight()
    {
        Debug.Log("Uncolored");
        spriteRenderer.color = Color.white;
    }
    public void Highlight()
    {
        Debug.Log("colored");

        spriteRenderer.color = Color.yellow;
    }
}
